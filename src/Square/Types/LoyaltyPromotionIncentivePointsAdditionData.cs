using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the metadata for a `POINTS_ADDITION` type of [loyalty promotion incentive](entity:LoyaltyPromotionIncentive).
/// </summary>
public record LoyaltyPromotionIncentivePointsAdditionData
{
    /// <summary>
    /// The number of additional points to earn each time the promotion is triggered. For example,
    /// suppose a purchase qualifies for 5 points from the base loyalty program. If the purchase also
    /// qualifies for a `POINTS_ADDITION` promotion incentive with a `points_addition` of 3, the buyer
    /// earns a total of 8 points (5 program points + 3 promotion points = 8 points).
    /// </summary>
    [JsonPropertyName("points_addition")]
    public required int PointsAddition { get; set; }

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
