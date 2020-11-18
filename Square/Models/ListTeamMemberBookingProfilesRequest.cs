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