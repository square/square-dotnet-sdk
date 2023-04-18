
# Deprecated Create Dispute Evidence File Request

Defines the parameters for a `DeprecatedCreateDisputeEvidenceFile` request.

## Structure

`DeprecatedCreateDisputeEvidenceFileRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` | Required | The Unique ID. For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `45` |
| `EvidenceType` | [`string`](../../doc/models/dispute-evidence-type.md) | Optional | The type of the dispute evidence. |
| `ContentType` | `string` | Optional | The MIME type of the uploaded file.<br>The type can be image/heic, image/heif, image/jpeg, application/pdf, image/png, or image/tiff.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `40` |

## Example (as JSON)

```json
{
  "idempotency_key": "idempotency_key6",
  "evidence_type": "RECEIPT",
  "content_type": "content_type6"
}
```

