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