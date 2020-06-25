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
    public class TeamMemberAssignedLocations 
    {
        public TeamMemberAssignedLocations(string assignmentType = null,
            IList<string> locationIds = null)
        {
            AssignmentType = assignmentType;
            LocationIds = locationIds;
        }

        /// <summary>
        /// Enumerates the possible assignment types the team member can have
        /// </summary>
        [JsonProperty("assignment_type")]
        public string AssignmentType { get; }

        /// <summary>
        /// The locations that the team member is assigned to.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AssignmentType(AssignmentType)
                .LocationIds(LocationIds);
            return builder;
        }

        public class Builder
        {
            private string assignmentType;
            private IList<string> locationIds = new List<string>();

            public Builder() { }
            public Builder AssignmentType(string value)
            {
                assignmentType = value;
                return this;
            }

            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public TeamMemberAssignedLocations Build()
            {
                return new TeamMemberAssignedLocations(assignmentType,
                    locationIds);
            }
        }
    }
}