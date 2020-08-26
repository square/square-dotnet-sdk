## V1 Timecard

Represents a timecard for an employee.

### Structure

`V1Timecard`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The timecard's unique ID. |
| `EmployeeId` | `string` |  | The ID of the employee the timecard is associated with. |
| `Deleted` | `bool?` | Optional | If true, the timecard was deleted by the merchant, and it is no longer valid. |
| `ClockinTime` | `string` | Optional | The clock-in time for the timecard, in ISO 8601 format. |
| `ClockoutTime` | `string` | Optional | The clock-out time for the timecard, in ISO 8601 format. Provide this value only if importing timecard information from another system. |
| `ClockinLocationId` | `string` | Optional | The ID of the location the employee clocked in from. We strongly reccomend providing a clockin_location_id. Square uses the clockin_location_id to determine a timecard’s timezone and overtime rules. |
| `ClockoutLocationId` | `string` | Optional | The ID of the location the employee clocked out from. Provide this value only if importing timecard information from another system. |
| `CreatedAt` | `string` | Optional | The time when the timecard was created, in ISO 8601 format. |
| `UpdatedAt` | `string` | Optional | The time when the timecard was most recently updated, in ISO 8601 format. |
| `RegularSecondsWorked` | `double?` | Optional | The total number of regular (non-overtime) seconds worked in the timecard. |
| `OvertimeSecondsWorked` | `double?` | Optional | The total number of overtime seconds worked in the timecard. |
| `DoubletimeSecondsWorked` | `double?` | Optional | The total number of doubletime seconds worked in the timecard. |

### Example (as JSON)

```json
{
  "id": "id0",
  "employee_id": "employee_id0",
  "deleted": false,
  "clockin_time": "clockin_time6",
  "clockout_time": "clockout_time4",
  "clockin_location_id": "clockin_location_id8"
}
```

