namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CreateLoyaltyAccountRequest.
    /// </summary>
    public class CreateLoyaltyAccountRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLoyaltyAccountRequest"/> class.
        /// </summary>
        /// <param name="loyaltyAccount">loyalty_account.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        public CreateLoyaltyAccountRequest(
            Models.LoyaltyAccount loyaltyAccount,
            string idempotencyKey)
        {
            this.LoyaltyAccount = loyaltyAccount;
            this.IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Describes a loyalty account in a [loyalty program]($m/LoyaltyProgram). For more information, see
        /// [Create and Retrieve Loyalty Accounts](https://developer.squareup.com/docs/loyalty-api/loyalty-accounts).
        /// </summary>
        [JsonProperty("loyalty_account")]
        public Models.LoyaltyAccount LoyaltyAccount { get; }

        /// <summary>
        /// A unique string that identifies this `CreateLoyaltyAccount` request.
        /// Keys can be any valid string, but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateLoyaltyAccountRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is CreateLoyaltyAccountRequest other &&                ((this.LoyaltyAccount == null && other.LoyaltyAccount == null) || (this.LoyaltyAccount?.Equals(other.LoyaltyAccount) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -436956469;
            hashCode = HashCode.Combine(this.LoyaltyAccount, this.IdempotencyKey);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyAccount = {(this.LoyaltyAccount == null ? "null" : this.LoyaltyAccount.ToString())}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LoyaltyAccount,
                this.IdempotencyKey);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.LoyaltyAccount loyaltyAccount;
            private string idempotencyKey;

            /// <summary>
            /// Initialize Builder for CreateLoyaltyAccountRequest.
            /// </summary>
            /// <param name="loyaltyAccount"> loyaltyAccount. </param>
            /// <param name="idempotencyKey"> idempotencyKey. </param>
            public Builder(
                Models.LoyaltyAccount loyaltyAccount,
                string idempotencyKey)
            {
                this.loyaltyAccount = loyaltyAccount;
                this.idempotencyKey = idempotencyKey;
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
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateLoyaltyAccountRequest. </returns>
            public CreateLoyaltyAccountRequest Build()
            {
                return new CreateLoyaltyAccountRequest(
                    this.loyaltyAccount,
                    this.idempotencyKey);
            }
        }
    }
}