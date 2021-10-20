namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// SearchLoyaltyRewardsRequestLoyaltyRewardQuery.
    /// </summary>
    public class SearchLoyaltyRewardsRequestLoyaltyRewardQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchLoyaltyRewardsRequestLoyaltyRewardQuery"/> class.
        /// </summary>
        /// <param name="loyaltyAccountId">loyalty_account_id.</param>
        /// <param name="status">status.</param>
        public SearchLoyaltyRewardsRequestLoyaltyRewardQuery(
            string loyaltyAccountId,
            string status = null)
        {
            this.LoyaltyAccountId = loyaltyAccountId;
            this.Status = status;
        }

        /// <summary>
        /// The ID of the [loyalty account]($m/LoyaltyAccount) to which the loyalty reward belongs.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        /// <summary>
        /// The status of the loyalty reward.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchLoyaltyRewardsRequestLoyaltyRewardQuery : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
                ((this.LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (this.LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -265874214;
            hashCode = HashCode.Combine(this.LoyaltyAccountId, this.Status);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyAccountId = {(this.LoyaltyAccountId == null ? "null" : this.LoyaltyAccountId == string.Empty ? "" : this.LoyaltyAccountId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyAccountId)
                .Status(this.Status);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string loyaltyAccountId;
            private string status;

            public Builder(
                string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
            }

             /// <summary>
             /// LoyaltyAccountId.
             /// </summary>
             /// <param name="loyaltyAccountId"> loyaltyAccountId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchLoyaltyRewardsRequestLoyaltyRewardQuery. </returns>
            public SearchLoyaltyRewardsRequestLoyaltyRewardQuery Build()
            {
                return new SearchLoyaltyRewardsRequestLoyaltyRewardQuery(
                    this.loyaltyAccountId,
                    this.status);
            }
        }
    }
}