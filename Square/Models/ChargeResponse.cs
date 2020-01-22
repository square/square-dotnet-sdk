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
    public class ChargeResponse 
    {
        public ChargeResponse(IList<Models.Error> errors = null,
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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a transaction processed with Square, either with the
        /// Connect API or with Square Point of Sale.
        /// The `tenders` field of this object lists all methods of payment used to pay in
        /// the transaction.
        /// </summary>
        [JsonProperty("transaction")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.Transaction transaction;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder Transaction(Models.Transaction value)
            {
                transaction = value;
                return this;
            }

            public ChargeResponse Build()
            {
                return new ChargeResponse(errors,
                    transaction);
            }
        }
    }
}