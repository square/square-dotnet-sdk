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
        public SearchLoyaltyAccountsRequestLoyaltyAccountQuery(IList<Models.LoyaltyAccountMapping> mappings = null)
        {
            Mappings = mappings;
        }

        /// <summary>
        /// The set of mappings to use in the loyalty account search.
        /// </summary>
        [JsonProperty("mappings")]
        public IList<Models.LoyaltyAccountMapping> Mappings { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Mappings(Mappings);
            return builder;
        }

        public class Builder
        {
            private IList<Models.LoyaltyAccountMapping> mappings = new List<Models.LoyaltyAccountMapping>();

            public Builder() { }
            public Builder Mappings(IList<Models.LoyaltyAccountMapping> value)
            {
                mappings = value;
                return this;
            }

            public SearchLoyaltyAccountsRequestLoyaltyAccountQuery Build()
            {
                return new SearchLoyaltyAccountsRequestLoyaltyAccountQuery(mappings);
            }
        }
    }
}