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
    /// RetrieveLoyaltyProgramResponse.
    /// </summary>
    public class RetrieveLoyaltyProgramResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveLoyaltyProgramResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="program">program.</param>
        public RetrieveLoyaltyProgramResponse(
            IList<Models.Error> errors = null,
            Models.LoyaltyProgram program = null)
        {
            this.Errors = errors;
            this.Program = program;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a Square loyalty program. Loyalty programs define how buyers can earn points and redeem points for rewards.
        /// Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard.
        /// For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// </summary>
        [JsonProperty("program", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyProgram Program { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveLoyaltyProgramResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is RetrieveLoyaltyProgramResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Program == null && other.Program == null) || (this.Program?.Equals(other.Program) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1841244463;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Program);

            return hashCode;
        }
        internal RetrieveLoyaltyProgramResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Program = {(this.Program == null ? "null" : this.Program.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Program(this.Program);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyProgram program;

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
             /// Program.
             /// </summary>
             /// <param name="program"> program. </param>
             /// <returns> Builder. </returns>
            public Builder Program(Models.LoyaltyProgram program)
            {
                this.program = program;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveLoyaltyProgramResponse. </returns>
            public RetrieveLoyaltyProgramResponse Build()
            {
                return new RetrieveLoyaltyProgramResponse(
                    this.errors,
                    this.program);
            }
        }
    }
}