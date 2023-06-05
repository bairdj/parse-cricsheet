namespace ParseCricsheet.Model.Input;

public record Toss {
    public bool? Uncontested { get; init; }
    public string Decision { get; init; }
    public string Winner { get; init; }

    public Toss(bool? uncontested, string decision, string winner) {
        Uncontested = uncontested;
        Decision = decision;
        Winner = winner;
    }
}