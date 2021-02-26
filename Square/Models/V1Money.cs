
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
    public class V1Money 
    {
        public V1Money(int? amount = null,
            string currencyCode = null)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Money : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Amount = {(Amount == null ? "null" : Amount.ToString())}");
            toStringOutput.Add($"CurrencyCode = {(CurrencyCode == null ? "null" : CurrencyCode.ToString())}");
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

            return obj is V1Money other &&
                ((Amount == null && other.Amount == null) || (Amount?.Equals(other.Amount) == true)) &&
                ((CurrencyCode == null && other.CurrencyCode == null) || (CurrencyCode?.Equals(other.CurrencyCode) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1421052291;

            if (Amount != null)
            {
               hashCode += Amount.GetHashCode();
            }

            if (CurrencyCode != null)
            {
               hashCode += CurrencyCode.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Amount(Amount)
                .CurrencyCode(CurrencyCode);
            return builder;
        }

        public class Builder
        {
            private int? amount;
            private string currencyCode;



            public Builder Amount(int? amount)
            {
                this.amount = amount;
                return this;
            }

            public Builder CurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }

            public V1Money Build()
            {
                return new V1Money(amount,
                    currencyCode);
            }
        }
    }
}