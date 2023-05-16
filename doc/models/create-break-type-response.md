
# Create Break Type Response

The response to the request to create a `BreakType`. The response contains
the created `BreakType` object and might contain a set of `Error` objects if
the request resulted in errors.

## Structure

`CreateBreakTypeResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `BreakType` | [`Models.BreakType`](../../doc/models/break-type.md) | Optional | A defined break template that sets an expectation for possible `Break`<br>instances on a `Shift`. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "break_type": {
    "break_name": "Lunch Break",
    "created_at": "2019-02-26T22:42:54Z",
    "expected_duration": "PT30M",
    "id": "49SSVDJG76WF3",
    "is_paid": true,
    "location_id": "CGJN03P1D08GF",
    "updated_at": "2019-02-26T22:42:54Z",
    "version": 1
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

