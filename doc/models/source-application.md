
# Source Application

Represents information about the application used to generate a change.

## Structure

`SourceApplication`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Product` | [`string`](../../doc/models/product.md) | Optional | Indicates the Square product used to generate a change. |
| `ApplicationId` | `string` | Optional | __Read only__ The Square-assigned ID of the application. This field is used only if the<br>[product](entity:Product) type is `EXTERNAL_API`. |
| `Name` | `string` | Optional | __Read only__ The display name of the application<br>(for example, `"Custom Application"` or `"Square POS 4.74 for Android"`). |

## Example (as JSON)

```json
{
  "product": "INVOICES",
  "application_id": "application_id0",
  "name": "name4"
}
```

