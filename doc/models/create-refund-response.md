
# Create Refund Response

Defines the fields that are included in the response body of
a request to the [CreateRefund](api-endpoint:Transactions-CreateRefund) endpoint.

One of `errors` or `refund` is present in a given response (never both).

## Structure

`CreateRefundResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Refund` | [`Refund`](../../doc/models/refund.md) | Optional | Represents a refund processed for a Square transaction. |

## Example (as JSON)

```json
{
  "refund": {
    "additional_recipients": [
      {
        "amount_money": {
          "amount": 10,
          "currency": "USD"
        },
        "description": "Application fees",
        "location_id": "057P5VYJ4A5X1",
        "receivable_id": "ISu5xwxJ5v0CMJTQq7RvqyMF"
      }
    ],
    "amount_money": {
      "amount": 100,
      "currency": "USD"
    },
    "created_at": "2016-02-12T00:28:18Z",
    "id": "b27436d1-7f8e-5610-45c6-417ef71434b4-SW",
    "location_id": "18YC4JDH91E1H",
    "reason": "some reason",
    "status": "PENDING",
    "tender_id": "MtZRYYdDrYNQbOvV7nbuBvMF",
    "transaction_id": "KnL67ZIwXCPtzOrqj0HrkxMF",
    "processing_fee_money": {
      "amount": 46,
      "currency": "TMT"
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

