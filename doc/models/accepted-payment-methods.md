
# Accepted Payment Methods

## Structure

`AcceptedPaymentMethods`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ApplePay` | `bool?` | Optional | Whether Apple Pay is accepted at checkout. |
| `GooglePay` | `bool?` | Optional | Whether Google Pay is accepted at checkout. |
| `CashAppPay` | `bool?` | Optional | Whether Cash App Pay is accepted at checkout. |
| `AfterpayClearpay` | `bool?` | Optional | Whether Afterpay/Clearpay is accepted at checkout. |

## Example (as JSON)

```json
{
  "apple_pay": false,
  "google_pay": false,
  "cash_app_pay": false,
  "afterpay_clearpay": false
}
```

