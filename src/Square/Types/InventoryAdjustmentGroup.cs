using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record InventoryAdjustmentGroup
{
    /// <summary>
    /// A unique ID generated by Square for the
    /// `InventoryAdjustmentGroup`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The inventory adjustment of the composed variation.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("root_adjustment_id")]
    public string? RootAdjustmentId { get; set; }

    /// <summary>
    /// Representative `from_state` for adjustments within the group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,
    /// there can be two component adjustments in the group: one from `IN_STOCK`to `COMPOSED` and the other one from `COMPOSED` to `SOLD`.
    /// Here, the representative `from_state` for the `InventoryAdjustmentGroup` is `IN_STOCK`.
    /// See [InventoryState](#type-inventorystate) for possible values
    /// </summary>
    [JsonPropertyName("from_state")]
    public InventoryState? FromState { get; set; }

    /// <summary>
    /// Representative `to_state` for adjustments within group. For example, for a group adjustment from `IN_STOCK` to `SOLD`,
    /// the two component adjustments in the group can be from `IN_STOCK` to `COMPOSED` and from `COMPOSED` to `SOLD`.
    /// Here, the representative `to_state` of the `InventoryAdjustmentGroup` is `SOLD`.
    /// See [InventoryState](#type-inventorystate) for possible values
    /// </summary>
    [JsonPropertyName("to_state")]
    public InventoryState? ToState { get; set; }

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
