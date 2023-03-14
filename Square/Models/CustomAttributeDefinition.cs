namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CustomAttributeDefinition.
    /// </summary>
    public class CustomAttributeDefinition
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomAttributeDefinition"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="schema">schema.</param>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="visibility">visibility.</param>
        /// <param name="version">version.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="createdAt">created_at.</param>
        public CustomAttributeDefinition(
            string key = null,
            JsonObject schema = null,
            string name = null,
            string description = null,
            string visibility = null,
            int? version = null,
            string updatedAt = null,
            string createdAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "key", false },
                { "schema", false },
                { "name", false },
                { "description", false }
            };

            if (key != null)
            {
                shouldSerialize["key"] = true;
                this.Key = key;
            }

            if (schema != null)
            {
                shouldSerialize["schema"] = true;
                this.Schema = schema;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            this.Visibility = visibility;
            this.Version = version;
            this.UpdatedAt = updatedAt;
            this.CreatedAt = createdAt;
        }
        internal CustomAttributeDefinition(Dictionary<string, bool> shouldSerialize,
            string key = null,
            JsonObject schema = null,
            string name = null,
            string description = null,
            string visibility = null,
            int? version = null,
            string updatedAt = null,
            string createdAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            Key = key;
            Schema = schema;
            Name = name;
            Description = description;
            Visibility = visibility;
            Version = version;
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
        /// This field can not be changed
        /// after the custom attribute definition is created. This field is required when creating
        /// a definition and must be unique per application, seller, and resource type.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; }

        /// <summary>
        /// The JSON schema for the custom attribute definition, which determines the data type of the corresponding custom attributes. For more information,
        /// see [Custom Attributes Overview](https://developer.squareup.com/docs/devtools/customattributes/overview). This field is required when creating a definition.
        /// </summary>
        [JsonProperty("schema")]
        public JsonObject Schema { get; }

        /// <summary>
        /// The name of the custom attribute definition for API and seller-facing UI purposes. The name must
        /// be unique within the seller and application pair. This field is required if the
        /// `visibility` field is `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Seller-oriented description of the custom attribute definition, including any constraints
        /// that the seller should observe. May be displayed as a tooltip in Square UIs. This field is
        /// required if the `visibility` field is `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// The level of permission that a seller or other applications requires to
        /// view this custom attribute definition.
        /// The `Visibility` field controls who can read and write the custom attribute values
        /// and custom attribute definition.
        /// </summary>
        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        public string Visibility { get; }

        /// <summary>
        /// Read only. The current version of the custom attribute definition.
        /// The value is incremented each time the custom attribute definition is updated.
        /// When updating a custom attribute definition, you can provide this field
        /// and specify the current version of the custom attribute definition to enable
        /// [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency).
        /// On writes, this field must be set to the latest version. Stale writes are rejected.
        /// This field can also be used to enforce strong consistency for reads. For more information about strong consistency for reads,
        /// see [Custom Attributes Overview](https://developer.squareup.com/docs/devtools/customattributes/overview).
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The timestamp that indicates when the custom attribute definition was created or most recently updated,
        /// in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The timestamp that indicates when the custom attribute definition was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomAttributeDefinition : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeSchema()
        {
            return this.shouldSerialize["schema"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
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

            return obj is CustomAttributeDefinition other &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.Schema == null && other.Schema == null) || (this.Schema?.Equals(other.Schema) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Visibility == null && other.Visibility == null) || (this.Visibility?.Equals(other.Visibility) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1168711231;
            hashCode = HashCode.Combine(this.Key, this.Schema, this.Name, this.Description, this.Visibility, this.Version, this.UpdatedAt);

            hashCode = HashCode.Combine(hashCode, this.CreatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
            toStringOutput.Add($"Schema = {(this.Schema == null ? "null" : this.Schema.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.Visibility = {(this.Visibility == null ? "null" : this.Visibility.ToString())}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Key(this.Key)
                .Schema(this.Schema)
                .Name(this.Name)
                .Description(this.Description)
                .Visibility(this.Visibility)
                .Version(this.Version)
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
                { "schema", false },
                { "name", false },
                { "description", false },
            };

            private string key;
            private JsonObject schema;
            private string name;
            private string description;
            private string visibility;
            private int? version;
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
             /// Schema.
             /// </summary>
             /// <param name="schema"> schema. </param>
             /// <returns> Builder. </returns>
            public Builder Schema(JsonObject schema)
            {
                shouldSerialize["schema"] = true;
                this.schema = schema;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                shouldSerialize["description"] = true;
                this.description = description;
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
            public void UnsetSchema()
            {
                this.shouldSerialize["schema"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomAttributeDefinition. </returns>
            public CustomAttributeDefinition Build()
            {
                return new CustomAttributeDefinition(shouldSerialize,
                    this.key,
                    this.schema,
                    this.name,
                    this.description,
                    this.visibility,
                    this.version,
                    this.updatedAt,
                    this.createdAt);
            }
        }
    }
}