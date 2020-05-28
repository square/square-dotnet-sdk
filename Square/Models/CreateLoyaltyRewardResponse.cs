using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateLoyaltyRewardResponse 
    {
        public CreateLoyaltyRewardResponse(IList<Models.Error> errors = null,
            Models.LoyaltyReward reward = null)
        {
            Errors = errors;
            Reward = reward;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for reward
        /// </summary>
        [JsonProperty("reward")]
        public Models.LoyaltyReward Reward { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Reward(Reward);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.LoyaltyReward reward;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Reward(Models.LoyaltyReward value)
            {
                reward = value;
                return this;
            }

            public CreateLoyaltyRewardResponse Build()
            {
                return new CreateLoyaltyRewardResponse(errors,
                    reward);
            }
        }
    }
}