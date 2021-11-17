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
    /// ListBookingsRequest.
    /// </summary>
    public class ListBookingsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBookingsRequest"/> class.
        /// </summary>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="startAtMin">start_at_min.</param>
        /// <param name="startAtMax">start_at_max.</param>
        public ListBookingsRequest(
            int? limit = null,
            string cursor = null,
            string teamMemberId = null,
            string locationId = null,
            string startAtMin = null,
            string startAtMax = null)
        {
            this.Limit = limit;
            this.Cursor = cursor;
            this.TeamMemberId = teamMemberId;
            this.LocationId = locationId;
            this.StartAtMin = startAtMin;
            this.StartAtMax = startAtMax;
        }

        /// <summary>
        /// The maximum number of results per page to return in a paged response.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used.
        /// </summary>
        [JsonProperty("start_at_min", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAtMin { get; }

        /// <summary>
        /// The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used.
        /// </summary>
        [JsonProperty("start_at_max", NullValueHandling = NullValueHandling.Ignore)]
        public string StartAtMax { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListBookingsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListBookingsRequest other &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.StartAtMin == null && other.StartAtMin == null) || (this.StartAtMin?.Equals(other.StartAtMin) == true)) &&
                ((this.StartAtMax == null && other.StartAtMax == null) || (this.StartAtMax?.Equals(other.StartAtMax) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1962659262;
            hashCode = HashCode.Combine(this.Limit, this.Cursor, this.TeamMemberId, this.LocationId, this.StartAtMin, this.StartAtMax);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.StartAtMin = {(this.StartAtMin == null ? "null" : this.StartAtMin == string.Empty ? "" : this.StartAtMin)}");
            toStringOutput.Add($"this.StartAtMax = {(this.StartAtMax == null ? "null" : this.StartAtMax == string.Empty ? "" : this.StartAtMax)}");
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
            private int? limit;
            private string cursor;
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
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
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
                this.startAtMax = startAtMax;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListBookingsRequest. </returns>
            public ListBookingsRequest Build()
            {
                return new ListBookingsRequest(
                    this.limit,
                    this.cursor,
                    this.teamMemberId,
                    this.locationId,
                    this.startAtMin,
                    this.startAtMax);
            }
        }
    }
}