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
    /// ListLoyaltyProgramsResponse.
    /// </summary>
    public class ListLoyaltyProgramsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListLoyaltyProgramsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="programs">programs.</param>
        public ListLoyaltyProgramsResponse(
            IList<Models.Error> errors = null,
            IList<Models.LoyaltyProgram> programs = null
        )
        {
            this.Errors = errors;
            this.Programs = programs;
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
        /// A list of `LoyaltyProgram` for the merchant.
        /// </summary>
        [JsonProperty("programs", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.LoyaltyProgram> Programs { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListLoyaltyProgramsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListLoyaltyProgramsResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Programs == null && other.Programs == null
                    || this.Programs?.Equals(other.Programs) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1778675748;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Programs);

            return hashCode;
        }

        internal ListLoyaltyProgramsResponse ContextSetter(HttpContext context)
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
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Programs = {(this.Programs == null ? "null" : $"[{string.Join(", ", this.Programs)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).Programs(this.Programs);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.LoyaltyProgram> programs;

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
            /// Programs.
            /// </summary>
            /// <param name="programs"> programs. </param>
            /// <returns> Builder. </returns>
            public Builder Programs(IList<Models.LoyaltyProgram> programs)
            {
                this.programs = programs;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListLoyaltyProgramsResponse. </returns>
            public ListLoyaltyProgramsResponse Build()
            {
                return new ListLoyaltyProgramsResponse(this.errors, this.programs);
            }
        }
    }
}
