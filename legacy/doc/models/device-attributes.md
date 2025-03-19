
# Device Attributes

## Structure

`DeviceAttributes`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Required, Constant | An enum identifier of the device type.<br>**Default**: `"TERMINAL"` |
| `Manufacturer` | `string` | Required | The maker of the device. |
| `Model` | `string` | Optional | The specific model of the device. |
| `Name` | `string` | Optional | A seller-specified name for the device. |
| `ManufacturersId` | `string` | Optional | The manufacturer-supplied identifier for the device (where available). In many cases,<br>this identifier will be a serial number. |
| `UpdatedAt` | `string` | Optional | The RFC 3339-formatted value of the most recent update to the device information.<br>(Could represent any field update on the device.) |
| `Version` | `string` | Optional | The current version of software installed on the device. |
| `MerchantToken` | `string` | Optional | The merchant_token identifying the merchant controlling the device. |

## Example (as JSON)

```json
{
  "type": "TERMINAL",
  "manufacturer": "manufacturer0",
  "model": "model4",
  "name": "name6",
  "manufacturers_id": "manufacturers_id2",
  "updated_at": "updated_at2",
  "version": "version2"
}
```

