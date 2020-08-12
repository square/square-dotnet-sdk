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
    public class ListSubscriptionEventsRequest 
    {
        public ListSubscriptionEventsRequest(string cursor = null,
            int? limit = null)
        {
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The upper limit on the number of subscription events to return 
        /// in the response. 
        /// Default: `200`
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(Cursor)
                .Limit(Limit);
            return builder;
        }

        public class Builder
        {
            private string cursor;
            private int? limit;

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

            public ListSubscriptionEventsRequest Build()
            {
                return new ListSubscriptionEventsRequest(cursor,
                    limit);
            }
        }
    }
}