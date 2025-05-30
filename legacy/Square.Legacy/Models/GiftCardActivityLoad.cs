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
    /// GiftCardActivityLoad.
    /// </summary>
    public class GiftCardActivityLoad
    {
        private readonly Dictionary<string, bool> shouldSerialize;

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
            IList<string> buyerPaymentInstrumentIds = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "order_id", false },
                { "line_item_uid", false },
                { "reference_id", false },
                { "buyer_payment_instrument_ids", false },
            };
            this.AmountMoney = amountMoney;

            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }

            if (lineItemUid != null)
            {
                shouldSerialize["line_item_uid"] = true;
                this.LineItemUid = lineItemUid;
            }

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

            if (buyerPaymentInstrumentIds != null)
            {
                shouldSerialize["buyer_payment_instrument_ids"] = true;
                this.BuyerPaymentInstrumentIds = buyerPaymentInstrumentIds;
            }
        }

        internal GiftCardActivityLoad(
            Dictionary<string, bool> shouldSerialize,
            Models.Money amountMoney = null,
            string orderId = null,
            string lineItemUid = null,
            string referenceId = null,
            IList<string> buyerPaymentInstrumentIds = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            AmountMoney = amountMoney;
            OrderId = orderId;
            LineItemUid = lineItemUid;
            ReferenceId = referenceId;
            BuyerPaymentInstrumentIds = buyerPaymentInstrumentIds;
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
        /// The ID of the [order](entity:Order) that contains the `GIFT_CARD` line item.
        /// Applications that use the Square Orders API to process orders must specify the order ID in the
        /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// The UID of the `GIFT_CARD` line item in the order that represents the additional funds for the gift card.
        /// Applications that use the Square Orders API to process orders must specify the line item UID
        /// in the [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
        /// </summary>
        [JsonProperty("line_item_uid")]
        public string LineItemUid { get; }

        /// <summary>
        /// A client-specified ID that associates the gift card activity with an entity in another system.
        /// Applications that use a custom order processing system can use this field to track information related to
        /// an order or payment.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// The payment instrument IDs used to process the order for the additional funds, such as a credit card ID
        /// or bank account ID.
        /// Applications that use a custom order processing system must specify payment instrument IDs in
        /// the [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) request.
        /// Square uses this information to perform compliance checks.
        /// For applications that use the Square Orders API to process payments, Square has the necessary
        /// instrument IDs to perform compliance checks.
        /// Each buyer payment instrument ID can contain a maximum of 255 characters.
        /// </summary>
        [JsonProperty("buyer_payment_instrument_ids")]
        public IList<string> BuyerPaymentInstrumentIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GiftCardActivityLoad : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLineItemUid()
        {
            return this.shouldSerialize["line_item_uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerPaymentInstrumentIds()
        {
            return this.shouldSerialize["buyer_payment_instrument_ids"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is GiftCardActivityLoad other
                && (
                    this.AmountMoney == null && other.AmountMoney == null
                    || this.AmountMoney?.Equals(other.AmountMoney) == true
                )
                && (
                    this.OrderId == null && other.OrderId == null
                    || this.OrderId?.Equals(other.OrderId) == true
                )
                && (
                    this.LineItemUid == null && other.LineItemUid == null
                    || this.LineItemUid?.Equals(other.LineItemUid) == true
                )
                && (
                    this.ReferenceId == null && other.ReferenceId == null
                    || this.ReferenceId?.Equals(other.ReferenceId) == true
                )
                && (
                    this.BuyerPaymentInstrumentIds == null
                        && other.BuyerPaymentInstrumentIds == null
                    || this.BuyerPaymentInstrumentIds?.Equals(other.BuyerPaymentInstrumentIds)
                        == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -718796028;
            hashCode = HashCode.Combine(
                hashCode,
                this.AmountMoney,
                this.OrderId,
                this.LineItemUid,
                this.ReferenceId,
                this.BuyerPaymentInstrumentIds
            );

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
            toStringOutput.Add($"this.OrderId = {this.OrderId ?? "null"}");
            toStringOutput.Add($"this.LineItemUid = {this.LineItemUid ?? "null"}");
            toStringOutput.Add($"this.ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add(
                $"this.BuyerPaymentInstrumentIds = {(this.BuyerPaymentInstrumentIds == null ? "null" : $"[{string.Join(", ", this.BuyerPaymentInstrumentIds)} ]")}"
            );
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "order_id", false },
                { "line_item_uid", false },
                { "reference_id", false },
                { "buyer_payment_instrument_ids", false },
            };

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
                shouldSerialize["order_id"] = true;
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
                shouldSerialize["line_item_uid"] = true;
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
                shouldSerialize["reference_id"] = true;
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
                shouldSerialize["buyer_payment_instrument_ids"] = true;
                this.buyerPaymentInstrumentIds = buyerPaymentInstrumentIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLineItemUid()
            {
                this.shouldSerialize["line_item_uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetBuyerPaymentInstrumentIds()
            {
                this.shouldSerialize["buyer_payment_instrument_ids"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivityLoad. </returns>
            public GiftCardActivityLoad Build()
            {
                return new GiftCardActivityLoad(
                    shouldSerialize,
                    this.amountMoney,
                    this.orderId,
                    this.lineItemUid,
                    this.referenceId,
                    this.buyerPaymentInstrumentIds
                );
            }
        }
    }
}
