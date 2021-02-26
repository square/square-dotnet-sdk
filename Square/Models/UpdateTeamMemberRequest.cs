
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
        [JsonProperty("team_member", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMember TeamMember { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateTeamMemberRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMember = {(TeamMember == null ? "null" : TeamMember.ToString())}");
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

            return obj is UpdateTeamMemberRequest other &&
                ((TeamMember == null && other.TeamMember == null) || (TeamMember?.Equals(other.TeamMember) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1973028988;

            if (TeamMember != null)
            {
               hashCode += TeamMember.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMember(TeamMember);
            return builder;
        }

        public class Builder
        {
            private Models.TeamMember teamMember;



            public Builder TeamMember(Models.TeamMember teamMember)
            {
                this.teamMember = teamMember;
                return this;
            }

            public UpdateTeamMemberRequest Build()
            {
                return new UpdateTeamMemberRequest(teamMember);
            }
        }
    }
}