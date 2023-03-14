# Devices

```csharp
IDevicesApi devicesApi = client.DevicesApi;
```

## Class Name

`DevicesApi`

## Methods

* [List Device Codes](../../doc/api/devices.md#list-device-codes)
* [Create Device Code](../../doc/api/devices.md#create-device-code)
* [Get Device Code](../../doc/api/devices.md#get-device-code)


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
    ListDeviceCodesResponse result = await devicesApi.ListDeviceCodesAsync(null, null, null, null);
}
catch (ApiException e){};
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
| `body` | [`Models.CreateDeviceCodeRequest`](../../doc/models/create-device-code-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateDeviceCodeResponse>`](../../doc/models/create-device-code-response.md)

## Example Usage

```csharp
var bodyDeviceCode = new DeviceCode.Builder(
        "TERMINAL_API")
    .Name("Counter 1")
    .LocationId("B5E4484SHHNYH")
    .Build();
var body = new CreateDeviceCodeRequest.Builder(
        "01bb00a6-0c86-4770-94ed-f5fca973cd56",
        bodyDeviceCode)
    .Build();

try
{
    CreateDeviceCodeResponse result = await devicesApi.CreateDeviceCodeAsync(body);
}
catch (ApiException e){};
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
catch (ApiException e){};
```

