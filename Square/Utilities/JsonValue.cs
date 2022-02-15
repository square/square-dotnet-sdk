namespace Square.Utilities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [JsonConverter(typeof(JsonValueSerializer))]
    public class JsonValue
    {
        private readonly object value;

        private JsonValue(object value)
        {
            this.value = value;
        }

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

        /// <summary>
        /// Getter for current value.
        /// </summary>
        internal object GetStoredValue()
        {
            return value;
        }

        /// <summary>
        /// Converts current value into string.
        /// </summary>
        public string ToJsonString()
        {
            return ApiHelper.JsonSerialize(value);
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
            writer.WriteRawValue(value.ToJsonString());
        }
    }
}