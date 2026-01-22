using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of a request to the TestWebhookSubscription endpoint.
/// </summary>
[Serializable]
public record TestWebhookSubscriptionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The [SubscriptionTestResult](entity:SubscriptionTestResult).
    /// </summary>
    [JsonPropertyName("subscription_test_result")]
    public SubscriptionTestResult? SubscriptionTestResult { get; set; }

    /// <summary>
    /// The URL that was used for the webhook notification test.
    /// </summary>
    [JsonPropertyName("notification_url")]
    public string? NotificationUrl { get; set; }

    /// <summary>
    /// The HTTP status code returned by the notification URL.
    /// </summary>
    [JsonPropertyName("status_code")]
    public int? StatusCode { get; set; }

    /// <summary>
    /// Whether the notification passed any configured filters.
    /// </summary>
    [JsonPropertyName("passes_filter")]
    public bool? PassesFilter { get; set; }

    /// <summary>
    /// The payload that was sent in the test notification.
    /// </summary>
    [JsonPropertyName("payload")]
    public Dictionary<string, object?>? Payload { get; set; }

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
