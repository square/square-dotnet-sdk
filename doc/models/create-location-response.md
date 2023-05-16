
# Create Location Response

The response object returned by the [CreateLocation](../../doc/api/locations.md#create-location) endpoint.

## Structure

`CreateLocationResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Information about [errors](https://developer.squareup.com/docs/build-basics/handling-errors) encountered during the request. |
| `Location` | [`Models.Location`](../../doc/models/location.md) | Optional | Represents one of a business' [locations](https://developer.squareup.com/docs/locations-api). |

## Example (as JSON)

```json
{
  "location": {
    "address": {
      "address_line_1": "1234 Peachtree St. NE",
      "administrative_district_level_1": "GA",
      "locality": "Atlanta",
      "postal_code": "30309",
      "address_line_2": "address_line_20",
      "address_line_3": "address_line_36",
      "sublocality": "sublocality0"
    },
    "business_name": "Jet Fuel Coffee",
    "capabilities": [
      "CREDIT_CARD_PROCESSING"
    ],
    "coordinates": {
      "latitude": 33.7889,
      "longitude": -84.3841
    },
    "country": "US",
    "created_at": "2022-02-19T17:58:25Z",
    "currency": "USD",
    "description": "Midtown Atlanta store",
    "id": "3Z4V4WHQK64X9",
    "language_code": "en-US",
    "mcc": "7299",
    "merchant_id": "3MYCJG5GVYQ8Q",
    "name": "Midtown",
    "status": "ACTIVE",
    "timezone": "America/New_York",
    "type": "PHYSICAL"
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

