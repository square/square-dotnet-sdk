using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter criteria for searching transfer orders
/// </summary>
public record TransferOrderFilter
{
    /// <summary>
    /// Filter by source location IDs
    /// </summary>
    [JsonPropertyName("source_location_ids")]
    public IEnumerable<string>? SourceLocationIds { get; set; }

    /// <summary>
    /// Filter by destination location IDs
    /// </summary>
    [JsonPropertyName("destination_location_ids")]
    public IEnumerable<string>? DestinationLocationIds { get; set; }

    /// <summary>
    /// Filter by order statuses
    /// See [TransferOrderStatus](#type-transferorderstatus) for possible values
    /// </summary>
    [JsonPropertyName("statuses")]
    public IEnumerable<TransferOrderStatus>? Statuses { get; set; }

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
