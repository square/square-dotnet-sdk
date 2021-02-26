
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateLoyaltyAccountRequest 
    {
        public CreateLoyaltyAccountRequest(Models.LoyaltyAccount loyaltyAccount,
            string idempotencyKey)
        {
            LoyaltyAccount = loyaltyAccount;
            IdempotencyKey = idempotencyKey;
        }

        /// <summary>
        /// Describes a loyalty account. For more information, see 
        /// [Loyalty Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// </summary>
        [JsonProperty("loyalty_account")]
        public Models.LoyaltyAccount LoyaltyAccount { get; }

        /// <summary>
        /// A unique string that identifies this `CreateLoyaltyAccount` request. 
        /// Keys can be any valid string, but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateLoyaltyAccountRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyAccount = {(LoyaltyAccount == null ? "null" : LoyaltyAccount.ToString())}");
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
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

            return obj is CreateLoyaltyAccountRequest other &&
                ((LoyaltyAccount == null && other.LoyaltyAccount == null) || (LoyaltyAccount?.Equals(other.LoyaltyAccount) == true)) &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -436956469;

            if (LoyaltyAccount != null)
            {
               hashCode += LoyaltyAccount.GetHashCode();
            }

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LoyaltyAccount,
                IdempotencyKey);
            return builder;
        }

        public class Builder
        {
            private Models.LoyaltyAccount loyaltyAccount;
            private string idempotencyKey;

            public Builder(Models.LoyaltyAccount loyaltyAccount,
                string idempotencyKey)
            {
                this.loyaltyAccount = loyaltyAccount;
                this.idempotencyKey = idempotencyKey;
            }

            public Builder LoyaltyAccount(Models.LoyaltyAccount loyaltyAccount)
            {
                this.loyaltyAccount = loyaltyAccount;
                return this;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public CreateLoyaltyAccountRequest Build()
            {
                return new CreateLoyaltyAccountRequest(loyaltyAccount,
                    idempotencyKey);
            }
        }
    }
}