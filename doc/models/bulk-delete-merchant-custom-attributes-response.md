
# Bulk Delete Merchant Custom Attributes Response

Represents a [BulkDeleteMerchantCustomAttributes](../../doc/api/merchant-custom-attributes.md#bulk-delete-merchant-custom-attributes) response,
which contains a map of responses that each corresponds to an individual delete request.

## Structure

`BulkDeleteMerchantCustomAttributesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Values` | [`IDictionary<string, BulkDeleteMerchantCustomAttributesResponseMerchantCustomAttributeDeleteResponse>`](../../doc/models/bulk-delete-merchant-custom-attributes-response-merchant-custom-attribute-delete-response.md) | Required | A map of responses that correspond to individual delete requests. Each response has the<br>same key as the corresponding request. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "values": {
    "id1": {
      "errors": [],
      "merchant_id": "DM7VKY8Q63GNP"
    },
    "id2": {
      "errors": [],
      "merchant_id": "DM7VKY8Q63GNP"
    }
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

