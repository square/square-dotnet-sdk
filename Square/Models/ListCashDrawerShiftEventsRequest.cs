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
    public class ListCashDrawerShiftEventsRequest 
    {
        public ListCashDrawerShiftEventsRequest(string locationId,
            int? limit = null,
            string cursor = null)
        {
            LocationId = locationId;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// The ID of the location to list cash drawer shifts for.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Number of resources to be returned in a page of results (200 by
        /// default, 1000 max).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Opaque cursor for fetching the next page of results.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationId)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private int? limit;
            private string cursor;

            public Builder(string locationId)
            {
                this.locationId = locationId;
            }
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

            public ListCashDrawerShiftEventsRequest Build()
            {
                return new ListCashDrawerShiftEventsRequest(locationId,
                    limit,
                    cursor);
            }
        }
    }
}