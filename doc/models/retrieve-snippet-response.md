
# Retrieve Snippet Response

Represents a `RetrieveSnippet` response. The response can include either `snippet` or `errors`.

## Structure

`RetrieveSnippetResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Snippet` | [`Models.Snippet`](../../doc/models/snippet.md) | Optional | Represents the snippet that is added to a Square Online site. The snippet code is injected into the `head` element of all pages on the site, except for checkout pages. |

## Example (as JSON)

```json
{
  "snippet": {
    "content": "<script>var js = 1;</script>",
    "created_at": "2021-03-11T25:40:09.000000Z",
    "id": "snippet_5d178150-a6c0-11eb-a9f1-437e6a2881e7",
    "site_id": "site_278075276488921835",
    "updated_at": "2021-03-11T25:40:09.000000Z"
  },
  "errors": [
    {
      "category": "AUTHENTICATION_ERROR",
      "code": "REFUND_ALREADY_PENDING",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "INVALID_REQUEST_ERROR",
      "code": "PAYMENT_NOT_REFUNDABLE",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "RATE_LIMIT_ERROR",
      "code": "REFUND_DECLINED",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

