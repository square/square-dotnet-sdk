
# Square Event

## Structure

`SquareEvent`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MerchantId` | `string` | Optional | The ID of the target merchant associated with the event. |
| `LocationId` | `string` | Optional | The ID of the location associated with the event. |
| `Type` | `string` | Optional | The type of event this represents. |
| `EventId` | `string` | Optional | A unique ID for the event. |
| `CreatedAt` | `string` | Optional | Timestamp of when the event was created, in RFC 3339 format. |
| `Data` | [`Models.SquareEventData`](../../doc/models/square-event-data.md) | Optional | - |

## Example (as JSON)

```json
{
  "merchant_id": null,
  "location_id": null,
  "type": null,
  "event_id": null,
  "created_at": null,
  "data": null
}
```

