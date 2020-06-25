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
    public class BulkCreateTeamMembersResponse 
    {
        public BulkCreateTeamMembersResponse(IDictionary<string, Models.CreateTeamMemberResponse> teamMembers = null,
            IList<Models.Error> errors = null)
        {
            TeamMembers = teamMembers;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The successfully created `TeamMember` objects. Each key is the `idempotency_key` that maps to the `CreateTeamMemberRequest`.
        /// </summary>
        [JsonProperty("team_members")]
        public IDictionary<string, Models.CreateTeamMemberResponse> TeamMembers { get; }

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
            private IDictionary<string, Models.CreateTeamMemberResponse> teamMembers = new Dictionary<string, Models.CreateTeamMemberResponse>();
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder TeamMembers(IDictionary<string, Models.CreateTeamMemberResponse> value)
            {
                teamMembers = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public BulkCreateTeamMembersResponse Build()
            {
                return new BulkCreateTeamMembersResponse(teamMembers,
                    errors);
            }
        }
    }
}