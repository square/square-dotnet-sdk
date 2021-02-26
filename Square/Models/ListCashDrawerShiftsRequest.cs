
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
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// The inclusive start time of the query on opened_at, in ISO 8601 format.
        /// </summary>
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// The exclusive end date of the query on opened_at, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; }

        /// <summary>
        /// Number of cash drawer shift events in a page of results (200 by
        /// default, 1000 max).
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Opaque cursor for fetching the next page of results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListCashDrawerShiftsRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"SortOrder = {(SortOrder == null ? "null" : SortOrder.ToString())}");
            toStringOutput.Add($"BeginTime = {(BeginTime == null ? "null" : BeginTime == string.Empty ? "" : BeginTime)}");
            toStringOutput.Add($"EndTime = {(EndTime == null ? "null" : EndTime == string.Empty ? "" : EndTime)}");
            toStringOutput.Add($"Limit = {(Limit == null ? "null" : Limit.ToString())}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is ListCashDrawerShiftsRequest other &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((SortOrder == null && other.SortOrder == null) || (SortOrder?.Equals(other.SortOrder) == true)) &&
                ((BeginTime == null && other.BeginTime == null) || (BeginTime?.Equals(other.BeginTime) == true)) &&
                ((EndTime == null && other.EndTime == null) || (EndTime?.Equals(other.EndTime) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1449210230;

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (SortOrder != null)
            {
               hashCode += SortOrder.GetHashCode();
            }

            if (BeginTime != null)
            {
               hashCode += BeginTime.GetHashCode();
            }

            if (EndTime != null)
            {
               hashCode += EndTime.GetHashCode();
            }

            if (Limit != null)
            {
               hashCode += Limit.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            public Builder BeginTime(string beginTime)
            {
                this.beginTime = beginTime;
                return this;
            }

            public Builder EndTime(string endTime)
            {
                this.endTime = endTime;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
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