## Update Item Modifier Lists Request

### Structure

`UpdateItemModifierListsRequest`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ItemIds` | `IList<string>` |  | The IDs of the catalog items associated with the CatalogModifierList objects being updated. |
| `ModifierListsToEnable` | `IList<string>` | Optional | The IDs of the CatalogModifierList objects to enable for the CatalogItem. |
| `ModifierListsToDisable` | `IList<string>` | Optional | The IDs of the CatalogModifierList objects to disable for the CatalogItem. |

### Example (as JSON)

```json
{
  "item_ids": [
    "H42BRLUJ5KTZTTMPVSLFAACQ",
    "2JXOBJIHCWBQ4NZ3RIXQGJA6"
  ],
  "modifier_lists_to_enable": [
    "H42BRLUJ5KTZTTMPVSLFAACQ",
    "2JXOBJIHCWBQ4NZ3RIXQGJA6"
  ],
  "modifier_lists_to_disable": [
    "7WRC16CJZDVLSNDQ35PP6YAD"
  ]
}
```

