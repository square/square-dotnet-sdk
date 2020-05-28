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
    public class SearchLoyaltyRewardsResponse 
    {
        public SearchLoyaltyRewardsResponse(IList<Models.Error> errors = null,
            IList<Models.LoyaltyReward> rewards = null,
            string cursor = null)
        {
            Errors = errors;
            Rewards = rewards;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The loyalty rewards that satisfy the search criteria.
        /// These are returned in descending order by `updated_at`.
        /// </summary>
        [JsonProperty("rewards")]
        public IList<Models.LoyaltyReward> Rewards { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent 
        /// request. If empty, this is the final response.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Rewards(Rewards)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.LoyaltyReward> rewards = new List<Models.LoyaltyReward>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Rewards(IList<Models.LoyaltyReward> value)
            {
                rewards = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public SearchLoyaltyRewardsResponse Build()
            {
                return new SearchLoyaltyRewardsResponse(errors,
                    rewards,
                    cursor);
            }
        }
    }
}