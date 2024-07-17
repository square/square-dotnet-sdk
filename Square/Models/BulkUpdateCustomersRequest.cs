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
    /// BulkUpdateCustomersRequest.
    /// </summary>
    public class BulkUpdateCustomersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpdateCustomersRequest"/> class.
        /// </summary>
        /// <param name="customers">customers.</param>
        public BulkUpdateCustomersRequest(
            IDictionary<string, Models.BulkUpdateCustomerData> customers)
        {
            this.Customers = customers;
        }

        /// <summary>
        /// A map of 1 to 100 individual update requests, represented by `customer ID: { customer data }`
        /// key-value pairs.
        /// Each key is the ID of the [customer profile](entity:Customer) to update. To update a customer profile
        /// that was created by merging existing profiles, provide the ID of the newly created profile.
        /// Each value contains the updated customer data. Only new or changed fields are required. To add or
        /// update a field, specify the new value. To remove a field, specify `null`.
        /// </summary>
        [JsonProperty("customers")]
        public IDictionary<string, Models.BulkUpdateCustomerData> Customers { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpdateCustomersRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkUpdateCustomersRequest other &&                ((this.Customers == null && other.Customers == null) || (this.Customers?.Equals(other.Customers) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 101362901;
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
            private IDictionary<string, Models.BulkUpdateCustomerData> customers;

            /// <summary>
            /// Initialize Builder for BulkUpdateCustomersRequest.
            /// </summary>
            /// <param name="customers"> customers. </param>
            public Builder(
                IDictionary<string, Models.BulkUpdateCustomerData> customers)
            {
                this.customers = customers;
            }

             /// <summary>
             /// Customers.
             /// </summary>
             /// <param name="customers"> customers. </param>
             /// <returns> Builder. </returns>
            public Builder Customers(IDictionary<string, Models.BulkUpdateCustomerData> customers)
            {
                this.customers = customers;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpdateCustomersRequest. </returns>
            public BulkUpdateCustomersRequest Build()
            {
                return new BulkUpdateCustomersRequest(
                    this.customers);
            }
        }
    }
}