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
    public class LoyaltyEventRedeemReward 
    {
        public LoyaltyEventRedeemReward(string loyaltyProgramId,
            string rewardId = null,
            string orderId = null)
        {
            LoyaltyProgramId = loyaltyProgramId;
            RewardId = rewardId;
            OrderId = orderId;
        }

        /// <summary>
        /// The ID of the [loyalty program](#type-LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id")]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The ID of the redeemed [loyalty reward](#type-LoyaltyReward).
        /// This field is returned only if the event source is `LOYALTY_API`.
        /// </summary>
        [JsonProperty("reward_id")]
        public string RewardId { get; }

        /// <summary>
        /// The ID of the [order](#type-Order) that redeemed the reward.
        /// This field is returned only if the Orders API is used to process orders.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyProgramId)
                .RewardId(RewardId)
                .OrderId(OrderId);
            return builder;
        }

        public class Builder
        {
            private string loyaltyProgramId;
            private string rewardId;
            private string orderId;

            public Builder(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
            }
            public Builder LoyaltyProgramId(string value)
            {
                loyaltyProgramId = value;
                return this;
            }

            public Builder RewardId(string value)
            {
                rewardId = value;
                return this;
            }

            public Builder OrderId(string value)
            {
                orderId = value;
                return this;
            }

            public LoyaltyEventRedeemReward Build()
            {
                return new LoyaltyEventRedeemReward(loyaltyProgramId,
                    rewardId,
                    orderId);
            }
        }
    }
}