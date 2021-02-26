
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
    public class GetTeamMemberWageResponse 
    {
        public GetTeamMemberWageResponse(Models.TeamMemberWage teamMemberWage = null,
            IList<Models.Error> errors = null)
        {
            TeamMemberWage = teamMemberWage;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The hourly wage rate that a team member will earn on a `Shift` for doing the job
        /// specified by the `title` property of this object.
        /// </summary>
        [JsonProperty("team_member_wage", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMemberWage TeamMemberWage { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetTeamMemberWageResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMemberWage = {(TeamMemberWage == null ? "null" : TeamMemberWage.ToString())}");
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

            return obj is GetTeamMemberWageResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((TeamMemberWage == null && other.TeamMemberWage == null) || (TeamMemberWage?.Equals(other.TeamMemberWage) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -612007804;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (TeamMemberWage != null)
            {
               hashCode += TeamMemberWage.GetHashCode();
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
                .TeamMemberWage(TeamMemberWage)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.TeamMemberWage teamMemberWage;
            private IList<Models.Error> errors;



            public Builder TeamMemberWage(Models.TeamMemberWage teamMemberWage)
            {
                this.teamMemberWage = teamMemberWage;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public GetTeamMemberWageResponse Build()
            {
                return new GetTeamMemberWageResponse(teamMemberWage,
                    errors);
            }
        }
    }
}