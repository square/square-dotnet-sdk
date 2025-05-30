using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// GiftCardActivityAdjustIncrement.
    /// </summary>
    public class GiftCardActivityAdjustIncrement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityAdjustIncrement"/> class.
        /// </summary>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="reason">reason.</param>
        public GiftCardActivityAdjustIncrement(Models.Money amountMoney, string reason)
        {
            this.AmountMoney = amountMoney;
            this.Reason = reason;
        }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Indicates the reason for adding money to a [gift card]($m/GiftCard).
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GiftCardActivityAdjustIncrement : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is GiftCardActivityAdjustIncrement other
                && (
                    this.AmountMoney == null && other.AmountMoney == null
                    || this.AmountMoney?.Equals(other.AmountMoney) == true
                )
                && (
                    this.Reason == null && other.Reason == null
                    || this.Reason?.Equals(other.Reason) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1966489663;
            hashCode = HashCode.Combine(hashCode, this.AmountMoney, this.Reason);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}"
            );
            toStringOutput.Add(
                $"this.Reason = {(this.Reason == null ? "null" : this.Reason.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.AmountMoney, this.Reason);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money amountMoney;
            private string reason;

            /// <summary>
            /// Initialize Builder for GiftCardActivityAdjustIncrement.
            /// </summary>
            /// <param name="amountMoney"> amountMoney. </param>
            /// <param name="reason"> reason. </param>
            public Builder(Models.Money amountMoney, string reason)
            {
                this.amountMoney = amountMoney;
                this.reason = reason;
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
            /// Reason.
            /// </summary>
            /// <param name="reason"> reason. </param>
            /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityAdjustIncrement. </returns>
            public GiftCardActivityAdjustIncrement Build()
            {
                return new GiftCardActivityAdjustIncrement(this.amountMoney, this.reason);
            }
        }
    }
}
