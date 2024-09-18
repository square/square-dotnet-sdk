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
    /// ListGiftCardActivitiesRequest.
    /// </summary>
    public class ListGiftCardActivitiesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "gift_card_id", false },
                { "type", false },
                { "location_id", false },
                { "begin_time", false },
                { "end_time", false },
                { "limit", false },
                { "cursor", false },
                { "sort_order", false }
            };

            if (giftCardId != null)
            {
                shouldSerialize["gift_card_id"] = true;
                this.GiftCardId = giftCardId;
            }

            if (type != null)
            {
                shouldSerialize["type"] = true;
                this.Type = type;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

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

            if (sortOrder != null)
            {
                shouldSerialize["sort_order"] = true;
                this.SortOrder = sortOrder;
            }

        }
        internal ListGiftCardActivitiesRequest(Dictionary<string, bool> shouldSerialize,
            string giftCardId = null,
            string type = null,
            string locationId = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string cursor = null,
            string sortOrder = null)
        {
            this.shouldSerialize = shouldSerialize;
            GiftCardId = giftCardId;
            Type = type;
            LocationId = locationId;
            BeginTime = beginTime;
            EndTime = endTime;
            Limit = limit;
            Cursor = cursor;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// If a gift card ID is provided, the endpoint returns activities related
        /// to the specified gift card. Otherwise, the endpoint returns all gift card activities for
        /// the seller.
        /// </summary>
        [JsonProperty("gift_card_id")]
        public string GiftCardId { get; }

        /// <summary>
        /// If a [type](entity:GiftCardActivityType) is provided, the endpoint returns gift card activities of the specified type.
        /// Otherwise, the endpoint returns all types of gift card activities.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// If a location ID is provided, the endpoint returns gift card activities for the specified location.
        /// Otherwise, the endpoint returns gift card activities for all locations.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The timestamp for the beginning of the reporting period, in RFC 3339 format.
        /// This start time is inclusive. The default value is the current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// The timestamp for the end of the reporting period, in RFC 3339 format.
        /// This end time is inclusive. The default value is the current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// If a limit is provided, the endpoint returns the specified number
        /// of results (or fewer) per page. The maximum value is 100. The default value is 50.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for the original query.
        /// If a cursor is not provided, the endpoint returns the first page of the results.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The order in which the endpoint returns the activities, based on `created_at`.
        /// - `ASC` - Oldest to newest.
        /// - `DESC` - Newest to oldest (default).
        /// </summary>
        [JsonProperty("sort_order")]
        public string SortOrder { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListGiftCardActivitiesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeGiftCardId()
        {
            return this.shouldSerialize["gift_card_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeType()
        {
            return this.shouldSerialize["type"];
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSortOrder()
        {
            return this.shouldSerialize["sort_order"];
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
            return obj is ListGiftCardActivitiesRequest other &&                ((this.GiftCardId == null && other.GiftCardId == null) || (this.GiftCardId?.Equals(other.GiftCardId) == true)) &&
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
            toStringOutput.Add($"this.GiftCardId = {(this.GiftCardId == null ? "null" : this.GiftCardId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.BeginTime = {(this.BeginTime == null ? "null" : this.BeginTime)}");
            toStringOutput.Add($"this.EndTime = {(this.EndTime == null ? "null" : this.EndTime)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "gift_card_id", false },
                { "type", false },
                { "location_id", false },
                { "begin_time", false },
                { "end_time", false },
                { "limit", false },
                { "cursor", false },
                { "sort_order", false },
            };

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
                shouldSerialize["gift_card_id"] = true;
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
                shouldSerialize["type"] = true;
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
                shouldSerialize["location_id"] = true;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetGiftCardId()
            {
                this.shouldSerialize["gift_card_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetType()
            {
                this.shouldSerialize["type"] = false;
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
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
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
            public void UnsetSortOrder()
            {
                this.shouldSerialize["sort_order"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListGiftCardActivitiesRequest. </returns>
            public ListGiftCardActivitiesRequest Build()
            {
                return new ListGiftCardActivitiesRequest(shouldSerialize,
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