
# List Invoices Request

Describes a `ListInvoice` request.

## Structure

`ListInvoicesRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Required | The ID of the location for which to list invoices.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `255` |
| `Cursor` | `string` | Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for your original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `Limit` | `int?` | Optional | The maximum number of invoices to return (200 is the maximum `limit`).<br>If not provided, the server uses a default limit of 100 invoices. |

## Example (as JSON)

```json
{
  "location_id": "location_id4",
  "cursor": "cursor6",
  "limit": 172
}
```

