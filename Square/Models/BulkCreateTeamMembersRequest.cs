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
    public class BulkCreateTeamMembersRequest 
    {
        public BulkCreateTeamMembersRequest(IDictionary<string, Models.CreateTeamMemberRequest> teamMembers)
        {
            TeamMembers = teamMembers;
        }

        /// <summary>
        /// The data which will be used to create the `TeamMember` objects. Each key is the `idempotency_key` that maps to the `CreateTeamMemberRequest`.
        /// </summary>
        [JsonProperty("team_members")]
        public IDictionary<string, Models.CreateTeamMemberRequest> TeamMembers { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(TeamMembers);
            return builder;
        }

        public class Builder
        {
            private IDictionary<string, Models.CreateTeamMemberRequest> teamMembers;

            public Builder(IDictionary<string, Models.CreateTeamMemberRequest> teamMembers)
            {
                this.teamMembers = teamMembers;
            }
            public Builder TeamMembers(IDictionary<string, Models.CreateTeamMemberRequest> value)
            {
                teamMembers = value;
                return this;
            }

            public BulkCreateTeamMembersRequest Build()
            {
                return new BulkCreateTeamMembersRequest(teamMembers);
            }
        }
    }
}