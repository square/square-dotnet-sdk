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
    /// CreateInvoiceRequest.
    /// </summary>
    public class CreateInvoiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoiceRequest"/> class.
        /// </summary>
        /// <param name="invoice">invoice.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateInvoiceRequest(Models.Invoice invoice, string idempotencyKey = null)
        {
            this.Invoice = invoice;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Stores information about an invoice. You use the Invoices API to create and manage
        /// invoices. For more information, see [Invoices API Overview](https://developer.squareup.com/docs/invoices-api/overview).
        /// </summary>
        [JsonProperty("invoice")]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// A unique string that identifies the `CreateInvoice` request. If you do not
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateInvoiceRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateInvoiceRequest other
                && (
                    this.Invoice == null && other.Invoice == null
                    || this.Invoice?.Equals(other.Invoice) == true
                )
                && (
                    this.IdempotencyKey == null && other.IdempotencyKey == null
                    || this.IdempotencyKey?.Equals(other.IdempotencyKey) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 503774574;
            hashCode = HashCode.Combine(hashCode, this.Invoice, this.IdempotencyKey);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Invoice = {(this.Invoice == null ? "null" : this.Invoice.ToString())}"
            );
            toStringOutput.Add($"this.IdempotencyKey = {this.IdempotencyKey ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Invoice).IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Invoice invoice;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CreateInvoiceRequest.
            /// </summary>
            /// <param name="invoice"> invoice. </param>
            public Builder(Models.Invoice invoice)
            {
                this.invoice = invoice;
            }

            /// <summary>
            /// Invoice.
            /// </summary>
            /// <param name="invoice"> invoice. </param>
            /// <returns> Builder. </returns>
            public Builder Invoice(Models.Invoice invoice)
            {
                this.invoice = invoice;
                return this;
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
            /// <returns> CreateInvoiceRequest. </returns>
            public CreateInvoiceRequest Build()
            {
                return new CreateInvoiceRequest(this.invoice, this.idempotencyKey);
            }
        }
    }
}
