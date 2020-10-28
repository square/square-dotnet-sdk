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
    public class UpdateInvoiceResponse 
    {
        public UpdateInvoiceResponse(Models.Invoice invoice = null,
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
        [JsonProperty("invoice", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Invoice Invoice { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Error> errors;



            public Builder Invoice(Models.Invoice invoice)
            {
                this.invoice = invoice;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public UpdateInvoiceResponse Build()
            {
                return new UpdateInvoiceResponse(invoice,
                    errors);
            }
        }
    }
}