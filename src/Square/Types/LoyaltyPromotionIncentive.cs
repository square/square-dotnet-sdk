using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents how points for a [loyalty promotion](entity:LoyaltyPromotion) are calculated,
/// either by multiplying the points earned from the base program or by adding a specified number
/// of points to the points earned from the base program.
/// </summary>
[Serializable]
public record LoyaltyPromotionIncentive : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
