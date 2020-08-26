# Labor

```csharp
ILaborApi laborApi = client.LaborApi;
```

## Class Name

`LaborApi`

## Methods

* [List Break Types](/doc/labor.md#list-break-types)
* [Create Break Type](/doc/labor.md#create-break-type)
* [Delete Break Type](/doc/labor.md#delete-break-type)
* [Get Break Type](/doc/labor.md#get-break-type)
* [Update Break Type](/doc/labor.md#update-break-type)
* [List Employee Wages](/doc/labor.md#list-employee-wages)
* [Get Employee Wage](/doc/labor.md#get-employee-wage)
* [Create Shift](/doc/labor.md#create-shift)
* [Search Shifts](/doc/labor.md#search-shifts)
* [Delete Shift](/doc/labor.md#delete-shift)
* [Get Shift](/doc/labor.md#get-shift)
* [Update Shift](/doc/labor.md#update-shift)
* [List Team Member Wages](/doc/labor.md#list-team-member-wages)
* [Get Team Member Wage](/doc/labor.md#get-team-member-wage)
* [List Workweek Configs](/doc/labor.md#list-workweek-configs)
* [Update Workweek Config](/doc/labor.md#update-workweek-config)

## List Break Types

Returns a paginated list of `BreakType` instances for a business.

```csharp
ListBreakTypesAsync(string locationId = null, int? limit = null, string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Optional | Filter Break Types returned to only those that are associated with the<br>specified location. |
| `limit` | `int?` | Query, Optional | Maximum number of Break Types to return per page. Can range between 1<br>and 200. The default is the maximum at 200. |
| `cursor` | `string` | Query, Optional | Pointer to the next page of Break Type results to fetch. |

### Response Type

[`Task<Models.ListBreakTypesResponse>`](/doc/models/list-break-types-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
int? limit = 172;
string cursor = "cursor6";

try
{
    ListBreakTypesResponse result = await laborApi.ListBreakTypesAsync(locationId, limit, cursor);
}
catch (ApiException e){};
```

## Create Break Type

Creates a new `BreakType`.

A `BreakType` is a template for creating `Break` objects.
You must provide the following values in your request to this
endpoint:

- `location_id`
- `break_name`
- `expected_duration`
- `is_paid`

You can only have 3 `BreakType` instances per location. If you attempt to add a 4th
`BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
is returned.

```csharp
CreateBreakTypeAsync(Models.CreateBreakTypeRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateBreakTypeRequest`](/doc/models/create-break-type-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateBreakTypeResponse>`](/doc/models/create-break-type-response.md)

### Example Usage

```csharp
var bodyBreakType = new BreakType.Builder(
        "CGJN03P1D08GF",
        "Lunch Break",
        "PT30M",
        true)
    .Id("id2")
    .Version(124)
    .CreatedAt("created_at0")
    .UpdatedAt("updated_at8")
    .Build();
var body = new CreateBreakTypeRequest.Builder(
        bodyBreakType)
    .IdempotencyKey("PAD3NG5KSN2GL")
    .Build();

try
{
    CreateBreakTypeResponse result = await laborApi.CreateBreakTypeAsync(body);
}
catch (ApiException e){};
```

## Delete Break Type

Deletes an existing `BreakType`.

A `BreakType` can be deleted even if it is referenced from a `Shift`.

```csharp
DeleteBreakTypeAsync(string id)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `BreakType` being deleted. |

### Response Type

[`Task<Models.DeleteBreakTypeResponse>`](/doc/models/delete-break-type-response.md)

### Example Usage

```csharp
string id = "id0";

try
{
    DeleteBreakTypeResponse result = await laborApi.DeleteBreakTypeAsync(id);
}
catch (ApiException e){};
```

## Get Break Type

Returns a single `BreakType` specified by id.

```csharp
GetBreakTypeAsync(string id)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `BreakType` being retrieved. |

### Response Type

[`Task<Models.GetBreakTypeResponse>`](/doc/models/get-break-type-response.md)

### Example Usage

```csharp
string id = "id0";

try
{
    GetBreakTypeResponse result = await laborApi.GetBreakTypeAsync(id);
}
catch (ApiException e){};
```

## Update Break Type

Updates an existing `BreakType`.

```csharp
UpdateBreakTypeAsync(string id, Models.UpdateBreakTypeRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `BreakType` being updated. |
| `body` | [`Models.UpdateBreakTypeRequest`](/doc/models/update-break-type-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateBreakTypeResponse>`](/doc/models/update-break-type-response.md)

### Example Usage

```csharp
string id = "id0";
var bodyBreakType = new BreakType.Builder(
        "26M7H24AZ9N6R",
        "Lunch",
        "PT50M",
        true)
    .Id("id2")
    .Version(1)
    .CreatedAt("created_at0")
    .UpdatedAt("updated_at8")
    .Build();
var body = new UpdateBreakTypeRequest.Builder(
        bodyBreakType)
    .Build();

try
{
    UpdateBreakTypeResponse result = await laborApi.UpdateBreakTypeAsync(id, body);
}
catch (ApiException e){};
```

## List Employee Wages

Returns a paginated list of `EmployeeWage` instances for a business.

```csharp
ListEmployeeWagesAsync(string employeeId = null, int? limit = null, string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `employeeId` | `string` | Query, Optional | Filter wages returned to only those that are associated with the specified employee. |
| `limit` | `int?` | Query, Optional | Maximum number of Employee Wages to return per page. Can range between<br>1 and 200. The default is the maximum at 200. |
| `cursor` | `string` | Query, Optional | Pointer to the next page of Employee Wage results to fetch. |

### Response Type

[`Task<Models.ListEmployeeWagesResponse>`](/doc/models/list-employee-wages-response.md)

### Example Usage

```csharp
string employeeId = "employee_id0";
int? limit = 172;
string cursor = "cursor6";

try
{
    ListEmployeeWagesResponse result = await laborApi.ListEmployeeWagesAsync(employeeId, limit, cursor);
}
catch (ApiException e){};
```

## Get Employee Wage

Returns a single `EmployeeWage` specified by id.

```csharp
GetEmployeeWageAsync(string id)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `EmployeeWage` being retrieved. |

### Response Type

[`Task<Models.GetEmployeeWageResponse>`](/doc/models/get-employee-wage-response.md)

### Example Usage

```csharp
string id = "id0";

try
{
    GetEmployeeWageResponse result = await laborApi.GetEmployeeWageAsync(id);
}
catch (ApiException e){};
```

## Create Shift

Creates a new `Shift`.

A `Shift` represents a complete work day for a single employee.
You must provide the following values in your request to this
endpoint:

- `location_id`
- `employee_id`
- `start_at`

An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
- The `status` of the new `Shift` is `OPEN` and the employee has another
shift with an `OPEN` status.
- The `start_at` date is in the future
- the `start_at` or `end_at` overlaps another shift for the same employee
- If `Break`s are set in the request, a break `start_at`
must not be before the `Shift.start_at`. A break `end_at` must not be after
the `Shift.end_at`

```csharp
CreateShiftAsync(Models.CreateShiftRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateShiftRequest`](/doc/models/create-shift-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateShiftResponse>`](/doc/models/create-shift-response.md)

### Example Usage

```csharp
var bodyShiftWageHourlyRate = new Money.Builder()
    .Amount(1100L)
    .Currency("USD")
    .Build();
var bodyShiftWage = new ShiftWage.Builder()
    .Title("Barista")
    .HourlyRate(bodyShiftWageHourlyRate)
    .Build();
var bodyShiftBreaks = new List<Break>();

var bodyShiftBreaks0 = new Break.Builder(
        "2019-01-25T06:11:00-05:00",
        "REGS1EQR1TPZ5",
        "Tea Break",
        "PT5M",
        true)
    .Id("id4")
    .EndAt("2019-01-25T06:16:00-05:00")
    .Build();
bodyShiftBreaks.Add(bodyShiftBreaks0);

var bodyShift = new Shift.Builder(
        "2019-01-25T03:11:00-05:00")
    .Id("id8")
    .EmployeeId("employee_id2")
    .LocationId("PAA1RJZZKXBFG")
    .Timezone("timezone2")
    .EndAt("2019-01-25T13:11:00-05:00")
    .Wage(bodyShiftWage)
    .Breaks(bodyShiftBreaks)
    .TeamMemberId("ormj0jJJZ5OZIzxrZYJI")
    .Build();
var body = new CreateShiftRequest.Builder(
        bodyShift)
    .IdempotencyKey("HIDSNG5KS478L")
    .Build();

try
{
    CreateShiftResponse result = await laborApi.CreateShiftAsync(body);
}
catch (ApiException e){};
```

## Search Shifts

Returns a paginated list of `Shift` records for a business.
The list to be returned can be filtered by:
- Location IDs **and**
- employee IDs **and**
- shift status (`OPEN`, `CLOSED`) **and**
- shift start **and**
- shift end **and**
- work day details

The list can be sorted by:
- `start_at`
- `end_at`
- `created_at`
- `updated_at`

```csharp
SearchShiftsAsync(Models.SearchShiftsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchShiftsRequest`](/doc/models/search-shifts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchShiftsResponse>`](/doc/models/search-shifts-response.md)

### Example Usage

```csharp
var bodyQueryFilterLocationIds = new List<string>();
bodyQueryFilterLocationIds.Add("location_ids2");
var bodyQueryFilterTeamMemberIds = new List<string>();
bodyQueryFilterTeamMemberIds.Add("team_member_ids9");
bodyQueryFilterTeamMemberIds.Add("team_member_ids0");
var bodyQueryFilterEmployeeIds = new List<string>();
bodyQueryFilterEmployeeIds.Add("employee_ids7");
var bodyQueryFilterStart = new TimeRange.Builder()
    .StartAt("start_at8")
    .EndAt("end_at4")
    .Build();
var bodyQueryFilterEnd = new TimeRange.Builder()
    .StartAt("start_at2")
    .EndAt("end_at0")
    .Build();
var bodyQueryFilterWorkdayDateRange = new DateRange.Builder()
    .StartDate("start_date8")
    .EndDate("end_date4")
    .Build();
var bodyQueryFilterWorkday = new ShiftWorkday.Builder()
    .DateRange(bodyQueryFilterWorkdayDateRange)
    .MatchShiftsBy("START_AT")
    .DefaultTimezone("default_timezone8")
    .Build();
var bodyQueryFilter = new ShiftFilter.Builder(
        bodyQueryFilterLocationIds,
        bodyQueryFilterTeamMemberIds)
    .EmployeeIds(bodyQueryFilterEmployeeIds)
    .Status("OPEN")
    .Start(bodyQueryFilterStart)
    .End(bodyQueryFilterEnd)
    .Workday(bodyQueryFilterWorkday)
    .Build();
var bodyQuerySort = new ShiftSort.Builder()
    .Field("CREATED_AT")
    .Order("DESC")
    .Build();
var bodyQuery = new ShiftQuery.Builder()
    .Filter(bodyQueryFilter)
    .Sort(bodyQuerySort)
    .Build();
var body = new SearchShiftsRequest.Builder()
    .Query(bodyQuery)
    .Limit(164)
    .Cursor("cursor0")
    .Build();

try
{
    SearchShiftsResponse result = await laborApi.SearchShiftsAsync(body);
}
catch (ApiException e){};
```

## Delete Shift

Deletes a `Shift`.

```csharp
DeleteShiftAsync(string id)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `Shift` being deleted. |

### Response Type

[`Task<Models.DeleteShiftResponse>`](/doc/models/delete-shift-response.md)

### Example Usage

```csharp
string id = "id0";

try
{
    DeleteShiftResponse result = await laborApi.DeleteShiftAsync(id);
}
catch (ApiException e){};
```

## Get Shift

Returns a single `Shift` specified by id.

```csharp
GetShiftAsync(string id)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `Shift` being retrieved. |

### Response Type

[`Task<Models.GetShiftResponse>`](/doc/models/get-shift-response.md)

### Example Usage

```csharp
string id = "id0";

try
{
    GetShiftResponse result = await laborApi.GetShiftAsync(id);
}
catch (ApiException e){};
```

## Update Shift

Updates an existing `Shift`.

When adding a `Break` to a `Shift`, any earlier `Breaks` in the `Shift` have
the `end_at` property set to a valid RFC-3339 datetime string.

When closing a `Shift`, all `Break` instances in the shift must be complete with `end_at`
set on each `Break`.

```csharp
UpdateShiftAsync(string id, Models.UpdateShiftRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | ID of the object being updated. |
| `body` | [`Models.UpdateShiftRequest`](/doc/models/update-shift-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateShiftResponse>`](/doc/models/update-shift-response.md)

### Example Usage

```csharp
string id = "id0";
var bodyShiftWageHourlyRate = new Money.Builder()
    .Amount(1500L)
    .Currency("USD")
    .Build();
var bodyShiftWage = new ShiftWage.Builder()
    .Title("Bartender")
    .HourlyRate(bodyShiftWageHourlyRate)
    .Build();
var bodyShiftBreaks = new List<Break>();

var bodyShiftBreaks0 = new Break.Builder(
        "2019-01-25T06:11:00-05:00",
        "REGS1EQR1TPZ5",
        "Tea Break",
        "PT5M",
        true)
    .Id("X7GAQYVVRRG6P")
    .EndAt("2019-01-25T06:16:00-05:00")
    .Build();
bodyShiftBreaks.Add(bodyShiftBreaks0);

var bodyShift = new Shift.Builder(
        "2019-01-25T03:11:00-05:00")
    .Id("id8")
    .EmployeeId("employee_id2")
    .LocationId("PAA1RJZZKXBFG")
    .Timezone("timezone2")
    .EndAt("2019-01-25T13:11:00-05:00")
    .Wage(bodyShiftWage)
    .Breaks(bodyShiftBreaks)
    .Version(1)
    .TeamMemberId("ormj0jJJZ5OZIzxrZYJI")
    .Build();
var body = new UpdateShiftRequest.Builder(
        bodyShift)
    .Build();

try
{
    UpdateShiftResponse result = await laborApi.UpdateShiftAsync(id, body);
}
catch (ApiException e){};
```

## List Team Member Wages

Returns a paginated list of `TeamMemberWage` instances for a business.

```csharp
ListTeamMemberWagesAsync(string teamMemberId = null, int? limit = null, string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Query, Optional | Filter wages returned to only those that are associated with the<br>specified team member. |
| `limit` | `int?` | Query, Optional | Maximum number of Team Member Wages to return per page. Can range between<br>1 and 200. The default is the maximum at 200. |
| `cursor` | `string` | Query, Optional | Pointer to the next page of Employee Wage results to fetch. |

### Response Type

[`Task<Models.ListTeamMemberWagesResponse>`](/doc/models/list-team-member-wages-response.md)

### Example Usage

```csharp
string teamMemberId = "team_member_id0";
int? limit = 172;
string cursor = "cursor6";

try
{
    ListTeamMemberWagesResponse result = await laborApi.ListTeamMemberWagesAsync(teamMemberId, limit, cursor);
}
catch (ApiException e){};
```

## Get Team Member Wage

Returns a single `TeamMemberWage` specified by id.

```csharp
GetTeamMemberWageAsync(string id)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `TeamMemberWage` being retrieved. |

### Response Type

[`Task<Models.GetTeamMemberWageResponse>`](/doc/models/get-team-member-wage-response.md)

### Example Usage

```csharp
string id = "id0";

try
{
    GetTeamMemberWageResponse result = await laborApi.GetTeamMemberWageAsync(id);
}
catch (ApiException e){};
```

## List Workweek Configs

Returns a list of `WorkweekConfig` instances for a business.

```csharp
ListWorkweekConfigsAsync(int? limit = null, string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | Maximum number of Workweek Configs to return per page. |
| `cursor` | `string` | Query, Optional | Pointer to the next page of Workweek Config results to fetch. |

### Response Type

[`Task<Models.ListWorkweekConfigsResponse>`](/doc/models/list-workweek-configs-response.md)

### Example Usage

```csharp
int? limit = 172;
string cursor = "cursor6";

try
{
    ListWorkweekConfigsResponse result = await laborApi.ListWorkweekConfigsAsync(limit, cursor);
}
catch (ApiException e){};
```

## Update Workweek Config

Updates a `WorkweekConfig`.

```csharp
UpdateWorkweekConfigAsync(string id, Models.UpdateWorkweekConfigRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the `WorkweekConfig` object being updated. |
| `body` | [`Models.UpdateWorkweekConfigRequest`](/doc/models/update-workweek-config-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateWorkweekConfigResponse>`](/doc/models/update-workweek-config-response.md)

### Example Usage

```csharp
string id = "id0";
var bodyWorkweekConfig = new WorkweekConfig.Builder(
        "MON",
        "10:00")
    .Id("id4")
    .Version(10)
    .CreatedAt("created_at2")
    .UpdatedAt("updated_at0")
    .Build();
var body = new UpdateWorkweekConfigRequest.Builder(
        bodyWorkweekConfig)
    .Build();

try
{
    UpdateWorkweekConfigResponse result = await laborApi.UpdateWorkweekConfigAsync(id, body);
}
catch (ApiException e){};
```

