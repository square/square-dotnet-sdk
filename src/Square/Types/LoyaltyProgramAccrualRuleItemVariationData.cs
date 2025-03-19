using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents additional data for rules with the `ITEM_VARIATION` accrual type.
/// </summary>
public record LoyaltyProgramAccrualRuleItemVariationData
{
    /// <summary>
    /// The ID of the `ITEM_VARIATION` [catalog object](entity:CatalogObject) that buyers can purchase to earn
    /// points.
    /// </summary>
    [JsonPropertyName("item_variation_id")]
    public required string ItemVariationId { get; set; }

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
