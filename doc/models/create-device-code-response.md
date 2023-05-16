
# Create Device Code Response

## Structure

`CreateDeviceCodeResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `DeviceCode` | [`Models.DeviceCode`](../../doc/models/device-code.md) | Optional | - |

## Example (as JSON)

```json
{
  "device_code": {
    "code": "EBCARJ",
    "created_at": "2020-02-06T18:44:33.000Z",
    "id": "B3Z6NAMYQSMTM",
    "location_id": "B5E4484SHHNYH",
    "name": "Counter 1",
    "pair_by": "2020-02-06T18:49:33.000Z",
    "product_type": "TERMINAL_API",
    "status": "UNPAIRED",
    "status_changed_at": "2020-02-06T18:44:33.000Z",
    "device_id": "device_id0"
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

