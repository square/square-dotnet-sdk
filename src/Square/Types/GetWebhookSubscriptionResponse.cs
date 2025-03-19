using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [RetrieveWebhookSubscription](api-endpoint:WebhookSubscriptions-RetrieveWebhookSubscription) endpoint.
///
/// Note: if there are errors processing the request, the [Subscription](entity:WebhookSubscription) will not be
/// present.
/// </summary>
public record GetWebhookSubscriptionResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested [Subscription](entity:WebhookSubscription).
    /// </summary>
    [JsonPropertyName("subscription")]
    public WebhookSubscription? Subscription { get; set; }

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
