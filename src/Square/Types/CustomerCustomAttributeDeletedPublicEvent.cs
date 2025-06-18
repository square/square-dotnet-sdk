using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Published when a customer [custom attribute](entity:CustomAttribute) that is visible
/// to all applications is deleted. A notification is sent when any application deletes a custom attribute
/// whose `visibility` is `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
///
/// This event is replaced by
/// [customer.custom_attribute.visible.deleted](webhook:customer.custom_attribute.visible.deleted),
/// which applies to custom attributes that are visible to the subscribing application.
/// </summary>
public record CustomerCustomAttributeDeletedPublicEvent
{
    /// <summary>
    /// The ID of the seller associated with the event that triggered the event notification.
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The type of this event. The value is `"customer.custom_attribute.public.deleted"`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// A unique ID for the event notification.
    /// </summary>
    [JsonPropertyName("event_id")]
    public string? EventId { get; set; }

    /// <summary>
    /// The timestamp that indicates when the event notification was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The data associated with the event that triggered the event notification.
    /// </summary>
    [JsonPropertyName("data")]
    public CustomAttributeEventData? Data { get; set; }

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
