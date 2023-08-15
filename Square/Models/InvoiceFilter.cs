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
    /// InvoiceFilter.
    /// </summary>
    public class InvoiceFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceFilter"/> class.
        /// </summary>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="customerIds">customer_ids.</param>
        public InvoiceFilter(
            IList<string> locationIds,
            IList<string> customerIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_ids", false }
            };

            this.LocationIds = locationIds;
            if (customerIds != null)
            {
                shouldSerialize["customer_ids"] = true;
                this.CustomerIds = customerIds;
            }

        }
        internal InvoiceFilter(Dictionary<string, bool> shouldSerialize,
            IList<string> locationIds,
            IList<string> customerIds = null)
        {
            this.shouldSerialize = shouldSerialize;
            LocationIds = locationIds;
            CustomerIds = customerIds;
        }

        /// <summary>
        /// Limits the search to the specified locations. A location is required.
        /// In the current implementation, only one location can be specified.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// Limits the search to the specified customers, within the specified locations.
        /// Specifying a customer is optional. In the current implementation,
        /// a maximum of one customer can be specified.
        /// </summary>
        [JsonProperty("customer_ids")]
        public IList<string> CustomerIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerIds()
        {
            return this.shouldSerialize["customer_ids"];
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
            return obj is InvoiceFilter other &&                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.CustomerIds == null && other.CustomerIds == null) || (this.CustomerIds?.Equals(other.CustomerIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 829641128;
            hashCode = HashCode.Combine(this.LocationIds, this.CustomerIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.CustomerIds = {(this.CustomerIds == null ? "null" : $"[{string.Join(", ", this.CustomerIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationIds)
                .CustomerIds(this.CustomerIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_ids", false },
            };

            private IList<string> locationIds;
            private IList<string> customerIds;

            public Builder(
                IList<string> locationIds)
            {
                this.locationIds = locationIds;
            }

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

             /// <summary>
             /// CustomerIds.
             /// </summary>
             /// <param name="customerIds"> customerIds. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerIds(IList<string> customerIds)
            {
                shouldSerialize["customer_ids"] = true;
                this.customerIds = customerIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomerIds()
            {
                this.shouldSerialize["customer_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceFilter. </returns>
            public InvoiceFilter Build()
            {
                return new InvoiceFilter(shouldSerialize,
                    this.locationIds,
                    this.customerIds);
            }
        }
    }
}