using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace FactJCTransactionsJCJCM {
    public class TrimStringConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return reader.Value?.ToString()?.Trim();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.WriteValue((value as string)?.Trim());
        }
    }
}
