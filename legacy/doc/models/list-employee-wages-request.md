
# List Employee Wages Request

A request for a set of `EmployeeWage` objects.

## Structure

`ListEmployeeWagesRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EmployeeId` | `string` | Optional | Filter the returned wages to only those that are associated with the specified employee. |
| `Limit` | `int?` | Optional | The maximum number of `EmployeeWage` results to return per page. The number can range between<br>1 and 200. The default is 200.<br>**Constraints**: `>= 1`, `<= 200` |
| `Cursor` | `string` | Optional | A pointer to the next page of `EmployeeWage` results to fetch. |

## Example (as JSON)

```json
{
  "employee_id": "employee_id2",
  "limit": 58,
  "cursor": "cursor4"
}
```

