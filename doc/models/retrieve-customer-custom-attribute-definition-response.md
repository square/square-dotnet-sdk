
# Retrieve Customer Custom Attribute Definition Response

Represents a [RetrieveCustomerCustomAttributeDefinition](../../doc/api/customer-custom-attributes.md#retrieve-customer-custom-attribute-definition) response.
Either `custom_attribute_definition` or `errors` is present in the response.

## Structure

`RetrieveCustomerCustomAttributeDefinitionResponse`

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
    "schema": {
      "key1": "val1",
      "key2": "val2"
    },
    "updated_at": "2022-04-26T15:27:30Z",
    "version": 1,
    "visibility": "VISIBILITY_READ_WRITE_VALUES"
  },
  "errors": [
    {
      "category": "AUTHENTICATION_ERROR",
      "code": "REFUND_ALREADY_PENDING",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "INVALID_REQUEST_ERROR",
      "code": "PAYMENT_NOT_REFUNDABLE",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "RATE_LIMIT_ERROR",
      "code": "REFUND_DECLINED",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

