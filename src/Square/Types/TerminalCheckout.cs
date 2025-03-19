using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a checkout processed by the Square Terminal.
/// </summary>
public record TerminalCheckout
{
    /// <summary>
    /// A unique ID for this `TerminalCheckout`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The amount of money (including the tax amount) that the Square Terminal device should try to collect.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// An optional user-defined reference ID that can be used to associate
    /// this `TerminalCheckout` to another entity in an external system. For example, an order
    /// ID generated by a third-party shopping cart. The ID is also associated with any payments
    /// used to complete the checkout.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// An optional note to associate with the checkout, as well as with any payments used to complete the checkout.
    /// Note: maximum 500 characters
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The reference to the Square order ID for the checkout request.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// Payment-specific options for the checkout request. Supported only in the US.
    /// </summary>
    [JsonPropertyName("payment_options")]
    public PaymentOptions? PaymentOptions { get; set; }

    /// <summary>
    /// Options to control the display and behavior of the Square Terminal device.
    /// </summary>
    [JsonPropertyName("device_options")]
    public required DeviceCheckoutOptions DeviceOptions { get; set; }

    /// <summary>
    /// An RFC 3339 duration, after which the checkout is automatically canceled.
    /// A `TerminalCheckout` that is `PENDING` is automatically `CANCELED` and has a cancellation reason
    /// of `TIMED_OUT`.
    ///
    /// Default: 5 minutes from creation
    ///
    /// Maximum: 5 minutes
    /// </summary>
    [JsonPropertyName("deadline_duration")]
    public string? DeadlineDuration { get; set; }

    /// <summary>
    /// The status of the `TerminalCheckout`.
    /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED`
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The reason why `TerminalCheckout` is canceled. Present if the status is `CANCELED`.
    /// See [ActionCancelReason](#type-actioncancelreason) for possible values
    /// </summary>
    [JsonPropertyName("cancel_reason")]
    public ActionCancelReason? CancelReason { get; set; }

    /// <summary>
    /// A list of IDs for payments created by this `TerminalCheckout`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("payment_ids")]
    public IEnumerable<string>? PaymentIds { get; set; }

    /// <summary>
    /// The time when the `TerminalCheckout` was created, as an RFC 3339 timestamp.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The time when the `TerminalCheckout` was last updated, as an RFC 3339 timestamp.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the application that created the checkout.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    /// <summary>
    /// The location of the device where the `TerminalCheckout` was directed.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The type of payment the terminal should attempt to capture from. Defaults to `CARD_PRESENT`.
    /// See [CheckoutOptionsPaymentType](#type-checkoutoptionspaymenttype) for possible values
    /// </summary>
    [JsonPropertyName("payment_type")]
    public CheckoutOptionsPaymentType? PaymentType { get; set; }

    /// <summary>
    /// An optional ID of the team member associated with creating the checkout.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// An optional ID of the customer associated with the checkout.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The amount the developer is taking as a fee for facilitating the payment on behalf
    /// of the seller.
    ///
    /// The amount cannot be more than 90% of the total amount of the payment.
    ///
    /// The amount must be specified in the smallest denomination of the applicable currency (for example, US dollar amounts are specified in cents). For more information, see [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
    ///
    /// The fee currency code must match the currency associated with the seller that is accepting the payment. The application must be from a developer account in the same country and using the same currency code as the seller.
    ///
    /// For more information about the application fee scenario, see [Take Payments and Collect Fees](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees).
    ///
    /// To set this field, PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS OAuth permission is required. For more information, see [Permissions](https://developer.squareup.com/docs/payments-api/take-payments-and-collect-fees#permissions).
    ///
    /// Supported only in the US.
    /// </summary>
    [JsonPropertyName("app_fee_money")]
    public Money? AppFeeMoney { get; set; }

    /// <summary>
    /// Optional additional payment information to include on the customer's card statement as
    /// part of the statement description. This can be, for example, an invoice number, ticket number,
    /// or short description that uniquely identifies the purchase. Supported only in the US.
    /// </summary>
    [JsonPropertyName("statement_description_identifier")]
    public string? StatementDescriptionIdentifier { get; set; }

    /// <summary>
    /// The amount designated as a tip, in addition to `amount_money`. This may only be set for a
    /// checkout that has tipping disabled (`tip_settings.allow_tipping` is `false`). Supported only in
    /// the US.
    /// </summary>
    [JsonPropertyName("tip_money")]
    public Money? TipMoney { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
