
# Create Terminal Action Response

## Structure

`CreateTerminalActionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Information on errors encountered during the request. |
| `Action` | [`TerminalAction`](../../doc/models/terminal-action.md) | Optional | Represents an action processed by the Square Terminal. |

## Example (as JSON)

```json
{
  "action": {
    "app_id": "APP_ID",
    "created_at": "2021-07-28T23:22:07.476Z",
    "deadline_duration": "PT5M",
    "device_id": "DEVICE_ID",
    "id": "termapia:jveJIAkkAjILHkdCE",
    "location_id": "LOCATION_ID",
    "save_card_options": {
      "customer_id": "CUSTOMER_ID",
      "reference_id": "user-id-1"
    },
    "status": "PENDING",
    "type": "SAVE_CARD",
    "updated_at": "2021-07-28T23:22:07.476Z",
    "cancel_reason": "TIMED_OUT"
  },
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

