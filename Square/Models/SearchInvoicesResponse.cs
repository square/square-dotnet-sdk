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
    public class SearchInvoicesResponse 
    {
        public SearchInvoicesResponse(IList<Models.Invoice> invoices = null,
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
        /// The list of invoices returned by the search.
        /// </summary>
        [JsonProperty("invoices", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Invoice> Invoices { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can use in a 
        /// subsequent request to fetch the next set of invoices. If empty, this is the final 
        /// response. 
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Invoice> invoices;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder Invoices(IList<Models.Invoice> invoices)
            {
                this.invoices = invoices;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public SearchInvoicesResponse Build()
            {
                return new SearchInvoicesResponse(invoices,
                    cursor,
                    errors);
            }
        }
    }
}