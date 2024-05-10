using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DifyAI.Converters
{
	internal abstract class PolymorphicConverterBase<T> : JsonConverter<T>
    {
        private readonly string _polymorphic;
        private readonly IDictionary<string, Type> _derivedTypes;

        protected PolymorphicConverterBase(string polymorphic, IDictionary<string, Type> derivedTypes)
        {
            _polymorphic = polymorphic;
            _derivedTypes = derivedTypes;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);

            var root = doc.RootElement;
            var type = root.GetProperty(_polymorphic).GetString();

            if (_derivedTypes.TryGetValue(type, out var derivedType))
                return (T)JsonSerializer.Deserialize(root.GetRawText(), derivedType, options);

            throw new JsonException($"Unrecognized {_polymorphic}: {type}");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}

