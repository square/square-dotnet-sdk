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
    /// ListGiftCardActivitiesRequest.
    /// </summary>
    public class ListGiftCardActivitiesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListGiftCardActivitiesRequest"/> class.
        /// </summary>
        /// <param name="giftCardId">gift_card_id.</param>
        /// <param name="type">type.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="endTime">end_time.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="sortOrder">sort_order.</param>
        public ListGiftCardActivitiesRequest(
            string giftCardId = null,
            string type = null,
            string locationId = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string cursor = null,
            string sortOrder = null)
        {
            this.GiftCardId = giftCardId;
            this.Type = type;
            this.LocationId = locationId;
            this.BeginTime = beginTime;
            this.EndTime = endTime;
            this.Limit = limit;
            this.Cursor = cursor;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// If you provide a gift card ID, the endpoint returns activities that belong
        /// to the specified gift card. Otherwise, the endpoint returns all gift card activities for
        /// the seller.
        /// </summary>
        [JsonProperty("gift_card_id", NullValueHandling = NullValueHandling.Ignore)]
        public string GiftCardId { get; }

        /// <summary>
        /// If you provide a type, the endpoint returns gift card activities of this type.
        /// Otherwise, the endpoint returns all types of gift card activities.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// If you provide a location ID, the endpoint returns gift card activities for that location.
        /// Otherwise, the endpoint returns gift card activities for all locations.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The timestamp for the beginning of the reporting period, in RFC 3339 format.
        /// Inclusive. Default: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// The timestamp for the end of the reporting period, in RFC 3339 format.
        /// Inclusive. Default: The current time.
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; }

        /// <summary>
        /// If you provide a limit value, the endpoint returns the specified number
        /// of results (or less) per page. A maximum value is 100. The default value is 50.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for the original query.
        /// If you do not provide the cursor, the call returns the first page of the results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The order in which the endpoint returns the activities, based on `created_at`.
        /// - `ASC` - Oldest to newest.
        /// - `DESC` - Newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListGiftCardActivitiesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListGiftCardActivitiesRequest other &&
                ((this.GiftCardId == null && other.GiftCardId == null) || (this.GiftCardId?.Equals(other.GiftCardId) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.BeginTime == null && other.BeginTime == null) || (this.BeginTime?.Equals(other.BeginTime) == true)) &&
                ((this.EndTime == null && other.EndTime == null) || (this.EndTime?.Equals(other.EndTime) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 467092355;
            hashCode = HashCode.Combine(this.GiftCardId, this.Type, this.LocationId, this.BeginTime, this.EndTime, this.Limit, this.Cursor);

            hashCode = HashCode.Combine(hashCode, this.SortOrder);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.GiftCardId = {(this.GiftCardId == null ? "null" : this.GiftCardId == string.Empty ? "" : this.GiftCardId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.BeginTime = {(this.BeginTime == null ? "null" : this.BeginTime == string.Empty ? "" : this.BeginTime)}");
            toStringOutput.Add($"this.EndTime = {(this.EndTime == null ? "null" : this.EndTime == string.Empty ? "" : this.EndTime)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder == string.Empty ? "" : this.SortOrder)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .GiftCardId(this.GiftCardId)
                .Type(this.Type)
                .LocationId(this.LocationId)
                .BeginTime(this.BeginTime)
                .EndTime(this.EndTime)
                .Limit(this.Limit)
                .Cursor(this.Cursor)
                .SortOrder(this.SortOrder);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string giftCardId;
            private string type;
            private string locationId;
            private string beginTime;
            private string endTime;
            private int? limit;
            private string cursor;
            private string sortOrder;

             /// <summary>
             /// GiftCardId.
             /// </summary>
             /// <param name="giftCardId"> giftCardId. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCardId(string giftCardId)
            {
                this.giftCardId = giftCardId;
                return this;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
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
            /// Builds class object.
            /// </summary>
            /// <returns> ListGiftCardActivitiesRequest. </returns>
            public ListGiftCardActivitiesRequest Build()
            {
                return new ListGiftCardActivitiesRequest(
                    this.giftCardId,
                    this.type,
                    this.locationId,
                    this.beginTime,
                    this.endTime,
                    this.limit,
                    this.cursor,
                    this.sortOrder);
            }
        }
    }
}