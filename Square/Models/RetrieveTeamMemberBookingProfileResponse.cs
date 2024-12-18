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

namespace Square.Models
{
    /// <summary>
    /// RetrieveTeamMemberBookingProfileResponse.
    /// </summary>
    public class RetrieveTeamMemberBookingProfileResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveTeamMemberBookingProfileResponse"/> class.
        /// </summary>
        /// <param name="teamMemberBookingProfile">team_member_booking_profile.</param>
        /// <param name="errors">errors.</param>
        public RetrieveTeamMemberBookingProfileResponse(
            Models.TeamMemberBookingProfile teamMemberBookingProfile = null,
            IList<Models.Error> errors = null)
        {
            this.TeamMemberBookingProfile = teamMemberBookingProfile;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The booking profile of a seller's team member, including the team member's ID, display name, description and whether the team member can be booked as a service provider.
        /// </summary>
        [JsonProperty("team_member_booking_profile", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMemberBookingProfile TeamMemberBookingProfile { get; }

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
            return $"RetrieveTeamMemberBookingProfileResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RetrieveTeamMemberBookingProfileResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.TeamMemberBookingProfile == null && other.TeamMemberBookingProfile == null ||
                 this.TeamMemberBookingProfile?.Equals(other.TeamMemberBookingProfile) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1419029283;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.TeamMemberBookingProfile, this.Errors);

            return hashCode;
        }

        internal RetrieveTeamMemberBookingProfileResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.TeamMemberBookingProfile = {(this.TeamMemberBookingProfile == null ? "null" : this.TeamMemberBookingProfile.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberBookingProfile(this.TeamMemberBookingProfile)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.TeamMemberBookingProfile teamMemberBookingProfile;
            private IList<Models.Error> errors;

             /// <summary>
             /// TeamMemberBookingProfile.
             /// </summary>
             /// <param name="teamMemberBookingProfile"> teamMemberBookingProfile. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberBookingProfile(Models.TeamMemberBookingProfile teamMemberBookingProfile)
            {
                this.teamMemberBookingProfile = teamMemberBookingProfile;
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
            /// <returns> RetrieveTeamMemberBookingProfileResponse. </returns>
            public RetrieveTeamMemberBookingProfileResponse Build()
            {
                return new RetrieveTeamMemberBookingProfileResponse(
                    this.teamMemberBookingProfile,
                    this.errors);
            }
        }
    }
}