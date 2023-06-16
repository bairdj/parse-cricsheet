namespace ParseCricsheet.Model.Output;

public record Match {
    public string MatchId { get; init; }
    public int BallsPerOver { get; init; }
    public string? City { get; init; }
    public string MatchType { get; init; }
    public DateOnly? StartDate { get; init; }
    public DateOnly? EndDate { get; init; }
    public string Gender { get; init; }
    public string Venue { get; init; }
    public ICollection<Innings> Innings { get; init; }
    
}