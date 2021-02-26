
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
    public class SearchSubscriptionsFilter 
    {
        public SearchSubscriptionsFilter(IList<string> customerIds = null,
            IList<string> locationIds = null)
        {
            CustomerIds = customerIds;
            LocationIds = locationIds;
        }

        /// <summary>
        /// A filter to select subscriptions based on the customer.
        /// </summary>
        [JsonProperty("customer_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerIds { get; }

        /// <summary>
        /// A filter to select subscriptions based the location.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchSubscriptionsFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CustomerIds = {(CustomerIds == null ? "null" : $"[{ string.Join(", ", CustomerIds)} ]")}");
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
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

            return obj is SearchSubscriptionsFilter other &&
                ((CustomerIds == null && other.CustomerIds == null) || (CustomerIds?.Equals(other.CustomerIds) == true)) &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1711926547;

            if (CustomerIds != null)
            {
               hashCode += CustomerIds.GetHashCode();
            }

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerIds(CustomerIds)
                .LocationIds(LocationIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> customerIds;
            private IList<string> locationIds;



            public Builder CustomerIds(IList<string> customerIds)
            {
                this.customerIds = customerIds;
                return this;
            }

            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            public SearchSubscriptionsFilter Build()
            {
                return new SearchSubscriptionsFilter(customerIds,
                    locationIds);
            }
        }
    }
}