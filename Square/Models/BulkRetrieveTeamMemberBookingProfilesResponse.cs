namespace Square.Models
{
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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// BulkRetrieveTeamMemberBookingProfilesResponse.
    /// </summary>
    public class BulkRetrieveTeamMemberBookingProfilesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkRetrieveTeamMemberBookingProfilesResponse"/> class.
        /// </summary>
        /// <param name="teamMemberBookingProfiles">team_member_booking_profiles.</param>
        /// <param name="errors">errors.</param>
        public BulkRetrieveTeamMemberBookingProfilesResponse(
            IDictionary<string, Models.RetrieveTeamMemberBookingProfileResponse> teamMemberBookingProfiles = null,
            IList<Models.Error> errors = null)
        {
            this.TeamMemberBookingProfiles = teamMemberBookingProfiles;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The returned team members' booking profiles, as a map with `team_member_id` as the key and [TeamMemberBookingProfile](entity:TeamMemberBookingProfile) the value.
        /// </summary>
        [JsonProperty("team_member_booking_profiles", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, Models.RetrieveTeamMemberBookingProfileResponse> TeamMemberBookingProfiles { get; }

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

            return $"BulkRetrieveTeamMemberBookingProfilesResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkRetrieveTeamMemberBookingProfilesResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.TeamMemberBookingProfiles == null && other.TeamMemberBookingProfiles == null) || (this.TeamMemberBookingProfiles?.Equals(other.TeamMemberBookingProfiles) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1134560618;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.TeamMemberBookingProfiles, this.Errors);

            return hashCode;
        }
        internal BulkRetrieveTeamMemberBookingProfilesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"TeamMemberBookingProfiles = {(this.TeamMemberBookingProfiles == null ? "null" : this.TeamMemberBookingProfiles.ToString())}");
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
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.RetrieveTeamMemberBookingProfileResponse> teamMemberBookingProfiles;
            private IList<Models.Error> errors;

             /// <summary>
             /// TeamMemberBookingProfiles.
             /// </summary>
             /// <param name="teamMemberBookingProfiles"> teamMemberBookingProfiles. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberBookingProfiles(IDictionary<string, Models.RetrieveTeamMemberBookingProfileResponse> teamMemberBookingProfiles)
            {
                this.teamMemberBookingProfiles = teamMemberBookingProfiles;
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
            /// <returns> BulkRetrieveTeamMemberBookingProfilesResponse. </returns>
            public BulkRetrieveTeamMemberBookingProfilesResponse Build()
            {
                return new BulkRetrieveTeamMemberBookingProfilesResponse(
                    this.teamMemberBookingProfiles,
                    this.errors);
            }
        }
    }
}