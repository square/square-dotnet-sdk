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
    public class CreateTeamMemberResponse 
    {
        public CreateTeamMemberResponse(Models.TeamMember teamMember = null,
            IList<Models.Error> errors = null)
        {
            TeamMember = teamMember;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A record representing an individual team member for a business.
        /// </summary>
        [JsonProperty("team_member")]
        public Models.TeamMember TeamMember { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMember(TeamMember)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.TeamMember teamMember;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder TeamMember(Models.TeamMember value)
            {
                teamMember = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public CreateTeamMemberResponse Build()
            {
                return new CreateTeamMemberResponse(teamMember,
                    errors);
            }
        }
    }
}