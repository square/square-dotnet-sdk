using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents how points for a [loyalty promotion](entity:LoyaltyPromotion) are calculated,
/// either by multiplying the points earned from the base program or by adding a specified number
/// of points to the points earned from the base program.
/// </summary>
public record LoyaltyPromotionIncentive
{
    /// <summary>
    /// The type of points incentive.
    /// See [LoyaltyPromotionIncentiveType](#type-loyaltypromotionincentivetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required LoyaltyPromotionIncentiveType Type { get; set; }

    /// <summary>
    /// Additional data for a `POINTS_MULTIPLIER` incentive type.
    /// </summary>
    [JsonPropertyName("points_multiplier_data")]
    public LoyaltyPromotionIncentivePointsMultiplierData? PointsMultiplierData { get; set; }

    /// <summary>
    /// Additional data for a `POINTS_ADDITION` incentive type.
    /// </summary>
    [JsonPropertyName("points_addition_data")]
    public LoyaltyPromotionIncentivePointsAdditionData? PointsAdditionData { get; set; }

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
