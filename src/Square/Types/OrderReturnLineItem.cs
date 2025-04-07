using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The line item being returned in an order.
/// </summary>
public record OrderReturnLineItem
{
    /// <summary>
    /// A unique ID for this return line-item entry.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the line item in the original sale order.
    /// </summary>
    [JsonPropertyName("source_line_item_uid")]
    public string? SourceLineItemUid { get; set; }

    /// <summary>
    /// The name of the line item.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The quantity returned, formatted as a decimal number.
    /// For example, `"3"`.
    ///
    /// Line items with a `quantity_unit` can have non-integer quantities.
    /// For example, `"1.70000"`.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required string Quantity { get; set; }

    /// <summary>
    /// The unit and precision that this return line item's quantity is measured in.
    /// </summary>
    [JsonPropertyName("quantity_unit")]
    public OrderQuantityUnit? QuantityUnit { get; set; }

    /// <summary>
    /// The note of the return line item.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The [CatalogItemVariation](entity:CatalogItemVariation) ID applied to this return line item.
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this line item references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The name of the variation applied to this return line item.
    /// </summary>
    [JsonPropertyName("variation_name")]
    public string? VariationName { get; set; }

    /// <summary>
    /// The type of line item: an itemized return, a non-itemized return (custom amount),
    /// or the return of an unactivated gift card sale.
    /// See [OrderLineItemItemType](#type-orderlineitemitemtype) for possible values
    /// </summary>
    [JsonPropertyName("item_type")]
    public OrderLineItemItemType? ItemType { get; set; }

    /// <summary>
    /// The [CatalogModifier](entity:CatalogModifier)s applied to this line item.
    /// </summary>
    [JsonPropertyName("return_modifiers")]
    public IEnumerable<OrderReturnLineItemModifier>? ReturnModifiers { get; set; }

    /// <summary>
    /// The list of references to `OrderReturnTax` entities applied to the return line item. Each
    /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
    /// `OrderReturnTax` applied to the return line item. On reads, the applied amount
    /// is populated.
    /// </summary>
    [JsonPropertyName("applied_taxes")]
    public IEnumerable<OrderLineItemAppliedTax>? AppliedTaxes { get; set; }

    /// <summary>
    /// The list of references to `OrderReturnDiscount` entities applied to the return line item. Each
    /// `OrderLineItemAppliedDiscount` has a `discount_uid` that references the `uid` of a top-level
    /// `OrderReturnDiscount` applied to the return line item. On reads, the applied amount
    /// is populated.
    /// </summary>
    [JsonPropertyName("applied_discounts")]
    public IEnumerable<OrderLineItemAppliedDiscount>? AppliedDiscounts { get; set; }

    /// <summary>
    /// The base price for a single unit of the line item.
    /// </summary>
    [JsonPropertyName("base_price_money")]
    public Money? BasePriceMoney { get; set; }

    /// <summary>
    /// The total price of all item variations returned in this line item.
    /// The price is calculated as `base_price_money` multiplied by `quantity` and
    /// does not include modifiers.
    /// </summary>
    [JsonPropertyName("variation_total_price_money")]
    public Money? VariationTotalPriceMoney { get; set; }

    /// <summary>
    /// The gross return amount of money calculated as (item base price + modifiers price) * quantity.
    /// </summary>
    [JsonPropertyName("gross_return_money")]
    public Money? GrossReturnMoney { get; set; }

    /// <summary>
    /// The total amount of tax money to return for the line item.
    /// </summary>
    [JsonPropertyName("total_tax_money")]
    public Money? TotalTaxMoney { get; set; }

    /// <summary>
    /// The total amount of discount money to return for the line item.
    /// </summary>
    [JsonPropertyName("total_discount_money")]
    public Money? TotalDiscountMoney { get; set; }

    /// <summary>
    /// The total amount of money to return for this line item.
    /// </summary>
    [JsonPropertyName("total_money")]
    public Money? TotalMoney { get; set; }

    /// <summary>
    /// The list of references to `OrderReturnServiceCharge` entities applied to the return
    /// line item. Each `OrderLineItemAppliedServiceCharge` has a `service_charge_uid` that
    /// references the `uid` of a top-level `OrderReturnServiceCharge` applied to the return line
    /// item. On reads, the applied amount is populated.
    /// </summary>
    [JsonPropertyName("applied_service_charges")]
    public IEnumerable<OrderLineItemAppliedServiceCharge>? AppliedServiceCharges { get; set; }

    /// <summary>
    /// The total amount of apportioned service charge money to return for the line item.
    /// </summary>
    [JsonPropertyName("total_service_charge_money")]
    public Money? TotalServiceChargeMoney { get; set; }

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
