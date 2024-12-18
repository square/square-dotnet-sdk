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
    /// BulkUpdateTeamMembersRequest.
    /// </summary>
    public class BulkUpdateTeamMembersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpdateTeamMembersRequest"/> class.
        /// </summary>
        /// <param name="teamMembers">team_members.</param>
        public BulkUpdateTeamMembersRequest(
            IDictionary<string, Models.UpdateTeamMemberRequest> teamMembers)
        {
            this.TeamMembers = teamMembers;
        }

        /// <summary>
        /// The data used to update the `TeamMember` objects. Each key is the `team_member_id` that maps to the `UpdateTeamMemberRequest`.
        /// The maximum number of update objects is 25.
        /// For each team member, include the fields to add, change, or clear. Fields can be cleared using a null value.
        /// To update `wage_setting.job_assignments`, you must provide the complete list of job assignments. If needed,
        /// call [ListJobs](api-endpoint:Team-ListJobs) to get the required `job_id` values.
        /// </summary>
        [JsonProperty("team_members")]
        public IDictionary<string, Models.UpdateTeamMemberRequest> TeamMembers { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkUpdateTeamMembersRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BulkUpdateTeamMembersRequest other &&
                (this.TeamMembers == null && other.TeamMembers == null ||
                 this.TeamMembers?.Equals(other.TeamMembers) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 676588886;
            hashCode = HashCode.Combine(hashCode, this.TeamMembers);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMembers = {(this.TeamMembers == null ? "null" : this.TeamMembers.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TeamMembers);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.UpdateTeamMemberRequest> teamMembers;

            /// <summary>
            /// Initialize Builder for BulkUpdateTeamMembersRequest.
            /// </summary>
            /// <param name="teamMembers"> teamMembers. </param>
            public Builder(
                IDictionary<string, Models.UpdateTeamMemberRequest> teamMembers)
            {
                this.teamMembers = teamMembers;
            }

             /// <summary>
             /// TeamMembers.
             /// </summary>
             /// <param name="teamMembers"> teamMembers. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMembers(IDictionary<string, Models.UpdateTeamMemberRequest> teamMembers)
            {
                this.teamMembers = teamMembers;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpdateTeamMembersRequest. </returns>
            public BulkUpdateTeamMembersRequest Build()
            {
                return new BulkUpdateTeamMembersRequest(
                    this.teamMembers);
            }
        }
    }
}