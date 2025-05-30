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
    /// CancelPaymentResponse.
    /// </summary>
    public class CancelPaymentResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelPaymentResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="payment">payment.</param>
        public CancelPaymentResponse(
            IList<Models.Error> errors = null,
            Models.Payment payment = null
        )
        {
            this.Errors = errors;
            this.Payment = payment;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a payment processed by the Square API.
        /// </summary>
        [JsonProperty("payment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Payment Payment { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CancelPaymentResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CancelPaymentResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Payment == null && other.Payment == null
                    || this.Payment?.Equals(other.Payment) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1901260067;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Payment);

            return hashCode;
        }

        internal CancelPaymentResponse ContextSetter(HttpContext context)
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
                $"this.Payment = {(this.Payment == null ? "null" : this.Payment.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).Payment(this.Payment);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Payment payment;

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
            /// Payment.
            /// </summary>
            /// <param name="payment"> payment. </param>
            /// <returns> Builder. </returns>
            public Builder Payment(Models.Payment payment)
            {
                this.payment = payment;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CancelPaymentResponse. </returns>
            public CancelPaymentResponse Build()
            {
                return new CancelPaymentResponse(this.errors, this.payment);
            }
        }
    }
}
