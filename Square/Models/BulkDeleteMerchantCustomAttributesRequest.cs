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
    /// BulkDeleteMerchantCustomAttributesRequest.
    /// </summary>
    public class BulkDeleteMerchantCustomAttributesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteMerchantCustomAttributesRequest"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        public BulkDeleteMerchantCustomAttributesRequest(
            IDictionary<string, Models.BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest> values)
        {
            this.Values = values;
        }

        /// <summary>
        /// The data used to update the `CustomAttribute` objects.
        /// The keys must be unique and are used to map to the corresponding response.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<string, Models.BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest> Values { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkDeleteMerchantCustomAttributesRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkDeleteMerchantCustomAttributesRequest other &&                ((this.Values == null && other.Values == null) || (this.Values?.Equals(other.Values) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -845675593;
            hashCode = HashCode.Combine(this.Values);

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
            private IDictionary<string, Models.BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest> values;

            public Builder(
                IDictionary<string, Models.BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest> values)
            {
                this.values = values;
            }

             /// <summary>
             /// Values.
             /// </summary>
             /// <param name="values"> values. </param>
             /// <returns> Builder. </returns>
            public Builder Values(IDictionary<string, Models.BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest> values)
            {
                this.values = values;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkDeleteMerchantCustomAttributesRequest. </returns>
            public BulkDeleteMerchantCustomAttributesRequest Build()
            {
                return new BulkDeleteMerchantCustomAttributesRequest(
                    this.values);
            }
        }
    }
}