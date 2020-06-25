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
        [JsonProperty("team_members")]
        public IList<Models.TeamMember> TeamMembers { get; }

        /// <summary>
        /// The opaque cursor for fetching the next page. Read about
        /// [pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination) with Square APIs for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
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
            private IList<Models.TeamMember> teamMembers = new List<Models.TeamMember>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder TeamMembers(IList<Models.TeamMember> value)
            {
                teamMembers = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
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