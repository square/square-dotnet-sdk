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

---

- __Deprecation date__: 2019-11-20
- [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
- [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)

---

```csharp
RetrieveBusinessAsync()
```

### Response Type

[`Task<Models.V1Merchant>`](/doc/models/v1-merchant.md)

### Example Usage

```csharp
try
{
    V1Merchant result = v1LocationsApi.RetrieveBusinessAsync().Result;
}
catch (ApiException e){};
```

## List Locations

Provides details for all business locations associated with a Square
account, including the Square-assigned object ID for the location.

---

- __Deprecation date__: 2019-11-20
- [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
- [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)

---

```csharp
ListLocationsAsync()
```

### Response Type

[`Task<List<Models.V1Merchant>>`](/doc/models/v1-merchant.md)

### Example Usage

```csharp
try
{
    List<V1Merchant> result = v1LocationsApi.ListLocationsAsync().Result;
}
catch (ApiException e){};
```

