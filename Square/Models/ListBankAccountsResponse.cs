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
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// List of BankAccounts associated with this account.
        /// </summary>
        [JsonProperty("bank_accounts")]
        public IList<Models.BankAccount> BankAccounts { get; }

        /// <summary>
        /// When a response is truncated, it includes a cursor that you can 
        /// use in a subsequent request to fetch next set of bank accounts.
        /// If empty, this is the final response.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
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
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.BankAccount> bankAccounts = new List<Models.BankAccount>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder BankAccounts(IList<Models.BankAccount> value)
            {
                bankAccounts = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
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