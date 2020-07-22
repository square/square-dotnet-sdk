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
        /// Stores information about an invoice. You use the Invoices API to create and process
        /// invoices. For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/docs/invoices-api/overview).
        /// </summary>
        [JsonProperty("invoice")]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// A unique string that identifies the `UpdateInvoice` request. If you do not
        /// provide `idempotency_key` (or provide an empty string as the value), the endpoint
        /// treats each request as independent.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// List of fields to clear.
        /// For examples, see [Update an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#update-an-invoice).
        /// </summary>
        [JsonProperty("fields_to_clear")]
        public IList<string> FieldsToClear { get; }

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
            private IList<string> fieldsToClear = new List<string>();

            public Builder(Models.Invoice invoice)
            {
                this.invoice = invoice;
            }
            public Builder Invoice(Models.Invoice value)
            {
                invoice = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder FieldsToClear(IList<string> value)
            {
                fieldsToClear = value;
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