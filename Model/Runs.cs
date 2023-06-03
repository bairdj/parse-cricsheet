namespace ParseCricsheet.Model;

public record Runs
{
    public int Batsman { get; init; }
    public int Extras { get; init; }
    public bool? NonBoundary { get; init; }
    public int Total { get; init; }
}
