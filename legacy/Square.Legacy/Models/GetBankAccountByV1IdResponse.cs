using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// GetBankAccountByV1IdResponse.
    /// </summary>
    public class GetBankAccountByV1IdResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetBankAccountByV1IdResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="bankAccount">bank_account.</param>
        public GetBankAccountByV1IdResponse(
            IList<Models.Error> errors = null,
            Models.BankAccount bankAccount = null
        )
        {
            this.Errors = errors;
            this.BankAccount = bankAccount;
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
        /// Represents a bank account. For more information about
        /// linking a bank account to a Square account, see
        /// [Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).
        /// </summary>
        [JsonProperty("bank_account", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BankAccount BankAccount { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GetBankAccountByV1IdResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is GetBankAccountByV1IdResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.BankAccount == null && other.BankAccount == null
                    || this.BankAccount?.Equals(other.BankAccount) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1540889322;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.BankAccount);

            return hashCode;
        }

        internal GetBankAccountByV1IdResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.BankAccount = {(this.BankAccount == null ? "null" : this.BankAccount.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).BankAccount(this.BankAccount);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.BankAccount bankAccount;

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
            /// BankAccount.
            /// </summary>
            /// <param name="bankAccount"> bankAccount. </param>
            /// <returns> Builder. </returns>
            public Builder BankAccount(Models.BankAccount bankAccount)
            {
                this.bankAccount = bankAccount;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GetBankAccountByV1IdResponse. </returns>
            public GetBankAccountByV1IdResponse Build()
            {
                return new GetBankAccountByV1IdResponse(this.errors, this.bankAccount);
            }
        }
    }
}
