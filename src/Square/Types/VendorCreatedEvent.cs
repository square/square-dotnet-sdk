using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Published when a [Vendor](entity:Vendor) is created.
/// </summary>
public record VendorCreatedEvent
{
    /// <summary>
    /// The ID of a seller associated with this event.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The ID of a location associated with the event, if the event is associated with the location of the seller.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The type of this event. The value is `"vendor.created".`
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// A unique ID for this event.
    /// </summary>
    [JsonPropertyName("event_id")]
    public string? EventId { get; set; }

    /// <summary>
    /// The RFC 3339-formatted time when the underlying event data object is created.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The data associated with this event.
    /// </summary>
    [JsonPropertyName("data")]
    public VendorCreatedEventData? Data { get; set; }

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
