using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents the metadata for a `POINTS_ADDITION` type of [loyalty promotion incentive](entity:LoyaltyPromotionIncentive).
/// </summary>
[Serializable]
public record LoyaltyPromotionIncentivePointsAdditionData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The number of additional points to earn each time the promotion is triggered. For example,
    /// suppose a purchase qualifies for 5 points from the base loyalty program. If the purchase also
    /// qualifies for a `POINTS_ADDITION` promotion incentive with a `points_addition` of 3, the buyer
    /// earns a total of 8 points (5 program points + 3 promotion points = 8 points).
    /// </summary>
    [JsonPropertyName("points_addition")]
    public required int PointsAddition { get; set; }

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
