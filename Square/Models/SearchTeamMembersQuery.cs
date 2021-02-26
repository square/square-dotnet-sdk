
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
    public class SearchTeamMembersQuery 
    {
        public SearchTeamMembersQuery(Models.SearchTeamMembersFilter filter = null)
        {
            Filter = filter;
        }

        /// <summary>
        /// Represents a filter used in a search for `TeamMember` objects. `AND` logic is applied
        /// between the individual fields, and `OR` logic is applied within list-based fields.
        /// For example, setting this filter value,
        /// ```
        /// filter = (locations_ids = ["A", "B"], status = ACTIVE)
        /// ```
        /// returns only active team members assigned to either location "A" or "B".
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchTeamMembersFilter Filter { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchTeamMembersQuery : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Filter = {(Filter == null ? "null" : Filter.ToString())}");
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

            return obj is SearchTeamMembersQuery other &&
                ((Filter == null && other.Filter == null) || (Filter?.Equals(other.Filter) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1472876926;

            if (Filter != null)
            {
               hashCode += Filter.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter);
            return builder;
        }

        public class Builder
        {
            private Models.SearchTeamMembersFilter filter;



            public Builder Filter(Models.SearchTeamMembersFilter filter)
            {
                this.filter = filter;
                return this;
            }

            public SearchTeamMembersQuery Build()
            {
                return new SearchTeamMembersQuery(filter);
            }
        }
    }
}