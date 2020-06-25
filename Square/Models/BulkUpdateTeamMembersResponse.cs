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
        [JsonProperty("team_members")]
        public IDictionary<string, Models.UpdateTeamMemberResponse> TeamMembers { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMembers(TeamMembers)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IDictionary<string, Models.UpdateTeamMemberResponse> teamMembers = new Dictionary<string, Models.UpdateTeamMemberResponse>();
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder TeamMembers(IDictionary<string, Models.UpdateTeamMemberResponse> value)
            {
                teamMembers = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
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