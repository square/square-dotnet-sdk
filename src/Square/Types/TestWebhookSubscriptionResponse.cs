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
public record TestWebhookSubscriptionResponse
{
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
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
