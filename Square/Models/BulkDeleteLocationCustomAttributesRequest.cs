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
    /// BulkDeleteLocationCustomAttributesRequest.
    /// </summary>
    public class BulkDeleteLocationCustomAttributesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteLocationCustomAttributesRequest"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        public BulkDeleteLocationCustomAttributesRequest(
            IDictionary<string, Models.BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest> values)
        {
            this.Values = values;
        }

        /// <summary>
        /// The data used to update the `CustomAttribute` objects.
        /// The keys must be unique and are used to map to the corresponding response.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<string, Models.BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest> Values { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkDeleteLocationCustomAttributesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BulkDeleteLocationCustomAttributesRequest other &&
                (this.Values == null && other.Values == null ||
                 this.Values?.Equals(other.Values) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1322428158;
            hashCode = HashCode.Combine(hashCode, this.Values);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Values = {(this.Values == null ? "null" : this.Values.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Values);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest> values;

            /// <summary>
            /// Initialize Builder for BulkDeleteLocationCustomAttributesRequest.
            /// </summary>
            /// <param name="values"> values. </param>
            public Builder(
                IDictionary<string, Models.BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest> values)
            {
                this.values = values;
            }

             /// <summary>
             /// Values.
             /// </summary>
             /// <param name="values"> values. </param>
             /// <returns> Builder. </returns>
            public Builder Values(IDictionary<string, Models.BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest> values)
            {
                this.values = values;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkDeleteLocationCustomAttributesRequest. </returns>
            public BulkDeleteLocationCustomAttributesRequest Build()
            {
                return new BulkDeleteLocationCustomAttributesRequest(
                    this.values);
            }
        }
    }
}