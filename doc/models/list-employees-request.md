## List Employees Request

### Structure

`ListEmployeesRequest`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | Filter employees returned to only those that are associated with the specified location. |
| `Status` | [`string`](/doc/models/employee-status.md) | Optional | The status of the Employee being retrieved. |
| `Limit` | `int?` | Optional | The number of employees to be returned on each page. |
| `Cursor` | `string` | Optional | The token required to retrieve the specified page of results. |

### Example (as JSON)

```json
{
  "location_id": null,
  "status": null,
  "limit": null,
  "cursor": null
}
```

