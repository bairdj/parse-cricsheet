namespace ParseCricsheet.Model.Output;

public abstract record Official : DbOutput
{
    public string MatchId { get; init; }
    public string Name { get; init; }
    /// <summary>
    /// Unique identifier for this official/match/type combination.
    /// This is necessary to work around the table-per-hierarchy setup
    /// being unable to handle multiple types with the same primary key,
    /// which is an issue if officals have fulfilled multiple roles in the
    /// same match.
    /// </summary>
    public Guid Id { get; }

    public Official(string matchId, string name) {
        MatchId = matchId;
        Name = name;
        Id = Guid.NewGuid();
    }
}

public record MatchReferee : Official 
{
    public MatchReferee(string matchId, string name) : base(matchId, name) { }
}

public record ReserveUmpire : Official 
{
    public ReserveUmpire(string matchId, string name) : base(matchId, name) { }
}

public record TvUmpire : Official 
{
    public TvUmpire(string matchId, string name) : base(matchId, name) { }
}

public record Umpire : Official 
{
    public Umpire(string matchId, string name) : base(matchId, name) { }
}
