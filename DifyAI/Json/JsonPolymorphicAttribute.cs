using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DifyAI.Json
{
    internal class JsonPolymorphicAttribute : JsonConverterAttribute
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<string, Type>> _derivedTypesMap = new();

        public override JsonConverter CreateConverter(Type typeToConvert)
        {
            var derivedTypes = _derivedTypesMap.GetOrAdd(
                typeToConvert,
                type => type
                    .GetCustomAttributes<JsonDerivedTypeAttribute>()
                    .ToDictionary(x => x.TypeDiscriminator, x => x.DerivedType)
                );

            return new JsonPolymorphicConverter(TypeDiscriminatorPropertyName, derivedTypes, DefaultType);
        }

        public string TypeDiscriminatorPropertyName { get; set; } = "type";

        public Type DefaultType { get; set; }

        private class JsonPolymorphicConverter : JsonConverter<object>
        {
            private readonly string _typeDiscriminatorPropertyName;
            private readonly Dictionary<string, Type> _derivedTypes;
            private readonly Type _defaultType;

            public JsonPolymorphicConverter(string typeDiscriminatorPropertyName, Dictionary<string, Type> derivedTypes, Type defaultType)
            {
                _typeDiscriminatorPropertyName = typeDiscriminatorPropertyName;
                _derivedTypes = derivedTypes;
                _defaultType = defaultType;
            }

            public override bool CanConvert(Type typeToConvert)
            {
                return true;
            }

            public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var doc = JsonDocument.ParseValue(ref reader);

                var root = doc.RootElement;
                var type = root.GetProperty(_typeDiscriminatorPropertyName).GetString();

                if (_derivedTypes.TryGetValue(type, out var derivedType))
                    return JsonSerializer.Deserialize(root.GetRawText(), derivedType, options);

                if (_defaultType != null)
                    return JsonSerializer.Deserialize(root.GetRawText(), _defaultType, options);

                throw new JsonException($"Unrecognized {_typeDiscriminatorPropertyName}: {type}");
            }

            public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
            }
        }
    }
}