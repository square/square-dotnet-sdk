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
    /// BulkCreateCustomersRequest.
    /// </summary>
    public class BulkCreateCustomersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkCreateCustomersRequest"/> class.
        /// </summary>
        /// <param name="customers">customers.</param>
        public BulkCreateCustomersRequest(
            IDictionary<string, Models.BulkCreateCustomerData> customers)
        {
            this.Customers = customers;
        }

        /// <summary>
        /// A map of 1 to 100 individual create requests, represented by `idempotency key: { customer data }`
        /// key-value pairs.
        /// Each key is an [idempotency key](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency)
        /// that uniquely identifies the create request. Each value contains the customer data used to create the
        /// customer profile.
        /// </summary>
        [JsonProperty("customers")]
        public IDictionary<string, Models.BulkCreateCustomerData> Customers { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkCreateCustomersRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkCreateCustomersRequest other &&                ((this.Customers == null && other.Customers == null) || (this.Customers?.Equals(other.Customers) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 573294327;
            hashCode = HashCode.Combine(this.Customers);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Customers = {(this.Customers == null ? "null" : this.Customers.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Customers);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.BulkCreateCustomerData> customers;

            /// <summary>
            /// Initialize Builder for BulkCreateCustomersRequest.
            /// </summary>
            /// <param name="customers"> customers. </param>
            public Builder(
                IDictionary<string, Models.BulkCreateCustomerData> customers)
            {
                this.customers = customers;
            }

             /// <summary>
             /// Customers.
             /// </summary>
             /// <param name="customers"> customers. </param>
             /// <returns> Builder. </returns>
            public Builder Customers(IDictionary<string, Models.BulkCreateCustomerData> customers)
            {
                this.customers = customers;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkCreateCustomersRequest. </returns>
            public BulkCreateCustomersRequest Build()
            {
                return new BulkCreateCustomersRequest(
                    this.customers);
            }
        }
    }
}