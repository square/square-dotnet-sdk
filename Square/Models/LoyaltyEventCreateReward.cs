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
    public class LoyaltyEventCreateReward 
    {
        public LoyaltyEventCreateReward(string loyaltyProgramId,
            int points,
            string rewardId = null)
        {
            LoyaltyProgramId = loyaltyProgramId;
            RewardId = rewardId;
            Points = points;
        }

        /// <summary>
        /// The ID of the [loyalty program](#type-LoyaltyProgram).
        /// </summary>
        [JsonProperty("loyalty_program_id")]
        public string LoyaltyProgramId { get; }

        /// <summary>
        /// The Square-assigned ID of the created [loyalty reward](#type-LoyaltyReward).
        /// This field is returned only if the event source is `LOYALTY_API`.
        /// </summary>
        [JsonProperty("reward_id")]
        public string RewardId { get; }

        /// <summary>
        /// The loyalty points used to create the reward.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyProgramId,
                Points)
                .RewardId(RewardId);
            return builder;
        }

        public class Builder
        {
            private string loyaltyProgramId;
            private int points;
            private string rewardId;

            public Builder(string loyaltyProgramId,
                int points)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                this.points = points;
            }
            public Builder LoyaltyProgramId(string value)
            {
                loyaltyProgramId = value;
                return this;
            }

            public Builder Points(int value)
            {
                points = value;
                return this;
            }

            public Builder RewardId(string value)
            {
                rewardId = value;
                return this;
            }

            public LoyaltyEventCreateReward Build()
            {
                return new LoyaltyEventCreateReward(loyaltyProgramId,
                    points,
                    rewardId);
            }
        }
    }
}