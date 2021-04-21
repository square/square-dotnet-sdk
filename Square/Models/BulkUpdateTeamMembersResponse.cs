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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// BulkUpdateTeamMembersResponse.
    /// </summary>
    public class BulkUpdateTeamMembersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpdateTeamMembersResponse"/> class.
        /// </summary>
        /// <param name="teamMembers">team_members.</param>
        /// <param name="errors">errors.</param>
        public BulkUpdateTeamMembersResponse(
            IDictionary<string, Models.UpdateTeamMemberResponse> teamMembers = null,
            IList<Models.Error> errors = null)
        {
            this.TeamMembers = teamMembers;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The successfully updated `TeamMember` objects. Each key is the `team_member_id` that maps to the `UpdateTeamMemberRequest`.
        /// </summary>
        [JsonProperty("team_members", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, Models.UpdateTeamMemberResponse> TeamMembers { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpdateTeamMembersResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is BulkUpdateTeamMembersResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.TeamMembers == null && other.TeamMembers == null) || (this.TeamMembers?.Equals(other.TeamMembers) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -740800268;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.TeamMembers != null)
            {
               hashCode += this.TeamMembers.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"TeamMembers = {(this.TeamMembers == null ? "null" : this.TeamMembers.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMembers(this.TeamMembers)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.UpdateTeamMemberResponse> teamMembers;
            private IList<Models.Error> errors;

             /// <summary>
             /// TeamMembers.
             /// </summary>
             /// <param name="teamMembers"> teamMembers. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMembers(IDictionary<string, Models.UpdateTeamMemberResponse> teamMembers)
            {
                this.teamMembers = teamMembers;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpdateTeamMembersResponse. </returns>
            public BulkUpdateTeamMembersResponse Build()
            {
                return new BulkUpdateTeamMembersResponse(
                    this.teamMembers,
                    this.errors);
            }
        }
    }
}