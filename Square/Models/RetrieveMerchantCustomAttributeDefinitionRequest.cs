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

namespace Square.Models
{
    /// <summary>
    /// RetrieveMerchantCustomAttributeDefinitionRequest.
    /// </summary>
    public class RetrieveMerchantCustomAttributeDefinitionRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveMerchantCustomAttributeDefinitionRequest"/> class.
        /// </summary>
        /// <param name="version">version.</param>
        public RetrieveMerchantCustomAttributeDefinitionRequest(
            int? version = null)
        {
            this.Version = version;
        }

        /// <summary>
        /// The current version of the custom attribute definition, which is used for strongly consistent
        /// reads to guarantee that you receive the most up-to-date data. When included in the request,
        /// Square returns the specified version or a higher version if one exists. If the specified version
        /// is higher than the current version, Square returns a `BAD_REQUEST` error.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveMerchantCustomAttributeDefinitionRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveMerchantCustomAttributeDefinitionRequest other &&                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1424718093;
            hashCode = HashCode.Combine(this.Version);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Version(this.Version);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int? version;

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
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveMerchantCustomAttributeDefinitionRequest. </returns>
            public RetrieveMerchantCustomAttributeDefinitionRequest Build()
            {
                return new RetrieveMerchantCustomAttributeDefinitionRequest(
                    this.version);
            }
        }
    }
}