
# Bulk Upsert Merchant Custom Attributes Response

Represents a [BulkUpsertMerchantCustomAttributes](../../doc/api/merchant-custom-attributes.md#bulk-upsert-merchant-custom-attributes) response,
which contains a map of responses that each corresponds to an individual upsert request.

## Structure

`BulkUpsertMerchantCustomAttributesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Values` | [`IDictionary<string, Models.BulkUpsertMerchantCustomAttributesResponseMerchantCustomAttributeUpsertResponse>`](../../doc/models/bulk-upsert-merchant-custom-attributes-response-merchant-custom-attribute-upsert-response.md) | Optional | A map of responses that correspond to individual upsert requests. Each response has the<br>same ID as the corresponding request and contains either a `merchant_id` and `custom_attribute` or an `errors` field. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "values": {
    "key0": {
      "merchant_id": "merchant_id0",
      "custom_attribute": {
        "key": "key8",
        "value": {
          "key1": "val1",
          "key2": "val2"
        },
        "version": 82,
        "visibility": "VISIBILITY_READ_WRITE_VALUES",
        "definition": {
          "key": "key8",
          "schema": {
            "key1": "val1",
            "key2": "val2"
          },
          "name": "name8",
          "description": "description8",
          "visibility": "VISIBILITY_HIDDEN"
        }
      },
      "errors": [
        {
          "category": "API_ERROR",
          "code": "INVALID_FEES",
          "detail": "detail1",
          "field": "field9"
        }
      ]
    },
    "key1": {
      "merchant_id": "merchant_id1",
      "custom_attribute": {
        "key": "key9",
        "value": {
          "key1": "val1",
          "key2": "val2"
        },
        "version": 83,
        "visibility": "VISIBILITY_READ_ONLY",
        "definition": {
          "key": "key9",
          "schema": {
            "key1": "val1",
            "key2": "val2"
          },
          "name": "name9",
          "description": "description9",
          "visibility": "VISIBILITY_READ_ONLY"
        }
      },
      "errors": [
        {
          "category": "AUTHENTICATION_ERROR",
          "code": "MANUALLY_ENTERED_PAYMENT_NOT_SUPPORTED",
          "detail": "detail2",
          "field": "field0"
        },
        {
          "category": "INVALID_REQUEST_ERROR",
          "code": "PAYMENT_LIMIT_EXCEEDED",
          "detail": "detail3",
          "field": "field1"
        }
      ]
    },
    "key2": {
      "merchant_id": "merchant_id2",
      "custom_attribute": {
        "key": "key0",
        "value": {
          "key1": "val1",
          "key2": "val2"
        },
        "version": 84,
        "visibility": "VISIBILITY_HIDDEN",
        "definition": {
          "key": "key0",
          "schema": {
            "key1": "val1",
            "key2": "val2"
          },
          "name": "name0",
          "description": "description0",
          "visibility": "VISIBILITY_READ_WRITE_VALUES"
        }
      },
      "errors": [
        {
          "category": "INVALID_REQUEST_ERROR",
          "code": "PAYMENT_LIMIT_EXCEEDED",
          "detail": "detail3",
          "field": "field1"
        },
        {
          "category": "RATE_LIMIT_ERROR",
          "code": "GIFT_CARD_AVAILABLE_AMOUNT",
          "detail": "detail4",
          "field": "field2"
        },
        {
          "category": "PAYMENT_METHOD_ERROR",
          "code": "ACCOUNT_UNUSABLE",
          "detail": "detail5",
          "field": "field3"
        }
      ]
    }
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

