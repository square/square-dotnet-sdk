
# Event

## Structure

`Event`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MerchantId` | `string` | Optional | The ID of the target merchant associated with the event. |
| `LocationId` | `string` | Optional | The ID of the location associated with the event. |
| `Type` | `string` | Optional | The type of event this represents. |
| `EventId` | `string` | Optional | A unique ID for the event. |
| `CreatedAt` | `string` | Optional | Timestamp of when the event was created, in RFC 3339 format. |
| `Data` | [`Models.EventData`](../../doc/models/event-data.md) | Optional | - |

## Example (as JSON)

```json
{
  "merchant_id": "merchant_id0",
  "location_id": "location_id4",
  "type": "type0",
  "event_id": "event_id6",
  "created_at": "created_at2"
}
```

