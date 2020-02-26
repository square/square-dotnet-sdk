## Cancel Payment by Idempotency Key Response

Return value from the
[CancelPaymentByIdempotencyKey](#endpoint-payments-cancelpaymentbyidempotencykey) endpoint.
On success, `errors` will be empty.

### Structure

`CancelPaymentByIdempotencyKeyResponse`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | Any errors that occurred during the request. |

### Example (as JSON)

```json
{}
```

