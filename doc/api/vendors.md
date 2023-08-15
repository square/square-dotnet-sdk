# Vendors

```csharp
IVendorsApi vendorsApi = client.VendorsApi;
```

## Class Name

`VendorsApi`

## Methods

* [Bulk Create Vendors](../../doc/api/vendors.md#bulk-create-vendors)
* [Bulk Retrieve Vendors](../../doc/api/vendors.md#bulk-retrieve-vendors)
* [Bulk Update Vendors](../../doc/api/vendors.md#bulk-update-vendors)
* [Create Vendor](../../doc/api/vendors.md#create-vendor)
* [Search Vendors](../../doc/api/vendors.md#search-vendors)
* [Retrieve Vendor](../../doc/api/vendors.md#retrieve-vendor)
* [Update Vendor](../../doc/api/vendors.md#update-vendor)


# Bulk Create Vendors

Creates one or more [Vendor](../../doc/models/vendor.md) objects to represent suppliers to a seller.

```csharp
BulkCreateVendorsAsync(
    Models.BulkCreateVendorsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkCreateVendorsRequest`](../../doc/models/bulk-create-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkCreateVendorsResponse>`](../../doc/models/bulk-create-vendors-response.md)

## Example Usage

```csharp
Models.BulkCreateVendorsRequest body = new Models.BulkCreateVendorsRequest.Builder(
    new Dictionary<string, Models.Vendor>
    {
        ["key0"] = new Models.Vendor.Builder()
        .Build(),
        ["key1"] = new Models.Vendor.Builder()
        .Build(),
    }
)
.Build();

try
{
    BulkCreateVendorsResponse result = await vendorsApi.BulkCreateVendorsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Retrieve Vendors

Retrieves one or more vendors of specified [Vendor](../../doc/models/vendor.md) IDs.

```csharp
BulkRetrieveVendorsAsync(
    Models.BulkRetrieveVendorsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkRetrieveVendorsRequest`](../../doc/models/bulk-retrieve-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkRetrieveVendorsResponse>`](../../doc/models/bulk-retrieve-vendors-response.md)

## Example Usage

```csharp
Models.BulkRetrieveVendorsRequest body = new Models.BulkRetrieveVendorsRequest.Builder()
.VendorIds(
    new List<string>
    {
        "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
    })
.Build();

try
{
    BulkRetrieveVendorsResponse result = await vendorsApi.BulkRetrieveVendorsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Update Vendors

Updates one or more of existing [Vendor](../../doc/models/vendor.md) objects as suppliers to a seller.

```csharp
BulkUpdateVendorsAsync(
    Models.BulkUpdateVendorsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkUpdateVendorsRequest`](../../doc/models/bulk-update-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpdateVendorsResponse>`](../../doc/models/bulk-update-vendors-response.md)

## Example Usage

```csharp
Models.BulkUpdateVendorsRequest body = new Models.BulkUpdateVendorsRequest.Builder(
    new Dictionary<string, Models.UpdateVendorRequest>
    {
        ["key0"] = new Models.UpdateVendorRequest.Builder(
            new Models.Vendor.Builder()
            .Build()
        )
        .Build(),
        ["key1"] = new Models.UpdateVendorRequest.Builder(
            new Models.Vendor.Builder()
            .Build()
        )
        .Build(),
    }
)
.Build();

try
{
    BulkUpdateVendorsResponse result = await vendorsApi.BulkUpdateVendorsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Vendor

Creates a single [Vendor](../../doc/models/vendor.md) object to represent a supplier to a seller.

```csharp
CreateVendorAsync(
    Models.CreateVendorRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateVendorRequest`](../../doc/models/create-vendor-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateVendorResponse>`](../../doc/models/create-vendor-response.md)

## Example Usage

```csharp
Models.CreateVendorRequest body = new Models.CreateVendorRequest.Builder(
    "idempotency_key2"
)
.Build();

try
{
    CreateVendorResponse result = await vendorsApi.CreateVendorAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Search Vendors

Searches for vendors using a filter against supported [Vendor](../../doc/models/vendor.md) properties and a supported sorter.

```csharp
SearchVendorsAsync(
    Models.SearchVendorsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SearchVendorsRequest`](../../doc/models/search-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchVendorsResponse>`](../../doc/models/search-vendors-response.md)

## Example Usage

```csharp
Models.SearchVendorsRequest body = new Models.SearchVendorsRequest.Builder()
.Build();

try
{
    SearchVendorsResponse result = await vendorsApi.SearchVendorsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Vendor

Retrieves the vendor of a specified [Vendor](../../doc/models/vendor.md) ID.

```csharp
RetrieveVendorAsync(
    string vendorId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `vendorId` | `string` | Template, Required | ID of the [Vendor](entity:Vendor) to retrieve. |

## Response Type

[`Task<Models.RetrieveVendorResponse>`](../../doc/models/retrieve-vendor-response.md)

## Example Usage

```csharp
string vendorId = "vendor_id8";
try
{
    RetrieveVendorResponse result = await vendorsApi.RetrieveVendorAsync(vendorId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Vendor

Updates an existing [Vendor](../../doc/models/vendor.md) object as a supplier to a seller.

```csharp
UpdateVendorAsync(
    Models.UpdateVendorRequest body,
    string vendorId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`UpdateVendorRequest`](../../doc/models/update-vendor-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |
| `vendorId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.UpdateVendorResponse>`](../../doc/models/update-vendor-response.md)

## Example Usage

```csharp
Models.UpdateVendorRequest body = new Models.UpdateVendorRequest.Builder(
    new Models.Vendor.Builder()
    .Id("INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4")
    .Name("Jack's Chicken Shack")
    .Version(1)
    .Status("ACTIVE")
    .Build()
)
.IdempotencyKey("8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe")
.Build();

string vendorId = "vendor_id8";
try
{
    UpdateVendorResponse result = await vendorsApi.UpdateVendorAsync(body, vendorId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

