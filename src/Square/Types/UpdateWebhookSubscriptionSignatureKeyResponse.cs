using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [UpdateWebhookSubscriptionSignatureKey](api-endpoint:WebhookSubscriptions-UpdateWebhookSubscriptionSignatureKey) endpoint.
///
/// Note: If there are errors processing the request, the [Subscription](entity:WebhookSubscription) is not
/// present.
/// </summary>
public record UpdateWebhookSubscriptionSignatureKeyResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The new Square-generated signature key used to validate the origin of the webhook event.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("signature_key")]
    public string? SignatureKey { get; set; }

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
