
# Device Details

Details about the device that took the payment.

## Structure

`DeviceDetails`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DeviceId` | `string` | Optional | The Square-issued ID of the device.<br>**Constraints**: *Maximum Length*: `255` |
| `DeviceInstallationId` | `string` | Optional | The Square-issued installation ID for the device.<br>**Constraints**: *Maximum Length*: `255` |
| `DeviceName` | `string` | Optional | The name of the device set by the seller.<br>**Constraints**: *Maximum Length*: `255` |

## Example (as JSON)

```json
{
  "device_id": "device_id6",
  "device_installation_id": "device_installation_id8",
  "device_name": "device_name2"
}
```

