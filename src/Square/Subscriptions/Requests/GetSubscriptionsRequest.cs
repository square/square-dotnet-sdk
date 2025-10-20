using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Subscriptions;

[Serializable]
public record GetSubscriptionsRequest
{
    /// <summary>
    /// The ID of the subscription to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string SubscriptionId { get; set; }

    /// <summary>
    /// A query parameter to specify related information to be included in the response.
    ///
    /// The supported query parameter values are:
    ///
    /// - `actions`: to include scheduled actions on the targeted subscription.
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
