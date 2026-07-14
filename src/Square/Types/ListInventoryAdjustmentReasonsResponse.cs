using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an output from a call to [ListInventoryAdjustmentReasons](api-endpoint:Inventory-ListInventoryAdjustmentReasons).
/// </summary>
[Serializable]
public record ListInventoryAdjustmentReasonsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Errors encountered when the request fails.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The standard, system-generated, and custom inventory adjustment
    /// reasons available to the seller.
    /// </summary>
    [JsonPropertyName("adjustment_reasons")]
    public IEnumerable<InventoryAdjustmentReason>? AdjustmentReasons { get; set; }

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
