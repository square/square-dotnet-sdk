
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateInvoiceRequest 
    {
        public CreateInvoiceRequest(Models.Invoice invoice,
            string idempotencyKey = null)
        {
            Invoice = invoice;
            IdempotencyKey = idempotencyKey;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateInvoiceRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Invoice = {(Invoice == null ? "null" : Invoice.ToString())}");
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
        }

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
                ((Invoice == null && other.Invoice == null) || (Invoice?.Equals(other.Invoice) == true)) &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 503774574;

            if (Invoice != null)
            {
               hashCode += Invoice.GetHashCode();
            }

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Invoice)
                .IdempotencyKey(IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.Invoice invoice;
            private string idempotencyKey;

            public Builder(Models.Invoice invoice)
            {
                this.invoice = invoice;
            }

            public Builder Invoice(Models.Invoice invoice)
            {
                this.invoice = invoice;
                return this;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public CreateInvoiceRequest Build()
            {
                return new CreateInvoiceRequest(invoice,
                    idempotencyKey);
            }
        }
    }
}