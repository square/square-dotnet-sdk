
# Receipt Options

Describes receipt action fields.

## Structure

`ReceiptOptions`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `PaymentId` | `string` | Required | The reference to the Square payment ID for the receipt. |
| `PrintOnly` | `bool?` | Optional | Instructs the device to print the receipt without displaying the receipt selection screen.<br>Requires `printer_enabled` set to true.<br>Defaults to false. |
| `IsDuplicate` | `bool?` | Optional | Identify the receipt as a reprint rather than an original receipt.<br>Defaults to false. |

## Example (as JSON)

```json
{
  "payment_id": "payment_id6",
  "print_only": false,
  "is_duplicate": false
}
```

