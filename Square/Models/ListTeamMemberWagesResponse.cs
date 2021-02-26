
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTeamMemberWagesResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMemberWages = {(TeamMemberWages == null ? "null" : $"[{ string.Join(", ", TeamMemberWages)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
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

            return obj is ListTeamMemberWagesResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((TeamMemberWages == null && other.TeamMemberWages == null) || (TeamMemberWages?.Equals(other.TeamMemberWages) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1794576862;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (TeamMemberWages != null)
            {
               hashCode += TeamMemberWages.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
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