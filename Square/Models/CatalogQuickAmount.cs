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
    /// CatalogQuickAmount.
    /// </summary>
    public class CatalogQuickAmount
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogQuickAmount"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="amount">amount.</param>
        /// <param name="score">score.</param>
        /// <param name="ordinal">ordinal.</param>
        public CatalogQuickAmount(
            string type,
            Models.Money amount,
            long? score = null,
            long? ordinal = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "score", false },
                { "ordinal", false }
            };

            this.Type = type;
            this.Amount = amount;
            if (score != null)
            {
                shouldSerialize["score"] = true;
                this.Score = score;
            }

            if (ordinal != null)
            {
                shouldSerialize["ordinal"] = true;
                this.Ordinal = ordinal;
            }

        }
        internal CatalogQuickAmount(Dictionary<string, bool> shouldSerialize,
            string type,
            Models.Money amount,
            long? score = null,
            long? ordinal = null)
        {
            this.shouldSerialize = shouldSerialize;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogQuickAmount : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeScore()
        {
            return this.shouldSerialize["score"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrdinal()
        {
            return this.shouldSerialize["ordinal"];
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
            return obj is CatalogQuickAmount other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                ((this.Score == null && other.Score == null) || (this.Score?.Equals(other.Score) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1903352296;
            hashCode = HashCode.Combine(this.Type, this.Amount, this.Score, this.Ordinal);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount.ToString())}");
            toStringOutput.Add($"this.Score = {(this.Score == null ? "null" : this.Score.ToString())}");
            toStringOutput.Add($"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type,
                this.Amount)
                .Score(this.Score)
                .Ordinal(this.Ordinal);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "score", false },
                { "ordinal", false },
            };

            private string type;
            private Models.Money amount;
            private long? score;
            private long? ordinal;

            public Builder(
                string type,
                Models.Money amount)
            {
                this.type = type;
                this.amount = amount;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// Amount.
             /// </summary>
             /// <param name="amount"> amount. </param>
             /// <returns> Builder. </returns>
            public Builder Amount(Models.Money amount)
            {
                this.amount = amount;
                return this;
            }

             /// <summary>
             /// Score.
             /// </summary>
             /// <param name="score"> score. </param>
             /// <returns> Builder. </returns>
            public Builder Score(long? score)
            {
                shouldSerialize["score"] = true;
                this.score = score;
                return this;
            }

             /// <summary>
             /// Ordinal.
             /// </summary>
             /// <param name="ordinal"> ordinal. </param>
             /// <returns> Builder. </returns>
            public Builder Ordinal(long? ordinal)
            {
                shouldSerialize["ordinal"] = true;
                this.ordinal = ordinal;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetScore()
            {
                this.shouldSerialize["score"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrdinal()
            {
                this.shouldSerialize["ordinal"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogQuickAmount. </returns>
            public CatalogQuickAmount Build()
            {
                return new CatalogQuickAmount(shouldSerialize,
                    this.type,
                    this.amount,
                    this.score,
                    this.ordinal);
            }
        }
    }
}