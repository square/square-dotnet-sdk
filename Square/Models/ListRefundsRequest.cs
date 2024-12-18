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
    /// ListRefundsRequest.
    /// </summary>
    public class ListRefundsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListRefundsRequest"/> class.
        /// </summary>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="endTime">end_time.</param>
        /// <param name="sortOrder">sort_order.</param>
        /// <param name="cursor">cursor.</param>
        public ListRefundsRequest(
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "begin_time", false },
                { "end_time", false },
                { "cursor", false }
            };

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
            this.SortOrder = sortOrder;

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }
        }

        internal ListRefundsRequest(
            Dictionary<string, bool> shouldSerialize,
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null)
        {
            this.shouldSerialize = shouldSerialize;
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
        }

        /// <summary>
        /// The beginning of the requested reporting period, in RFC 3339 format.
        /// See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.
        /// Default value: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// The end of the requested reporting period, in RFC 3339 format.
        /// See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.
        /// Default value: The current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListRefundsRequest : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ListRefundsRequest other &&
                (this.BeginTime == null && other.BeginTime == null ||
                 this.BeginTime?.Equals(other.BeginTime) == true) &&
                (this.EndTime == null && other.EndTime == null ||
                 this.EndTime?.Equals(other.EndTime) == true) &&
                (this.SortOrder == null && other.SortOrder == null ||
                 this.SortOrder?.Equals(other.SortOrder) == true) &&
                (this.Cursor == null && other.Cursor == null ||
                 this.Cursor?.Equals(other.Cursor) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1413410039;
            hashCode = HashCode.Combine(hashCode, this.BeginTime, this.EndTime, this.SortOrder, this.Cursor);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeginTime = {this.BeginTime ?? "null"}");
            toStringOutput.Add($"this.EndTime = {this.EndTime ?? "null"}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BeginTime(this.BeginTime)
                .EndTime(this.EndTime)
                .SortOrder(this.SortOrder)
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
                { "cursor", false },
            };

            private string beginTime;
            private string endTime;
            private string sortOrder;
            private string cursor;

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
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListRefundsRequest. </returns>
            public ListRefundsRequest Build()
            {
                return new ListRefundsRequest(
                    shouldSerialize,
                    this.beginTime,
                    this.endTime,
                    this.sortOrder,
                    this.cursor);
            }
        }
    }
}