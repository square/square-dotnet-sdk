
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
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchLoyaltyRewardsRequestLoyaltyRewardQuery : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyAccountId = {(LoyaltyAccountId == null ? "null" : LoyaltyAccountId == string.Empty ? "" : LoyaltyAccountId)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
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

            return obj is SearchLoyaltyRewardsRequestLoyaltyRewardQuery other &&
                ((LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -265874214;

            if (LoyaltyAccountId != null)
            {
               hashCode += LoyaltyAccountId.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
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