using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
