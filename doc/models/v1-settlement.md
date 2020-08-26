## V1 Settlement

V1Settlement

### Structure

`V1Settlement`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The settlement's unique identifier. |
| `Status` | [`string`](/doc/models/v1-settlement-status.md) | Optional | - |
| `TotalMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `InitiatedAt` | `string` | Optional | The time when the settlement was submitted for deposit or withdrawal, in ISO 8601 format. |
| `BankAccountId` | `string` | Optional | The Square-issued unique identifier for the bank account associated with the settlement. |
| `Entries` | [`IList<Models.V1SettlementEntry>`](/doc/models/v1-settlement-entry.md) | Optional | The entries included in this settlement. |

### Example (as JSON)

```json
{
  "id": "id0",
  "status": "FAILED",
  "total_money": {
    "amount": 250,
    "currency_code": "USS"
  },
  "initiated_at": "initiated_at2",
  "bank_account_id": "bank_account_id0"
}
```

