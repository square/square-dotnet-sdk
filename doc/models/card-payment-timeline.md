
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
  "authorized_at": null,
  "captured_at": null,
  "voided_at": null
}
```

