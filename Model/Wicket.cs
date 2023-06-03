namespace ParseCricsheet.Model;

public record Wicket
{
    public string Kind { get; init; }
    public string PlayerOut { get; init; }
    public IEnumerable<Fielder>? Fielders { get; init; }

    public Wicket(string kind, string playerOut, IEnumerable<Fielder>? fielders) {
        Kind = kind;
        PlayerOut = playerOut;
        Fielders = fielders;
    }
}
