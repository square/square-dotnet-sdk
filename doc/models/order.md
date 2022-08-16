
# Order

Contains all information related to a single order to process with Square,
including line items that specify the products to purchase. `Order` objects also
include information about any associated tenders, refunds, and returns.

All Connect V2 Transactions have all been converted to Orders including all associated
itemization data.

## Structure

`Order`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The order's unique ID. |
| `LocationId` | `string` | Required | The ID of the seller location that this order is associated with.<br>**Constraints**: *Minimum Length*: `1` |
| `ReferenceId` | `string` | Optional | A client-specified ID to associate an entity in another system<br>with this order.<br>**Constraints**: *Maximum Length*: `40` |
| `Source` | [`Models.OrderSource`](../../doc/models/order-source.md) | Optional | Represents the origination details of an order. |
| `CustomerId` | `string` | Optional | The ID of the [customer](../../doc/models/customer.md) associated with the order.<br><br>__IMPORTANT:__ You should specify a `customer_id` if you want the corresponding payment transactions<br>to be explicitly linked to the customer in the Seller Dashboard. If this field is omitted, the<br>`customer_id` assigned to any underlying `Payment` objects is ignored and might result in the<br>creation of new [instant profiles](https://developer.squareup.com/docs/customers-api/what-it-does#instant-profiles).<br>**Constraints**: *Maximum Length*: `191` |
| `LineItems` | [`IList<Models.OrderLineItem>`](../../doc/models/order-line-item.md) | Optional | The line items included in the order. |
| `Taxes` | [`IList<Models.OrderLineItemTax>`](../../doc/models/order-line-item-tax.md) | Optional | The list of all taxes associated with the order.<br><br>Taxes can be scoped to either `ORDER` or `LINE_ITEM`. For taxes with `LINE_ITEM` scope, an<br>`OrderLineItemAppliedTax` must be added to each line item that the tax applies to. For taxes<br>with `ORDER` scope, the server generates an `OrderLineItemAppliedTax` for every line item.<br><br>On reads, each tax in the list includes the total amount of that tax applied to the order.<br><br>__IMPORTANT__: If `LINE_ITEM` scope is set on any taxes in this field, using the deprecated<br>`line_items.taxes` field results in an error. Use `line_items.applied_taxes`<br>instead. |
| `Discounts` | [`IList<Models.OrderLineItemDiscount>`](../../doc/models/order-line-item-discount.md) | Optional | The list of all discounts associated with the order.<br><br>Discounts can be scoped to either `ORDER` or `LINE_ITEM`. For discounts scoped to `LINE_ITEM`,<br>an `OrderLineItemAppliedDiscount` must be added to each line item that the discount applies to.<br>For discounts with `ORDER` scope, the server generates an `OrderLineItemAppliedDiscount`<br>for every line item.<br><br>__IMPORTANT__: If `LINE_ITEM` scope is set on any discounts in this field, using the deprecated<br>`line_items.discounts` field results in an error. Use `line_items.applied_discounts`<br>instead. |
| `ServiceCharges` | [`IList<Models.OrderServiceCharge>`](../../doc/models/order-service-charge.md) | Optional | A list of service charges applied to the order. |
| `Fulfillments` | [`IList<Models.OrderFulfillment>`](../../doc/models/order-fulfillment.md) | Optional | Details about order fulfillment.<br><br>Orders can only be created with at most one fulfillment. However, orders returned<br>by the API might contain multiple fulfillments. |
| `Returns` | [`IList<Models.OrderReturn>`](../../doc/models/order-return.md) | Optional | A collection of items from sale orders being returned in this one. Normally part of an<br>itemized return or exchange. There is exactly one `Return` object per sale `Order` being<br>referenced. |
| `ReturnAmounts` | [`Models.OrderMoneyAmounts`](../../doc/models/order-money-amounts.md) | Optional | A collection of various money amounts. |
| `NetAmounts` | [`Models.OrderMoneyAmounts`](../../doc/models/order-money-amounts.md) | Optional | A collection of various money amounts. |
| `RoundingAdjustment` | [`Models.OrderRoundingAdjustment`](../../doc/models/order-rounding-adjustment.md) | Optional | A rounding adjustment of the money being returned. Commonly used to apply cash rounding<br>when the minimum unit of the account is smaller than the lowest physical denomination of the currency. |
| `Tenders` | [`IList<Models.Tender>`](../../doc/models/tender.md) | Optional | The tenders that were used to pay for the order. |
| `Refunds` | [`IList<Models.Refund>`](../../doc/models/refund.md) | Optional | The refunds that are part of this order. |
| `Metadata` | `IDictionary<string, string>` | Optional | Application-defined data attached to this order. Metadata fields are intended<br>to store descriptive references or associations with an entity in another system or store brief<br>information about the object. Square does not process this field; it only stores and returns it<br>in relevant API calls. Do not use metadata to store any sensitive information (such as personally<br>identifiable information or card details).<br><br>Keys written by applications must be 60 characters or less and must be in the character set<br>`[a-zA-Z0-9_-]`. Entries can also include metadata generated by Square. These keys are prefixed<br>with a namespace, separated from the key with a ':' character.<br><br>Values have a maximum length of 255 characters.<br><br>An application can have up to 10 entries per metadata field.<br><br>Entries written by applications are private and can only be read or modified by the same<br>application.<br><br>For more information, see  [Metadata](https://developer.squareup.com/docs/build-basics/metadata). |
| `CreatedAt` | `string` | Optional | The timestamp for when the order was created, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z"). |
| `UpdatedAt` | `string` | Optional | The timestamp for when the order was last updated, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z"). |
| `ClosedAt` | `string` | Optional | The timestamp for when the order reached a terminal [state](../../doc/models/order-state.md), in RFC 3339 format (for example "2016-09-04T23:59:33.123Z"). |
| `State` | [`string`](../../doc/models/order-state.md) | Optional | The state of the order. |
| `Version` | `int?` | Optional | The version number, which is incremented each time an update is committed to the order.<br>Orders not created through the API do not include a version number and<br>therefore cannot be updated.<br><br>[Read more about working with versions](https://developer.squareup.com/docs/orders-api/manage-orders#update-orders). |
| `TotalMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TotalTaxMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TotalDiscountMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TotalTipMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TotalServiceChargeMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TicketName` | `string` | Optional | A short-term identifier for the order (such as a customer first name,<br>table number, or auto-generated order number that resets daily).<br>**Constraints**: *Maximum Length*: `30` |
| `PricingOptions` | [`Models.OrderPricingOptions`](../../doc/models/order-pricing-options.md) | Optional | Pricing options for an order. The options affect how the order's price is calculated.<br>They can be used, for example, to apply automatic price adjustments that are based on preconfigured<br>[pricing rules](../../doc/models/catalog-pricing-rule.md). |
| `Rewards` | [`IList<Models.OrderReward>`](../../doc/models/order-reward.md) | Optional | A set-like list of Rewards that have been added to the Order. |
| `NetAmountDueMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |

## Example (as JSON)

```json
{
  "location_id": "location_id4",
  "reference_id": null,
  "source": null,
  "customer_id": null,
  "line_items": null,
  "taxes": null,
  "discounts": null,
  "service_charges": null,
  "fulfillments": null,
  "return_amounts": null,
  "net_amounts": null,
  "rounding_adjustment": null,
  "metadata": null,
  "state": null,
  "version": null,
  "total_money": null,
  "total_tax_money": null,
  "total_discount_money": null,
  "total_tip_money": null,
  "total_service_charge_money": null,
  "ticket_name": null,
  "pricing_options": null,
  "net_amount_due_money": null
}
```

