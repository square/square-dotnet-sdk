namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// ListTransactionsResponse.
    /// </summary>
    public class ListTransactionsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListTransactionsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="transactions">transactions.</param>
        /// <param name="cursor">cursor.</param>
        public ListTransactionsResponse(
            IList<Models.Error> errors = null,
            IList<Models.Transaction> transactions = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.Transactions = transactions;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
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
        /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListTransactionsResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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

            return obj is ListTransactionsResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Transactions == null && other.Transactions == null) || (this.Transactions?.Equals(other.Transactions) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 739123017;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            if (this.Transactions != null)
            {
               hashCode += this.Transactions.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Transactions = {(this.Transactions == null ? "null" : $"[{string.Join(", ", this.Transactions)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Transactions(this.Transactions)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Transaction> transactions;
            private string cursor;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// Transactions.
             /// </summary>
             /// <param name="transactions"> transactions. </param>
             /// <returns> Builder. </returns>
            public Builder Transactions(IList<Models.Transaction> transactions)
            {
                this.transactions = transactions;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListTransactionsResponse. </returns>
            public ListTransactionsResponse Build()
            {
                return new ListTransactionsResponse(
                    this.errors,
                    this.transactions,
                    this.cursor);
            }
        }
    }
}