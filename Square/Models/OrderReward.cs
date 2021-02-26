
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
    public class OrderReward 
    {
        public OrderReward(string id,
            string rewardTierId)
        {
            Id = id;
            RewardTierId = rewardTierId;
        }

        /// <summary>
        /// The identifier of the reward.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The identifier of the reward tier corresponding to this reward.
        /// </summary>
        [JsonProperty("reward_tier_id")]
        public string RewardTierId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReward : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"RewardTierId = {(RewardTierId == null ? "null" : RewardTierId == string.Empty ? "" : RewardTierId)}");
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

            return obj is OrderReward other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((RewardTierId == null && other.RewardTierId == null) || (RewardTierId?.Equals(other.RewardTierId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 2052630566;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (RewardTierId != null)
            {
               hashCode += RewardTierId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                RewardTierId);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string rewardTierId;

            public Builder(string id,
                string rewardTierId)
            {
                this.id = id;
                this.rewardTierId = rewardTierId;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder RewardTierId(string rewardTierId)
            {
                this.rewardTierId = rewardTierId;
                return this;
            }

            public OrderReward Build()
            {
                return new OrderReward(id,
                    rewardTierId);
            }
        }
    }
}