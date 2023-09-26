# Locations

```csharp
ILocationsApi locationsApi = client.LocationsApi;
```

## Class Name

`LocationsApi`

## Methods

* [List Locations](../../doc/api/locations.md#list-locations)
* [Create Location](../../doc/api/locations.md#create-location)
* [Retrieve Location](../../doc/api/locations.md#retrieve-location)
* [Update Location](../../doc/api/locations.md#update-location)


# List Locations

Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),
including those with an inactive status.

```csharp
ListLocationsAsync()
```

## Response Type

[`Task<Models.ListLocationsResponse>`](../../doc/models/list-locations-response.md)

## Example Usage

```csharp
try
{
    ListLocationsResponse result = await locationsApi.ListLocationsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Location

Creates a [location](https://developer.squareup.com/docs/locations-api).
Creating new locations allows for separate configuration of receipt layouts, item prices,
and sales reports. Developers can use locations to separate sales activity through applications
that integrate with Square from sales activity elsewhere in a seller's account.
Locations created programmatically with the Locations API last forever and
are visible to the seller for their own management. Therefore, ensure that
each location has a sensible and unique name.

```csharp
CreateLocationAsync(
    Models.CreateLocationRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateLocationRequest`](../../doc/models/create-location-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateLocationResponse>`](../../doc/models/create-location-response.md)

## Example Usage

```csharp
Models.CreateLocationRequest body = new Models.CreateLocationRequest.Builder()
.Location(
    new Models.Location.Builder()
    .Name("Midtown")
    .Address(
        new Models.Address.Builder()
        .AddressLine1("1234 Peachtree St. NE")
        .Locality("Atlanta")
        .AdministrativeDistrictLevel1("GA")
        .PostalCode("30309")
        .Build())
    .Description("Midtown Atlanta store")
    .Build())
.Build();

try
{
    CreateLocationResponse result = await locationsApi.CreateLocationAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Location

Retrieves details of a single location. Specify "main"
as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).

```csharp
RetrieveLocationAsync(
    string locationId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to retrieve. Specify the string<br>"main" to return the main location. |

## Response Type

[`Task<Models.RetrieveLocationResponse>`](../../doc/models/retrieve-location-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
try
{
    RetrieveLocationResponse result = await locationsApi.RetrieveLocationAsync(locationId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Location

Updates a [location](https://developer.squareup.com/docs/locations-api).

```csharp
UpdateLocationAsync(
    string locationId,
    Models.UpdateLocationRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to update. |
| `body` | [`UpdateLocationRequest`](../../doc/models/update-location-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateLocationResponse>`](../../doc/models/update-location-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
Models.UpdateLocationRequest body = new Models.UpdateLocationRequest.Builder()
.Location(
    new Models.Location.Builder()
    .BusinessHours(
        new Models.BusinessHours.Builder()
        .Periods(
            new List<Models.BusinessHoursPeriod>
            {
                new Models.BusinessHoursPeriod.Builder()
                .DayOfWeek("FRI")
                .StartLocalTime("07:00")
                .EndLocalTime("18:00")
                .Build(),
                new Models.BusinessHoursPeriod.Builder()
                .DayOfWeek("SAT")
                .StartLocalTime("07:00")
                .EndLocalTime("18:00")
                .Build(),
                new Models.BusinessHoursPeriod.Builder()
                .DayOfWeek("SUN")
                .StartLocalTime("09:00")
                .EndLocalTime("15:00")
                .Build(),
            })
        .Build())
    .Description("Midtown Atlanta store - Open weekends")
    .Build())
.Build();

try
{
    UpdateLocationResponse result = await locationsApi.UpdateLocationAsync(
        locationId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

