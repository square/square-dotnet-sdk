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
    public class UpdateTeamMemberRequest 
    {
        public UpdateTeamMemberRequest(Models.TeamMember teamMember = null)
        {
            TeamMember = teamMember;
        }

        /// <summary>
        /// A record representing an individual team member for a business.
        /// </summary>
        [JsonProperty("team_member")]
        public Models.TeamMember TeamMember { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMember(TeamMember);
            return builder;
        }

        public class Builder
        {
            private Models.TeamMember teamMember;

            public Builder() { }
            public Builder TeamMember(Models.TeamMember value)
            {
                teamMember = value;
                return this;
            }

            public UpdateTeamMemberRequest Build()
            {
                return new UpdateTeamMemberRequest(teamMember);
            }
        }
    }
}