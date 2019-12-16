## V1 Timecard Event Event Type

Actions that resulted in a change to a timecard. All timecard
events created with the Connect API have an event type that begins with
`API`.

### Enumeration

`V1TimecardEventEventType`

### Fields

| Name | Description |
|  --- | --- |
| `APICREATE` | The timecard was created by a request to the<br>[CreateTimecard](#endpoint-v1employees-createtimecard) endpoint. |
| `APIEDIT` | The timecard was edited by a request to the<br>[UpdateTimecard](#endpoint-v1employees-updatetimecard) endpoint. |
| `APIDELETE` | The timecard was deleted by a request to the<br>[DeleteTimecard](#endpoint-v1employees-deletetimecard) endpoint. |
| `REGISTERCLOCKIN` | The employee clocked in via Square Point of Sale. |
| `REGISTERCLOCKOUT` | The employee clocked out via Square Point of Sale. |
| `DASHBOARDSUPERVISORCLOSE` | A supervisor clocked out the employee from the merchant<br>dashboard. |
| `DASHBOARDEDIT` | A supervisor manually edited the timecard from the merchant<br>dashboard |
| `DASHBOARDDELETE` | A supervisor deleted the timecard from the merchant dashboard. |

