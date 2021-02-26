
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkCreateTeamMembersRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMembers = {(TeamMembers == null ? "null" : TeamMembers.ToString())}");
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

            return obj is BulkCreateTeamMembersRequest other &&
                ((TeamMembers == null && other.TeamMembers == null) || (TeamMembers?.Equals(other.TeamMembers) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1170567582;

            if (TeamMembers != null)
            {
               hashCode += TeamMembers.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder TeamMembers(IDictionary<string, Models.CreateTeamMemberRequest> teamMembers)
            {
                this.teamMembers = teamMembers;
                return this;
            }

            public BulkCreateTeamMembersRequest Build()
            {
                return new BulkCreateTeamMembersRequest(teamMembers);
            }
        }
    }
}