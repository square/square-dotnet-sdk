using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Published when evidence is added to a [Dispute](entity:Dispute)
/// from the Disputes Dashboard in the Seller Dashboard, the Square Point of Sale app,
/// or by calling either [CreateDisputeEvidenceFile](api-endpoint:Disputes-CreateDisputeEvidenceFile) or [CreateDisputeEvidenceText](api-endpoint:Disputes-CreateDisputeEvidenceText).
/// </summary>
public record DisputeEvidenceCreatedEvent
{
    /// <summary>
    /// The ID of the target merchant associated with the event.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The ID of the target location associated with the event.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The type of event this represents.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// A unique ID for the event.
    /// </summary>
    [JsonPropertyName("event_id")]
    public string? EventId { get; set; }

    /// <summary>
    /// Timestamp of when the event was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Data associated with the event.
    /// </summary>
    [JsonPropertyName("data")]
    public DisputeEvidenceCreatedEventData? Data { get; set; }

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
