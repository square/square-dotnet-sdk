
# Square Event Data

## Structure

`SquareEventData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Optional | Name of the affected object’s type. |
| `Id` | `string` | Optional | ID of the affected object. |
| `Deleted` | `bool?` | Optional | Is true if the affected object was deleted. Otherwise absent. |
| `MObject` | `JsonObject` | Optional | An object containing fields and values relevant to the event. Is absent if affected object was deleted. |

## Example (as JSON)

```json
{
  "type": null,
  "id": null,
  "deleted": null,
  "object": null
}
```

