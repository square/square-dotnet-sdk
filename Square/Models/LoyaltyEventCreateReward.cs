
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
        [JsonProperty("reward_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RewardId { get; }

        /// <summary>
        /// The loyalty points used to create the reward.
        /// </summary>
        [JsonProperty("points")]
        public int Points { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventCreateReward : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyProgramId = {(LoyaltyProgramId == null ? "null" : LoyaltyProgramId == string.Empty ? "" : LoyaltyProgramId)}");
            toStringOutput.Add($"RewardId = {(RewardId == null ? "null" : RewardId == string.Empty ? "" : RewardId)}");
            toStringOutput.Add($"Points = {Points}");
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

            return obj is LoyaltyEventCreateReward other &&
                ((LoyaltyProgramId == null && other.LoyaltyProgramId == null) || (LoyaltyProgramId?.Equals(other.LoyaltyProgramId) == true)) &&
                ((RewardId == null && other.RewardId == null) || (RewardId?.Equals(other.RewardId) == true)) &&
                Points.Equals(other.Points);
        }

        public override int GetHashCode()
        {
            int hashCode = 860504367;

            if (LoyaltyProgramId != null)
            {
               hashCode += LoyaltyProgramId.GetHashCode();
            }

            if (RewardId != null)
            {
               hashCode += RewardId.GetHashCode();
            }
            hashCode += Points.GetHashCode();

            return hashCode;
        }

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

            public Builder LoyaltyProgramId(string loyaltyProgramId)
            {
                this.loyaltyProgramId = loyaltyProgramId;
                return this;
            }

            public Builder Points(int points)
            {
                this.points = points;
                return this;
            }

            public Builder RewardId(string rewardId)
            {
                this.rewardId = rewardId;
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