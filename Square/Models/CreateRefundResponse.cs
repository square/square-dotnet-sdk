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
    /// CreateRefundResponse.
    /// </summary>
    public class CreateRefundResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRefundResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="refund">refund.</param>
        public CreateRefundResponse(
            IList<Models.Error> errors = null,
            Models.Refund refund = null)
        {
            this.Errors = errors;
            this.Refund = refund;
        }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a refund processed for a Square transaction.
        /// </summary>
        [JsonProperty("refund", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Refund Refund { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateRefundResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateRefundResponse other &&                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Refund == null && other.Refund == null) || (this.Refund?.Equals(other.Refund) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1017134499;
            hashCode = HashCode.Combine(this.Errors, this.Refund);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Refund = {(this.Refund == null ? "null" : this.Refund.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Refund(this.Refund);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Refund refund;

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
             /// Refund.
             /// </summary>
             /// <param name="refund"> refund. </param>
             /// <returns> Builder. </returns>
            public Builder Refund(Models.Refund refund)
            {
                this.refund = refund;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateRefundResponse. </returns>
            public CreateRefundResponse Build()
            {
                return new CreateRefundResponse(
                    this.errors,
                    this.refund);
            }
        }
    }
}