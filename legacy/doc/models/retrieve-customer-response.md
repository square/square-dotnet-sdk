
# Retrieve Customer Response

Defines the fields that are included in the response body of
a request to the `RetrieveCustomer` endpoint.

Either `errors` or `customer` is present in a given response (never both).

## Structure

`RetrieveCustomerResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Customer` | [`Customer`](../../doc/models/customer.md) | Optional | Represents a Square customer profile in the Customer Directory of a Square seller. |

## Example (as JSON)

```json
{
  "customer": {
    "address": {
      "address_line_1": "500 Electric Ave",
      "address_line_2": "Suite 600",
      "administrative_district_level_1": "NY",
      "country": "US",
      "locality": "New York",
      "postal_code": "10003"
    },
    "created_at": "2016-03-23T20:21:54.859Z",
    "creation_source": "THIRD_PARTY",
    "email_address": "Amelia.Earhart@example.com",
    "family_name": "Earhart",
    "given_name": "Amelia",
    "group_ids": [
      "545AXB44B4XXWMVQ4W8SBT3HHF"
    ],
    "id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
    "note": "a customer",
    "phone_number": "+1-212-555-4240",
    "preferences": {
      "email_unsubscribed": false
    },
    "reference_id": "YOUR_REFERENCE_ID",
    "segment_ids": [
      "1KB9JE5EGJXCW.REACHABLE"
    ],
    "updated_at": "2016-03-23T20:21:54.859Z",
    "version": 1,
    "cards": [
      {
        "id": "id8",
        "card_brand": "DISCOVER",
        "last_4": "last_40",
        "exp_month": 152,
        "exp_year": 144
      }
    ]
  },
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

