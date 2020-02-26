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
    public class GetBankAccountResponse 
    {
        public GetBankAccountResponse(IList<Models.Error> errors = null,
            Models.BankAccount bankAccount = null)
        {
            Errors = errors;
            BankAccount = bankAccount;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a bank account. For more information about 
        /// linking a bank account to a Square account, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api).
        /// </summary>
        [JsonProperty("bank_account")]
        public Models.BankAccount BankAccount { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .BankAccount(BankAccount);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.BankAccount bankAccount;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder BankAccount(Models.BankAccount value)
            {
                bankAccount = value;
                return this;
            }

            public GetBankAccountResponse Build()
            {
                return new GetBankAccountResponse(errors,
                    bankAccount);
            }
        }
    }
}