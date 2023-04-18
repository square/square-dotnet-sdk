
# List Gift Cards Request

A request to list gift cards. You can optionally specify a filter to retrieve a subset of
gift cards.

## Structure

`ListGiftCardsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Optional | If a [type](entity:GiftCardType) is provided, the endpoint returns gift cards of the specified type.<br>Otherwise, the endpoint returns gift cards of all types. |
| `State` | `string` | Optional | If a [state](entity:GiftCardStatus) is provided, the endpoint returns the gift cards in the specified state.<br>Otherwise, the endpoint returns the gift cards of all states. |
| `Limit` | `int?` | Optional | If a limit is provided, the endpoint returns only the specified number of results per page.<br>The maximum value is 50. The default value is 30.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).<br>**Constraints**: `>= 1`, `<= 50` |
| `Cursor` | `string` | Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>If a cursor is not provided, the endpoint returns the first page of the results.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `CustomerId` | `string` | Optional | If a customer ID is provided, the endpoint returns only the gift cards linked to the specified customer.<br>**Constraints**: *Maximum Length*: `191` |

## Example (as JSON)

```json
{
  "type": "type0",
  "state": "state4",
  "limit": 172,
  "cursor": "cursor6",
  "customer_id": "customer_id8"
}
```

