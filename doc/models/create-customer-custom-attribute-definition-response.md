
# Create Customer Custom Attribute Definition Response

Represents a [CreateCustomerCustomAttributeDefinition](../../doc/api/customer-custom-attributes.md#create-customer-custom-attribute-definition) response.
Either `custom_attribute_definition` or `errors` is present in the response.

## Structure

`CreateCustomerCustomAttributeDefinitionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttributeDefinition` | [`Models.CustomAttributeDefinition`](../../doc/models/custom-attribute-definition.md) | Optional | Represents a definition for custom attribute values. A custom attribute definition<br>specifies the key, visibility, schema, and other properties for a custom attribute. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "custom_attribute_definition": {
    "created_at": "2022-04-26T15:27:30Z",
    "description": "The favorite movie of the customer.",
    "key": "favoritemovie",
    "name": "Favorite Movie",
    "schema": null,
    "updated_at": "2022-04-26T15:27:30Z",
    "version": 1,
    "visibility": "VISIBILITY_HIDDEN"
  }
}
```

