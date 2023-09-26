
# Cash Drawer Shift

This model gives the details of a cash drawer shift.
The cash_payment_money, cash_refund_money, cash_paid_in_money,
and cash_paid_out_money fields are all computed by summing their respective
event types.

## Structure

`CashDrawerShift`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The shift unique ID. |
| `State` | [`string`](../../doc/models/cash-drawer-shift-state.md) | Optional | The current state of a cash drawer shift. |
| `OpenedAt` | `string` | Optional | The time when the shift began, in ISO 8601 format. |
| `EndedAt` | `string` | Optional | The time when the shift ended, in ISO 8601 format. |
| `ClosedAt` | `string` | Optional | The time when the shift was closed, in ISO 8601 format. |
| `Description` | `string` | Optional | The free-form text description of a cash drawer by an employee. |
| `OpenedCashMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashPaymentMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashRefundsMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashPaidInMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `CashPaidOutMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ExpectedCashMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ClosedCashMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `Device` | [`CashDrawerDevice`](../../doc/models/cash-drawer-device.md) | Optional | - |
| `CreatedAt` | `string` | Optional | The shift start time in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The shift updated at time in RFC 3339 format. |
| `LocationId` | `string` | Optional | The ID of the location the cash drawer shift belongs to. |
| `TeamMemberIds` | `IList<string>` | Optional | The IDs of all team members that were logged into Square Point of Sale at any<br>point while the cash drawer shift was open. |
| `OpeningTeamMemberId` | `string` | Optional | The ID of the team member that started the cash drawer shift. |
| `EndingTeamMemberId` | `string` | Optional | The ID of the team member that ended the cash drawer shift. |
| `ClosingTeamMemberId` | `string` | Optional | The ID of the team member that closed the cash drawer shift by auditing<br>the cash drawer contents. |

## Example (as JSON)

```json
{
  "id": "id6",
  "state": "OPEN",
  "opened_at": "opened_at4",
  "ended_at": "ended_at8",
  "closed_at": "closed_at8"
}
```

