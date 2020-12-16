# Bookings

```csharp
IBookingsApi bookingsApi = client.BookingsApi;
```

## Class Name

`BookingsApi`

## Methods

* [Create Booking](/doc/api/bookings.md#create-booking)
* [Search Availability](/doc/api/bookings.md#search-availability)
* [Retrieve Business Booking Profile](/doc/api/bookings.md#retrieve-business-booking-profile)
* [List Team Member Booking Profiles](/doc/api/bookings.md#list-team-member-booking-profiles)
* [Retrieve Team Member Booking Profile](/doc/api/bookings.md#retrieve-team-member-booking-profile)
* [Retrieve Booking](/doc/api/bookings.md#retrieve-booking)
* [Update Booking](/doc/api/bookings.md#update-booking)
* [Cancel Booking](/doc/api/bookings.md#cancel-booking)


# Create Booking

Creates a booking.

```csharp
CreateBookingAsync(Models.CreateBookingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateBookingRequest`](/doc/models/create-booking-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateBookingResponse>`](/doc/models/create-booking-response.md)

## Example Usage

```csharp
var bodyBooking = new Booking.Builder()
    .Id("id8")
    .Version(148)
    .Status("ACCEPTED")
    .CreatedAt("created_at6")
    .UpdatedAt("updated_at4")
    .Build();
var body = new CreateBookingRequest.Builder(
        bodyBooking)
    .IdempotencyKey("idempotency_key2")
    .Build();

try
{
    CreateBookingResponse result = await bookingsApi.CreateBookingAsync(body);
}
catch (ApiException e){};
```


# Search Availability

Searches for availabilities for booking.

```csharp
SearchAvailabilityAsync(Models.SearchAvailabilityRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchAvailabilityRequest`](/doc/models/search-availability-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchAvailabilityResponse>`](/doc/models/search-availability-response.md)

## Example Usage

```csharp
var bodyQueryFilterStartAtRange = new TimeRange.Builder()
    .StartAt("start_at8")
    .EndAt("end_at4")
    .Build();
var bodyQueryFilterSegmentFilters = new List<SegmentFilter>();

var bodyQueryFilterSegmentFilters0TeamMemberIdFilterAll = new List<string>();
bodyQueryFilterSegmentFilters0TeamMemberIdFilterAll.Add("all7");
var bodyQueryFilterSegmentFilters0TeamMemberIdFilterAny = new List<string>();
bodyQueryFilterSegmentFilters0TeamMemberIdFilterAny.Add("any0");
bodyQueryFilterSegmentFilters0TeamMemberIdFilterAny.Add("any1");
var bodyQueryFilterSegmentFilters0TeamMemberIdFilterNone = new List<string>();
bodyQueryFilterSegmentFilters0TeamMemberIdFilterNone.Add("none5");
var bodyQueryFilterSegmentFilters0TeamMemberIdFilter = new FilterValue.Builder()
    .All(bodyQueryFilterSegmentFilters0TeamMemberIdFilterAll)
    .Any(bodyQueryFilterSegmentFilters0TeamMemberIdFilterAny)
    .None(bodyQueryFilterSegmentFilters0TeamMemberIdFilterNone)
    .Build();
var bodyQueryFilterSegmentFilters0 = new SegmentFilter.Builder(
        "service_variation_id8")
    .TeamMemberIdFilter(bodyQueryFilterSegmentFilters0TeamMemberIdFilter)
    .Build();
bodyQueryFilterSegmentFilters.Add(bodyQueryFilterSegmentFilters0);

var bodyQueryFilterSegmentFilters1TeamMemberIdFilterAll = new List<string>();
bodyQueryFilterSegmentFilters1TeamMemberIdFilterAll.Add("all6");
bodyQueryFilterSegmentFilters1TeamMemberIdFilterAll.Add("all7");
bodyQueryFilterSegmentFilters1TeamMemberIdFilterAll.Add("all8");
var bodyQueryFilterSegmentFilters1TeamMemberIdFilterAny = new List<string>();
bodyQueryFilterSegmentFilters1TeamMemberIdFilterAny.Add("any1");
bodyQueryFilterSegmentFilters1TeamMemberIdFilterAny.Add("any2");
bodyQueryFilterSegmentFilters1TeamMemberIdFilterAny.Add("any3");
var bodyQueryFilterSegmentFilters1TeamMemberIdFilterNone = new List<string>();
bodyQueryFilterSegmentFilters1TeamMemberIdFilterNone.Add("none6");
bodyQueryFilterSegmentFilters1TeamMemberIdFilterNone.Add("none7");
var bodyQueryFilterSegmentFilters1TeamMemberIdFilter = new FilterValue.Builder()
    .All(bodyQueryFilterSegmentFilters1TeamMemberIdFilterAll)
    .Any(bodyQueryFilterSegmentFilters1TeamMemberIdFilterAny)
    .None(bodyQueryFilterSegmentFilters1TeamMemberIdFilterNone)
    .Build();
var bodyQueryFilterSegmentFilters1 = new SegmentFilter.Builder(
        "service_variation_id7")
    .TeamMemberIdFilter(bodyQueryFilterSegmentFilters1TeamMemberIdFilter)
    .Build();
bodyQueryFilterSegmentFilters.Add(bodyQueryFilterSegmentFilters1);

var bodyQueryFilter = new SearchAvailabilityFilter.Builder(
        bodyQueryFilterStartAtRange)
    .LocationId("location_id6")
    .SegmentFilters(bodyQueryFilterSegmentFilters)
    .BookingId("booking_id6")
    .Build();
var bodyQuery = new SearchAvailabilityQuery.Builder(
        bodyQueryFilter)
    .Build();
var body = new SearchAvailabilityRequest.Builder(
        bodyQuery)
    .Build();

try
{
    SearchAvailabilityResponse result = await bookingsApi.SearchAvailabilityAsync(body);
}
catch (ApiException e){};
```


# Retrieve Business Booking Profile

Retrieves a seller's booking profile.

```csharp
RetrieveBusinessBookingProfileAsync()
```

## Response Type

[`Task<Models.RetrieveBusinessBookingProfileResponse>`](/doc/models/retrieve-business-booking-profile-response.md)

## Example Usage

```csharp
try
{
    RetrieveBusinessBookingProfileResponse result = await bookingsApi.RetrieveBusinessBookingProfileAsync();
}
catch (ApiException e){};
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
| `bookableOnly` | `bool?` | Query, Optional | Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return. |
| `cursor` | `string` | Query, Optional | The cursor for paginating through the results. |
| `locationId` | `string` | Query, Optional | Indicates whether to include only team members enabled at the given location in the returned result. |

## Response Type

[`Task<Models.ListTeamMemberBookingProfilesResponse>`](/doc/models/list-team-member-booking-profiles-response.md)

## Example Usage

```csharp
bool? bookableOnly = false;
int? limit = 172;
string cursor = "cursor6";
string locationId = "location_id4";

try
{
    ListTeamMemberBookingProfilesResponse result = await bookingsApi.ListTeamMemberBookingProfilesAsync(bookableOnly, limit, cursor, locationId);
}
catch (ApiException e){};
```


# Retrieve Team Member Booking Profile

Retrieves a team member's booking profile.

```csharp
RetrieveTeamMemberBookingProfileAsync(string teamMemberId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to retrieve. |

## Response Type

[`Task<Models.RetrieveTeamMemberBookingProfileResponse>`](/doc/models/retrieve-team-member-booking-profile-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";

try
{
    RetrieveTeamMemberBookingProfileResponse result = await bookingsApi.RetrieveTeamMemberBookingProfileAsync(teamMemberId);
}
catch (ApiException e){};
```


# Retrieve Booking

Retrieves a booking.

```csharp
RetrieveBookingAsync(string bookingId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the [Booking](#type-booking) object representing the to-be-retrieved booking. |

## Response Type

[`Task<Models.RetrieveBookingResponse>`](/doc/models/retrieve-booking-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";

try
{
    RetrieveBookingResponse result = await bookingsApi.RetrieveBookingAsync(bookingId);
}
catch (ApiException e){};
```


# Update Booking

Updates a booking.

```csharp
UpdateBookingAsync(string bookingId, Models.UpdateBookingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the [Booking](#type-booking) object representing the to-be-updated booking. |
| `body` | [`Models.UpdateBookingRequest`](/doc/models/update-booking-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateBookingResponse>`](/doc/models/update-booking-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
var bodyBooking = new Booking.Builder()
    .Id("id8")
    .Version(148)
    .Status("ACCEPTED")
    .CreatedAt("created_at6")
    .UpdatedAt("updated_at4")
    .Build();
var body = new UpdateBookingRequest.Builder(
        bodyBooking)
    .IdempotencyKey("idempotency_key2")
    .Build();

try
{
    UpdateBookingResponse result = await bookingsApi.UpdateBookingAsync(bookingId, body);
}
catch (ApiException e){};
```


# Cancel Booking

Cancels an existing booking.

```csharp
CancelBookingAsync(string bookingId, Models.CancelBookingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the [Booking](#type-booking) object representing the to-be-cancelled booking. |
| `body` | [`Models.CancelBookingRequest`](/doc/models/cancel-booking-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CancelBookingResponse>`](/doc/models/cancel-booking-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
var body = new CancelBookingRequest.Builder()
    .IdempotencyKey("idempotency_key2")
    .BookingVersion(8)
    .Build();

try
{
    CancelBookingResponse result = await bookingsApi.CancelBookingAsync(bookingId, body);
}
catch (ApiException e){};
```

