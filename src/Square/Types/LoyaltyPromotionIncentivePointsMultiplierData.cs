using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the metadata for a `POINTS_MULTIPLIER` type of [loyalty promotion incentive](entity:LoyaltyPromotionIncentive).
/// </summary>
public record LoyaltyPromotionIncentivePointsMultiplierData
{
    /// <summary>
    /// The multiplier used to calculate the number of points earned each time the promotion
    /// is triggered. For example, suppose a purchase qualifies for 5 points from the base loyalty program.
    /// If the purchase also qualifies for a `POINTS_MULTIPLIER` promotion incentive with a `points_multiplier`
    /// of 3, the buyer earns a total of 15 points (5 program points x 3 promotion multiplier = 15 points).
    ///
    /// DEPRECATED at version 2023-08-16. Replaced by the `multiplier` field.
    ///
    /// One of the following is required when specifying a points multiplier:
    /// - (Recommended) The `multiplier` field.
    /// - This deprecated `points_multiplier` field. If provided in the request, Square also returns `multiplier`
    /// with the equivalent value.
    /// </summary>
    [JsonPropertyName("points_multiplier")]
    public int? PointsMultiplier { get; set; }

    /// <summary>
    /// The multiplier used to calculate the number of points earned each time the promotion is triggered,
    /// specified as a string representation of a decimal. Square supports multipliers up to 10x, with three
    /// point precision for decimal multipliers. For example, suppose a purchase qualifies for 4 points from the
    /// base loyalty program. If the purchase also qualifies for a `POINTS_MULTIPLIER` promotion incentive with a
    /// `multiplier` of "1.5", the buyer earns a total of 6 points (4 program points x 1.5 promotion multiplier = 6 points).
    /// Fractional points are dropped.
    ///
    /// One of the following is required when specifying a points multiplier:
    /// - (Recommended) This `multiplier` field.
    /// - The deprecated `points_multiplier` field. If provided in the request, Square also returns `multiplier`
    /// with the equivalent value.
    /// </summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }

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
