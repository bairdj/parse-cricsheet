namespace ParseCricsheet.Process;
using ParseCricsheet.Model;
using ParseCricsheet.Model.Input;

public class MatchWriter
{
    public readonly Model.Input.Match _match;
    private readonly IDictionary<PlayerName, PlayerId> _playerMap;

    public MatchWriter(Model.Input.Match match)
    {
        _match = match;
        _playerMap = match.Info.Registry.People;
    }

    public IEnumerable<object> GetMatchEntities()
    {
        if (_match.MatchId == null) {
            throw new ArgumentException("MatchId must be set");
        }
        var outputMatch = new Model.Output.Match
        {
            MatchId = _match.MatchId,
            BallsPerOver = _match.Info.BallsPerOver,
            City = _match.Info.City,
            MatchType = _match.Info.MatchType,
            StartDate = _match.Info.Dates?.First(),
            EndDate = _match.Info.Dates?.Last(),
            Gender = _match.Info.Gender,
            Venue = _match.Info.Venue
        };
        yield return outputMatch;

        // Loop over innings, then overs
        int inningsNumber = 1;
        foreach (var innings in _match.Innings)
        {
            var battingTeam = innings.Team;
            var bowlingTeam = _match.Info.Teams.First(t => t != battingTeam);
            var inningsOutput = new Model.Output.Innings {
                MatchId = _match.MatchId,
                InningsNumber = inningsNumber,
                BattingTeam = innings.Team,
                BowlingTeam = bowlingTeam
            };
            yield return inningsOutput;
            int overNumber = 1;
            foreach(var over in innings.Overs)
            {
                int ballNumber = 1;
                foreach(var delivery in over.Deliveries)
                {
                    yield return new Model.Output.Delivery {
                        MatchId = _match.MatchId,
                        InningsNumber = inningsNumber,
                        Over = overNumber,
                        Ball = ballNumber,
                        Bowler = _playerMap[delivery.Bowler],
                        Batter = _playerMap[delivery.Batter],
                        NonStriker = _playerMap[delivery.NonStriker],
                        BatterRuns = delivery.Runs.Batter,
                        Extras = delivery.Runs.Extras,
                        TotalRuns = delivery.Runs.Total,
                        Byes = delivery.Extras?.Byes ?? 0,
                        LegByes = delivery.Extras?.LegByes ?? 0,
                        NoBalls = delivery.Extras?.NoBalls ?? 0,
                        Penalty = delivery.Extras?.Penalty ?? 0,
                        Wides = delivery.Extras?.Wides ?? 0
                    };
                    
                    if (delivery.Wickets != null) {
                        foreach(var wicket in delivery.Wickets) {
                            yield return new Model.Output.Wicket {
                                MatchId = _match.MatchId,
                                InningsNumber = inningsNumber,
                                Over = overNumber,
                                Ball = ballNumber,
                                Batter = _playerMap[wicket.PlayerOut],
                                Bowler = _playerMap[delivery.Bowler],
                                Kind = wicket.Kind
                            };
                        }
                    }
                    ballNumber++;
                }
                overNumber++;
            }
            inningsNumber++;
        }
    }
}
