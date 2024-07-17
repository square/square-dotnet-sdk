namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// GiftCardActivityTransferBalanceTo.
    /// </summary>
    public class GiftCardActivityTransferBalanceTo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityTransferBalanceTo"/> class.
        /// </summary>
        /// <param name="transferFromGiftCardId">transfer_from_gift_card_id.</param>
        /// <param name="amountMoney">amount_money.</param>
        public GiftCardActivityTransferBalanceTo(
            string transferFromGiftCardId,
            Models.Money amountMoney)
        {
            this.TransferFromGiftCardId = transferFromGiftCardId;
            this.AmountMoney = amountMoney;
        }

        /// <summary>
        /// The ID of the gift card from which the specified amount was transferred.
        /// </summary>
        [JsonProperty("transfer_from_gift_card_id")]
        public string TransferFromGiftCardId { get; }

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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivityTransferBalanceTo : ({string.Join(", ", toStringOutput)})";
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
            return obj is GiftCardActivityTransferBalanceTo other &&                ((this.TransferFromGiftCardId == null && other.TransferFromGiftCardId == null) || (this.TransferFromGiftCardId?.Equals(other.TransferFromGiftCardId) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1088403925;
            hashCode = HashCode.Combine(this.TransferFromGiftCardId, this.AmountMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TransferFromGiftCardId = {(this.TransferFromGiftCardId == null ? "null" : this.TransferFromGiftCardId)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TransferFromGiftCardId,
                this.AmountMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string transferFromGiftCardId;
            private Models.Money amountMoney;

            /// <summary>
            /// Initialize Builder for GiftCardActivityTransferBalanceTo.
            /// </summary>
            /// <param name="transferFromGiftCardId"> transferFromGiftCardId. </param>
            /// <param name="amountMoney"> amountMoney. </param>
            public Builder(
                string transferFromGiftCardId,
                Models.Money amountMoney)
            {
                this.transferFromGiftCardId = transferFromGiftCardId;
                this.amountMoney = amountMoney;
            }

             /// <summary>
             /// TransferFromGiftCardId.
             /// </summary>
             /// <param name="transferFromGiftCardId"> transferFromGiftCardId. </param>
             /// <returns> Builder. </returns>
            public Builder TransferFromGiftCardId(string transferFromGiftCardId)
            {
                this.transferFromGiftCardId = transferFromGiftCardId;
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
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityTransferBalanceTo. </returns>
            public GiftCardActivityTransferBalanceTo Build()
            {
                return new GiftCardActivityTransferBalanceTo(
                    this.transferFromGiftCardId,
                    this.amountMoney);
            }
        }
    }
}