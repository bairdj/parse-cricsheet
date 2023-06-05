namespace ParseCricsheet.Model.Input;

public record Review
{
    public string Batter { get; init; }
    public string By { get; init; }
    public string Decision { get; init; }
    public string? Umpire { get; init; }
    public bool? UmpiresCall { get; init; }

    public Review(string batter, string by, string decision, string? umpire, bool? umpiresCall)
    {
        Batter = batter;
        By = by;
        Decision = decision;
        Umpire = umpire;
        UmpiresCall = umpiresCall;
    }
}
