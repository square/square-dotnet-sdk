
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
    public class BulkUpdateTeamMembersResponse 
    {
        public BulkUpdateTeamMembersResponse(IDictionary<string, Models.UpdateTeamMemberResponse> teamMembers = null,
            IList<Models.Error> errors = null)
        {
            TeamMembers = teamMembers;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The successfully updated `TeamMember` objects. Each key is the `team_member_id` that maps to the `UpdateTeamMemberRequest`.
        /// </summary>
        [JsonProperty("team_members", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, Models.UpdateTeamMemberResponse> TeamMembers { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpdateTeamMembersResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMembers = {(TeamMembers == null ? "null" : TeamMembers.ToString())}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is BulkUpdateTeamMembersResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((TeamMembers == null && other.TeamMembers == null) || (TeamMembers?.Equals(other.TeamMembers) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -740800268;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (TeamMembers != null)
            {
               hashCode += TeamMembers.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMembers(TeamMembers)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IDictionary<string, Models.UpdateTeamMemberResponse> teamMembers;
            private IList<Models.Error> errors;



            public Builder TeamMembers(IDictionary<string, Models.UpdateTeamMemberResponse> teamMembers)
            {
                this.teamMembers = teamMembers;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public BulkUpdateTeamMembersResponse Build()
            {
                return new BulkUpdateTeamMembersResponse(teamMembers,
                    errors);
            }
        }
    }
}