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
    public class ListBankAccountsResponse 
    {
        public ListBankAccountsResponse(IList<Models.Error> errors = null,
            IList<Models.BankAccount> bankAccounts = null,
            string cursor = null)
        {
            Errors = errors;
            BankAccounts = bankAccounts;
            Cursor = cursor;
        }

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

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .BankAccounts(BankAccounts)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.BankAccount> bankAccounts;
            private string cursor;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder BankAccounts(IList<Models.BankAccount> bankAccounts)
            {
                this.bankAccounts = bankAccounts;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public ListBankAccountsResponse Build()
            {
                return new ListBankAccountsResponse(errors,
                    bankAccounts,
                    cursor);
            }
        }
    }
}