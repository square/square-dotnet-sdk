
# Checkout Location Settings Policy

## Structure

`CheckoutLocationSettingsPolicy`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Uid` | `string` | Optional | A unique ID to identify the policy when making changes. You must set the UID for policy updates, but it’s optional when setting new policies. |
| `Title` | `string` | Optional | The title of the policy. This is required when setting the description, though you can update it in a different request.<br>**Constraints**: *Maximum Length*: `50` |
| `Description` | `string` | Optional | The description of the policy.<br>**Constraints**: *Maximum Length*: `4096` |

## Example (as JSON)

```json
{
  "uid": "uid0",
  "title": "title6",
  "description": "description0"
}
```

