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
    public class ListTeamMemberWagesResponse 
    {
        public ListTeamMemberWagesResponse(IList<Models.TeamMemberWage> teamMemberWages = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            TeamMemberWages = teamMemberWages;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A page of Team Member Wage results.
        /// </summary>
        [JsonProperty("team_member_wages", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.TeamMemberWage> TeamMemberWages { get; }

        /// <summary>
        /// Value supplied in the subsequent request to fetch the next next page
        /// of Team Member Wage results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberWages(TeamMemberWages)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.TeamMemberWage> teamMemberWages;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder TeamMemberWages(IList<Models.TeamMemberWage> teamMemberWages)
            {
                this.teamMemberWages = teamMemberWages;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public ListTeamMemberWagesResponse Build()
            {
                return new ListTeamMemberWagesResponse(teamMemberWages,
                    cursor,
                    errors);
            }
        }
    }
}