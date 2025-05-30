using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a change in state or quantity of product inventory at a
/// particular time and location.
/// </summary>
public record InventoryAdjustment
{
    /// <summary>
    /// A unique ID generated by Square for the
    /// `InventoryAdjustment`.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An optional ID provided by the application to tie the
    /// `InventoryAdjustment` to an external
    /// system.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The [inventory state](entity:InventoryState) of the related quantity
    /// of items before the adjustment.
    /// See [InventoryState](#type-inventorystate) for possible values
    /// </summary>
    [JsonPropertyName("from_state")]
    public InventoryState? FromState { get; set; }

    /// <summary>
    /// The [inventory state](entity:InventoryState) of the related quantity
    /// of items after the adjustment.
    /// See [InventoryState](#type-inventorystate) for possible values
    /// </summary>
    [JsonPropertyName("to_state")]
    public InventoryState? ToState { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Location](entity:Location) where the related
    /// quantity of items is being tracked.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The Square-generated ID of the
    /// [CatalogObject](entity:CatalogObject) being tracked.
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The [type](entity:CatalogObjectType) of the [CatalogObject](entity:CatalogObject) being tracked.
    ///
    /// The Inventory API supports setting and reading the `"catalog_object_type": "ITEM_VARIATION"` field value.
    /// In addition, it can also read the `"catalog_object_type": "ITEM"` field value that is set by the Square Restaurants app.
    /// </summary>
    [JsonPropertyName("catalog_object_type")]
    public string? CatalogObjectType { get; set; }

    /// <summary>
    /// The number of items affected by the adjustment as a decimal string.
    /// Can support up to 5 digits after the decimal point.
    /// </summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>
    /// The total price paid for goods associated with the
    /// adjustment. Present if and only if `to_state` is `SOLD`. Always
    /// non-negative.
    /// </summary>
    [JsonPropertyName("total_price_money")]
    public Money? TotalPriceMoney { get; set; }

    /// <summary>
    /// A client-generated RFC 3339-formatted timestamp that indicates when
    /// the inventory adjustment took place. For inventory adjustment updates, the `occurred_at`
    /// timestamp cannot be older than 24 hours or in the future relative to the
    /// time of the request.
    /// </summary>
    [JsonPropertyName("occurred_at")]
    public string? OccurredAt { get; set; }

    /// <summary>
    /// An RFC 3339-formatted timestamp that indicates when the inventory adjustment is received.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// Information about the application that caused the
    /// inventory adjustment.
    /// </summary>
    [JsonPropertyName("source")]
    public SourceApplication? Source { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Employee](entity:Employee) responsible for the
    /// inventory adjustment.
    /// </summary>
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Team Member](entity:TeamMember) responsible for the
    /// inventory adjustment.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Transaction](entity:Transaction) that
    /// caused the adjustment. Only relevant for payment-related state
    /// transitions.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("transaction_id")]
    public string? TransactionId { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Refund](entity:Refund) that
    /// caused the adjustment. Only relevant for refund-related state
    /// transitions.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("refund_id")]
    public string? RefundId { get; set; }

    /// <summary>
    /// The Square-generated ID of the purchase order that caused the
    /// adjustment. Only relevant for state transitions from the Square for Retail
    /// app.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("purchase_order_id")]
    public string? PurchaseOrderId { get; set; }

    /// <summary>
    /// The Square-generated ID of the goods receipt that caused the
    /// adjustment. Only relevant for state transitions from the Square for Retail
    /// app.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("goods_receipt_id")]
    public string? GoodsReceiptId { get; set; }

    /// <summary>
    /// An adjustment group bundling the related adjustments of item variations through stock conversions in a single inventory event.
    /// </summary>
    [JsonPropertyName("adjustment_group")]
    public InventoryAdjustmentGroup? AdjustmentGroup { get; set; }

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
