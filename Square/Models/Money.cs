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
    /// Money.
    /// </summary>
    public class Money
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="amount">amount.</param>
        /// <param name="currency">currency.</param>
        public Money(
            long? amount = null,
            string currency = null)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        /// <summary>
        /// The amount of money, in the smallest denomination of the currency
        /// indicated by `currency`. For example, when `currency` is `USD`, `amount` is
        /// in cents. Monetary amounts can be positive or negative. See the specific
        /// field description to determine the meaning of the sign in a particular case.
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? Amount { get; }

        /// <summary>
        /// Indicates the associated currency for an amount of money. Values correspond
        /// to [ISO 4217](https://wikipedia.org/wiki/ISO_4217).
        /// </summary>
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Money : ({string.Join(", ", toStringOutput)})";
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

            return obj is Money other &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -205100821;

            if (this.Amount != null)
            {
               hashCode += this.Amount.GetHashCode();
            }

            if (this.Currency != null)
            {
               hashCode += this.Currency.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount.ToString())}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Amount(this.Amount)
                .Currency(this.Currency);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private long? amount;
            private string currency;

             /// <summary>
             /// Amount.
             /// </summary>
             /// <param name="amount"> amount. </param>
             /// <returns> Builder. </returns>
            public Builder Amount(long? amount)
            {
                this.amount = amount;
                return this;
            }

             /// <summary>
             /// Currency.
             /// </summary>
             /// <param name="currency"> currency. </param>
             /// <returns> Builder. </returns>
            public Builder Currency(string currency)
            {
                this.currency = currency;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Money. </returns>
            public Money Build()
            {
                return new Money(
                    this.amount,
                    this.currency);
            }
        }
    }
}