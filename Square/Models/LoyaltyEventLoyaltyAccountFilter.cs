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
    public class LoyaltyEventLoyaltyAccountFilter 
    {
        public LoyaltyEventLoyaltyAccountFilter(string loyaltyAccountId)
        {
            LoyaltyAccountId = loyaltyAccountId;
        }

        /// <summary>
        /// The ID of the [loyalty account](#type-LoyaltyAccount) associated with loyalty events.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyAccountId);
            return builder;
        }

        public class Builder
        {
            private string loyaltyAccountId;

            public Builder(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
            }
            public Builder LoyaltyAccountId(string value)
            {
                loyaltyAccountId = value;
                return this;
            }

            public LoyaltyEventLoyaltyAccountFilter Build()
            {
                return new LoyaltyEventLoyaltyAccountFilter(loyaltyAccountId);
            }
        }
    }
}