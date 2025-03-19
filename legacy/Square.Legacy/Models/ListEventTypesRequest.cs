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
    /// ListEventTypesRequest.
    /// </summary>
    public class ListEventTypesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListEventTypesRequest"/> class.
        /// </summary>
        /// <param name="apiVersion">api_version.</param>
        public ListEventTypesRequest(string apiVersion = null)
        {
            shouldSerialize = new Dictionary<string, bool> { { "api_version", false } };

            if (apiVersion != null)
            {
                shouldSerialize["api_version"] = true;
                this.ApiVersion = apiVersion;
            }
        }

        internal ListEventTypesRequest(
            Dictionary<string, bool> shouldSerialize,
            string apiVersion = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            ApiVersion = apiVersion;
        }

        /// <summary>
        /// The API version for which to list event types. Setting this field overrides the default version used by the application.
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListEventTypesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApiVersion()
        {
            return this.shouldSerialize["api_version"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListEventTypesRequest other
                && (
                    this.ApiVersion == null && other.ApiVersion == null
                    || this.ApiVersion?.Equals(other.ApiVersion) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 2071481040;
            hashCode = HashCode.Combine(hashCode, this.ApiVersion);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ApiVersion = {this.ApiVersion ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().ApiVersion(this.ApiVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "api_version", false },
            };

            private string apiVersion;

            /// <summary>
            /// ApiVersion.
            /// </summary>
            /// <param name="apiVersion"> apiVersion. </param>
            /// <returns> Builder. </returns>
            public Builder ApiVersion(string apiVersion)
            {
                shouldSerialize["api_version"] = true;
                this.apiVersion = apiVersion;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetApiVersion()
            {
                this.shouldSerialize["api_version"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListEventTypesRequest. </returns>
            public ListEventTypesRequest Build()
            {
                return new ListEventTypesRequest(shouldSerialize, this.apiVersion);
            }
        }
    }
}
