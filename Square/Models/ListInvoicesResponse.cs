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
    public class ListInvoicesResponse 
    {
        public ListInvoicesResponse(IList<Models.Invoice> invoices = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            Invoices = invoices;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The invoices retrieved.
        /// </summary>
        [JsonProperty("invoices")]
        public IList<Models.Invoice> Invoices { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can use in a 
        /// subsequent request to fetch the next set of invoices. If empty, this is the final 
        /// response. 
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Invoices(Invoices)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Invoice> invoices = new List<Models.Invoice>();
            private string cursor;
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder Invoices(IList<Models.Invoice> value)
            {
                invoices = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public ListInvoicesResponse Build()
            {
                return new ListInvoicesResponse(invoices,
                    cursor,
                    errors);
            }
        }
    }
}