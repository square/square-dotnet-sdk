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
    public class ListPaymentsRequest 
    {
        public ListPaymentsRequest(string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            string locationId = null,
            long? total = null,
            string last4 = null,
            string cardBrand = null)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
            LocationId = locationId;
            Total = total;
            Last4 = last4;
            CardBrand = cardBrand;
        }

        /// <summary>
        /// Timestamp for the beginning of the reporting period, in RFC 3339 format.
        /// Inclusive. Default: The current time minus one year.
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
        /// The exact amount in the total_money for a `Payment`.
        /// </summary>
        [JsonProperty("total")]
        public long? Total { get; }

        /// <summary>
        /// The last 4 digits of `Payment` card.
        /// </summary>
        [JsonProperty("last_4")]
        public string Last4 { get; }

        /// <summary>
        /// The brand of `Payment` card. For example, `VISA`
        /// </summary>
        [JsonProperty("card_brand")]
        public string CardBrand { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BeginTime(BeginTime)
                .EndTime(EndTime)
                .SortOrder(SortOrder)
                .Cursor(Cursor)
                .LocationId(LocationId)
                .Total(Total)
                .Last4(Last4)
                .CardBrand(CardBrand);
            return builder;
        }

        public class Builder
        {
            private string beginTime;
            private string endTime;
            private string sortOrder;
            private string cursor;
            private string locationId;
            private long? total;
            private string last4;
            private string cardBrand;

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

            public Builder Total(long? value)
            {
                total = value;
                return this;
            }

            public Builder Last4(string value)
            {
                last4 = value;
                return this;
            }

            public Builder CardBrand(string value)
            {
                cardBrand = value;
                return this;
            }

            public ListPaymentsRequest Build()
            {
                return new ListPaymentsRequest(beginTime,
                    endTime,
                    sortOrder,
                    cursor,
                    locationId,
                    total,
                    last4,
                    cardBrand);
            }
        }
    }
}