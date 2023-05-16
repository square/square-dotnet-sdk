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
    /// ListTeamMemberBookingProfilesRequest.
    /// </summary>
    public class ListTeamMemberBookingProfilesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListTeamMemberBookingProfilesRequest"/> class.
        /// </summary>
        /// <param name="bookableOnly">bookable_only.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="locationId">location_id.</param>
        public ListTeamMemberBookingProfilesRequest(
            bool? bookableOnly = null,
            int? limit = null,
            string cursor = null,
            string locationId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "bookable_only", false },
                { "limit", false },
                { "cursor", false },
                { "location_id", false }
            };

            if (bookableOnly != null)
            {
                shouldSerialize["bookable_only"] = true;
                this.BookableOnly = bookableOnly;
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

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

        }
        internal ListTeamMemberBookingProfilesRequest(Dictionary<string, bool> shouldSerialize,
            bool? bookableOnly = null,
            int? limit = null,
            string cursor = null,
            string locationId = null)
        {
            this.shouldSerialize = shouldSerialize;
            BookableOnly = bookableOnly;
            Limit = limit;
            Cursor = cursor;
            LocationId = locationId;
        }

        /// <summary>
        /// Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("bookable_only")]
        public bool? BookableOnly { get; }

        /// <summary>
        /// The maximum number of results to return in a paged response.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Indicates whether to include only team members enabled at the given location in the returned result.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTeamMemberBookingProfilesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBookableOnly()
        {
            return this.shouldSerialize["bookable_only"];
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
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
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
            return obj is ListTeamMemberBookingProfilesRequest other &&                ((this.BookableOnly == null && other.BookableOnly == null) || (this.BookableOnly?.Equals(other.BookableOnly) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -294097730;
            hashCode = HashCode.Combine(this.BookableOnly, this.Limit, this.Cursor, this.LocationId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BookableOnly = {(this.BookableOnly == null ? "null" : this.BookableOnly.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BookableOnly(this.BookableOnly)
                .Limit(this.Limit)
                .Cursor(this.Cursor)
                .LocationId(this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "bookable_only", false },
                { "limit", false },
                { "cursor", false },
                { "location_id", false },
            };

            private bool? bookableOnly;
            private int? limit;
            private string cursor;
            private string locationId;

             /// <summary>
             /// BookableOnly.
             /// </summary>
             /// <param name="bookableOnly"> bookableOnly. </param>
             /// <returns> Builder. </returns>
            public Builder BookableOnly(bool? bookableOnly)
            {
                shouldSerialize["bookable_only"] = true;
                this.bookableOnly = bookableOnly;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBookableOnly()
            {
                this.shouldSerialize["bookable_only"] = false;
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
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListTeamMemberBookingProfilesRequest. </returns>
            public ListTeamMemberBookingProfilesRequest Build()
            {
                return new ListTeamMemberBookingProfilesRequest(shouldSerialize,
                    this.bookableOnly,
                    this.limit,
                    this.cursor,
                    this.locationId);
            }
        }
    }
}