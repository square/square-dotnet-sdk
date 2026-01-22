using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an accrual rule, which defines how buyers can earn points from the base [loyalty program](entity:LoyaltyProgram).
/// </summary>
[Serializable]
public record LoyaltyProgramAccrualRule : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of the accrual rule that defines how buyers can earn points.
    /// See [LoyaltyProgramAccrualRuleType](#type-loyaltyprogramaccrualruletype) for possible values
    /// </summary>
    [JsonPropertyName("accrual_type")]
    public required LoyaltyProgramAccrualRuleType AccrualType { get; set; }

    /// <summary>
    /// The number of points that
    /// buyers earn based on the `accrual_type`.
    /// </summary>
    [JsonPropertyName("points")]
    public int? Points { get; set; }

    /// <summary>
    /// Additional data for rules with the `VISIT` accrual type.
    /// </summary>
    [JsonPropertyName("visit_data")]
    public LoyaltyProgramAccrualRuleVisitData? VisitData { get; set; }

    /// <summary>
    /// Additional data for rules with the `SPEND` accrual type.
    /// </summary>
    [JsonPropertyName("spend_data")]
    public LoyaltyProgramAccrualRuleSpendData? SpendData { get; set; }

    /// <summary>
    /// Additional data for rules with the `ITEM_VARIATION` accrual type.
    /// </summary>
    [JsonPropertyName("item_variation_data")]
    public LoyaltyProgramAccrualRuleItemVariationData? ItemVariationData { get; set; }

    /// <summary>
    /// Additional data for rules with the `CATEGORY` accrual type.
    /// </summary>
    [JsonPropertyName("category_data")]
    public LoyaltyProgramAccrualRuleCategoryData? CategoryData { get; set; }

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
