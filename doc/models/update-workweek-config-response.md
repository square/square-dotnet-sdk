
# Update Workweek Config Response

The response to a request to update a `WorkweekConfig` object. The response contains
the updated `WorkweekConfig` object and might contain a set of `Error` objects if
the request resulted in errors.

## Structure

`UpdateWorkweekConfigResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `WorkweekConfig` | [`Models.WorkweekConfig`](../../doc/models/workweek-config.md) | Optional | Sets the day of the week and hour of the day that a business starts a<br>workweek. This is used to calculate overtime pay. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "workweek_config": {
    "created_at": "2016-02-04T00:58:24Z",
    "id": "FY4VCAQN700GM",
    "start_of_day_local_time": "10:00",
    "start_of_week": "MON",
    "updated_at": "2019-02-28T01:04:35Z",
    "version": 11
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

