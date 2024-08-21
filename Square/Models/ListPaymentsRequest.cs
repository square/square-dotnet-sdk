namespace Square.Models
{
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

    /// <summary>
    /// ListPaymentsRequest.
    /// </summary>
    public class ListPaymentsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
        /// <param name="isOfflinePayment">is_offline_payment.</param>
        /// <param name="offlineBeginTime">offline_begin_time.</param>
        /// <param name="offlineEndTime">offline_end_time.</param>
        public ListPaymentsRequest(
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            string locationId = null,
            long? total = null,
            string last4 = null,
            string cardBrand = null,
            int? limit = null,
            bool? isOfflinePayment = null,
            string offlineBeginTime = null,
            string offlineEndTime = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "begin_time", false },
                { "end_time", false },
                { "sort_order", false },
                { "cursor", false },
                { "location_id", false },
                { "total", false },
                { "last_4", false },
                { "card_brand", false },
                { "limit", false },
                { "is_offline_payment", false },
                { "offline_begin_time", false },
                { "offline_end_time", false }
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

            if (total != null)
            {
                shouldSerialize["total"] = true;
                this.Total = total;
            }

            if (last4 != null)
            {
                shouldSerialize["last_4"] = true;
                this.Last4 = last4;
            }

            if (cardBrand != null)
            {
                shouldSerialize["card_brand"] = true;
                this.CardBrand = cardBrand;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (isOfflinePayment != null)
            {
                shouldSerialize["is_offline_payment"] = true;
                this.IsOfflinePayment = isOfflinePayment;
            }

            if (offlineBeginTime != null)
            {
                shouldSerialize["offline_begin_time"] = true;
                this.OfflineBeginTime = offlineBeginTime;
            }

            if (offlineEndTime != null)
            {
                shouldSerialize["offline_end_time"] = true;
                this.OfflineEndTime = offlineEndTime;
            }

        }
        internal ListPaymentsRequest(Dictionary<string, bool> shouldSerialize,
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            string locationId = null,
            long? total = null,
            string last4 = null,
            string cardBrand = null,
            int? limit = null,
            bool? isOfflinePayment = null,
            string offlineBeginTime = null,
            string offlineEndTime = null)
        {
            this.shouldSerialize = shouldSerialize;
            BeginTime = beginTime;
            EndTime = endTime;
            SortOrder = sortOrder;
            Cursor = cursor;
            LocationId = locationId;
            Total = total;
            Last4 = last4;
            CardBrand = cardBrand;
            Limit = limit;
            IsOfflinePayment = isOfflinePayment;
            OfflineBeginTime = offlineBeginTime;
            OfflineEndTime = offlineEndTime;
        }

        /// <summary>
        /// Indicates the start of the time range to retrieve payments for, in RFC 3339 format.
        /// The range is determined using the `created_at` field for each Payment.
        /// Inclusive. Default: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// Indicates the end of the time range to retrieve payments for, in RFC 3339 format.  The
        /// range is determined using the `created_at` field for each Payment.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// The order in which results are listed by `Payment.created_at`:
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
        /// for the default (main) location associated with the seller.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The exact amount in the `total_money` for a payment.
        /// </summary>
        [JsonProperty("total")]
        public long? Total { get; }

        /// <summary>
        /// The last four digits of a payment card.
        /// </summary>
        [JsonProperty("last_4")]
        public string Last4 { get; }

        /// <summary>
        /// The brand of the payment card (for example, VISA).
        /// </summary>
        [JsonProperty("card_brand")]
        public string CardBrand { get; }

        /// <summary>
        /// The maximum number of results to be returned in a single page.
        /// It is possible to receive fewer results than the specified limit on a given page.
        /// The default value of 100 is also the maximum allowed value. If the provided value is
        /// greater than 100, it is ignored and the default value is used instead.
        /// Default: `100`
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Whether the payment was taken offline or not.
        /// </summary>
        [JsonProperty("is_offline_payment")]
        public bool? IsOfflinePayment { get; }

        /// <summary>
        /// Indicates the start of the time range for which to retrieve offline payments, in RFC 3339
        /// format for timestamps. The range is determined using the
        /// `offline_payment_details.client_created_at` field for each Payment. If set, payments without a
        /// value set in `offline_payment_details.client_created_at` will not be returned.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("offline_begin_time")]
        public string OfflineBeginTime { get; }

        /// <summary>
        /// Indicates the end of the time range for which to retrieve offline payments, in RFC 3339
        /// format for timestamps. The range is determined using the
        /// `offline_payment_details.client_created_at` field for each Payment. If set, payments without a
        /// value set in `offline_payment_details.client_created_at` will not be returned.
        /// Default: The current time.
        /// </summary>
        [JsonProperty("offline_end_time")]
        public string OfflineEndTime { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListPaymentsRequest : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeTotal()
        {
            return this.shouldSerialize["total"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLast4()
        {
            return this.shouldSerialize["last_4"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCardBrand()
        {
            return this.shouldSerialize["card_brand"];
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
        public bool ShouldSerializeIsOfflinePayment()
        {
            return this.shouldSerialize["is_offline_payment"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfflineBeginTime()
        {
            return this.shouldSerialize["offline_begin_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOfflineEndTime()
        {
            return this.shouldSerialize["offline_end_time"];
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
            return obj is ListPaymentsRequest other &&                ((this.BeginTime == null && other.BeginTime == null) || (this.BeginTime?.Equals(other.BeginTime) == true)) &&
                ((this.EndTime == null && other.EndTime == null) || (this.EndTime?.Equals(other.EndTime) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Total == null && other.Total == null) || (this.Total?.Equals(other.Total) == true)) &&
                ((this.Last4 == null && other.Last4 == null) || (this.Last4?.Equals(other.Last4) == true)) &&
                ((this.CardBrand == null && other.CardBrand == null) || (this.CardBrand?.Equals(other.CardBrand) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.IsOfflinePayment == null && other.IsOfflinePayment == null) || (this.IsOfflinePayment?.Equals(other.IsOfflinePayment) == true)) &&
                ((this.OfflineBeginTime == null && other.OfflineBeginTime == null) || (this.OfflineBeginTime?.Equals(other.OfflineBeginTime) == true)) &&
                ((this.OfflineEndTime == null && other.OfflineEndTime == null) || (this.OfflineEndTime?.Equals(other.OfflineEndTime) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 973903656;
            hashCode = HashCode.Combine(this.BeginTime, this.EndTime, this.SortOrder, this.Cursor, this.LocationId, this.Total, this.Last4);

            hashCode = HashCode.Combine(hashCode, this.CardBrand, this.Limit, this.IsOfflinePayment, this.OfflineBeginTime, this.OfflineEndTime);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeginTime = {(this.BeginTime == null ? "null" : this.BeginTime)}");
            toStringOutput.Add($"this.EndTime = {(this.EndTime == null ? "null" : this.EndTime)}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder)}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Total = {(this.Total == null ? "null" : this.Total.ToString())}");
            toStringOutput.Add($"this.Last4 = {(this.Last4 == null ? "null" : this.Last4)}");
            toStringOutput.Add($"this.CardBrand = {(this.CardBrand == null ? "null" : this.CardBrand)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.IsOfflinePayment = {(this.IsOfflinePayment == null ? "null" : this.IsOfflinePayment.ToString())}");
            toStringOutput.Add($"this.OfflineBeginTime = {(this.OfflineBeginTime == null ? "null" : this.OfflineBeginTime)}");
            toStringOutput.Add($"this.OfflineEndTime = {(this.OfflineEndTime == null ? "null" : this.OfflineEndTime)}");
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
                .Limit(this.Limit)
                .IsOfflinePayment(this.IsOfflinePayment)
                .OfflineBeginTime(this.OfflineBeginTime)
                .OfflineEndTime(this.OfflineEndTime);
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
                { "total", false },
                { "last_4", false },
                { "card_brand", false },
                { "limit", false },
                { "is_offline_payment", false },
                { "offline_begin_time", false },
                { "offline_end_time", false },
            };

            private string beginTime;
            private string endTime;
            private string sortOrder;
            private string cursor;
            private string locationId;
            private long? total;
            private string last4;
            private string cardBrand;
            private int? limit;
            private bool? isOfflinePayment;
            private string offlineBeginTime;
            private string offlineEndTime;

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
             /// Total.
             /// </summary>
             /// <param name="total"> total. </param>
             /// <returns> Builder. </returns>
            public Builder Total(long? total)
            {
                shouldSerialize["total"] = true;
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
                shouldSerialize["last_4"] = true;
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
                shouldSerialize["card_brand"] = true;
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
                shouldSerialize["limit"] = true;
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// IsOfflinePayment.
             /// </summary>
             /// <param name="isOfflinePayment"> isOfflinePayment. </param>
             /// <returns> Builder. </returns>
            public Builder IsOfflinePayment(bool? isOfflinePayment)
            {
                shouldSerialize["is_offline_payment"] = true;
                this.isOfflinePayment = isOfflinePayment;
                return this;
            }

             /// <summary>
             /// OfflineBeginTime.
             /// </summary>
             /// <param name="offlineBeginTime"> offlineBeginTime. </param>
             /// <returns> Builder. </returns>
            public Builder OfflineBeginTime(string offlineBeginTime)
            {
                shouldSerialize["offline_begin_time"] = true;
                this.offlineBeginTime = offlineBeginTime;
                return this;
            }

             /// <summary>
             /// OfflineEndTime.
             /// </summary>
             /// <param name="offlineEndTime"> offlineEndTime. </param>
             /// <returns> Builder. </returns>
            public Builder OfflineEndTime(string offlineEndTime)
            {
                shouldSerialize["offline_end_time"] = true;
                this.offlineEndTime = offlineEndTime;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBeginTime()
            {
                this.shouldSerialize["begin_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndTime()
            {
                this.shouldSerialize["end_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSortOrder()
            {
                this.shouldSerialize["sort_order"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTotal()
            {
                this.shouldSerialize["total"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLast4()
            {
                this.shouldSerialize["last_4"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCardBrand()
            {
                this.shouldSerialize["card_brand"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsOfflinePayment()
            {
                this.shouldSerialize["is_offline_payment"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOfflineBeginTime()
            {
                this.shouldSerialize["offline_begin_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOfflineEndTime()
            {
                this.shouldSerialize["offline_end_time"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListPaymentsRequest. </returns>
            public ListPaymentsRequest Build()
            {
                return new ListPaymentsRequest(shouldSerialize,
                    this.beginTime,
                    this.endTime,
                    this.sortOrder,
                    this.cursor,
                    this.locationId,
                    this.total,
                    this.last4,
                    this.cardBrand,
                    this.limit,
                    this.isOfflinePayment,
                    this.offlineBeginTime,
                    this.offlineEndTime);
            }
        }
    }
}