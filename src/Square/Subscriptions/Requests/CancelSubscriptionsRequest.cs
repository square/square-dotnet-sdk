using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Subscriptions;

public record CancelSubscriptionsRequest
{
    /// <summary>
    /// The ID of the subscription to cancel.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
