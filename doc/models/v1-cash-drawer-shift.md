## V1 Cash Drawer Shift

Contains details for a single cash drawer shift.

### Structure

`V1CashDrawerShift`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The shift's unique ID. |
| `EventType` | [`string`](/doc/models/v1-cash-drawer-shift-event-type.md) | Optional | - |
| `OpenedAt` | `string` | Optional | The time when the shift began, in ISO 8601 format. |
| `EndedAt` | `string` | Optional | The time when the shift ended, in ISO 8601 format. |
| `ClosedAt` | `string` | Optional | The time when the shift was closed, in ISO 8601 format. |
| `EmployeeIds` | `IList<string>` | Optional | The IDs of all employees that were logged into Square Register at some point during the cash drawer shift. |
| `OpeningEmployeeId` | `string` | Optional | The ID of the employee that started the cash drawer shift. |
| `EndingEmployeeId` | `string` | Optional | The ID of the employee that ended the cash drawer shift. |
| `ClosingEmployeeId` | `string` | Optional | The ID of the employee that closed the cash drawer shift by auditing the cash drawer's contents. |
| `Description` | `string` | Optional | A description of the cash drawer shift. |
| `StartingCashMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `CashPaymentMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `CashRefundsMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `CashPaidInMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `CashPaidOutMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `ExpectedCashMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `ClosedCashMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `Device` | [`Models.Device`](/doc/models/device.md) | Optional | - |
| `Events` | [`IList<Models.V1CashDrawerEvent>`](/doc/models/v1-cash-drawer-event.md) | Optional | All of the events (payments, refunds, and so on) that involved the cash drawer during the shift. |

### Example (as JSON)

```json
{
  "id": "id0",
  "event_type": "ENDED",
  "opened_at": "opened_at8",
  "ended_at": "ended_at2",
  "closed_at": "closed_at2"
}
```

