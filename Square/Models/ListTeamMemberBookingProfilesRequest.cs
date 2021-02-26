
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
    public class ListTeamMemberBookingProfilesRequest 
    {
        public ListTeamMemberBookingProfilesRequest(bool? bookableOnly = null,
            int? limit = null,
            string cursor = null,
            string locationId = null)
        {
            BookableOnly = bookableOnly;
            Limit = limit;
            Cursor = cursor;
            LocationId = locationId;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTeamMemberBookingProfilesRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"BookableOnly = {(BookableOnly == null ? "null" : BookableOnly.ToString())}");
            toStringOutput.Add($"Limit = {(Limit == null ? "null" : Limit.ToString())}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
        }

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
                ((BookableOnly == null && other.BookableOnly == null) || (BookableOnly?.Equals(other.BookableOnly) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -294097730;

            if (BookableOnly != null)
            {
               hashCode += BookableOnly.GetHashCode();
            }

            if (Limit != null)
            {
               hashCode += Limit.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BookableOnly(BookableOnly)
                .Limit(Limit)
                .Cursor(Cursor)
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private bool? bookableOnly;
            private int? limit;
            private string cursor;
            private string locationId;



            public Builder BookableOnly(bool? bookableOnly)
            {
                this.bookableOnly = bookableOnly;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
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

            public ListTeamMemberBookingProfilesRequest Build()
            {
                return new ListTeamMemberBookingProfilesRequest(bookableOnly,
                    limit,
                    cursor,
                    locationId);
            }
        }
    }
}