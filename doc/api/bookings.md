# Bookings

```csharp
IBookingsApi bookingsApi = client.BookingsApi;
```

## Class Name

`BookingsApi`

## Methods

* [List Bookings](../../doc/api/bookings.md#list-bookings)
* [Create Booking](../../doc/api/bookings.md#create-booking)
* [Search Availability](../../doc/api/bookings.md#search-availability)
* [Bulk Retrieve Bookings](../../doc/api/bookings.md#bulk-retrieve-bookings)
* [Retrieve Business Booking Profile](../../doc/api/bookings.md#retrieve-business-booking-profile)
* [List Location Booking Profiles](../../doc/api/bookings.md#list-location-booking-profiles)
* [Retrieve Location Booking Profile](../../doc/api/bookings.md#retrieve-location-booking-profile)
* [List Team Member Booking Profiles](../../doc/api/bookings.md#list-team-member-booking-profiles)
* [Bulk Retrieve Team Member Booking Profiles](../../doc/api/bookings.md#bulk-retrieve-team-member-booking-profiles)
* [Retrieve Team Member Booking Profile](../../doc/api/bookings.md#retrieve-team-member-booking-profile)
* [Retrieve Booking](../../doc/api/bookings.md#retrieve-booking)
* [Update Booking](../../doc/api/bookings.md#update-booking)
* [Cancel Booking](../../doc/api/bookings.md#cancel-booking)


# List Bookings

Retrieve a collection of bookings.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
ListBookingsAsync(
    int? limit = null,
    string cursor = null,
    string customerId = null,
    string teamMemberId = null,
    string locationId = null,
    string startAtMin = null,
    string startAtMax = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | The maximum number of results per page to return in a paged response. |
| `cursor` | `string` | Query, Optional | The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results. |
| `customerId` | `string` | Query, Optional | The [customer](entity:Customer) for whom to retrieve bookings. If this is not set, bookings for all customers are retrieved. |
| `teamMemberId` | `string` | Query, Optional | The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved. |
| `locationId` | `string` | Query, Optional | The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved. |
| `startAtMin` | `string` | Query, Optional | The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used. |
| `startAtMax` | `string` | Query, Optional | The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used. |

## Response Type

[`Task<Models.ListBookingsResponse>`](../../doc/models/list-bookings-response.md)

## Example Usage

```csharp
try
{
    ListBookingsResponse result = await bookingsApi.ListBookingsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Booking

Creates a booking.

The required input must include the following:

- `Booking.location_id`
- `Booking.start_at`
- `Booking.team_member_id`
- `Booking.AppointmentSegment.service_variation_id`
- `Booking.AppointmentSegment.service_variation_version`

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
CreateBookingAsync(
    Models.CreateBookingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateBookingRequest`](../../doc/models/create-booking-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateBookingResponse>`](../../doc/models/create-booking-response.md)

## Example Usage

```csharp
Models.CreateBookingRequest body = new Models.CreateBookingRequest.Builder(
    new Models.Booking.Builder()
    .Build()
)
.Build();

try
{
    CreateBookingResponse result = await bookingsApi.CreateBookingAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Search Availability

Searches for availabilities for booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
SearchAvailabilityAsync(
    Models.SearchAvailabilityRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SearchAvailabilityRequest`](../../doc/models/search-availability-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchAvailabilityResponse>`](../../doc/models/search-availability-response.md)

## Example Usage

```csharp
Models.SearchAvailabilityRequest body = new Models.SearchAvailabilityRequest.Builder(
    new Models.SearchAvailabilityQuery.Builder(
        new Models.SearchAvailabilityFilter.Builder(
            new Models.TimeRange.Builder()
            .Build()
        )
        .Build()
    )
    .Build()
)
.Build();

try
{
    SearchAvailabilityResponse result = await bookingsApi.SearchAvailabilityAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Retrieve Bookings

Bulk-Retrieves a list of bookings by booking IDs.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
BulkRetrieveBookingsAsync(
    Models.BulkRetrieveBookingsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkRetrieveBookingsRequest`](../../doc/models/bulk-retrieve-bookings-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkRetrieveBookingsResponse>`](../../doc/models/bulk-retrieve-bookings-response.md)

## Example Usage

```csharp
Models.BulkRetrieveBookingsRequest body = new Models.BulkRetrieveBookingsRequest.Builder(
    new List<string>
    {
        "booking_ids8",
        "booking_ids9",
        "booking_ids0",
    }
)
.Build();

try
{
    BulkRetrieveBookingsResponse result = await bookingsApi.BulkRetrieveBookingsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Business Booking Profile

Retrieves a seller's booking profile.

```csharp
RetrieveBusinessBookingProfileAsync()
```

## Response Type

[`Task<Models.RetrieveBusinessBookingProfileResponse>`](../../doc/models/retrieve-business-booking-profile-response.md)

## Example Usage

```csharp
try
{
    RetrieveBusinessBookingProfileResponse result = await bookingsApi.RetrieveBusinessBookingProfileAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Location Booking Profiles

Lists location booking profiles of a seller.

```csharp
ListLocationBookingProfilesAsync(
    int? limit = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a paged response. |
| `cursor` | `string` | Query, Optional | The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results. |

## Response Type

[`Task<Models.ListLocationBookingProfilesResponse>`](../../doc/models/list-location-booking-profiles-response.md)

## Example Usage

```csharp
try
{
    ListLocationBookingProfilesResponse result = await bookingsApi.ListLocationBookingProfilesAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Location Booking Profile

Retrieves a seller's location booking profile.

```csharp
RetrieveLocationBookingProfileAsync(
    string locationId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to retrieve the booking profile. |

## Response Type

[`Task<Models.RetrieveLocationBookingProfileResponse>`](../../doc/models/retrieve-location-booking-profile-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
try
{
    RetrieveLocationBookingProfileResponse result = await bookingsApi.RetrieveLocationBookingProfileAsync(locationId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Team Member Booking Profiles

Lists booking profiles for team members.

```csharp
ListTeamMemberBookingProfilesAsync(
    bool? bookableOnly = false,
    int? limit = null,
    string cursor = null,
    string locationId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookableOnly` | `bool?` | Query, Optional | Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`).<br>**Default**: `false` |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a paged response. |
| `cursor` | `string` | Query, Optional | The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results. |
| `locationId` | `string` | Query, Optional | Indicates whether to include only team members enabled at the given location in the returned result. |

## Response Type

[`Task<Models.ListTeamMemberBookingProfilesResponse>`](../../doc/models/list-team-member-booking-profiles-response.md)

## Example Usage

```csharp
bool? bookableOnly = false;
try
{
    ListTeamMemberBookingProfilesResponse result = await bookingsApi.ListTeamMemberBookingProfilesAsync(bookableOnly);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Retrieve Team Member Booking Profiles

Retrieves one or more team members' booking profiles.

```csharp
BulkRetrieveTeamMemberBookingProfilesAsync(
    Models.BulkRetrieveTeamMemberBookingProfilesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkRetrieveTeamMemberBookingProfilesRequest`](../../doc/models/bulk-retrieve-team-member-booking-profiles-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkRetrieveTeamMemberBookingProfilesResponse>`](../../doc/models/bulk-retrieve-team-member-booking-profiles-response.md)

## Example Usage

```csharp
Models.BulkRetrieveTeamMemberBookingProfilesRequest body = new Models.BulkRetrieveTeamMemberBookingProfilesRequest.Builder(
    new List<string>
    {
        "team_member_ids3",
        "team_member_ids4",
        "team_member_ids5",
    }
)
.Build();

try
{
    BulkRetrieveTeamMemberBookingProfilesResponse result = await bookingsApi.BulkRetrieveTeamMemberBookingProfilesAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Team Member Booking Profile

Retrieves a team member's booking profile.

```csharp
RetrieveTeamMemberBookingProfileAsync(
    string teamMemberId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to retrieve. |

## Response Type

[`Task<Models.RetrieveTeamMemberBookingProfileResponse>`](../../doc/models/retrieve-team-member-booking-profile-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";
try
{
    RetrieveTeamMemberBookingProfileResponse result = await bookingsApi.RetrieveTeamMemberBookingProfileAsync(teamMemberId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Booking

Retrieves a booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
RetrieveBookingAsync(
    string bookingId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the [Booking](entity:Booking) object representing the to-be-retrieved booking. |

## Response Type

[`Task<Models.RetrieveBookingResponse>`](../../doc/models/retrieve-booking-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
try
{
    RetrieveBookingResponse result = await bookingsApi.RetrieveBookingAsync(bookingId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Booking

Updates a booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
UpdateBookingAsync(
    string bookingId,
    Models.UpdateBookingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the [Booking](entity:Booking) object representing the to-be-updated booking. |
| `body` | [`UpdateBookingRequest`](../../doc/models/update-booking-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateBookingResponse>`](../../doc/models/update-booking-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
Models.UpdateBookingRequest body = new Models.UpdateBookingRequest.Builder(
    new Models.Booking.Builder()
    .Build()
)
.Build();

try
{
    UpdateBookingResponse result = await bookingsApi.UpdateBookingAsync(
        bookingId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Cancel Booking

Cancels an existing booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
CancelBookingAsync(
    string bookingId,
    Models.CancelBookingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the [Booking](entity:Booking) object representing the to-be-cancelled booking. |
| `body` | [`CancelBookingRequest`](../../doc/models/cancel-booking-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CancelBookingResponse>`](../../doc/models/cancel-booking-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
Models.CancelBookingRequest body = new Models.CancelBookingRequest.Builder()
.Build();

try
{
    CancelBookingResponse result = await bookingsApi.CancelBookingAsync(
        bookingId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

