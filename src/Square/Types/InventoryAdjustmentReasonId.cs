using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Identifies a standard or custom inventory adjustment reason.
/// </summary>
[Serializable]
public record InventoryAdjustmentReasonId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The adjustment reason type.
    /// See [Type](#type-type) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public required InventoryAdjustmentReasonIdType Type { get; set; }

    /// <summary>
    /// The Square-generated ID of the custom adjustment reason. This field
    /// is only set when `type` is `CUSTOM`.
    /// </summary>
    [JsonPropertyName("custom_reason_id")]
    public string? CustomReasonId { get; set; }

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
