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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// BulkCreateTeamMembersRequest.
    /// </summary>
    public class BulkCreateTeamMembersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkCreateTeamMembersRequest"/> class.
        /// </summary>
        /// <param name="teamMembers">team_members.</param>
        public BulkCreateTeamMembersRequest(
            IDictionary<string, Models.CreateTeamMemberRequest> teamMembers
        )
        {
            this.TeamMembers = teamMembers;
        }

        /// <summary>
        /// The data used to create the `TeamMember` objects. Each key is the `idempotency_key` that maps to the `CreateTeamMemberRequest`.
        /// The maximum number of create objects is 25.
        /// If you include a team member's `wage_setting`, you must provide `job_id` for each job assignment. To get job IDs,
        /// call [ListJobs](api-endpoint:Team-ListJobs).
        /// </summary>
        [JsonProperty("team_members")]
        public IDictionary<string, Models.CreateTeamMemberRequest> TeamMembers { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkCreateTeamMembersRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkCreateTeamMembersRequest other
                && (
                    this.TeamMembers == null && other.TeamMembers == null
                    || this.TeamMembers?.Equals(other.TeamMembers) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1170567582;
            hashCode = HashCode.Combine(hashCode, this.TeamMembers);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"TeamMembers = {(this.TeamMembers == null ? "null" : this.TeamMembers.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.TeamMembers);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.CreateTeamMemberRequest> teamMembers;

            /// <summary>
            /// Initialize Builder for BulkCreateTeamMembersRequest.
            /// </summary>
            /// <param name="teamMembers"> teamMembers. </param>
            public Builder(IDictionary<string, Models.CreateTeamMemberRequest> teamMembers)
            {
                this.teamMembers = teamMembers;
            }

            /// <summary>
            /// TeamMembers.
            /// </summary>
            /// <param name="teamMembers"> teamMembers. </param>
            /// <returns> Builder. </returns>
            public Builder TeamMembers(
                IDictionary<string, Models.CreateTeamMemberRequest> teamMembers
            )
            {
                this.teamMembers = teamMembers;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkCreateTeamMembersRequest. </returns>
            public BulkCreateTeamMembersRequest Build()
            {
                return new BulkCreateTeamMembersRequest(this.teamMembers);
            }
        }
    }
}
