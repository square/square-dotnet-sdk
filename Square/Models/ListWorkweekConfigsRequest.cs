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
    public class ListWorkweekConfigsRequest 
    {
        public ListWorkweekConfigsRequest(int? limit = null,
            string cursor = null)
        {
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Maximum number of Workweek Configs to return per page.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Pointer to the next page of Workweek Config results to fetch.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private int? limit;
            private string cursor;

            public Builder() { }
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

            public ListWorkweekConfigsRequest Build()
            {
                return new ListWorkweekConfigsRequest(limit,
                    cursor);
            }
        }
    }
}