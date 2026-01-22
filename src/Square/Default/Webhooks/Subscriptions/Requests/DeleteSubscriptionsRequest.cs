using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Webhooks;

[Serializable]
public record DeleteSubscriptionsRequest
{
    /// <summary>
    /// [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to delete.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
