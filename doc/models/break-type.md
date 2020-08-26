## Break Type

A defined break template that sets an expectation for possible `Break`
instances on a `Shift`.

### Structure

`BreakType`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | UUID for this object. |
| `LocationId` | `string` |  | The ID of the business location this type of break applies to. |
| `BreakName` | `string` |  | A human-readable name for this type of break. Will be displayed to<br>employees in Square products. |
| `ExpectedDuration` | `string` |  | Format: RFC-3339 P[n]Y[n]M[n]DT[n]H[n]M[n]S. The expected length of<br>this break. Precision below minutes is truncated. |
| `IsPaid` | `bool` |  | Whether this break counts towards time worked for compensation<br>purposes. |
| `Version` | `int?` | Optional | Used for resolving concurrency issues; request will fail if version<br>provided does not match server version at time of request. If a value is not<br>provided, Square's servers execute a "blind" write; potentially<br>overwriting another writer's data. |
| `CreatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format. |

### Example (as JSON)

```json
{
  "id": "id0",
  "location_id": "location_id4",
  "break_name": "break_name8",
  "expected_duration": "expected_duration4",
  "is_paid": false,
  "version": 172,
  "created_at": "created_at2",
  "updated_at": "updated_at4"
}
```

