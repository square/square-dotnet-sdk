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
        [JsonProperty("assignment_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AssignmentType { get; }

        /// <summary>
        /// The locations that the team member is assigned to.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<string> locationIds;



            public Builder AssignmentType(string assignmentType)
            {
                this.assignmentType = assignmentType;
                return this;
            }

            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
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