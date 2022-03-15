
# Create Break Type Request

A request to create a new `BreakType`.

## Structure

`CreateBreakTypeRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` | Optional | A unique string value to ensure the idempotency of the operation.<br>**Constraints**: *Maximum Length*: `128` |
| `BreakType` | [`Models.BreakType`](../../doc/models/break-type.md) | Required | A defined break template that sets an expectation for possible `Break`<br>instances on a `Shift`. |

## Example (as JSON)

```json
{
  "break_type": {
    "break_name": "Lunch Break",
    "expected_duration": "PT30M",
    "is_paid": true,
    "location_id": "CGJN03P1D08GF"
  },
  "idempotency_key": "PAD3NG5KSN2GL"
}
```

