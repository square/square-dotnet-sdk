using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Data for creating a new transfer order to move [CatalogItemVariation](entity:CatalogItemVariation)s
/// between [Location](entity:Location)s. Used with the [CreateTransferOrder](api-endpoint:TransferOrders-CreateTransferOrder)
/// endpoint.
/// </summary>
public record CreateTransferOrderData
{
    /// <summary>
    /// The source [Location](entity:Location) that will send the items. Must be an active location
    /// in your Square account with sufficient inventory of the requested items.
    /// </summary>
    [JsonPropertyName("source_location_id")]
    public required string SourceLocationId { get; set; }

    /// <summary>
    /// The destination [Location](entity:Location) that will receive the items. Must be an active location
    /// in your Square account
    /// </summary>
    [JsonPropertyName("destination_location_id")]
    public required string DestinationLocationId { get; set; }

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
    /// Optional shipment tracking number
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string? TrackingNumber { get; set; }

    /// <summary>
    /// ID of the [TeamMember](entity:TeamMember) creating this transfer order. Used for tracking
    /// and auditing purposes.
    /// </summary>
    [JsonPropertyName("created_by_team_member_id")]
    public string? CreatedByTeamMemberId { get; set; }

    /// <summary>
    /// List of [CatalogItemVariation](entity:CatalogItemVariation)s to transfer, including quantities
    /// </summary>
    [JsonPropertyName("line_items")]
    public IEnumerable<CreateTransferOrderLineData>? LineItems { get; set; }

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
