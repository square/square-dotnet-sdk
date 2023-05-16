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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// ListTeamMemberBookingProfilesResponse.
    /// </summary>
    public class ListTeamMemberBookingProfilesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListTeamMemberBookingProfilesResponse"/> class.
        /// </summary>
        /// <param name="teamMemberBookingProfiles">team_member_booking_profiles.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public ListTeamMemberBookingProfilesResponse(
            IList<Models.TeamMemberBookingProfile> teamMemberBookingProfiles = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.TeamMemberBookingProfiles = teamMemberBookingProfiles;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The list of team member booking profiles. The results are returned in the ascending order of the time
        /// when the team member booking profiles were last updated. Multiple booking profiles updated at the same time
        /// are further sorted in the ascending order of their IDs.
        /// </summary>
        [JsonProperty("team_member_booking_profiles", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.TeamMemberBookingProfile> TeamMemberBookingProfiles { get; }

        /// <summary>
        /// The pagination cursor to be used in the subsequent request to get the next page of the results. Stop retrieving the next page of the results when the cursor is not set.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTeamMemberBookingProfilesResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListTeamMemberBookingProfilesResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.TeamMemberBookingProfiles == null && other.TeamMemberBookingProfiles == null) || (this.TeamMemberBookingProfiles?.Equals(other.TeamMemberBookingProfiles) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1456381957;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.TeamMemberBookingProfiles, this.Cursor, this.Errors);

            return hashCode;
        }
        internal ListTeamMemberBookingProfilesResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TeamMemberBookingProfiles = {(this.TeamMemberBookingProfiles == null ? "null" : $"[{string.Join(", ", this.TeamMemberBookingProfiles)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberBookingProfiles(this.TeamMemberBookingProfiles)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.TeamMemberBookingProfile> teamMemberBookingProfiles;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// TeamMemberBookingProfiles.
             /// </summary>
             /// <param name="teamMemberBookingProfiles"> teamMemberBookingProfiles. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberBookingProfiles(IList<Models.TeamMemberBookingProfile> teamMemberBookingProfiles)
            {
                this.teamMemberBookingProfiles = teamMemberBookingProfiles;
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
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListTeamMemberBookingProfilesResponse. </returns>
            public ListTeamMemberBookingProfilesResponse Build()
            {
                return new ListTeamMemberBookingProfilesResponse(
                    this.teamMemberBookingProfiles,
                    this.cursor,
                    this.errors);
            }
        }
    }
}