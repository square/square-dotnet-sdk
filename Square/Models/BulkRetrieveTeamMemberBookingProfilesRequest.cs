using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// BulkRetrieveTeamMemberBookingProfilesRequest.
    /// </summary>
    public class BulkRetrieveTeamMemberBookingProfilesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkRetrieveTeamMemberBookingProfilesRequest"/> class.
        /// </summary>
        /// <param name="teamMemberIds">team_member_ids.</param>
        public BulkRetrieveTeamMemberBookingProfilesRequest(
            IList<string> teamMemberIds)
        {
            this.TeamMemberIds = teamMemberIds;
        }

        /// <summary>
        /// A non-empty list of IDs of team members whose booking profiles you want to retrieve.
        /// </summary>
        [JsonProperty("team_member_ids")]
        public IList<string> TeamMemberIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkRetrieveTeamMemberBookingProfilesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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
            return obj is BulkRetrieveTeamMemberBookingProfilesRequest other &&                ((this.TeamMemberIds == null && other.TeamMemberIds == null) || (this.TeamMemberIds?.Equals(other.TeamMemberIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1676686656;
            hashCode = HashCode.Combine(this.TeamMemberIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TeamMemberIds = {(this.TeamMemberIds == null ? "null" : $"[{string.Join(", ", this.TeamMemberIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TeamMemberIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> teamMemberIds;

            /// <summary>
            /// Initialize Builder for BulkRetrieveTeamMemberBookingProfilesRequest.
            /// </summary>
            /// <param name="teamMemberIds"> teamMemberIds. </param>
            public Builder(
                IList<string> teamMemberIds)
            {
                this.teamMemberIds = teamMemberIds;
            }

             /// <summary>
             /// TeamMemberIds.
             /// </summary>
             /// <param name="teamMemberIds"> teamMemberIds. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberIds(IList<string> teamMemberIds)
            {
                this.teamMemberIds = teamMemberIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkRetrieveTeamMemberBookingProfilesRequest. </returns>
            public BulkRetrieveTeamMemberBookingProfilesRequest Build()
            {
                return new BulkRetrieveTeamMemberBookingProfilesRequest(
                    this.teamMemberIds);
            }
        }
    }
}