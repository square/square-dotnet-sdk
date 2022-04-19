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
    /// CreateTerminalRefundRequest.
    /// </summary>
    public class CreateTerminalRefundRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTerminalRefundRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="refund">refund.</param>
        public CreateTerminalRefundRequest(
            string idempotencyKey,
            Models.TerminalRefund refund = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Refund = refund;
        }

        /// <summary>
        /// A unique string that identifies this `CreateRefund` request. Keys can be any valid string but
        /// must be unique for every `CreateRefund` request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents a payment refund processed by the Square Terminal. Only supports Interac (Canadian debit network) payment refunds.
        /// </summary>
        [JsonProperty("refund", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TerminalRefund Refund { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateTerminalRefundRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateTerminalRefundRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Refund == null && other.Refund == null) || (this.Refund?.Equals(other.Refund) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -475578715;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.Refund);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.Refund = {(this.Refund == null ? "null" : this.Refund.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey)
                .Refund(this.Refund);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.TerminalRefund refund;

            public Builder(
                string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }

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
             /// Refund.
             /// </summary>
             /// <param name="refund"> refund. </param>
             /// <returns> Builder. </returns>
            public Builder Refund(Models.TerminalRefund refund)
            {
                this.refund = refund;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateTerminalRefundRequest. </returns>
            public CreateTerminalRefundRequest Build()
            {
                return new CreateTerminalRefundRequest(
                    this.idempotencyKey,
                    this.refund);
            }
        }
    }
}