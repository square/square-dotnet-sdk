using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CancelInvoiceResponse 
    {
        public CancelInvoiceResponse(Models.Invoice invoice = null,
            IList<Models.Error> errors = null)
        {
            Invoice = invoice;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Stores information about an invoice. You use the Invoices API to create and process
        /// invoices. For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/docs/invoices-api/overview).
        /// </summary>
        [JsonProperty("invoice")]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Invoice(Invoice)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.Invoice invoice;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Invoice(Models.Invoice value)
            {
                invoice = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public CancelInvoiceResponse Build()
            {
                return new CancelInvoiceResponse(invoice,
                    errors);
            }
        }
    }
}