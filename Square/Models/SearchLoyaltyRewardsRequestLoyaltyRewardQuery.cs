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
    public class SearchLoyaltyRewardsRequestLoyaltyRewardQuery 
    {
        public SearchLoyaltyRewardsRequestLoyaltyRewardQuery(string loyaltyAccountId,
            string status = null)
        {
            LoyaltyAccountId = loyaltyAccountId;
            Status = status;
        }

        /// <summary>
        /// The ID of the [loyalty account](#type-LoyaltyAccount) to which the loyalty reward belongs.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        /// <summary>
        /// The status of the loyalty reward.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyAccountId)
                .Status(Status);
            return builder;
        }

        public class Builder
        {
            private string loyaltyAccountId;
            private string status;

            public Builder(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
            }
            public Builder LoyaltyAccountId(string value)
            {
                loyaltyAccountId = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public SearchLoyaltyRewardsRequestLoyaltyRewardQuery Build()
            {
                return new SearchLoyaltyRewardsRequestLoyaltyRewardQuery(loyaltyAccountId,
                    status);
            }
        }
    }
}