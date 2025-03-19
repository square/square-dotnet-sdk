
# Qr Code Options

Fields to describe the action that displays QR-Codes.

## Structure

`QrCodeOptions`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Title` | `string` | Required | The title text to display in the QR code flow on the Terminal.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `250` |
| `Body` | `string` | Required | The body text to display in the QR code flow on the Terminal.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `10000` |
| `BarcodeContents` | `string` | Required | The text representation of the data to show in the QR code<br>as UTF8-encoded data.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1024` |

## Example (as JSON)

```json
{
  "title": "title8",
  "body": "body8",
  "barcode_contents": "barcode_contents4"
}
```

