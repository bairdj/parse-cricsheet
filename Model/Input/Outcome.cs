namespace ParseCricsheet.Model.Input;

public record Outcome
{
    public By? By { get; init; }
    public string? BowlOut { get; init; }
    public string? Eliminator { get; init; }
    public string? Method { get; init; }
    public string? Result { get; init; }
    public string? Winner { get; init; }
}
