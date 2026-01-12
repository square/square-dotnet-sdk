using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Published when a customer [custom attribute](entity:CustomAttribute) that is visible
/// to all applications is deleted. A notification is sent when any application deletes a custom attribute
/// whose `visibility` is `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
///
/// This event is replaced by
/// [customer.custom_attribute.visible.deleted](webhook:customer.custom_attribute.visible.deleted),
/// which applies to custom attributes that are visible to the subscribing application.
/// </summary>
[Serializable]
public record CustomerCustomAttributeDeletedPublicEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
