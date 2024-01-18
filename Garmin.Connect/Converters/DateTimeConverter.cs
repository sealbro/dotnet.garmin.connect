using System;
using System.Buffers;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Converters;

public class DateTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "yyyy-MM-dd HH:mm:ss";
    private const string Format2 = "yyyy-MM-dd\\THH:mm:ss.f";
    private const string Format3 = "yyyy-MM-dd\\THH:mm:ss.fff";
    private static readonly string[] Formats = [Format2, Format3, Format];

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var rawString = GetRawString(reader);
        return DateTime.ParseExact(rawString, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None );
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToUniversalTime().ToString(Format2));

    private static string GetRawString(Utf8JsonReader reader)
    {
        byte[] array;
        if (!reader.HasValueSequence)
        {
            array = reader.ValueSpan.ToArray();
        }
        else
        {
            var sequence = reader.ValueSequence;
            array = sequence.ToArray();
        }

        return Encoding.UTF8.GetString(array);
    }
}