namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CustomAttribute.
    /// </summary>
    public class CustomAttribute
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAttribute"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="mValue">value.</param>
        /// <param name="version">version.</param>
        /// <param name="visibility">visibility.</param>
        /// <param name="definition">definition.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="createdAt">created_at.</param>
        public CustomAttribute(
            string key = null,
            JsonValue mValue = null,
            int? version = null,
            string visibility = null,
            Models.CustomAttributeDefinition definition = null,
            string updatedAt = null,
            string createdAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "key", false },
                { "value", false }
            };

            if (key != null)
            {
                shouldSerialize["key"] = true;
                this.Key = key;
            }

            if (mValue != null)
            {
                shouldSerialize["value"] = true;
                this.MValue = mValue;
            }

            this.Version = version;
            this.Visibility = visibility;
            this.Definition = definition;
            this.UpdatedAt = updatedAt;
            this.CreatedAt = createdAt;
        }
        internal CustomAttribute(Dictionary<string, bool> shouldSerialize,
            string key = null,
            JsonValue mValue = null,
            int? version = null,
            string visibility = null,
            Models.CustomAttributeDefinition definition = null,
            string updatedAt = null,
            string createdAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            Key = key;
            MValue = mValue;
            Version = version;
            Visibility = visibility;
            Definition = definition;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// The identifier
        /// of the custom attribute definition and its corresponding custom attributes. This value
        /// can be a simple key, which is the key that is provided when the custom attribute definition
        /// is created, or a qualified key, if the requesting
        /// application is not the definition owner. The qualified key consists of the application ID
        /// of the custom attribute definition owner
        /// followed by the simple key that was provided when the definition was created. It has the
        /// format application_id:simple key.
        /// The value for a simple key can contain up to 60 alphanumeric characters, periods (.),
        /// underscores (_), and hyphens (-).
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; }

        /// <summary>
        /// The value assigned to the custom attribute. It is validated against the custom
        /// attribute definition's schema on write operations. For more information about custom
        /// attribute values,
        /// see [Custom Attributes Overview](https://developer.squareup.com/docs/devtools/customattributes/overview).
        /// </summary>
        [JsonProperty("value")]
        public JsonValue MValue { get; }

        /// <summary>
        /// Read only. The current version of the custom attribute. This field is incremented when the custom attribute is changed.
        /// When updating an existing custom attribute value, you can provide this field
        /// and specify the current version of the custom attribute to enable
        /// [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency).
        /// This field can also be used to enforce strong consistency for reads. For more information about strong consistency for reads,
        /// see [Custom Attributes Overview](https://developer.squareup.com/docs/devtools/customattributes/overview).
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The level of permission that a seller or other applications requires to
        /// view this custom attribute definition.
        /// The `Visibility` field controls who can read and write the custom attribute values
        /// and custom attribute definition.
        /// </summary>
        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public string Visibility { get; }

        /// <summary>
        /// Represents a definition for custom attribute values. A custom attribute definition
        /// specifies the key, visibility, schema, and other properties for a custom attribute.
        /// </summary>
        [JsonProperty("definition", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomAttributeDefinition Definition { get; }

        /// <summary>
        /// The timestamp that indicates when the custom attribute was created or was most recently
        /// updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The timestamp that indicates when the custom attribute was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomAttribute : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeKey()
        {
            return this.shouldSerialize["key"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMValue()
        {
            return this.shouldSerialize["value"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is CustomAttribute other &&                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.Visibility == null && other.Visibility == null) || (this.Visibility?.Equals(other.Visibility) == true)) &&
                ((this.Definition == null && other.Definition == null) || (this.Definition?.Equals(other.Definition) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -616949174;
            hashCode = HashCode.Combine(this.Key, this.MValue, this.Version, this.Visibility, this.Definition, this.UpdatedAt, this.CreatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key)}");
            toStringOutput.Add($"MValue = {(this.MValue == null ? "null" : this.MValue.ToString())}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.Visibility = {(this.Visibility == null ? "null" : this.Visibility.ToString())}");
            toStringOutput.Add($"this.Definition = {(this.Definition == null ? "null" : this.Definition.ToString())}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Key(this.Key)
                .MValue(this.MValue)
                .Version(this.Version)
                .Visibility(this.Visibility)
                .Definition(this.Definition)
                .UpdatedAt(this.UpdatedAt)
                .CreatedAt(this.CreatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "key", false },
                { "value", false },
            };

            private string key;
            private JsonValue mValue;
            private int? version;
            private string visibility;
            private Models.CustomAttributeDefinition definition;
            private string updatedAt;
            private string createdAt;

             /// <summary>
             /// Key.
             /// </summary>
             /// <param name="key"> key. </param>
             /// <returns> Builder. </returns>
            public Builder Key(string key)
            {
                shouldSerialize["key"] = true;
                this.key = key;
                return this;
            }

             /// <summary>
             /// MValue.
             /// </summary>
             /// <param name="mValue"> mValue. </param>
             /// <returns> Builder. </returns>
            public Builder MValue(JsonValue mValue)
            {
                shouldSerialize["value"] = true;
                this.mValue = mValue;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// Visibility.
             /// </summary>
             /// <param name="visibility"> visibility. </param>
             /// <returns> Builder. </returns>
            public Builder Visibility(string visibility)
            {
                this.visibility = visibility;
                return this;
            }

             /// <summary>
             /// Definition.
             /// </summary>
             /// <param name="definition"> definition. </param>
             /// <returns> Builder. </returns>
            public Builder Definition(Models.CustomAttributeDefinition definition)
            {
                this.definition = definition;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetKey()
            {
                this.shouldSerialize["key"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMValue()
            {
                this.shouldSerialize["value"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomAttribute. </returns>
            public CustomAttribute Build()
            {
                return new CustomAttribute(shouldSerialize,
                    this.key,
                    this.mValue,
                    this.version,
                    this.visibility,
                    this.definition,
                    this.updatedAt,
                    this.createdAt);
            }
        }
    }
}