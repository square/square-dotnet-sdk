
# List Dispute Evidence Response

Defines the fields in a `ListDisputeEvidence` response.

## Structure

`ListDisputeEvidenceResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Evidence` | [`IList<DisputeEvidence>`](../../doc/models/dispute-evidence.md) | Optional | The list of evidence previously uploaded to the specified dispute. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Information about errors encountered during the request. |
| `Cursor` | `string` | Optional | The pagination cursor to be used in a subsequent request.<br>If unset, this is the final response. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Example (as JSON)

```json
{
  "evidence": [
    {
      "evidence_id": "evidence_id0",
      "id": "id2",
      "dispute_id": "dispute_id4",
      "evidence_file": {
        "filename": "filename8",
        "filetype": "filetype8"
      },
      "evidence_text": "evidence_text6"
    }
  ],
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    }
  ],
  "cursor": "cursor6"
}
```

