using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

[Serializable]
public record CreateWebhookSubscriptionRequest
{
    /// <summary>
    /// A unique string that identifies the [CreateWebhookSubscription](api-endpoint:WebhookSubscriptions-CreateWebhookSubscription) request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// The [Subscription](entity:WebhookSubscription) to create.
    /// </summary>
    [JsonPropertyName("subscription")]
    public required WebhookSubscription Subscription { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
