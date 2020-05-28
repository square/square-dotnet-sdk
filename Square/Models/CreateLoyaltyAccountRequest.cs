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
        /// [Loyalty Overview](https://developer.squareup.com/docs/docs/loyalty/overview).
        /// </summary>
        [JsonProperty("loyalty_account")]
        public Models.LoyaltyAccount LoyaltyAccount { get; }

        /// <summary>
        /// A unique string that identifies this `CreateLoyaltyAccount` request. 
        /// Keys can be any valid string, but must be unique for every request.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

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
            public Builder LoyaltyAccount(Models.LoyaltyAccount value)
            {
                loyaltyAccount = value;
                return this;
            }

            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
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