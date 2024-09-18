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
    /// ListBookingsRequest.
    /// </summary>
    public class ListBookingsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBookingsRequest"/> class.
        /// </summary>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="startAtMin">start_at_min.</param>
        /// <param name="startAtMax">start_at_max.</param>
        public ListBookingsRequest(
            int? limit = null,
            string cursor = null,
            string customerId = null,
            string teamMemberId = null,
            string locationId = null,
            string startAtMin = null,
            string startAtMax = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "limit", false },
                { "cursor", false },
                { "customer_id", false },
                { "team_member_id", false },
                { "location_id", false },
                { "start_at_min", false },
                { "start_at_max", false }
            };

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

            if (customerId != null)
            {
                shouldSerialize["customer_id"] = true;
                this.CustomerId = customerId;
            }

            if (teamMemberId != null)
            {
                shouldSerialize["team_member_id"] = true;
                this.TeamMemberId = teamMemberId;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (startAtMin != null)
            {
                shouldSerialize["start_at_min"] = true;
                this.StartAtMin = startAtMin;
            }

            if (startAtMax != null)
            {
                shouldSerialize["start_at_max"] = true;
                this.StartAtMax = startAtMax;
            }

        }
        internal ListBookingsRequest(Dictionary<string, bool> shouldSerialize,
            int? limit = null,
            string cursor = null,
            string customerId = null,
            string teamMemberId = null,
            string locationId = null,
            string startAtMin = null,
            string startAtMax = null)
        {
            this.shouldSerialize = shouldSerialize;
            Limit = limit;
            Cursor = cursor;
            CustomerId = customerId;
            TeamMemberId = teamMemberId;
            LocationId = locationId;
            StartAtMin = startAtMin;
            StartAtMax = startAtMax;
        }

        /// <summary>
        /// The maximum number of results per page to return in a paged response.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The [customer](entity:Customer) for whom to retrieve bookings. If this is not set, bookings for all customers are retrieved.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used.
        /// </summary>
        [JsonProperty("start_at_min")]
        public string StartAtMin { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used.
        /// </summary>
        [JsonProperty("start_at_max")]
        public string StartAtMax { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListBookingsRequest : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeCustomerId()
        {
            return this.shouldSerialize["customer_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberId()
        {
            return this.shouldSerialize["team_member_id"];
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
        public bool ShouldSerializeStartAtMin()
        {
            return this.shouldSerialize["start_at_min"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStartAtMax()
        {
            return this.shouldSerialize["start_at_max"];
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
            return obj is ListBookingsRequest other &&                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.StartAtMin == null && other.StartAtMin == null) || (this.StartAtMin?.Equals(other.StartAtMin) == true)) &&
                ((this.StartAtMax == null && other.StartAtMax == null) || (this.StartAtMax?.Equals(other.StartAtMax) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1824278131;
            hashCode = HashCode.Combine(this.Limit, this.Cursor, this.CustomerId, this.TeamMemberId, this.LocationId, this.StartAtMin, this.StartAtMax);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.StartAtMin = {(this.StartAtMin == null ? "null" : this.StartAtMin)}");
            toStringOutput.Add($"this.StartAtMax = {(this.StartAtMax == null ? "null" : this.StartAtMax)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Limit(this.Limit)
                .Cursor(this.Cursor)
                .CustomerId(this.CustomerId)
                .TeamMemberId(this.TeamMemberId)
                .LocationId(this.LocationId)
                .StartAtMin(this.StartAtMin)
                .StartAtMax(this.StartAtMax);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "limit", false },
                { "cursor", false },
                { "customer_id", false },
                { "team_member_id", false },
                { "location_id", false },
                { "start_at_min", false },
                { "start_at_max", false },
            };

            private int? limit;
            private string cursor;
            private string customerId;
            private string teamMemberId;
            private string locationId;
            private string startAtMin;
            private string startAtMax;

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
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                shouldSerialize["customer_id"] = true;
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                shouldSerialize["team_member_id"] = true;
                this.teamMemberId = teamMemberId;
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
             /// StartAtMin.
             /// </summary>
             /// <param name="startAtMin"> startAtMin. </param>
             /// <returns> Builder. </returns>
            public Builder StartAtMin(string startAtMin)
            {
                shouldSerialize["start_at_min"] = true;
                this.startAtMin = startAtMin;
                return this;
            }

             /// <summary>
             /// StartAtMax.
             /// </summary>
             /// <param name="startAtMax"> startAtMax. </param>
             /// <returns> Builder. </returns>
            public Builder StartAtMax(string startAtMax)
            {
                shouldSerialize["start_at_max"] = true;
                this.startAtMax = startAtMax;
                return this;
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
            public void UnsetCustomerId()
            {
                this.shouldSerialize["customer_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
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
            public void UnsetStartAtMin()
            {
                this.shouldSerialize["start_at_min"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStartAtMax()
            {
                this.shouldSerialize["start_at_max"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListBookingsRequest. </returns>
            public ListBookingsRequest Build()
            {
                return new ListBookingsRequest(shouldSerialize,
                    this.limit,
                    this.cursor,
                    this.customerId,
                    this.teamMemberId,
                    this.locationId,
                    this.startAtMin,
                    this.startAtMax);
            }
        }
    }
}