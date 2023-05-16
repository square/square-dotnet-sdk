
# Retrieve Merchant Response

The response object returned by the [RetrieveMerchant](../../doc/api/merchants.md#retrieve-merchant) endpoint.

## Structure

`RetrieveMerchantResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Information on errors encountered during the request. |
| `Merchant` | [`Models.Merchant`](../../doc/models/merchant.md) | Optional | Represents a business that sells with Square. |

## Example (as JSON)

```json
{
  "merchant": {
    "business_name": "Apple A Day",
    "country": "US",
    "created_at": "2021-12-10T19:25:52.484Z",
    "currency": "USD",
    "id": "DM7VKY8Q63GNP",
    "language_code": "en-US",
    "main_location_id": "9A65CGC72ZQG1",
    "status": "ACTIVE"
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

