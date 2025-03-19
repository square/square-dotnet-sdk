using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

public record GetSubscriptionsRequest
{
    /// <summary>
    /// [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
