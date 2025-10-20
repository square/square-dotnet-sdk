using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

[Serializable]
public record GetSubscriptionsRequest
{
    /// <summary>
    /// [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
