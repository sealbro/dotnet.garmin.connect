using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Converters;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return default;
        }

        var value = reader.GetString();

        return string.IsNullOrEmpty(value)
            ? default
            : DateOnly.ParseExact(value, Format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}
