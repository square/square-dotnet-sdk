using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record InventoryCountUpdatedEventObject
{
    /// <summary>
    /// The inventory counts.
    /// </summary>
    [JsonPropertyName("inventory_counts")]
    public IEnumerable<InventoryCount>? InventoryCounts { get; set; }

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
