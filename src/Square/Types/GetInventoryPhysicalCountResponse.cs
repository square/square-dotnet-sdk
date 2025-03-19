using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record GetInventoryPhysicalCountResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The requested [InventoryPhysicalCount](entity:InventoryPhysicalCount).
    /// </summary>
    [JsonPropertyName("count")]
    public InventoryPhysicalCount? Count { get; set; }

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
