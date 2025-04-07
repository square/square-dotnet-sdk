using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines output parameters in a response from the
/// [CancelSubscription](api-endpoint:Subscriptions-CancelSubscription) endpoint.
/// </summary>
public record CancelSubscriptionResponse
{
    /// <summary>
    /// Errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The specified subscription scheduled for cancellation according to the action created by the request.
    /// </summary>
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; set; }

    /// <summary>
    /// A list of a single `CANCEL` action scheduled for the subscription.
    /// </summary>
    [JsonPropertyName("actions")]
    public IEnumerable<SubscriptionAction>? Actions { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
