# Labor

```csharp
ILaborApi laborApi = client.LaborApi;
```

## Class Name

`LaborApi`

## Methods

* [List Break Types](../../doc/api/labor.md#list-break-types)
* [Create Break Type](../../doc/api/labor.md#create-break-type)
* [Delete Break Type](../../doc/api/labor.md#delete-break-type)
* [Get Break Type](../../doc/api/labor.md#get-break-type)
* [Update Break Type](../../doc/api/labor.md#update-break-type)
* [List Employee Wages](../../doc/api/labor.md#list-employee-wages)
* [Get Employee Wage](../../doc/api/labor.md#get-employee-wage)
* [Create Shift](../../doc/api/labor.md#create-shift)
* [Search Shifts](../../doc/api/labor.md#search-shifts)
* [Delete Shift](../../doc/api/labor.md#delete-shift)
* [Get Shift](../../doc/api/labor.md#get-shift)
* [Update Shift](../../doc/api/labor.md#update-shift)
* [List Team Member Wages](../../doc/api/labor.md#list-team-member-wages)
* [Get Team Member Wage](../../doc/api/labor.md#get-team-member-wage)
* [List Workweek Configs](../../doc/api/labor.md#list-workweek-configs)
* [Update Workweek Config](../../doc/api/labor.md#update-workweek-config)


# List Break Types

Returns a paginated list of `BreakType` instances for a business.

```csharp
ListBreakTypesAsync(
    string locationId = null,
    int? limit = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Optional | Filter the returned `BreakType` results to only those that are associated with the<br>specified location. |
| `limit` | `int?` | Query, Optional | The maximum number of `BreakType` results to return per page. The number can range between 1<br>and 200. The default is 200. |
| `cursor` | `string` | Query, Optional | A pointer to the next page of `BreakType` results to fetch. |

## Response Type

[`Task<Models.ListBreakTypesResponse>`](../../doc/models/list-break-types-response.md)

## Example Usage

```csharp
try
{
    ListBreakTypesResponse result = await laborApi.ListBreakTypesAsync(null, null, null);
}
catch (ApiException e){};
```


# Create Break Type

Creates a new `BreakType`.

A `BreakType` is a template for creating `Break` objects.
You must provide the following values in your request to this
endpoint:

- `location_id`
- `break_name`
- `expected_duration`
- `is_paid`

You can only have three `BreakType` instances per location. If you attempt to add a fourth
`BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
is returned.

```csharp
CreateBreakTypeAsync(
    Models.CreateBreakTypeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateBreakTypeRequest`](../../doc/models/create-break-type-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateBreakTypeResponse>`](../../doc/models/create-break-type-response.md)

## Example Usage

```csharp
var bodyBreakType = new BreakType.Builder(
        "CGJN03P1D08GF",
        "Lunch Break",
        "PT30M",
        true)
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


# Delete Break Type

Deletes an existing `BreakType`.

A `BreakType` can be deleted even if it is referenced from a `Shift`.

```csharp
DeleteBreakTypeAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `BreakType` being deleted. |

## Response Type

[`Task<Models.DeleteBreakTypeResponse>`](../../doc/models/delete-break-type-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    DeleteBreakTypeResponse result = await laborApi.DeleteBreakTypeAsync(id);
}
catch (ApiException e){};
```


# Get Break Type

Returns a single `BreakType` specified by `id`.

```csharp
GetBreakTypeAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `BreakType` being retrieved. |

## Response Type

[`Task<Models.GetBreakTypeResponse>`](../../doc/models/get-break-type-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    GetBreakTypeResponse result = await laborApi.GetBreakTypeAsync(id);
}
catch (ApiException e){};
```


# Update Break Type

Updates an existing `BreakType`.

```csharp
UpdateBreakTypeAsync(
    string id,
    Models.UpdateBreakTypeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `BreakType` being updated. |
| `body` | [`Models.UpdateBreakTypeRequest`](../../doc/models/update-break-type-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateBreakTypeResponse>`](../../doc/models/update-break-type-response.md)

## Example Usage

```csharp
string id = "id0";
var bodyBreakType = new BreakType.Builder(
        "26M7H24AZ9N6R",
        "Lunch",
        "PT50M",
        true)
    .Version(1)
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


# List Employee Wages

**This endpoint is deprecated.**

Returns a paginated list of `EmployeeWage` instances for a business.

```csharp
ListEmployeeWagesAsync(
    string employeeId = null,
    int? limit = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `employeeId` | `string` | Query, Optional | Filter the returned wages to only those that are associated with the specified employee. |
| `limit` | `int?` | Query, Optional | The maximum number of `EmployeeWage` results to return per page. The number can range between<br>1 and 200. The default is 200. |
| `cursor` | `string` | Query, Optional | A pointer to the next page of `EmployeeWage` results to fetch. |

## Response Type

[`Task<Models.ListEmployeeWagesResponse>`](../../doc/models/list-employee-wages-response.md)

## Example Usage

```csharp
try
{
    ListEmployeeWagesResponse result = await laborApi.ListEmployeeWagesAsync(null, null, null);
}
catch (ApiException e){};
```


# Get Employee Wage

**This endpoint is deprecated.**

Returns a single `EmployeeWage` specified by `id`.

```csharp
GetEmployeeWageAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `EmployeeWage` being retrieved. |

## Response Type

[`Task<Models.GetEmployeeWageResponse>`](../../doc/models/get-employee-wage-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    GetEmployeeWageResponse result = await laborApi.GetEmployeeWageAsync(id);
}
catch (ApiException e){};
```


# Create Shift

Creates a new `Shift`.

A `Shift` represents a complete workday for a single employee.
You must provide the following values in your request to this
endpoint:

- `location_id`
- `employee_id`
- `start_at`

An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:

- The `status` of the new `Shift` is `OPEN` and the employee has another
  shift with an `OPEN` status.
- The `start_at` date is in the future.
- The `start_at` or `end_at` date overlaps another shift for the same employee.
- The `Break` instances are set in the request and a break `start_at`
  is before the `Shift.start_at`, a break `end_at` is after
  the `Shift.end_at`, or both.

```csharp
CreateShiftAsync(
    Models.CreateShiftRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateShiftRequest`](../../doc/models/create-shift-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateShiftResponse>`](../../doc/models/create-shift-response.md)

## Example Usage

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
        "2019-01-25T11:11:00+00:00",
        "REGS1EQR1TPZ5",
        "Tea Break",
        "PT5M",
        true)
    .EndAt("2019-01-25T11:16:00+00:00")
    .Build();
bodyShiftBreaks.Add(bodyShiftBreaks0);

var bodyShift = new Shift.Builder(
        "2019-01-25T08:11:00+00:00")
    .LocationId("PAA1RJZZKXBFG")
    .EndAt("2019-01-25T18:11:00+00:00")
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


# Search Shifts

Returns a paginated list of `Shift` records for a business.
The list to be returned can be filtered by:

- Location IDs.
- Employee IDs.
- Shift status (`OPEN` and `CLOSED`).
- Shift start.
- Shift end.
- Workday details.

The list can be sorted by:

- `start_at`.
- `end_at`.
- `created_at`.
- `updated_at`.

```csharp
SearchShiftsAsync(
    Models.SearchShiftsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchShiftsRequest`](../../doc/models/search-shifts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchShiftsResponse>`](../../doc/models/search-shifts-response.md)

## Example Usage

```csharp
var bodyQueryFilterWorkdayDateRange = new DateRange.Builder()
    .StartDate("2019-01-20")
    .EndDate("2019-02-03")
    .Build();
var bodyQueryFilterWorkday = new ShiftWorkday.Builder()
    .DateRange(bodyQueryFilterWorkdayDateRange)
    .MatchShiftsBy("START_AT")
    .DefaultTimezone("America/Los_Angeles")
    .Build();
var bodyQueryFilter = new ShiftFilter.Builder()
    .Workday(bodyQueryFilterWorkday)
    .Build();
var bodyQuery = new ShiftQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchShiftsRequest.Builder()
    .Query(bodyQuery)
    .Limit(100)
    .Build();

try
{
    SearchShiftsResponse result = await laborApi.SearchShiftsAsync(body);
}
catch (ApiException e){};
```


# Delete Shift

Deletes a `Shift`.

```csharp
DeleteShiftAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `Shift` being deleted. |

## Response Type

[`Task<Models.DeleteShiftResponse>`](../../doc/models/delete-shift-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    DeleteShiftResponse result = await laborApi.DeleteShiftAsync(id);
}
catch (ApiException e){};
```


# Get Shift

Returns a single `Shift` specified by `id`.

```csharp
GetShiftAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `Shift` being retrieved. |

## Response Type

[`Task<Models.GetShiftResponse>`](../../doc/models/get-shift-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    GetShiftResponse result = await laborApi.GetShiftAsync(id);
}
catch (ApiException e){};
```


# Update Shift

Updates an existing `Shift`.

When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have
the `end_at` property set to a valid RFC-3339 datetime string.

When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`
set on each `Break`.

```csharp
UpdateShiftAsync(
    string id,
    Models.UpdateShiftRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The ID of the object being updated. |
| `body` | [`Models.UpdateShiftRequest`](../../doc/models/update-shift-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateShiftResponse>`](../../doc/models/update-shift-response.md)

## Example Usage

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
        "2019-01-25T11:11:00+00:00",
        "REGS1EQR1TPZ5",
        "Tea Break",
        "PT5M",
        true)
    .Id("X7GAQYVVRRG6P")
    .EndAt("2019-01-25T11:16:00+00:00")
    .Build();
bodyShiftBreaks.Add(bodyShiftBreaks0);

var bodyShift = new Shift.Builder(
        "2019-01-25T08:11:00+00:00")
    .LocationId("PAA1RJZZKXBFG")
    .EndAt("2019-01-25T18:11:00+00:00")
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


# List Team Member Wages

Returns a paginated list of `TeamMemberWage` instances for a business.

```csharp
ListTeamMemberWagesAsync(
    string teamMemberId = null,
    int? limit = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Query, Optional | Filter the returned wages to only those that are associated with the<br>specified team member. |
| `limit` | `int?` | Query, Optional | The maximum number of `TeamMemberWage` results to return per page. The number can range between<br>1 and 200. The default is 200. |
| `cursor` | `string` | Query, Optional | A pointer to the next page of `EmployeeWage` results to fetch. |

## Response Type

[`Task<Models.ListTeamMemberWagesResponse>`](../../doc/models/list-team-member-wages-response.md)

## Example Usage

```csharp
try
{
    ListTeamMemberWagesResponse result = await laborApi.ListTeamMemberWagesAsync(null, null, null);
}
catch (ApiException e){};
```


# Get Team Member Wage

Returns a single `TeamMemberWage` specified by `id`.

```csharp
GetTeamMemberWageAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `TeamMemberWage` being retrieved. |

## Response Type

[`Task<Models.GetTeamMemberWageResponse>`](../../doc/models/get-team-member-wage-response.md)

## Example Usage

```csharp
string id = "id0";

try
{
    GetTeamMemberWageResponse result = await laborApi.GetTeamMemberWageAsync(id);
}
catch (ApiException e){};
```


# List Workweek Configs

Returns a list of `WorkweekConfig` instances for a business.

```csharp
ListWorkweekConfigsAsync(
    int? limit = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | The maximum number of `WorkweekConfigs` results to return per page. |
| `cursor` | `string` | Query, Optional | A pointer to the next page of `WorkweekConfig` results to fetch. |

## Response Type

[`Task<Models.ListWorkweekConfigsResponse>`](../../doc/models/list-workweek-configs-response.md)

## Example Usage

```csharp
try
{
    ListWorkweekConfigsResponse result = await laborApi.ListWorkweekConfigsAsync(null, null);
}
catch (ApiException e){};
```


# Update Workweek Config

Updates a `WorkweekConfig`.

```csharp
UpdateWorkweekConfigAsync(
    string id,
    Models.UpdateWorkweekConfigRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The UUID for the `WorkweekConfig` object being updated. |
| `body` | [`Models.UpdateWorkweekConfigRequest`](../../doc/models/update-workweek-config-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateWorkweekConfigResponse>`](../../doc/models/update-workweek-config-response.md)

## Example Usage

```csharp
string id = "id0";
var bodyWorkweekConfig = new WorkweekConfig.Builder(
        "MON",
        "10:00")
    .Version(10)
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

