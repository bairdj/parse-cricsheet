namespace ParseCricsheet.Model;

public record By
{
    public int? Innings { get; init; }
    public int? Runs { get; init; }
    public int? Wickets { get; init; }
}