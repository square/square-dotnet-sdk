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