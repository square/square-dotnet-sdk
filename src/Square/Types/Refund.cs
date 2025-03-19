using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a refund processed for a Square transaction.
/// </summary>
public record Refund
{
    /// <summary>
    /// The refund's unique ID.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the refund's associated location.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// The ID of the transaction that the refunded tender is part of.
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// The ID of the refunded tender.
    /// </summary>
    [JsonPropertyName("tender_id")]
    public required string TenderId { get; set; }

    /// <summary>
    /// The timestamp for when the refund was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The reason for the refund being issued.
    /// </summary>
    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    /// <summary>
    /// The amount of money refunded to the buyer.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// The current status of the refund (`PENDING`, `APPROVED`, `REJECTED`,
    /// or `FAILED`).
    /// See [RefundStatus](#type-refundstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public required RefundStatus Status { get; set; }

    /// <summary>
    /// The amount of Square processing fee money refunded to the *merchant*.
    /// </summary>
    [JsonPropertyName("processing_fee_money")]
    public Money? ProcessingFeeMoney { get; set; }

    /// <summary>
    /// Additional recipients (other than the merchant) receiving a portion of this refund.
    /// For example, fees assessed on a refund of a purchase by a third party integration.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public IEnumerable<AdditionalRecipient>? AdditionalRecipients { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
