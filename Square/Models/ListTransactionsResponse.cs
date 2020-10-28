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
    public class ListTransactionsResponse 
    {
        public ListTransactionsResponse(IList<Models.Error> errors = null,
            IList<Models.Transaction> transactions = null,
            string cursor = null)
        {
            Errors = errors;
            Transactions = transactions;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// An array of transactions that match your query.
        /// </summary>
        [JsonProperty("transactions", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Transaction> Transactions { get; }

        /// <summary>
        /// A pagination cursor for retrieving the next set of results,
        /// if any remain. Provide this value as the `cursor` parameter in a subsequent
        /// request to this endpoint.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Transactions(Transactions)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Transaction> transactions;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Transactions(IList<Models.Transaction> transactions)
            {
                this.transactions = transactions;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListTransactionsResponse Build()
            {
                return new ListTransactionsResponse(errors,
                    transactions,
                    cursor);
            }
        }
    }
}