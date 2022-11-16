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
    /// RetrieveOrderCustomAttributeRequest.
    /// </summary>
    public class RetrieveOrderCustomAttributeRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveOrderCustomAttributeRequest"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        /// <param name="withDefinition">with_definition.</param>
        public RetrieveOrderCustomAttributeRequest(
            int? version = null,
            bool? withDefinition = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "with_definition", false }
            };

            this.Version = version;
            if (withDefinition != null)
            {
                shouldSerialize["with_definition"] = true;
                this.WithDefinition = withDefinition;
            }

        }
        internal RetrieveOrderCustomAttributeRequest(Dictionary<string, bool> shouldSerialize,
            int? version = null,
            bool? withDefinition = null)
        {
            this.shouldSerialize = shouldSerialize;
            Version = version;
            WithDefinition = withDefinition;
        }

        /// <summary>
        /// To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
        /// control, include this optional field and specify the current version of the custom attribute.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// Indicates whether to return the [custom attribute definition]($m/CustomAttributeDefinition) in the `definition` field of each
        /// custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,
        /// information about the data type, or other definition details. The default value is `false`.
        /// </summary>
        [JsonProperty("with_definition")]
        public bool? WithDefinition { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveOrderCustomAttributeRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeWithDefinition()
        {
            return this.shouldSerialize["with_definition"];
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

            return obj is RetrieveOrderCustomAttributeRequest other &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.WithDefinition == null && other.WithDefinition == null) || (this.WithDefinition?.Equals(other.WithDefinition) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -291006171;
            hashCode = HashCode.Combine(this.Version, this.WithDefinition);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.WithDefinition = {(this.WithDefinition == null ? "null" : this.WithDefinition.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Version(this.Version)
                .WithDefinition(this.WithDefinition);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "with_definition", false },
            };

            private int? version;
            private bool? withDefinition;

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
             /// WithDefinition.
             /// </summary>
             /// <param name="withDefinition"> withDefinition. </param>
             /// <returns> Builder. </returns>
            public Builder WithDefinition(bool? withDefinition)
            {
                shouldSerialize["with_definition"] = true;
                this.withDefinition = withDefinition;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetWithDefinition()
            {
                this.shouldSerialize["with_definition"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveOrderCustomAttributeRequest. </returns>
            public RetrieveOrderCustomAttributeRequest Build()
            {
                return new RetrieveOrderCustomAttributeRequest(shouldSerialize,
                    this.version,
                    this.withDefinition);
            }
        }
    }
}