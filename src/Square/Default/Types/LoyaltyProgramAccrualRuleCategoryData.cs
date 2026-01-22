using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents additional data for rules with the `CATEGORY` accrual type.
/// </summary>
[Serializable]
public record LoyaltyProgramAccrualRuleCategoryData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the `CATEGORY` [catalog object](entity:CatalogObject) that buyers can purchase to earn
    /// points.
    /// </summary>
    [JsonPropertyName("category_id")]
    public required string CategoryId { get; set; }

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
