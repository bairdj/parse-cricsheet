using ParseCricsheet.Model.Input;

namespace ParseCricsheet.Model.Output;

public record Wicket : DbOutput
{
    public string MatchId { get; init; }
    public int InningsNumber { get; init; }
    public int Over { get; init; }
    public int Ball { get; init; }
    public int WicketNumber { get; init; }
    public PlayerId Batter { get; init; }
    public PlayerId Bowler { get; init; }
    public string Kind { get; init; }
}