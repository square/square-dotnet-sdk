namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

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
            IDictionary<string, Models.CreateTeamMemberRequest> teamMembers)
        {
            this.TeamMembers = teamMembers;
        }

        /// <summary>
        /// The data used to create the `TeamMember` objects. Each key is the `idempotency_key` that maps to the `CreateTeamMemberRequest`.
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is BulkCreateTeamMembersRequest other &&
                ((this.TeamMembers == null && other.TeamMembers == null) || (this.TeamMembers?.Equals(other.TeamMembers) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1170567582;
            hashCode = HashCode.Combine(this.TeamMembers);

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
            private IDictionary<string, Models.CreateTeamMemberRequest> teamMembers;

            public Builder(
                IDictionary<string, Models.CreateTeamMemberRequest> teamMembers)
            {
                this.teamMembers = teamMembers;
            }

             /// <summary>
             /// TeamMembers.
             /// </summary>
             /// <param name="teamMembers"> teamMembers. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMembers(IDictionary<string, Models.CreateTeamMemberRequest> teamMembers)
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
                return new BulkCreateTeamMembersRequest(
                    this.teamMembers);
            }
        }
    }
}