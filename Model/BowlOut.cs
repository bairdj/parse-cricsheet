namespace ParseCricsheet.Model;

public record BowlOut
{
    public string Bowler { get; init; }
    public string Outcome { get; init; }

    public BowlOut(string bowler, string outcome) {
        Bowler = bowler;
        Outcome = outcome;
    }
}
