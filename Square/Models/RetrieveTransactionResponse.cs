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
    public class RetrieveTransactionResponse 
    {
        public RetrieveTransactionResponse(IList<Models.Error> errors = null,
            Models.Transaction transaction = null)
        {
            Errors = errors;
            Transaction = transaction;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a transaction processed with Square, either with the
        /// Connect API or with Square Point of Sale.
        /// The `tenders` field of this object lists all methods of payment used to pay in
        /// the transaction.
        /// </summary>
        [JsonProperty("transaction", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Transaction Transaction { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Transaction(Transaction);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Transaction transaction;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Transaction(Models.Transaction transaction)
            {
                this.transaction = transaction;
                return this;
            }

            public RetrieveTransactionResponse Build()
            {
                return new RetrieveTransactionResponse(errors,
                    transaction);
            }
        }
    }
}