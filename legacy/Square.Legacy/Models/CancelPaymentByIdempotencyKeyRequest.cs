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
    /// CancelPaymentByIdempotencyKeyRequest.
    /// </summary>
    public class CancelPaymentByIdempotencyKeyRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelPaymentByIdempotencyKeyRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CancelPaymentByIdempotencyKeyRequest(string idempotencyKey)
        {
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// The `idempotency_key` identifying the payment to be canceled.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CancelPaymentByIdempotencyKeyRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CancelPaymentByIdempotencyKeyRequest other
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1646474822;
            hashCode = HashCode.Combine(hashCode, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CancelPaymentByIdempotencyKeyRequest.
            /// </summary>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            public Builder(string idempotencyKey)
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
            /// Builds class object.
            /// </summary>
            /// <returns> CancelPaymentByIdempotencyKeyRequest. </returns>
            public CancelPaymentByIdempotencyKeyRequest Build()
            {
                return new CancelPaymentByIdempotencyKeyRequest(this.idempotencyKey);
            }
        }
    }
}
