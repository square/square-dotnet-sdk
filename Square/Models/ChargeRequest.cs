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
    /// ChargeRequest.
    /// </summary>
    public class ChargeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="cardNonce">card_nonce.</param>
        /// <param name="customerCardId">customer_card_id.</param>
        /// <param name="delayCapture">delay_capture.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="note">note.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="shippingAddress">shipping_address.</param>
        /// <param name="buyerEmailAddress">buyer_email_address.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="additionalRecipients">additional_recipients.</param>
        /// <param name="verificationToken">verification_token.</param>
        public ChargeRequest(
            string idempotencyKey,
            Models.Money amountMoney,
            string cardNonce = null,
            string customerCardId = null,
            bool? delayCapture = null,
            string referenceId = null,
            string note = null,
            string customerId = null,
            Models.Address billingAddress = null,
            Models.Address shippingAddress = null,
            string buyerEmailAddress = null,
            string orderId = null,
            IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients = null,
            string verificationToken = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.AmountMoney = amountMoney;
            this.CardNonce = cardNonce;
            this.CustomerCardId = customerCardId;
            this.DelayCapture = delayCapture;
            this.ReferenceId = referenceId;
            this.Note = note;
            this.CustomerId = customerId;
            this.BillingAddress = billingAddress;
            this.ShippingAddress = shippingAddress;
            this.BuyerEmailAddress = buyerEmailAddress;
            this.OrderId = orderId;
            this.AdditionalRecipients = additionalRecipients;
            this.VerificationToken = verificationToken;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// transaction among transactions you've created.
        /// If you're unsure whether a particular transaction succeeded,
        /// you can reattempt it with the same idempotency key without
        /// worrying about double-charging the buyer.
        /// See [Idempotency keys](https://developer.squareup.com/docs/working-with-apis/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

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
        /// A payment token generated from the [Card.tokenize()](https://developer.squareup.com/reference/sdks/web/payments/objects/Card#Card.tokenize) that represents the card
        /// to charge.
        /// The application that provides a payment token to this endpoint must be the
        /// _same application_ that generated the payment token with the Web Payments SDK.
        /// Otherwise, the nonce is invalid.
        /// Do not provide a value for this field if you provide a value for
        /// `customer_card_id`.
        /// </summary>
        [JsonProperty("card_nonce", NullValueHandling = NullValueHandling.Ignore)]
        public string CardNonce { get; }

        /// <summary>
        /// The ID of the customer card on file to charge. Do
        /// not provide a value for this field if you provide a value for `card_nonce`.
        /// If you provide this value, you _must_ also provide a value for
        /// `customer_id`.
        /// </summary>
        [JsonProperty("customer_card_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerCardId { get; }

        /// <summary>
        /// If `true`, the request will only perform an Auth on the provided
        /// card. You can then later perform either a Capture (with the
        /// [CaptureTransaction]($e/Transactions/CaptureTransaction) endpoint) or a Void
        /// (with the [VoidTransaction]($e/Transactions/VoidTransaction) endpoint).
        /// Default value: `false`
        /// </summary>
        [JsonProperty("delay_capture", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DelayCapture { get; }

        /// <summary>
        /// An optional ID you can associate with the transaction for your own
        /// purposes (such as to associate the transaction with an entity ID in your
        /// own database).
        /// This value cannot exceed 40 characters.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// An optional note to associate with the transaction.
        /// This value cannot exceed 60 characters.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The ID of the customer to associate this transaction with. This field
        /// is required if you provide a value for `customer_card_id`, and optional
        /// otherwise.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address BillingAddress { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address ShippingAddress { get; }

        /// <summary>
        /// The buyer's email address, if available. This value is optional,
        /// but this transaction is ineligible for chargeback protection if it is not
        /// provided.
        /// </summary>
        [JsonProperty("buyer_email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerEmailAddress { get; }

        /// <summary>
        /// The ID of the order to associate with this transaction.
        /// If you provide this value, the `amount_money` value of your request must
        /// __exactly match__ the value of the order's `total_money` field.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// The basic primitive of multi-party transaction. The value is optional.
        /// The transaction facilitated by you can be split from here.
        /// If you provide this value, the `amount_money` value in your additional_recipients
        /// must not be more than 90% of the `amount_money` value in the charge request.
        /// The `location_id` must be the valid location of the app owner merchant.
        /// This field requires the `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission.
        /// This field is currently not supported in sandbox.
        /// </summary>
        [JsonProperty("additional_recipients", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.ChargeRequestAdditionalRecipient> AdditionalRecipients { get; }

        /// <summary>
        /// A token generated by SqPaymentForm's verifyBuyer() that represents
        /// customer's device info and 3ds challenge result.
        /// </summary>
        [JsonProperty("verification_token", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ChargeRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ChargeRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.CardNonce == null && other.CardNonce == null) || (this.CardNonce?.Equals(other.CardNonce) == true)) &&
                ((this.CustomerCardId == null && other.CustomerCardId == null) || (this.CustomerCardId?.Equals(other.CustomerCardId) == true)) &&
                ((this.DelayCapture == null && other.DelayCapture == null) || (this.DelayCapture?.Equals(other.DelayCapture) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.ShippingAddress == null && other.ShippingAddress == null) || (this.ShippingAddress?.Equals(other.ShippingAddress) == true)) &&
                ((this.BuyerEmailAddress == null && other.BuyerEmailAddress == null) || (this.BuyerEmailAddress?.Equals(other.BuyerEmailAddress) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.AdditionalRecipients == null && other.AdditionalRecipients == null) || (this.AdditionalRecipients?.Equals(other.AdditionalRecipients) == true)) &&
                ((this.VerificationToken == null && other.VerificationToken == null) || (this.VerificationToken?.Equals(other.VerificationToken) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 851688088;

            if (this.IdempotencyKey != null)
            {
               hashCode += this.IdempotencyKey.GetHashCode();
            }

            if (this.AmountMoney != null)
            {
               hashCode += this.AmountMoney.GetHashCode();
            }

            if (this.CardNonce != null)
            {
               hashCode += this.CardNonce.GetHashCode();
            }

            if (this.CustomerCardId != null)
            {
               hashCode += this.CustomerCardId.GetHashCode();
            }

            if (this.DelayCapture != null)
            {
               hashCode += this.DelayCapture.GetHashCode();
            }

            if (this.ReferenceId != null)
            {
               hashCode += this.ReferenceId.GetHashCode();
            }

            if (this.Note != null)
            {
               hashCode += this.Note.GetHashCode();
            }

            if (this.CustomerId != null)
            {
               hashCode += this.CustomerId.GetHashCode();
            }

            if (this.BillingAddress != null)
            {
               hashCode += this.BillingAddress.GetHashCode();
            }

            if (this.ShippingAddress != null)
            {
               hashCode += this.ShippingAddress.GetHashCode();
            }

            if (this.BuyerEmailAddress != null)
            {
               hashCode += this.BuyerEmailAddress.GetHashCode();
            }

            if (this.OrderId != null)
            {
               hashCode += this.OrderId.GetHashCode();
            }

            if (this.AdditionalRecipients != null)
            {
               hashCode += this.AdditionalRecipients.GetHashCode();
            }

            if (this.VerificationToken != null)
            {
               hashCode += this.VerificationToken.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.CardNonce = {(this.CardNonce == null ? "null" : this.CardNonce == string.Empty ? "" : this.CardNonce)}");
            toStringOutput.Add($"this.CustomerCardId = {(this.CustomerCardId == null ? "null" : this.CustomerCardId == string.Empty ? "" : this.CustomerCardId)}");
            toStringOutput.Add($"this.DelayCapture = {(this.DelayCapture == null ? "null" : this.DelayCapture.ToString())}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.ShippingAddress = {(this.ShippingAddress == null ? "null" : this.ShippingAddress.ToString())}");
            toStringOutput.Add($"this.BuyerEmailAddress = {(this.BuyerEmailAddress == null ? "null" : this.BuyerEmailAddress == string.Empty ? "" : this.BuyerEmailAddress)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.AdditionalRecipients = {(this.AdditionalRecipients == null ? "null" : $"[{string.Join(", ", this.AdditionalRecipients)} ]")}");
            toStringOutput.Add($"this.VerificationToken = {(this.VerificationToken == null ? "null" : this.VerificationToken == string.Empty ? "" : this.VerificationToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey,
                this.AmountMoney)
                .CardNonce(this.CardNonce)
                .CustomerCardId(this.CustomerCardId)
                .DelayCapture(this.DelayCapture)
                .ReferenceId(this.ReferenceId)
                .Note(this.Note)
                .CustomerId(this.CustomerId)
                .BillingAddress(this.BillingAddress)
                .ShippingAddress(this.ShippingAddress)
                .BuyerEmailAddress(this.BuyerEmailAddress)
                .OrderId(this.OrderId)
                .AdditionalRecipients(this.AdditionalRecipients)
                .VerificationToken(this.VerificationToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private Models.Money amountMoney;
            private string cardNonce;
            private string customerCardId;
            private bool? delayCapture;
            private string referenceId;
            private string note;
            private string customerId;
            private Models.Address billingAddress;
            private Models.Address shippingAddress;
            private string buyerEmailAddress;
            private string orderId;
            private IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients;
            private string verificationToken;

            public Builder(
                string idempotencyKey,
                Models.Money amountMoney)
            {
                this.idempotencyKey = idempotencyKey;
                this.amountMoney = amountMoney;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
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
             /// CardNonce.
             /// </summary>
             /// <param name="cardNonce"> cardNonce. </param>
             /// <returns> Builder. </returns>
            public Builder CardNonce(string cardNonce)
            {
                this.cardNonce = cardNonce;
                return this;
            }

             /// <summary>
             /// CustomerCardId.
             /// </summary>
             /// <param name="customerCardId"> customerCardId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerCardId(string customerCardId)
            {
                this.customerCardId = customerCardId;
                return this;
            }

             /// <summary>
             /// DelayCapture.
             /// </summary>
             /// <param name="delayCapture"> delayCapture. </param>
             /// <returns> Builder. </returns>
            public Builder DelayCapture(bool? delayCapture)
            {
                this.delayCapture = delayCapture;
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
             /// Note.
             /// </summary>
             /// <param name="note"> note. </param>
             /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

             /// <summary>
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// BillingAddress.
             /// </summary>
             /// <param name="billingAddress"> billingAddress. </param>
             /// <returns> Builder. </returns>
            public Builder BillingAddress(Models.Address billingAddress)
            {
                this.billingAddress = billingAddress;
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
             /// BuyerEmailAddress.
             /// </summary>
             /// <param name="buyerEmailAddress"> buyerEmailAddress. </param>
             /// <returns> Builder. </returns>
            public Builder BuyerEmailAddress(string buyerEmailAddress)
            {
                this.buyerEmailAddress = buyerEmailAddress;
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
             /// AdditionalRecipients.
             /// </summary>
             /// <param name="additionalRecipients"> additionalRecipients. </param>
             /// <returns> Builder. </returns>
            public Builder AdditionalRecipients(IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients)
            {
                this.additionalRecipients = additionalRecipients;
                return this;
            }

             /// <summary>
             /// VerificationToken.
             /// </summary>
             /// <param name="verificationToken"> verificationToken. </param>
             /// <returns> Builder. </returns>
            public Builder VerificationToken(string verificationToken)
            {
                this.verificationToken = verificationToken;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ChargeRequest. </returns>
            public ChargeRequest Build()
            {
                return new ChargeRequest(
                    this.idempotencyKey,
                    this.amountMoney,
                    this.cardNonce,
                    this.customerCardId,
                    this.delayCapture,
                    this.referenceId,
                    this.note,
                    this.customerId,
                    this.billingAddress,
                    this.shippingAddress,
                    this.buyerEmailAddress,
                    this.orderId,
                    this.additionalRecipients,
                    this.verificationToken);
            }
        }
    }
}