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
        [JsonProperty("filter")]
        public Models.SearchTeamMembersFilter Filter { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(Filter);
            return builder;
        }

        public class Builder
        {
            private Models.SearchTeamMembersFilter filter;

            public Builder() { }
            public Builder Filter(Models.SearchTeamMembersFilter value)
            {
                filter = value;
                return this;
            }

            public SearchTeamMembersQuery Build()
            {
                return new SearchTeamMembersQuery(filter);
            }
        }
    }
}