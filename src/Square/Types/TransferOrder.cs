using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a transfer order for moving [CatalogItemVariation](entity:CatalogItemVariation)s
/// between [Location](entity:Location)s. Transfer orders track the entire lifecycle of an inventory
/// transfer, including:
/// - What items and quantities are being moved
/// - Source and destination locations
/// - Current [TransferOrderStatus](entity:TransferOrderStatus)
/// - Shipping information and tracking
/// - Which [TeamMember](entity:TeamMember) initiated the transfer
///
/// This object is commonly used to:
/// - Track [CatalogItemVariation](entity:CatalogItemVariation) movements between [Location](entity:Location)s
/// - Reconcile expected vs received quantities
/// - Monitor transfer progress and shipping status
/// - Audit inventory movement history
/// </summary>
public record TransferOrder
{
    /// <summary>
    /// Unique system-generated identifier for this transfer order. Use this ID for:
    /// - Retrieving transfer order details
    /// - Tracking status changes via webhooks
    /// - Linking transfers in external systems
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The source [Location](entity:Location) sending the [CatalogItemVariation](entity:CatalogItemVariation)s.
    /// This location must:
    /// - Be active in your Square organization
    /// - Have sufficient inventory for the items being transferred
    /// - Not be the same as the destination location
    ///
    /// This field is not updatable.
    /// </summary>
    [JsonPropertyName("source_location_id")]
    public string? SourceLocationId { get; set; }

    /// <summary>
    /// The destination [Location](entity:Location) receiving the [CatalogItemVariation](entity:CatalogItemVariation)s.
    /// This location must:
    /// - Be active in your Square organization
    /// - Not be the same as the source location
    ///
    /// This field is not updatable.
    /// </summary>
    [JsonPropertyName("destination_location_id")]
    public string? DestinationLocationId { get; set; }

    /// <summary>
    /// Current [TransferOrderStatus](entity:TransferOrderStatus) indicating where the order is in its lifecycle.
    /// Status transitions follow this progression:
    /// 1. [DRAFT](entity:TransferOrderStatus) -&gt; [STARTED](entity:TransferOrderStatus) via [StartTransferOrder](api-endpoint:TransferOrders-StartTransferOrder)
    /// 2. [STARTED](entity:TransferOrderStatus) -&gt; [PARTIALLY_RECEIVED](entity:TransferOrderStatus) via [ReceiveTransferOrder](api-endpoint:TransferOrders-ReceiveTransferOrder)
    /// 3. [PARTIALLY_RECEIVED](entity:TransferOrderStatus) -&gt; [COMPLETED](entity:TransferOrderStatus) after all items received
    ///
    /// Orders can be [CANCELED](entity:TransferOrderStatus) from [STARTED](entity:TransferOrderStatus) or
    /// [PARTIALLY_RECEIVED](entity:TransferOrderStatus) status.
    ///
    /// This field is read-only and reflects the current state of the transfer order, and cannot be updated directly. Use the appropriate
    /// endpoints (e.g. [StartPurchaseOrder](api-endpoint:TransferOrders-StartTransferOrder), to change the status.
    /// See [TransferOrderStatus](#type-transferorderstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TransferOrderStatus? Status { get; set; }

    /// <summary>
    /// Timestamp when the transfer order was created, in RFC 3339 format.
    /// Used for:
    /// - Auditing transfer history
    /// - Tracking order age
    /// - Reporting and analytics
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the transfer order was last updated, in RFC 3339 format.
    /// Updated when:
    /// - Order status changes
    /// - Items are received
    /// - Notes or metadata are modified
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Expected transfer completion date, in RFC 3339 format.
    /// Used for:
    /// - Planning inventory availability
    /// - Scheduling receiving staff
    /// - Monitoring transfer timeliness
    /// </summary>
    [JsonPropertyName("expected_at")]
    public string? ExpectedAt { get; set; }

    /// <summary>
    /// Timestamp when the transfer order was completed or canceled, in RFC 3339 format (e.g. "2023-10-01T12:00:00Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

    /// <summary>
    /// Optional notes about the transfer.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    /// <summary>
    /// Shipment tracking number for monitoring transfer progress.
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string? TrackingNumber { get; set; }

    /// <summary>
    /// ID of the [TeamMember](entity:TeamMember) who created this transfer order. This field is not writeable by the Connect V2 API.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_by_team_member_id")]
    public string? CreatedByTeamMemberId { get; set; }

    /// <summary>
    /// List of [CatalogItemVariation](entity:CatalogItemVariation)s being transferred.
    /// </summary>
    [JsonPropertyName("line_items")]
    public IEnumerable<TransferOrderLine>? LineItems { get; set; }

    /// <summary>
    /// Version for optimistic concurrency control. This is a monotonically increasing integer
    /// that changes whenever the transfer order is modified. Use this when calling
    /// [UpdateTransferOrder](api-endpoint:TransferOrders-UpdateTransferOrder) and other endpoints to ensure you're
    /// not overwriting concurrent changes.
    /// </summary>
    [JsonPropertyName("version")]
    public long? Version { get; set; }

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
