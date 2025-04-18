using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents additional data for rules with the `SPEND` accrual type.
/// </summary>
public record LoyaltyProgramAccrualRuleSpendData
{
    /// <summary>
    /// The amount that buyers must spend to earn points.
    /// For example, given an "Earn 1 point for every $10 spent" accrual rule, a buyer who spends $105 earns 10 points.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// The IDs of any `CATEGORY` catalog objects that are excluded from points accrual.
    ///
    /// You can use the [BatchRetrieveCatalogObjects](api-endpoint:Catalog-BatchRetrieveCatalogObjects)
    /// endpoint to retrieve information about the excluded categories.
    /// </summary>
    [JsonPropertyName("excluded_category_ids")]
    public IEnumerable<string>? ExcludedCategoryIds { get; set; }

    /// <summary>
    /// The IDs of any `ITEM_VARIATION` catalog objects that are excluded from points accrual.
    ///
    /// You can use the [BatchRetrieveCatalogObjects](api-endpoint:Catalog-BatchRetrieveCatalogObjects)
    /// endpoint to retrieve information about the excluded item variations.
    /// </summary>
    [JsonPropertyName("excluded_item_variation_ids")]
    public IEnumerable<string>? ExcludedItemVariationIds { get; set; }

    /// <summary>
    /// Indicates how taxes should be treated when calculating the purchase amount used for points accrual.
    /// See [LoyaltyProgramAccrualRuleTaxMode](#type-loyaltyprogramaccrualruletaxmode) for possible values
    /// </summary>
    [JsonPropertyName("tax_mode")]
    public required LoyaltyProgramAccrualRuleTaxMode TaxMode { get; set; }

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
