using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace X.ComponentModel
{
    [JsonObject]
    public abstract class JsonObject<T> : ValueObject<T>
        where T : JsonObject<T>
    {
        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json);
        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}
