
# Dispute Evidence Created Webhook Data

## Structure

`DisputeEvidenceCreatedWebhookData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | `string` | Optional | Name of the affected dispute's type. |
| `Id` | `string` | Optional | ID of the affected dispute. |
| `MObject` | [`Models.DisputeEvidenceCreatedWebhookObject`](../../doc/models/dispute-evidence-created-webhook-object.md) | Optional | - |

## Example (as JSON)

```json
{
  "type": "type0",
  "id": "id0",
  "object": {
    "object": {
      "dispute_id": "dispute_id2",
      "id": "id0",
      "amount_money": {
        "amount": 186,
        "currency": "NGN"
      },
      "reason": "NOT_AS_DESCRIBED",
      "state": "PROCESSING"
    }
  }
}
```

