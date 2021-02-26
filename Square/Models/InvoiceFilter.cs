
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
    public class InvoiceFilter 
    {
        public InvoiceFilter(IList<string> locationIds,
            IList<string> customerIds = null)
        {
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
        [JsonProperty("customer_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
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

            return obj is InvoiceFilter other &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true)) &&
                ((CustomerIds == null && other.CustomerIds == null) || (CustomerIds?.Equals(other.CustomerIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 829641128;

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            if (CustomerIds != null)
            {
               hashCode += CustomerIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationIds)
                .CustomerIds(CustomerIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds;
            private IList<string> customerIds;

            public Builder(IList<string> locationIds)
            {
                this.locationIds = locationIds;
            }

            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            public Builder CustomerIds(IList<string> customerIds)
            {
                this.customerIds = customerIds;
                return this;
            }

            public InvoiceFilter Build()
            {
                return new InvoiceFilter(locationIds,
                    customerIds);
            }
        }
    }
}