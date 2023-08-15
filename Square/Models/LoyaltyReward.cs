namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// LoyaltyReward.
    /// </summary>
    public class LoyaltyReward
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyReward"/> class.
        /// </summary>
        /// <param name="loyaltyAccountId">loyalty_account_id.</param>
        /// <param name="rewardTierId">reward_tier_id.</param>
        /// <param name="id">id.</param>
        /// <param name="status">status.</param>
        /// <param name="points">points.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="redeemedAt">redeemed_at.</param>
        public LoyaltyReward(
            string loyaltyAccountId,
            string rewardTierId,
            string id = null,
            string status = null,
            int? points = null,
            string orderId = null,
            string createdAt = null,
            string updatedAt = null,
            string redeemedAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "order_id", false }
            };

            this.Id = id;
            this.Status = status;
            this.LoyaltyAccountId = loyaltyAccountId;
            this.RewardTierId = rewardTierId;
            this.Points = points;
            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.RedeemedAt = redeemedAt;
        }
        internal LoyaltyReward(Dictionary<string, bool> shouldSerialize,
            string loyaltyAccountId,
            string rewardTierId,
            string id = null,
            string status = null,
            int? points = null,
            string orderId = null,
            string createdAt = null,
            string updatedAt = null,
            string redeemedAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Status = status;
            LoyaltyAccountId = loyaltyAccountId;
            RewardTierId = rewardTierId;
            Points = points;
            OrderId = orderId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            RedeemedAt = redeemedAt;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty reward.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The status of the loyalty reward.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The Square-assigned ID of the [loyalty account](entity:LoyaltyAccount) to which the reward belongs.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        /// <summary>
        /// The Square-assigned ID of the [reward tier](entity:LoyaltyProgramRewardTier) used to create the reward.
        /// </summary>
        [JsonProperty("reward_tier_id")]
        public string RewardTierId { get; }

        /// <summary>
        /// The number of loyalty points used for the reward.
        /// </summary>
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; }

        /// <summary>
        /// The Square-assigned ID of the [order](entity:Order) to which the reward is attached.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// The timestamp when the reward was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was redeemed, in RFC 3339 format.
        /// </summary>
        [JsonProperty("redeemed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string RedeemedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyReward : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
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
            return obj is LoyaltyReward other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.LoyaltyAccountId == null && other.LoyaltyAccountId == null) || (this.LoyaltyAccountId?.Equals(other.LoyaltyAccountId) == true)) &&
                ((this.RewardTierId == null && other.RewardTierId == null) || (this.RewardTierId?.Equals(other.RewardTierId) == true)) &&
                ((this.Points == null && other.Points == null) || (this.Points?.Equals(other.Points) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.RedeemedAt == null && other.RedeemedAt == null) || (this.RedeemedAt?.Equals(other.RedeemedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1604808841;
            hashCode = HashCode.Combine(this.Id, this.Status, this.LoyaltyAccountId, this.RewardTierId, this.Points, this.OrderId, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.UpdatedAt, this.RedeemedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.LoyaltyAccountId = {(this.LoyaltyAccountId == null ? "null" : this.LoyaltyAccountId)}");
            toStringOutput.Add($"this.RewardTierId = {(this.RewardTierId == null ? "null" : this.RewardTierId)}");
            toStringOutput.Add($"this.Points = {(this.Points == null ? "null" : this.Points.ToString())}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.RedeemedAt = {(this.RedeemedAt == null ? "null" : this.RedeemedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyAccountId,
                this.RewardTierId)
                .Id(this.Id)
                .Status(this.Status)
                .Points(this.Points)
                .OrderId(this.OrderId)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .RedeemedAt(this.RedeemedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "order_id", false },
            };

            private string loyaltyAccountId;
            private string rewardTierId;
            private string id;
            private string status;
            private int? points;
            private string orderId;
            private string createdAt;
            private string updatedAt;
            private string redeemedAt;

            public Builder(
                string loyaltyAccountId,
                string rewardTierId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                this.rewardTierId = rewardTierId;
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
             /// RewardTierId.
             /// </summary>
             /// <param name="rewardTierId"> rewardTierId. </param>
             /// <returns> Builder. </returns>
            public Builder RewardTierId(string rewardTierId)
            {
                this.rewardTierId = rewardTierId;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
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
             /// Points.
             /// </summary>
             /// <param name="points"> points. </param>
             /// <returns> Builder. </returns>
            public Builder Points(int? points)
            {
                this.points = points;
                return this;
            }

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                shouldSerialize["order_id"] = true;
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// RedeemedAt.
             /// </summary>
             /// <param name="redeemedAt"> redeemedAt. </param>
             /// <returns> Builder. </returns>
            public Builder RedeemedAt(string redeemedAt)
            {
                this.redeemedAt = redeemedAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyReward. </returns>
            public LoyaltyReward Build()
            {
                return new LoyaltyReward(shouldSerialize,
                    this.loyaltyAccountId,
                    this.rewardTierId,
                    this.id,
                    this.status,
                    this.points,
                    this.orderId,
                    this.createdAt,
                    this.updatedAt,
                    this.redeemedAt);
            }
        }
    }
}