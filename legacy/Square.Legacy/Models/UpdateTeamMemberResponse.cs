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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// UpdateTeamMemberResponse.
    /// </summary>
    public class UpdateTeamMemberResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTeamMemberResponse"/> class.
        /// </summary>
        /// <param name="teamMember">team_member.</param>
        /// <param name="errors">errors.</param>
        public UpdateTeamMemberResponse(
            Models.TeamMember teamMember = null,
            IList<Models.Error> errors = null
        )
        {
            this.TeamMember = teamMember;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A record representing an individual team member for a business.
        /// </summary>
        [JsonProperty("team_member", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMember TeamMember { get; }

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
            return $"UpdateTeamMemberResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is UpdateTeamMemberResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.TeamMember == null && other.TeamMember == null
                    || this.TeamMember?.Equals(other.TeamMember) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1574093810;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.TeamMember, this.Errors);

            return hashCode;
        }

        internal UpdateTeamMemberResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.TeamMember = {(this.TeamMember == null ? "null" : this.TeamMember.ToString())}"
            );
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().TeamMember(this.TeamMember).Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.TeamMember teamMember;
            private IList<Models.Error> errors;

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
            /// <returns> UpdateTeamMemberResponse. </returns>
            public UpdateTeamMemberResponse Build()
            {
                return new UpdateTeamMemberResponse(this.teamMember, this.errors);
            }
        }
    }
}
