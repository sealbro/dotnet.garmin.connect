using System;
using System.Buffers;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Converters
{
    internal class DateTimeConverter : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-dd HH:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(GetRawString(reader), Format, CultureInfo.InvariantCulture);
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
                ReadOnlySequence<byte> sequence = reader.ValueSequence;
                array = sequence.ToArray<byte>();
            }

            return Encoding.UTF8.GetString(array);
        }
    }
}