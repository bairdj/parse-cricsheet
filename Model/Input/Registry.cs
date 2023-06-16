namespace ParseCricsheet.Model.Input;

public struct PlayerId {
    public string Id { get; init; }

    public PlayerId(string id) {
        Id = id;
    }
    public static implicit operator PlayerId(string id) => new(id);
    public static implicit operator string(PlayerId id) => id.Id;
}

public struct PlayerName {
    public string Name { get; init; }

    public PlayerName(string name) {
        Name = name;
    }
    public static implicit operator PlayerName(string name) => new(name);
    public static implicit operator string(PlayerName name) => name.Name;
}



public record Registry {
    public IDictionary<PlayerName, PlayerId> People { get; init; }

    public Registry(IDictionary<PlayerName, PlayerId> people) {
        People = people;
    }
}