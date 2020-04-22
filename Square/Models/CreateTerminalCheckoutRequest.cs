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
    public class CreateTerminalCheckoutRequest 
    {
        public CreateTerminalCheckoutRequest(string idempotencyKey,
            Models.TerminalCheckout checkout)
        {
            IdempotencyKey = idempotencyKey;
            Checkout = checkout;
        }

        /// <summary>
        /// A unique string that identifies this CreateCheckout request. Keys can be any valid string but
        /// must be unique for every CreateCheckout request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Getter for checkout
        /// </summary>
        [JsonProperty("checkout")]
        public Models.TerminalCheckout Checkout { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                Checkout);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private Models.TerminalCheckout checkout;

            public Builder(string idempotencyKey,
                Models.TerminalCheckout checkout)
            {
                this.idempotencyKey = idempotencyKey;
                this.checkout = checkout;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder Checkout(Models.TerminalCheckout value)
            {
                checkout = value;
                return this;
            }

            public CreateTerminalCheckoutRequest Build()
            {
                return new CreateTerminalCheckoutRequest(idempotencyKey,
                    checkout);
            }
        }
    }
}