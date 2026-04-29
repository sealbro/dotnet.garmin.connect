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

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.ParseExact(reader.GetString()!, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToUniversalTime().ToString(Format4));
}