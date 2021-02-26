
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class SearchOrdersCustomerFilter 
    {
        public SearchOrdersCustomerFilter(IList<string> customerIds = null)
        {
            CustomerIds = customerIds;
        }

        /// <summary>
        /// List of customer IDs to filter by.
        /// Max: 10 customer IDs.
        /// </summary>
        [JsonProperty("customer_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersCustomerFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CustomerIds = {(CustomerIds == null ? "null" : $"[{ string.Join(", ", CustomerIds)} ]")}");
        }

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
                ((CustomerIds == null && other.CustomerIds == null) || (CustomerIds?.Equals(other.CustomerIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 963322310;

            if (CustomerIds != null)
            {
               hashCode += CustomerIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerIds(CustomerIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> customerIds;



            public Builder CustomerIds(IList<string> customerIds)
            {
                this.customerIds = customerIds;
                return this;
            }

            public SearchOrdersCustomerFilter Build()
            {
                return new SearchOrdersCustomerFilter(customerIds);
            }
        }
    }
}