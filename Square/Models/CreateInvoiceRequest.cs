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
    /// CreateInvoiceRequest.
    /// </summary>
    public class CreateInvoiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateInvoiceRequest"/> class.
        /// </summary>
        /// <param name="invoice">invoice.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateInvoiceRequest(
            Models.Invoice invoice,
            string idempotencyKey = null)
        {
            this.Invoice = invoice;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Stores information about an invoice. You use the Invoices API to create and manage
        /// invoices. For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/invoices-api/overview).
        /// </summary>
        [JsonProperty("invoice")]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// A unique string that identifies the `CreateInvoice` request. If you do not
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is CreateInvoiceRequest other &&
                ((this.Invoice == null && other.Invoice == null) || (this.Invoice?.Equals(other.Invoice) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 503774574;

            if (this.Invoice != null)
            {
               hashCode += this.Invoice.GetHashCode();
            }

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Invoice = {(this.Invoice == null ? "null" : this.Invoice.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Invoice)
                .IdempotencyKey(this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Invoice invoice;
            private string idempotencyKey;

            public Builder(
                Models.Invoice invoice)
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
                return new CreateInvoiceRequest(
                    this.invoice,
                    this.idempotencyKey);
            }
        }
    }
}