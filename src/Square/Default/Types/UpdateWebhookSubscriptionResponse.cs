using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines the fields that are included in the response body of
/// a request to the [UpdateWebhookSubscription](api-endpoint:WebhookSubscriptions-UpdateWebhookSubscription) endpoint.
///
/// Note: If there are errors processing the request, the [Subscription](entity:WebhookSubscription) is not
/// present.
/// </summary>
[Serializable]
public record UpdateWebhookSubscriptionResponse : IJsonOnDeserialized
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
    /// The updated [Subscription](entity:WebhookSubscription).
    /// </summary>
    [JsonPropertyName("subscription")]
    public WebhookSubscription? Subscription { get; set; }

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
