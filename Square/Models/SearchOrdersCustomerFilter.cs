namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// SearchOrdersCustomerFilter.
    /// </summary>
    public class SearchOrdersCustomerFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersCustomerFilter"/> class.
        /// </summary>
        /// <param name="customerIds">customer_ids.</param>
        public SearchOrdersCustomerFilter(
            IList<string> customerIds = null)
        {
            this.CustomerIds = customerIds;
        }

        /// <summary>
        /// A list of customer IDs to filter by.
        /// Max: 10 customer IDs.
        /// </summary>
        [JsonProperty("customer_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersCustomerFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchOrdersCustomerFilter other &&
                ((this.CustomerIds == null && other.CustomerIds == null) || (this.CustomerIds?.Equals(other.CustomerIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 963322310;
            hashCode = HashCode.Combine(this.CustomerIds);

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
            var builder = new Builder()
                .CustomerIds(this.CustomerIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> customerIds;

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
            /// <returns> SearchOrdersCustomerFilter. </returns>
            public SearchOrdersCustomerFilter Build()
            {
                return new SearchOrdersCustomerFilter(
                    this.customerIds);
            }
        }
    }
}