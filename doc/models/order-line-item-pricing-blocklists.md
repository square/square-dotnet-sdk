
# Order Line Item Pricing Blocklists

Describes pricing adjustments that are blocked from automatic
application to a line item. For more information, see
[Apply Taxes and Discounts](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts).

## Structure

`OrderLineItemPricingBlocklists`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BlockedDiscounts` | [`IList<Models.OrderLineItemPricingBlocklistsBlockedDiscount>`](../../doc/models/order-line-item-pricing-blocklists-blocked-discount.md) | Optional | A list of discounts blocked from applying to the line item.<br>Discounts can be blocked by the `discount_uid` (for ad hoc discounts) or<br>the `discount_catalog_object_id` (for catalog discounts). |
| `BlockedTaxes` | [`IList<Models.OrderLineItemPricingBlocklistsBlockedTax>`](../../doc/models/order-line-item-pricing-blocklists-blocked-tax.md) | Optional | A list of taxes blocked from applying to the line item.<br>Taxes can be blocked by the `tax_uid` (for ad hoc taxes) or<br>the `tax_catalog_object_id` (for catalog taxes). |

## Example (as JSON)

```json
{
  "blocked_discounts": null,
  "blocked_taxes": null
}
```

