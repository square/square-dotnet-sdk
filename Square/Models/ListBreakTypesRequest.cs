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
    public class ListBreakTypesRequest 
    {
        public ListBreakTypesRequest(string locationId = null,
            int? limit = null,
            string cursor = null)
        {
            LocationId = locationId;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Filter Break Types returned to only those that are associated with the
        /// specified location.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Maximum number of Break Types to return per page. Can range between 1
        /// and 200. The default is the maximum at 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Pointer to the next page of Break Type results to fetch.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(LocationId)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private int? limit;
            private string cursor;

            public Builder() { }
            public Builder LocationId(string value)
            {
                locationId = value;
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

            public ListBreakTypesRequest Build()
            {
                return new ListBreakTypesRequest(locationId,
                    limit,
                    cursor);
            }
        }
    }
}