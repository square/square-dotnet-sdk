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
    public class CreateTeamMemberRequest 
    {
        public CreateTeamMemberRequest(string idempotencyKey = null,
            Models.TeamMember teamMember = null)
        {
            IdempotencyKey = idempotencyKey;
            TeamMember = teamMember;
        }

        /// <summary>
        /// A unique string that identifies this CreateTeamMember request.
        /// Keys can be any valid string but must be unique for every request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// <br>
        /// <b>Min Length 1    Max Length 45</b>
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A record representing an individual team member for a business.
        /// </summary>
        [JsonProperty("team_member")]
        public Models.TeamMember TeamMember { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(IdempotencyKey)
                .TeamMember(TeamMember);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private Models.TeamMember teamMember;

            public Builder() { }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder TeamMember(Models.TeamMember value)
            {
                teamMember = value;
                return this;
            }

            public CreateTeamMemberRequest Build()
            {
                return new CreateTeamMemberRequest(idempotencyKey,
                    teamMember);
            }
        }
    }
}