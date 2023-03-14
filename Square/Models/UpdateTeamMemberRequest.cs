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
    /// UpdateTeamMemberRequest.
    /// </summary>
    public class UpdateTeamMemberRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTeamMemberRequest"/> class.
        /// </summary>
        /// <param name="teamMember">team_member.</param>
        public UpdateTeamMemberRequest(
            Models.TeamMember teamMember = null)
        {
            this.TeamMember = teamMember;
        }

        /// <summary>
        /// A record representing an individual team member for a business.
        /// </summary>
        [JsonProperty("team_member", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMember TeamMember { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateTeamMemberRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateTeamMemberRequest other &&
                ((this.TeamMember == null && other.TeamMember == null) || (this.TeamMember?.Equals(other.TeamMember) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1973028988;
            hashCode = HashCode.Combine(this.TeamMember);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TeamMember = {(this.TeamMember == null ? "null" : this.TeamMember.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMember(this.TeamMember);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.TeamMember teamMember;

             /// <summary>
             /// TeamMember.
             /// </summary>
             /// <param name="teamMember"> teamMember. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMember(Models.TeamMember teamMember)
            {
                this.teamMember = teamMember;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateTeamMemberRequest. </returns>
            public UpdateTeamMemberRequest Build()
            {
                return new UpdateTeamMemberRequest(
                    this.teamMember);
            }
        }
    }
}