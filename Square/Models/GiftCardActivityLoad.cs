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
    /// GiftCardActivityLoad.
    /// </summary>
    public class GiftCardActivityLoad
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivityLoad"/> class.
        /// </summary>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="lineItemUid">line_item_uid.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="buyerPaymentInstrumentIds">buyer_payment_instrument_ids.</param>
        public GiftCardActivityLoad(
            Models.Money amountMoney = null,
            string orderId = null,
            string lineItemUid = null,
            string referenceId = null,
            IList<string> buyerPaymentInstrumentIds = null)
        {
            this.AmountMoney = amountMoney;
            this.OrderId = orderId;
            this.LineItemUid = lineItemUid;
            this.ReferenceId = referenceId;
            this.BuyerPaymentInstrumentIds = buyerPaymentInstrumentIds;
        }

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

        /// <summary>
        /// The ID of the [order]($m/Order) that contains the `GIFT_CARD` line item.
        /// Applications that use the Square Orders API to process orders must specify the order ID in the
        /// [CreateGiftCardActivity]($e/GiftCardActivities/CreateGiftCardActivity) request.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// The UID of the `GIFT_CARD` line item in the order that represents the additional funds for the gift card.
        /// Applications that use the Square Orders API to process orders must specify the line item UID
        /// in the [CreateGiftCardActivity]($e/GiftCardActivities/CreateGiftCardActivity) request.
        /// </summary>
        [JsonProperty("line_item_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string LineItemUid { get; }

        /// <summary>
        /// A client-specified ID that associates the gift card activity with an entity in another system.
        /// Applications that use a custom order processing system can use this field to track information related to
        /// an order or payment.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// The payment instrument IDs used to process the order for the additional funds, such as a credit card ID
        /// or bank account ID.
        /// Applications that use a custom order processing system must specify payment instrument IDs in
        /// the [CreateGiftCardActivity]($e/GiftCardActivities/CreateGiftCardActivity) request.
        /// Square uses this information to perform compliance checks.
        /// For applications that use the Square Orders API to process payments, Square has the necessary
        /// instrument IDs to perform compliance checks.
        /// </summary>
        [JsonProperty("buyer_payment_instrument_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> BuyerPaymentInstrumentIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivityLoad : ({string.Join(", ", toStringOutput)})";
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

            return obj is GiftCardActivityLoad other &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.LineItemUid == null && other.LineItemUid == null) || (this.LineItemUid?.Equals(other.LineItemUid) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.BuyerPaymentInstrumentIds == null && other.BuyerPaymentInstrumentIds == null) || (this.BuyerPaymentInstrumentIds?.Equals(other.BuyerPaymentInstrumentIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -718796028;
            hashCode = HashCode.Combine(this.AmountMoney, this.OrderId, this.LineItemUid, this.ReferenceId, this.BuyerPaymentInstrumentIds);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.LineItemUid = {(this.LineItemUid == null ? "null" : this.LineItemUid == string.Empty ? "" : this.LineItemUid)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.BuyerPaymentInstrumentIds = {(this.BuyerPaymentInstrumentIds == null ? "null" : $"[{string.Join(", ", this.BuyerPaymentInstrumentIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AmountMoney(this.AmountMoney)
                .OrderId(this.OrderId)
                .LineItemUid(this.LineItemUid)
                .ReferenceId(this.ReferenceId)
                .BuyerPaymentInstrumentIds(this.BuyerPaymentInstrumentIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Money amountMoney;
            private string orderId;
            private string lineItemUid;
            private string referenceId;
            private IList<string> buyerPaymentInstrumentIds;

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
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// LineItemUid.
             /// </summary>
             /// <param name="lineItemUid"> lineItemUid. </param>
             /// <returns> Builder. </returns>
            public Builder LineItemUid(string lineItemUid)
            {
                this.lineItemUid = lineItemUid;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// BuyerPaymentInstrumentIds.
             /// </summary>
             /// <param name="buyerPaymentInstrumentIds"> buyerPaymentInstrumentIds. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerPaymentInstrumentIds(IList<string> buyerPaymentInstrumentIds)
            {
                this.buyerPaymentInstrumentIds = buyerPaymentInstrumentIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityLoad. </returns>
            public GiftCardActivityLoad Build()
            {
                return new GiftCardActivityLoad(
                    this.amountMoney,
                    this.orderId,
                    this.lineItemUid,
                    this.referenceId,
                    this.buyerPaymentInstrumentIds);
            }
        }
    }
}