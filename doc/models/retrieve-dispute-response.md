## Retrieve Dispute Response

Defines fields in a RetrieveDispute response.

### Structure

`RetrieveDisputeResponse`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](/doc/models/error.md) | Optional | Information on errors encountered during the request. |
| `Dispute` | [`Models.Dispute`](/doc/models/dispute.md) | Optional | Represents a dispute a cardholder initiated with their bank. |

### Example (as JSON)

```json
{
  "errors": null,
  "dispute": null
}
```

