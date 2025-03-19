using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the details of a webhook subscription, including notification URL,
/// event types, and signature key.
/// </summary>
public record WebhookSubscription
{
    /// <summary>
    /// A Square-generated unique ID for the subscription.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of this subscription.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Indicates whether the subscription is enabled (`true`) or not (`false`).
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// The event types associated with this subscription.
    /// </summary>
    [JsonPropertyName("event_types")]
    public IEnumerable<string>? EventTypes { get; set; }

    /// <summary>
    /// The URL to which webhooks are sent.
    /// </summary>
    [JsonPropertyName("notification_url")]
    public string? NotificationUrl { get; set; }

    /// <summary>
    /// The API version of the subscription.
    /// This field is optional for `CreateWebhookSubscription`.
    /// The value defaults to the API version used by the application.
    /// </summary>
    [JsonPropertyName("api_version")]
    public string? ApiVersion { get; set; }

    /// <summary>
    /// The Square-generated signature key used to validate the origin of the webhook event.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("signature_key")]
    public string? SignatureKey { get; set; }

    /// <summary>
    /// The timestamp of when the subscription was created, in RFC 3339 format. For example, "2016-09-04T23:59:33.123Z".
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp of when the subscription was last updated, in RFC 3339 format.
    /// For example, "2016-09-04T23:59:33.123Z".
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
