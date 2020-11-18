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
    public class SearchLoyaltyAccountsRequest 
    {
        public SearchLoyaltyAccountsRequest(Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery query = null,
            int? limit = null,
            string cursor = null)
        {
            Query = query;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// The search criteria for the loyalty accounts.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery Query { get; }

        /// <summary>
        /// The maximum number of results to include in the response.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to 
        /// this endpoint. Provide this to retrieve the next set of 
        /// results for the original query.
        /// For more information, 
        /// see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
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
            private Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery query;
            private int? limit;
            private string cursor;



            public Builder Query(Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery query)
            {
                this.query = query;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public SearchLoyaltyAccountsRequest Build()
            {
                return new SearchLoyaltyAccountsRequest(query,
                    limit,
                    cursor);
            }
        }
    }
}