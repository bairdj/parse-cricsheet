namespace ParseCricsheet.Model;

public record Fielder
{
    public string Name { get; init; }
    public bool? Substitute { get; init; }
}
