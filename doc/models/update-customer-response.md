
# Update Customer Response

Defines the fields that are included in the response body of
a request to the `UpdateCustomer` endpoint.

Either `errors` or `customer` is present in a given response (never both).

## Structure

`UpdateCustomerResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Customer` | [`Models.Customer`](../../doc/models/customer.md) | Optional | Represents a Square customer profile in the Customer Directory of a Square seller. |

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
    "email_address": "New.Amelia.Earhart@example.com",
    "family_name": "Earhart",
    "given_name": "Amelia",
    "id": "JDKYHBWT1D4F8MFH63DBMEN8Y4",
    "note": "updated customer note",
    "preferences": {
      "email_unsubscribed": false
    },
    "reference_id": "YOUR_REFERENCE_ID",
    "updated_at": "2016-05-15T20:21:55Z",
    "version": 3,
    "cards": [
      {
        "id": "id7",
        "card_brand": "AMERICAN_EXPRESS",
        "last_4": "last_49",
        "exp_month": 113,
        "exp_year": 183
      }
    ]
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

