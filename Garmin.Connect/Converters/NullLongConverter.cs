using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Converters
{
    internal class NullLongConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.Null ? 0 : reader.GetInt64();
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}