using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An item variation, representing a product for sale, in the Catalog object model. Each [item](entity:CatalogItem) must have at least one
/// item variation and can have at most 250 item variations.
///
/// An item variation can be sellable, stockable, or both if it has a unit of measure for its count for the sold number of the variation, the stocked
/// number of the variation, or both. For example, when a variation representing wine is stocked and sold by the bottle, the variation is both
/// stockable and sellable. But when a variation of the wine is sold by the glass, the sold units cannot be used as a measure of the stocked units. This by-the-glass
/// variation is sellable, but not stockable. To accurately keep track of the wine's inventory count at any time, the sellable count must be
/// converted to stockable count. Typically, the seller defines this unit conversion. For example, 1 bottle equals 5 glasses. The Square API exposes
/// the `stockable_conversion` property on the variation to specify the conversion. Thus, when two glasses of the wine are sold, the sellable count
/// decreases by 2, and the stockable count automatically decreases by 0.4 bottle according to the conversion.
/// </summary>
public record CatalogItemVariation
{
    /// <summary>
    /// The ID of the `CatalogItem` associated with this item variation.
    /// </summary>
    [JsonPropertyName("item_id")]
    public string? ItemId { get; set; }

    /// <summary>
    /// The item variation's name. This is a searchable attribute for use in applicable query filters.
    ///
    /// Its value has a maximum length of 255 Unicode code points. However, when the parent [item](entity:CatalogItem)
    /// uses [item options](entity:CatalogItemOption), this attribute is auto-generated, read-only, and can be
    /// longer than 255 Unicode code points.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The item variation's SKU, if any. This is a searchable attribute for use in applicable query filters.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? Sku { get; set; }

    /// <summary>
    /// The universal product code (UPC) of the item variation, if any. This is a searchable attribute for use in applicable query filters.
    ///
    /// The value of this attribute should be a number of 12-14 digits long.  This restriction is enforced on the Square Seller Dashboard,
    /// Square Point of Sale or Retail Point of Sale apps, where this attribute shows in the GTIN field. If a non-compliant UPC value is assigned
    /// to this attribute using the API, the value is not editable on the Seller Dashboard, Square Point of Sale or Retail Point of Sale apps
    /// unless it is updated to fit the expected format.
    /// </summary>
    [JsonPropertyName("upc")]
    public string? Upc { get; set; }

    /// <summary>
    /// The order in which this item variation should be displayed. This value is read-only. On writes, the ordinal
    /// for each item variation within a parent `CatalogItem` is set according to the item variations's
    /// position. On reads, the value is not guaranteed to be sequential or unique.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("ordinal")]
    public int? Ordinal { get; set; }

    /// <summary>
    /// Indicates whether the item variation's price is fixed or determined at the time
    /// of sale.
    /// See [CatalogPricingType](#type-catalogpricingtype) for possible values
    /// </summary>
    [JsonPropertyName("pricing_type")]
    public CatalogPricingType? PricingType { get; set; }

    /// <summary>
    /// The item variation's price, if fixed pricing is used.
    /// </summary>
    [JsonPropertyName("price_money")]
    public Money? PriceMoney { get; set; }

    /// <summary>
    /// Per-location price and inventory overrides.
    /// </summary>
    [JsonPropertyName("location_overrides")]
    public IEnumerable<ItemVariationLocationOverrides>? LocationOverrides { get; set; }

    /// <summary>
    /// If `true`, inventory tracking is active for the variation.
    /// </summary>
    [JsonPropertyName("track_inventory")]
    public bool? TrackInventory { get; set; }

    /// <summary>
    /// Indicates whether the item variation displays an alert when its inventory quantity is less than or equal
    /// to its `inventory_alert_threshold`.
    /// See [InventoryAlertType](#type-inventoryalerttype) for possible values
    /// </summary>
    [JsonPropertyName("inventory_alert_type")]
    public InventoryAlertType? InventoryAlertType { get; set; }

    /// <summary>
    /// If the inventory quantity for the variation is less than or equal to this value and `inventory_alert_type`
    /// is `LOW_QUANTITY`, the variation displays an alert in the merchant dashboard.
    ///
    /// This value is always an integer.
    /// </summary>
    [JsonPropertyName("inventory_alert_threshold")]
    public long? InventoryAlertThreshold { get; set; }

    /// <summary>
    /// Arbitrary user metadata to associate with the item variation. This attribute value length is of Unicode code points.
    /// </summary>
    [JsonPropertyName("user_data")]
    public string? UserData { get; set; }

    /// <summary>
    /// If the `CatalogItem` that owns this item variation is of type
    /// `APPOINTMENTS_SERVICE`, then this is the duration of the service in milliseconds. For
    /// example, a 30 minute appointment would have the value `1800000`, which is equal to
    /// 30 (minutes) * 60 (seconds per minute) * 1000 (milliseconds per second).
    /// </summary>
    [JsonPropertyName("service_duration")]
    public long? ServiceDuration { get; set; }

    /// <summary>
    /// If the `CatalogItem` that owns this item variation is of type
    /// `APPOINTMENTS_SERVICE`, a bool representing whether this service is available for booking.
    /// </summary>
    [JsonPropertyName("available_for_booking")]
    public bool? AvailableForBooking { get; set; }

    /// <summary>
    /// List of item option values associated with this item variation. Listed
    /// in the same order as the item options of the parent item.
    /// </summary>
    [JsonPropertyName("item_option_values")]
    public IEnumerable<CatalogItemOptionValueForItemVariation>? ItemOptionValues { get; set; }

    /// <summary>
    /// ID of the ‘CatalogMeasurementUnit’ that is used to measure the quantity
    /// sold of this item variation. If left unset, the item will be sold in
    /// whole quantities.
    /// </summary>
    [JsonPropertyName("measurement_unit_id")]
    public string? MeasurementUnitId { get; set; }

    /// <summary>
    /// Whether this variation can be sold. The inventory count of a sellable variation indicates
    /// the number of units available for sale. When a variation is both stockable and sellable,
    /// its sellable inventory count can be smaller than or equal to its stockable count.
    /// </summary>
    [JsonPropertyName("sellable")]
    public bool? Sellable { get; set; }

    /// <summary>
    /// Whether stock is counted directly on this variation (TRUE) or only on its components (FALSE).
    /// When a variation is both stockable and sellable, the inventory count of a stockable variation keeps track of the number of units of this variation in stock
    /// and is not an indicator of the number of units of the variation that can be sold.
    /// </summary>
    [JsonPropertyName("stockable")]
    public bool? Stockable { get; set; }

    /// <summary>
    /// The IDs of images associated with this `CatalogItemVariation` instance.
    /// These images will be shown to customers in Square Online Store.
    /// </summary>
    [JsonPropertyName("image_ids")]
    public IEnumerable<string>? ImageIds { get; set; }

    /// <summary>
    /// Tokens of employees that can perform the service represented by this variation. Only valid for
    /// variations of type `APPOINTMENTS_SERVICE`.
    /// </summary>
    [JsonPropertyName("team_member_ids")]
    public IEnumerable<string>? TeamMemberIds { get; set; }

    /// <summary>
    /// The unit conversion rule, as prescribed by the [CatalogStockConversion](entity:CatalogStockConversion) type,
    /// that describes how this non-stockable (i.e., sellable/receivable) item variation is converted
    /// to/from the stockable item variation sharing the same parent item. With the stock conversion,
    /// you can accurately track inventory when an item variation is sold in one unit, but stocked in
    /// another unit.
    /// </summary>
    [JsonPropertyName("stockable_conversion")]
    public CatalogStockConversion? StockableConversion { get; set; }

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
