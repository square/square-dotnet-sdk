
# Terminal Action

Represents an action processed by the Square Terminal.

## Structure

`TerminalAction`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique ID for this `TerminalAction`.<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `255` |
| `DeviceId` | `string` | Optional | The unique Id of the device intended for this `TerminalAction`.<br>The Id can be retrieved from /v2/devices api. |
| `DeadlineDuration` | `string` | Optional | The duration as an RFC 3339 duration, after which the action will be automatically canceled.<br>TerminalActions that are `PENDING` will be automatically `CANCELED` and have a cancellation reason<br>of `TIMED_OUT`<br><br>Default: 5 minutes from creation<br><br>Maximum: 5 minutes |
| `Status` | `string` | Optional | The status of the `TerminalAction`.<br>Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED` |
| `CancelReason` | [`string`](../../doc/models/action-cancel-reason.md) | Optional | - |
| `CreatedAt` | `string` | Optional | The time when the `TerminalAction` was created as an RFC 3339 timestamp. |
| `UpdatedAt` | `string` | Optional | The time when the `TerminalAction` was last updated as an RFC 3339 timestamp. |
| `AppId` | `string` | Optional | The ID of the application that created the action. |
| `Type` | [`string`](../../doc/models/terminal-action-action-type.md) | Optional | Describes the type of this unit and indicates which field contains the unit information. This is an ‘open’ enum. |
| `QrCodeOptions` | [`Models.QrCodeOptions`](../../doc/models/qr-code-options.md) | Optional | Fields to describe the action that displays QR-Codes. |
| `SaveCardOptions` | [`Models.SaveCardOptions`](../../doc/models/save-card-options.md) | Optional | Describes save-card action fields. |
| `SignatureOptions` | [`Models.SignatureOptions`](../../doc/models/signature-options.md) | Optional | - |
| `ConfirmationOptions` | [`Models.ConfirmationOptions`](../../doc/models/confirmation-options.md) | Optional | - |
| `ReceiptOptions` | [`Models.ReceiptOptions`](../../doc/models/receipt-options.md) | Optional | Describes receipt action fields. |
| `DataCollectionOptions` | [`Models.DataCollectionOptions`](../../doc/models/data-collection-options.md) | Optional | - |
| `SelectOptions` | [`Models.SelectOptions`](../../doc/models/select-options.md) | Optional | - |
| `DeviceMetadata` | [`Models.DeviceMetadata`](../../doc/models/device-metadata.md) | Optional | - |
| `AwaitNextAction` | `bool?` | Optional | Indicates the action will be linked to another action and requires a waiting dialog to be<br>displayed instead of returning to the idle screen on completion of the action.<br><br>Only supported on SIGNATURE, CONFIRMATION, DATA_COLLECTION, and SELECT types. |
| `AwaitNextActionDuration` | `string` | Optional | The timeout duration of the waiting dialog as an RFC 3339 duration, after which the<br>waiting dialog will no longer be displayed and the Terminal will return to the idle screen.<br><br>Default: 5 minutes from when the waiting dialog is displayed<br><br>Maximum: 5 minutes |

## Example (as JSON)

```json
{
  "id": "id0",
  "device_id": "device_id6",
  "deadline_duration": "deadline_duration8",
  "status": "status8",
  "cancel_reason": "SELLER_CANCELED"
}
```

