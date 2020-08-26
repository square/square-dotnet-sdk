## Dispute Evidence

### Structure

`DisputeEvidence`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `EvidenceId` | `string` | Optional | The Square-generated ID of the evidence. |
| `DisputeId` | `string` | Optional | The ID of the dispute the evidence is associated with. |
| `UploadedAt` | `string` | Optional | The time when the next action is due, in RFC 3339 format. |
| `EvidenceType` | [`string`](/doc/models/dispute-evidence-type.md) | Optional | Type of the dispute evidence. |

### Example (as JSON)

```json
{
  "evidence_id": "evidence_id2",
  "dispute_id": "dispute_id2",
  "uploaded_at": "uploaded_at4",
  "evidence_type": "RECEIPT"
}
```

