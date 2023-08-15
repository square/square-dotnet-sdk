
# Retrieve Gift Card Response

A response that contains a `GiftCard`. The response might contain a set of `Error` objects
if the request resulted in errors.

## Structure

`RetrieveGiftCardResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `GiftCard` | [`GiftCard`](../../doc/models/gift-card.md) | Optional | Represents a Square gift card. |

## Example (as JSON)

```json
{
  "gift_card": {
    "balance_money": {
      "amount": 1000,
      "currency": "USD"
    },
    "created_at": "2021-05-20T22:26:54.000Z",
    "gan": "7783320001001635",
    "gan_source": "SQUARE",
    "id": "gftc:00113070ba5745f0b2377c1b9570cb03",
    "state": "ACTIVE",
    "type": "DIGITAL"
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

