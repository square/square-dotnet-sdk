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
    public class SearchLoyaltyRewardsRequest 
    {
        public SearchLoyaltyRewardsRequest(Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery query = null,
            int? limit = null,
            string cursor = null)
        {
            Query = query;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// The set of search requirements.
        /// </summary>
        [JsonProperty("query")]
        public Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery Query { get; }

        /// <summary>
        /// The maximum number of results to return in the response.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to 
        /// this endpoint. Provide this to retrieve the next set of 
        /// results for the original query.
        /// For more information, 
        /// see [Pagination](https://developer.squareup.com/docs/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Query(Query)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery query;
            private int? limit;
            private string cursor;

            public Builder() { }
            public Builder Query(Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery value)
            {
                query = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public SearchLoyaltyRewardsRequest Build()
            {
                return new SearchLoyaltyRewardsRequest(query,
                    limit,
                    cursor);
            }
        }
    }
}