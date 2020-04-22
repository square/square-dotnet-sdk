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
    public class ListCustomerSegmentsRequest 
    {
        public ListCustomerSegmentsRequest(string cursor = null,
            long? limit = null)
        {
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// A pagination cursor returned by previous calls to __ListCustomerSegments__.
        /// Used to retrieve the next set of query results.
        /// See the [Pagination guide](https://developer.squareup.com/docs/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Sets the maximum number of results to be returned in a single page.
        /// Limit values outside the supported range are ignored.
        /// Minimum value: `1`
        /// Maximum value: `1,000`
        /// </summary>
        [JsonProperty("limit")]
        public long? Limit { get; }

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
            private long? limit;

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

            public ListCustomerSegmentsRequest Build()
            {
                return new ListCustomerSegmentsRequest(cursor,
                    limit);
            }
        }
    }
}