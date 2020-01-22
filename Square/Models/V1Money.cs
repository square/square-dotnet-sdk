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
        [JsonProperty("amount")]
        public int? Amount { get; }

        /// <summary>
        /// Indicates the associated currency for an amount of money. Values correspond
        /// to [ISO 4217](https://wikipedia.org/wiki/ISO_4217).
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; }

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

            public Builder() { }
            public Builder Amount(int? value)
            {
                amount = value;
                return this;
            }

            public Builder CurrencyCode(string value)
            {
                currencyCode = value;
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