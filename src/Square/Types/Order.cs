using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains all information related to a single order to process with Square,
/// including line items that specify the products to purchase. `Order` objects also
/// include information about any associated tenders, refunds, and returns.
///
/// All Connect V2 Transactions have all been converted to Orders including all associated
/// itemization data.
/// </summary>
public record Order
{
    /// <summary>
    /// The order's unique ID.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The ID of the seller location that this order is associated with.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

    /// <summary>
    /// A client-specified ID to associate an entity in another system
    /// with this order.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// The origination details of the order.
    /// </summary>
    [JsonPropertyName("source")]
    public OrderSource? Source { get; set; }

    /// <summary>
    /// The ID of the [customer](entity:Customer) associated with the order.
    ///
    /// You should specify a `customer_id` on the order (or the payment) to ensure that transactions
    /// are reliably linked to customers. Omitting this field might result in the creation of new
    /// [instant profiles](https://developer.squareup.com/docs/customers-api/what-it-does#instant-profiles).
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The line items included in the order.
    /// </summary>
    [JsonPropertyName("line_items")]
    public IEnumerable<OrderLineItem>? LineItems { get; set; }

    /// <summary>
    /// The list of all taxes associated with the order.
    ///
    /// Taxes can be scoped to either `ORDER` or `LINE_ITEM`. For taxes with `LINE_ITEM` scope, an
    /// `OrderLineItemAppliedTax` must be added to each line item that the tax applies to. For taxes
    /// with `ORDER` scope, the server generates an `OrderLineItemAppliedTax` for every line item.
    ///
    /// On reads, each tax in the list includes the total amount of that tax applied to the order.
    ///
    /// __IMPORTANT__: If `LINE_ITEM` scope is set on any taxes in this field, using the deprecated
    /// `line_items.taxes` field results in an error. Use `line_items.applied_taxes`
    /// instead.
    /// </summary>
    [JsonPropertyName("taxes")]
    public IEnumerable<OrderLineItemTax>? Taxes { get; set; }

    /// <summary>
    /// The list of all discounts associated with the order.
    ///
    /// Discounts can be scoped to either `ORDER` or `LINE_ITEM`. For discounts scoped to `LINE_ITEM`,
    /// an `OrderLineItemAppliedDiscount` must be added to each line item that the discount applies to.
    /// For discounts with `ORDER` scope, the server generates an `OrderLineItemAppliedDiscount`
    /// for every line item.
    ///
    /// __IMPORTANT__: If `LINE_ITEM` scope is set on any discounts in this field, using the deprecated
    /// `line_items.discounts` field results in an error. Use `line_items.applied_discounts`
    /// instead.
    /// </summary>
    [JsonPropertyName("discounts")]
    public IEnumerable<OrderLineItemDiscount>? Discounts { get; set; }

    /// <summary>
    /// A list of service charges applied to the order.
    /// </summary>
    [JsonPropertyName("service_charges")]
    public IEnumerable<OrderServiceCharge>? ServiceCharges { get; set; }

    /// <summary>
    /// Details about order fulfillment.
    ///
    /// Orders can only be created with at most one fulfillment. However, orders returned
    /// by the API might contain multiple fulfillments.
    /// </summary>
    [JsonPropertyName("fulfillments")]
    public IEnumerable<Fulfillment>? Fulfillments { get; set; }

    /// <summary>
    /// A collection of items from sale orders being returned in this one. Normally part of an
    /// itemized return or exchange. There is exactly one `Return` object per sale `Order` being
    /// referenced.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("returns")]
    public IEnumerable<OrderReturn>? Returns { get; set; }

    /// <summary>
    /// The rollup of the returned money amounts.
    /// </summary>
    [JsonPropertyName("return_amounts")]
    public OrderMoneyAmounts? ReturnAmounts { get; set; }

    /// <summary>
    /// The net money amounts (sale money - return money).
    /// </summary>
    [JsonPropertyName("net_amounts")]
    public OrderMoneyAmounts? NetAmounts { get; set; }

    /// <summary>
    /// A positive rounding adjustment to the total of the order. This adjustment is commonly
    /// used to apply cash rounding when the minimum unit of account is smaller than the lowest physical
    /// denomination of the currency.
    /// </summary>
    [JsonPropertyName("rounding_adjustment")]
    public OrderRoundingAdjustment? RoundingAdjustment { get; set; }

    /// <summary>
    /// The tenders that were used to pay for the order.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("tenders")]
    public IEnumerable<Tender>? Tenders { get; set; }

    /// <summary>
    /// The refunds that are part of this order.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("refunds")]
    public IEnumerable<Refund>? Refunds { get; set; }

    /// <summary>
    /// Application-defined data attached to this order. Metadata fields are intended
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
    /// For more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata).
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

    /// <summary>
    /// The timestamp for when the order was created, at server side, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp for when the order was last updated, at server side, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The timestamp for when the order reached a terminal [state](entity:OrderState), in RFC 3339 format (for example "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("closed_at")]
    public string? ClosedAt { get; set; }

    /// <summary>
    /// The current state of the order.
    /// See [OrderState](#type-orderstate) for possible values
    /// </summary>
    [JsonPropertyName("state")]
    public OrderState? State { get; set; }

    /// <summary>
    /// The version number, which is incremented each time an update is committed to the order.
    /// Orders not created through the API do not include a version number and
    /// therefore cannot be updated.
    ///
    /// [Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders).
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The total amount of money to collect for the order.
    /// </summary>
    [JsonPropertyName("total_money")]
    public Money? TotalMoney { get; set; }

    /// <summary>
    /// The total amount of tax money to collect for the order.
    /// </summary>
    [JsonPropertyName("total_tax_money")]
    public Money? TotalTaxMoney { get; set; }

    /// <summary>
    /// The total amount of discount money to collect for the order.
    /// </summary>
    [JsonPropertyName("total_discount_money")]
    public Money? TotalDiscountMoney { get; set; }

    /// <summary>
    /// The total amount of tip money to collect for the order.
    /// </summary>
    [JsonPropertyName("total_tip_money")]
    public Money? TotalTipMoney { get; set; }

    /// <summary>
    /// The total amount of money collected in service charges for the order.
    ///
    /// Note: `total_service_charge_money` is the sum of `applied_money` fields for each individual
    /// service charge. Therefore, `total_service_charge_money` only includes inclusive tax amounts,
    /// not additive tax amounts.
    /// </summary>
    [JsonPropertyName("total_service_charge_money")]
    public Money? TotalServiceChargeMoney { get; set; }

    /// <summary>
    /// A short-term identifier for the order (such as a customer first name,
    /// table number, or auto-generated order number that resets daily).
    /// </summary>
    [JsonPropertyName("ticket_name")]
    public string? TicketName { get; set; }

    /// <summary>
    /// Pricing options for an order. The options affect how the order's price is calculated.
    /// They can be used, for example, to apply automatic price adjustments that are based on
    /// preconfigured [pricing rules](entity:CatalogPricingRule).
    /// </summary>
    [JsonPropertyName("pricing_options")]
    public OrderPricingOptions? PricingOptions { get; set; }

    /// <summary>
    /// A set-like list of Rewards that have been added to the Order.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("rewards")]
    public IEnumerable<OrderReward>? Rewards { get; set; }

    /// <summary>
    /// The net amount of money due on the order.
    /// </summary>
    [JsonPropertyName("net_amount_due_money")]
    public Money? NetAmountDueMoney { get; set; }

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
