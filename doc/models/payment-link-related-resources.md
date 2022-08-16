
# Payment Link Related Resources

## Structure

`PaymentLinkRelatedResources`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Orders` | [`IList<Models.Order>`](../../doc/models/order.md) | Optional | The order associated with the payment link. |
| `SubscriptionPlans` | [`IList<Models.CatalogObject>`](../../doc/models/catalog-object.md) | Optional | The subscription plan associated with the payment link. |

## Example (as JSON)

```json
{
  "orders": null,
  "subscription_plans": null
}
```

