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
    public class ListCashDrawerShiftsRequest 
    {
        public ListCashDrawerShiftsRequest(string locationId,
            string sortOrder = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string cursor = null)
        {
            LocationId = locationId;
            SortOrder = sortOrder;
            BeginTime = beginTime;
            EndTime = endTime;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// The ID of the location to query for a list of cash drawer shifts.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        /// <summary>
        /// The inclusive start time of the query on opened_at, in ISO 8601 format.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// The exclusive end date of the query on opened_at, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// Number of cash drawer shift events in a page of results (200 by
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
                .SortOrder(SortOrder)
                .BeginTime(BeginTime)
                .EndTime(EndTime)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private string sortOrder;
            private string beginTime;
            private string endTime;
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

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public Builder BeginTime(string value)
            {
                beginTime = value;
                return this;
            }

            public Builder EndTime(string value)
            {
                endTime = value;
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

            public ListCashDrawerShiftsRequest Build()
            {
                return new ListCashDrawerShiftsRequest(locationId,
                    sortOrder,
                    beginTime,
                    endTime,
                    limit,
                    cursor);
            }
        }
    }
}