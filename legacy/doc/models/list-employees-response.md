
# List Employees Response

## Structure

`ListEmployeesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Employees` | [`IList<Employee>`](../../doc/models/employee.md) | Optional | - |
| `Cursor` | `string` | Optional | The token to be used to retrieve the next page of results. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "employees": [
    {
      "id": "id4",
      "first_name": "first_name4",
      "last_name": "last_name2",
      "email": "email2",
      "phone_number": "phone_number8"
    }
  ],
  "cursor": "cursor8",
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

