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
            string sourceType = null,
            int? limit = null)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
            LocationId = locationId;
            Status = status;
            SourceType = sourceType;
            Limit = limit;
        }

        /// <summary>
        /// Timestamp for the beginning of the requested reporting period, in RFC 3339 format.
        /// Default: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// Timestamp for the end of the requested reporting period, in RFC 3339 format.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; }

        /// <summary>
        /// The order in which results are listed.
        /// - `ASC` - oldest to newest
        /// - `DESC` - newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Limit results to the location supplied. By default, results are returned
        /// for all locations associated with the merchant.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// If provided, only refunds with the given status are returned.
        /// For a list of refund status values, see [PaymentRefund](#type-paymentrefund).
        /// Default: If omitted refunds are returned regardless of status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// If provided, only refunds with the given source type are returned.
        /// - `CARD` - List refunds only for payments where card was specified as payment
        /// source.
        /// Default: If omitted refunds are returned regardless of source type.
        /// </summary>
        [JsonProperty("source_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceType { get; }

        /// <summary>
        /// Maximum number of results to be returned in a single page.
        /// It is possible to receive fewer results than the specified limit on a given page.
        /// If the supplied value is greater than 100, at most 100 results will be returned.
        /// Default: `100`
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BeginTime(BeginTime)
                .EndTime(EndTime)
                .SortOrder(SortOrder)
                .Cursor(Cursor)
                .LocationId(LocationId)
                .Status(Status)
                .SourceType(SourceType)
                .Limit(Limit);
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
            private int? limit;



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

            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder SourceType(string sourceType)
            {
                this.sourceType = sourceType;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
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
                    sourceType,
                    limit);
            }
        }
    }
}