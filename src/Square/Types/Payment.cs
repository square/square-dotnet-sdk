using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a payment processed by the Square API.
/// </summary>
[Serializable]
public record Payment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID for the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The timestamp of when the payment was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the payment was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The amount processed for this payment, not including `tip_money`.
    ///
    /// The amount is specified in the smallest denomination of the applicable currency (for example,
    /// US dollar amounts are specified in cents). For more information, see
    /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// The amount designated as a tip for the seller's staff.
    ///
    /// Tips for external vendors such as a 3rd party delivery courier must be recorded using Order.service_charges.
    ///
    /// This amount is specified in the smallest denomination of the applicable currency (for example,
    /// US dollar amounts are specified in cents). For more information, see
    /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
    /// </summary>
    [JsonPropertyName("tip_money")]
    public Money? TipMoney { get; set; }

    /// <summary>
    /// The total amount for the payment, including `amount_money` and `tip_money`.
    /// This amount is specified in the smallest denomination of the applicable currency (for example,
    /// US dollar amounts are specified in cents). For more information, see
    /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
    /// </summary>
    [JsonPropertyName("total_money")]
    public Money? TotalMoney { get; set; }

    /// <summary>
    /// The amount the developer is taking as a fee for facilitating the payment on behalf
    /// of the seller. This amount is specified in the smallest denomination of the applicable currency
    /// (for example, US dollar amounts are specified in cents). For more information,
    /// see [Take Payments and Collect Fees](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees).
    ///
    /// The amount cannot be more than 90% of the `total_money` value.
    ///
    /// To set this field, `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required.
    /// For more information, see [Permissions](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees#permissions).
    /// </summary>
    [JsonPropertyName("app_fee_money")]
    public Money? AppFeeMoney { get; set; }

    /// <summary>
    /// The amount of money approved for this payment. This value may change if Square chooses to
    /// obtain reauthorization as part of a call to [UpdatePayment](api-endpoint:Payments-UpdatePayment).
    /// </summary>
    [JsonPropertyName("approved_money")]
    public Money? ApprovedMoney { get; set; }

    /// <summary>
    /// The processing fees and fee adjustments assessed by Square for this payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("processing_fee")]
    public IEnumerable<ProcessingFee>? ProcessingFee { get; set; }

    /// <summary>
    /// The total amount of the payment refunded to date.
    ///
    /// This amount is specified in the smallest denomination of the applicable currency (for example,
    /// US dollar amounts are specified in cents).
    /// </summary>
    [JsonPropertyName("refunded_money")]
    public Money? RefundedMoney { get; set; }

    /// <summary>
    /// Indicates whether the payment is APPROVED, PENDING, COMPLETED, CANCELED, or FAILED.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The duration of time after the payment's creation when Square automatically applies the
    /// `delay_action` to the payment. This automatic `delay_action` applies only to payments that
    /// do not reach a terminal state (COMPLETED, CANCELED, or FAILED) before the `delay_duration`
    /// time period.
    ///
    /// This field is specified as a time duration, in RFC 3339 format.
    ///
    /// Notes:
    /// This feature is only supported for card payments.
    ///
    /// Default:
    ///
    /// - Card-present payments: "PT36H" (36 hours) from the creation time.
    /// - Card-not-present payments: "P7D" (7 days) from the creation time.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("delay_duration")]
    public string? DelayDuration { get; set; }

    /// <summary>
    /// The action to be applied to the payment when the `delay_duration` has elapsed.
    ///
    /// Current values include `CANCEL` and `COMPLETE`.
    /// </summary>
    [JsonPropertyName("delay_action")]
    public string? DelayAction { get; set; }

    /// <summary>
    /// The read-only timestamp of when the `delay_action` is automatically applied,
    /// in RFC 3339 format.
    ///
    /// Note that this field is calculated by summing the payment's `delay_duration` and `created_at`
    /// fields. The `created_at` field is generated by Square and might not exactly match the
    /// time on your local machine.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("delayed_until")]
    public string? DelayedUntil { get; set; }

    /// <summary>
    /// The source type for this payment.
    ///
    /// Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `BUY_NOW_PAY_LATER`, `SQUARE_ACCOUNT`,
    /// `CASH` and `EXTERNAL`. For information about these payment source types,
    /// see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("source_type")]
    public string? SourceType { get; set; }

    /// <summary>
    /// Details about a card payment. These details are only populated if the source_type is `CARD`.
    /// </summary>
    [JsonPropertyName("card_details")]
    public CardPaymentDetails? CardDetails { get; set; }

    /// <summary>
    /// Details about a cash payment. These details are only populated if the source_type is `CASH`.
    /// </summary>
    [JsonPropertyName("cash_details")]
    public CashPaymentDetails? CashDetails { get; set; }

    /// <summary>
    /// Details about a bank account payment. These details are only populated if the source_type is `BANK_ACCOUNT`.
    /// </summary>
    [JsonPropertyName("bank_account_details")]
    public BankAccountPaymentDetails? BankAccountDetails { get; set; }

    /// <summary>
    /// Details about an external payment. The details are only populated
    /// if the `source_type` is `EXTERNAL`.
    /// </summary>
    [JsonPropertyName("external_details")]
    public ExternalPaymentDetails? ExternalDetails { get; set; }

    /// <summary>
    /// Details about an wallet payment. The details are only populated
    /// if the `source_type` is `WALLET`.
    /// </summary>
    [JsonPropertyName("wallet_details")]
    public DigitalWalletDetails? WalletDetails { get; set; }

    /// <summary>
    /// Details about a Buy Now Pay Later payment. The details are only populated
    /// if the `source_type` is `BUY_NOW_PAY_LATER`. For more information, see
    /// [Afterpay Payments](https://developer.squareup.com/docs/payments-api/take-payments/afterpay-payments).
    /// </summary>
    [JsonPropertyName("buy_now_pay_later_details")]
    public BuyNowPayLaterDetails? BuyNowPayLaterDetails { get; set; }

    /// <summary>
    /// Details about a Square Account payment. The details are only populated
    /// if the `source_type` is `SQUARE_ACCOUNT`.
    /// </summary>
    [JsonPropertyName("square_account_details")]
    public SquareAccountDetails? SquareAccountDetails { get; set; }

    /// <summary>
    /// The ID of the location associated with the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The ID of the order associated with the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// An optional ID that associates the payment with an entity in
    /// another system.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

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
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// __Deprecated__: Use `Payment.team_member_id` instead.
    ///
    /// An optional ID of the employee associated with taking the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// An optional ID of the [TeamMember](entity:TeamMember) associated with taking the payment.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// A list of `refund_id`s identifying refunds for the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("refund_ids")]
    public IEnumerable<string>? RefundIds { get; set; }

    /// <summary>
    /// Provides information about the risk associated with the payment, as determined by Square.
    /// This field is present for payments to sellers that have opted in to receive risk
    /// evaluations.
    /// </summary>
    [JsonPropertyName("risk_evaluation")]
    public RiskEvaluation? RiskEvaluation { get; set; }

    /// <summary>
    /// An optional ID for a Terminal checkout that is associated with the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("terminal_checkout_id")]
    public string? TerminalCheckoutId { get; set; }

    /// <summary>
    /// The buyer's email address.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("buyer_email_address")]
    public string? BuyerEmailAddress { get; set; }

    /// <summary>
    /// The buyer's billing address.
    /// </summary>
    [JsonPropertyName("billing_address")]
    public Address? BillingAddress { get; set; }

    /// <summary>
    /// The buyer's shipping address.
    /// </summary>
    [JsonPropertyName("shipping_address")]
    public Address? ShippingAddress { get; set; }

    /// <summary>
    /// An optional note to include when creating a payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// Additional payment information that gets added to the customer's card statement
    /// as part of the statement description.
    ///
    /// Note that the `statement_description_identifier` might get truncated on the statement description
    /// to fit the required information including the Square identifier (SQ *) and the name of the
    /// seller taking the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("statement_description_identifier")]
    public string? StatementDescriptionIdentifier { get; set; }

    /// <summary>
    /// Actions that can be performed on this payment:
    /// - `EDIT_AMOUNT_UP` - The payment amount can be edited up.
    /// - `EDIT_AMOUNT_DOWN` - The payment amount can be edited down.
    /// - `EDIT_TIP_AMOUNT_UP` - The tip amount can be edited up.
    /// - `EDIT_TIP_AMOUNT_DOWN` - The tip amount can be edited down.
    /// - `EDIT_DELAY_ACTION` - The delay_action can be edited.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("capabilities")]
    public IEnumerable<string>? Capabilities { get; set; }

    /// <summary>
    /// The payment's receipt number.
    /// The field is missing if a payment is canceled.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("receipt_number")]
    public string? ReceiptNumber { get; set; }

    /// <summary>
    /// The URL for the payment's receipt.
    /// The field is only populated for COMPLETED payments.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("receipt_url")]
    public string? ReceiptUrl { get; set; }

    /// <summary>
    /// Details about the device that took the payment.
    /// </summary>
    [JsonPropertyName("device_details")]
    public DeviceDetails? DeviceDetails { get; set; }

    /// <summary>
    /// Details about the application that took the payment.
    /// </summary>
    [JsonPropertyName("application_details")]
    public ApplicationDetails? ApplicationDetails { get; set; }

    /// <summary>
    /// Whether or not this payment was taken offline.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("is_offline_payment")]
    public bool? IsOfflinePayment { get; set; }

    /// <summary>
    /// Additional information about the payment if it was taken offline.
    /// </summary>
    [JsonPropertyName("offline_payment_details")]
    public OfflinePaymentDetails? OfflinePaymentDetails { get; set; }

    /// <summary>
    /// Used for optimistic concurrency. This opaque token identifies a specific version of the
    /// `Payment` object.
    /// </summary>
    [JsonPropertyName("version_token")]
    public string? VersionToken { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
