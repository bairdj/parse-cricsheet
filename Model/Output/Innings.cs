namespace ParseCricsheet.Model.Output;

public record Innings : DbOutput
{
    public string MatchId { get; init; }
    public Match Match { get; init; }
    public int InningsNumber { get; init; }
    public string BattingTeam { get; init; }
    public string BowlingTeam { get; init; }

}
