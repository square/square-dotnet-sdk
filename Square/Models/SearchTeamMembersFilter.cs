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
    public class SearchTeamMembersFilter 
    {
        public SearchTeamMembersFilter(IList<string> locationIds = null,
            string status = null)
        {
            LocationIds = locationIds;
            Status = status;
        }

        /// <summary>
        /// When present, filter by team members assigned to the specified locations.
        /// When empty, include team members assigned to any location.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// Enumerates the possible statuses the team member can have within a business.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationIds(LocationIds)
                .Status(Status);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds = new List<string>();
            private string status;

            public Builder() { }
            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public SearchTeamMembersFilter Build()
            {
                return new SearchTeamMembersFilter(locationIds,
                    status);
            }
        }
    }
}