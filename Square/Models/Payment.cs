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
    /// Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="tipMoney">tip_money.</param>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="appFeeMoney">app_fee_money.</param>
        /// <param name="approvedMoney">approved_money.</param>
        /// <param name="processingFee">processing_fee.</param>
        /// <param name="refundedMoney">refunded_money.</param>
        /// <param name="status">status.</param>
        /// <param name="delayDuration">delay_duration.</param>
        /// <param name="delayAction">delay_action.</param>
        /// <param name="delayedUntil">delayed_until.</param>
        /// <param name="sourceType">source_type.</param>
        /// <param name="cardDetails">card_details.</param>
        /// <param name="cashDetails">cash_details.</param>
        /// <param name="bankAccountDetails">bank_account_details.</param>
        /// <param name="externalDetails">external_details.</param>
        /// <param name="walletDetails">wallet_details.</param>
        /// <param name="buyNowPayLaterDetails">buy_now_pay_later_details.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="refundIds">refund_ids.</param>
        /// <param name="riskEvaluation">risk_evaluation.</param>
        /// <param name="buyerEmailAddress">buyer_email_address.</param>
        /// <param name="billingAddress">billing_address.</param>
        /// <param name="shippingAddress">shipping_address.</param>
        /// <param name="note">note.</param>
        /// <param name="statementDescriptionIdentifier">statement_description_identifier.</param>
        /// <param name="capabilities">capabilities.</param>
        /// <param name="receiptNumber">receipt_number.</param>
        /// <param name="receiptUrl">receipt_url.</param>
        /// <param name="deviceDetails">device_details.</param>
        /// <param name="applicationDetails">application_details.</param>
        /// <param name="versionToken">version_token.</param>
        public Payment(
            string id = null,
            string createdAt = null,
            string updatedAt = null,
            Models.Money amountMoney = null,
            Models.Money tipMoney = null,
            Models.Money totalMoney = null,
            Models.Money appFeeMoney = null,
            Models.Money approvedMoney = null,
            IList<Models.ProcessingFee> processingFee = null,
            Models.Money refundedMoney = null,
            string status = null,
            string delayDuration = null,
            string delayAction = null,
            string delayedUntil = null,
            string sourceType = null,
            Models.CardPaymentDetails cardDetails = null,
            Models.CashPaymentDetails cashDetails = null,
            Models.BankAccountPaymentDetails bankAccountDetails = null,
            Models.ExternalPaymentDetails externalDetails = null,
            Models.DigitalWalletDetails walletDetails = null,
            Models.BuyNowPayLaterDetails buyNowPayLaterDetails = null,
            string locationId = null,
            string orderId = null,
            string referenceId = null,
            string customerId = null,
            string employeeId = null,
            string teamMemberId = null,
            IList<string> refundIds = null,
            Models.RiskEvaluation riskEvaluation = null,
            string buyerEmailAddress = null,
            Models.Address billingAddress = null,
            Models.Address shippingAddress = null,
            string note = null,
            string statementDescriptionIdentifier = null,
            IList<string> capabilities = null,
            string receiptNumber = null,
            string receiptUrl = null,
            Models.DeviceDetails deviceDetails = null,
            Models.ApplicationDetails applicationDetails = null,
            string versionToken = null)
        {
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AmountMoney = amountMoney;
            this.TipMoney = tipMoney;
            this.TotalMoney = totalMoney;
            this.AppFeeMoney = appFeeMoney;
            this.ApprovedMoney = approvedMoney;
            this.ProcessingFee = processingFee;
            this.RefundedMoney = refundedMoney;
            this.Status = status;
            this.DelayDuration = delayDuration;
            this.DelayAction = delayAction;
            this.DelayedUntil = delayedUntil;
            this.SourceType = sourceType;
            this.CardDetails = cardDetails;
            this.CashDetails = cashDetails;
            this.BankAccountDetails = bankAccountDetails;
            this.ExternalDetails = externalDetails;
            this.WalletDetails = walletDetails;
            this.BuyNowPayLaterDetails = buyNowPayLaterDetails;
            this.LocationId = locationId;
            this.OrderId = orderId;
            this.ReferenceId = referenceId;
            this.CustomerId = customerId;
            this.EmployeeId = employeeId;
            this.TeamMemberId = teamMemberId;
            this.RefundIds = refundIds;
            this.RiskEvaluation = riskEvaluation;
            this.BuyerEmailAddress = buyerEmailAddress;
            this.BillingAddress = billingAddress;
            this.ShippingAddress = shippingAddress;
            this.Note = note;
            this.StatementDescriptionIdentifier = statementDescriptionIdentifier;
            this.Capabilities = capabilities;
            this.ReceiptNumber = receiptNumber;
            this.ReceiptUrl = receiptUrl;
            this.DeviceDetails = deviceDetails;
            this.ApplicationDetails = applicationDetails;
            this.VersionToken = versionToken;
        }

        /// <summary>
        /// A unique ID for the payment.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The timestamp of when the payment was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp of when the payment was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

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
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalMoney { get; }

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
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("approved_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ApprovedMoney { get; }

        /// <summary>
        /// The processing fees and fee adjustments assessed by Square for this payment.
        /// </summary>
        [JsonProperty("processing_fee", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.ProcessingFee> ProcessingFee { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("refunded_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money RefundedMoney { get; }

        /// <summary>
        /// Indicates whether the payment is APPROVED, PENDING, COMPLETED, CANCELED, or FAILED.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The duration of time after the payment's creation when Square automatically applies the
        /// `delay_action` to the payment. This automatic `delay_action` applies only to payments that
        /// do not reach a terminal state (COMPLETED, CANCELED, or FAILED) before the `delay_duration`
        /// time period.
        /// This field is specified as a time duration, in RFC 3339 format.
        /// Notes:
        /// This feature is only supported for card payments.
        /// Default:
        /// - Card-present payments: "PT36H" (36 hours) from the creation time.
        /// - Card-not-present payments: "P7D" (7 days) from the creation time.
        /// </summary>
        [JsonProperty("delay_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string DelayDuration { get; }

        /// <summary>
        /// The action to be applied to the payment when the `delay_duration` has elapsed.
        /// Current values include `CANCEL` and `COMPLETE`.
        /// </summary>
        [JsonProperty("delay_action", NullValueHandling = NullValueHandling.Ignore)]
        public string DelayAction { get; }

        /// <summary>
        /// The read-only timestamp of when the `delay_action` is automatically applied,
        /// in RFC 3339 format.
        /// Note that this field is calculated by summing the payment's `delay_duration` and `created_at`
        /// fields. The `created_at` field is generated by Square and might not exactly match the
        /// time on your local machine.
        /// </summary>
        [JsonProperty("delayed_until", NullValueHandling = NullValueHandling.Ignore)]
        public string DelayedUntil { get; }

        /// <summary>
        /// The source type for this payment.
        /// Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `BUY_NOW_PAY_LATER`, `CASH`
        /// and `EXTERNAL`. For information about these payment source types,
        /// see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
        /// </summary>
        [JsonProperty("source_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceType { get; }

        /// <summary>
        /// Reflects the current status of a card payment. Contains only non-confidential information.
        /// </summary>
        [JsonProperty("card_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CardPaymentDetails CardDetails { get; }

        /// <summary>
        /// Stores details about a cash payment. Contains only non-confidential information. For more information, see
        /// [Take Cash Payments](https://developer.squareup.com/docs/payments-api/take-payments/cash-payments).
        /// </summary>
        [JsonProperty("cash_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CashPaymentDetails CashDetails { get; }

        /// <summary>
        /// Additional details about BANK_ACCOUNT type payments.
        /// </summary>
        [JsonProperty("bank_account_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BankAccountPaymentDetails BankAccountDetails { get; }

        /// <summary>
        /// Stores details about an external payment. Contains only non-confidential information.
        /// For more information, see
        /// [Take External Payments](https://developer.squareup.com/docs/payments-api/take-payments/external-payments).
        /// </summary>
        [JsonProperty("external_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ExternalPaymentDetails ExternalDetails { get; }

        /// <summary>
        /// Additional details about `WALLET` type payments. Contains only non-confidential information.
        /// </summary>
        [JsonProperty("wallet_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DigitalWalletDetails WalletDetails { get; }

        /// <summary>
        /// Additional details about a Buy Now Pay Later payment type.
        /// </summary>
        [JsonProperty("buy_now_pay_later_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BuyNowPayLaterDetails BuyNowPayLaterDetails { get; }

        /// <summary>
        /// The ID of the location associated with the payment.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the order associated with the payment.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

        /// <summary>
        /// An optional ID that associates the payment with an entity in
        /// another system.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// The ID of the customer associated with the payment. If the ID is
        /// not provided in the `CreatePayment` request that was used to create the `Payment`,
        /// Square may use information in the request
        /// (such as the billing and shipping address, email address, and payment source)
        /// to identify a matching customer profile in the Customer Directory.
        /// If found, the profile ID is used. If a profile is not found, the
        /// API attempts to create an
        /// [instant profile](https://developer.squareup.com/docs/customers-api/what-it-does#instant-profiles).
        /// If the API cannot create an
        /// instant profile (either because the seller has disabled it or the
        /// seller's region prevents creating it), this field remains unset. Note that
        /// this process is asynchronous and it may take some time before a
        /// customer ID is added to the payment.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// __Deprecated__: Use `Payment.team_member_id` instead.
        /// An optional ID of the employee associated with taking the payment.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// An optional ID of the [TeamMember]($m/TeamMember) associated with taking the payment.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// A list of `refund_id`s identifying refunds for the payment.
        /// </summary>
        [JsonProperty("refund_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> RefundIds { get; }

        /// <summary>
        /// Represents fraud risk information for the associated payment.
        /// When you take a payment through Square's Payments API (using the `CreatePayment`
        /// endpoint), Square evaluates it and assigns a risk level to the payment. Sellers
        /// can use this information to determine the course of action (for example,
        /// provide the goods/services or refund the payment).
        /// </summary>
        [JsonProperty("risk_evaluation", NullValueHandling = NullValueHandling.Ignore)]
        public Models.RiskEvaluation RiskEvaluation { get; }

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
        /// An optional note to include when creating a payment.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// Additional payment information that gets added to the customer's card statement
        /// as part of the statement description.
        /// Note that the `statement_description_identifier` might get truncated on the statement description
        /// to fit the required information including the Square identifier (SQ *) and the name of the
        /// seller taking the payment.
        /// </summary>
        [JsonProperty("statement_description_identifier", NullValueHandling = NullValueHandling.Ignore)]
        public string StatementDescriptionIdentifier { get; }

        /// <summary>
        /// Actions that can be performed on this payment:
        /// - `EDIT_AMOUNT_UP` - The payment amount can be edited up.
        /// - `EDIT_AMOUNT_DOWN` - The payment amount can be edited down.
        /// - `EDIT_TIP_AMOUNT_UP` - The tip amount can be edited up.
        /// - `EDIT_TIP_AMOUNT_DOWN` - The tip amount can be edited down.
        /// - `EDIT_DELAY_ACTION` - The delay_action can be edited.
        /// </summary>
        [JsonProperty("capabilities", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Capabilities { get; }

        /// <summary>
        /// The payment's receipt number.
        /// The field is missing if a payment is canceled.
        /// </summary>
        [JsonProperty("receipt_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiptNumber { get; }

        /// <summary>
        /// The URL for the payment's receipt.
        /// The field is only populated for COMPLETED payments.
        /// </summary>
        [JsonProperty("receipt_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiptUrl { get; }

        /// <summary>
        /// Details about the device that took the payment.
        /// </summary>
        [JsonProperty("device_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceDetails DeviceDetails { get; }

        /// <summary>
        /// Details about the application that took the payment.
        /// </summary>
        [JsonProperty("application_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ApplicationDetails ApplicationDetails { get; }

        /// <summary>
        /// Used for optimistic concurrency. This opaque token identifies a specific version of the
        /// `Payment` object.
        /// </summary>
        [JsonProperty("version_token", NullValueHandling = NullValueHandling.Ignore)]
        public string VersionToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Payment : ({string.Join(", ", toStringOutput)})";
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

            return obj is Payment other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.TipMoney == null && other.TipMoney == null) || (this.TipMoney?.Equals(other.TipMoney) == true)) &&
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.AppFeeMoney == null && other.AppFeeMoney == null) || (this.AppFeeMoney?.Equals(other.AppFeeMoney) == true)) &&
                ((this.ApprovedMoney == null && other.ApprovedMoney == null) || (this.ApprovedMoney?.Equals(other.ApprovedMoney) == true)) &&
                ((this.ProcessingFee == null && other.ProcessingFee == null) || (this.ProcessingFee?.Equals(other.ProcessingFee) == true)) &&
                ((this.RefundedMoney == null && other.RefundedMoney == null) || (this.RefundedMoney?.Equals(other.RefundedMoney) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.DelayDuration == null && other.DelayDuration == null) || (this.DelayDuration?.Equals(other.DelayDuration) == true)) &&
                ((this.DelayAction == null && other.DelayAction == null) || (this.DelayAction?.Equals(other.DelayAction) == true)) &&
                ((this.DelayedUntil == null && other.DelayedUntil == null) || (this.DelayedUntil?.Equals(other.DelayedUntil) == true)) &&
                ((this.SourceType == null && other.SourceType == null) || (this.SourceType?.Equals(other.SourceType) == true)) &&
                ((this.CardDetails == null && other.CardDetails == null) || (this.CardDetails?.Equals(other.CardDetails) == true)) &&
                ((this.CashDetails == null && other.CashDetails == null) || (this.CashDetails?.Equals(other.CashDetails) == true)) &&
                ((this.BankAccountDetails == null && other.BankAccountDetails == null) || (this.BankAccountDetails?.Equals(other.BankAccountDetails) == true)) &&
                ((this.ExternalDetails == null && other.ExternalDetails == null) || (this.ExternalDetails?.Equals(other.ExternalDetails) == true)) &&
                ((this.WalletDetails == null && other.WalletDetails == null) || (this.WalletDetails?.Equals(other.WalletDetails) == true)) &&
                ((this.BuyNowPayLaterDetails == null && other.BuyNowPayLaterDetails == null) || (this.BuyNowPayLaterDetails?.Equals(other.BuyNowPayLaterDetails) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.RefundIds == null && other.RefundIds == null) || (this.RefundIds?.Equals(other.RefundIds) == true)) &&
                ((this.RiskEvaluation == null && other.RiskEvaluation == null) || (this.RiskEvaluation?.Equals(other.RiskEvaluation) == true)) &&
                ((this.BuyerEmailAddress == null && other.BuyerEmailAddress == null) || (this.BuyerEmailAddress?.Equals(other.BuyerEmailAddress) == true)) &&
                ((this.BillingAddress == null && other.BillingAddress == null) || (this.BillingAddress?.Equals(other.BillingAddress) == true)) &&
                ((this.ShippingAddress == null && other.ShippingAddress == null) || (this.ShippingAddress?.Equals(other.ShippingAddress) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.StatementDescriptionIdentifier == null && other.StatementDescriptionIdentifier == null) || (this.StatementDescriptionIdentifier?.Equals(other.StatementDescriptionIdentifier) == true)) &&
                ((this.Capabilities == null && other.Capabilities == null) || (this.Capabilities?.Equals(other.Capabilities) == true)) &&
                ((this.ReceiptNumber == null && other.ReceiptNumber == null) || (this.ReceiptNumber?.Equals(other.ReceiptNumber) == true)) &&
                ((this.ReceiptUrl == null && other.ReceiptUrl == null) || (this.ReceiptUrl?.Equals(other.ReceiptUrl) == true)) &&
                ((this.DeviceDetails == null && other.DeviceDetails == null) || (this.DeviceDetails?.Equals(other.DeviceDetails) == true)) &&
                ((this.ApplicationDetails == null && other.ApplicationDetails == null) || (this.ApplicationDetails?.Equals(other.ApplicationDetails) == true)) &&
                ((this.VersionToken == null && other.VersionToken == null) || (this.VersionToken?.Equals(other.VersionToken) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1418416036;
            hashCode = HashCode.Combine(this.Id, this.CreatedAt, this.UpdatedAt, this.AmountMoney, this.TipMoney, this.TotalMoney, this.AppFeeMoney);

            hashCode = HashCode.Combine(hashCode, this.ApprovedMoney, this.ProcessingFee, this.RefundedMoney, this.Status, this.DelayDuration, this.DelayAction, this.DelayedUntil);

            hashCode = HashCode.Combine(hashCode, this.SourceType, this.CardDetails, this.CashDetails, this.BankAccountDetails, this.ExternalDetails, this.WalletDetails, this.BuyNowPayLaterDetails);

            hashCode = HashCode.Combine(hashCode, this.LocationId, this.OrderId, this.ReferenceId, this.CustomerId, this.EmployeeId, this.TeamMemberId, this.RefundIds);

            hashCode = HashCode.Combine(hashCode, this.RiskEvaluation, this.BuyerEmailAddress, this.BillingAddress, this.ShippingAddress, this.Note, this.StatementDescriptionIdentifier, this.Capabilities);

            hashCode = HashCode.Combine(hashCode, this.ReceiptNumber, this.ReceiptUrl, this.DeviceDetails, this.ApplicationDetails, this.VersionToken);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.TipMoney = {(this.TipMoney == null ? "null" : this.TipMoney.ToString())}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.AppFeeMoney = {(this.AppFeeMoney == null ? "null" : this.AppFeeMoney.ToString())}");
            toStringOutput.Add($"this.ApprovedMoney = {(this.ApprovedMoney == null ? "null" : this.ApprovedMoney.ToString())}");
            toStringOutput.Add($"this.ProcessingFee = {(this.ProcessingFee == null ? "null" : $"[{string.Join(", ", this.ProcessingFee)} ]")}");
            toStringOutput.Add($"this.RefundedMoney = {(this.RefundedMoney == null ? "null" : this.RefundedMoney.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.DelayDuration = {(this.DelayDuration == null ? "null" : this.DelayDuration == string.Empty ? "" : this.DelayDuration)}");
            toStringOutput.Add($"this.DelayAction = {(this.DelayAction == null ? "null" : this.DelayAction == string.Empty ? "" : this.DelayAction)}");
            toStringOutput.Add($"this.DelayedUntil = {(this.DelayedUntil == null ? "null" : this.DelayedUntil == string.Empty ? "" : this.DelayedUntil)}");
            toStringOutput.Add($"this.SourceType = {(this.SourceType == null ? "null" : this.SourceType == string.Empty ? "" : this.SourceType)}");
            toStringOutput.Add($"this.CardDetails = {(this.CardDetails == null ? "null" : this.CardDetails.ToString())}");
            toStringOutput.Add($"this.CashDetails = {(this.CashDetails == null ? "null" : this.CashDetails.ToString())}");
            toStringOutput.Add($"this.BankAccountDetails = {(this.BankAccountDetails == null ? "null" : this.BankAccountDetails.ToString())}");
            toStringOutput.Add($"this.ExternalDetails = {(this.ExternalDetails == null ? "null" : this.ExternalDetails.ToString())}");
            toStringOutput.Add($"this.WalletDetails = {(this.WalletDetails == null ? "null" : this.WalletDetails.ToString())}");
            toStringOutput.Add($"this.BuyNowPayLaterDetails = {(this.BuyNowPayLaterDetails == null ? "null" : this.BuyNowPayLaterDetails.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId == string.Empty ? "" : this.EmployeeId)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.RefundIds = {(this.RefundIds == null ? "null" : $"[{string.Join(", ", this.RefundIds)} ]")}");
            toStringOutput.Add($"this.RiskEvaluation = {(this.RiskEvaluation == null ? "null" : this.RiskEvaluation.ToString())}");
            toStringOutput.Add($"this.BuyerEmailAddress = {(this.BuyerEmailAddress == null ? "null" : this.BuyerEmailAddress == string.Empty ? "" : this.BuyerEmailAddress)}");
            toStringOutput.Add($"this.BillingAddress = {(this.BillingAddress == null ? "null" : this.BillingAddress.ToString())}");
            toStringOutput.Add($"this.ShippingAddress = {(this.ShippingAddress == null ? "null" : this.ShippingAddress.ToString())}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.StatementDescriptionIdentifier = {(this.StatementDescriptionIdentifier == null ? "null" : this.StatementDescriptionIdentifier == string.Empty ? "" : this.StatementDescriptionIdentifier)}");
            toStringOutput.Add($"this.Capabilities = {(this.Capabilities == null ? "null" : $"[{string.Join(", ", this.Capabilities)} ]")}");
            toStringOutput.Add($"this.ReceiptNumber = {(this.ReceiptNumber == null ? "null" : this.ReceiptNumber == string.Empty ? "" : this.ReceiptNumber)}");
            toStringOutput.Add($"this.ReceiptUrl = {(this.ReceiptUrl == null ? "null" : this.ReceiptUrl == string.Empty ? "" : this.ReceiptUrl)}");
            toStringOutput.Add($"this.DeviceDetails = {(this.DeviceDetails == null ? "null" : this.DeviceDetails.ToString())}");
            toStringOutput.Add($"this.ApplicationDetails = {(this.ApplicationDetails == null ? "null" : this.ApplicationDetails.ToString())}");
            toStringOutput.Add($"this.VersionToken = {(this.VersionToken == null ? "null" : this.VersionToken == string.Empty ? "" : this.VersionToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .AmountMoney(this.AmountMoney)
                .TipMoney(this.TipMoney)
                .TotalMoney(this.TotalMoney)
                .AppFeeMoney(this.AppFeeMoney)
                .ApprovedMoney(this.ApprovedMoney)
                .ProcessingFee(this.ProcessingFee)
                .RefundedMoney(this.RefundedMoney)
                .Status(this.Status)
                .DelayDuration(this.DelayDuration)
                .DelayAction(this.DelayAction)
                .DelayedUntil(this.DelayedUntil)
                .SourceType(this.SourceType)
                .CardDetails(this.CardDetails)
                .CashDetails(this.CashDetails)
                .BankAccountDetails(this.BankAccountDetails)
                .ExternalDetails(this.ExternalDetails)
                .WalletDetails(this.WalletDetails)
                .BuyNowPayLaterDetails(this.BuyNowPayLaterDetails)
                .LocationId(this.LocationId)
                .OrderId(this.OrderId)
                .ReferenceId(this.ReferenceId)
                .CustomerId(this.CustomerId)
                .EmployeeId(this.EmployeeId)
                .TeamMemberId(this.TeamMemberId)
                .RefundIds(this.RefundIds)
                .RiskEvaluation(this.RiskEvaluation)
                .BuyerEmailAddress(this.BuyerEmailAddress)
                .BillingAddress(this.BillingAddress)
                .ShippingAddress(this.ShippingAddress)
                .Note(this.Note)
                .StatementDescriptionIdentifier(this.StatementDescriptionIdentifier)
                .Capabilities(this.Capabilities)
                .ReceiptNumber(this.ReceiptNumber)
                .ReceiptUrl(this.ReceiptUrl)
                .DeviceDetails(this.DeviceDetails)
                .ApplicationDetails(this.ApplicationDetails)
                .VersionToken(this.VersionToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string id;
            private string createdAt;
            private string updatedAt;
            private Models.Money amountMoney;
            private Models.Money tipMoney;
            private Models.Money totalMoney;
            private Models.Money appFeeMoney;
            private Models.Money approvedMoney;
            private IList<Models.ProcessingFee> processingFee;
            private Models.Money refundedMoney;
            private string status;
            private string delayDuration;
            private string delayAction;
            private string delayedUntil;
            private string sourceType;
            private Models.CardPaymentDetails cardDetails;
            private Models.CashPaymentDetails cashDetails;
            private Models.BankAccountPaymentDetails bankAccountDetails;
            private Models.ExternalPaymentDetails externalDetails;
            private Models.DigitalWalletDetails walletDetails;
            private Models.BuyNowPayLaterDetails buyNowPayLaterDetails;
            private string locationId;
            private string orderId;
            private string referenceId;
            private string customerId;
            private string employeeId;
            private string teamMemberId;
            private IList<string> refundIds;
            private Models.RiskEvaluation riskEvaluation;
            private string buyerEmailAddress;
            private Models.Address billingAddress;
            private Models.Address shippingAddress;
            private string note;
            private string statementDescriptionIdentifier;
            private IList<string> capabilities;
            private string receiptNumber;
            private string receiptUrl;
            private Models.DeviceDetails deviceDetails;
            private Models.ApplicationDetails applicationDetails;
            private string versionToken;

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
             /// TotalMoney.
             /// </summary>
             /// <param name="totalMoney"> totalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
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
             /// ApprovedMoney.
             /// </summary>
             /// <param name="approvedMoney"> approvedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder ApprovedMoney(Models.Money approvedMoney)
            {
                this.approvedMoney = approvedMoney;
                return this;
            }

             /// <summary>
             /// ProcessingFee.
             /// </summary>
             /// <param name="processingFee"> processingFee. </param>
             /// <returns> Builder. </returns>
            public Builder ProcessingFee(IList<Models.ProcessingFee> processingFee)
            {
                this.processingFee = processingFee;
                return this;
            }

             /// <summary>
             /// RefundedMoney.
             /// </summary>
             /// <param name="refundedMoney"> refundedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedMoney(Models.Money refundedMoney)
            {
                this.refundedMoney = refundedMoney;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
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
             /// DelayedUntil.
             /// </summary>
             /// <param name="delayedUntil"> delayedUntil. </param>
             /// <returns> Builder. </returns>
            public Builder DelayedUntil(string delayedUntil)
            {
                this.delayedUntil = delayedUntil;
                return this;
            }

             /// <summary>
             /// SourceType.
             /// </summary>
             /// <param name="sourceType"> sourceType. </param>
             /// <returns> Builder. </returns>
            public Builder SourceType(string sourceType)
            {
                this.sourceType = sourceType;
                return this;
            }

             /// <summary>
             /// CardDetails.
             /// </summary>
             /// <param name="cardDetails"> cardDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CardDetails(Models.CardPaymentDetails cardDetails)
            {
                this.cardDetails = cardDetails;
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
             /// BankAccountDetails.
             /// </summary>
             /// <param name="bankAccountDetails"> bankAccountDetails. </param>
             /// <returns> Builder. </returns>
            public Builder BankAccountDetails(Models.BankAccountPaymentDetails bankAccountDetails)
            {
                this.bankAccountDetails = bankAccountDetails;
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
             /// WalletDetails.
             /// </summary>
             /// <param name="walletDetails"> walletDetails. </param>
             /// <returns> Builder. </returns>
            public Builder WalletDetails(Models.DigitalWalletDetails walletDetails)
            {
                this.walletDetails = walletDetails;
                return this;
            }

             /// <summary>
             /// BuyNowPayLaterDetails.
             /// </summary>
             /// <param name="buyNowPayLaterDetails"> buyNowPayLaterDetails. </param>
             /// <returns> Builder. </returns>
            public Builder BuyNowPayLaterDetails(Models.BuyNowPayLaterDetails buyNowPayLaterDetails)
            {
                this.buyNowPayLaterDetails = buyNowPayLaterDetails;
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
             /// EmployeeId.
             /// </summary>
             /// <param name="employeeId"> employeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
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
             /// RefundIds.
             /// </summary>
             /// <param name="refundIds"> refundIds. </param>
             /// <returns> Builder. </returns>
            public Builder RefundIds(IList<string> refundIds)
            {
                this.refundIds = refundIds;
                return this;
            }

             /// <summary>
             /// RiskEvaluation.
             /// </summary>
             /// <param name="riskEvaluation"> riskEvaluation. </param>
             /// <returns> Builder. </returns>
            public Builder RiskEvaluation(Models.RiskEvaluation riskEvaluation)
            {
                this.riskEvaluation = riskEvaluation;
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
             /// Capabilities.
             /// </summary>
             /// <param name="capabilities"> capabilities. </param>
             /// <returns> Builder. </returns>
            public Builder Capabilities(IList<string> capabilities)
            {
                this.capabilities = capabilities;
                return this;
            }

             /// <summary>
             /// ReceiptNumber.
             /// </summary>
             /// <param name="receiptNumber"> receiptNumber. </param>
             /// <returns> Builder. </returns>
            public Builder ReceiptNumber(string receiptNumber)
            {
                this.receiptNumber = receiptNumber;
                return this;
            }

             /// <summary>
             /// ReceiptUrl.
             /// </summary>
             /// <param name="receiptUrl"> receiptUrl. </param>
             /// <returns> Builder. </returns>
            public Builder ReceiptUrl(string receiptUrl)
            {
                this.receiptUrl = receiptUrl;
                return this;
            }

             /// <summary>
             /// DeviceDetails.
             /// </summary>
             /// <param name="deviceDetails"> deviceDetails. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceDetails(Models.DeviceDetails deviceDetails)
            {
                this.deviceDetails = deviceDetails;
                return this;
            }

             /// <summary>
             /// ApplicationDetails.
             /// </summary>
             /// <param name="applicationDetails"> applicationDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationDetails(Models.ApplicationDetails applicationDetails)
            {
                this.applicationDetails = applicationDetails;
                return this;
            }

             /// <summary>
             /// VersionToken.
             /// </summary>
             /// <param name="versionToken"> versionToken. </param>
             /// <returns> Builder. </returns>
            public Builder VersionToken(string versionToken)
            {
                this.versionToken = versionToken;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Payment. </returns>
            public Payment Build()
            {
                return new Payment(
                    this.id,
                    this.createdAt,
                    this.updatedAt,
                    this.amountMoney,
                    this.tipMoney,
                    this.totalMoney,
                    this.appFeeMoney,
                    this.approvedMoney,
                    this.processingFee,
                    this.refundedMoney,
                    this.status,
                    this.delayDuration,
                    this.delayAction,
                    this.delayedUntil,
                    this.sourceType,
                    this.cardDetails,
                    this.cashDetails,
                    this.bankAccountDetails,
                    this.externalDetails,
                    this.walletDetails,
                    this.buyNowPayLaterDetails,
                    this.locationId,
                    this.orderId,
                    this.referenceId,
                    this.customerId,
                    this.employeeId,
                    this.teamMemberId,
                    this.refundIds,
                    this.riskEvaluation,
                    this.buyerEmailAddress,
                    this.billingAddress,
                    this.shippingAddress,
                    this.note,
                    this.statementDescriptionIdentifier,
                    this.capabilities,
                    this.receiptNumber,
                    this.receiptUrl,
                    this.deviceDetails,
                    this.applicationDetails,
                    this.versionToken);
            }
        }
    }
}