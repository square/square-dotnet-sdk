using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines output parameters in a response from the
/// [PauseSubscription](api-endpoint:Subscriptions-PauseSubscription) endpoint.
/// </summary>
public record PauseSubscriptionResponse
{
    /// <summary>
    /// Errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The subscription to be paused by the scheduled `PAUSE` action.
    /// </summary>
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; set; }

    /// <summary>
    /// The list of a `PAUSE` action and a possible `RESUME` action created by the request.
    /// </summary>
    [JsonPropertyName("actions")]
    public IEnumerable<SubscriptionAction>? Actions { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
