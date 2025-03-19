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
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// DeprecatedCreateDisputeEvidenceFileResponse.
    /// </summary>
    public class DeprecatedCreateDisputeEvidenceFileResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeprecatedCreateDisputeEvidenceFileResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="evidence">evidence.</param>
        public DeprecatedCreateDisputeEvidenceFileResponse(
            IList<Models.Error> errors = null,
            Models.DisputeEvidence evidence = null
        )
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
            return $"DeprecatedCreateDisputeEvidenceFileResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is DeprecatedCreateDisputeEvidenceFileResponse other
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Evidence == null && other.Evidence == null
                    || this.Evidence?.Equals(other.Evidence) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 772059897;
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Evidence);

            return hashCode;
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
                $"this.Evidence = {(this.Evidence == null ? "null" : this.Evidence.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).Evidence(this.Evidence);
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
            /// <returns> DeprecatedCreateDisputeEvidenceFileResponse. </returns>
            public DeprecatedCreateDisputeEvidenceFileResponse Build()
            {
                return new DeprecatedCreateDisputeEvidenceFileResponse(this.errors, this.evidence);
            }
        }
    }
}
