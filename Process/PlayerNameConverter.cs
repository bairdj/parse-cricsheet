using System.Text.Json;
using System.Text.Json.Serialization;
using ParseCricsheet.Model.Input;

namespace ParseCricsheet.Process;

public class PlayerNameJsonConverter : JsonConverter<PlayerName>
{
    public override PlayerName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new PlayerName(value!);
    }

    public override void Write(Utf8JsonWriter writer, PlayerName value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Name);
    }

    public override PlayerName ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new PlayerName(value!);
    }
}
