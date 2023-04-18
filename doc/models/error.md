
# Error

Represents an error encountered during a request to the Connect API.

See [Handling errors](https://developer.squareup.com/docs/build-basics/handling-errors) for more information.

## Structure

`Error`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Category` | [`string`](../../doc/models/error-category.md) | Required | Indicates which high-level category of error has occurred during a<br>request to the Connect API. |
| `Code` | [`string`](../../doc/models/error-code.md) | Required | Indicates the specific error that occurred during a request to a<br>Square API. |
| `Detail` | `string` | Optional | A human-readable description of the error for debugging purposes. |
| `Field` | `string` | Optional | The name of the field provided in the original request (if any) that<br>the error pertains to. |

## Example (as JSON)

```json
{
  "category": "RATE_LIMIT_ERROR",
  "code": "UNEXPECTED_VALUE",
  "detail": "detail6",
  "field": "field6"
}
```

