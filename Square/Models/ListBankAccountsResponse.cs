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
    /// ListBankAccountsResponse.
    /// </summary>
    public class ListBankAccountsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListBankAccountsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="bankAccounts">bank_accounts.</param>
        /// <param name="cursor">cursor.</param>
        public ListBankAccountsResponse(
            IList<Models.Error> errors = null,
            IList<Models.BankAccount> bankAccounts = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.BankAccounts = bankAccounts;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// List of BankAccounts associated with this account.
        /// </summary>
        [JsonProperty("bank_accounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.BankAccount> BankAccounts { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can
        /// use in a subsequent request to fetch next set of bank accounts.
        /// If empty, this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListBankAccountsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListBankAccountsResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.BankAccounts == null && other.BankAccounts == null) || (this.BankAccounts?.Equals(other.BankAccounts) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 77145891;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.BankAccounts, this.Cursor);

            return hashCode;
        }
        internal ListBankAccountsResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.BankAccounts = {(this.BankAccounts == null ? "null" : $"[{string.Join(", ", this.BankAccounts)} ]")}");
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
                .BankAccounts(this.BankAccounts)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.BankAccount> bankAccounts;
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
             /// BankAccounts.
             /// </summary>
             /// <param name="bankAccounts"> bankAccounts. </param>
             /// <returns> Builder. </returns>
            public Builder BankAccounts(IList<Models.BankAccount> bankAccounts)
            {
                this.bankAccounts = bankAccounts;
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
            /// <returns> ListBankAccountsResponse. </returns>
            public ListBankAccountsResponse Build()
            {
                return new ListBankAccountsResponse(
                    this.errors,
                    this.bankAccounts,
                    this.cursor);
            }
        }
    }
}