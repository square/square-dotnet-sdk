# Customer Groups

```csharp
ICustomerGroupsApi customerGroupsApi = client.CustomerGroupsApi;
```

## Class Name

`CustomerGroupsApi`

## Methods

* [List Customer Groups](../../doc/api/customer-groups.md#list-customer-groups)
* [Create Customer Group](../../doc/api/customer-groups.md#create-customer-group)
* [Delete Customer Group](../../doc/api/customer-groups.md#delete-customer-group)
* [Retrieve Customer Group](../../doc/api/customer-groups.md#retrieve-customer-group)
* [Update Customer Group](../../doc/api/customer-groups.md#update-customer-group)


# List Customer Groups

Retrieves the list of customer groups of a business.

```csharp
ListCustomerGroupsAsync(
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for your original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.<br>If the limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Response Type

[`Task<Models.ListCustomerGroupsResponse>`](../../doc/models/list-customer-groups-response.md)

## Example Usage

```csharp
try
{
    ListCustomerGroupsResponse result = await customerGroupsApi.ListCustomerGroupsAsync(null, null);
}
catch (ApiException e){};
```


# Create Customer Group

Creates a new customer group for a business.

The request must include the `name` value of the group.

```csharp
CreateCustomerGroupAsync(
    Models.CreateCustomerGroupRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateCustomerGroupRequest`](../../doc/models/create-customer-group-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateCustomerGroupResponse>`](../../doc/models/create-customer-group-response.md)

## Example Usage

```csharp
var bodyGroup = new CustomerGroup.Builder(
        "Loyal Customers")
    .Build();
var body = new CreateCustomerGroupRequest.Builder(
        bodyGroup)
    .Build();

try
{
    CreateCustomerGroupResponse result = await customerGroupsApi.CreateCustomerGroupAsync(body);
}
catch (ApiException e){};
```


# Delete Customer Group

Deletes a customer group as identified by the `group_id` value.

```csharp
DeleteCustomerGroupAsync(
    string groupId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `groupId` | `string` | Template, Required | The ID of the customer group to delete. |

## Response Type

[`Task<Models.DeleteCustomerGroupResponse>`](../../doc/models/delete-customer-group-response.md)

## Example Usage

```csharp
string groupId = "group_id0";

try
{
    DeleteCustomerGroupResponse result = await customerGroupsApi.DeleteCustomerGroupAsync(groupId);
}
catch (ApiException e){};
```


# Retrieve Customer Group

Retrieves a specific customer group as identified by the `group_id` value.

```csharp
RetrieveCustomerGroupAsync(
    string groupId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `groupId` | `string` | Template, Required | The ID of the customer group to retrieve. |

## Response Type

[`Task<Models.RetrieveCustomerGroupResponse>`](../../doc/models/retrieve-customer-group-response.md)

## Example Usage

```csharp
string groupId = "group_id0";

try
{
    RetrieveCustomerGroupResponse result = await customerGroupsApi.RetrieveCustomerGroupAsync(groupId);
}
catch (ApiException e){};
```


# Update Customer Group

Updates a customer group as identified by the `group_id` value.

```csharp
UpdateCustomerGroupAsync(
    string groupId,
    Models.UpdateCustomerGroupRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `groupId` | `string` | Template, Required | The ID of the customer group to update. |
| `body` | [`Models.UpdateCustomerGroupRequest`](../../doc/models/update-customer-group-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateCustomerGroupResponse>`](../../doc/models/update-customer-group-response.md)

## Example Usage

```csharp
string groupId = "group_id0";
var bodyGroup = new CustomerGroup.Builder(
        "Loyal Customers")
    .Build();
var body = new UpdateCustomerGroupRequest.Builder(
        bodyGroup)
    .Build();

try
{
    UpdateCustomerGroupResponse result = await customerGroupsApi.UpdateCustomerGroupAsync(groupId, body);
}
catch (ApiException e){};
```

