using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a discount being returned that applies to one or more return line items in an
/// order.
///
/// Fixed-amount, order-scoped discounts are distributed across all non-zero return line item totals.
/// The amount distributed to each return line item is relative to that item’s contribution to the
/// order subtotal.
/// </summary>
public record OrderReturnDiscount
{
    /// <summary>
    /// A unique ID that identifies the returned discount only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The discount `uid` from the order that contains the original application of this discount.
    /// </summary>
    [JsonPropertyName("source_discount_uid")]
    public string? SourceDiscountUid { get; set; }

    /// <summary>
    /// The catalog object ID referencing [CatalogDiscount](entity:CatalogDiscount).
    /// </summary>
    [JsonPropertyName("catalog_object_id")]
    public string? CatalogObjectId { get; set; }

    /// <summary>
    /// The version of the catalog object that this discount references.
    /// </summary>
    [JsonPropertyName("catalog_version")]
    public long? CatalogVersion { get; set; }

    /// <summary>
    /// The discount's name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The type of the discount. If it is created by the API, it is `FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
    ///
    /// Discounts that do not reference a catalog object ID must have a type of
    /// `FIXED_PERCENTAGE` or `FIXED_AMOUNT`.
    /// See [OrderLineItemDiscountType](#type-orderlineitemdiscounttype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public OrderLineItemDiscountType? Type { get; set; }

    /// <summary>
    /// The percentage of the tax, as a string representation of a decimal number.
    /// A value of `"7.25"` corresponds to a percentage of 7.25%.
    ///
    /// `percentage` is not set for amount-based discounts.
    /// </summary>
    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }

    /// <summary>
    /// The total declared monetary amount of the discount.
    ///
    /// `amount_money` is not set for percentage-based discounts.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public Money? AmountMoney { get; set; }

    /// <summary>
    /// The amount of discount actually applied to this line item. When an amount-based
    /// discount is at the order level, this value is different from `amount_money` because the discount
    /// is distributed across the line items.
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    /// <summary>
    /// Indicates the level at which the `OrderReturnDiscount` applies. For `ORDER` scoped
    /// discounts, the server generates references in `applied_discounts` on all
    /// `OrderReturnLineItem`s. For `LINE_ITEM` scoped discounts, the discount is only applied to
    /// `OrderReturnLineItem`s with references in their `applied_discounts` field.
    /// See [OrderLineItemDiscountScope](#type-orderlineitemdiscountscope) for possible values
    /// </summary>
    [JsonPropertyName("scope")]
    public OrderLineItemDiscountScope? Scope { get; set; }

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
