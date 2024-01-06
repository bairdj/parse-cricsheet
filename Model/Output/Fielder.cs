using ParseCricsheet.Model.Input;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParseCricsheet.Model.Output;

public record Fielder : DbOutput
{
    public string MatchId { get; init; }
    public int InningsNumber { get; init; }
    public int Over { get; init; }
    public int Ball { get; init; }
    public int WicketNumber { get; init; }
    // Store the column name as 'Fielder'
    [Column("Fielder")]
    public PlayerId FielderId { get; init; }
    public bool Substitute { get; init; }
    public int FielderNumber { get; init; }
}