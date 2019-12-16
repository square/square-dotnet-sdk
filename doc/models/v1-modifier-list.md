## V1 Modifier List

V1ModifierList

### Structure

`V1ModifierList`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The modifier list's unique ID. |
| `Name` | `string` | Optional | The modifier list's name. |
| `SelectionType` | [`string`](/doc/models/v1-modifier-list-selection-type.md) | Optional | - |
| `ModifierOptions` | [`IList<Models.V1ModifierOption>`](/doc/models/v1-modifier-option.md) | Optional | The options included in the modifier list. |
| `V2Id` | `string` | Optional | The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID. |

### Example (as JSON)

```json
{
  "id": null,
  "name": null,
  "selection_type": null,
  "modifier_options": null,
  "v2_id": null
}
```

