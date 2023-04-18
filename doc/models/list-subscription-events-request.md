
# List Subscription Events Request

Defines input parameters in a request to the
[ListSubscriptionEvents](../../doc/api/subscriptions.md#list-subscription-events)
endpoint.

## Structure

`ListSubscriptionEventsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Cursor` | `string` | Optional | When the total number of resulting subscription events exceeds the limit of a paged response,<br>specify the cursor returned from a preceding response here to fetch the next set of results.<br>If the cursor is unset, the response contains the last page of the results.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `Limit` | `int?` | Optional | The upper limit on the number of subscription events to return<br>in a paged response.<br>**Constraints**: `>= 1` |

## Example (as JSON)

```json
{
  "cursor": "cursor6",
  "limit": 172
}
```

