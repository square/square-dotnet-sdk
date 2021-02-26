
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTeamMemberBookingProfilesResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMemberBookingProfiles = {(TeamMemberBookingProfiles == null ? "null" : $"[{ string.Join(", ", TeamMemberBookingProfiles)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is ListTeamMemberBookingProfilesResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((TeamMemberBookingProfiles == null && other.TeamMemberBookingProfiles == null) || (TeamMemberBookingProfiles?.Equals(other.TeamMemberBookingProfiles) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1456381957;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (TeamMemberBookingProfiles != null)
            {
               hashCode += TeamMemberBookingProfiles.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

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