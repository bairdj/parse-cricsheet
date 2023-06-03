namespace ParseCricsheet.Process;
using ParseCricsheet.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class SeasonJsonConverter : JsonConverter<Season>
{
    public override Season Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Season value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
