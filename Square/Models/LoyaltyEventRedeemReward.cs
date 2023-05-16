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
    /// LoyaltyEventRedeemReward.
    /// </summary>
    public class LoyaltyEventRedeemReward
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventRedeemReward"/> class.
        /// </summary>
        /// <param name="loyaltyProgramId">loyalty_program_id.</param>
        /// <param name="rewardId">reward_id.</param>
        /// <param name="orderId">order_id.</param>
        public LoyaltyEventRedeemReward(
            string loyaltyProgramId,
            string rewardId = null,
            string orderId = null)
        {
            this.LoyaltyProgramId = loyaltyProgramId;
            this.RewardId = rewardId;
            this.OrderId = orderId;
        }

        /// <summary>
        /// The ID of the [loyalty program](entity:LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id")]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The ID of the redeemed [loyalty reward](entity:LoyaltyReward).
        /// This field is returned only if the event source is `LOYALTY_API`.
        /// </summary>
        [JsonProperty("reward_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RewardId { get; }

        /// <summary>
        /// The ID of the [order](entity:Order) that redeemed the reward.
        /// This field is returned only if the Orders API is used to process orders.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventRedeemReward : ({string.Join(", ", toStringOutput)})";
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
            return obj is LoyaltyEventRedeemReward other &&                ((this.LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (this.LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                ((this.RewardId == null && other.RewardId == null) || (this.RewardId?.Equals(other.RewardId) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2041086926;
            hashCode = HashCode.Combine(this.LoyaltyProgramId, this.RewardId, this.OrderId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyProgramId = {(this.LoyaltyProgramId == null ? "null" : this.LoyaltyProgramId == string.Empty ? "" : this.LoyaltyProgramId)}");
            toStringOutput.Add($"this.RewardId = {(this.RewardId == null ? "null" : this.RewardId == string.Empty ? "" : this.RewardId)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyProgramId)
                .RewardId(this.RewardId)
                .OrderId(this.OrderId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string loyaltyProgramId;
            private string rewardId;
            private string orderId;

            public Builder(
                string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
            }

             /// <summary>
             /// LoyaltyProgramId.
             /// </summary>
             /// <param name="loyaltyProgramId"> loyaltyProgramId. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

             /// <summary>
             /// RewardId.
             /// </summary>
             /// <param name="rewardId"> rewardId. </param>
             /// <returns> Builder. </returns>
            public Builder RewardId(string rewardId)
            {
                this.rewardId = rewardId;
                return this;
            }

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventRedeemReward. </returns>
            public LoyaltyEventRedeemReward Build()
            {
                return new LoyaltyEventRedeemReward(
                    this.loyaltyProgramId,
                    this.rewardId,
                    this.orderId);
            }
        }
    }
}