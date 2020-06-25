# V1 Locations

```csharp
IV1LocationsApi v1LocationsApi = client.V1LocationsApi;
```

## Class Name

`V1LocationsApi`

## Methods

* [Retrieve Business](/doc/v1-locations.md#retrieve-business)
* [List Locations](/doc/v1-locations.md#list-locations)

## Retrieve Business

Get the general information for a business.

```csharp
RetrieveBusinessAsync()
```

### Response Type

[`Task<Models.V1Merchant>`](/doc/models/v1-merchant.md)

### Example Usage

```csharp
try
{
    V1Merchant result = await v1LocationsApi.RetrieveBusinessAsync();
}
catch (ApiException e){};
```

## List Locations

Provides details for all business locations associated with a Square
account, including the Square-assigned object ID for the location.

```csharp
ListLocationsAsync()
```

### Response Type

[`Task<List<Models.V1Merchant>>`](/doc/models/v1-merchant.md)

### Example Usage

```csharp
try
{
    List<V1Merchant> result = await v1LocationsApi.ListLocationsAsync();
}
catch (ApiException e){};
```

