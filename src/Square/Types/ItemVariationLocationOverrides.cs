using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Price and inventory alerting overrides for a `CatalogItemVariation` at a specific `Location`.
/// </summary>
public record ItemVariationLocationOverrides
{
    /// <summary>
    /// The ID of the `Location`. This can include locations that are deactivated.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The price of the `CatalogItemVariation` at the given `Location`, or blank for variable pricing.
    /// </summary>
    [JsonPropertyName("price_money")]
    public Money? PriceMoney { get; set; }

    /// <summary>
    /// The pricing type (fixed or variable) for the `CatalogItemVariation` at the given `Location`.
    /// See [CatalogPricingType](#type-catalogpricingtype) for possible values
    /// </summary>
    [JsonPropertyName("pricing_type")]
    public CatalogPricingType? PricingType { get; set; }

    /// <summary>
    /// If `true`, inventory tracking is active for the `CatalogItemVariation` at this `Location`.
    /// </summary>
    [JsonPropertyName("track_inventory")]
    public bool? TrackInventory { get; set; }

    /// <summary>
    /// Indicates whether the `CatalogItemVariation` displays an alert when its inventory
    /// quantity is less than or equal to its `inventory_alert_threshold`.
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
    /// Indicates whether the overridden item variation is sold out at the specified location.
    ///
    /// When inventory tracking is enabled on the item variation either globally or at the specified location,
    /// the item variation is automatically marked as sold out when its inventory count reaches zero. The seller
    /// can manually set the item variation as sold out even when the inventory count is greater than zero.
    /// Attempts by an application to set this attribute are ignored. Regardless how the sold-out status is set,
    /// applications should treat its inventory count as zero when this attribute value is `true`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("sold_out")]
    public bool? SoldOut { get; set; }

    /// <summary>
    /// The seller-assigned timestamp, of the RFC 3339 format, to indicate when this sold-out variation
    /// becomes available again at the specified location. Attempts by an application to set this attribute are ignored.
    /// When the current time is later than this attribute value, the affected item variation is no longer sold out.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("sold_out_valid_until")]
    public string? SoldOutValidUntil { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
