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
    /// DeprecatedCreateDisputeEvidenceTextResponse.
    /// </summary>
    public class DeprecatedCreateDisputeEvidenceTextResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeprecatedCreateDisputeEvidenceTextResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="evidence">evidence.</param>
        public DeprecatedCreateDisputeEvidenceTextResponse(
            IList<Models.Error> errors = null,
            Models.DisputeEvidence evidence = null)
        {
            this.Errors = errors;
            this.Evidence = evidence;
        }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Gets or sets Evidence.
        /// </summary>
        [JsonProperty("evidence", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DisputeEvidence Evidence { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeprecatedCreateDisputeEvidenceTextResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeprecatedCreateDisputeEvidenceTextResponse other &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Evidence == null && other.Evidence == null) || (this.Evidence?.Equals(other.Evidence) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1286420372;
            hashCode = HashCode.Combine(this.Errors, this.Evidence);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Evidence = {(this.Evidence == null ? "null" : this.Evidence.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Evidence(this.Evidence);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.DisputeEvidence evidence;

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
             /// Evidence.
             /// </summary>
             /// <param name="evidence"> evidence. </param>
             /// <returns> Builder. </returns>
            public Builder Evidence(Models.DisputeEvidence evidence)
            {
                this.evidence = evidence;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeprecatedCreateDisputeEvidenceTextResponse. </returns>
            public DeprecatedCreateDisputeEvidenceTextResponse Build()
            {
                return new DeprecatedCreateDisputeEvidenceTextResponse(
                    this.errors,
                    this.evidence);
            }
        }
    }
}