namespace ParseCricsheet.Model.Input;

public record Officials
{
    public IEnumerable<String> MatchReferees { get; init; }
    public IEnumerable<String> ReserveUmpires { get; init; }
    public IEnumerable<String> TvUmpires { get; init; }
    public IEnumerable<String> Umpires { get; init; }

    public Officials(IEnumerable<String> matchReferees, IEnumerable<String> reserveUmpires, IEnumerable<String> tvUmpires, IEnumerable<String> umpires) {
        MatchReferees = matchReferees;
        ReserveUmpires = reserveUmpires;
        TvUmpires = tvUmpires;
        Umpires = umpires;
    }
}
