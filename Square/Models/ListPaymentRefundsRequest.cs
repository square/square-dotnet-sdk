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
    public class ListPaymentRefundsRequest 
    {
        public ListPaymentRefundsRequest(string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            string locationId = null,
            string status = null,
            string sourceType = null)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
            LocationId = locationId;
            Status = status;
            SourceType = sourceType;
        }

        /// <summary>
        /// Timestamp for the beginning of the requested reporting period, in RFC 3339 format.
        /// Default: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// Timestamp for the end of the requested reporting period, in RFC 3339 format.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// The order in which results are listed.
        /// - `ASC` - oldest to newest
        /// - `DESC` - newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Limit results to the location supplied. By default, results are returned
        /// for all locations associated with the merchant.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// If provided, only refunds with the given status are returned.
        /// For a list of refund status values, see [PaymentRefund](#type-paymentrefund).
        /// Default: If omitted refunds are returned regardless of status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// If provided, only refunds with the given source type are returned.
        /// - `CARD` - List refunds only for payments where card was specified as payment
        /// source.
        /// Default: If omitted refunds are returned regardless of source type.
        /// </summary>
        [JsonProperty("source_type")]
        public string SourceType { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BeginTime(BeginTime)
                .EndTime(EndTime)
                .SortOrder(SortOrder)
                .Cursor(Cursor)
                .LocationId(LocationId)
                .Status(Status)
                .SourceType(SourceType);
            return builder;
        }

        public class Builder
        {
            private string beginTime;
            private string endTime;
            private string sortOrder;
            private string cursor;
            private string locationId;
            private string status;
            private string sourceType;

            public Builder() { }
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

            public Builder SortOrder(string value)
            {
                sortOrder = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder SourceType(string value)
            {
                sourceType = value;
                return this;
            }

            public ListPaymentRefundsRequest Build()
            {
                return new ListPaymentRefundsRequest(beginTime,
                    endTime,
                    sortOrder,
                    cursor,
                    locationId,
                    status,
                    sourceType);
            }
        }
    }
}