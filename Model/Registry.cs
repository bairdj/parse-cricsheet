namespace ParseCricsheet.Model;

public record Registry {
    public IDictionary<string, string> People { get; init; }

    public Registry(IDictionary<string, string> people) {
        People = people;
    }
}