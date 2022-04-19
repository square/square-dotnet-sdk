namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CreateTerminalCheckoutRequest.
    /// </summary>
    public class CreateTerminalCheckoutRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTerminalCheckoutRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="checkout">checkout.</param>
        public CreateTerminalCheckoutRequest(
            string idempotencyKey,
            Models.TerminalCheckout checkout)
        {
            this.IdempotencyKey = idempotencyKey;
            this.Checkout = checkout;
        }

        /// <summary>
        /// A unique string that identifies this `CreateCheckout` request. Keys can be any valid string but
        /// must be unique for every `CreateCheckout` request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Represents a checkout processed by the Square Terminal.
        /// </summary>
        [JsonProperty("checkout")]
        public Models.TerminalCheckout Checkout { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateTerminalCheckoutRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreateTerminalCheckoutRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.Checkout == null && other.Checkout == null) || (this.Checkout?.Equals(other.Checkout) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 418922267;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.Checkout);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.Checkout = {(this.Checkout == null ? "null" : this.Checkout.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.Checkout);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.TerminalCheckout checkout;

            public Builder(
                string idempotencyKey,
                Models.TerminalCheckout checkout)
            {
                this.idempotencyKey = idempotencyKey;
                this.checkout = checkout;
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
             /// Checkout.
             /// </summary>
             /// <param name="checkout"> checkout. </param>
             /// <returns> Builder. </returns>
            public Builder Checkout(Models.TerminalCheckout checkout)
            {
                this.checkout = checkout;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateTerminalCheckoutRequest. </returns>
            public CreateTerminalCheckoutRequest Build()
            {
                return new CreateTerminalCheckoutRequest(
                    this.idempotencyKey,
                    this.checkout);
            }
        }
    }
}