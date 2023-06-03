namespace ParseCricsheet.Model;

public record Event {
    public string Name { get; init; }
    public int? MatchNumber { get; init; }
    public string? Group {get; init; }
    public string? Stage { get; init; }

    public Event(string name, int? matchNumber, string? group, string? stage) {
        Name = name;
        MatchNumber = matchNumber;
        Group = group;
        Stage = stage;
    }
}
