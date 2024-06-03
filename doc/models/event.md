
# Event

## Structure

`Event`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `MerchantId` | `string` | Optional | The ID of the target merchant associated with the event. |
| `LocationId` | `string` | Optional | The ID of the target location associated with the event. |
| `Type` | `string` | Optional | The type of event this represents. |
| `EventId` | `string` | Optional | A unique ID for the event. |
| `CreatedAt` | `string` | Optional | Timestamp of when the event was created, in RFC 3339 format. |
| `Data` | [`EventData`](../../doc/models/event-data.md) | Optional | - |

## Example (as JSON)

```json
{
  "merchant_id": "merchant_id2",
  "location_id": "location_id6",
  "type": "type8",
  "event_id": "event_id8",
  "created_at": "created_at0"
}
```

