
# Retrieve Location Custom Attribute Definition Response

Represents a [RetrieveLocationCustomAttributeDefinition](../../doc/api/location-custom-attributes.md#retrieve-location-custom-attribute-definition) response.
Either `custom_attribute_definition` or `errors` is present in the response.

## Structure

`RetrieveLocationCustomAttributeDefinitionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttributeDefinition` | [`Models.CustomAttributeDefinition`](../../doc/models/custom-attribute-definition.md) | Optional | Represents a definition for custom attribute values. A custom attribute definition<br>specifies the key, visibility, schema, and other properties for a custom attribute. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "custom_attribute_definition": {
    "created_at": "2022-12-02T19:06:36.559Z",
    "description": "Bestselling item at location",
    "key": "bestseller",
    "name": "Bestseller",
    "schema": null,
    "updated_at": "2022-12-02T19:06:36.559Z",
    "version": 1,
    "visibility": "VISIBILITY_READ_WRITE_VALUES"
  }
}
```
