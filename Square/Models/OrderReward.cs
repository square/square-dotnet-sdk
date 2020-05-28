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
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder RewardTierId(string value)
            {
                rewardTierId = value;
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