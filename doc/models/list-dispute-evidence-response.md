
# List Dispute Evidence Response

Defines the fields in a `ListDisputeEvidence` response.

## Structure

`ListDisputeEvidenceResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Evidence` | [`IList<Models.DisputeEvidence>`](../../doc/models/dispute-evidence.md) | Optional | The list of evidence previously uploaded to the specified dispute. |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Information about errors encountered during the request. |
| `Cursor` | `string` | Optional | The pagination cursor to be used in a subsequent request.<br>If unset, this is the final response. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Example (as JSON)

```json
{
  "evidence": null,
  "errors": null,
  "cursor": null
}
```

