## Shift

A record of the hourly rate, start, and end times for a single work shift
for an employee. May include a record of the start and end times for breaks
taken during the shift.

### Structure

`Shift`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | UUID for this object |
| `EmployeeId` | `string` | Optional | The ID of the employee this shift belongs to. DEPRECATED at version 2020-08-26. Use `team_member_id` instead |
| `LocationId` | `string` | Optional | The ID of the location this shift occurred at. Should be based on<br>where the employee clocked in. |
| `Timezone` | `string` | Optional | Read-only convenience value that is calculated from the location based<br>on `location_id`. Format: the IANA Timezone Database identifier for the<br>location timezone. |
| `StartAt` | `string` |  | RFC 3339; shifted to location timezone + offset. Precision up to the<br>minute is respected; seconds are truncated. |
| `EndAt` | `string` | Optional | RFC 3339; shifted to timezone + offset. Precision up to the minute is<br>respected; seconds are truncated. |
| `Wage` | [`Models.ShiftWage`](/doc/models/shift-wage.md) | Optional | The hourly wage rate used to compensate an employee for this shift. |
| `Breaks` | [`IList<Models.Break>`](/doc/models/break.md) | Optional | A list of any paid or unpaid breaks that were taken during this shift. |
| `Status` | [`string`](/doc/models/shift-status.md) | Optional | Enumerates the possible status of a `Shift` |
| `Version` | `int?` | Optional | Used for resolving concurrency issues; request will fail if version<br>provided does not match server version at time of request. If not provided,<br>Square executes a blind write; potentially overwriting data from another<br>write. |
| `CreatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format; presented in UTC. |
| `UpdatedAt` | `string` | Optional | A read-only timestamp in RFC 3339 format; presented in UTC. |
| `TeamMemberId` | `string` | Optional | The ID of the team member this shift belongs to. Replaced `employee_id` at version "2020-08-26" |

### Example (as JSON)

```json
{
  "id": "id0",
  "employee_id": "employee_id0",
  "location_id": "location_id4",
  "timezone": "timezone0",
  "start_at": "start_at2",
  "end_at": "end_at0"
}
```

