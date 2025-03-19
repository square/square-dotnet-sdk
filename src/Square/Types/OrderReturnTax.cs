using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a tax being returned that applies to one or more return line items in an order.
///
/// Fixed-amount, order-scoped taxes are distributed across all non-zero return line item totals.
/// The amount distributed to each return line item is relative to that item’s contribution to the
/// order subtotal.
/// </summary>
public record OrderReturnTax
{
    /// <summary>
    /// A unique ID that identifies the returned tax only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The tax `uid` from the order that contains the original tax charge.
    /// </summary>
    [JsonPropertyName("source_tax_uid")]
    public string? SourceTaxUid { get; set; }

    /// <summary>
    /// The catalog object ID referencing [CatalogTax](entity:CatalogTax).
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this tax references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The tax's name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Indicates the calculation method used to apply the tax.
    /// See [OrderLineItemTaxType](#type-orderlineitemtaxtype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public OrderLineItemTaxType? Type { get; set; }

    /// <summary>
    /// The percentage of the tax, as a string representation of a decimal number.
    /// For example, a value of `"7.25"` corresponds to a percentage of 7.25%.
    /// </summary>
    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }

    /// <summary>
    /// The amount of money applied by the tax in an order.
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    /// <summary>
    /// Indicates the level at which the `OrderReturnTax` applies. For `ORDER` scoped
    /// taxes, Square generates references in `applied_taxes` on all
    /// `OrderReturnLineItem`s. For `LINE_ITEM` scoped taxes, the tax is only applied to
    /// `OrderReturnLineItem`s with references in their `applied_discounts` field.
    /// See [OrderLineItemTaxScope](#type-orderlineitemtaxscope) for possible values
    /// </summary>
    [JsonPropertyName("scope")]
    public OrderLineItemTaxScope? Scope { get; set; }

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
