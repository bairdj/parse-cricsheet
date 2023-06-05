namespace ParseCricsheet.Model.Input;

public record Innings
{
    public string Team { get; init; }
    public IEnumerable<Over> Overs { get; init; }
    public bool? Declared { get; init; }
    public bool? Forfeited { get; init; }

    public Innings(string team, IEnumerable<Over> overs) {
        Team = team;
        Overs = overs;
    }
}
