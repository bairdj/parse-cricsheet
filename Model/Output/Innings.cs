namespace ParseCricsheet.Model.Output;

public class Innings
{
    public string MatchId { get; init; }
    public Match Match { get; init; }
    public int InningsNumber { get; init; }
    public string BattingTeam { get; init; }
    public string BowlingTeam { get; init; }

}
