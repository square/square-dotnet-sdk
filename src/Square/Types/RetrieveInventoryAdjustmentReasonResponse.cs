using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an output from a call to [RetrieveInventoryAdjustmentReason](api-endpoint:Inventory-RetrieveInventoryAdjustmentReason).
/// </summary>
[Serializable]
public record RetrieveInventoryAdjustmentReasonResponse : IJsonOnDeserialized
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
    /// The successfully retrieved inventory adjustment reason. Deleted custom
    /// reasons can be retrieved by ID and have `is_deleted` set to `true`.
    /// </summary>
    [JsonPropertyName("adjustment_reason")]
    public InventoryAdjustmentReason? AdjustmentReason { get; set; }

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
