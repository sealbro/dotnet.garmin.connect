using System;
using System.Buffers;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Converters;

internal class DateTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "yyyy-MM-dd HH:mm:ss";
    private const string Format2nd = "yyyy-MM-dd\\THH:mm:ss.f";
    private readonly static string[] Formats = new string[] { Format, Format2nd };

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string dateTimeString = GetRawString( reader );
        return dateTimeString == "null"
          ? DateTime.MinValue
          : DateTime.ParseExact( dateTimeString, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None );
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToUniversalTime().ToString(Format));

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