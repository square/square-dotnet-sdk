## V1 Payment Modifier

V1PaymentModifier

### Structure

`V1PaymentModifier`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Optional | The modifier option's name. |
| `AppliedMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `ModifierOptionId` | `string` | Optional | TThe ID of the applied modifier option, if available. Modifier options applied in older versions of Square Register might not have an ID. |

### Example (as JSON)

```json
{
  "name": null,
  "applied_money": null,
  "modifier_option_id": null
}
```

