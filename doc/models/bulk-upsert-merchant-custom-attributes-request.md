
# Bulk Upsert Merchant Custom Attributes Request

Represents a [BulkUpsertMerchantCustomAttributes](../../doc/api/merchant-custom-attributes.md#bulk-upsert-merchant-custom-attributes) request.

## Structure

`BulkUpsertMerchantCustomAttributesRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Values` | [`IDictionary<string, BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest>`](../../doc/models/bulk-upsert-merchant-custom-attributes-request-merchant-custom-attribute-upsert-request.md) | Required | A map containing 1 to 25 individual upsert requests. For each request, provide an<br>arbitrary ID that is unique for this `BulkUpsertMerchantCustomAttributes` request and the<br>information needed to create or update a custom attribute. |

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
      "idempotency_key": "idempotency_key6"
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
      "idempotency_key": "idempotency_key7"
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
      "idempotency_key": "idempotency_key8"
    }
  }
}
```

