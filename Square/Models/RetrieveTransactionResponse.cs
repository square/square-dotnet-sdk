
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveTransactionResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Transaction = {(Transaction == null ? "null" : Transaction.ToString())}");
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

            return obj is RetrieveTransactionResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Transaction == null && other.Transaction == null) || (Transaction?.Equals(other.Transaction) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 808587361;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Transaction != null)
            {
               hashCode += Transaction.GetHashCode();
            }

            return hashCode;
        }

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