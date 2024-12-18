using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// ListCashDrawerShiftsRequest.
    /// </summary>
    public class ListCashDrawerShiftsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCashDrawerShiftsRequest"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="sortOrder">sort_order.</param>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="endTime">end_time.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        public ListCashDrawerShiftsRequest(
            string locationId,
            string sortOrder = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string cursor = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "begin_time", false },
                { "end_time", false },
                { "limit", false },
                { "cursor", false }
            };
            this.LocationId = locationId;
            this.SortOrder = sortOrder;

            if (beginTime != null)
            {
                shouldSerialize["begin_time"] = true;
                this.BeginTime = beginTime;
            }

            if (endTime != null)
            {
                shouldSerialize["end_time"] = true;
                this.EndTime = endTime;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }
        }

        internal ListCashDrawerShiftsRequest(
            Dictionary<string, bool> shouldSerialize,
            string locationId,
            string sortOrder = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string cursor = null)
        {
            this.shouldSerialize = shouldSerialize;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListCashDrawerShiftsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBeginTime()
        {
            return this.shouldSerialize["begin_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndTime()
        {
            return this.shouldSerialize["end_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListCashDrawerShiftsRequest other &&
                (this.LocationId == null && other.LocationId == null ||
                 this.LocationId?.Equals(other.LocationId) == true) &&
                (this.SortOrder == null && other.SortOrder == null ||
                 this.SortOrder?.Equals(other.SortOrder) == true) &&
                (this.BeginTime == null && other.BeginTime == null ||
                 this.BeginTime?.Equals(other.BeginTime) == true) &&
                (this.EndTime == null && other.EndTime == null ||
                 this.EndTime?.Equals(other.EndTime) == true) &&
                (this.Limit == null && other.Limit == null ||
                 this.Limit?.Equals(other.Limit) == true) &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1449210230;
            hashCode = HashCode.Combine(hashCode, this.LocationId, this.SortOrder, this.BeginTime, this.EndTime, this.Limit, this.Cursor);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
            toStringOutput.Add($"this.BeginTime = {this.BeginTime ?? "null"}");
            toStringOutput.Add($"this.EndTime = {this.EndTime ?? "null"}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationId)
                .SortOrder(this.SortOrder)
                .BeginTime(this.BeginTime)
                .EndTime(this.EndTime)
                .Limit(this.Limit)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "begin_time", false },
                { "end_time", false },
                { "limit", false },
                { "cursor", false },
            };

            private string locationId;
            private string sortOrder;
            private string beginTime;
            private string endTime;
            private int? limit;
            private string cursor;

            /// <summary>
            /// Initialize Builder for ListCashDrawerShiftsRequest.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            public Builder(
                string locationId)
            {
                this.locationId = locationId;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// SortOrder.
             /// </summary>
             /// <param name="sortOrder"> sortOrder. </param>
             /// <returns> Builder. </returns>
            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

             /// <summary>
             /// BeginTime.
             /// </summary>
             /// <param name="beginTime"> beginTime. </param>
             /// <returns> Builder. </returns>
            public Builder BeginTime(string beginTime)
            {
                shouldSerialize["begin_time"] = true;
                this.beginTime = beginTime;
                return this;
            }

             /// <summary>
             /// EndTime.
             /// </summary>
             /// <param name="endTime"> endTime. </param>
             /// <returns> Builder. </returns>
            public Builder EndTime(string endTime)
            {
                shouldSerialize["end_time"] = true;
                this.endTime = endTime;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                shouldSerialize["limit"] = true;
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                shouldSerialize["cursor"] = true;
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetBeginTime()
            {
                this.shouldSerialize["begin_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEndTime()
            {
                this.shouldSerialize["end_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListCashDrawerShiftsRequest. </returns>
            public ListCashDrawerShiftsRequest Build()
            {
                return new ListCashDrawerShiftsRequest(
                    shouldSerialize,
                    this.locationId,
                    this.sortOrder,
                    this.beginTime,
                    this.endTime,
                    this.limit,
                    this.cursor);
            }
        }
    }
}