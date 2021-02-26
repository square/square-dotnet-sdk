# V1 Employees

```csharp
IV1EmployeesApi v1EmployeesApi = client.V1EmployeesApi;
```

## Class Name

`V1EmployeesApi`

## Methods

* [List Employees](/doc/api/v1-employees.md#list-employees)
* [Create Employee](/doc/api/v1-employees.md#create-employee)
* [Retrieve Employee](/doc/api/v1-employees.md#retrieve-employee)
* [Update Employee](/doc/api/v1-employees.md#update-employee)
* [List Employee Roles](/doc/api/v1-employees.md#list-employee-roles)
* [Create Employee Role](/doc/api/v1-employees.md#create-employee-role)
* [Retrieve Employee Role](/doc/api/v1-employees.md#retrieve-employee-role)
* [Update Employee Role](/doc/api/v1-employees.md#update-employee-role)


# List Employees

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

## Parameters

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

## Response Type

[`Task<List<Models.V1Employee>>`](/doc/models/v1-employee.md)

## Example Usage

```csharp
string order = "DESC";
string beginUpdatedAt = "begin_updated_at6";
string endUpdatedAt = "end_updated_at4";
string beginCreatedAt = "begin_created_at6";
string endCreatedAt = "end_created_at8";
string status = "ACTIVE";
string externalId = "external_id6";
int? limit = 172;
string batchToken = "batch_token2";

try
{
    List<V1Employee> result = await v1EmployeesApi.ListEmployeesAsync(order, beginUpdatedAt, endUpdatedAt, beginCreatedAt, endCreatedAt, status, externalId, limit, batchToken);
}
catch (ApiException e){};
```


# Create Employee

Use the CreateEmployee endpoint to add an employee to a Square
account. Employees created with the Connect API have an initial status
of `INACTIVE`. Inactive employees cannot sign in to Square Point of Sale
until they are activated from the Square Dashboard. Employee status
cannot be changed with the Connect API.

Employee entities cannot be deleted. To disable employee profiles,
set the employee's status to <code>INACTIVE</code>

```csharp
CreateEmployeeAsync(Models.V1Employee body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1Employee`](/doc/models/v1-employee.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.V1Employee>`](/doc/models/v1-employee.md)

## Example Usage

```csharp
var bodyRoleIds = new List<string>();
bodyRoleIds.Add("role_ids0");
bodyRoleIds.Add("role_ids1");
var bodyAuthorizedLocationIds = new List<string>();
bodyAuthorizedLocationIds.Add("authorized_location_ids7");
bodyAuthorizedLocationIds.Add("authorized_location_ids8");
var body = new V1Employee.Builder(
        "first_name6",
        "last_name4")
    .Id("id6")
    .RoleIds(bodyRoleIds)
    .AuthorizedLocationIds(bodyAuthorizedLocationIds)
    .Email("email0")
    .Status("ACTIVE")
    .Build();

try
{
    V1Employee result = await v1EmployeesApi.CreateEmployeeAsync(body);
}
catch (ApiException e){};
```


# Retrieve Employee

Provides the details for a single employee.

```csharp
RetrieveEmployeeAsync(string employeeId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `employeeId` | `string` | Template, Required | The employee's ID. |

## Response Type

[`Task<Models.V1Employee>`](/doc/models/v1-employee.md)

## Example Usage

```csharp
string employeeId = "employee_id0";

try
{
    V1Employee result = await v1EmployeesApi.RetrieveEmployeeAsync(employeeId);
}
catch (ApiException e){};
```


# Update Employee

UpdateEmployee

```csharp
UpdateEmployeeAsync(string employeeId, Models.V1Employee body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `employeeId` | `string` | Template, Required | The ID of the role to modify. |
| `body` | [`Models.V1Employee`](/doc/models/v1-employee.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.V1Employee>`](/doc/models/v1-employee.md)

## Example Usage

```csharp
string employeeId = "employee_id0";
var bodyRoleIds = new List<string>();
bodyRoleIds.Add("role_ids0");
bodyRoleIds.Add("role_ids1");
var bodyAuthorizedLocationIds = new List<string>();
bodyAuthorizedLocationIds.Add("authorized_location_ids7");
bodyAuthorizedLocationIds.Add("authorized_location_ids8");
var body = new V1Employee.Builder(
        "first_name6",
        "last_name4")
    .Id("id6")
    .RoleIds(bodyRoleIds)
    .AuthorizedLocationIds(bodyAuthorizedLocationIds)
    .Email("email0")
    .Status("ACTIVE")
    .Build();

try
{
    V1Employee result = await v1EmployeesApi.UpdateEmployeeAsync(employeeId, body);
}
catch (ApiException e){};
```


# List Employee Roles

Provides summary information for all of a business's employee roles.

```csharp
ListEmployeeRolesAsync(string order = null, int? limit = null, string batchToken = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which employees are listed in the response, based on their created_at field.Default value: ASC |
| `limit` | `int?` | Query, Optional | The maximum integer number of employee entities to return in a single response. Default 100, maximum 200. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

## Response Type

[`Task<List<Models.V1EmployeeRole>>`](/doc/models/v1-employee-role.md)

## Example Usage

```csharp
string order = "DESC";
int? limit = 172;
string batchToken = "batch_token2";

try
{
    List<V1EmployeeRole> result = await v1EmployeesApi.ListEmployeeRolesAsync(order, limit, batchToken);
}
catch (ApiException e){};
```


# Create Employee Role

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

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.V1EmployeeRole`](/doc/models/v1-employee-role.md) | Body, Required | An EmployeeRole object with a name and permissions, and an optional owner flag. |

## Response Type

[`Task<Models.V1EmployeeRole>`](/doc/models/v1-employee-role.md)

## Example Usage

```csharp
var bodyPermissions = new List<string>();
bodyPermissions.Add("REGISTER_APPLY_RESTRICTED_DISCOUNTS");
bodyPermissions.Add("REGISTER_CHANGE_SETTINGS");
bodyPermissions.Add("REGISTER_EDIT_ITEM");
var body = new V1EmployeeRole.Builder(
        "name6",
        bodyPermissions)
    .Id("id6")
    .IsOwner(false)
    .CreatedAt("created_at4")
    .UpdatedAt("updated_at8")
    .Build();

try
{
    V1EmployeeRole result = await v1EmployeesApi.CreateEmployeeRoleAsync(body);
}
catch (ApiException e){};
```


# Retrieve Employee Role

Provides the details for a single employee role.

```csharp
RetrieveEmployeeRoleAsync(string roleId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `roleId` | `string` | Template, Required | The role's ID. |

## Response Type

[`Task<Models.V1EmployeeRole>`](/doc/models/v1-employee-role.md)

## Example Usage

```csharp
string roleId = "role_id6";

try
{
    V1EmployeeRole result = await v1EmployeesApi.RetrieveEmployeeRoleAsync(roleId);
}
catch (ApiException e){};
```


# Update Employee Role

Modifies the details of an employee role.

```csharp
UpdateEmployeeRoleAsync(string roleId, Models.V1EmployeeRole body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `roleId` | `string` | Template, Required | The ID of the role to modify. |
| `body` | [`Models.V1EmployeeRole`](/doc/models/v1-employee-role.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.V1EmployeeRole>`](/doc/models/v1-employee-role.md)

## Example Usage

```csharp
string roleId = "role_id6";
var bodyPermissions = new List<string>();
bodyPermissions.Add("REGISTER_APPLY_RESTRICTED_DISCOUNTS");
bodyPermissions.Add("REGISTER_CHANGE_SETTINGS");
bodyPermissions.Add("REGISTER_EDIT_ITEM");
var body = new V1EmployeeRole.Builder(
        "name6",
        bodyPermissions)
    .Id("id6")
    .IsOwner(false)
    .CreatedAt("created_at4")
    .UpdatedAt("updated_at8")
    .Build();

try
{
    V1EmployeeRole result = await v1EmployeesApi.UpdateEmployeeRoleAsync(roleId, body);
}
catch (ApiException e){};
```

