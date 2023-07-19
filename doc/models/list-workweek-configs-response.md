
# List Workweek Configs Response

The response to a request for a set of `WorkweekConfig` objects. The response contains
the requested `WorkweekConfig` objects and might contain a set of `Error` objects if
the request resulted in errors.

## Structure

`ListWorkweekConfigsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `WorkweekConfigs` | [`IList<Models.WorkweekConfig>`](../../doc/models/workweek-config.md) | Optional | A page of `WorkweekConfig` results. |
| `Cursor` | `string` | Optional | The value supplied in the subsequent request to fetch the next page of<br>`WorkweekConfig` results. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "cursor": "2fofTniCgT0yIPAq26kmk0YyFQJZfbWkh73OOnlTHmTAx13NgED",
  "workweek_configs": [
    {
      "created_at": "2016-02-04T00:58:24Z",
      "id": "FY4VCAQN700GM",
      "start_of_day_local_time": "10:00",
      "start_of_week": "MON",
      "updated_at": "2019-02-28T01:04:35Z",
      "version": 11
    }
  ],
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

