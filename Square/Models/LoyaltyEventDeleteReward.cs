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
    public class LoyaltyEventDeleteReward 
    {
        public LoyaltyEventDeleteReward(string loyaltyProgramId,
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
        /// The ID of the deleted [loyalty reward](#type-LoyaltyReward).
        /// This field is returned only if the event source is `LOYALTY_API`.
        /// </summary>
        [JsonProperty("reward_id")]
        public string RewardId { get; }

        /// <summary>
        /// The number of points returned to the loyalty account.
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

            public LoyaltyEventDeleteReward Build()
            {
                return new LoyaltyEventDeleteReward(loyaltyProgramId,
                    points,
                    rewardId);
            }
        }
    }
}