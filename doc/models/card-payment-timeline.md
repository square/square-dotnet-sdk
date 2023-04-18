
# Card Payment Timeline

The timeline for card payments.

## Structure

`CardPaymentTimeline`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AuthorizedAt` | `string` | Optional | The timestamp when the payment was authorized, in RFC 3339 format. |
| `CapturedAt` | `string` | Optional | The timestamp when the payment was captured, in RFC 3339 format. |
| `VoidedAt` | `string` | Optional | The timestamp when the payment was voided, in RFC 3339 format. |

## Example (as JSON)

```json
{
  "authorized_at": "authorized_at4",
  "captured_at": "captured_at4",
  "voided_at": "voided_at8"
}
```

