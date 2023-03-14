namespace Square.Utilities
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using APIMatic.Core.Types.Sdk;
    using System.Collections.Generic;

    [JsonConverter(typeof(JsonValueSerializer))]
    public class JsonValue : CoreJsonValue
    {
        private JsonValue(object value)
            : base(value) { }

        /// <summary>
        /// Creates the JSON Value instance with the provided string value.
        /// </summary>
        /// <param name="value">The string value.</param>
        public static JsonValue FromString(string value)
        {
            return new JsonValue(value);
        }

        /// <summary>
        /// Creates the JSON Value instance with the provided boolean value.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        public static JsonValue FromBoolean(bool? value)
        {
            return new JsonValue(value);
        }

        /// <summary>
        /// Creates the JSON Value instance with the provided integer value.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public static JsonValue FromInteger(int? value)
        {
            return new JsonValue(value);
        }

        /// <summary>
        /// Creates the JSON Value instance with the provided double value.
        /// </summary>
        /// <param name="value">The double value.</param>
        public static JsonValue FromDouble(double? value)
        {
            return new JsonValue(value);
        }

        /// <summary>
        /// Creates the JSON Value instance with the provided long value.
        /// </summary>
        /// <param name="value">The long value.</param>
        public static JsonValue FromLong(long? value)
        {
            return new JsonValue(value);
        }

        /// <summary>
        /// Creates the JSON Value instance with the provided object.
        /// </summary>
        /// <param name="value">Any object.</param>
        public static JsonValue FromObject(object value)
        {
            return new JsonValue(value);
        }

        /// <summary>
        /// Creates the JSON Value instance with an array of the provided type.
        /// </summary>
        /// <param name="values">The List of any provided type.</param>
        public static JsonValue FromArray<T>(List<T> values)
        {
            return new JsonValue(values);
        }
    }

    internal class JsonValueSerializer : JsonConverter<JsonValue>
    {
        public override JsonValue ReadJson(JsonReader reader, Type objectType, JsonValue existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return JsonValue.FromObject(JToken.Load(reader));
        }

        public override void WriteJson(JsonWriter writer, JsonValue value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }
}