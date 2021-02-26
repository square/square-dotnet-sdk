
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
    public class UpdateInvoiceRequest 
    {
        public UpdateInvoiceRequest(Models.Invoice invoice,
            string idempotencyKey = null,
            IList<string> fieldsToClear = null)
        {
            Invoice = invoice;
            IdempotencyKey = idempotencyKey;
            FieldsToClear = fieldsToClear;
        }

        /// <summary>
        /// Stores information about an invoice. You use the Invoices API to create and manage
        /// invoices. For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/invoices-api/overview).
        /// </summary>
        [JsonProperty("invoice")]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// A unique string that identifies the `UpdateInvoice` request. If you do not
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key", NullValueHandling = NullValueHandling.Ignore)]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The list of fields to clear.
        /// For examples, see [Update an invoice](https://developer.squareup.com/docs/invoices-api/overview#update-an-invoice).
        /// </summary>
        [JsonProperty("fields_to_clear", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FieldsToClear { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateInvoiceRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Invoice = {(Invoice == null ? "null" : Invoice.ToString())}");
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"FieldsToClear = {(FieldsToClear == null ? "null" : $"[{ string.Join(", ", FieldsToClear)} ]")}");
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

            return obj is UpdateInvoiceRequest other &&
                ((Invoice == null && other.Invoice == null) || (Invoice?.Equals(other.Invoice) == true)) &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((FieldsToClear == null && other.FieldsToClear == null) || (FieldsToClear?.Equals(other.FieldsToClear) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -281586426;

            if (Invoice != null)
            {
               hashCode += Invoice.GetHashCode();
            }

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (FieldsToClear != null)
            {
               hashCode += FieldsToClear.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Invoice)
                .IdempotencyKey(IdempotencyKey)
                .FieldsToClear(FieldsToClear);
            return builder;
        }

        public class Builder
        {
            private Models.Invoice invoice;
            private string idempotencyKey;
            private IList<string> fieldsToClear;

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

            public Builder FieldsToClear(IList<string> fieldsToClear)
            {
                this.fieldsToClear = fieldsToClear;
                return this;
            }

            public UpdateInvoiceRequest Build()
            {
                return new UpdateInvoiceRequest(invoice,
                    idempotencyKey,
                    fieldsToClear);
            }
        }
    }
}