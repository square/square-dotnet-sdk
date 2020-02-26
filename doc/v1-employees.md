# V1 Employees

```csharp
IV1EmployeesApi v1EmployeesApi = client.V1EmployeesApi;
```

## Class Name

`V1EmployeesApi`

## Methods

* [List Employees](/doc/v1-employees.md#list-employees)
* [Create Employee](/doc/v1-employees.md#create-employee)
* [Retrieve Employee](/doc/v1-employees.md#retrieve-employee)
* [Update Employee](/doc/v1-employees.md#update-employee)
* [List Employee Roles](/doc/v1-employees.md#list-employee-roles)
* [Create Employee Role](/doc/v1-employees.md#create-employee-role)
* [Retrieve Employee Role](/doc/v1-employees.md#retrieve-employee-role)
* [Update Employee Role](/doc/v1-employees.md#update-employee-role)
* [List Timecards](/doc/v1-employees.md#list-timecards)
* [Create Timecard](/doc/v1-employees.md#create-timecard)
* [Delete Timecard](/doc/v1-employees.md#delete-timecard)
* [Retrieve Timecard](/doc/v1-employees.md#retrieve-timecard)
* [Update Timecard](/doc/v1-employees.md#update-timecard)
* [List Timecard Events](/doc/v1-employees.md#list-timecard-events)
* [List Cash Drawer Shifts](/doc/v1-employees.md#list-cash-drawer-shifts)
* [Retrieve Cash Drawer Shift](/doc/v1-employees.md#retrieve-cash-drawer-shift)

## List Employees

Provides summary information for all of a business's employees.

```csharp
ListEmployeesAsync(
    string order = null,
    string beginUpdatedAt = null,
    string endUpdatedAt = null,
    string beginCreatedAt = null,
    string endCreatedAt = null,
    string status = null,
    string externalId = null,
    int? limit = null,
    string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which employees are listed in the response, based on their created_at field.      Default value: ASC |
| `beginUpdatedAt` | `string` | Query, Optional | If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format |
| `endUpdatedAt` | `string` | Query, Optional | If filtering results by there updated_at field, the end of the requested reporting period, in ISO 8601 format. |
| `beginCreatedAt` | `string` | Query, Optional | If filtering results by their created_at field, the beginning of the requested reporting period, in ISO 8601 format. |
| `endCreatedAt` | `string` | Query, Optional | If filtering results by their created_at field, the end of the requested reporting period, in ISO 8601 format. |
| `status` | [`string`](/doc/models/v1-list-employees-request-status.md) | Query, Optional | If provided, the endpoint returns only employee entities with the specified status (ACTIVE or INACTIVE). |
| `externalId` | `string` | Query, Optional | If provided, the endpoint returns only employee entities with the specified external_id. |
| `limit` | `int?` | Query, Optional | The maximum integer number of employee entities to return in a single response. Default 100, maximum 200. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1Employee>>`](/doc/models/v1-employee.md)

### Example Usage

```csharp
try
{
    List<V1Employee> result = await v1EmployeesApi.ListEmployeesAsync(null, null, null, null, null, null, null, null, null);
}
catch (ApiException e){};
```

## Create Employee

Use the CreateEmployee endpoint to add an employee to a Square
account. Employees created with the Connect API have an initial status
of `INACTIVE`. Inactive employees cannot sign in to Square Point of Sale
until they are activated from the Square Dashboard. Employee status
cannot be changed with the Connect API.

<aside class="important">
Employee entities cannot be deleted. To disable employee profiles,
set the employee's status to <code>INACTIVE</code>
</aside>

```csharp
CreateEmployeeAsync(Models.V1Employee body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1Employee`](/doc/models/v1-employee.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Employee>`](/doc/models/v1-employee.md)

### Example Usage

```csharp
var body = new V1Employee.Builder(
        "first_name6",
        "last_name4")
    .Build();

try
{
    V1Employee result = await v1EmployeesApi.CreateEmployeeAsync(body);
}
catch (ApiException e){};
```

## Retrieve Employee

Provides the details for a single employee.

```csharp
RetrieveEmployeeAsync(string employeeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `employeeId` | `string` | Template, Required | The employee's ID. |

### Response Type

[`Task<Models.V1Employee>`](/doc/models/v1-employee.md)

### Example Usage

```csharp
string employeeId = "employee_id0";

try
{
    V1Employee result = await v1EmployeesApi.RetrieveEmployeeAsync(employeeId);
}
catch (ApiException e){};
```

## Update Employee

UpdateEmployee

```csharp
UpdateEmployeeAsync(string employeeId, Models.V1Employee body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `employeeId` | `string` | Template, Required | The ID of the role to modify. |
| `body` | [`Models.V1Employee`](/doc/models/v1-employee.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Employee>`](/doc/models/v1-employee.md)

### Example Usage

```csharp
string employeeId = "employee_id0";
var body = new V1Employee.Builder(
        "first_name6",
        "last_name4")
    .Build();

try
{
    V1Employee result = await v1EmployeesApi.UpdateEmployeeAsync(employeeId, body);
}
catch (ApiException e){};
```

## List Employee Roles

Provides summary information for all of a business's employee roles.

```csharp
ListEmployeeRolesAsync(string order = null, int? limit = null, string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which employees are listed in the response, based on their created_at field.Default value: ASC |
| `limit` | `int?` | Query, Optional | The maximum integer number of employee entities to return in a single response. Default 100, maximum 200. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1EmployeeRole>>`](/doc/models/v1-employee-role.md)

### Example Usage

```csharp
try
{
    List<V1EmployeeRole> result = await v1EmployeesApi.ListEmployeeRolesAsync(null, null, null);
}
catch (ApiException e){};
```

## Create Employee Role

Creates an employee role you can then assign to employees.

Square accounts can include any number of roles that can be assigned to
employees. These roles define the actions and permissions granted to an
employee with that role. For example, an employee with a "Shift Manager"
role might be able to issue refunds in Square Point of Sale, whereas an
employee with a "Clerk" role might not.

Roles are assigned with the [V1UpdateEmployee](#endpoint-v1updateemployee)
endpoint. An employee can have only one role at a time.

If an employee has no role, they have none of the permissions associated
with roles. All employees can accept payments with Square Point of Sale.

```csharp
CreateEmployeeRoleAsync(Models.V1EmployeeRole body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1EmployeeRole`](/doc/models/v1-employee-role.md) | Body, Required | An EmployeeRole object with a name and permissions, and an optional owner flag. |

### Response Type

[`Task<Models.V1EmployeeRole>`](/doc/models/v1-employee-role.md)

### Example Usage

```csharp
var bodyPermissions = new List<string>();
bodyPermissions.Add("REGISTER_APPLY_RESTRICTED_DISCOUNTS");
bodyPermissions.Add("REGISTER_CHANGE_SETTINGS");
bodyPermissions.Add("REGISTER_EDIT_ITEM");
var body = new V1EmployeeRole.Builder(
        "name6",
        bodyPermissions)
    .Build();

try
{
    V1EmployeeRole result = await v1EmployeesApi.CreateEmployeeRoleAsync(body);
}
catch (ApiException e){};
```

## Retrieve Employee Role

Provides the details for a single employee role.

```csharp
RetrieveEmployeeRoleAsync(string roleId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `roleId` | `string` | Template, Required | The role's ID. |

### Response Type

[`Task<Models.V1EmployeeRole>`](/doc/models/v1-employee-role.md)

### Example Usage

```csharp
string roleId = "role_id6";

try
{
    V1EmployeeRole result = await v1EmployeesApi.RetrieveEmployeeRoleAsync(roleId);
}
catch (ApiException e){};
```

## Update Employee Role

Modifies the details of an employee role.

```csharp
UpdateEmployeeRoleAsync(string roleId, Models.V1EmployeeRole body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `roleId` | `string` | Template, Required | The ID of the role to modify. |
| `body` | [`Models.V1EmployeeRole`](/doc/models/v1-employee-role.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1EmployeeRole>`](/doc/models/v1-employee-role.md)

### Example Usage

```csharp
string roleId = "role_id6";
var bodyPermissions = new List<string>();
bodyPermissions.Add("REGISTER_APPLY_RESTRICTED_DISCOUNTS");
bodyPermissions.Add("REGISTER_CHANGE_SETTINGS");
bodyPermissions.Add("REGISTER_EDIT_ITEM");
var body = new V1EmployeeRole.Builder(
        "name6",
        bodyPermissions)
    .Build();

try
{
    V1EmployeeRole result = await v1EmployeesApi.UpdateEmployeeRoleAsync(roleId, body);
}
catch (ApiException e){};
```

## List Timecards

Provides summary information for all of a business's employee timecards.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-timecards)

---

```csharp
ListTimecardsAsync(
    string order = null,
    string employeeId = null,
    string beginClockinTime = null,
    string endClockinTime = null,
    string beginClockoutTime = null,
    string endClockoutTime = null,
    string beginUpdatedAt = null,
    string endUpdatedAt = null,
    bool? deleted = null,
    int? limit = null,
    string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which timecards are listed in the response, based on their created_at field. |
| `employeeId` | `string` | Query, Optional | If provided, the endpoint returns only timecards for the employee with the specified ID. |
| `beginClockinTime` | `string` | Query, Optional | If filtering results by their clockin_time field, the beginning of the requested reporting period, in ISO 8601 format. |
| `endClockinTime` | `string` | Query, Optional | If filtering results by their clockin_time field, the end of the requested reporting period, in ISO 8601 format. |
| `beginClockoutTime` | `string` | Query, Optional | If filtering results by their clockout_time field, the beginning of the requested reporting period, in ISO 8601 format. |
| `endClockoutTime` | `string` | Query, Optional | If filtering results by their clockout_time field, the end of the requested reporting period, in ISO 8601 format. |
| `beginUpdatedAt` | `string` | Query, Optional | If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format. |
| `endUpdatedAt` | `string` | Query, Optional | If filtering results by their updated_at field, the end of the requested reporting period, in ISO 8601 format. |
| `deleted` | `bool?` | Query, Optional | If true, only deleted timecards are returned. If false, only valid timecards are returned.If you don't provide this parameter, both valid and deleted timecards are returned. |
| `limit` | `int?` | Query, Optional | The maximum integer number of employee entities to return in a single response. Default 100, maximum 200. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1Timecard>>`](/doc/models/v1-timecard.md)

### Example Usage

```csharp
try
{
    List<V1Timecard> result = await v1EmployeesApi.ListTimecardsAsync(null, null, null, null, null, null, null, null, null, null, null);
}
catch (ApiException e){};
```

## Create Timecard

Creates a timecard for an employee and clocks them in with an
`API_CREATE` event and a `clockin_time` set to the current time unless
the request provides a different value.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-timecards)

---


To import timecards from another
system (rather than clocking someone in). Specify the `clockin_time`
and* `clockout_time` in the request.

Timecards correspond to exactly one shift for a given employee, bounded
by the `clockin_time` and `clockout_time` fields. An employee is
considered clocked in if they have a timecard that doesn't have a
`clockout_time` set. An employee that is currently clocked in cannot
be clocked in a second time.

```csharp
CreateTimecardAsync(Models.V1Timecard body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1Timecard`](/doc/models/v1-timecard.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Timecard>`](/doc/models/v1-timecard.md)

### Example Usage

```csharp
var body = new V1Timecard.Builder(
        "employee_id4")
    .Build();

try
{
    V1Timecard result = await v1EmployeesApi.CreateTimecardAsync(body);
}
catch (ApiException e){};
```

## Delete Timecard

Deletes a timecard. Timecards can also be deleted through the
Square Dashboard. Deleted timecards are still accessible through
Connect API endpoints, but cannot be modified. The `deleted` field of
the `Timecard` object indicates whether the timecard has been deleted.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-timecards)

---

*Note**: By default, deleted timecards appear alongside valid timecards in
results returned by the [ListTimecards](#endpoint-v1employees-listtimecards)
endpoint. To filter deleted timecards, include the `deleted` query
parameter in the list request.

<aside>
Only approved accounts can manage their employees with Square.
Unapproved accounts cannot use employee management features with the
API.
</aside>

```csharp
DeleteTimecardAsync(string timecardId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `timecardId` | `string` | Template, Required | The ID of the timecard to delete. |

### Response Type

`Task<object>`

### Example Usage

```csharp
string timecardId = "timecard_id0";

try
{
    object result = await v1EmployeesApi.DeleteTimecardAsync(timecardId);
}
catch (ApiException e){};
```

## Retrieve Timecard

Provides the details for a single timecard.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-timecards)

---

<aside>
Only approved accounts can manage their employees with Square.
Unapproved accounts cannot use employee management features with the
API.
</aside>

```csharp
RetrieveTimecardAsync(string timecardId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `timecardId` | `string` | Template, Required | The timecard's ID. |

### Response Type

[`Task<Models.V1Timecard>`](/doc/models/v1-timecard.md)

### Example Usage

```csharp
string timecardId = "timecard_id0";

try
{
    V1Timecard result = await v1EmployeesApi.RetrieveTimecardAsync(timecardId);
}
catch (ApiException e){};
```

## Update Timecard

Modifies the details of a timecard with an `API_EDIT` event for
the timecard. Updating an active timecard with a `clockout_time`
clocks the employee out.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-timecards)

---

```csharp
UpdateTimecardAsync(string timecardId, Models.V1Timecard body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `timecardId` | `string` | Template, Required | TThe ID of the timecard to modify. |
| `body` | [`Models.V1Timecard`](/doc/models/v1-timecard.md) | Body, Required | An object containing the fields to POST for the request.<br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Timecard>`](/doc/models/v1-timecard.md)

### Example Usage

```csharp
string timecardId = "timecard_id0";
var body = new V1Timecard.Builder(
        "employee_id4")
    .Build();

try
{
    V1Timecard result = await v1EmployeesApi.UpdateTimecardAsync(timecardId, body);
}
catch (ApiException e){};
```

## List Timecard Events

Provides summary information for all events associated with a
particular timecard.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-timecards)

---

<aside>
Only approved accounts can manage their employees with Square.
Unapproved accounts cannot use employee management features with the
API.
</aside>

```csharp
ListTimecardEventsAsync(string timecardId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `timecardId` | `string` | Template, Required | The ID of the timecard to list events for. |

### Response Type

[`Task<List<Models.V1TimecardEvent>>`](/doc/models/v1-timecard-event.md)

### Example Usage

```csharp
string timecardId = "timecard_id0";

try
{
    List<V1TimecardEvent> result = await v1EmployeesApi.ListTimecardEventsAsync(timecardId);
}
catch (ApiException e){};
```

## List Cash Drawer Shifts

Provides the details for all of a location's cash drawer shifts during a date range. The date range you specify cannot exceed 90 days.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-cashdrawershifts)

---

```csharp
ListCashDrawerShiftsAsync(
    string locationId,
    string order = null,
    string beginTime = null,
    string endTime = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list cash drawer shifts for. |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which cash drawer shifts are listed in the response, based on their created_at field. Default value: ASC |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time minus 90 days. |
| `endTime` | `string` | Query, Optional | The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time. |

### Response Type

[`Task<List<Models.V1CashDrawerShift>>`](/doc/models/v1-cash-drawer-shift.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    List<V1CashDrawerShift> result = await v1EmployeesApi.ListCashDrawerShiftsAsync(locationId, null, null, null);
}
catch (ApiException e){};
```

## Retrieve Cash Drawer Shift

Provides the details for a single cash drawer shift, including all events that occurred during the shift.

---

- __Deprecation date__: 2020-02-26
- [__Retirement date__](https://developer.squareup.com/docs/docs/build-basics/api-lifecycle#deprecated): 2021-02-26
- [Migration guide](https://developer.squareup.com/docs/docs/migrate-from-v1/guides/v1-cashdrawershifts)

---

```csharp
RetrieveCashDrawerShiftAsync(string locationId, string shiftId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list cash drawer shifts for. |
| `shiftId` | `string` | Template, Required | The shift's ID. |

### Response Type

[`Task<Models.V1CashDrawerShift>`](/doc/models/v1-cash-drawer-shift.md)

### Example Usage

```csharp
string locationId = "location_id4";
string shiftId = "shift_id0";

try
{
    V1CashDrawerShift result = await v1EmployeesApi.RetrieveCashDrawerShiftAsync(locationId, shiftId);
}
catch (ApiException e){};
```

