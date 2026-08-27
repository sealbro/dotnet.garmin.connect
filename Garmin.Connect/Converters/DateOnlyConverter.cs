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

        if (string.IsNullOrEmpty(value))
        {
            return default;
        }

        if (DateOnly.TryParseExact(value, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
        {
            return parsed;
        }

        // Some endpoints return a full timestamp where a plain date is expected.
        if (reader.TryGetDateTime(out var dateTime))
        {
            return DateOnly.FromDateTime(dateTime);
        }

        throw new FormatException($"'{value}' does not match the supported date format {Format} or ISO 8601.");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}
