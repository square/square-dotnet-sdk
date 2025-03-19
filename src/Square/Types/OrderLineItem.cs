using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a line item in an order. Each line item describes a different
/// product to purchase, with its own quantity and price details.
/// </summary>
public record OrderLineItem
{
    /// <summary>
    /// A unique ID that identifies the line item only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The name of the line item.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The count, or measurement, of a line item being purchased:
    ///
    /// If `quantity` is a whole number, and `quantity_unit` is not specified, then `quantity` denotes an item count.  For example: `3` apples.
    ///
    /// If `quantity` is a whole or decimal number, and `quantity_unit` is also specified, then `quantity` denotes a measurement.  For example: `2.25` pounds of broccoli.
    ///
    /// For more information, see [Specify item quantity and measurement unit](https://developer.squareup.com/docs/orders-api/create-orders#specify-item-quantity-and-measurement-unit).
    ///
    /// Line items with a quantity of `0` are automatically removed
    /// when paying for or otherwise completing the order.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required string Quantity { get; set; }

    /// <summary>
    /// The measurement unit and decimal precision that this line item's quantity is measured in.
    /// </summary>
    [JsonPropertyName("quantity_unit")]
    public OrderQuantityUnit? QuantityUnit { get; set; }

    /// <summary>
    /// An optional note associated with the line item.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The [CatalogItemVariation](entity:CatalogItemVariation) ID applied to this line item.
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this line item references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The name of the variation applied to this line item.
    /// </summary>
    [JsonPropertyName("variation_name")]
    public string? VariationName { get; set; }

    /// <summary>
    /// The type of line item: an itemized sale, a non-itemized sale (custom amount), or the
    /// activation or reloading of a gift card.
    /// See [OrderLineItemItemType](#type-orderlineitemitemtype) for possible values
    /// </summary>
    [JsonPropertyName("item_type")]
    public OrderLineItemItemType? ItemType { get; set; }

    /// <summary>
    /// Application-defined data attached to this line item. Metadata fields are intended
    /// to store descriptive references or associations with an entity in another system or store brief
    /// information about the object. Square does not process this field; it only stores and returns it
    /// in relevant API calls. Do not use metadata to store any sensitive information (such as personally
    /// identifiable information or card details).
    ///
    /// Keys written by applications must be 60 characters or less and must be in the character set
    /// `[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed
    /// with a namespace, separated from the key with a ':' character.
    ///
    /// Values have a maximum length of 255 characters.
    ///
    /// An application can have up to 10 entries per metadata field.
    ///
    /// Entries written by applications are private and can only be read or modified by the same
    /// application.
    ///
    /// For more information, see [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

    /// <summary>
    /// The [CatalogModifier](entity:CatalogModifier)s applied to this line item.
    /// </summary>
    [JsonPropertyName("modifiers")]
    public IEnumerable<OrderLineItemModifier>? Modifiers { get; set; }

    /// <summary>
    /// The list of references to taxes applied to this line item. Each
    /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a
    /// top-level `OrderLineItemTax` applied to the line item. On reads, the
    /// amount applied is populated.
    ///
    /// An `OrderLineItemAppliedTax` is automatically created on every line
    /// item for all `ORDER` scoped taxes added to the order. `OrderLineItemAppliedTax`
    /// records for `LINE_ITEM` scoped taxes must be added in requests for the tax
    /// to apply to any line items.
    ///
    /// To change the amount of a tax, modify the referenced top-level tax.
    /// </summary>
    [JsonPropertyName("applied_taxes")]
    public IEnumerable<OrderLineItemAppliedTax>? AppliedTaxes { get; set; }

    /// <summary>
    /// The list of references to discounts applied to this line item. Each
    /// `OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
    /// `OrderLineItemDiscounts` applied to the line item. On reads, the amount
    /// applied is populated.
    ///
    /// An `OrderLineItemAppliedDiscount` is automatically created on every line item for all
    /// `ORDER` scoped discounts that are added to the order. `OrderLineItemAppliedDiscount` records
    /// for `LINE_ITEM` scoped discounts must be added in requests for the discount to apply to any
    /// line items.
    ///
    /// To change the amount of a discount, modify the referenced top-level discount.
    /// </summary>
    [JsonPropertyName("applied_discounts")]
    public IEnumerable<OrderLineItemAppliedDiscount>? AppliedDiscounts { get; set; }

    /// <summary>
    /// The list of references to service charges applied to this line item. Each
    /// `OrderLineItemAppliedServiceCharge` has a `service_charge_id` that references the `uid` of a
    /// top-level `OrderServiceCharge` applied to the line item. On reads, the amount applied is
    /// populated.
    ///
    /// To change the amount of a service charge, modify the referenced top-level service charge.
    /// </summary>
    [JsonPropertyName("applied_service_charges")]
    public IEnumerable<OrderLineItemAppliedServiceCharge>? AppliedServiceCharges { get; set; }

    /// <summary>
    /// The base price for a single unit of the line item.
    /// </summary>
    [JsonPropertyName("base_price_money")]
    public Money? BasePriceMoney { get; set; }

    /// <summary>
    /// The total price of all item variations sold in this line item.
    /// The price is calculated as `base_price_money` multiplied by `quantity`.
    /// It does not include modifiers.
    /// </summary>
    [JsonPropertyName("variation_total_price_money")]
    public Money? VariationTotalPriceMoney { get; set; }

    /// <summary>
    /// The amount of money made in gross sales for this line item.
    /// The amount is calculated as the sum of the variation's total price and each modifier's total price.
    /// For inclusive tax items in the US, Canada, and Japan, tax is deducted from `gross_sales_money`. For Europe and
    /// Australia, inclusive tax remains as part of the gross sale calculation.
    /// </summary>
    [JsonPropertyName("gross_sales_money")]
    public Money? GrossSalesMoney { get; set; }

    /// <summary>
    /// The total amount of tax money to collect for the line item.
    /// </summary>
    [JsonPropertyName("total_tax_money")]
    public Money? TotalTaxMoney { get; set; }

    /// <summary>
    /// The total amount of discount money to collect for the line item.
    /// </summary>
    [JsonPropertyName("total_discount_money")]
    public Money? TotalDiscountMoney { get; set; }

    /// <summary>
    /// The total amount of money to collect for this line item.
    /// </summary>
    [JsonPropertyName("total_money")]
    public Money? TotalMoney { get; set; }

    /// <summary>
    /// Describes pricing adjustments that are blocked from automatic
    /// application to a line item. For more information, see
    /// [Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).
    /// </summary>
    [JsonPropertyName("pricing_blocklists")]
    public OrderLineItemPricingBlocklists? PricingBlocklists { get; set; }

    /// <summary>
    /// The total amount of apportioned service charge money to collect for the line item.
    /// </summary>
    [JsonPropertyName("total_service_charge_money")]
    public Money? TotalServiceChargeMoney { get; set; }

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
