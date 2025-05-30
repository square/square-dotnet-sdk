using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a refund of a payment made using Square. Contains information about
/// the original payment and the amount of money refunded.
/// </summary>
public record PaymentRefund
{
    /// <summary>
    /// The unique ID for this refund, generated by Square.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The refund's status:
    /// - `PENDING` - Awaiting approval.
    /// - `COMPLETED` - Successfully completed.
    /// - `REJECTED` - The refund was rejected.
    /// - `FAILED` - An error occurred.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The location ID associated with the payment this refund is attached to.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// Flag indicating whether or not the refund is linked to an existing payment in Square.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("unlinked")]
    public bool? Unlinked { get; set; }

    /// <summary>
    /// The destination type for this refund.
    ///
    /// Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `BUY_NOW_PAY_LATER`, `CASH`,
    /// `EXTERNAL`, and `SQUARE_ACCOUNT`.
    /// </summary>
    [JsonPropertyName("destination_type")]
    public string? DestinationType { get; set; }

    /// <summary>
    /// Contains information about the refund destination. This field is populated only if
    /// `destination_id` is defined in the `RefundPayment` request.
    /// </summary>
    [JsonPropertyName("destination_details")]
    public DestinationDetails? DestinationDetails { get; set; }

    /// <summary>
    /// The amount of money refunded. This amount is specified in the smallest denomination
    /// of the applicable currency (for example, US dollar amounts are specified in cents).
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// The amount of money the application developer contributed to help cover the refunded amount.
    /// This amount is specified in the smallest denomination of the applicable currency (for example,
    /// US dollar amounts are specified in cents). For more information, see
    /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts).
    /// </summary>
    [JsonPropertyName("app_fee_money")]
    public Money? AppFeeMoney { get; set; }

    /// <summary>
    /// Processing fees and fee adjustments assessed by Square for this refund.
    /// </summary>
    [JsonPropertyName("processing_fee")]
    public IEnumerable<ProcessingFee>? ProcessingFee { get; set; }

    /// <summary>
    /// The ID of the payment associated with this refund.
    /// </summary>
    [JsonPropertyName("payment_id")]
    public string? PaymentId { get; set; }

    /// <summary>
    /// The ID of the order associated with the refund.
    /// </summary>
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The reason for the refund.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// The timestamp of when the refund was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the refund was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// An optional ID of the team member associated with taking the payment.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// An optional ID for a Terminal refund.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("terminal_refund_id")]
    public string? TerminalRefundId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
