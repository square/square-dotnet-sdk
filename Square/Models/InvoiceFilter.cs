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
        [JsonProperty("customer_ids")]
        public IList<string> CustomerIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationIds)
                .CustomerIds(CustomerIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds;
            private IList<string> customerIds = new List<string>();

            public Builder(IList<string> locationIds)
            {
                this.locationIds = locationIds;
            }
            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public Builder CustomerIds(IList<string> value)
            {
                customerIds = value;
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