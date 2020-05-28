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
    public class CreateLoyaltyRewardRequest 
    {
        public CreateLoyaltyRewardRequest(Models.LoyaltyReward reward,
            string idempotencyKey)
        {
            Reward = reward;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Getter for reward
        /// </summary>
        [JsonProperty("reward")]
        public Models.LoyaltyReward Reward { get; }

        /// <summary>
        /// A unique string that identifies this `CreateLoyaltyReward` request. 
        /// Keys can be any valid string, but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Reward,
                IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.LoyaltyReward reward;
            private string idempotencyKey;

            public Builder(Models.LoyaltyReward reward,
                string idempotencyKey)
            {
                this.reward = reward;
                this.idempotencyKey = idempotencyKey;
            }
            public Builder Reward(Models.LoyaltyReward value)
            {
                reward = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public CreateLoyaltyRewardRequest Build()
            {
                return new CreateLoyaltyRewardRequest(reward,
                    idempotencyKey);
            }
        }
    }
}