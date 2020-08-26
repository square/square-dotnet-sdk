## Cash Drawer Shift

This model gives the details of a cash drawer shift.
The cash_payment_money, cash_refund_money, cash_paid_in_money,
and cash_paid_out_money fields are all computed by summing their respective
event types.

### Structure

`CashDrawerShift`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The shift unique ID. |
| `State` | [`string`](/doc/models/cash-drawer-shift-state.md) | Optional | The current state of a cash drawer shift. |
| `OpenedAt` | `string` | Optional | The time when the shift began, in ISO 8601 format. |
| `EndedAt` | `string` | Optional | The time when the shift ended, in ISO 8601 format. |
| `ClosedAt` | `string` | Optional | The time when the shift was closed, in ISO 8601 format. |
| `EmployeeIds` | `IList<string>` | Optional | The IDs of all employees that were logged into Square Point of Sale at any<br>point while the cash drawer shift was open. |
| `OpeningEmployeeId` | `string` | Optional | The ID of the employee that started the cash drawer shift. |
| `EndingEmployeeId` | `string` | Optional | The ID of the employee that ended the cash drawer shift. |
| `ClosingEmployeeId` | `string` | Optional | The ID of the employee that closed the cash drawer shift by auditing<br>the cash drawer contents. |
| `Description` | `string` | Optional | The free-form text description of a cash drawer by an employee. |
| `OpenedCashMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashPaymentMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashRefundsMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashPaidInMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashPaidOutMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ExpectedCashMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ClosedCashMoney` | [`Models.Money`](/doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `Device` | [`Models.CashDrawerDevice`](/doc/models/cash-drawer-device.md) | Optional | - |

### Example (as JSON)

```json
{
  "id": "id0",
  "state": "CLOSED",
  "opened_at": "opened_at8",
  "ended_at": "ended_at2",
  "closed_at": "closed_at2"
}
```

