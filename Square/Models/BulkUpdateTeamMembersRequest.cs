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
    public class BulkUpdateTeamMembersRequest 
    {
        public BulkUpdateTeamMembersRequest(IDictionary<string, Models.UpdateTeamMemberRequest> teamMembers)
        {
            TeamMembers = teamMembers;
        }

        /// <summary>
        /// The data which will be used to update the `TeamMember` objects. Each key is the `team_member_id` that maps to the `UpdateTeamMemberRequest`.
        /// </summary>
        [JsonProperty("team_members")]
        public IDictionary<string, Models.UpdateTeamMemberRequest> TeamMembers { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(TeamMembers);
            return builder;
        }

        public class Builder
        {
            private IDictionary<string, Models.UpdateTeamMemberRequest> teamMembers;

            public Builder(IDictionary<string, Models.UpdateTeamMemberRequest> teamMembers)
            {
                this.teamMembers = teamMembers;
            }
            public Builder TeamMembers(IDictionary<string, Models.UpdateTeamMemberRequest> value)
            {
                teamMembers = value;
                return this;
            }

            public BulkUpdateTeamMembersRequest Build()
            {
                return new BulkUpdateTeamMembersRequest(teamMembers);
            }
        }
    }
}