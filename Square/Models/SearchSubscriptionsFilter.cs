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
        [JsonProperty("customer_ids")]
        public IList<string> CustomerIds { get; }

        /// <summary>
        /// A filter to select subscriptions based the location.
        /// </summary>
        [JsonProperty("location_ids")]
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
            private IList<string> customerIds = new List<string>();
            private IList<string> locationIds = new List<string>();

            public Builder() { }
            public Builder CustomerIds(IList<string> value)
            {
                customerIds = value;
                return this;
            }

            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
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