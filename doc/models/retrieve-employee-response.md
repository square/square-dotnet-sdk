## Retrieve Employee Response

### Structure

`RetrieveEmployeeResponse`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Employee` | [`Models.Employee`](/doc/models/employee.md) | Optional | An employee object that is used by the external API. |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | Any errors that occurred during the request. |

### Example (as JSON)

```json
{
  "employee": null,
  "errors": null
}
```

