using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents additional data for rules with the `ITEM_VARIATION` accrual type.
/// </summary>
[Serializable]
public record LoyaltyProgramAccrualRuleItemVariationData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the `ITEM_VARIATION` [catalog object](entity:CatalogObject) that buyers can purchase to earn
    /// points.
    /// </summary>
    [JsonPropertyName("item_variation_id")]
    public required string ItemVariationId { get; set; }

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
