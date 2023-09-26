
# V1 Payment Tax

V1PaymentTax

## Structure

`V1PaymentTax`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Name` | `string` | Optional | The merchant-defined name of the tax. |
| `AppliedMoney` | [`V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `Rate` | `string` | Optional | The rate of the tax, as a string representation of a decimal number. A value of 0.07 corresponds to a rate of 7%. |
| `InclusionType` | [`string`](../../doc/models/v1-payment-tax-inclusion-type.md) | Optional | - |
| `FeeId` | `string` | Optional | The ID of the tax, if available. Taxes applied in older versions of Square Register might not have an ID. |

## Example (as JSON)

```json
{
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    }
  ],
  "name": "name6",
  "applied_money": {
    "amount": 196,
    "currency_code": "IQD"
  },
  "rate": "rate4",
  "inclusion_type": "ADDITIVE"
}
```

