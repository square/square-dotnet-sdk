using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents a payment refund processed by the Square Terminal. Only supports Interac (Canadian debit network) payment refunds.
/// </summary>
[Serializable]
public record TerminalRefund : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID for this `TerminalRefund`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The reference to the payment refund created by completing this `TerminalRefund`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }

    /// <summary>
    /// The unique ID of the payment being refunded.
    /// </summary>
    [JsonPropertyName("payment_id")]
    public required string PaymentId { get; set; }

    /// <summary>
    /// The reference to the Square order ID for the payment identified by the `payment_id`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The amount of money, inclusive of `tax_money`, that the `TerminalRefund` should return.
    /// This value is limited to the amount taken in the original payment minus any completed or
    /// pending refunds.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// A description of the reason for the refund.
    /// </summary>
    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    /// <summary>
    /// The unique ID of the device intended for this `TerminalRefund`.
    /// The Id can be retrieved from /v2/devices api.
    /// </summary>
    [JsonPropertyName("device_id")]
    public required string DeviceId { get; set; }

    /// <summary>
    /// The RFC 3339 duration, after which the refund is automatically canceled.
    /// A `TerminalRefund` that is `PENDING` is automatically `CANCELED` and has a cancellation reason
    /// of `TIMED_OUT`.
    ///
    /// Default: 5 minutes from creation.
    ///
    /// Maximum: 5 minutes
    /// </summary>
    [JsonPropertyName("deadline_duration")]
    public string? DeadlineDuration { get; set; }

    /// <summary>
    /// The status of the `TerminalRefund`.
    /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, or `COMPLETED`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Present if the status is `CANCELED`.
    /// See [ActionCancelReason](#type-actioncancelreason) for possible values
    /// </summary>
    [JsonPropertyName("cancel_reason")]
    public ActionCancelReason? CancelReason { get; set; }

    /// <summary>
    /// The time when the `TerminalRefund` was created, as an RFC 3339 timestamp.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The time when the `TerminalRefund` was last updated, as an RFC 3339 timestamp.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the application that created the refund.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("app_id")]
    public string? AppId { get; set; }

    /// <summary>
    /// The location of the device where the `TerminalRefund` was directed.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

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
