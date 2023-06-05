namespace ParseCricsheet.Model.Input;
using System.Text.Json.Serialization;

public record Extras
{
    public int Byes { get; init; }
    [JsonPropertyName("legbyes")]
    public int LegByes { get; init; }
    [JsonPropertyName("noballs")]
    public int NoBalls { get; init; }
    public int Penalty { get; init; }
    public int Wides { get; init; }
}
