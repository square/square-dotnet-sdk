
# Business Hours

The hours of operation for a location.

## Structure

`BusinessHours`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Periods` | [`IList<Models.BusinessHoursPeriod>`](../../doc/models/business-hours-period.md) | Optional | The list of time periods during which the business is open. There can be at most 10 periods per day. |

## Example (as JSON)

```json
{
  "periods": null
}
```

