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