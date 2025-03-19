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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// RetrieveCustomerCustomAttributeRequest.
    /// </summary>
    public class RetrieveCustomerCustomAttributeRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveCustomerCustomAttributeRequest"/> class.
        /// </summary>
        /// <param name="withDefinition">with_definition.</param>
        /// <param name="version">version.</param>
        public RetrieveCustomerCustomAttributeRequest(
            bool? withDefinition = null,
            int? version = null
        )
        {
            shouldSerialize = new Dictionary<string, bool> { { "with_definition", false } };

            if (withDefinition != null)
            {
                shouldSerialize["with_definition"] = true;
                this.WithDefinition = withDefinition;
            }
            this.Version = version;
        }

        internal RetrieveCustomerCustomAttributeRequest(
            Dictionary<string, bool> shouldSerialize,
            bool? withDefinition = null,
            int? version = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            WithDefinition = withDefinition;
            Version = version;
        }

        /// <summary>
        /// Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of
        /// the custom attribute. Set this parameter to `true` to get the name and description of the custom
        /// attribute, information about the data type, or other definition details. The default value is `false`.
        /// </summary>
        [JsonProperty("with_definition")]
        public bool? WithDefinition { get; }

        /// <summary>
        /// The current version of the custom attribute, which is used for strongly consistent reads to
        /// guarantee that you receive the most up-to-date data. When included in the request, Square
        /// returns the specified version or a higher version if one exists. If the specified version is
        /// higher than the current version, Square returns a `BAD_REQUEST` error.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveCustomerCustomAttributeRequest : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is RetrieveCustomerCustomAttributeRequest other
                && (
                    this.WithDefinition == null && other.WithDefinition == null
                    || this.WithDefinition?.Equals(other.WithDefinition) == true
                )
                && (
                    this.Version == null && other.Version == null
                    || this.Version?.Equals(other.Version) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2144154743;
            hashCode = HashCode.Combine(hashCode, this.WithDefinition, this.Version);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.WithDefinition = {(this.WithDefinition == null ? "null" : this.WithDefinition.ToString())}"
            );
            toStringOutput.Add(
                $"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().WithDefinition(this.WithDefinition).Version(this.Version);
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

            private bool? withDefinition;
            private int? version;

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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetWithDefinition()
            {
                this.shouldSerialize["with_definition"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveCustomerCustomAttributeRequest. </returns>
            public RetrieveCustomerCustomAttributeRequest Build()
            {
                return new RetrieveCustomerCustomAttributeRequest(
                    shouldSerialize,
                    this.withDefinition,
                    this.version
                );
            }
        }
    }
}
