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
    /// CreateTeamMemberRequest.
    /// </summary>
    public class CreateTeamMemberRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTeamMemberRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="teamMember">team_member.</param>
        public CreateTeamMemberRequest(
            string idempotencyKey = null,
            Models.TeamMember teamMember = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.TeamMember = teamMember;
        }

        /// <summary>
        /// A unique string that identifies this `CreateTeamMember` request.
        /// Keys can be any valid string, but must be unique for every request.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency).
        /// The minimum length is 1 and the maximum length is 45.
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

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

            return $"CreateTeamMemberRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateTeamMemberRequest other &&                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.TeamMember == null && other.TeamMember == null) || (this.TeamMember?.Equals(other.TeamMember) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1352322993;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.TeamMember);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.TeamMember = {(this.TeamMember == null ? "null" : this.TeamMember.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .IdempotencyKey(this.IdempotencyKey)
                .TeamMember(this.TeamMember);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.TeamMember teamMember;

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

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
            /// <returns> CreateTeamMemberRequest. </returns>
            public CreateTeamMemberRequest Build()
            {
                return new CreateTeamMemberRequest(
                    this.idempotencyKey,
                    this.teamMember);
            }
        }
    }
}