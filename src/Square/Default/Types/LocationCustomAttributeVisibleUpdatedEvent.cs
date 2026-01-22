using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Published when a location [custom attribute](entity:CustomAttribute) that is visible
/// to the subscribing application is created or updated. A notification is sent when:
/// - Your application creates or updates a custom attribute owned by your application, regardless of the `visibility` setting.
/// - Any application creates or updates a custom attribute whose `visibility` is `VISIBILITY_READ_ONLY`
/// or `VISIBILITY_READ_WRITE_VALUES`.
///
/// Custom attributes set to `VISIBILITY_READ_WRITE_VALUES` can be created or updated by any application, but those set to
/// `VISIBILITY_READ_ONLY` or `VISIBILITY_HIDDEN` can only be created or updated by the owner. Custom attributes are owned
/// by the application that created the corresponding [custom attribute definition](entity:CustomAttributeDefinition).
/// </summary>
[Serializable]
public record LocationCustomAttributeVisibleUpdatedEvent : IJsonOnDeserialized
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
    /// The type of this event. The value is `"location.custom_attribute.visible.updated"`.
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
