using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an [AccumulateLoyaltyPoints](api-endpoint:Loyalty-AccumulateLoyaltyPoints) response.
/// </summary>
public record AccumulateLoyaltyPointsResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The resulting loyalty event. Starting in Square version 2022-08-17, this field is no longer returned.
    /// </summary>
    [JsonPropertyName("event")]
    public LoyaltyEvent? Event { get; set; }

    /// <summary>
    /// The resulting loyalty events. If the purchase qualifies for points, the `ACCUMULATE_POINTS` event
    /// is always included. When using the Orders API, the `ACCUMULATE_PROMOTION_POINTS` event is included
    /// if the purchase also qualifies for a loyalty promotion.
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<LoyaltyEvent>? Events { get; set; }

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
