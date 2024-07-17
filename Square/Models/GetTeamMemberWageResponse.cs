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
    /// GetTeamMemberWageResponse.
    /// </summary>
    public class GetTeamMemberWageResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTeamMemberWageResponse"/> class.
        /// </summary>
        /// <param name="teamMemberWage">team_member_wage.</param>
        /// <param name="errors">errors.</param>
        public GetTeamMemberWageResponse(
            Models.TeamMemberWage teamMemberWage = null,
            IList<Models.Error> errors = null)
        {
            this.TeamMemberWage = teamMemberWage;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The hourly wage rate that a team member earns on a `Shift` for doing the job
        /// specified by the `title` property of this object.
        /// </summary>
        [JsonProperty("team_member_wage", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TeamMemberWage TeamMemberWage { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetTeamMemberWageResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is GetTeamMemberWageResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.TeamMemberWage == null && other.TeamMemberWage == null) || (this.TeamMemberWage?.Equals(other.TeamMemberWage) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -612007804;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.TeamMemberWage, this.Errors);

            return hashCode;
        }
        internal GetTeamMemberWageResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.TeamMemberWage = {(this.TeamMemberWage == null ? "null" : this.TeamMemberWage.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .TeamMemberWage(this.TeamMemberWage)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.TeamMemberWage teamMemberWage;
            private IList<Models.Error> errors;

             /// <summary>
             /// TeamMemberWage.
             /// </summary>
             /// <param name="teamMemberWage"> teamMemberWage. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberWage(Models.TeamMemberWage teamMemberWage)
            {
                this.teamMemberWage = teamMemberWage;
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
            /// <returns> GetTeamMemberWageResponse. </returns>
            public GetTeamMemberWageResponse Build()
            {
                return new GetTeamMemberWageResponse(
                    this.teamMemberWage,
                    this.errors);
            }
        }
    }
}