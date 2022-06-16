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
    /// CreatePaymentRequest.
    /// </summary>
    public class CreatePaymentRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePaymentRequest"/> class.
        /// </summary>
        /// <param name="sourceId">source_id.</param>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="tipMoney">tip_money.</param>
        /// <param name="appFeeMoney">app_fee_money.</param>
        /// <param name="delayDuration">delay_duration.</param>
        /// <param name="delayAction">delay_action.</param>
        /// <param name="autocomplete">autocomplete.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="verificationToken">verification_token.</param>
        /// <param name="acceptPartialAuthorization">accept_partial_authorization.</param>
        /// <param name="buyerEmailAddress">buyer_email_address.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="shippingAddress">shipping_address.</param>
        /// <param name="note">note.</param>
        /// <param name="statementDescriptionIdentifier">statement_description_identifier.</param>
        /// <param name="cashDetails">cash_details.</param>
        /// <param name="externalDetails">external_details.</param>
        public CreatePaymentRequest(
            string sourceId,
            string idempotencyKey,
            Models.Money amountMoney,
            Models.Money tipMoney = null,
            Models.Money appFeeMoney = null,
            string delayDuration = null,
            string delayAction = null,
            bool? autocomplete = null,
            string orderId = null,
            string customerId = null,
            string locationId = null,
            string teamMemberId = null,
            string referenceId = null,
            string verificationToken = null,
            bool? acceptPartialAuthorization = null,
            string buyerEmailAddress = null,
            Models.Address billingAddress = null,
            Models.Address shippingAddress = null,
            string note = null,
            string statementDescriptionIdentifier = null,
            Models.CashPaymentDetails cashDetails = null,
            Models.ExternalPaymentDetails externalDetails = null)
        {
            this.SourceId = sourceId;
            this.IdempotencyKey = idempotencyKey;
            this.AmountMoney = amountMoney;
            this.TipMoney = tipMoney;
            this.AppFeeMoney = appFeeMoney;
            this.DelayDuration = delayDuration;
            this.DelayAction = delayAction;
            this.Autocomplete = autocomplete;
            this.OrderId = orderId;
            this.CustomerId = customerId;
            this.LocationId = locationId;
            this.TeamMemberId = teamMemberId;
            this.ReferenceId = referenceId;
            this.VerificationToken = verificationToken;
            this.AcceptPartialAuthorization = acceptPartialAuthorization;
            this.BuyerEmailAddress = buyerEmailAddress;
            this.BillingAddress = billingAddress;
            this.ShippingAddress = shippingAddress;
            this.Note = note;
            this.StatementDescriptionIdentifier = statementDescriptionIdentifier;
            this.CashDetails = cashDetails;
            this.ExternalDetails = externalDetails;
        }

        /// <summary>
        /// The ID for the source of funds for this payment. This can be a payment token
        /// (card nonce) generated by the Square payment form or a card on file made with the
        /// Customers API. If recording a payment that the seller
        /// received outside of Square, specify either "CASH" or "EXTERNAL".
        /// For more information, see
        /// [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
        /// </summary>
        [JsonProperty("source_id")]
        public string SourceId { get; }

        /// <summary>
        /// A unique string that identifies this `CreatePayment` request. Keys can be any valid string
        /// but must be unique for every `CreatePayment` request.
        /// Note: The number of allowed characters might be less than the stated maximum, if multi-byte
        /// characters are used.
        /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
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
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("tip_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TipMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("app_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppFeeMoney { get; }

        /// <summary>
        /// The duration of time after the payment's creation when Square automatically
        /// either completes or cancels the payment depending on the `delay_action` field value.
        /// For more information, see
        /// [Time threshold](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture#time-threshold).
        /// This parameter should be specified as a time duration, in RFC 3339 format.
        /// Note: This feature is only supported for card payments. This parameter can only be set for a delayed
        /// capture payment (`autocomplete=false`).
        /// Default:
        /// - Card-present payments: "PT36H" (36 hours) from the creation time.
        /// - Card-not-present payments: "P7D" (7 days) from the creation time.
        /// </summary>
        [JsonProperty("delay_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string DelayDuration { get; }

        /// <summary>
        /// The action to be applied to the payment when the `delay_duration` has elapsed. The action must be
        /// CANCEL or COMPLETE. For more information, see
        /// [Time Threshold](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture#time-threshold).
        /// Default: CANCEL
        /// </summary>
        [JsonProperty("delay_action", NullValueHandling = NullValueHandling.Ignore)]
        public string DelayAction { get; }

        /// <summary>
        /// If set to `true`, this payment will be completed when possible. If
        /// set to `false`, this payment is held in an approved state until either
        /// explicitly completed (captured) or canceled (voided). For more information, see
        /// [Delayed capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments#delayed-capture-of-a-card-payment).
        /// Default: true
        /// </summary>
        [JsonProperty("autocomplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Autocomplete { get; }

        /// <summary>
        /// Associates a previously created order with this payment.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// The [Customer]($m/Customer) ID of the customer associated with the payment.
        /// This is required if the `source_id` refers to a card on file created using the Customers API.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The location ID to associate with the payment. If not specified, the default location is
        /// used.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// An optional [TeamMember]($m/TeamMember) ID to associate with
        /// this payment.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// A user-defined ID to associate with the payment.
        /// You can use this field to associate the payment to an entity in an external system
        /// (for example, you might specify an order ID that is generated by a third-party shopping cart).
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// An identifying token generated by [payments.verifyBuyer()](https://developer.squareup.com/reference/sdks/web/payments/objects/Payments#Payments.verifyBuyer).
        /// Verification tokens encapsulate customer device information and 3-D Secure
        /// challenge results to indicate that Square has verified the buyer identity.
        /// For more information, see [SCA Overview](https://developer.squareup.com/docs/sca-overview).
        /// </summary>
        [JsonProperty("verification_token", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationToken { get; }

        /// <summary>
        /// If set to `true` and charging a Square Gift Card, a payment might be returned with
        /// `amount_money` equal to less than what was requested. For example, a request for $20 when charging
        /// a Square Gift Card with a balance of $5 results in an APPROVED payment of $5. You might choose
        /// to prompt the buyer for an additional payment to cover the remainder or cancel the Gift Card
        /// payment. This field cannot be `true` when `autocomplete = true`.
        /// For more information, see
        /// [Partial amount with Square Gift Cards](https://developer.squareup.com/docs/payments-api/take-payments#partial-payment-gift-card).
        /// Default: false
        /// </summary>
        [JsonProperty("accept_partial_authorization", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AcceptPartialAuthorization { get; }

        /// <summary>
        /// The buyer's email address.
        /// </summary>
        [JsonProperty("buyer_email_address", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyerEmailAddress { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("billing_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address BillingAddress { get; }

        /// <summary>
        /// Represents a postal address in a country.
        /// For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).
        /// </summary>
        [JsonProperty("shipping_address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address ShippingAddress { get; }

        /// <summary>
        /// An optional note to be entered by the developer when creating a payment.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// Optional additional payment information to include on the customer's card statement
        /// as part of the statement description. This can be, for example, an invoice number, ticket number,
        /// or short description that uniquely identifies the purchase.
        /// Note that the `statement_description_identifier` might get truncated on the statement description
        /// to fit the required information including the Square identifier (SQ *) and name of the
        /// seller taking the payment.
        /// </summary>
        [JsonProperty("statement_description_identifier", NullValueHandling = NullValueHandling.Ignore)]
        public string StatementDescriptionIdentifier { get; }

        /// <summary>
        /// Stores details about a cash payment. Contains only non-confidential information. For more information, see
        /// [Take Cash Payments](https://developer.squareup.com/docs/payments-api/take-payments/cash-payments).
        /// </summary>
        [JsonProperty("cash_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CashPaymentDetails CashDetails { get; }

        /// <summary>
        /// Stores details about an external payment. Contains only non-confidential information.
        /// For more information, see
        /// [Take External Payments](https://developer.squareup.com/docs/payments-api/take-payments/external-payments).
        /// </summary>
        [JsonProperty("external_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ExternalPaymentDetails ExternalDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreatePaymentRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is CreatePaymentRequest other &&
                ((this.SourceId == null && other.SourceId == null) || (this.SourceId?.Equals(other.SourceId) == true)) &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.TipMoney == null && other.TipMoney == null) || (this.TipMoney?.Equals(other.TipMoney) == true)) &&
                ((this.AppFeeMoney == null && other.AppFeeMoney == null) || (this.AppFeeMoney?.Equals(other.AppFeeMoney) == true)) &&
                ((this.DelayDuration == null && other.DelayDuration == null) || (this.DelayDuration?.Equals(other.DelayDuration) == true)) &&
                ((this.DelayAction == null && other.DelayAction == null) || (this.DelayAction?.Equals(other.DelayAction) == true)) &&
                ((this.Autocomplete == null && other.Autocomplete == null) || (this.Autocomplete?.Equals(other.Autocomplete) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.VerificationToken == null && other.VerificationToken == null) || (this.VerificationToken?.Equals(other.VerificationToken) == true)) &&
                ((this.AcceptPartialAuthorization == null && other.AcceptPartialAuthorization == null) || (this.AcceptPartialAuthorization?.Equals(other.AcceptPartialAuthorization) == true)) &&
                ((this.BuyerEmailAddress == null && other.BuyerEmailAddress == null) || (this.BuyerEmailAddress?.Equals(other.BuyerEmailAddress) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.ShippingAddress == null && other.ShippingAddress == null) || (this.ShippingAddress?.Equals(other.ShippingAddress) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.StatementDescriptionIdentifier == null && other.StatementDescriptionIdentifier == null) || (this.StatementDescriptionIdentifier?.Equals(other.StatementDescriptionIdentifier) == true)) &&
                ((this.CashDetails == null && other.CashDetails == null) || (this.CashDetails?.Equals(other.CashDetails) == true)) &&
                ((this.ExternalDetails == null && other.ExternalDetails == null) || (this.ExternalDetails?.Equals(other.ExternalDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1754918315;
            hashCode = HashCode.Combine(this.SourceId, this.IdempotencyKey, this.AmountMoney, this.TipMoney, this.AppFeeMoney, this.DelayDuration, this.DelayAction);

            hashCode = HashCode.Combine(hashCode, this.Autocomplete, this.OrderId, this.CustomerId, this.LocationId, this.TeamMemberId, this.ReferenceId, this.VerificationToken);

            hashCode = HashCode.Combine(hashCode, this.AcceptPartialAuthorization, this.BuyerEmailAddress, this.BillingAddress, this.ShippingAddress, this.Note, this.StatementDescriptionIdentifier, this.CashDetails);

            hashCode = HashCode.Combine(hashCode, this.ExternalDetails);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SourceId = {(this.SourceId == null ? "null" : this.SourceId == string.Empty ? "" : this.SourceId)}");
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.TipMoney = {(this.TipMoney == null ? "null" : this.TipMoney.ToString())}");
            toStringOutput.Add($"this.AppFeeMoney = {(this.AppFeeMoney == null ? "null" : this.AppFeeMoney.ToString())}");
            toStringOutput.Add($"this.DelayDuration = {(this.DelayDuration == null ? "null" : this.DelayDuration == string.Empty ? "" : this.DelayDuration)}");
            toStringOutput.Add($"this.DelayAction = {(this.DelayAction == null ? "null" : this.DelayAction == string.Empty ? "" : this.DelayAction)}");
            toStringOutput.Add($"this.Autocomplete = {(this.Autocomplete == null ? "null" : this.Autocomplete.ToString())}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.VerificationToken = {(this.VerificationToken == null ? "null" : this.VerificationToken == string.Empty ? "" : this.VerificationToken)}");
            toStringOutput.Add($"this.AcceptPartialAuthorization = {(this.AcceptPartialAuthorization == null ? "null" : this.AcceptPartialAuthorization.ToString())}");
            toStringOutput.Add($"this.BuyerEmailAddress = {(this.BuyerEmailAddress == null ? "null" : this.BuyerEmailAddress == string.Empty ? "" : this.BuyerEmailAddress)}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.ShippingAddress = {(this.ShippingAddress == null ? "null" : this.ShippingAddress.ToString())}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.StatementDescriptionIdentifier = {(this.StatementDescriptionIdentifier == null ? "null" : this.StatementDescriptionIdentifier == string.Empty ? "" : this.StatementDescriptionIdentifier)}");
            toStringOutput.Add($"this.CashDetails = {(this.CashDetails == null ? "null" : this.CashDetails.ToString())}");
            toStringOutput.Add($"this.ExternalDetails = {(this.ExternalDetails == null ? "null" : this.ExternalDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.SourceId,
                this.IdempotencyKey,
                this.AmountMoney)
                .TipMoney(this.TipMoney)
                .AppFeeMoney(this.AppFeeMoney)
                .DelayDuration(this.DelayDuration)
                .DelayAction(this.DelayAction)
                .Autocomplete(this.Autocomplete)
                .OrderId(this.OrderId)
                .CustomerId(this.CustomerId)
                .LocationId(this.LocationId)
                .TeamMemberId(this.TeamMemberId)
                .ReferenceId(this.ReferenceId)
                .VerificationToken(this.VerificationToken)
                .AcceptPartialAuthorization(this.AcceptPartialAuthorization)
                .BuyerEmailAddress(this.BuyerEmailAddress)
                .BillingAddress(this.BillingAddress)
                .ShippingAddress(this.ShippingAddress)
                .Note(this.Note)
                .StatementDescriptionIdentifier(this.StatementDescriptionIdentifier)
                .CashDetails(this.CashDetails)
                .ExternalDetails(this.ExternalDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string sourceId;
            private string idempotencyKey;
            private Models.Money amountMoney;
            private Models.Money tipMoney;
            private Models.Money appFeeMoney;
            private string delayDuration;
            private string delayAction;
            private bool? autocomplete;
            private string orderId;
            private string customerId;
            private string locationId;
            private string teamMemberId;
            private string referenceId;
            private string verificationToken;
            private bool? acceptPartialAuthorization;
            private string buyerEmailAddress;
            private Models.Address billingAddress;
            private Models.Address shippingAddress;
            private string note;
            private string statementDescriptionIdentifier;
            private Models.CashPaymentDetails cashDetails;
            private Models.ExternalPaymentDetails externalDetails;

            public Builder(
                string sourceId,
                string idempotencyKey,
                Models.Money amountMoney)
            {
                this.sourceId = sourceId;
                this.idempotencyKey = idempotencyKey;
                this.amountMoney = amountMoney;
            }

             /// <summary>
             /// SourceId.
             /// </summary>
             /// <param name="sourceId"> sourceId. </param>
             /// <returns> Builder. </returns>
            public Builder SourceId(string sourceId)
            {
                this.sourceId = sourceId;
                return this;
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
             /// TipMoney.
             /// </summary>
             /// <param name="tipMoney"> tipMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TipMoney(Models.Money tipMoney)
            {
                this.tipMoney = tipMoney;
                return this;
            }

             /// <summary>
             /// AppFeeMoney.
             /// </summary>
             /// <param name="appFeeMoney"> appFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppFeeMoney(Models.Money appFeeMoney)
            {
                this.appFeeMoney = appFeeMoney;
                return this;
            }

             /// <summary>
             /// DelayDuration.
             /// </summary>
             /// <param name="delayDuration"> delayDuration. </param>
             /// <returns> Builder. </returns>
            public Builder DelayDuration(string delayDuration)
            {
                this.delayDuration = delayDuration;
                return this;
            }

             /// <summary>
             /// DelayAction.
             /// </summary>
             /// <param name="delayAction"> delayAction. </param>
             /// <returns> Builder. </returns>
            public Builder DelayAction(string delayAction)
            {
                this.delayAction = delayAction;
                return this;
            }

             /// <summary>
             /// Autocomplete.
             /// </summary>
             /// <param name="autocomplete"> autocomplete. </param>
             /// <returns> Builder. </returns>
            public Builder Autocomplete(bool? autocomplete)
            {
                this.autocomplete = autocomplete;
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
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
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
             /// AcceptPartialAuthorization.
             /// </summary>
             /// <param name="acceptPartialAuthorization"> acceptPartialAuthorization. </param>
             /// <returns> Builder. </returns>
            public Builder AcceptPartialAuthorization(bool? acceptPartialAuthorization)
            {
                this.acceptPartialAuthorization = acceptPartialAuthorization;
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
             /// StatementDescriptionIdentifier.
             /// </summary>
             /// <param name="statementDescriptionIdentifier"> statementDescriptionIdentifier. </param>
             /// <returns> Builder. </returns>
            public Builder StatementDescriptionIdentifier(string statementDescriptionIdentifier)
            {
                this.statementDescriptionIdentifier = statementDescriptionIdentifier;
                return this;
            }

             /// <summary>
             /// CashDetails.
             /// </summary>
             /// <param name="cashDetails"> cashDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CashDetails(Models.CashPaymentDetails cashDetails)
            {
                this.cashDetails = cashDetails;
                return this;
            }

             /// <summary>
             /// ExternalDetails.
             /// </summary>
             /// <param name="externalDetails"> externalDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ExternalDetails(Models.ExternalPaymentDetails externalDetails)
            {
                this.externalDetails = externalDetails;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreatePaymentRequest. </returns>
            public CreatePaymentRequest Build()
            {
                return new CreatePaymentRequest(
                    this.sourceId,
                    this.idempotencyKey,
                    this.amountMoney,
                    this.tipMoney,
                    this.appFeeMoney,
                    this.delayDuration,
                    this.delayAction,
                    this.autocomplete,
                    this.orderId,
                    this.customerId,
                    this.locationId,
                    this.teamMemberId,
                    this.referenceId,
                    this.verificationToken,
                    this.acceptPartialAuthorization,
                    this.buyerEmailAddress,
                    this.billingAddress,
                    this.shippingAddress,
                    this.note,
                    this.statementDescriptionIdentifier,
                    this.cashDetails,
                    this.externalDetails);
            }
        }
    }
}