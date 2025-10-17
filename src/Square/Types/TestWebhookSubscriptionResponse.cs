using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [TestWebhookSubscription](api-endpoint:WebhookSubscriptions-TestWebhookSubscription) endpoint.
///
/// Note: If there are errors processing the request, the [SubscriptionTestResult](entity:SubscriptionTestResult) field is not
/// present.
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
