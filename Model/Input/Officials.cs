namespace ParseCricsheet.Model.Input;

public record Officials
{
    public IEnumerable<string>? MatchReferees { get; init; }
    public IEnumerable<string>? ReserveUmpires { get; init; }
    public IEnumerable<string>? TvUmpires { get; init; }
    public IEnumerable<string>? Umpires { get; init; }
}
