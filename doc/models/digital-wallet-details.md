
# Digital Wallet Details

Additional details about `WALLET` type payments. Contains only non-confidential information.

## Structure

`DigitalWalletDetails`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Status` | `string` | Optional | The status of the `WALLET` payment. The status can be `AUTHORIZED`, `CAPTURED`, `VOIDED`, or<br>`FAILED`.<br>**Constraints**: *Maximum Length*: `50` |
| `Brand` | `string` | Optional | The brand used for the `WALLET` payment. The brand can be `CASH_APP`, `PAYPAY` or `UNKNOWN`.<br>**Constraints**: *Maximum Length*: `50` |
| `CashAppDetails` | [`Models.CashAppDetails`](../../doc/models/cash-app-details.md) | Optional | Additional details about `WALLET` type payments with the `brand` of `CASH_APP`. |

## Example (as JSON)

```json
{
  "status": null,
  "brand": null,
  "cash_app_details": null
}
```

