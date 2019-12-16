## List Employees Response

### Structure

`ListEmployeesResponse`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Employees` | [`IList<Models.Employee>`](/doc/models/employee.md) | Optional | List of employees returned from the request. |
| `Cursor` | `string` | Optional | The token to be used to retrieve the next page of results. |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | Any errors that occurred during the request. |

### Example (as JSON)

```json
{
  "employees": null,
  "cursor": null,
  "errors": null
}
```

