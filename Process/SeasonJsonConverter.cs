namespace ParseCricsheet.Process;
using ParseCricsheet.Model.Input;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class SeasonJsonConverter : JsonConverter<Season>
{
    public override Season Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new Season(reader.GetString()!);
        }
        if (reader.TokenType == JsonTokenType.Number)
        {
            return new Season(reader.GetInt32());
        }
        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, Season value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }

}
