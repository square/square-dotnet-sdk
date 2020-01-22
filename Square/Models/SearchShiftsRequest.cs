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
    public class SearchShiftsRequest 
    {
        public SearchShiftsRequest(Models.ShiftQuery query = null,
            int? limit = null,
            string cursor = null)
        {
            Query = query;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// The parameters of a `Shift` search query. Includes filter and sort options.
        /// </summary>
        [JsonProperty("query")]
        public Models.ShiftQuery Query { get; }

        /// <summary>
        /// number of resources in a page (200 by default).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// opaque cursor for fetching the next page.
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
            private Models.ShiftQuery query;
            private int? limit;
            private string cursor;

            public Builder() { }
            public Builder Query(Models.ShiftQuery value)
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

            public SearchShiftsRequest Build()
            {
                return new SearchShiftsRequest(query,
                    limit,
                    cursor);
            }
        }
    }
}