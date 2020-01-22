## V1 List Settlements Request

### Structure

`V1ListSettlementsRequest`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Order` | [`string`](/doc/models/sort-order.md) | Optional | The order (e.g., chronological or alphabetical) in which results from a request are returned. |
| `BeginTime` | `string` | Optional | The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year. |
| `EndTime` | `string` | Optional | The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time. |
| `Limit` | `int?` | Optional | The maximum number of settlements to return in a single response. This value cannot exceed 200. |
| `Status` | [`string`](/doc/models/v1-list-settlements-request-status.md) | Optional | - |
| `BatchToken` | `string` | Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Example (as JSON)

```json
{
  "order": null,
  "begin_time": null,
  "end_time": null,
  "limit": null,
  "status": null,
  "batch_token": null
}
```

