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
    public class CatalogQuickAmount 
    {
        public CatalogQuickAmount(string type,
            Models.Money amount,
            long? score = null,
            long? ordinal = null)
        {
            Type = type;
            Amount = amount;
            Score = score;
            Ordinal = ordinal;
        }

        /// <summary>
        /// Determines the type of a specific Quick Amount.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount")]
        public Models.Money Amount { get; }

        /// <summary>
        /// Describes the ranking of the Quick Amount provided by machine learning model, in the range [0, 100].
        /// MANUAL type amount will always have score = 100.
        /// </summary>
        [JsonProperty("score")]
        public long? Score { get; }

        /// <summary>
        /// The order in which this Quick Amount should be displayed.
        /// </summary>
        [JsonProperty("ordinal")]
        public long? Ordinal { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Type,
                Amount)
                .Score(Score)
                .Ordinal(Ordinal);
            return builder;
        }

        public class Builder
        {
            private string type;
            private Models.Money amount;
            private long? score;
            private long? ordinal;

            public Builder(string type,
                Models.Money amount)
            {
                this.type = type;
                this.amount = amount;
            }
            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Amount(Models.Money value)
            {
                amount = value;
                return this;
            }

            public Builder Score(long? value)
            {
                score = value;
                return this;
            }

            public Builder Ordinal(long? value)
            {
                ordinal = value;
                return this;
            }

            public CatalogQuickAmount Build()
            {
                return new CatalogQuickAmount(type,
                    amount,
                    score,
                    ordinal);
            }
        }
    }
}