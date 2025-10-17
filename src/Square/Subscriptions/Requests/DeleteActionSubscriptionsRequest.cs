using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Subscriptions;

[Serializable]
public record DeleteActionSubscriptionsRequest
{
    /// <summary>
    /// The ID of the subscription the targeted action is to act upon.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The ID of the targeted action to be deleted.
    /// </summary>
    [JsonIgnore]
    public required string ActionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
