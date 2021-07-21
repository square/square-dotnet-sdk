
# Order Return Line Item Modifier

A line item modifier being returned.

## Structure

`OrderReturnLineItemModifier`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Uid` | `string` | Optional | A unique ID that identifies the return modifier only within this order.<br>**Constraints**: *Maximum Length*: `60` |
| `SourceModifierUid` | `string` | Optional | The modifier `uid` from the order's line item that contains the<br>original sale of this line item modifier.<br>**Constraints**: *Maximum Length*: `60` |
| `CatalogObjectId` | `string` | Optional | The catalog object ID referencing [CatalogModifier](/doc/models/catalog-modifier.md).<br>**Constraints**: *Maximum Length*: `192` |
| `CatalogVersion` | `long?` | Optional | The version of the catalog object that this line item modifier references. |
| `Name` | `string` | Optional | The name of the item modifier.<br>**Constraints**: *Maximum Length*: `255` |
| `BasePriceMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TotalPriceMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |

## Example (as JSON)

```json
{
  "uid": "uid0",
  "source_modifier_uid": "source_modifier_uid6",
  "catalog_object_id": "catalog_object_id6",
  "catalog_version": 126,
  "name": "name0"
}
```

