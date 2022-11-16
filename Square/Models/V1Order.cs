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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// V1Order.
    /// </summary>
    public class V1Order
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Order"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="id">id.</param>
        /// <param name="buyerEmail">buyer_email.</param>
        /// <param name="recipientName">recipient_name.</param>
        /// <param name="recipientPhoneNumber">recipient_phone_number.</param>
        /// <param name="state">state.</param>
        /// <param name="shippingAddress">shipping_address.</param>
        /// <param name="subtotalMoney">subtotal_money.</param>
        /// <param name="totalShippingMoney">total_shipping_money.</param>
        /// <param name="totalTaxMoney">total_tax_money.</param>
        /// <param name="totalPriceMoney">total_price_money.</param>
        /// <param name="totalDiscountMoney">total_discount_money.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="expiresAt">expires_at.</param>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="buyerNote">buyer_note.</param>
        /// <param name="completedNote">completed_note.</param>
        /// <param name="refundedNote">refunded_note.</param>
        /// <param name="canceledNote">canceled_note.</param>
        /// <param name="tender">tender.</param>
        /// <param name="orderHistory">order_history.</param>
        /// <param name="promoCode">promo_code.</param>
        /// <param name="btcReceiveAddress">btc_receive_address.</param>
        /// <param name="btcPriceSatoshi">btc_price_satoshi.</param>
        public V1Order(
            IList<Models.Error> errors = null,
            string id = null,
            string buyerEmail = null,
            string recipientName = null,
            string recipientPhoneNumber = null,
            string state = null,
            Models.Address shippingAddress = null,
            Models.V1Money subtotalMoney = null,
            Models.V1Money totalShippingMoney = null,
            Models.V1Money totalTaxMoney = null,
            Models.V1Money totalPriceMoney = null,
            Models.V1Money totalDiscountMoney = null,
            string createdAt = null,
            string updatedAt = null,
            string expiresAt = null,
            string paymentId = null,
            string buyerNote = null,
            string completedNote = null,
            string refundedNote = null,
            string canceledNote = null,
            Models.V1Tender tender = null,
            IList<Models.V1OrderHistoryEntry> orderHistory = null,
            string promoCode = null,
            string btcReceiveAddress = null,
            double? btcPriceSatoshi = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "errors", false },
                { "buyer_email", false },
                { "recipient_name", false },
                { "recipient_phone_number", false },
                { "expires_at", false },
                { "payment_id", false },
                { "buyer_note", false },
                { "completed_note", false },
                { "refunded_note", false },
                { "canceled_note", false },
                { "order_history", false },
                { "promo_code", false },
                { "btc_receive_address", false },
                { "btc_price_satoshi", false }
            };

            if (errors != null)
            {
                shouldSerialize["errors"] = true;
                this.Errors = errors;
            }

            this.Id = id;
            if (buyerEmail != null)
            {
                shouldSerialize["buyer_email"] = true;
                this.BuyerEmail = buyerEmail;
            }

            if (recipientName != null)
            {
                shouldSerialize["recipient_name"] = true;
                this.RecipientName = recipientName;
            }

            if (recipientPhoneNumber != null)
            {
                shouldSerialize["recipient_phone_number"] = true;
                this.RecipientPhoneNumber = recipientPhoneNumber;
            }

            this.State = state;
            this.ShippingAddress = shippingAddress;
            this.SubtotalMoney = subtotalMoney;
            this.TotalShippingMoney = totalShippingMoney;
            this.TotalTaxMoney = totalTaxMoney;
            this.TotalPriceMoney = totalPriceMoney;
            this.TotalDiscountMoney = totalDiscountMoney;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            if (expiresAt != null)
            {
                shouldSerialize["expires_at"] = true;
                this.ExpiresAt = expiresAt;
            }

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            if (buyerNote != null)
            {
                shouldSerialize["buyer_note"] = true;
                this.BuyerNote = buyerNote;
            }

            if (completedNote != null)
            {
                shouldSerialize["completed_note"] = true;
                this.CompletedNote = completedNote;
            }

            if (refundedNote != null)
            {
                shouldSerialize["refunded_note"] = true;
                this.RefundedNote = refundedNote;
            }

            if (canceledNote != null)
            {
                shouldSerialize["canceled_note"] = true;
                this.CanceledNote = canceledNote;
            }

            this.Tender = tender;
            if (orderHistory != null)
            {
                shouldSerialize["order_history"] = true;
                this.OrderHistory = orderHistory;
            }

            if (promoCode != null)
            {
                shouldSerialize["promo_code"] = true;
                this.PromoCode = promoCode;
            }

            if (btcReceiveAddress != null)
            {
                shouldSerialize["btc_receive_address"] = true;
                this.BtcReceiveAddress = btcReceiveAddress;
            }

            if (btcPriceSatoshi != null)
            {
                shouldSerialize["btc_price_satoshi"] = true;
                this.BtcPriceSatoshi = btcPriceSatoshi;
            }

        }
        internal V1Order(Dictionary<string, bool> shouldSerialize,
            IList<Models.Error> errors = null,
            string id = null,
            string buyerEmail = null,
            string recipientName = null,
            string recipientPhoneNumber = null,
            string state = null,
            Models.Address shippingAddress = null,
            Models.V1Money subtotalMoney = null,
            Models.V1Money totalShippingMoney = null,
            Models.V1Money totalTaxMoney = null,
            Models.V1Money totalPriceMoney = null,
            Models.V1Money totalDiscountMoney = null,
            string createdAt = null,
            string updatedAt = null,
            string expiresAt = null,
            string paymentId = null,
            string buyerNote = null,
            string completedNote = null,
            string refundedNote = null,
            string canceledNote = null,
            Models.V1Tender tender = null,
            IList<Models.V1OrderHistoryEntry> orderHistory = null,
            string promoCode = null,
            string btcReceiveAddress = null,
            double? btcPriceSatoshi = null)
        {
            this.shouldSerialize = shouldSerialize;
            Errors = errors;
            Id = id;
            BuyerEmail = buyerEmail;
            RecipientName = recipientName;
            RecipientPhoneNumber = recipientPhoneNumber;
            State = state;
            ShippingAddress = shippingAddress;
            SubtotalMoney = subtotalMoney;
            TotalShippingMoney = totalShippingMoney;
            TotalTaxMoney = totalTaxMoney;
            TotalPriceMoney = totalPriceMoney;
            TotalDiscountMoney = totalDiscountMoney;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ExpiresAt = expiresAt;
            PaymentId = paymentId;
            BuyerNote = buyerNote;
            CompletedNote = completedNote;
            RefundedNote = refundedNote;
            CanceledNote = canceledNote;
            Tender = tender;
            OrderHistory = orderHistory;
            PromoCode = promoCode;
            BtcReceiveAddress = btcReceiveAddress;
            BtcPriceSatoshi = btcPriceSatoshi;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The order's unique identifier.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The email address of the order's buyer.
        /// </summary>
        [JsonProperty("buyer_email")]
        public string BuyerEmail { get; }

        /// <summary>
        /// The name of the order's buyer.
        /// </summary>
        [JsonProperty("recipient_name")]
        public string RecipientName { get; }

        /// <summary>
        /// The phone number to use for the order's delivery.
        /// </summary>
        [JsonProperty("recipient_phone_number")]
        public string RecipientPhoneNumber { get; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address ShippingAddress { get; }

        /// <summary>
        /// Gets or sets SubtotalMoney.
        /// </summary>
        [JsonProperty("subtotal_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SubtotalMoney { get; }

        /// <summary>
        /// Gets or sets TotalShippingMoney.
        /// </summary>
        [JsonProperty("total_shipping_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalShippingMoney { get; }

        /// <summary>
        /// Gets or sets TotalTaxMoney.
        /// </summary>
        [JsonProperty("total_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalTaxMoney { get; }

        /// <summary>
        /// Gets or sets TotalPriceMoney.
        /// </summary>
        [JsonProperty("total_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalPriceMoney { get; }

        /// <summary>
        /// Gets or sets TotalDiscountMoney.
        /// </summary>
        [JsonProperty("total_discount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalDiscountMoney { get; }

        /// <summary>
        /// The time when the order was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the order was last modified, in ISO 8601 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The time when the order expires if no action is taken, in ISO 8601 format.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; }

        /// <summary>
        /// The unique identifier of the payment associated with the order.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// A note provided by the buyer when the order was created, if any.
        /// </summary>
        [JsonProperty("buyer_note")]
        public string BuyerNote { get; }

        /// <summary>
        /// A note provided by the merchant when the order's state was set to COMPLETED, if any
        /// </summary>
        [JsonProperty("completed_note")]
        public string CompletedNote { get; }

        /// <summary>
        /// A note provided by the merchant when the order's state was set to REFUNDED, if any.
        /// </summary>
        [JsonProperty("refunded_note")]
        public string RefundedNote { get; }

        /// <summary>
        /// A note provided by the merchant when the order's state was set to CANCELED, if any.
        /// </summary>
        [JsonProperty("canceled_note")]
        public string CanceledNote { get; }

        /// <summary>
        /// A tender represents a discrete monetary exchange. Square represents this
        /// exchange as a money object with a specific currency and amount, where the
        /// amount is given in the smallest denomination of the given currency.
        /// Square POS can accept more than one form of tender for a single payment (such
        /// as by splitting a bill between a credit card and a gift card). The `tender`
        /// field of the Payment object lists all forms of tender used for the payment.
        /// Split tender payments behave slightly differently from single tender payments:
        /// The receipt_url for a split tender corresponds only to the first tender listed
        /// in the tender field. To get the receipt URLs for the remaining tenders, use
        /// the receipt_url fields of the corresponding Tender objects.
        /// *A note on gift cards**: when a customer purchases a Square gift card from a
        /// merchant, the merchant receives the full amount of the gift card in the
        /// associated payment.
        /// When that gift card is used as a tender, the balance of the gift card is
        /// reduced and the merchant receives no funds. A `Tender` object with a type of
        /// `SQUARE_GIFT_CARD` indicates a gift card was used for some or all of the
        /// associated payment.
        /// </summary>
        [JsonProperty("tender", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Tender Tender { get; }

        /// <summary>
        /// The history of actions associated with the order.
        /// </summary>
        [JsonProperty("order_history")]
        public IList<Models.V1OrderHistoryEntry> OrderHistory { get; }

        /// <summary>
        /// The promo code provided by the buyer, if any.
        /// </summary>
        [JsonProperty("promo_code")]
        public string PromoCode { get; }

        /// <summary>
        /// For Bitcoin transactions, the address that the buyer sent Bitcoin to.
        /// </summary>
        [JsonProperty("btc_receive_address")]
        public string BtcReceiveAddress { get; }

        /// <summary>
        /// For Bitcoin transactions, the price of the buyer's order in satoshi (100 million satoshi equals 1 BTC).
        /// </summary>
        [JsonProperty("btc_price_satoshi")]
        public double? BtcPriceSatoshi { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Order : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeErrors()
        {
            return this.shouldSerialize["errors"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerEmail()
        {
            return this.shouldSerialize["buyer_email"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecipientName()
        {
            return this.shouldSerialize["recipient_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRecipientPhoneNumber()
        {
            return this.shouldSerialize["recipient_phone_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpiresAt()
        {
            return this.shouldSerialize["expires_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBuyerNote()
        {
            return this.shouldSerialize["buyer_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCompletedNote()
        {
            return this.shouldSerialize["completed_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRefundedNote()
        {
            return this.shouldSerialize["refunded_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCanceledNote()
        {
            return this.shouldSerialize["canceled_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderHistory()
        {
            return this.shouldSerialize["order_history"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePromoCode()
        {
            return this.shouldSerialize["promo_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBtcReceiveAddress()
        {
            return this.shouldSerialize["btc_receive_address"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBtcPriceSatoshi()
        {
            return this.shouldSerialize["btc_price_satoshi"];
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

            return obj is V1Order other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.BuyerEmail == null && other.BuyerEmail == null) || (this.BuyerEmail?.Equals(other.BuyerEmail) == true)) &&
                ((this.RecipientName == null && other.RecipientName == null) || (this.RecipientName?.Equals(other.RecipientName) == true)) &&
                ((this.RecipientPhoneNumber == null && other.RecipientPhoneNumber == null) || (this.RecipientPhoneNumber?.Equals(other.RecipientPhoneNumber) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.ShippingAddress == null && other.ShippingAddress == null) || (this.ShippingAddress?.Equals(other.ShippingAddress) == true)) &&
                ((this.SubtotalMoney == null && other.SubtotalMoney == null) || (this.SubtotalMoney?.Equals(other.SubtotalMoney) == true)) &&
                ((this.TotalShippingMoney == null && other.TotalShippingMoney == null) || (this.TotalShippingMoney?.Equals(other.TotalShippingMoney) == true)) &&
                ((this.TotalTaxMoney == null && other.TotalTaxMoney == null) || (this.TotalTaxMoney?.Equals(other.TotalTaxMoney) == true)) &&
                ((this.TotalPriceMoney == null && other.TotalPriceMoney == null) || (this.TotalPriceMoney?.Equals(other.TotalPriceMoney) == true)) &&
                ((this.TotalDiscountMoney == null && other.TotalDiscountMoney == null) || (this.TotalDiscountMoney?.Equals(other.TotalDiscountMoney) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.ExpiresAt == null && other.ExpiresAt == null) || (this.ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.BuyerNote == null && other.BuyerNote == null) || (this.BuyerNote?.Equals(other.BuyerNote) == true)) &&
                ((this.CompletedNote == null && other.CompletedNote == null) || (this.CompletedNote?.Equals(other.CompletedNote) == true)) &&
                ((this.RefundedNote == null && other.RefundedNote == null) || (this.RefundedNote?.Equals(other.RefundedNote) == true)) &&
                ((this.CanceledNote == null && other.CanceledNote == null) || (this.CanceledNote?.Equals(other.CanceledNote) == true)) &&
                ((this.Tender == null && other.Tender == null) || (this.Tender?.Equals(other.Tender) == true)) &&
                ((this.OrderHistory == null && other.OrderHistory == null) || (this.OrderHistory?.Equals(other.OrderHistory) == true)) &&
                ((this.PromoCode == null && other.PromoCode == null) || (this.PromoCode?.Equals(other.PromoCode) == true)) &&
                ((this.BtcReceiveAddress == null && other.BtcReceiveAddress == null) || (this.BtcReceiveAddress?.Equals(other.BtcReceiveAddress) == true)) &&
                ((this.BtcPriceSatoshi == null && other.BtcPriceSatoshi == null) || (this.BtcPriceSatoshi?.Equals(other.BtcPriceSatoshi) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 820864276;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Id, this.BuyerEmail, this.RecipientName, this.RecipientPhoneNumber, this.State, this.ShippingAddress);

            hashCode = HashCode.Combine(hashCode, this.SubtotalMoney, this.TotalShippingMoney, this.TotalTaxMoney, this.TotalPriceMoney, this.TotalDiscountMoney, this.CreatedAt, this.UpdatedAt);

            hashCode = HashCode.Combine(hashCode, this.ExpiresAt, this.PaymentId, this.BuyerNote, this.CompletedNote, this.RefundedNote, this.CanceledNote, this.Tender);

            hashCode = HashCode.Combine(hashCode, this.OrderHistory, this.PromoCode, this.BtcReceiveAddress, this.BtcPriceSatoshi);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.BuyerEmail = {(this.BuyerEmail == null ? "null" : this.BuyerEmail == string.Empty ? "" : this.BuyerEmail)}");
            toStringOutput.Add($"this.RecipientName = {(this.RecipientName == null ? "null" : this.RecipientName == string.Empty ? "" : this.RecipientName)}");
            toStringOutput.Add($"this.RecipientPhoneNumber = {(this.RecipientPhoneNumber == null ? "null" : this.RecipientPhoneNumber == string.Empty ? "" : this.RecipientPhoneNumber)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.ShippingAddress = {(this.ShippingAddress == null ? "null" : this.ShippingAddress.ToString())}");
            toStringOutput.Add($"this.SubtotalMoney = {(this.SubtotalMoney == null ? "null" : this.SubtotalMoney.ToString())}");
            toStringOutput.Add($"this.TotalShippingMoney = {(this.TotalShippingMoney == null ? "null" : this.TotalShippingMoney.ToString())}");
            toStringOutput.Add($"this.TotalTaxMoney = {(this.TotalTaxMoney == null ? "null" : this.TotalTaxMoney.ToString())}");
            toStringOutput.Add($"this.TotalPriceMoney = {(this.TotalPriceMoney == null ? "null" : this.TotalPriceMoney.ToString())}");
            toStringOutput.Add($"this.TotalDiscountMoney = {(this.TotalDiscountMoney == null ? "null" : this.TotalDiscountMoney.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.ExpiresAt = {(this.ExpiresAt == null ? "null" : this.ExpiresAt == string.Empty ? "" : this.ExpiresAt)}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.BuyerNote = {(this.BuyerNote == null ? "null" : this.BuyerNote == string.Empty ? "" : this.BuyerNote)}");
            toStringOutput.Add($"this.CompletedNote = {(this.CompletedNote == null ? "null" : this.CompletedNote == string.Empty ? "" : this.CompletedNote)}");
            toStringOutput.Add($"this.RefundedNote = {(this.RefundedNote == null ? "null" : this.RefundedNote == string.Empty ? "" : this.RefundedNote)}");
            toStringOutput.Add($"this.CanceledNote = {(this.CanceledNote == null ? "null" : this.CanceledNote == string.Empty ? "" : this.CanceledNote)}");
            toStringOutput.Add($"this.Tender = {(this.Tender == null ? "null" : this.Tender.ToString())}");
            toStringOutput.Add($"this.OrderHistory = {(this.OrderHistory == null ? "null" : $"[{string.Join(", ", this.OrderHistory)} ]")}");
            toStringOutput.Add($"this.PromoCode = {(this.PromoCode == null ? "null" : this.PromoCode == string.Empty ? "" : this.PromoCode)}");
            toStringOutput.Add($"this.BtcReceiveAddress = {(this.BtcReceiveAddress == null ? "null" : this.BtcReceiveAddress == string.Empty ? "" : this.BtcReceiveAddress)}");
            toStringOutput.Add($"this.BtcPriceSatoshi = {(this.BtcPriceSatoshi == null ? "null" : this.BtcPriceSatoshi.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Id(this.Id)
                .BuyerEmail(this.BuyerEmail)
                .RecipientName(this.RecipientName)
                .RecipientPhoneNumber(this.RecipientPhoneNumber)
                .State(this.State)
                .ShippingAddress(this.ShippingAddress)
                .SubtotalMoney(this.SubtotalMoney)
                .TotalShippingMoney(this.TotalShippingMoney)
                .TotalTaxMoney(this.TotalTaxMoney)
                .TotalPriceMoney(this.TotalPriceMoney)
                .TotalDiscountMoney(this.TotalDiscountMoney)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .ExpiresAt(this.ExpiresAt)
                .PaymentId(this.PaymentId)
                .BuyerNote(this.BuyerNote)
                .CompletedNote(this.CompletedNote)
                .RefundedNote(this.RefundedNote)
                .CanceledNote(this.CanceledNote)
                .Tender(this.Tender)
                .OrderHistory(this.OrderHistory)
                .PromoCode(this.PromoCode)
                .BtcReceiveAddress(this.BtcReceiveAddress)
                .BtcPriceSatoshi(this.BtcPriceSatoshi);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "errors", false },
                { "buyer_email", false },
                { "recipient_name", false },
                { "recipient_phone_number", false },
                { "expires_at", false },
                { "payment_id", false },
                { "buyer_note", false },
                { "completed_note", false },
                { "refunded_note", false },
                { "canceled_note", false },
                { "order_history", false },
                { "promo_code", false },
                { "btc_receive_address", false },
                { "btc_price_satoshi", false },
            };

            private IList<Models.Error> errors;
            private string id;
            private string buyerEmail;
            private string recipientName;
            private string recipientPhoneNumber;
            private string state;
            private Models.Address shippingAddress;
            private Models.V1Money subtotalMoney;
            private Models.V1Money totalShippingMoney;
            private Models.V1Money totalTaxMoney;
            private Models.V1Money totalPriceMoney;
            private Models.V1Money totalDiscountMoney;
            private string createdAt;
            private string updatedAt;
            private string expiresAt;
            private string paymentId;
            private string buyerNote;
            private string completedNote;
            private string refundedNote;
            private string canceledNote;
            private Models.V1Tender tender;
            private IList<Models.V1OrderHistoryEntry> orderHistory;
            private string promoCode;
            private string btcReceiveAddress;
            private double? btcPriceSatoshi;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                shouldSerialize["errors"] = true;
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// BuyerEmail.
             /// </summary>
             /// <param name="buyerEmail"> buyerEmail. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerEmail(string buyerEmail)
            {
                shouldSerialize["buyer_email"] = true;
                this.buyerEmail = buyerEmail;
                return this;
            }

             /// <summary>
             /// RecipientName.
             /// </summary>
             /// <param name="recipientName"> recipientName. </param>
             /// <returns> Builder. </returns>
            public Builder RecipientName(string recipientName)
            {
                shouldSerialize["recipient_name"] = true;
                this.recipientName = recipientName;
                return this;
            }

             /// <summary>
             /// RecipientPhoneNumber.
             /// </summary>
             /// <param name="recipientPhoneNumber"> recipientPhoneNumber. </param>
             /// <returns> Builder. </returns>
            public Builder RecipientPhoneNumber(string recipientPhoneNumber)
            {
                shouldSerialize["recipient_phone_number"] = true;
                this.recipientPhoneNumber = recipientPhoneNumber;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

             /// <summary>
             /// ShippingAddress.
             /// </summary>
             /// <param name="shippingAddress"> shippingAddress. </param>
             /// <returns> Builder. </returns>
            public Builder ShippingAddress(Models.Address shippingAddress)
            {
                this.shippingAddress = shippingAddress;
                return this;
            }

             /// <summary>
             /// SubtotalMoney.
             /// </summary>
             /// <param name="subtotalMoney"> subtotalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder SubtotalMoney(Models.V1Money subtotalMoney)
            {
                this.subtotalMoney = subtotalMoney;
                return this;
            }

             /// <summary>
             /// TotalShippingMoney.
             /// </summary>
             /// <param name="totalShippingMoney"> totalShippingMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalShippingMoney(Models.V1Money totalShippingMoney)
            {
                this.totalShippingMoney = totalShippingMoney;
                return this;
            }

             /// <summary>
             /// TotalTaxMoney.
             /// </summary>
             /// <param name="totalTaxMoney"> totalTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalTaxMoney(Models.V1Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

             /// <summary>
             /// TotalPriceMoney.
             /// </summary>
             /// <param name="totalPriceMoney"> totalPriceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalPriceMoney(Models.V1Money totalPriceMoney)
            {
                this.totalPriceMoney = totalPriceMoney;
                return this;
            }

             /// <summary>
             /// TotalDiscountMoney.
             /// </summary>
             /// <param name="totalDiscountMoney"> totalDiscountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalDiscountMoney(Models.V1Money totalDiscountMoney)
            {
                this.totalDiscountMoney = totalDiscountMoney;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// ExpiresAt.
             /// </summary>
             /// <param name="expiresAt"> expiresAt. </param>
             /// <returns> Builder. </returns>
            public Builder ExpiresAt(string expiresAt)
            {
                shouldSerialize["expires_at"] = true;
                this.expiresAt = expiresAt;
                return this;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                shouldSerialize["payment_id"] = true;
                this.paymentId = paymentId;
                return this;
            }

             /// <summary>
             /// BuyerNote.
             /// </summary>
             /// <param name="buyerNote"> buyerNote. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerNote(string buyerNote)
            {
                shouldSerialize["buyer_note"] = true;
                this.buyerNote = buyerNote;
                return this;
            }

             /// <summary>
             /// CompletedNote.
             /// </summary>
             /// <param name="completedNote"> completedNote. </param>
             /// <returns> Builder. </returns>
            public Builder CompletedNote(string completedNote)
            {
                shouldSerialize["completed_note"] = true;
                this.completedNote = completedNote;
                return this;
            }

             /// <summary>
             /// RefundedNote.
             /// </summary>
             /// <param name="refundedNote"> refundedNote. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedNote(string refundedNote)
            {
                shouldSerialize["refunded_note"] = true;
                this.refundedNote = refundedNote;
                return this;
            }

             /// <summary>
             /// CanceledNote.
             /// </summary>
             /// <param name="canceledNote"> canceledNote. </param>
             /// <returns> Builder. </returns>
            public Builder CanceledNote(string canceledNote)
            {
                shouldSerialize["canceled_note"] = true;
                this.canceledNote = canceledNote;
                return this;
            }

             /// <summary>
             /// Tender.
             /// </summary>
             /// <param name="tender"> tender. </param>
             /// <returns> Builder. </returns>
            public Builder Tender(Models.V1Tender tender)
            {
                this.tender = tender;
                return this;
            }

             /// <summary>
             /// OrderHistory.
             /// </summary>
             /// <param name="orderHistory"> orderHistory. </param>
             /// <returns> Builder. </returns>
            public Builder OrderHistory(IList<Models.V1OrderHistoryEntry> orderHistory)
            {
                shouldSerialize["order_history"] = true;
                this.orderHistory = orderHistory;
                return this;
            }

             /// <summary>
             /// PromoCode.
             /// </summary>
             /// <param name="promoCode"> promoCode. </param>
             /// <returns> Builder. </returns>
            public Builder PromoCode(string promoCode)
            {
                shouldSerialize["promo_code"] = true;
                this.promoCode = promoCode;
                return this;
            }

             /// <summary>
             /// BtcReceiveAddress.
             /// </summary>
             /// <param name="btcReceiveAddress"> btcReceiveAddress. </param>
             /// <returns> Builder. </returns>
            public Builder BtcReceiveAddress(string btcReceiveAddress)
            {
                shouldSerialize["btc_receive_address"] = true;
                this.btcReceiveAddress = btcReceiveAddress;
                return this;
            }

             /// <summary>
             /// BtcPriceSatoshi.
             /// </summary>
             /// <param name="btcPriceSatoshi"> btcPriceSatoshi. </param>
             /// <returns> Builder. </returns>
            public Builder BtcPriceSatoshi(double? btcPriceSatoshi)
            {
                shouldSerialize["btc_price_satoshi"] = true;
                this.btcPriceSatoshi = btcPriceSatoshi;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetErrors()
            {
                this.shouldSerialize["errors"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBuyerEmail()
            {
                this.shouldSerialize["buyer_email"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRecipientName()
            {
                this.shouldSerialize["recipient_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRecipientPhoneNumber()
            {
                this.shouldSerialize["recipient_phone_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExpiresAt()
            {
                this.shouldSerialize["expires_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBuyerNote()
            {
                this.shouldSerialize["buyer_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCompletedNote()
            {
                this.shouldSerialize["completed_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRefundedNote()
            {
                this.shouldSerialize["refunded_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCanceledNote()
            {
                this.shouldSerialize["canceled_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrderHistory()
            {
                this.shouldSerialize["order_history"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPromoCode()
            {
                this.shouldSerialize["promo_code"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBtcReceiveAddress()
            {
                this.shouldSerialize["btc_receive_address"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBtcPriceSatoshi()
            {
                this.shouldSerialize["btc_price_satoshi"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1Order. </returns>
            public V1Order Build()
            {
                return new V1Order(shouldSerialize,
                    this.errors,
                    this.id,
                    this.buyerEmail,
                    this.recipientName,
                    this.recipientPhoneNumber,
                    this.state,
                    this.shippingAddress,
                    this.subtotalMoney,
                    this.totalShippingMoney,
                    this.totalTaxMoney,
                    this.totalPriceMoney,
                    this.totalDiscountMoney,
                    this.createdAt,
                    this.updatedAt,
                    this.expiresAt,
                    this.paymentId,
                    this.buyerNote,
                    this.completedNote,
                    this.refundedNote,
                    this.canceledNote,
                    this.tender,
                    this.orderHistory,
                    this.promoCode,
                    this.btcReceiveAddress,
                    this.btcPriceSatoshi);
            }
        }
    }
}