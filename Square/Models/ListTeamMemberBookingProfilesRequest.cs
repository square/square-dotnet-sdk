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
            this.BookableOnly = bookableOnly;
            this.Limit = limit;
            this.Cursor = cursor;
            this.LocationId = locationId;
        }

        /// <summary>
        /// Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("bookable_only", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BookableOnly { get; }

        /// <summary>
        /// The maximum number of results to return.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// The cursor for paginating through the results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Indicates whether to include only team members enabled at the given location in the returned result.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTeamMemberBookingProfilesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListTeamMemberBookingProfilesRequest other &&
                ((this.BookableOnly == null && other.BookableOnly == null) || (this.BookableOnly?.Equals(other.BookableOnly) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -294097730;

            if (this.BookableOnly != null)
            {
               hashCode += this.BookableOnly.GetHashCode();
            }

            if (this.Limit != null)
            {
               hashCode += this.Limit.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> ListTeamMemberBookingProfilesRequest. </returns>
            public ListTeamMemberBookingProfilesRequest Build()
            {
                return new ListTeamMemberBookingProfilesRequest(
                    this.bookableOnly,
                    this.limit,
                    this.cursor,
                    this.locationId);
            }
        }
    }
}