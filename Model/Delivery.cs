namespace ParseCricsheet.Model;

public record Delivery {
    public string Batter { get; init; }
    public string Bowler { get; init; }
    public Extras? Extras { get; init; }
    public string NonStriker { get; init; }
    public Runs Runs { get; init; }
    public IEnumerable<Wicket>? Wickets { get; init; }
    public Review? Review { get; init; }

    public Delivery(string batter, string bowler, Extras? extras, string nonStriker, Runs runs, IEnumerable<Wicket>? wickets, Review? review) {
        Batter = batter;
        Bowler = bowler;
        Extras = extras;
        NonStriker = nonStriker;
        Runs = runs;
        Wickets = wickets;
        Review = review;
    }
}
