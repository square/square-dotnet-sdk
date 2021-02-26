
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
    public class CreateTeamMemberResponse 
    {
        public CreateTeamMemberResponse(Models.TeamMember teamMember = null,
            IList<Models.Error> errors = null)
        {
            TeamMember = teamMember;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A record representing an individual team member for a business.
        /// </summary>
        [JsonProperty("team_member", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMember TeamMember { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateTeamMemberResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMember = {(TeamMember == null ? "null" : TeamMember.ToString())}");
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

            return obj is CreateTeamMemberResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((TeamMember == null && other.TeamMember == null) || (TeamMember?.Equals(other.TeamMember) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1401221559;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (TeamMember != null)
            {
               hashCode += TeamMember.GetHashCode();
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
                .TeamMember(TeamMember)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.TeamMember teamMember;
            private IList<Models.Error> errors;



            public Builder TeamMember(Models.TeamMember teamMember)
            {
                this.teamMember = teamMember;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public CreateTeamMemberResponse Build()
            {
                return new CreateTeamMemberResponse(teamMember,
                    errors);
            }
        }
    }
}