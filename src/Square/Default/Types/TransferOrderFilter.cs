using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Filter criteria for searching transfer orders
/// </summary>
[Serializable]
public record TransferOrderFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
