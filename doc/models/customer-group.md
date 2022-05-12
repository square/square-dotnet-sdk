
# Customer Group

Represents a group of customer profiles.

Customer groups can be created, be modified, and have their membership defined using
the Customers API or within the Customer Directory in the Square Seller Dashboard or Point of Sale.

## Structure

`CustomerGroup`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique Square-generated ID for the customer group.<br>**Constraints**: *Maximum Length*: `255` |
| `Name` | `string` | Required | The name of the customer group. |
| `CreatedAt` | `string` | Optional | The timestamp when the customer group was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp when the customer group was last updated, in RFC 3339 format. |

## Example (as JSON)

```json
{
  "id": null,
  "name": "name0",
  "created_at": null,
  "updated_at": null
}
```

