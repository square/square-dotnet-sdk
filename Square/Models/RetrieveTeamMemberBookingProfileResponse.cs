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
    public class RetrieveTeamMemberBookingProfileResponse 
    {
        public RetrieveTeamMemberBookingProfileResponse(Models.TeamMemberBookingProfile teamMemberBookingProfile = null,
            IList<Models.Error> errors = null)
        {
            TeamMemberBookingProfile = teamMemberBookingProfile;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The booking profile of a seller's team member, including the team member's ID, display name, description and whether the team member can be booked as a service provider.
        /// </summary>
        [JsonProperty("team_member_booking_profile", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMemberBookingProfile TeamMemberBookingProfile { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberBookingProfile(TeamMemberBookingProfile)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.TeamMemberBookingProfile teamMemberBookingProfile;
            private IList<Models.Error> errors;



            public Builder TeamMemberBookingProfile(Models.TeamMemberBookingProfile teamMemberBookingProfile)
            {
                this.teamMemberBookingProfile = teamMemberBookingProfile;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public RetrieveTeamMemberBookingProfileResponse Build()
            {
                return new RetrieveTeamMemberBookingProfileResponse(teamMemberBookingProfile,
                    errors);
            }
        }
    }
}