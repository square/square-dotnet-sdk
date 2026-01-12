using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the result of testing a webhook subscription. Note: The actual API returns these fields at the root level of TestWebhookSubscriptionResponse, not nested under this object.
/// </summary>
[Serializable]
public record SubscriptionTestResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A Square-generated unique ID for the subscription test result.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The HTTP status code returned by the notification URL.
    /// </summary>
    [JsonPropertyName("status_code")]
    public int? StatusCode { get; set; }

    /// <summary>
    /// The payload that was sent in the test notification.
    /// </summary>
    [JsonPropertyName("payload")]
    public Dictionary<string, object?>? Payload { get; set; }

    /// <summary>
    /// The timestamp of when the subscription was created, in RFC 3339 format.
    /// For example, "2016-09-04T23:59:33.123Z".
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the subscription was updated, in RFC 3339 format. For example, "2016-09-04T23:59:33.123Z".
    /// Because a subscription test result is unique, this field is the same as the `created_at` field.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The URL that was used for the webhook notification test.
    /// </summary>
    [JsonPropertyName("notification_url")]
    public string? NotificationUrl { get; set; }

    /// <summary>
    /// Whether the notification passed any configured filters.
    /// </summary>
    [JsonPropertyName("passes_filter")]
    public bool? PassesFilter { get; set; }

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
