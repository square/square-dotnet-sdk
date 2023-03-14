# Booking Custom Attributes

```csharp
IBookingCustomAttributesApi bookingCustomAttributesApi = client.BookingCustomAttributesApi;
```

## Class Name

`BookingCustomAttributesApi`

## Methods

* [List Booking Custom Attribute Definitions](../../doc/api/booking-custom-attributes.md#list-booking-custom-attribute-definitions)
* [Create Booking Custom Attribute Definition](../../doc/api/booking-custom-attributes.md#create-booking-custom-attribute-definition)
* [Delete Booking Custom Attribute Definition](../../doc/api/booking-custom-attributes.md#delete-booking-custom-attribute-definition)
* [Retrieve Booking Custom Attribute Definition](../../doc/api/booking-custom-attributes.md#retrieve-booking-custom-attribute-definition)
* [Update Booking Custom Attribute Definition](../../doc/api/booking-custom-attributes.md#update-booking-custom-attribute-definition)
* [Bulk Delete Booking Custom Attributes](../../doc/api/booking-custom-attributes.md#bulk-delete-booking-custom-attributes)
* [Bulk Upsert Booking Custom Attributes](../../doc/api/booking-custom-attributes.md#bulk-upsert-booking-custom-attributes)
* [List Booking Custom Attributes](../../doc/api/booking-custom-attributes.md#list-booking-custom-attributes)
* [Delete Booking Custom Attribute](../../doc/api/booking-custom-attributes.md#delete-booking-custom-attribute)
* [Retrieve Booking Custom Attribute](../../doc/api/booking-custom-attributes.md#retrieve-booking-custom-attribute)
* [Upsert Booking Custom Attribute](../../doc/api/booking-custom-attributes.md#upsert-booking-custom-attribute)


# List Booking Custom Attribute Definitions

Get all bookings custom attribute definitions.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
ListBookingCustomAttributeDefinitionsAsync(
    int? limit = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single paged response. This limit is advisory.<br>The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.<br>The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `cursor` | `string` | Query, Optional | The cursor returned in the paged response from the previous call to this endpoint.<br>Provide this cursor to retrieve the next page of results for your original request.<br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Response Type

[`Task<Models.ListBookingCustomAttributeDefinitionsResponse>`](../../doc/models/list-booking-custom-attribute-definitions-response.md)

## Example Usage

```csharp
try
{
    ListBookingCustomAttributeDefinitionsResponse result = await bookingCustomAttributesApi.ListBookingCustomAttributeDefinitionsAsync(null, null);
}
catch (ApiException e){};
```


# Create Booking Custom Attribute Definition

Creates a bookings custom attribute definition.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
CreateBookingCustomAttributeDefinitionAsync(
    Models.CreateBookingCustomAttributeDefinitionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateBookingCustomAttributeDefinitionRequest`](../../doc/models/create-booking-custom-attribute-definition-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateBookingCustomAttributeDefinitionResponse>`](../../doc/models/create-booking-custom-attribute-definition-response.md)

## Example Usage

```csharp
var bodyCustomAttributeDefinition = new CustomAttributeDefinition.Builder()
    .Build();
var body = new CreateBookingCustomAttributeDefinitionRequest.Builder(
        bodyCustomAttributeDefinition)
    .Build();

try
{
    CreateBookingCustomAttributeDefinitionResponse result = await bookingCustomAttributesApi.CreateBookingCustomAttributeDefinitionAsync(body);
}
catch (ApiException e){};
```


# Delete Booking Custom Attribute Definition

Deletes a bookings custom attribute definition.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
DeleteBookingCustomAttributeDefinitionAsync(
    string key)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to delete. |

## Response Type

[`Task<Models.DeleteBookingCustomAttributeDefinitionResponse>`](../../doc/models/delete-booking-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";

try
{
    DeleteBookingCustomAttributeDefinitionResponse result = await bookingCustomAttributesApi.DeleteBookingCustomAttributeDefinitionAsync(key);
}
catch (ApiException e){};
```


# Retrieve Booking Custom Attribute Definition

Retrieves a bookings custom attribute definition.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
RetrieveBookingCustomAttributeDefinitionAsync(
    string key,
    int? version = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to retrieve. If the requesting application<br>is not the definition owner, you must use the qualified key. |
| `version` | `int?` | Query, Optional | The current version of the custom attribute definition, which is used for strongly consistent<br>reads to guarantee that you receive the most up-to-date data. When included in the request,<br>Square returns the specified version or a higher version if one exists. If the specified version<br>is higher than the current version, Square returns a `BAD_REQUEST` error. |

## Response Type

[`Task<Models.RetrieveBookingCustomAttributeDefinitionResponse>`](../../doc/models/retrieve-booking-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";

try
{
    RetrieveBookingCustomAttributeDefinitionResponse result = await bookingCustomAttributesApi.RetrieveBookingCustomAttributeDefinitionAsync(key, null);
}
catch (ApiException e){};
```


# Update Booking Custom Attribute Definition

Updates a bookings custom attribute definition.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
UpdateBookingCustomAttributeDefinitionAsync(
    string key,
    Models.UpdateBookingCustomAttributeDefinitionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to update. |
| `body` | [`Models.UpdateBookingCustomAttributeDefinitionRequest`](../../doc/models/update-booking-custom-attribute-definition-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateBookingCustomAttributeDefinitionResponse>`](../../doc/models/update-booking-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";
var bodyCustomAttributeDefinition = new CustomAttributeDefinition.Builder()
    .Build();
var body = new UpdateBookingCustomAttributeDefinitionRequest.Builder(
        bodyCustomAttributeDefinition)
    .Build();

try
{
    UpdateBookingCustomAttributeDefinitionResponse result = await bookingCustomAttributesApi.UpdateBookingCustomAttributeDefinitionAsync(key, body);
}
catch (ApiException e){};
```


# Bulk Delete Booking Custom Attributes

Bulk deletes bookings custom attributes.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
BulkDeleteBookingCustomAttributesAsync(
    Models.BulkDeleteBookingCustomAttributesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkDeleteBookingCustomAttributesRequest`](../../doc/models/bulk-delete-booking-custom-attributes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkDeleteBookingCustomAttributesResponse>`](../../doc/models/bulk-delete-booking-custom-attributes-response.md)

## Example Usage

```csharp
var bodyValues = new Dictionary<string, BookingCustomAttributeDeleteRequest>();


var bodyValues0 = new BookingCustomAttributeDeleteRequest.Builder(
        "booking_id8",
        "key4")
    .Build();
bodyValues.Add("key0",bodyValues0);

var bodyValues1 = new BookingCustomAttributeDeleteRequest.Builder(
        "booking_id9",
        "key5")
    .Build();
bodyValues.Add("key1",bodyValues1);

var body = new BulkDeleteBookingCustomAttributesRequest.Builder(
        bodyValues)
    .Build();

try
{
    BulkDeleteBookingCustomAttributesResponse result = await bookingCustomAttributesApi.BulkDeleteBookingCustomAttributesAsync(body);
}
catch (ApiException e){};
```


# Bulk Upsert Booking Custom Attributes

Bulk upserts bookings custom attributes.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
BulkUpsertBookingCustomAttributesAsync(
    Models.BulkUpsertBookingCustomAttributesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkUpsertBookingCustomAttributesRequest`](../../doc/models/bulk-upsert-booking-custom-attributes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpsertBookingCustomAttributesResponse>`](../../doc/models/bulk-upsert-booking-custom-attributes-response.md)

## Example Usage

```csharp
var bodyValues = new Dictionary<string, BookingCustomAttributeUpsertRequest>();


var bodyValues0CustomAttribute = new CustomAttribute.Builder()
    .Build();
var bodyValues0 = new BookingCustomAttributeUpsertRequest.Builder(
        "booking_id8",
        bodyValues0CustomAttribute)
    .Build();
bodyValues.Add("key0",bodyValues0);

var bodyValues1CustomAttribute = new CustomAttribute.Builder()
    .Build();
var bodyValues1 = new BookingCustomAttributeUpsertRequest.Builder(
        "booking_id9",
        bodyValues1CustomAttribute)
    .Build();
bodyValues.Add("key1",bodyValues1);

var body = new BulkUpsertBookingCustomAttributesRequest.Builder(
        bodyValues)
    .Build();

try
{
    BulkUpsertBookingCustomAttributesResponse result = await bookingCustomAttributesApi.BulkUpsertBookingCustomAttributesAsync(body);
}
catch (ApiException e){};
```


# List Booking Custom Attributes

Lists a booking's custom attributes.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
ListBookingCustomAttributesAsync(
    string bookingId,
    int? limit = null,
    string cursor = null,
    bool? withDefinitions = false)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the target [booking](../../doc/models/booking.md). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single paged response. This limit is advisory.<br>The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.<br>The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `cursor` | `string` | Query, Optional | The cursor returned in the paged response from the previous call to this endpoint.<br>Provide this cursor to retrieve the next page of results for your original request. For more<br>information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `withDefinitions` | `bool?` | Query, Optional | Indicates whether to return the [custom attribute definition](../../doc/models/custom-attribute-definition.md) in the `definition` field of each<br>custom attribute. Set this parameter to `true` to get the name and description of each custom<br>attribute, information about the data type, or other definition details. The default value is `false`.<br>**Default**: `false` |

## Response Type

[`Task<Models.ListBookingCustomAttributesResponse>`](../../doc/models/list-booking-custom-attributes-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
bool? withDefinitions = false;

try
{
    ListBookingCustomAttributesResponse result = await bookingCustomAttributesApi.ListBookingCustomAttributesAsync(bookingId, null, null, withDefinitions);
}
catch (ApiException e){};
```


# Delete Booking Custom Attribute

Deletes a bookings custom attribute.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
DeleteBookingCustomAttributeAsync(
    string bookingId,
    string key)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the target [booking](../../doc/models/booking.md). |
| `key` | `string` | Template, Required | The key of the custom attribute to delete. This key must match the `key` of a custom<br>attribute definition in the Square seller account. If the requesting application is not the<br>definition owner, you must use the qualified key. |

## Response Type

[`Task<Models.DeleteBookingCustomAttributeResponse>`](../../doc/models/delete-booking-custom-attribute-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
string key = "key0";

try
{
    DeleteBookingCustomAttributeResponse result = await bookingCustomAttributesApi.DeleteBookingCustomAttributeAsync(bookingId, key);
}
catch (ApiException e){};
```


# Retrieve Booking Custom Attribute

Retrieves a bookings custom attribute.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.

```csharp
RetrieveBookingCustomAttributeAsync(
    string bookingId,
    string key,
    bool? withDefinition = false,
    int? version = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the target [booking](../../doc/models/booking.md). |
| `key` | `string` | Template, Required | The key of the custom attribute to retrieve. This key must match the `key` of a custom<br>attribute definition in the Square seller account. If the requesting application is not the<br>definition owner, you must use the qualified key. |
| `withDefinition` | `bool?` | Query, Optional | Indicates whether to return the [custom attribute definition](../../doc/models/custom-attribute-definition.md) in the `definition` field of<br>the custom attribute. Set this parameter to `true` to get the name and description of the custom<br>attribute, information about the data type, or other definition details. The default value is `false`.<br>**Default**: `false` |
| `version` | `int?` | Query, Optional | The current version of the custom attribute, which is used for strongly consistent reads to<br>guarantee that you receive the most up-to-date data. When included in the request, Square<br>returns the specified version or a higher version if one exists. If the specified version is<br>higher than the current version, Square returns a `BAD_REQUEST` error. |

## Response Type

[`Task<Models.RetrieveBookingCustomAttributeResponse>`](../../doc/models/retrieve-booking-custom-attribute-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
string key = "key0";
bool? withDefinition = false;

try
{
    RetrieveBookingCustomAttributeResponse result = await bookingCustomAttributesApi.RetrieveBookingCustomAttributeAsync(bookingId, key, withDefinition, null);
}
catch (ApiException e){};
```


# Upsert Booking Custom Attribute

Upserts a bookings custom attribute.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.

```csharp
UpsertBookingCustomAttributeAsync(
    string bookingId,
    string key,
    Models.UpsertBookingCustomAttributeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bookingId` | `string` | Template, Required | The ID of the target [booking](../../doc/models/booking.md). |
| `key` | `string` | Template, Required | The key of the custom attribute to create or update. This key must match the `key` of a<br>custom attribute definition in the Square seller account. If the requesting application is not<br>the definition owner, you must use the qualified key. |
| `body` | [`Models.UpsertBookingCustomAttributeRequest`](../../doc/models/upsert-booking-custom-attribute-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpsertBookingCustomAttributeResponse>`](../../doc/models/upsert-booking-custom-attribute-response.md)

## Example Usage

```csharp
string bookingId = "booking_id4";
string key = "key0";
var bodyCustomAttribute = new CustomAttribute.Builder()
    .Build();
var body = new UpsertBookingCustomAttributeRequest.Builder(
        bodyCustomAttribute)
    .Build();

try
{
    UpsertBookingCustomAttributeResponse result = await bookingCustomAttributesApi.UpsertBookingCustomAttributeAsync(bookingId, key, body);
}
catch (ApiException e){};
```

