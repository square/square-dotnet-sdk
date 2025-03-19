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
    /// CreateLoyaltyAccountResponse.
    /// </summary>
    public class CreateLoyaltyAccountResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLoyaltyAccountResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="loyaltyAccount">loyalty_account.</param>
        public CreateLoyaltyAccountResponse(
            IList<Models.Error> errors = null,
            Models.LoyaltyAccount loyaltyAccount = null
        )
        {
            this.Errors = errors;
            this.LoyaltyAccount = loyaltyAccount;
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
        /// Describes a loyalty account in a [loyalty program]($m/LoyaltyProgram). For more information, see
        /// [Create and Retrieve Loyalty Accounts](https://developer.squareup.com/docs/loyalty-api/loyalty-accounts).
        /// </summary>
        [JsonProperty("loyalty_account", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyAccount LoyaltyAccount { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CreateLoyaltyAccountResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CreateLoyaltyAccountResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.LoyaltyAccount == null && other.LoyaltyAccount == null
                    || this.LoyaltyAccount?.Equals(other.LoyaltyAccount) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -963021991;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.LoyaltyAccount);

            return hashCode;
        }

        internal CreateLoyaltyAccountResponse ContextSetter(HttpContext context)
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
                $"this.LoyaltyAccount = {(this.LoyaltyAccount == null ? "null" : this.LoyaltyAccount.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Errors(this.Errors).LoyaltyAccount(this.LoyaltyAccount);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyAccount loyaltyAccount;

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
            /// LoyaltyAccount.
            /// </summary>
            /// <param name="loyaltyAccount"> loyaltyAccount. </param>
            /// <returns> Builder. </returns>
            public Builder LoyaltyAccount(Models.LoyaltyAccount loyaltyAccount)
            {
                this.loyaltyAccount = loyaltyAccount;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateLoyaltyAccountResponse. </returns>
            public CreateLoyaltyAccountResponse Build()
            {
                return new CreateLoyaltyAccountResponse(this.errors, this.loyaltyAccount);
            }
        }
    }
}
