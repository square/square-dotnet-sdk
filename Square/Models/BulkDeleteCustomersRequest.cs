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
    /// BulkDeleteCustomersRequest.
    /// </summary>
    public class BulkDeleteCustomersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteCustomersRequest"/> class.
        /// </summary>
        /// <param name="customerIds">customer_ids.</param>
        public BulkDeleteCustomersRequest(
            IList<string> customerIds)
        {
            this.CustomerIds = customerIds;
        }

        /// <summary>
        /// The IDs of the [customer profiles](entity:Customer) to delete.
        /// </summary>
        [JsonProperty("customer_ids")]
        public IList<string> CustomerIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkDeleteCustomersRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BulkDeleteCustomersRequest other &&
                (this.CustomerIds == null && other.CustomerIds == null ||
                 this.CustomerIds?.Equals(other.CustomerIds) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1157396994;
            hashCode = HashCode.Combine(hashCode, this.CustomerIds);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerIds = {(this.CustomerIds == null ? "null" : $"[{string.Join(", ", this.CustomerIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.CustomerIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> customerIds;

            /// <summary>
            /// Initialize Builder for BulkDeleteCustomersRequest.
            /// </summary>
            /// <param name="customerIds"> customerIds. </param>
            public Builder(
                IList<string> customerIds)
            {
                this.customerIds = customerIds;
            }

             /// <summary>
             /// CustomerIds.
             /// </summary>
             /// <param name="customerIds"> customerIds. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerIds(IList<string> customerIds)
            {
                this.customerIds = customerIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkDeleteCustomersRequest. </returns>
            public BulkDeleteCustomersRequest Build()
            {
                return new BulkDeleteCustomersRequest(
                    this.customerIds);
            }
        }
    }
}