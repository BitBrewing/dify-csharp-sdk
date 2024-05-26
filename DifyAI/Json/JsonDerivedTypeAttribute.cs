using System;
using System.Text.Json.Serialization;

namespace DifyAI.Json
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
    internal class JsonDerivedTypeAttribute : JsonAttribute
    {
        public Type DerivedType { get; }

        public string TypeDiscriminator { get; }

        public JsonDerivedTypeAttribute(Type derivedType, string typeDiscriminator)
        {
            DerivedType = derivedType;
            TypeDiscriminator = typeDiscriminator;
        }
    }
}
