
# Dispute Evidence

## Structure

`DisputeEvidence`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EvidenceId` | `string` | Optional | The Square-generated ID of the evidence.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `40` |
| `Id` | `string` | Optional | The Square-generated ID of the evidence.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `40` |
| `DisputeId` | `string` | Optional | The ID of the dispute the evidence is associated with.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `40` |
| `EvidenceFile` | [`Models.DisputeEvidenceFile`](../../doc/models/dispute-evidence-file.md) | Optional | A file to be uploaded as dispute evidence. |
| `EvidenceText` | `string` | Optional | Raw text<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `500` |
| `UploadedAt` | `string` | Optional | The time when the evidence was uploaded, in RFC 3339 format.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `40` |
| `EvidenceType` | [`string`](../../doc/models/dispute-evidence-type.md) | Optional | The type of the dispute evidence. |

## Example (as JSON)

```json
{
  "evidence_id": null,
  "id": null,
  "dispute_id": null,
  "evidence_file": null,
  "evidence_text": null,
  "uploaded_at": null,
  "evidence_type": null
}
```

