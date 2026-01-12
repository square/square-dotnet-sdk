using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Subscriptions;

[Serializable]
public record CancelSubscriptionsRequest
{
    /// <summary>
    /// The ID of the subscription to cancel.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
