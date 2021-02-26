
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TeamMemberAssignedLocations : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AssignmentType = {(AssignmentType == null ? "null" : AssignmentType.ToString())}");
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
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

            return obj is TeamMemberAssignedLocations other &&
                ((AssignmentType == null && other.AssignmentType == null) || (AssignmentType?.Equals(other.AssignmentType) == true)) &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1779620942;

            if (AssignmentType != null)
            {
               hashCode += AssignmentType.GetHashCode();
            }

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            return hashCode;
        }

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