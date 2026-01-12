using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Data model for updating a transfer order. All fields are optional.
/// </summary>
[Serializable]
public record UpdateTransferOrderData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The source [Location](entity:Location) that will send the items. Must be an active location
    /// in your Square account with sufficient inventory of the requested items.
    /// </summary>
    [JsonPropertyName("source_location_id")]
    public string? SourceLocationId { get; set; }

    /// <summary>
    /// The destination [Location](entity:Location) that will receive the items. Must be an active location
    /// in your Square account.
    /// </summary>
    [JsonPropertyName("destination_location_id")]
    public string? DestinationLocationId { get; set; }

    /// <summary>
    /// Expected transfer date in RFC 3339 format (e.g. "2023-10-01T12:00:00Z").
    /// </summary>
    [JsonPropertyName("expected_at")]
    public string? ExpectedAt { get; set; }

    /// <summary>
    /// Optional notes about the transfer
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// Shipment tracking number
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string? TrackingNumber { get; set; }

    /// <summary>
    /// List of items being transferred
    /// </summary>
    [JsonPropertyName("line_items")]
    public IEnumerable<UpdateTransferOrderLineData>? LineItems { get; set; }

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
