namespace ParseCricsheet.Model.Input;

public record Match
{
    public string? MatchId { get; set; }
    public Meta Meta { get; init; }
    public Info Info { get; init; }
    public IEnumerable<Innings> Innings { get; init; }

    public Match(Meta meta, Info info, IEnumerable<Innings> innings) {
        Meta = meta;
        Info = info;
        Innings = innings;
    }
}
