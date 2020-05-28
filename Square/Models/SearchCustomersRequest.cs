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
    public class SearchCustomersRequest 
    {
        public SearchCustomersRequest(string cursor = null,
            long? limit = null,
            Models.CustomerQuery query = null)
        {
            Cursor = cursor;
            Limit = limit;
            Query = query;
        }

        /// <summary>
        /// Include the pagination cursor in subsequent calls to this endpoint to retrieve
        /// the next set of results associated with the original query.
        /// See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// A limit on the number of results to be returned in a single page.
        /// The limit is advisory - the implementation may return more or fewer results.
        /// If the supplied limit is negative, zero, or is higher than the maximum limit
        /// of 100, it will be ignored.
        /// </summary>
        [JsonProperty("limit")]
        public long? Limit { get; }

        /// <summary>
        /// Represents a query (including filtering criteria, sorting criteria, or both) used to search
        /// for customer profiles.
        /// </summary>
        [JsonProperty("query")]
        public Models.CustomerQuery Query { get; }

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
            private long? limit;
            private Models.CustomerQuery query;

            public Builder() { }
            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Limit(long? value)
            {
                limit = value;
                return this;
            }

            public Builder Query(Models.CustomerQuery value)
            {
                query = value;
                return this;
            }

            public SearchCustomersRequest Build()
            {
                return new SearchCustomersRequest(cursor,
                    limit,
                    query);
            }
        }
    }
}