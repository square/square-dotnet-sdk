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
            string cardBrand = null,
            int? limit = null)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
            LocationId = locationId;
            Total = total;
            Last4 = last4;
            CardBrand = cardBrand;
            Limit = limit;
        }

        /// <summary>
        /// The timestamp for the beginning of the reporting period, in RFC 3339 format.
        /// Inclusive. Default: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// The timestamp for the end of the reporting period, in RFC 3339 format.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; }

        /// <summary>
        /// The order in which results are listed:
        /// - `ASC` - Oldest to newest.
        /// - `DESC` - Newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for the original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Limit results to the location supplied. By default, results are returned
        /// for the default (main) location associated with the seller.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The exact amount in the `total_money` for a payment.
        /// </summary>
        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; }

        /// <summary>
        /// The last four digits of a payment card.
        /// </summary>
        [JsonProperty("last_4", NullValueHandling = NullValueHandling.Ignore)]
        public string Last4 { get; }

        /// <summary>
        /// The brand of the payment card (for example, VISA).
        /// </summary>
        [JsonProperty("card_brand", NullValueHandling = NullValueHandling.Ignore)]
        public string CardBrand { get; }

        /// <summary>
        /// The maximum number of results to be returned in a single page.
        /// It is possible to receive fewer results than the specified limit on a given page.
        /// The default value of 100 is also the maximum allowed value. If the provided value is 
        /// greater than 100, it is ignored and the default value is used instead.
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
                .Total(Total)
                .Last4(Last4)
                .CardBrand(CardBrand)
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
            private long? total;
            private string last4;
            private string cardBrand;
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

            public Builder Total(long? total)
            {
                this.total = total;
                return this;
            }

            public Builder Last4(string last4)
            {
                this.last4 = last4;
                return this;
            }

            public Builder CardBrand(string cardBrand)
            {
                this.cardBrand = cardBrand;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
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
                    cardBrand,
                    limit);
            }
        }
    }
}