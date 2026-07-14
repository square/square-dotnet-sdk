using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an inventory adjustment reason.
/// </summary>
[Serializable]
public record InventoryAdjustmentReason : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The identifier for this inventory adjustment reason.
    /// </summary>
    [JsonPropertyName("id")]
    public required InventoryAdjustmentReasonId Id { get; set; }

    /// <summary>
    /// The seller-facing name for a custom inventory adjustment reason. This
    /// field is empty for standard and system-generated adjustment reasons.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Indicates whether this inventory adjustment reason increases or
    /// decreases inventory. This field is set for custom reasons and for standard
    /// seller-selectable reasons. It is empty for system-generated inventory
    /// events.
    /// See [Direction](#type-direction) for possible values
    /// </summary>
    [JsonPropertyName("direction")]
    public InventoryAdjustmentReasonDirection? Direction { get; set; }

    /// <summary>
    /// An RFC 3339-formatted timestamp that indicates when the custom
    /// adjustment reason was created. This field is empty for standard
    /// adjustment reasons.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// An RFC 3339-formatted timestamp that indicates when the custom
    /// adjustment reason was last updated. This field is empty for standard
    /// adjustment reasons.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Indicates whether this custom inventory adjustment reason has been
    /// deleted. Deleted custom reasons can still be retrieved by ID, but are
    /// omitted from list responses unless deleted reasons are explicitly included.
    /// To restore a deleted custom reason, call
    /// [RestoreInventoryAdjustmentReason](api-endpoint:Inventory-RestoreInventoryAdjustmentReason).
    /// This field is always `false` for standard and system-generated adjustment
    /// reasons.
    /// </summary>
    [JsonPropertyName("is_deleted")]
    public bool? IsDeleted { get; set; }

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
