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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// ListPaymentRefundsRequest.
    /// </summary>
    public class ListPaymentRefundsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListPaymentRefundsRequest"/> class.
        /// </summary>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="endTime">end_time.</param>
        /// <param name="sortOrder">sort_order.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="status">status.</param>
        /// <param name="sourceType">source_type.</param>
        /// <param name="limit">limit.</param>
        /// <param name="updatedAtBeginTime">updated_at_begin_time.</param>
        /// <param name="updatedAtEndTime">updated_at_end_time.</param>
        /// <param name="sortField">sort_field.</param>
        public ListPaymentRefundsRequest(
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            string locationId = null,
            string status = null,
            string sourceType = null,
            int? limit = null,
            string updatedAtBeginTime = null,
            string updatedAtEndTime = null,
            string sortField = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "begin_time", false },
                { "end_time", false },
                { "sort_order", false },
                { "cursor", false },
                { "location_id", false },
                { "status", false },
                { "source_type", false },
                { "limit", false },
                { "updated_at_begin_time", false },
                { "updated_at_end_time", false },
                { "sort_field", false },
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

            if (sortOrder != null)
            {
                shouldSerialize["sort_order"] = true;
                this.SortOrder = sortOrder;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (status != null)
            {
                shouldSerialize["status"] = true;
                this.Status = status;
            }

            if (sourceType != null)
            {
                shouldSerialize["source_type"] = true;
                this.SourceType = sourceType;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (updatedAtBeginTime != null)
            {
                shouldSerialize["updated_at_begin_time"] = true;
                this.UpdatedAtBeginTime = updatedAtBeginTime;
            }

            if (updatedAtEndTime != null)
            {
                shouldSerialize["updated_at_end_time"] = true;
                this.UpdatedAtEndTime = updatedAtEndTime;
            }

            if (sortField != null)
            {
                shouldSerialize["sort_field"] = true;
                this.SortField = sortField;
            }
        }

        internal ListPaymentRefundsRequest(
            Dictionary<string, bool> shouldSerialize,
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            string locationId = null,
            string status = null,
            string sourceType = null,
            int? limit = null,
            string updatedAtBeginTime = null,
            string updatedAtEndTime = null,
            string sortField = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
            LocationId = locationId;
            Status = status;
            SourceType = sourceType;
            Limit = limit;
            UpdatedAtBeginTime = updatedAtBeginTime;
            UpdatedAtEndTime = updatedAtEndTime;
            SortField = sortField;
        }

        /// <summary>
        /// Indicates the start of the time range to retrieve each `PaymentRefund` for, in RFC 3339
        /// format.  The range is determined using the `created_at` field for each `PaymentRefund`.
        /// Default: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// Indicates the end of the time range to retrieve each `PaymentRefund` for, in RFC 3339
        /// format.  The range is determined using the `created_at` field for each `PaymentRefund`.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// The order in which results are listed by `PaymentRefund.created_at`:
        /// - `ASC` - Oldest to newest.
        /// - `DESC` - Newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for the original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Limit results to the location supplied. By default, results are returned
        /// for all locations associated with the seller.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// If provided, only refunds with the given status are returned.
        /// For a list of refund status values, see [PaymentRefund](entity:PaymentRefund).
        /// Default: If omitted, refunds are returned regardless of their status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// If provided, only returns refunds whose payments have the indicated source type.
        /// Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `CASH`, and `EXTERNAL`.
        /// For information about these payment source types, see
        /// [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
        /// Default: If omitted, refunds are returned regardless of the source type.
        /// </summary>
        [JsonProperty("source_type")]
        public string SourceType { get; }

        /// <summary>
        /// The maximum number of results to be returned in a single page.
        /// It is possible to receive fewer results than the specified limit on a given page.
        /// If the supplied value is greater than 100, no more than 100 results are returned.
        /// Default: 100
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Indicates the start of the time range to retrieve each `PaymentRefund` for, in RFC 3339
        /// format.  The range is determined using the `updated_at` field for each `PaymentRefund`.
        /// Default: if omitted, the time range starts at `beginTime`.
        /// </summary>
        [JsonProperty("updated_at_begin_time")]
        public string UpdatedAtBeginTime { get; }

        /// <summary>
        /// Indicates the end of the time range to retrieve each `PaymentRefund` for, in RFC 3339
        /// format.  The range is determined using the `updated_at` field for each `PaymentRefund`.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("updated_at_end_time")]
        public string UpdatedAtEndTime { get; }

        /// <summary>
        /// The field used to sort results by. The default is `CREATED_AT`.
        /// Current values include `CREATED_AT` and `UPDATED_AT`.
        /// </summary>
        [JsonProperty("sort_field")]
        public string SortField { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListPaymentRefundsRequest : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeSortOrder()
        {
            return this.shouldSerialize["sort_order"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatus()
        {
            return this.shouldSerialize["status"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceType()
        {
            return this.shouldSerialize["source_type"];
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
        public bool ShouldSerializeUpdatedAtBeginTime()
        {
            return this.shouldSerialize["updated_at_begin_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUpdatedAtEndTime()
        {
            return this.shouldSerialize["updated_at_end_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSortField()
        {
            return this.shouldSerialize["sort_field"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListPaymentRefundsRequest other
                && (
                    this.BeginTime == null && other.BeginTime == null
                    || this.BeginTime?.Equals(other.BeginTime) == true
                )
                && (
                    this.EndTime == null && other.EndTime == null
                    || this.EndTime?.Equals(other.EndTime) == true
                )
                && (
                    this.SortOrder == null && other.SortOrder == null
                    || this.SortOrder?.Equals(other.SortOrder) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                )
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.Status == null && other.Status == null
                    || this.Status?.Equals(other.Status) == true
                )
                && (
                    this.SourceType == null && other.SourceType == null
                    || this.SourceType?.Equals(other.SourceType) == true
                )
                && (
                    this.Limit == null && other.Limit == null
                    || this.Limit?.Equals(other.Limit) == true
                )
                && (
                    this.UpdatedAtBeginTime == null && other.UpdatedAtBeginTime == null
                    || this.UpdatedAtBeginTime?.Equals(other.UpdatedAtBeginTime) == true
                )
                && (
                    this.UpdatedAtEndTime == null && other.UpdatedAtEndTime == null
                    || this.UpdatedAtEndTime?.Equals(other.UpdatedAtEndTime) == true
                )
                && (
                    this.SortField == null && other.SortField == null
                    || this.SortField?.Equals(other.SortField) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -211695136;
            hashCode = HashCode.Combine(
                hashCode,
                this.BeginTime,
                this.EndTime,
                this.SortOrder,
                this.Cursor,
                this.LocationId,
                this.Status,
                this.SourceType
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.Limit,
                this.UpdatedAtBeginTime,
                this.UpdatedAtEndTime,
                this.SortField
            );

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
            toStringOutput.Add($"this.SortOrder = {this.SortOrder ?? "null"}");
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.Status = {this.Status ?? "null"}");
            toStringOutput.Add($"this.SourceType = {this.SourceType ?? "null"}");
            toStringOutput.Add(
                $"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}"
            );
            toStringOutput.Add($"this.UpdatedAtBeginTime = {this.UpdatedAtBeginTime ?? "null"}");
            toStringOutput.Add($"this.UpdatedAtEndTime = {this.UpdatedAtEndTime ?? "null"}");
            toStringOutput.Add($"this.SortField = {this.SortField ?? "null"}");
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
                .Cursor(this.Cursor)
                .LocationId(this.LocationId)
                .Status(this.Status)
                .SourceType(this.SourceType)
                .Limit(this.Limit)
                .UpdatedAtBeginTime(this.UpdatedAtBeginTime)
                .UpdatedAtEndTime(this.UpdatedAtEndTime)
                .SortField(this.SortField);
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
                { "sort_order", false },
                { "cursor", false },
                { "location_id", false },
                { "status", false },
                { "source_type", false },
                { "limit", false },
                { "updated_at_begin_time", false },
                { "updated_at_end_time", false },
                { "sort_field", false },
            };

            private string beginTime;
            private string endTime;
            private string sortOrder;
            private string cursor;
            private string locationId;
            private string status;
            private string sourceType;
            private int? limit;
            private string updatedAtBeginTime;
            private string updatedAtEndTime;
            private string sortField;

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
                shouldSerialize["sort_order"] = true;
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
            /// LocationId.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Status.
            /// </summary>
            /// <param name="status"> status. </param>
            /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                shouldSerialize["status"] = true;
                this.status = status;
                return this;
            }

            /// <summary>
            /// SourceType.
            /// </summary>
            /// <param name="sourceType"> sourceType. </param>
            /// <returns> Builder. </returns>
            public Builder SourceType(string sourceType)
            {
                shouldSerialize["source_type"] = true;
                this.sourceType = sourceType;
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
            /// UpdatedAtBeginTime.
            /// </summary>
            /// <param name="updatedAtBeginTime"> updatedAtBeginTime. </param>
            /// <returns> Builder. </returns>
            public Builder UpdatedAtBeginTime(string updatedAtBeginTime)
            {
                shouldSerialize["updated_at_begin_time"] = true;
                this.updatedAtBeginTime = updatedAtBeginTime;
                return this;
            }

            /// <summary>
            /// UpdatedAtEndTime.
            /// </summary>
            /// <param name="updatedAtEndTime"> updatedAtEndTime. </param>
            /// <returns> Builder. </returns>
            public Builder UpdatedAtEndTime(string updatedAtEndTime)
            {
                shouldSerialize["updated_at_end_time"] = true;
                this.updatedAtEndTime = updatedAtEndTime;
                return this;
            }

            /// <summary>
            /// SortField.
            /// </summary>
            /// <param name="sortField"> sortField. </param>
            /// <returns> Builder. </returns>
            public Builder SortField(string sortField)
            {
                shouldSerialize["sort_field"] = true;
                this.sortField = sortField;
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
            public void UnsetSortOrder()
            {
                this.shouldSerialize["sort_order"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetStatus()
            {
                this.shouldSerialize["status"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSourceType()
            {
                this.shouldSerialize["source_type"] = false;
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
            public void UnsetUpdatedAtBeginTime()
            {
                this.shouldSerialize["updated_at_begin_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUpdatedAtEndTime()
            {
                this.shouldSerialize["updated_at_end_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSortField()
            {
                this.shouldSerialize["sort_field"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListPaymentRefundsRequest. </returns>
            public ListPaymentRefundsRequest Build()
            {
                return new ListPaymentRefundsRequest(
                    shouldSerialize,
                    this.beginTime,
                    this.endTime,
                    this.sortOrder,
                    this.cursor,
                    this.locationId,
                    this.status,
                    this.sourceType,
                    this.limit,
                    this.updatedAtBeginTime,
                    this.updatedAtEndTime,
                    this.sortField
                );
            }
        }
    }
}
