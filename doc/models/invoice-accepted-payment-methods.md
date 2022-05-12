
# Invoice Accepted Payment Methods

The payment methods that customers can use to pay an invoice on the Square-hosted invoice page.

## Structure

`InvoiceAcceptedPaymentMethods`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Card` | `bool?` | Optional | Indicates whether credit card or debit card payments are accepted. The default value is `false`. |
| `SquareGiftCard` | `bool?` | Optional | Indicates whether Square gift card payments are accepted. The default value is `false`. |
| `BankAccount` | `bool?` | Optional | Indicates whether bank transfer payments are accepted. The default value is `false`.<br><br>This option is allowed only for invoices that have a single payment request of type `BALANCE`. |

## Example (as JSON)

```json
{
  "card": null,
  "square_gift_card": null,
  "bank_account": null
}
```

