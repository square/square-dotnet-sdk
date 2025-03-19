using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines output parameters in a response of the
/// [SwapPlan](api-endpoint:Subscriptions-SwapPlan) endpoint.
/// </summary>
public record SwapPlanResponse
{
    /// <summary>
    /// Errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The subscription with the updated subscription plan.
    /// </summary>
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; set; }

    /// <summary>
    /// A list of a `SWAP_PLAN` action created by the request.
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
