
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetBankAccountByV1IdResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"BankAccount = {(BankAccount == null ? "null" : BankAccount.ToString())}");
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

            return obj is GetBankAccountByV1IdResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((BankAccount == null && other.BankAccount == null) || (BankAccount?.Equals(other.BankAccount) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1540889322;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (BankAccount != null)
            {
               hashCode += BankAccount.GetHashCode();
            }

            return hashCode;
        }

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