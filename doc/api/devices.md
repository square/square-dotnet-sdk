# Devices

```csharp
IDevicesApi devicesApi = client.DevicesApi;
```

## Class Name

`DevicesApi`

## Methods

* [List Devices](../../doc/api/devices.md#list-devices)
* [List Device Codes](../../doc/api/devices.md#list-device-codes)
* [Create Device Code](../../doc/api/devices.md#create-device-code)
* [Get Device Code](../../doc/api/devices.md#get-device-code)
* [Get Device](../../doc/api/devices.md#get-device)


# List Devices

List devices associated with the merchant. Currently, only Terminal API
devices are supported.

```csharp
ListDevicesAsync(
    string cursor = null,
    string sortOrder = null,
    int? limit = null,
    string locationId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | The order in which results are listed.<br><br>- `ASC` - Oldest to newest.<br>- `DESC` - Newest to oldest (default). |
| `limit` | `int?` | Query, Optional | The number of results to return in a single page. |
| `locationId` | `string` | Query, Optional | If present, only returns devices at the target location. |

## Response Type

[`Task<Models.ListDevicesResponse>`](../../doc/models/list-devices-response.md)

## Example Usage

```csharp
try
{
    ListDevicesResponse result = await devicesApi.ListDevicesAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Device Codes

Lists all DeviceCodes associated with the merchant.

```csharp
ListDeviceCodesAsync(
    string cursor = null,
    string locationId = null,
    string productType = null,
    string status = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information. |
| `locationId` | `string` | Query, Optional | If specified, only returns DeviceCodes of the specified location.<br>Returns DeviceCodes of all locations if empty. |
| `productType` | [`string`](../../doc/models/product-type.md) | Query, Optional | If specified, only returns DeviceCodes targeting the specified product type.<br>Returns DeviceCodes of all product types if empty. |
| `status` | [`string`](../../doc/models/device-code-status.md) | Query, Optional | If specified, returns DeviceCodes with the specified statuses.<br>Returns DeviceCodes of status `PAIRED` and `UNPAIRED` if empty. |

## Response Type

[`Task<Models.ListDeviceCodesResponse>`](../../doc/models/list-device-codes-response.md)

## Example Usage

```csharp
try
{
    ListDeviceCodesResponse result = await devicesApi.ListDeviceCodesAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Device Code

Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected
terminal mode.

```csharp
CreateDeviceCodeAsync(
    Models.CreateDeviceCodeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateDeviceCodeRequest`](../../doc/models/create-device-code-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateDeviceCodeResponse>`](../../doc/models/create-device-code-response.md)

## Example Usage

```csharp
Models.CreateDeviceCodeRequest body = new Models.CreateDeviceCodeRequest.Builder(
    "01bb00a6-0c86-4770-94ed-f5fca973cd56",
    new Models.DeviceCode.Builder(
        "TERMINAL_API"
    )
    .Name("Counter 1")
    .LocationId("B5E4484SHHNYH")
    .Build()
)
.Build();

try
{
    CreateDeviceCodeResponse result = await devicesApi.CreateDeviceCodeAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Device Code

Retrieves DeviceCode with the associated ID.

```csharp
GetDeviceCodeAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The unique identifier for the device code. |

## Response Type

[`Task<Models.GetDeviceCodeResponse>`](../../doc/models/get-device-code-response.md)

## Example Usage

```csharp
string id = "id0";
try
{
    GetDeviceCodeResponse result = await devicesApi.GetDeviceCodeAsync(id);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Device

Retrieves Device with the associated `device_id`.

```csharp
GetDeviceAsync(
    string deviceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `deviceId` | `string` | Template, Required | The unique ID for the desired `Device`. |

## Response Type

[`Task<Models.GetDeviceResponse>`](../../doc/models/get-device-response.md)

## Example Usage

```csharp
string deviceId = "device_id6";
try
{
    GetDeviceResponse result = await devicesApi.GetDeviceAsync(deviceId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

