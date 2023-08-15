
# Retrieve Customer Segment Response

Defines the fields that are included in the response body for requests to the `RetrieveCustomerSegment` endpoint.

Either `errors` or `segment` is present in a given response (never both).

## Structure

`RetrieveCustomerSegmentResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Segment` | [`CustomerSegment`](../../doc/models/customer-segment.md) | Optional | Represents a group of customer profiles that match one or more predefined filter criteria.<br><br>Segments (also known as Smart Groups) are defined and created within the Customer Directory in the<br>Square Seller Dashboard or Point of Sale. |

## Example (as JSON)

```json
{
  "segment": {
    "created_at": "2020-01-09T19:33:24.469Z",
    "id": "GMNXRZVEXNQDF.CHURN_RISK",
    "name": "Lapsed",
    "updated_at": "2020-04-13T23:01:13Z"
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

