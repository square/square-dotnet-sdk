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

namespace Square.Models
{
    /// <summary>
    /// GiftCardActivityTransferBalanceFrom.
    /// </summary>
    public class GiftCardActivityTransferBalanceFrom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityTransferBalanceFrom"/> class.
        /// </summary>
        /// <param name="transferToGiftCardId">transfer_to_gift_card_id.</param>
        /// <param name="amountMoney">amount_money.</param>
        public GiftCardActivityTransferBalanceFrom(
            string transferToGiftCardId,
            Models.Money amountMoney)
        {
            this.TransferToGiftCardId = transferToGiftCardId;
            this.AmountMoney = amountMoney;
        }

        /// <summary>
        /// The ID of the gift card to which the specified amount was transferred.
        /// </summary>
        [JsonProperty("transfer_to_gift_card_id")]
        public string TransferToGiftCardId { get; }

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

            return $"GiftCardActivityTransferBalanceFrom : ({string.Join(", ", toStringOutput)})";
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
            return obj is GiftCardActivityTransferBalanceFrom other &&                ((this.TransferToGiftCardId == null && other.TransferToGiftCardId == null) || (this.TransferToGiftCardId?.Equals(other.TransferToGiftCardId) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -144429867;
            hashCode = HashCode.Combine(this.TransferToGiftCardId, this.AmountMoney);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TransferToGiftCardId = {(this.TransferToGiftCardId == null ? "null" : this.TransferToGiftCardId)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.TransferToGiftCardId,
                this.AmountMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string transferToGiftCardId;
            private Models.Money amountMoney;

            /// <summary>
            /// Initialize Builder for GiftCardActivityTransferBalanceFrom.
            /// </summary>
            /// <param name="transferToGiftCardId"> transferToGiftCardId. </param>
            /// <param name="amountMoney"> amountMoney. </param>
            public Builder(
                string transferToGiftCardId,
                Models.Money amountMoney)
            {
                this.transferToGiftCardId = transferToGiftCardId;
                this.amountMoney = amountMoney;
            }

             /// <summary>
             /// TransferToGiftCardId.
             /// </summary>
             /// <param name="transferToGiftCardId"> transferToGiftCardId. </param>
             /// <returns> Builder. </returns>
            public Builder TransferToGiftCardId(string transferToGiftCardId)
            {
                this.transferToGiftCardId = transferToGiftCardId;
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
            /// <returns> GiftCardActivityTransferBalanceFrom. </returns>
            public GiftCardActivityTransferBalanceFrom Build()
            {
                return new GiftCardActivityTransferBalanceFrom(
                    this.transferToGiftCardId,
                    this.amountMoney);
            }
        }
    }
}