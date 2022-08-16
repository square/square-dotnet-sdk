
# Search Terminal Actions Response

## Structure

`SearchTerminalActionsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Information on errors encountered during the request. |
| `Action` | [`IList<Models.TerminalAction>`](../../doc/models/terminal-action.md) | Optional | The requested search result of `TerminalAction`s. |
| `Cursor` | `string` | Optional | The pagination cursor to be used in a subsequent request. If empty,<br>this is the final response.<br><br>See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more<br>information. |

## Example (as JSON)

```json
{
  "action": [
    {
      "app_id": "APP_ID",
      "created_at": "2022-04-08T15:14:04.895Z",
      "deadline_duration": "PT5M",
      "device_id": "DEVICE_ID",
      "id": "termapia:oBGWlAats8xWCiCE",
      "location_id": "LOCATION_ID",
      "save_card_options": {
        "customer_id": "CUSTOMER_ID",
        "reference_id": "user-id-1"
      },
      "status": "IN_PROGRESS",
      "type": "SAVE_CARD",
      "updated_at": "2022-04-08T15:14:05.446Z"
    },
    {
      "app_id": "APP_ID",
      "created_at": "2022-04-08T15:14:01.210Z",
      "deadline_duration": "PT5M",
      "device_id": "DEVICE_ID",
      "id": "termapia:K2NY2YSSml3lTiCE",
      "location_id": "LOCATION_ID",
      "save_card_options": {
        "card_id": "ccof:CARD_ID",
        "customer_id": "CUSTOMER_ID",
        "reference_id": "user-id-1"
      },
      "status": "COMPLETED",
      "type": "SAVE_CARD",
      "updated_at": "2022-04-08T15:14:09.861Z"
    }
  ],
  "cursor": "CURSOR"
}
```

