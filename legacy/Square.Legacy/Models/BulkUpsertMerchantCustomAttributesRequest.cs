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
    /// BulkUpsertMerchantCustomAttributesRequest.
    /// </summary>
    public class BulkUpsertMerchantCustomAttributesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertMerchantCustomAttributesRequest"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        public BulkUpsertMerchantCustomAttributesRequest(
            IDictionary<
                string,
                Models.BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
            > values
        )
        {
            this.Values = values;
        }

        /// <summary>
        /// A map containing 1 to 25 individual upsert requests. For each request, provide an
        /// arbitrary ID that is unique for this `BulkUpsertMerchantCustomAttributes` request and the
        /// information needed to create or update a custom attribute.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<
            string,
            Models.BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
        > Values { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkUpsertMerchantCustomAttributesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkUpsertMerchantCustomAttributesRequest other
                && (
                    this.Values == null && other.Values == null
                    || this.Values?.Equals(other.Values) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1308800051;
            hashCode = HashCode.Combine(hashCode, this.Values);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"Values = {(this.Values == null ? "null" : this.Values.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Values);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<
                string,
                Models.BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
            > values;

            /// <summary>
            /// Initialize Builder for BulkUpsertMerchantCustomAttributesRequest.
            /// </summary>
            /// <param name="values"> values. </param>
            public Builder(
                IDictionary<
                    string,
                    Models.BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
                > values
            )
            {
                this.values = values;
            }

            /// <summary>
            /// Values.
            /// </summary>
            /// <param name="values"> values. </param>
            /// <returns> Builder. </returns>
            public Builder Values(
                IDictionary<
                    string,
                    Models.BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
                > values
            )
            {
                this.values = values;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpsertMerchantCustomAttributesRequest. </returns>
            public BulkUpsertMerchantCustomAttributesRequest Build()
            {
                return new BulkUpsertMerchantCustomAttributesRequest(this.values);
            }
        }
    }
}
