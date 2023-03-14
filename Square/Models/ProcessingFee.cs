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
    /// ProcessingFee.
    /// </summary>
    public class ProcessingFee
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessingFee"/> class.
        /// </summary>
        /// <param name="effectiveAt">effective_at.</param>
        /// <param name="type">type.</param>
        /// <param name="amountMoney">amount_money.</param>
        public ProcessingFee(
            string effectiveAt = null,
            string type = null,
            Models.Money amountMoney = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_at", false },
                { "type", false }
            };

            if (effectiveAt != null)
            {
                shouldSerialize["effective_at"] = true;
                this.EffectiveAt = effectiveAt;
            }

            if (type != null)
            {
                shouldSerialize["type"] = true;
                this.Type = type;
            }

            this.AmountMoney = amountMoney;
        }
        internal ProcessingFee(Dictionary<string, bool> shouldSerialize,
            string effectiveAt = null,
            string type = null,
            Models.Money amountMoney = null)
        {
            this.shouldSerialize = shouldSerialize;
            EffectiveAt = effectiveAt;
            Type = type;
            AmountMoney = amountMoney;
        }

        /// <summary>
        /// The timestamp of when the fee takes effect, in RFC 3339 format.
        /// </summary>
        [JsonProperty("effective_at")]
        public string EffectiveAt { get; }

        /// <summary>
        /// The type of fee assessed or adjusted. The fee type can be `INITIAL` or `ADJUSTMENT`.
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
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ProcessingFee : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEffectiveAt()
        {
            return this.shouldSerialize["effective_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeType()
        {
            return this.shouldSerialize["type"];
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

            return obj is ProcessingFee other &&
                ((this.EffectiveAt == null && other.EffectiveAt == null) || (this.EffectiveAt?.Equals(other.EffectiveAt) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1083651961;
            hashCode = HashCode.Combine(this.EffectiveAt, this.Type, this.AmountMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EffectiveAt = {(this.EffectiveAt == null ? "null" : this.EffectiveAt == string.Empty ? "" : this.EffectiveAt)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EffectiveAt(this.EffectiveAt)
                .Type(this.Type)
                .AmountMoney(this.AmountMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "effective_at", false },
                { "type", false },
            };

            private string effectiveAt;
            private string type;
            private Models.Money amountMoney;

             /// <summary>
             /// EffectiveAt.
             /// </summary>
             /// <param name="effectiveAt"> effectiveAt. </param>
             /// <returns> Builder. </returns>
            public Builder EffectiveAt(string effectiveAt)
            {
                shouldSerialize["effective_at"] = true;
                this.effectiveAt = effectiveAt;
                return this;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                shouldSerialize["type"] = true;
                this.type = type;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEffectiveAt()
            {
                this.shouldSerialize["effective_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetType()
            {
                this.shouldSerialize["type"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ProcessingFee. </returns>
            public ProcessingFee Build()
            {
                return new ProcessingFee(shouldSerialize,
                    this.effectiveAt,
                    this.type,
                    this.amountMoney);
            }
        }
    }
}