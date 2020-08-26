# Employees

```csharp
IEmployeesApi employeesApi = client.EmployeesApi;
```

## Class Name

`EmployeesApi`

## Methods

* [List Employees](/doc/employees.md#list-employees)
* [Retrieve Employee](/doc/employees.md#retrieve-employee)

## List Employees

ListEmployees

```csharp
ListEmployeesAsync(
    string locationId = null,
    string status = null,
    int? limit = null,
    string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Optional | - |
| `status` | [`string`](/doc/models/employee-status.md) | Query, Optional | Specifies the EmployeeStatus to filter the employee by. |
| `limit` | `int?` | Query, Optional | The number of employees to be returned on each page. |
| `cursor` | `string` | Query, Optional | The token required to retrieve the specified page of results. |

### Response Type

[`Task<Models.ListEmployeesResponse>`](/doc/models/list-employees-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string status = "ACTIVE";
int? limit = 172;
string cursor = "cursor6";

try
{
    ListEmployeesResponse result = await employeesApi.ListEmployeesAsync(locationId, status, limit, cursor);
}
catch (ApiException e){};
```

## Retrieve Employee

RetrieveEmployee

```csharp
RetrieveEmployeeAsync(string id)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | UUID for the employee that was requested. |

### Response Type

[`Task<Models.RetrieveEmployeeResponse>`](/doc/models/retrieve-employee-response.md)

### Example Usage

```csharp
string id = "id0";

try
{
    RetrieveEmployeeResponse result = await employeesApi.RetrieveEmployeeAsync(id);
}
catch (ApiException e){};
```

