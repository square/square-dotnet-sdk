## List Cash Drawer Shift Events Response

### Structure

`ListCashDrawerShiftEventsResponse`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Events` | [`IList<Models.CashDrawerShiftEvent>`](/doc/models/cash-drawer-shift-event.md) | Optional | All of the events (payments, refunds, etc.) for a cash drawer during<br>the shift. |
| `Cursor` | `string` | Optional | Opaque cursor for fetching the next page. Cursor is not present in<br>the last page of results. |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | Any errors that occurred during the request. |

### Example (as JSON)

```json
{
  "events": null,
  "cursor": null,
  "errors": null
}
```

