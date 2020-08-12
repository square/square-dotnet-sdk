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
    public class SearchSubscriptionsRequest 
    {
        public SearchSubscriptionsRequest(string cursor = null,
            int? limit = null,
            Models.SearchSubscriptionsQuery query = null)
        {
            Cursor = cursor;
            Limit = limit;
            Query = query;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The upper limit on the number of subscriptions to return 
        /// in the response. 
        /// Default: `200`
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Represents a query (including filtering criteria) used to search for subscriptions.
        /// </summary>
        [JsonProperty("query")]
        public Models.SearchSubscriptionsQuery Query { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .Limit(Limit)
                .Query(Query);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private int? limit;
            private Models.SearchSubscriptionsQuery query;

            public Builder() { }
            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public Builder Query(Models.SearchSubscriptionsQuery value)
            {
                query = value;
                return this;
            }

            public SearchSubscriptionsRequest Build()
            {
                return new SearchSubscriptionsRequest(cursor,
                    limit,
                    query);
            }
        }
    }
}