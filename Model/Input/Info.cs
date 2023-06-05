namespace ParseCricsheet.Model.Input;

public record Info
{
    public int BallsPerOver { get; init; }
    public BowlOut? BowlOut { get; init; }
    public string? City { get; init; }
    public IEnumerable<DateOnly>? Dates { get; init; }
    public string Gender { get; init; }
    public string MatchType { get; init; }
    public int? MatchTypeNumber { get; init; }
    public Officials? Officials { get; init; }
    public Outcome Outcome { get; init; }
    public int? Overs { get; init; }
    public IEnumerable<string>? PlayerOfMatch { get; init; }
    public IDictionary<string, IEnumerable<string>> Players { get; init; }
    public Registry Registry { get; init; }
    public Season Season { get; init; }
    public IDictionary<string, string>? Supersubs { get; init; }
    public string TeamType { get; init; }
    public IEnumerable<string>? Teams { get; init; }
    public Toss Toss { get; init; }
    public string Venue { get; init; }
}
