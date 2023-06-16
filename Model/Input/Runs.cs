namespace ParseCricsheet.Model.Input;

public record Runs
{
    public int Batter { get; init; }
    public int Extras { get; init; }
    public bool? NonBoundary { get; init; }
    public int Total { get; init; }
}
