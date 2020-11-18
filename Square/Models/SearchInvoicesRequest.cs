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
    public class SearchInvoicesRequest 
    {
        public SearchInvoicesRequest(Models.InvoiceQuery query,
            int? limit = null,
            string cursor = null)
        {
            Query = query;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Describes query criteria for searching invoices.
        /// </summary>
        [JsonProperty("query")]
        public Models.InvoiceQuery Query { get; }

        /// <summary>
        /// The maximum number of invoices to return (200 is the maximum `limit`). 
        /// If not provided, the server 
        /// uses a default limit of 100 invoices.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint. 
        /// Provide this cursor to retrieve the next set of results for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Query)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private Models.InvoiceQuery query;
            private int? limit;
            private string cursor;

            public Builder(Models.InvoiceQuery query)
            {
                this.query = query;
            }

            public Builder Query(Models.InvoiceQuery query)
            {
                this.query = query;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public SearchInvoicesRequest Build()
            {
                return new SearchInvoicesRequest(query,
                    limit,
                    cursor);
            }
        }
    }
}