
# Bulk Upsert Order Custom Attributes Response

Represents a response from a bulk upsert of order custom attributes.

## Structure

`BulkUpsertOrderCustomAttributesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Values` | [`IDictionary<string, Models.UpsertOrderCustomAttributeResponse>`](../../doc/models/upsert-order-custom-attribute-response.md) | Required | A map of responses that correspond to individual upsert operations for custom attributes. |

## Example (as JSON)

```json
{
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
  ],
  "values": {
    "key0": {
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
  }
}
```

