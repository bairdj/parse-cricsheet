namespace ParseCricsheet.Process;
using System.Text.Json;
using System.Text.RegularExpressions;

public class SnakeCaseNamingPolicy : JsonNamingPolicy {
    private readonly Regex _wordStartRegex;

    public SnakeCaseNamingPolicy() {
        _wordStartRegex = new Regex(@"(?<=[a-z])(?=[A-Z])");
    }
    /// <summary>
    /// Converts a name from PascalCase to snake_case.
    /// </summary>
    public override string ConvertName(string name) {
        // Replace word starts with an underscore
        return _wordStartRegex.Replace(name, "_").ToLower();
    }
}
