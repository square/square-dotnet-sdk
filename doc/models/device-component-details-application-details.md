
# Device Component Details Application Details

## Structure

`DeviceComponentDetailsApplicationDetails`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ApplicationType` | [`string`](../../doc/models/application-type.md) | Optional | - |
| `Version` | `string` | Optional | The version of the application. |
| `SessionLocation` | `string` | Optional | The location_id of the session for the application. |
| `DeviceCodeId` | `string` | Optional | The id of the device code that was used to log in to the device. |

## Example (as JSON)

```json
{
  "application_type": "TERMINAL_API",
  "version": "version4",
  "session_location": "session_location0",
  "device_code_id": "device_code_id2"
}
```

