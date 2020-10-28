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
    public class SearchTerminalRefundsRequest 
    {
        public SearchTerminalRefundsRequest(Models.TerminalRefundQuery query = null,
            string cursor = null,
            int? limit = null)
        {
            Query = query;
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// Getter for query
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefundQuery Query { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Limit the number of results returned for a single request.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Query(Query)
                .Cursor(Cursor)
                .Limit(Limit);
            return builder;
        }

        public class Builder
        {
            private Models.TerminalRefundQuery query;
            private string cursor;
            private int? limit;



            public Builder Query(Models.TerminalRefundQuery query)
            {
                this.query = query;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public SearchTerminalRefundsRequest Build()
            {
                return new SearchTerminalRefundsRequest(query,
                    cursor,
                    limit);
            }
        }
    }
}