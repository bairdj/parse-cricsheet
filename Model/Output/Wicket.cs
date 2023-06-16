using ParseCricsheet.Model.Input;

namespace ParseCricsheet.Model.Output;

public class Wicket
{
    public string MatchId { get; init; }
    public int InningsNumber { get; init; }
    public int Over { get; init; }
    public int Ball { get; init; }
    public PlayerId Batter { get; init; }
    public PlayerId Bowler { get; init; }
    public string Kind { get; init; }
}