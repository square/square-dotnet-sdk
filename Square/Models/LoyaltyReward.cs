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
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The status of the loyalty reward.
        /// </summary>
        [JsonProperty("status")]
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
        [JsonProperty("points")]
        public int? Points { get; }

        /// <summary>
        /// The Square-assigned ID of the [order](#type-Order) to which the reward is attached.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// The timestamp when the reward was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        /// <summary>
        /// The timestamp when the reward was redeemed, in RFC 3339 format.
        /// </summary>
        [JsonProperty("redeemed_at")]
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
            public Builder LoyaltyAccountId(string value)
            {
                loyaltyAccountId = value;
                return this;
            }

            public Builder RewardTierId(string value)
            {
                rewardTierId = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder Points(int? value)
            {
                points = value;
                return this;
            }

            public Builder OrderId(string value)
            {
                orderId = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
                return this;
            }

            public Builder RedeemedAt(string value)
            {
                redeemedAt = value;
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