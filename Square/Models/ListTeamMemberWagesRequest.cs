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
    public class ListTeamMemberWagesRequest 
    {
        public ListTeamMemberWagesRequest(string teamMemberId = null,
            int? limit = null,
            string cursor = null)
        {
            TeamMemberId = teamMemberId;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Filter wages returned to only those that are associated with the
        /// specified team member.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// Maximum number of Team Member Wages to return per page. Can range between
        /// 1 and 200. The default is the maximum at 200.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Pointer to the next page of Employee Wage results to fetch.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberId(TeamMemberId)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string teamMemberId;
            private int? limit;
            private string cursor;



            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListTeamMemberWagesRequest Build()
            {
                return new ListTeamMemberWagesRequest(teamMemberId,
                    limit,
                    cursor);
            }
        }
    }
}