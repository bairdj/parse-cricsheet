namespace ParseCricsheet.Process;
using System.Text.Json;
using ParseCricsheet.Model.Input;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

public class MatchParser
{
    private readonly JsonSerializerOptions _jsonOptions;

    public MatchParser() {
        _jsonOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = new SnakeCaseNamingPolicy()
        };
        _jsonOptions.Converters.Add(new DateOnlyJsonConverter());
        _jsonOptions.Converters.Add(new SeasonJsonConverter());
        _jsonOptions.Converters.Add(new PlayerIdJsonConverter());
        _jsonOptions.Converters.Add(new PlayerNameJsonConverter());
    }

    public async Task<Match?> ParseAsync(Stream jsonStream) {
        return await JsonSerializer.DeserializeAsync<Match>(jsonStream, _jsonOptions);
    }

    /// <summary>
    /// Parse all JSON files in a directory.
    /// If a file fails to parse, it will be skipped.
    /// </summary>
    public async IAsyncEnumerable<Match> ParseDirectoryAsync(string directoryPath) {
        var files = Directory.EnumerateFiles(directoryPath, "*.json");
        foreach(var filePath in files) {
            using var jsonStream = File.OpenRead(filePath);
            var parsedMatch = await ParseAsync(jsonStream);
            if (parsedMatch == null) continue;
            parsedMatch.MatchId = Path.GetFileNameWithoutExtension(filePath);
            yield return parsedMatch;
        }
    }

    /// <summary>
    /// Parse all JSON files in a ZIP archive.
    /// Useful as the cricsheet.org files are usually provided as ZIP archives.
    /// </summary>
    public async IAsyncEnumerable<Match> ParseZipAsync(string zipPath) {
        using var archive = ZipFile.OpenRead(zipPath);
        foreach(var entry in archive.Entries) {
            if (!entry.Name.EndsWith(".json")) continue;
            using var jsonStream = entry.Open();
            Match? parsedMatch = null;
            try {
                parsedMatch = await ParseAsync(jsonStream);
            } catch (JsonException e) {
                Console.WriteLine($"Failed to parse {entry.Name}: {e.Message}");
            }
            if (parsedMatch != null) {
                parsedMatch.MatchId = Path.GetFileNameWithoutExtension(entry.Name);
                yield return parsedMatch;
            }
        }
    }
}
