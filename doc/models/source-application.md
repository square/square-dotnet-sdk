## Source Application

Provides information about the application used to generate an inventory
change.

### Structure

`SourceApplication`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Product` | [`string`](/doc/models/product.md) | Optional | Indicates the Square product used to generate an inventory change. |
| `ApplicationId` | `string` | Optional | Read-only Square ID assigned to the application. Only used for<br>[Product](#type-product) type `EXTERNAL_API`. |
| `Name` | `string` | Optional | Read-only display name assigned to the application<br>(e.g. `"Custom Application"`, `"Square POS 4.74 for Android"`). |

### Example (as JSON)

```json
{
  "product": null,
  "application_id": null,
  "name": null
}
```

