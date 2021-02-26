
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
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// A record representing an individual team member for a business.
        /// </summary>
        [JsonProperty("team_member", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMember TeamMember { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateTeamMemberRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
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

            return obj is CreateTeamMemberRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((TeamMember == null && other.TeamMember == null) || (TeamMember?.Equals(other.TeamMember) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1352322993;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (TeamMember != null)
            {
               hashCode += TeamMember.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder TeamMember(Models.TeamMember teamMember)
            {
                this.teamMember = teamMember;
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