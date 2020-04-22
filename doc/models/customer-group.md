## Customer Group

Represents a group of customer profiles. 

Customer groups can be created, modified, and have their membership defined either via 
the Customers API or within Customer Directory in the Square Dashboard or Point of Sale.

### Structure

`CustomerGroup`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | Unique Square-generated ID for the customer group. |
| `Name` | `string` |  | Name of the customer group. |
| `CreatedAt` | `string` | Optional | The timestamp when the customer group was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timesamp when the customer group was last updated, in RFC 3339 format. |

### Example (as JSON)

```json
{
  "id": null,
  "name": "name0",
  "created_at": null,
  "updated_at": null
}
```

