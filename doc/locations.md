# Locations

```csharp
ILocationsApi locationsApi = client.LocationsApi;
```

## Class Name

`LocationsApi`

## Methods

* [List Locations](/doc/locations.md#list-locations)
* [Create Location](/doc/locations.md#create-location)
* [Retrieve Location](/doc/locations.md#retrieve-location)
* [Update Location](/doc/locations.md#update-location)

## List Locations

Provides information of all locations of a business.

Most other Connect API endpoints have a required `location_id` path parameter.
The `id` field of the [`Location`](#type-location) objects returned by this
endpoint correspond to that `location_id` parameter.

```csharp
ListLocationsAsync()
```

### Response Type

[`Task<Models.ListLocationsResponse>`](/doc/models/list-locations-response.md)

### Example Usage

```csharp
try
{
    ListLocationsResponse result = await locationsApi.ListLocationsAsync();
}
catch (ApiException e){};
```

## Create Location

Creates a location.
For more information about locations, see [Locations API Overview](https://developer.squareup.com/docs/locations-api).

```csharp
CreateLocationAsync(Models.CreateLocationRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateLocationRequest`](/doc/models/create-location-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateLocationResponse>`](/doc/models/create-location-response.md)

### Example Usage

```csharp
var bodyLocationAddress = new Address.Builder()
    .AddressLine1("1234 Peachtree St. NE")
    .Locality("Atlanta")
    .AdministrativeDistrictLevel1("GA")
    .PostalCode("30309")
    .Build();
var bodyLocation = new Location.Builder()
    .Name("New location name")
    .Address(bodyLocationAddress)
    .Description("My new location.")
    .Build();
var body = new CreateLocationRequest.Builder()
    .Location(bodyLocation)
    .Build();

try
{
    CreateLocationResponse result = await locationsApi.CreateLocationAsync(body);
}
catch (ApiException e){};
```

## Retrieve Location

Retrieves details of a location. You can specify "main" 
as the location ID to retrieve details of the 
main location. For more information, 
see [Locations API Overview](https://developer.squareup.com/docs/docs/locations-api).

```csharp
RetrieveLocationAsync(string locationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to retrieve. If you specify the string "main",<br>then the endpoint returns the main location. |

### Response Type

[`Task<Models.RetrieveLocationResponse>`](/doc/models/retrieve-location-response.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    RetrieveLocationResponse result = await locationsApi.RetrieveLocationAsync(locationId);
}
catch (ApiException e){};
```

## Update Location

Updates a location.

```csharp
UpdateLocationAsync(string locationId, Models.UpdateLocationRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to update. |
| `body` | [`Models.UpdateLocationRequest`](/doc/models/update-location-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateLocationResponse>`](/doc/models/update-location-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyLocationAddress = new Address.Builder()
    .AddressLine1("1234 Peachtree St. NE")
    .Locality("Atlanta")
    .AdministrativeDistrictLevel1("GA")
    .PostalCode("30309")
    .Build();
var bodyLocationBusinessHoursPeriods = new List<BusinessHoursPeriod>();

var bodyLocationBusinessHoursPeriods0 = new BusinessHoursPeriod.Builder()
    .DayOfWeek("MON")
    .StartLocalTime("09:00")
    .EndLocalTime("17:00")
    .Build();
bodyLocationBusinessHoursPeriods.Add(bodyLocationBusinessHoursPeriods0);

var bodyLocationBusinessHours = new BusinessHours.Builder()
    .Periods(bodyLocationBusinessHoursPeriods)
    .Build();
var bodyLocation = new Location.Builder()
    .Name("Updated nickname")
    .Address(bodyLocationAddress)
    .BusinessHours(bodyLocationBusinessHours)
    .Description("Updated description")
    .TwitterUsername("twitter")
    .InstagramUsername("instagram")
    .Build();
var body = new UpdateLocationRequest.Builder()
    .Location(bodyLocation)
    .Build();

try
{
    UpdateLocationResponse result = await locationsApi.UpdateLocationAsync(locationId, body);
}
catch (ApiException e){};
```

