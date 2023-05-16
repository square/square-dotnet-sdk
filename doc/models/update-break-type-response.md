
# Update Break Type Response

A response to a request to update a `BreakType`. The response contains
the requested `BreakType` objects and might contain a set of `Error` objects if
the request resulted in errors.

## Structure

`UpdateBreakTypeResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BreakType` | [`Models.BreakType`](../../doc/models/break-type.md) | Optional | A defined break template that sets an expectation for possible `Break`<br>instances on a `Shift`. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "break_type": {
    "break_name": "Lunch",
    "created_at": "2018-06-12T20:19:12Z",
    "expected_duration": "PT50M",
    "id": "Q6JSJS6D4DBCH",
    "is_paid": true,
    "location_id": "26M7H24AZ9N6R",
    "updated_at": "2019-02-26T23:12:59Z",
    "version": 2
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

