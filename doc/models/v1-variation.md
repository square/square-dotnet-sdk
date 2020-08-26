## V1 Variation

V1Variation

### Structure

`V1Variation`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The item variation's unique ID. |
| `Name` | `string` | Optional | The item variation's name. |
| `ItemId` | `string` | Optional | The ID of the variation's associated item. |
| `Ordinal` | `int?` | Optional | Indicates the variation's list position when displayed in Square Point of Sale and the merchant dashboard. If more than one variation for the same item has the same ordinal value, those variations are displayed in alphabetical order |
| `PricingType` | [`string`](/doc/models/v1-variation-pricing-type.md) | Optional | - |
| `PriceMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `Sku` | `string` | Optional | The item variation's SKU, if any. |
| `TrackInventory` | `bool?` | Optional | If true, inventory tracking is active for the variation. |
| `InventoryAlertType` | [`string`](/doc/models/v1-variation-inventory-alert-type.md) | Optional | - |
| `InventoryAlertThreshold` | `int?` | Optional | If the inventory quantity for the variation is less than or equal to this value and inventory_alert_type is LOW_QUANTITY, the variation displays an alert in the merchant dashboard. |
| `UserData` | `string` | Optional | Arbitrary metadata associated with the variation. Cannot exceed 255 characters. |
| `V2Id` | `string` | Optional | The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID. |

### Example (as JSON)

```json
{
  "id": "id0",
  "name": "name0",
  "item_id": "item_id0",
  "ordinal": 80,
  "pricing_type": "FIXED_PRICING"
}
```

