
# Update Merchant Custom Attribute Definition Response

Represents an [UpdateMerchantCustomAttributeDefinition](../../doc/api/merchant-custom-attributes.md#update-merchant-custom-attribute-definition) response.
Either `custom_attribute_definition` or `errors` is present in the response.

## Structure

`UpdateMerchantCustomAttributeDefinitionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttributeDefinition` | [`CustomAttributeDefinition`](../../doc/models/custom-attribute-definition.md) | Optional | Represents a definition for custom attribute values. A custom attribute definition<br>specifies the key, visibility, schema, and other properties for a custom attribute. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "custom_attribute_definition": {
    "created_at": "2023-05-05T19:06:36.559Z",
    "description": "Update the description as desired.",
    "key": "alternative_seller_name",
    "name": "Alternative Merchant Name",
    "schema": {
      "key1": "val1",
      "key2": "val2"
    },
    "updated_at": "2023-05-05T19:34:10.181Z",
    "version": 2,
    "visibility": "VISIBILITY_READ_ONLY"
  },
  "errors": [
    {
      "category": "REFUND_ERROR",
      "code": "MERCHANT_SUBSCRIPTION_NOT_FOUND",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "BAD_REQUEST",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "EXTERNAL_VENDOR_ERROR",
      "code": "MISSING_REQUIRED_PARAMETER",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

