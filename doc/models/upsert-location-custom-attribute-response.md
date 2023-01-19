
# Upsert Location Custom Attribute Response

Represents an [UpsertLocationCustomAttribute](../../doc/api/location-custom-attributes.md#upsert-location-custom-attribute) response.
Either `custom_attribute_definition` or `errors` is present in the response.

## Structure

`UpsertLocationCustomAttributeResponse`

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

