
# Deprecated Create Dispute Evidence Text Response

Defines the fields in a `DeprecatedCreateDisputeEvidenceText` response.

## Structure

`DeprecatedCreateDisputeEvidenceTextResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Evidence` | [`DisputeEvidence`](../../doc/models/dispute-evidence.md) | Optional | - |

## Example (as JSON)

```json
{
  "evidence": {
    "dispute_id": "bVTprrwk0gygTLZ96VX1oB",
    "evidence_text": "The customer purchased the item twice, on April 11 and April 28.",
    "evidence_type": "REBUTTAL_EXPLANATION",
    "id": "TOomLInj6iWmP3N8qfCXrB",
    "uploaded_at": "2022-05-18T16:01:10.000Z",
    "evidence_id": "evidence_id0",
    "evidence_file": {
      "filename": "filename8",
      "filetype": "filetype8"
    }
  },
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

