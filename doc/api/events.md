# Events

```csharp
IEventsApi eventsApi = client.EventsApi;
```

## Class Name

`EventsApi`

## Methods

* [Search Events](../../doc/api/events.md#search-events)
* [Disable Events](../../doc/api/events.md#disable-events)
* [Enable Events](../../doc/api/events.md#enable-events)
* [List Event Types](../../doc/api/events.md#list-event-types)


# Search Events

Search for Square API events that occur within a 28-day timeframe.

```csharp
SearchEventsAsync(
    Models.SearchEventsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SearchEventsRequest`](../../doc/models/search-events-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchEventsResponse>`](../../doc/models/search-events-response.md)

## Example Usage

```csharp
Models.SearchEventsRequest body = new Models.SearchEventsRequest.Builder()
.Build();

try
{
    SearchEventsResponse result = await eventsApi.SearchEventsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Disable Events

Disables events to prevent them from being searchable.
All events are disabled by default. You must enable events to make them searchable.
Disabling events for a specific time period prevents them from being searchable, even if you re-enable them later.

```csharp
DisableEventsAsync()
```

## Response Type

[`Task<Models.DisableEventsResponse>`](../../doc/models/disable-events-response.md)

## Example Usage

```csharp
try
{
    DisableEventsResponse result = await eventsApi.DisableEventsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Enable Events

Enables events to make them searchable. Only events that occur while in the enabled state are searchable.

```csharp
EnableEventsAsync()
```

## Response Type

[`Task<Models.EnableEventsResponse>`](../../doc/models/enable-events-response.md)

## Example Usage

```csharp
try
{
    EnableEventsResponse result = await eventsApi.EnableEventsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Event Types

Lists all event types that you can subscribe to as webhooks or query using the Events API.

```csharp
ListEventTypesAsync(
    string apiVersion = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `apiVersion` | `string` | Query, Optional | The API version for which to list event types. Setting this field overrides the default version used by the application. |

## Response Type

[`Task<Models.ListEventTypesResponse>`](../../doc/models/list-event-types-response.md)

## Example Usage

```csharp
try
{
    ListEventTypesResponse result = await eventsApi.ListEventTypesAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

