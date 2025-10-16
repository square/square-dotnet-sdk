using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Data model for updating a transfer order. All fields are optional.
/// </summary>
public record UpdateTransferOrderData
{
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
