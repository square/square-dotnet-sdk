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
    public class ProcessingFee 
    {
        public ProcessingFee(string effectiveAt = null,
            string type = null,
            Models.Money amountMoney = null)
        {
            EffectiveAt = effectiveAt;
            Type = type;
            AmountMoney = amountMoney;
        }

        /// <summary>
        /// Timestamp of when the fee takes effect, in RFC 3339 format.
        /// </summary>
        [JsonProperty("effective_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EffectiveAt { get; }

        /// <summary>
        /// The type of fee assessed or adjusted. Can be one of: `INITIAL`, `ADJUSTMENT`.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EffectiveAt(EffectiveAt)
                .Type(Type)
                .AmountMoney(AmountMoney);
            return builder;
        }

        public class Builder
        {
            private string effectiveAt;
            private string type;
            private Models.Money amountMoney;



            public Builder EffectiveAt(string effectiveAt)
            {
                this.effectiveAt = effectiveAt;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public ProcessingFee Build()
            {
                return new ProcessingFee(effectiveAt,
                    type,
                    amountMoney);
            }
        }
    }
}