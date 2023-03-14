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
    /// CreateBreakTypeResponse.
    /// </summary>
    public class CreateBreakTypeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBreakTypeResponse"/> class.
        /// </summary>
        /// <param name="breakType">break_type.</param>
        /// <param name="errors">errors.</param>
        public CreateBreakTypeResponse(
            Models.BreakType breakType = null,
            IList<Models.Error> errors = null)
        {
            this.BreakType = breakType;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A defined break template that sets an expectation for possible `Break`
        /// instances on a `Shift`.
        /// </summary>
        [JsonProperty("break_type", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BreakType BreakType { get; }

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

            return $"CreateBreakTypeResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateBreakTypeResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.BreakType == null && other.BreakType == null) || (this.BreakType?.Equals(other.BreakType) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 819753957;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.BreakType, this.Errors);

            return hashCode;
        }
        internal CreateBreakTypeResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.BreakType = {(this.BreakType == null ? "null" : this.BreakType.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BreakType(this.BreakType)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.BreakType breakType;
            private IList<Models.Error> errors;

             /// <summary>
             /// BreakType.
             /// </summary>
             /// <param name="breakType"> breakType. </param>
             /// <returns> Builder. </returns>
            public Builder BreakType(Models.BreakType breakType)
            {
                this.breakType = breakType;
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
            /// <returns> CreateBreakTypeResponse. </returns>
            public CreateBreakTypeResponse Build()
            {
                return new CreateBreakTypeResponse(
                    this.breakType,
                    this.errors);
            }
        }
    }
}