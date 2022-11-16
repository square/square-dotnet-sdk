
# Retrieve Order Custom Attribute Response

Represents a response from getting an order custom attribute.

## Structure

`RetrieveOrderCustomAttributeResponse`

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

