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
    public class SearchTeamMembersResponse 
    {
        public SearchTeamMembersResponse(IList<Models.TeamMember> teamMembers = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            TeamMembers = teamMembers;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The filtered list of `TeamMember` objects.
        /// </summary>
        [JsonProperty("team_members", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.TeamMember> TeamMembers { get; }

        /// <summary>
        /// The opaque cursor for fetching the next page. Read about
        /// [pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) with Square APIs for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMembers(TeamMembers)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.TeamMember> teamMembers;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder TeamMembers(IList<Models.TeamMember> teamMembers)
            {
                this.teamMembers = teamMembers;
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

            public SearchTeamMembersResponse Build()
            {
                return new SearchTeamMembersResponse(teamMembers,
                    cursor,
                    errors);
            }
        }
    }
}