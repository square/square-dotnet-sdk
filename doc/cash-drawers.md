# Cash Drawers

```csharp
ICashDrawersApi cashDrawersApi = client.CashDrawersApi;
```

## Class Name

`CashDrawersApi`

## Methods

* [List Cash Drawer Shifts](/doc/cash-drawers.md#list-cash-drawer-shifts)
* [Retrieve Cash Drawer Shift](/doc/cash-drawers.md#retrieve-cash-drawer-shift)
* [List Cash Drawer Shift Events](/doc/cash-drawers.md#list-cash-drawer-shift-events)

## List Cash Drawer Shifts

Provides the details for all of the cash drawer shifts for a location
in a date range.

```csharp
ListCashDrawerShiftsAsync(
    string locationId,
    string sortOrder = null,
    string beginTime = null,
    string endTime = null,
    int? limit = null,
    string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Required | The ID of the location to query for a list of cash drawer shifts. |
| `sortOrder` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which cash drawer shifts are listed in the response,<br>based on their opened_at field. Default value: ASC |
| `beginTime` | `string` | Query, Optional | The inclusive start time of the query on opened_at, in ISO 8601 format. |
| `endTime` | `string` | Query, Optional | The exclusive end date of the query on opened_at, in ISO 8601 format. |
| `limit` | `int?` | Query, Optional | Number of cash drawer shift events in a page of results (200 by<br>default, 1000 max). |
| `cursor` | `string` | Query, Optional | Opaque cursor for fetching the next page of results. |

### Response Type

[`Task<Models.ListCashDrawerShiftsResponse>`](/doc/models/list-cash-drawer-shifts-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string sortOrder = "DESC";
string beginTime = "begin_time2";
string endTime = "end_time2";
int? limit = 172;
string cursor = "cursor6";

try
{
    ListCashDrawerShiftsResponse result = await cashDrawersApi.ListCashDrawerShiftsAsync(locationId, sortOrder, beginTime, endTime, limit, cursor);
}
catch (ApiException e){};
```

## Retrieve Cash Drawer Shift

Provides the summary details for a single cash drawer shift. See
RetrieveCashDrawerShiftEvents for a list of cash drawer shift events.

```csharp
RetrieveCashDrawerShiftAsync(string locationId, string shiftId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Required | The ID of the location to retrieve cash drawer shifts from. |
| `shiftId` | `string` | Template, Required | The shift ID. |

### Response Type

[`Task<Models.RetrieveCashDrawerShiftResponse>`](/doc/models/retrieve-cash-drawer-shift-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string shiftId = "shift_id0";

try
{
    RetrieveCashDrawerShiftResponse result = await cashDrawersApi.RetrieveCashDrawerShiftAsync(locationId, shiftId);
}
catch (ApiException e){};
```

## List Cash Drawer Shift Events

Provides a paginated list of events for a single cash drawer shift.

```csharp
ListCashDrawerShiftEventsAsync(
    string locationId,
    string shiftId,
    int? limit = null,
    string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Required | The ID of the location to list cash drawer shifts for. |
| `shiftId` | `string` | Template, Required | The shift ID. |
| `limit` | `int?` | Query, Optional | Number of resources to be returned in a page of results (200 by<br>default, 1000 max). |
| `cursor` | `string` | Query, Optional | Opaque cursor for fetching the next page of results. |

### Response Type

[`Task<Models.ListCashDrawerShiftEventsResponse>`](/doc/models/list-cash-drawer-shift-events-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string shiftId = "shift_id0";
int? limit = 172;
string cursor = "cursor6";

try
{
    ListCashDrawerShiftEventsResponse result = await cashDrawersApi.ListCashDrawerShiftEventsAsync(locationId, shiftId, limit, cursor);
}
catch (ApiException e){};
```

