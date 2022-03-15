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
| `body` | [`Models.BulkCreateVendorsRequest`](../../doc/models/bulk-create-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkCreateVendorsResponse>`](../../doc/models/bulk-create-vendors-response.md)

## Example Usage

```csharp
var bodyVendors = new Dictionary<string, Vendor>();


var bodyVendors0 = new Vendor.Builder()
    .Build();
bodyVendors.Add("",bodyVendors0);

var bodyVendors1 = new Vendor.Builder()
    .Build();
bodyVendors.Add("",bodyVendors1);

var body = new BulkCreateVendorsRequest.Builder(
        bodyVendors)
    .Build();

try
{
    BulkCreateVendorsResponse result = await vendorsApi.BulkCreateVendorsAsync(body);
}
catch (ApiException e){};
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
| `body` | [`Models.BulkRetrieveVendorsRequest`](../../doc/models/bulk-retrieve-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkRetrieveVendorsResponse>`](../../doc/models/bulk-retrieve-vendors-response.md)

## Example Usage

```csharp
var bodyVendorIds = new IList<string>();
bodyVendorIds.Add("INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4");
var body = new BulkRetrieveVendorsRequest.Builder()
    .VendorIds(bodyVendorIds)
    .Build();

try
{
    BulkRetrieveVendorsResponse result = await vendorsApi.BulkRetrieveVendorsAsync(body);
}
catch (ApiException e){};
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
| `body` | [`Models.BulkUpdateVendorsRequest`](../../doc/models/bulk-update-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpdateVendorsResponse>`](../../doc/models/bulk-update-vendors-response.md)

## Example Usage

```csharp
var bodyVendors = new Dictionary<string, UpdateVendorRequest>();


var bodyVendors0Vendor = new Vendor.Builder()
    .Build();
var bodyVendors0 = new UpdateVendorRequest.Builder(
        bodyVendors0Vendor)
    .Build();
bodyVendors.Add("",bodyVendors0);

var bodyVendors1Vendor = new Vendor.Builder()
    .Build();
var bodyVendors1 = new UpdateVendorRequest.Builder(
        bodyVendors1Vendor)
    .Build();
bodyVendors.Add("",bodyVendors1);

var body = new BulkUpdateVendorsRequest.Builder(
        bodyVendors)
    .Build();

try
{
    BulkUpdateVendorsResponse result = await vendorsApi.BulkUpdateVendorsAsync(body);
}
catch (ApiException e){};
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
| `body` | [`Models.CreateVendorRequest`](../../doc/models/create-vendor-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateVendorResponse>`](../../doc/models/create-vendor-response.md)

## Example Usage

```csharp
var bodyVendorAddress = new Address.Builder()
    .AddressLine1("address_line_18")
    .AddressLine2("address_line_28")
    .AddressLine3("address_line_34")
    .Locality("locality8")
    .Sublocality("sublocality8")
    .Build();
var bodyVendor = new Vendor.Builder()
    .Id("id2")
    .CreatedAt("created_at0")
    .UpdatedAt("updated_at8")
    .Name("name2")
    .Address(bodyVendorAddress)
    .Build();
var body = new CreateVendorRequest.Builder(
        "idempotency_key2")
    .Vendor(bodyVendor)
    .Build();

try
{
    CreateVendorResponse result = await vendorsApi.CreateVendorAsync(body);
}
catch (ApiException e){};
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
| `body` | [`Models.SearchVendorsRequest`](../../doc/models/search-vendors-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchVendorsResponse>`](../../doc/models/search-vendors-response.md)

## Example Usage

```csharp
var bodyFilterName = new IList<string>();
bodyFilterName.Add("name8");
bodyFilterName.Add("name9");
var bodyFilterStatus = new IList<string>();
bodyFilterStatus.Add("ACTIVE");
var bodyFilter = new SearchVendorsRequestFilter.Builder()
    .Name(bodyFilterName)
    .Status(bodyFilterStatus)
    .Build();
var bodySort = new SearchVendorsRequestSort.Builder()
    .Field("NAME")
    .Order("DESC")
    .Build();
var body = new SearchVendorsRequest.Builder()
    .Filter(bodyFilter)
    .Sort(bodySort)
    .Cursor("cursor0")
    .Build();

try
{
    SearchVendorsResponse result = await vendorsApi.SearchVendorsAsync(body);
}
catch (ApiException e){};
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
| `vendorId` | `string` | Template, Required | ID of the [Vendor](../../doc/models/vendor.md) to retrieve. |

## Response Type

[`Task<Models.RetrieveVendorResponse>`](../../doc/models/retrieve-vendor-response.md)

## Example Usage

```csharp
string vendorId = "vendor_id8";

try
{
    RetrieveVendorResponse result = await vendorsApi.RetrieveVendorAsync(vendorId);
}
catch (ApiException e){};
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
| `body` | [`Models.UpdateVendorRequest`](../../doc/models/update-vendor-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |
| `vendorId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.UpdateVendorResponse>`](../../doc/models/update-vendor-response.md)

## Example Usage

```csharp
var bodyVendorAddress = new Address.Builder()
    .AddressLine1("address_line_18")
    .AddressLine2("address_line_28")
    .AddressLine3("address_line_34")
    .Locality("locality8")
    .Sublocality("sublocality8")
    .Build();
var bodyVendor = new Vendor.Builder()
    .Id("INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4")
    .CreatedAt("created_at0")
    .UpdatedAt("updated_at8")
    .Name("Jack's Chicken Shack")
    .Address(bodyVendorAddress)
    .Version(1)
    .Status("ACTIVE")
    .Build();
var body = new UpdateVendorRequest.Builder(
        bodyVendor)
    .IdempotencyKey("8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe")
    .Build();
string vendorId = "vendor_id8";

try
{
    UpdateVendorResponse result = await vendorsApi.UpdateVendorAsync(body, vendorId);
}
catch (ApiException e){};
```

