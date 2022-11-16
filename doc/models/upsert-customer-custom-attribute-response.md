
# Upsert Customer Custom Attribute Response

Represents an [UpsertCustomerCustomAttribute](../../doc/api/customer-custom-attributes.md#upsert-customer-custom-attribute) response.
Either `custom_attribute_definition` or `errors` is present in the response.

## Structure

`UpsertCustomerCustomAttributeResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttribute` | [`Models.CustomAttribute`](../../doc/models/custom-attribute.md) | Optional | A custom attribute value. Each custom attribute value has a corresponding<br>`CustomAttributeDefinition` object. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "custom_attribute": null,
  "errors": null
}
```

