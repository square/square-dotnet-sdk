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
    public class GetBankAccountByV1IdResponse 
    {
        public GetBankAccountByV1IdResponse(IList<Models.Error> errors = null,
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
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Represents a bank account. For more information about 
        /// linking a bank account to a Square account, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).
        /// </summary>
        [JsonProperty("bank_account", NullValueHandling = NullValueHandling.Ignore)]
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
            private IList<Models.Error> errors;
            private Models.BankAccount bankAccount;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder BankAccount(Models.BankAccount bankAccount)
            {
                this.bankAccount = bankAccount;
                return this;
            }

            public GetBankAccountByV1IdResponse Build()
            {
                return new GetBankAccountByV1IdResponse(errors,
                    bankAccount);
            }
        }
    }
}