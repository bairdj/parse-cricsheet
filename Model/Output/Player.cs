namespace ParseCricsheet.Model.Output;

public class Player
{
    public Model.Input.PlayerId PlayerId { get; set; }
    public string Name { get; set; } = null!;
    public string UniqueName { get; set; } = null!;
    public int? KeyCricinfo { get; set; }
}
