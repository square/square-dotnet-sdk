using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using APIMatic.Core.Types.Sdk;

namespace Square.Utilities
{
    [JsonConverter(typeof(JsonObjectSerializer))]
    public class JsonObject : CoreJsonObject
    {
        private JsonObject(JObject json)
            : base(json) { }

        /// <summary>
        /// Creates the JSON Object instance with the provided JSON string.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        public static JsonObject FromJsonString(string json)
        {
            if (json == null)
            {
                return new JsonObject(null);
            }

            return new JsonObject(JObject.Parse(json));
        }

        /// <summary>
        /// Creates the JSON Object instance with the provided JSON Object.
        /// </summary>
        /// <param name="json">The JSON object.</param>
        internal static JsonObject FromJObject(JObject json)
        {
            return new JsonObject(json);
        }
    }

    internal class JsonObjectSerializer : JsonConverter<JsonObject>
    {
        public override JsonObject ReadJson(JsonReader reader, Type objectType, JsonObject existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return JsonObject.FromJObject(JObject.Load(reader));
        }

        public override void WriteJson(JsonWriter writer, JsonObject value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }
}