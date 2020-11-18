using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class ListTeamMemberBookingProfilesResponse 
    {
        public ListTeamMemberBookingProfilesResponse(IList<Models.TeamMemberBookingProfile> teamMemberBookingProfiles = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            TeamMemberBookingProfiles = teamMemberBookingProfiles;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The list of team member booking profiles.
        /// </summary>
        [JsonProperty("team_member_booking_profiles", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.TeamMemberBookingProfile> TeamMemberBookingProfiles { get; }

        /// <summary>
        /// The cursor for paginating through the results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberBookingProfiles(TeamMemberBookingProfiles)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.TeamMemberBookingProfile> teamMemberBookingProfiles;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder TeamMemberBookingProfiles(IList<Models.TeamMemberBookingProfile> teamMemberBookingProfiles)
            {
                this.teamMemberBookingProfiles = teamMemberBookingProfiles;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public ListTeamMemberBookingProfilesResponse Build()
            {
                return new ListTeamMemberBookingProfilesResponse(teamMemberBookingProfiles,
                    cursor,
                    errors);
            }
        }
    }
}