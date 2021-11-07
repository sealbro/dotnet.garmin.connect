using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garmin.Connect.Converters
{
    internal class NullIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.Null ? 0 : reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}