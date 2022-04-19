
namespace Square.Utilities
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [JsonConverter(typeof(JsonObjectSerializer))]
    public class JsonObject
    {
        private readonly JToken json;

        private JsonObject(JObject json)
        {
            this.json = json;
        }

        /// <summary>
        /// Return current JSON string.
        /// </summary>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(json, Formatting.None);
        }

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

        /// <summary>
        /// Getter for the stored JSON.
        /// </summary>
        public JToken GetStoredObject()
        {
            return json;
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