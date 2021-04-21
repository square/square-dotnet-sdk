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
    /// V1Money.
    /// </summary>
    public class V1Money
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Money"/> class.
        /// </summary>
        /// <param name="amount">amount.</param>
        /// <param name="currencyCode">currency_code.</param>
        public V1Money(
            int? amount = null,
            string currencyCode = null)
        {
            this.Amount = amount;
            this.CurrencyCode = currencyCode;
        }

        /// <summary>
        /// Amount in the lowest denominated value of this Currency. E.g. in USD
        /// these are cents, in JPY they are Yen (which do not have a 'cent' concept).
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public int? Amount { get; }

        /// <summary>
        /// Indicates the associated currency for an amount of money. Values correspond
        /// to [ISO 4217](https://wikipedia.org/wiki/ISO_4217).
        /// </summary>
        [JsonProperty("currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Money : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1Money other &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                ((this.CurrencyCode == null && other.CurrencyCode == null) || (this.CurrencyCode?.Equals(other.CurrencyCode) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1421052291;

            if (this.Amount != null)
            {
               hashCode += this.Amount.GetHashCode();
            }

            if (this.CurrencyCode != null)
            {
               hashCode += this.CurrencyCode.GetHashCode();
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
            toStringOutput.Add($"this.CurrencyCode = {(this.CurrencyCode == null ? "null" : this.CurrencyCode.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Amount(this.Amount)
                .CurrencyCode(this.CurrencyCode);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private int? amount;
            private string currencyCode;

             /// <summary>
             /// Amount.
             /// </summary>
             /// <param name="amount"> amount. </param>
             /// <returns> Builder. </returns>
            public Builder Amount(int? amount)
            {
                this.amount = amount;
                return this;
            }

             /// <summary>
             /// CurrencyCode.
             /// </summary>
             /// <param name="currencyCode"> currencyCode. </param>
             /// <returns> Builder. </returns>
            public Builder CurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1Money. </returns>
            public V1Money Build()
            {
                return new V1Money(
                    this.amount,
                    this.currencyCode);
            }
        }
    }
}