namespace ParseCricsheet.Model.Output;

public record Match : DbOutput {
    public string MatchId { get; init; }
    public int BallsPerOver { get; init; }
    public string? City { get; init; }
    public string MatchType { get; init; }
    public DateOnly? StartDate { get; init; }
    public DateOnly? EndDate { get; init; }
    public string Gender { get; init; }
    public string Venue { get; init; }
    public ICollection<Innings> Innings { get; init; }
    public string Team1 { get; init; }
    public string Team2 { get; init; }
    public string Result { get; init; }
    public string? ResultMethod { get; init; }
    public string? Winner { get; init; }
    public int? WinRuns { get; init; }
    public int? WinWickets { get; init; }
    public bool WinByInnings { get; init; }
    public string? TossWinner { get; init; }
    public string? TossDecision { get; init; }
    
}