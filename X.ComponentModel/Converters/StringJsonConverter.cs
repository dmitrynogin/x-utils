using System;
using Newtonsoft.Json;

namespace X.ComponentModel.Converters
{
    class StringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            objectType == typeof(object) ? false :
            objectType.IsConstructedGenericType && objectType.GetGenericTypeDefinition() == typeof(String<>) ? true :
            CanConvert(objectType.BaseType);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            Activator.CreateInstance(objectType, reader.Value);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            writer.WriteValue(value.ToString());
    }
}