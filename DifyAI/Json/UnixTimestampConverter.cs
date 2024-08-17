using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace DifyAI.Json
{
    internal class UnixTimestampConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            long unixTime = reader.GetInt64();
            return DateTimeOffset.FromUnixTimeSeconds(unixTime);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset dateTimeValue, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(dateTimeValue.ToUnixTimeSeconds());
        }
    }
    
    internal class UnixTimestampNullConverter : JsonConverter<DateTimeOffset?>
    {
        public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out long timestamp))
            {
                return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
            }

            throw new JsonException("Invalid Unix timestamp format");
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteNumberValue(value.Value.ToUnixTimeSeconds());
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
