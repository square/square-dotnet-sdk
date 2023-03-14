
# Inventory Physical Count

Represents the quantity of an item variation that is physically present
at a specific location, verified by a seller or a seller's employee. For example,
a physical count might come from an employee counting the item variations on
hand or from syncing with an external system.

## Structure

`InventoryPhysicalCount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique Square-generated ID for the<br>[InventoryPhysicalCount](../../doc/models/inventory-physical-count.md).<br>**Constraints**: *Maximum Length*: `100` |
| `ReferenceId` | `string` | Optional | An optional ID provided by the application to tie the<br>[InventoryPhysicalCount](../../doc/models/inventory-physical-count.md) to an external<br>system.<br>**Constraints**: *Maximum Length*: `255` |
| `CatalogObjectId` | `string` | Optional | The Square-generated ID of the<br>[CatalogObject](../../doc/models/catalog-object.md) being tracked.<br>**Constraints**: *Maximum Length*: `100` |
| `CatalogObjectType` | `string` | Optional | The [type](../../doc/models/catalog-object-type.md) of the [CatalogObject](../../doc/models/catalog-object.md) being tracked.<br><br>The Inventory API supports setting and reading the `"catalog_object_type": "ITEM_VARIATION"` field value.<br>In addition, it can also read the `"catalog_object_type": "ITEM"` field value that is set by the Square Restaurants app.<br>**Constraints**: *Maximum Length*: `14` |
| `State` | [`string`](../../doc/models/inventory-state.md) | Optional | Indicates the state of a tracked item quantity in the lifecycle of goods. |
| `LocationId` | `string` | Optional | The Square-generated ID of the [Location](../../doc/models/location.md) where the related<br>quantity of items is being tracked.<br>**Constraints**: *Maximum Length*: `100` |
| `Quantity` | `string` | Optional | The number of items affected by the physical count as a decimal string.<br>The number can support up to 5 digits after the decimal point.<br>**Constraints**: *Maximum Length*: `26` |
| `Source` | [`Models.SourceApplication`](../../doc/models/source-application.md) | Optional | Represents information about the application used to generate a change. |
| `EmployeeId` | `string` | Optional | The Square-generated ID of the [Employee](../../doc/models/employee.md) responsible for the<br>physical count.<br>**Constraints**: *Maximum Length*: `100` |
| `TeamMemberId` | `string` | Optional | The Square-generated ID of the [Team Member](../../doc/models/team-member.md) responsible for the<br>physical count.<br>**Constraints**: *Maximum Length*: `100` |
| `OccurredAt` | `string` | Optional | A client-generated RFC 3339-formatted timestamp that indicates when<br>the physical count was examined. For physical count updates, the `occurred_at`<br>timestamp cannot be older than 24 hours or in the future relative to the<br>time of the request.<br>**Constraints**: *Maximum Length*: `34` |
| `CreatedAt` | `string` | Optional | An RFC 3339-formatted timestamp that indicates when the physical count is received.<br>**Constraints**: *Maximum Length*: `34` |

## Example (as JSON)

```json
{
  "id": null,
  "reference_id": null,
  "catalog_object_id": null,
  "catalog_object_type": null,
  "state": null,
  "location_id": null,
  "quantity": null,
  "source": null,
  "employee_id": null,
  "team_member_id": null,
  "occurred_at": null,
  "created_at": null
}
```

