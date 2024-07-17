namespace Square.Models
{
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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// BulkCreateTeamMembersResponse.
    /// </summary>
    public class BulkCreateTeamMembersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkCreateTeamMembersResponse"/> class.
        /// </summary>
        /// <param name="teamMembers">team_members.</param>
        /// <param name="errors">errors.</param>
        public BulkCreateTeamMembersResponse(
            IDictionary<string, Models.CreateTeamMemberResponse> teamMembers = null,
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
        /// The successfully created `TeamMember` objects. Each key is the `idempotency_key` that maps to the `CreateTeamMemberRequest`.
        /// </summary>
        [JsonProperty("team_members", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, Models.CreateTeamMemberResponse> TeamMembers { get; }

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

            return $"BulkCreateTeamMembersResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkCreateTeamMembersResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.TeamMembers == null && other.TeamMembers == null) || (this.TeamMembers?.Equals(other.TeamMembers) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 46225548;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.TeamMembers, this.Errors);

            return hashCode;
        }
        internal BulkCreateTeamMembersResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
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
            private IDictionary<string, Models.CreateTeamMemberResponse> teamMembers;
            private IList<Models.Error> errors;

             /// <summary>
             /// TeamMembers.
             /// </summary>
             /// <param name="teamMembers"> teamMembers. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMembers(IDictionary<string, Models.CreateTeamMemberResponse> teamMembers)
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
            /// <returns> BulkCreateTeamMembersResponse. </returns>
            public BulkCreateTeamMembersResponse Build()
            {
                return new BulkCreateTeamMembersResponse(
                    this.teamMembers,
                    this.errors);
            }
        }
    }
}