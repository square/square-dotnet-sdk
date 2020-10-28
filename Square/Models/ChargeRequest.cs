using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class ChargeRequest 
    {
        public ChargeRequest(string idempotencyKey,
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
            IdempotencyKey = idempotencyKey;
            AmountMoney = amountMoney;
            CardNonce = cardNonce;
            CustomerCardId = customerCardId;
            DelayCapture = delayCapture;
            ReferenceId = referenceId;
            Note = note;
            CustomerId = customerId;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            BuyerEmailAddress = buyerEmailAddress;
            OrderId = orderId;
            AdditionalRecipients = additionalRecipients;
            VerificationToken = verificationToken;
        }

        /// <summary>
        /// A value you specify that uniquely identifies this
        /// transaction among transactions you've created.
        /// If you're unsure whether a particular transaction succeeded,
        /// you can reattempt it with the same idempotency key without
        /// worrying about double-charging the buyer.
        /// See [Idempotency keys](#idempotencykeys) for more information.
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
        /// A nonce generated from the `SqPaymentForm` that represents the card
        /// to charge.
        /// The application that provides a nonce to this endpoint must be the
        /// _same application_ that generated the nonce with the `SqPaymentForm`.
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
        /// [CaptureTransaction](#endpoint-capturetransaction) endpoint) or a Void
        /// (with the [VoidTransaction](#endpoint-voidtransaction) endpoint).
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

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                AmountMoney)
                .CardNonce(CardNonce)
                .CustomerCardId(CustomerCardId)
                .DelayCapture(DelayCapture)
                .ReferenceId(ReferenceId)
                .Note(Note)
                .CustomerId(CustomerId)
                .BillingAddress(BillingAddress)
                .ShippingAddress(ShippingAddress)
                .BuyerEmailAddress(BuyerEmailAddress)
                .OrderId(OrderId)
                .AdditionalRecipients(AdditionalRecipients)
                .VerificationToken(VerificationToken);
            return builder;
        }

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

            public Builder(string idempotencyKey,
                Models.Money amountMoney)
            {
                this.idempotencyKey = idempotencyKey;
                this.amountMoney = amountMoney;
            }

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder CardNonce(string cardNonce)
            {
                this.cardNonce = cardNonce;
                return this;
            }

            public Builder CustomerCardId(string customerCardId)
            {
                this.customerCardId = customerCardId;
                return this;
            }

            public Builder DelayCapture(bool? delayCapture)
            {
                this.delayCapture = delayCapture;
                return this;
            }

            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            public Builder BillingAddress(Models.Address billingAddress)
            {
                this.billingAddress = billingAddress;
                return this;
            }

            public Builder ShippingAddress(Models.Address shippingAddress)
            {
                this.shippingAddress = shippingAddress;
                return this;
            }

            public Builder BuyerEmailAddress(string buyerEmailAddress)
            {
                this.buyerEmailAddress = buyerEmailAddress;
                return this;
            }

            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public Builder AdditionalRecipients(IList<Models.ChargeRequestAdditionalRecipient> additionalRecipients)
            {
                this.additionalRecipients = additionalRecipients;
                return this;
            }

            public Builder VerificationToken(string verificationToken)
            {
                this.verificationToken = verificationToken;
                return this;
            }

            public ChargeRequest Build()
            {
                return new ChargeRequest(idempotencyKey,
                    amountMoney,
                    cardNonce,
                    customerCardId,
                    delayCapture,
                    referenceId,
                    note,
                    customerId,
                    billingAddress,
                    shippingAddress,
                    buyerEmailAddress,
                    orderId,
                    additionalRecipients,
                    verificationToken);
            }
        }
    }
}