using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

public record TestWebhookSubscriptionRequest
{
    /// <summary>
    /// [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to test.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The event type that will be used to test the [Subscription](entity:WebhookSubscription). The event type must be
    /// contained in the list of event types in the [Subscription](entity:WebhookSubscription).
    /// </summary>
    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
