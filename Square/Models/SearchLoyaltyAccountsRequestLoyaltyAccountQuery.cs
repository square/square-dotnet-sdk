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
    public class SearchLoyaltyAccountsRequestLoyaltyAccountQuery 
    {
        public SearchLoyaltyAccountsRequestLoyaltyAccountQuery(IList<Models.LoyaltyAccountMapping> mappings = null,
            IList<string> customerIds = null)
        {
            Mappings = mappings;
            CustomerIds = customerIds;
        }

        /// <summary>
        /// The set of mappings to use in the loyalty account search.  
        /// This cannot be combined with `customer_ids`.  
        /// Max: 30 mappings
        /// </summary>
        [JsonProperty("mappings", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LoyaltyAccountMapping> Mappings { get; }

        /// <summary>
        /// The set of customer IDs to use in the loyalty account search.  
        /// This cannot be combined with `mappings`.  
        /// Max: 30 customer IDs
        /// </summary>
        [JsonProperty("customer_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Mappings(Mappings)
                .CustomerIds(CustomerIds);
            return builder;
        }

        public class Builder
        {
            private IList<Models.LoyaltyAccountMapping> mappings;
            private IList<string> customerIds;



            public Builder Mappings(IList<Models.LoyaltyAccountMapping> mappings)
            {
                this.mappings = mappings;
                return this;
            }

            public Builder CustomerIds(IList<string> customerIds)
            {
                this.customerIds = customerIds;
                return this;
            }

            public SearchLoyaltyAccountsRequestLoyaltyAccountQuery Build()
            {
                return new SearchLoyaltyAccountsRequestLoyaltyAccountQuery(mappings,
                    customerIds);
            }
        }
    }
}