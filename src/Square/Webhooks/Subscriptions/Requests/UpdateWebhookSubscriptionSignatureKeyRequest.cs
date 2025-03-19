using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

public record UpdateWebhookSubscriptionSignatureKeyRequest
{
    /// <summary>
    /// [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// A unique string that identifies the [UpdateWebhookSubscriptionSignatureKey](api-endpoint:WebhookSubscriptions-UpdateWebhookSubscriptionSignatureKey) request.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
