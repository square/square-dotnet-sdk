using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an accrual rule, which defines how buyers can earn points from the base [loyalty program](entity:LoyaltyProgram).
/// </summary>
public record LoyaltyProgramAccrualRule
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
