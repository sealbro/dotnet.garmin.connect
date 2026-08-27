using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Converters;

public class DateTimeConverter : JsonConverter<DateTime>
{
    private const string Format0 = "yyyy-MM-dd";
    private const string Format1 = "yyyy-MM-dd HH:mm:ss";
    private const string Format2 = "yyyy-MM-dd\\THH:mm:ss.f";
    private const string Format3 = "yyyy-MM-dd\\THH:mm:ss.ff";
    private const string Format4 = "yyyy-MM-dd\\THH:mm:ss.fff";
    private const string Format5 = "yyyy-MM-dd\\THH:mm:ss.fffzzz";
    private static readonly string[] Formats = [Format2, Format3, Format4, Format5, Format1, Format0];

    // AdjustToUniversal only kicks in for formats carrying an offset (Format5); without it the
    // result would depend on the machine timezone. Offset-less formats stay Unspecified.
    private const DateTimeStyles Styles = DateTimeStyles.AdjustToUniversal;

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return default;
            // Garmin also reports timestamps as GMT milliseconds since epoch.
            case JsonTokenType.Number:
                return DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).UtcDateTime;
        }

        var value = reader.GetString();

        if (string.IsNullOrEmpty(value))
        {
            return default;
        }

        if (DateTime.TryParseExact(value, Formats, CultureInfo.InvariantCulture, Styles, out var parsed))
        {
            return parsed;
        }

        // Not one of Garmin's quirky shapes — fall back to the standard ISO 8601 handling
        // (trailing `Z`, 7-digit fractions, ...) this converter now replaces globally.
        if (reader.TryGetDateTime(out var iso))
        {
            return iso;
        }

        throw new FormatException(
            $"'{value}' does not match any supported date time format: {string.Join(", ", Formats)} or ISO 8601.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // Unspecified values are written as-is: they carry the caller's wall clock time
        // (Garmin's `...Local` fields), converting them would shift the timestamp.
        var utc = value.Kind == DateTimeKind.Local ? value.ToUniversalTime() : value;

        writer.WriteStringValue(utc.ToString(Format4, CultureInfo.InvariantCulture));
    }
}
