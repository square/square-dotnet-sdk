
# Event Data

## Structure

`EventData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Optional | The name of the affected object’s type. |
| `Id` | `string` | Optional | The ID of the affected object. |
| `Deleted` | `bool?` | Optional | This is true if the affected object has been deleted; otherwise, it's absent. |
| `MObject` | `JsonObject` | Optional | An object containing fields and values relevant to the event. It is absent if the affected object has been deleted. |

## Example (as JSON)

```json
{
  "type": "type2",
  "id": "id8",
  "deleted": false,
  "object": {
    "key1": "val1",
    "key2": "val2"
  }
}
```

