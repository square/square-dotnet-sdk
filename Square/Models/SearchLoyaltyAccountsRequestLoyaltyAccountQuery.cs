
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchLoyaltyAccountsRequestLoyaltyAccountQuery : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Mappings = {(Mappings == null ? "null" : $"[{ string.Join(", ", Mappings)} ]")}");
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

            return obj is SearchLoyaltyAccountsRequestLoyaltyAccountQuery other &&
                ((Mappings == null && other.Mappings == null) || (Mappings?.Equals(other.Mappings) == true)) &&
                ((CustomerIds == null && other.CustomerIds == null) || (CustomerIds?.Equals(other.CustomerIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1219141926;

            if (Mappings != null)
            {
               hashCode += Mappings.GetHashCode();
            }

            if (CustomerIds != null)
            {
               hashCode += CustomerIds.GetHashCode();
            }

            return hashCode;
        }

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