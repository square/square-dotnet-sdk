using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes pricing adjustments that are blocked from automatic
/// application to a line item. For more information, see
/// [Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).
/// </summary>
[Serializable]
public record OrderLineItemPricingBlocklists : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of discounts blocked from applying to the line item.
    /// Discounts can be blocked by the `discount_uid` (for ad hoc discounts) or
    /// the `discount_catalog_object_id` (for catalog discounts).
    /// </summary>
    [JsonPropertyName("blocked_discounts")]
    public IEnumerable<OrderLineItemPricingBlocklistsBlockedDiscount>? BlockedDiscounts { get; set; }

    /// <summary>
    /// A list of taxes blocked from applying to the line item.
    /// Taxes can be blocked by the `tax_uid` (for ad hoc taxes) or
    /// the `tax_catalog_object_id` (for catalog taxes).
    /// </summary>
    [JsonPropertyName("blocked_taxes")]
    public IEnumerable<OrderLineItemPricingBlocklistsBlockedTax>? BlockedTaxes { get; set; }

    /// <summary>
    /// A list of service charges blocked from applying to the line item.
    /// Service charges can be blocked by the `service_charge_uid` (for ad hoc
    /// service charges) or the `service_charge_catalog_object_id` (for catalog
    /// service charges).
    /// </summary>
    [JsonPropertyName("blocked_service_charges")]
    public IEnumerable<OrderLineItemPricingBlocklistsBlockedServiceCharge>? BlockedServiceCharges { get; set; }

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
