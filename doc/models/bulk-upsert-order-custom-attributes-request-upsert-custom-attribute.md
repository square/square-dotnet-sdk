
# Bulk Upsert Order Custom Attributes Request Upsert Custom Attribute

Represents one upsert within the bulk operation.

## Structure

`BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttribute` | [`Models.CustomAttribute`](../../doc/models/custom-attribute.md) | Required | A custom attribute value. Each custom attribute value has a corresponding<br>`CustomAttributeDefinition` object. |
| `IdempotencyKey` | `string` | Optional | A unique identifier for this request, used to ensure idempotency.<br>For more information, see [Idempotency](https://developer.squareup.com/docs/basics/api101/idempotency).<br>**Constraints**: *Maximum Length*: `45` |
| `OrderId` | `string` | Required | The ID of the target [order](../../doc/models/order.md). |

## Example (as JSON)

```json
{
  "custom_attribute": {
    "key": null,
    "value": null,
    "version": null,
    "visibility": null,
    "definition": null,
    "updated_at": null,
    "created_at": null
  },
  "idempotency_key": null,
  "order_id": "order_id6"
}
```

