
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Order 
    {
        public V1Order(IList<Models.Error> errors = null,
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

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The order's unique identifier.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The email address of the order's buyer.
        /// </summary>
        [JsonProperty("buyer_email", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerEmail { get; }

        /// <summary>
        /// The name of the order's buyer.
        /// </summary>
        [JsonProperty("recipient_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientName { get; }

        /// <summary>
        /// The phone number to use for the order's delivery.
        /// </summary>
        [JsonProperty("recipient_phone_number", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientPhoneNumber { get; }

        /// <summary>
        /// Getter for state
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address ShippingAddress { get; }

        /// <summary>
        /// Getter for subtotal_money
        /// </summary>
        [JsonProperty("subtotal_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money SubtotalMoney { get; }

        /// <summary>
        /// Getter for total_shipping_money
        /// </summary>
        [JsonProperty("total_shipping_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalShippingMoney { get; }

        /// <summary>
        /// Getter for total_tax_money
        /// </summary>
        [JsonProperty("total_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalTaxMoney { get; }

        /// <summary>
        /// Getter for total_price_money
        /// </summary>
        [JsonProperty("total_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.V1Money TotalPriceMoney { get; }

        /// <summary>
        /// Getter for total_discount_money
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
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; }

        /// <summary>
        /// The unique identifier of the payment associated with the order.
        /// </summary>
        [JsonProperty("payment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentId { get; }

        /// <summary>
        /// A note provided by the buyer when the order was created, if any.
        /// </summary>
        [JsonProperty("buyer_note", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerNote { get; }

        /// <summary>
        /// A note provided by the merchant when the order's state was set to COMPLETED, if any
        /// </summary>
        [JsonProperty("completed_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CompletedNote { get; }

        /// <summary>
        /// A note provided by the merchant when the order's state was set to REFUNDED, if any.
        /// </summary>
        [JsonProperty("refunded_note", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundedNote { get; }

        /// <summary>
        /// A note provided by the merchant when the order's state was set to CANCELED, if any.
        /// </summary>
        [JsonProperty("canceled_note", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("order_history", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.V1OrderHistoryEntry> OrderHistory { get; }

        /// <summary>
        /// The promo code provided by the buyer, if any.
        /// </summary>
        [JsonProperty("promo_code", NullValueHandling = NullValueHandling.Ignore)]
        public string PromoCode { get; }

        /// <summary>
        /// For Bitcoin transactions, the address that the buyer sent Bitcoin to.
        /// </summary>
        [JsonProperty("btc_receive_address", NullValueHandling = NullValueHandling.Ignore)]
        public string BtcReceiveAddress { get; }

        /// <summary>
        /// For Bitcoin transactions, the price of the buyer's order in satoshi (100 million satoshi equals 1 BTC).
        /// </summary>
        [JsonProperty("btc_price_satoshi", NullValueHandling = NullValueHandling.Ignore)]
        public double? BtcPriceSatoshi { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1Order : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"BuyerEmail = {(BuyerEmail == null ? "null" : BuyerEmail == string.Empty ? "" : BuyerEmail)}");
            toStringOutput.Add($"RecipientName = {(RecipientName == null ? "null" : RecipientName == string.Empty ? "" : RecipientName)}");
            toStringOutput.Add($"RecipientPhoneNumber = {(RecipientPhoneNumber == null ? "null" : RecipientPhoneNumber == string.Empty ? "" : RecipientPhoneNumber)}");
            toStringOutput.Add($"State = {(State == null ? "null" : State.ToString())}");
            toStringOutput.Add($"ShippingAddress = {(ShippingAddress == null ? "null" : ShippingAddress.ToString())}");
            toStringOutput.Add($"SubtotalMoney = {(SubtotalMoney == null ? "null" : SubtotalMoney.ToString())}");
            toStringOutput.Add($"TotalShippingMoney = {(TotalShippingMoney == null ? "null" : TotalShippingMoney.ToString())}");
            toStringOutput.Add($"TotalTaxMoney = {(TotalTaxMoney == null ? "null" : TotalTaxMoney.ToString())}");
            toStringOutput.Add($"TotalPriceMoney = {(TotalPriceMoney == null ? "null" : TotalPriceMoney.ToString())}");
            toStringOutput.Add($"TotalDiscountMoney = {(TotalDiscountMoney == null ? "null" : TotalDiscountMoney.ToString())}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
            toStringOutput.Add($"ExpiresAt = {(ExpiresAt == null ? "null" : ExpiresAt == string.Empty ? "" : ExpiresAt)}");
            toStringOutput.Add($"PaymentId = {(PaymentId == null ? "null" : PaymentId == string.Empty ? "" : PaymentId)}");
            toStringOutput.Add($"BuyerNote = {(BuyerNote == null ? "null" : BuyerNote == string.Empty ? "" : BuyerNote)}");
            toStringOutput.Add($"CompletedNote = {(CompletedNote == null ? "null" : CompletedNote == string.Empty ? "" : CompletedNote)}");
            toStringOutput.Add($"RefundedNote = {(RefundedNote == null ? "null" : RefundedNote == string.Empty ? "" : RefundedNote)}");
            toStringOutput.Add($"CanceledNote = {(CanceledNote == null ? "null" : CanceledNote == string.Empty ? "" : CanceledNote)}");
            toStringOutput.Add($"Tender = {(Tender == null ? "null" : Tender.ToString())}");
            toStringOutput.Add($"OrderHistory = {(OrderHistory == null ? "null" : $"[{ string.Join(", ", OrderHistory)} ]")}");
            toStringOutput.Add($"PromoCode = {(PromoCode == null ? "null" : PromoCode == string.Empty ? "" : PromoCode)}");
            toStringOutput.Add($"BtcReceiveAddress = {(BtcReceiveAddress == null ? "null" : BtcReceiveAddress == string.Empty ? "" : BtcReceiveAddress)}");
            toStringOutput.Add($"BtcPriceSatoshi = {(BtcPriceSatoshi == null ? "null" : BtcPriceSatoshi.ToString())}");
        }

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
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((BuyerEmail == null && other.BuyerEmail == null) || (BuyerEmail?.Equals(other.BuyerEmail) == true)) &&
                ((RecipientName == null && other.RecipientName == null) || (RecipientName?.Equals(other.RecipientName) == true)) &&
                ((RecipientPhoneNumber == null && other.RecipientPhoneNumber == null) || (RecipientPhoneNumber?.Equals(other.RecipientPhoneNumber) == true)) &&
                ((State == null && other.State == null) || (State?.Equals(other.State) == true)) &&
                ((ShippingAddress == null && other.ShippingAddress == null) || (ShippingAddress?.Equals(other.ShippingAddress) == true)) &&
                ((SubtotalMoney == null && other.SubtotalMoney == null) || (SubtotalMoney?.Equals(other.SubtotalMoney) == true)) &&
                ((TotalShippingMoney == null && other.TotalShippingMoney == null) || (TotalShippingMoney?.Equals(other.TotalShippingMoney) == true)) &&
                ((TotalTaxMoney == null && other.TotalTaxMoney == null) || (TotalTaxMoney?.Equals(other.TotalTaxMoney) == true)) &&
                ((TotalPriceMoney == null && other.TotalPriceMoney == null) || (TotalPriceMoney?.Equals(other.TotalPriceMoney) == true)) &&
                ((TotalDiscountMoney == null && other.TotalDiscountMoney == null) || (TotalDiscountMoney?.Equals(other.TotalDiscountMoney) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((ExpiresAt == null && other.ExpiresAt == null) || (ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((PaymentId == null && other.PaymentId == null) || (PaymentId?.Equals(other.PaymentId) == true)) &&
                ((BuyerNote == null && other.BuyerNote == null) || (BuyerNote?.Equals(other.BuyerNote) == true)) &&
                ((CompletedNote == null && other.CompletedNote == null) || (CompletedNote?.Equals(other.CompletedNote) == true)) &&
                ((RefundedNote == null && other.RefundedNote == null) || (RefundedNote?.Equals(other.RefundedNote) == true)) &&
                ((CanceledNote == null && other.CanceledNote == null) || (CanceledNote?.Equals(other.CanceledNote) == true)) &&
                ((Tender == null && other.Tender == null) || (Tender?.Equals(other.Tender) == true)) &&
                ((OrderHistory == null && other.OrderHistory == null) || (OrderHistory?.Equals(other.OrderHistory) == true)) &&
                ((PromoCode == null && other.PromoCode == null) || (PromoCode?.Equals(other.PromoCode) == true)) &&
                ((BtcReceiveAddress == null && other.BtcReceiveAddress == null) || (BtcReceiveAddress?.Equals(other.BtcReceiveAddress) == true)) &&
                ((BtcPriceSatoshi == null && other.BtcPriceSatoshi == null) || (BtcPriceSatoshi?.Equals(other.BtcPriceSatoshi) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 820864276;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (BuyerEmail != null)
            {
               hashCode += BuyerEmail.GetHashCode();
            }

            if (RecipientName != null)
            {
               hashCode += RecipientName.GetHashCode();
            }

            if (RecipientPhoneNumber != null)
            {
               hashCode += RecipientPhoneNumber.GetHashCode();
            }

            if (State != null)
            {
               hashCode += State.GetHashCode();
            }

            if (ShippingAddress != null)
            {
               hashCode += ShippingAddress.GetHashCode();
            }

            if (SubtotalMoney != null)
            {
               hashCode += SubtotalMoney.GetHashCode();
            }

            if (TotalShippingMoney != null)
            {
               hashCode += TotalShippingMoney.GetHashCode();
            }

            if (TotalTaxMoney != null)
            {
               hashCode += TotalTaxMoney.GetHashCode();
            }

            if (TotalPriceMoney != null)
            {
               hashCode += TotalPriceMoney.GetHashCode();
            }

            if (TotalDiscountMoney != null)
            {
               hashCode += TotalDiscountMoney.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            if (ExpiresAt != null)
            {
               hashCode += ExpiresAt.GetHashCode();
            }

            if (PaymentId != null)
            {
               hashCode += PaymentId.GetHashCode();
            }

            if (BuyerNote != null)
            {
               hashCode += BuyerNote.GetHashCode();
            }

            if (CompletedNote != null)
            {
               hashCode += CompletedNote.GetHashCode();
            }

            if (RefundedNote != null)
            {
               hashCode += RefundedNote.GetHashCode();
            }

            if (CanceledNote != null)
            {
               hashCode += CanceledNote.GetHashCode();
            }

            if (Tender != null)
            {
               hashCode += Tender.GetHashCode();
            }

            if (OrderHistory != null)
            {
               hashCode += OrderHistory.GetHashCode();
            }

            if (PromoCode != null)
            {
               hashCode += PromoCode.GetHashCode();
            }

            if (BtcReceiveAddress != null)
            {
               hashCode += BtcReceiveAddress.GetHashCode();
            }

            if (BtcPriceSatoshi != null)
            {
               hashCode += BtcPriceSatoshi.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .Id(Id)
                .BuyerEmail(BuyerEmail)
                .RecipientName(RecipientName)
                .RecipientPhoneNumber(RecipientPhoneNumber)
                .State(State)
                .ShippingAddress(ShippingAddress)
                .SubtotalMoney(SubtotalMoney)
                .TotalShippingMoney(TotalShippingMoney)
                .TotalTaxMoney(TotalTaxMoney)
                .TotalPriceMoney(TotalPriceMoney)
                .TotalDiscountMoney(TotalDiscountMoney)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .ExpiresAt(ExpiresAt)
                .PaymentId(PaymentId)
                .BuyerNote(BuyerNote)
                .CompletedNote(CompletedNote)
                .RefundedNote(RefundedNote)
                .CanceledNote(CanceledNote)
                .Tender(Tender)
                .OrderHistory(OrderHistory)
                .PromoCode(PromoCode)
                .BtcReceiveAddress(BtcReceiveAddress)
                .BtcPriceSatoshi(BtcPriceSatoshi);
            return builder;
        }

        public class Builder
        {
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



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder BuyerEmail(string buyerEmail)
            {
                this.buyerEmail = buyerEmail;
                return this;
            }

            public Builder RecipientName(string recipientName)
            {
                this.recipientName = recipientName;
                return this;
            }

            public Builder RecipientPhoneNumber(string recipientPhoneNumber)
            {
                this.recipientPhoneNumber = recipientPhoneNumber;
                return this;
            }

            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

            public Builder ShippingAddress(Models.Address shippingAddress)
            {
                this.shippingAddress = shippingAddress;
                return this;
            }

            public Builder SubtotalMoney(Models.V1Money subtotalMoney)
            {
                this.subtotalMoney = subtotalMoney;
                return this;
            }

            public Builder TotalShippingMoney(Models.V1Money totalShippingMoney)
            {
                this.totalShippingMoney = totalShippingMoney;
                return this;
            }

            public Builder TotalTaxMoney(Models.V1Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

            public Builder TotalPriceMoney(Models.V1Money totalPriceMoney)
            {
                this.totalPriceMoney = totalPriceMoney;
                return this;
            }

            public Builder TotalDiscountMoney(Models.V1Money totalDiscountMoney)
            {
                this.totalDiscountMoney = totalDiscountMoney;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public Builder ExpiresAt(string expiresAt)
            {
                this.expiresAt = expiresAt;
                return this;
            }

            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

            public Builder BuyerNote(string buyerNote)
            {
                this.buyerNote = buyerNote;
                return this;
            }

            public Builder CompletedNote(string completedNote)
            {
                this.completedNote = completedNote;
                return this;
            }

            public Builder RefundedNote(string refundedNote)
            {
                this.refundedNote = refundedNote;
                return this;
            }

            public Builder CanceledNote(string canceledNote)
            {
                this.canceledNote = canceledNote;
                return this;
            }

            public Builder Tender(Models.V1Tender tender)
            {
                this.tender = tender;
                return this;
            }

            public Builder OrderHistory(IList<Models.V1OrderHistoryEntry> orderHistory)
            {
                this.orderHistory = orderHistory;
                return this;
            }

            public Builder PromoCode(string promoCode)
            {
                this.promoCode = promoCode;
                return this;
            }

            public Builder BtcReceiveAddress(string btcReceiveAddress)
            {
                this.btcReceiveAddress = btcReceiveAddress;
                return this;
            }

            public Builder BtcPriceSatoshi(double? btcPriceSatoshi)
            {
                this.btcPriceSatoshi = btcPriceSatoshi;
                return this;
            }

            public V1Order Build()
            {
                return new V1Order(errors,
                    id,
                    buyerEmail,
                    recipientName,
                    recipientPhoneNumber,
                    state,
                    shippingAddress,
                    subtotalMoney,
                    totalShippingMoney,
                    totalTaxMoney,
                    totalPriceMoney,
                    totalDiscountMoney,
                    createdAt,
                    updatedAt,
                    expiresAt,
                    paymentId,
                    buyerNote,
                    completedNote,
                    refundedNote,
                    canceledNote,
                    tender,
                    orderHistory,
                    promoCode,
                    btcReceiveAddress,
                    btcPriceSatoshi);
            }
        }
    }
}