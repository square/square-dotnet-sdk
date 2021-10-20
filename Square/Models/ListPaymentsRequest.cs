namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// ListPaymentsRequest.
    /// </summary>
    public class ListPaymentsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListPaymentsRequest"/> class.
        /// </summary>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="endTime">end_time.</param>
        /// <param name="sortOrder">sort_order.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="total">total.</param>
        /// <param name="last4">last_4.</param>
        /// <param name="cardBrand">card_brand.</param>
        /// <param name="limit">limit.</param>
        public ListPaymentsRequest(
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            string locationId = null,
            long? total = null,
            string last4 = null,
            string cardBrand = null,
            int? limit = null)
        {
            this.BeginTime = beginTime;
            this.EndTime = endTime;
            this.SortOrder = sortOrder;
            this.Cursor = cursor;
            this.LocationId = locationId;
            this.Total = total;
            this.Last4 = last4;
            this.CardBrand = cardBrand;
            this.Limit = limit;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListPaymentsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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

            return obj is ListPaymentsRequest other &&
                ((this.BeginTime == null && other.BeginTime == null) || (this.BeginTime?.Equals(other.BeginTime) == true)) &&
                ((this.EndTime == null && other.EndTime == null) || (this.EndTime?.Equals(other.EndTime) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Total == null && other.Total == null) || (this.Total?.Equals(other.Total) == true)) &&
                ((this.Last4 == null && other.Last4 == null) || (this.Last4?.Equals(other.Last4) == true)) &&
                ((this.CardBrand == null && other.CardBrand == null) || (this.CardBrand?.Equals(other.CardBrand) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 805936600;
            hashCode = HashCode.Combine(this.BeginTime, this.EndTime, this.SortOrder, this.Cursor, this.LocationId, this.Total, this.Last4);

            hashCode = HashCode.Combine(hashCode, this.CardBrand, this.Limit);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeginTime = {(this.BeginTime == null ? "null" : this.BeginTime == string.Empty ? "" : this.BeginTime)}");
            toStringOutput.Add($"this.EndTime = {(this.EndTime == null ? "null" : this.EndTime == string.Empty ? "" : this.EndTime)}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder == string.Empty ? "" : this.SortOrder)}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.Total = {(this.Total == null ? "null" : this.Total.ToString())}");
            toStringOutput.Add($"this.Last4 = {(this.Last4 == null ? "null" : this.Last4 == string.Empty ? "" : this.Last4)}");
            toStringOutput.Add($"this.CardBrand = {(this.CardBrand == null ? "null" : this.CardBrand == string.Empty ? "" : this.CardBrand)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
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
                .Total(this.Total)
                .Last4(this.Last4)
                .CardBrand(this.CardBrand)
                .Limit(this.Limit);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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

             /// <summary>
             /// BeginTime.
             /// </summary>
             /// <param name="beginTime"> beginTime. </param>
             /// <returns> Builder. </returns>
            public Builder BeginTime(string beginTime)
            {
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
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// Total.
             /// </summary>
             /// <param name="total"> total. </param>
             /// <returns> Builder. </returns>
            public Builder Total(long? total)
            {
                this.total = total;
                return this;
            }

             /// <summary>
             /// Last4.
             /// </summary>
             /// <param name="last4"> last4. </param>
             /// <returns> Builder. </returns>
            public Builder Last4(string last4)
            {
                this.last4 = last4;
                return this;
            }

             /// <summary>
             /// CardBrand.
             /// </summary>
             /// <param name="cardBrand"> cardBrand. </param>
             /// <returns> Builder. </returns>
            public Builder CardBrand(string cardBrand)
            {
                this.cardBrand = cardBrand;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListPaymentsRequest. </returns>
            public ListPaymentsRequest Build()
            {
                return new ListPaymentsRequest(
                    this.beginTime,
                    this.endTime,
                    this.sortOrder,
                    this.cursor,
                    this.locationId,
                    this.total,
                    this.last4,
                    this.cardBrand,
                    this.limit);
            }
        }
    }
}