using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents the quantity of an item variation that is physically present
/// at a specific location, verified by a seller or a seller's employee. For example,
/// a physical count might come from an employee counting the item variations on
/// hand or from syncing with an external system.
/// </summary>
public record InventoryPhysicalCount
{
    /// <summary>
    /// A unique Square-generated ID for the
    /// [InventoryPhysicalCount](entity:InventoryPhysicalCount).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An optional ID provided by the application to tie the
    /// [InventoryPhysicalCount](entity:InventoryPhysicalCount) to an external
    /// system.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

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
    /// The current [inventory state](entity:InventoryState) for the related
    /// quantity of items.
    /// See [InventoryState](#type-inventorystate) for possible values
    /// </summary>
    [JsonPropertyName("state")]
    public InventoryState? State { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Location](entity:Location) where the related
    /// quantity of items is being tracked.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The number of items affected by the physical count as a decimal string.
    /// The number can support up to 5 digits after the decimal point.
    /// </summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>
    /// Information about the application with which the
    /// physical count is submitted.
    /// </summary>
    [JsonPropertyName("source")]
    public SourceApplication? Source { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Employee](entity:Employee) responsible for the
    /// physical count.
    /// </summary>
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// The Square-generated ID of the [Team Member](entity:TeamMember) responsible for the
    /// physical count.
    /// </summary>
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// A client-generated RFC 3339-formatted timestamp that indicates when
    /// the physical count was examined. For physical count updates, the `occurred_at`
    /// timestamp cannot be older than 24 hours or in the future relative to the
    /// time of the request.
    /// </summary>
    [JsonPropertyName("occurred_at")]
    public string? OccurredAt { get; set; }

    /// <summary>
    /// An RFC 3339-formatted timestamp that indicates when the physical count is received.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

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
