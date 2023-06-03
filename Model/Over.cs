namespace ParseCricsheet.Model;

public record Over {
    public int Number { get; init; }
    public IEnumerable<Delivery> Deliveries { get; init; }

    public Over(int number, IEnumerable<Delivery> deliveries) {
        Number = number;
        Deliveries = deliveries;
    }
}
