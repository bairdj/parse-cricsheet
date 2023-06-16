using System.Text.Json;
using System.Text.Json.Serialization;
using ParseCricsheet.Model.Input;

namespace ParseCricsheet.Process;

public class PlayerIdJsonConverter : JsonConverter<PlayerId>
{
    public override PlayerId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new PlayerId(value!);
    }

    public override void Write(Utf8JsonWriter writer, PlayerId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Id);
    }
}
