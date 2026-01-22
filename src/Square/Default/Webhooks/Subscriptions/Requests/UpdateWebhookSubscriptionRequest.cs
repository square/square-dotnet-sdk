using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Webhooks;

[Serializable]
public record UpdateWebhookSubscriptionRequest
{
    /// <summary>
    /// [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The [Subscription](entity:WebhookSubscription) to update.
    /// </summary>
    [JsonPropertyName("subscription")]
    public WebhookSubscription? Subscription { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
