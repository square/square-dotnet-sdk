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
    public class LoyaltyReward 
    {
        public LoyaltyReward(string loyaltyAccountId,
            string rewardTierId,
            string id = null,
            string status = null,
            int? points = null,
            string orderId = null,
            string createdAt = null,
            string updatedAt = null,
            string redeemedAt = null)
        {
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
        /// The Square-assigned ID of the [loyalty account](#type-LoyaltyAccount) to which the reward belongs.
        /// </summary>
        [JsonProperty("loyalty_account_id")]
        public string LoyaltyAccountId { get; }

        /// <summary>
        /// The Square-assigned ID of the [reward tier](#type-LoyaltyProgramRewardTier) used to create the reward.
        /// </summary>
        [JsonProperty("reward_tier_id")]
        public string RewardTierId { get; }

        /// <summary>
        /// The number of loyalty points used for the reward.
        /// </summary>
        [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
        public int? Points { get; }

        /// <summary>
        /// The Square-assigned ID of the [order](#type-Order) to which the reward is attached.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
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

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyAccountId,
                RewardTierId)
                .Id(Id)
                .Status(Status)
                .Points(Points)
                .OrderId(OrderId)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .RedeemedAt(RedeemedAt);
            return builder;
        }

        public class Builder
        {
            private string loyaltyAccountId;
            private string rewardTierId;
            private string id;
            private string status;
            private int? points;
            private string orderId;
            private string createdAt;
            private string updatedAt;
            private string redeemedAt;

            public Builder(string loyaltyAccountId,
                string rewardTierId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                this.rewardTierId = rewardTierId;
            }

            public Builder LoyaltyAccountId(string loyaltyAccountId)
            {
                this.loyaltyAccountId = loyaltyAccountId;
                return this;
            }

            public Builder RewardTierId(string rewardTierId)
            {
                this.rewardTierId = rewardTierId;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder Points(int? points)
            {
                this.points = points;
                return this;
            }

            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public Builder RedeemedAt(string redeemedAt)
            {
                this.redeemedAt = redeemedAt;
                return this;
            }

            public LoyaltyReward Build()
            {
                return new LoyaltyReward(loyaltyAccountId,
                    rewardTierId,
                    id,
                    status,
                    points,
                    orderId,
                    createdAt,
                    updatedAt,
                    redeemedAt);
            }
        }
    }
}