using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Subscriptions;

[Serializable]
public record UpdateSubscriptionRequest
{
    /// <summary>
    /// The ID of the subscription to update.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// The subscription object containing the current version, and fields to update.
    /// Unset fields will be left at their current server values, and JSON `null` values will
    /// be treated as a request to clear the relevant data.
    /// </summary>
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
