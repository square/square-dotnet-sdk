## V1 Item

V1Item

### Structure

`V1Item`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The item's ID. Must be unique among all entity IDs ever provided on behalf of the merchant. You can never reuse an ID. This value can include alphanumeric characters, dashes (-), and underscores (_). |
| `Name` | `string` | Optional | The item's name. |
| `Description` | `string` | Optional | The item's description. |
| `Type` | [`string`](/doc/models/v1-item-type.md) | Optional | - |
| `Color` | [`string`](/doc/models/v1-item-color.md) | Optional | - |
| `Abbreviation` | `string` | Optional | The text of the item's display label in Square Point of Sale. Only up to the first five characters of the string are used. |
| `Visibility` | [`string`](/doc/models/v1-item-visibility.md) | Optional | - |
| `AvailableOnline` | `bool?` | Optional | If true, the item can be added to shipping orders from the merchant's online store. |
| `MasterImage` | [`Models.V1ItemImage`](/doc/models/v1-item-image.md) | Optional | V1ItemImage |
| `Category` | [`Models.V1Category`](/doc/models/v1-category.md) | Optional | V1Category |
| `Variations` | [`IList<Models.V1Variation>`](/doc/models/v1-variation.md) | Optional | The item's variations. You must specify at least one variation. |
| `ModifierLists` | [`IList<Models.V1ModifierList>`](/doc/models/v1-modifier-list.md) | Optional | The modifier lists that apply to the item, if any. |
| `Fees` | [`IList<Models.V1Fee>`](/doc/models/v1-fee.md) | Optional | The fees that apply to the item, if any. |
| `Taxable` | `bool?` | Optional | Deprecated. This field is not used. |
| `CategoryId` | `string` | Optional | The ID of the item's category, if any. |
| `AvailableForPickup` | `bool?` | Optional | If true, the item can be added to pickup orders from the merchant's online store. Default value: false |
| `V2Id` | `string` | Optional | The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID. |

### Example (as JSON)

```json
{
  "id": "id0",
  "name": "name0",
  "description": "description0",
  "type": "OTHER",
  "color": "0b8000"
}
```

