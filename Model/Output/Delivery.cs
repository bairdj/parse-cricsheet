using ParseCricsheet.Model.Input;
namespace ParseCricsheet.Model.Output;

public record Delivery : DbOutput
{
    public string MatchId { get; init; }
    public int InningsNumber { get; init; }
    public int Over { get; init; }
    public int Ball { get; init; }
    public PlayerId Bowler { get; init; }
    public PlayerId Batter { get; init; }
    public PlayerId NonStriker { get; init; }
    public int BatterRuns { get; init; }
    public int Extras { get; init; }
    public int TotalRuns { get; init; }
    public int Byes { get; init; }
    public int LegByes { get; init; }
    public int NoBalls { get; init; }
    public int Penalty { get; init; }
    public int Wides { get; init; }
    

}