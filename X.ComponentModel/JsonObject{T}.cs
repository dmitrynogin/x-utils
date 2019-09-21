using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace X.ComponentModel
{
    [JsonObject]
    public abstract class JsonObject<T> : ValueObject<T>
        where T : JsonObject<T>
    {
        static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        public static T FromJson(string json) => JsonConvert.DeserializeObject<T>(json);
        public string ToJson() => JsonConvert.SerializeObject(this, Settings);
    }
}
