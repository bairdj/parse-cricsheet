using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ParseCricsheet.Process;

public static class RegisterParser
{
    public static List<Model.Output.Player> Parse(StreamReader reader)
    {
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<PlayerMap>();
        return csv.GetRecords<Model.Output.Player>().ToList();
    }

    public static List<Model.Output.Player> Parse(string path)
    {
        using var reader = new StreamReader(path);
        return Parse(reader);
    }
}

public sealed class PlayerMap : ClassMap<Model.Output.Player>
{
    public PlayerMap()
    {
        Map(m => m.PlayerId)
            .Convert(row => new Model.Input.PlayerId(row.Row["identifier"]!));
        Map(m => m.Name).Name("name");
        Map(m => m.UniqueName).Name("unique_name");
        Map(m => m.KeyCricinfo).Name("key_cricinfo");
    }
}