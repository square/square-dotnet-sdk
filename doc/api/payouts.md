# Payouts

```csharp
IPayoutsApi payoutsApi = client.PayoutsApi;
```

## Class Name

`PayoutsApi`

## Methods

* [List Payouts](../../doc/api/payouts.md#list-payouts)
* [Get Payout](../../doc/api/payouts.md#get-payout)
* [List Payout Entries](../../doc/api/payouts.md#list-payout-entries)


# List Payouts

Retrieves a list of all payouts for the default location.
You can filter payouts by location ID, status, time range, and order them in ascending or descending order.
To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.

```csharp
ListPayoutsAsync(
    string locationId = null,
    string status = null,
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Optional | The ID of the location for which to list the payouts.<br>By default, payouts are returned for the default (main) location associated with the seller. |
| `status` | [`string`](../../doc/models/payout-status.md) | Query, Optional | If provided, only payouts with the given status are returned. |
| `beginTime` | `string` | Query, Optional | The timestamp for the beginning of the payout creation time, in RFC 3339 format.<br>Inclusive. Default: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The timestamp for the end of the payout creation time, in RFC 3339 format.<br>Default: The current time. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | The order in which payouts are listed. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).<br>If request parameters change between requests, subsequent results may contain duplicates or missing records. |
| `limit` | `int?` | Query, Optional | The maximum number of results to be returned in a single page.<br>It is possible to receive fewer results than the specified limit on a given page.<br>The default value of 100 is also the maximum allowed value. If the provided value is<br>greater than 100, it is ignored and the default value is used instead.<br>Default: `100` |

## Response Type

[`Task<Models.ListPayoutsResponse>`](../../doc/models/list-payouts-response.md)

## Example Usage

```csharp
try
{
    ListPayoutsResponse result = await payoutsApi.ListPayoutsAsync(null, null, null, null, null, null, null);
}
catch (ApiException e){};
```


# Get Payout

Retrieves details of a specific payout identified by a payout ID.
To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.

```csharp
GetPayoutAsync(
    string payoutId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `payoutId` | `string` | Template, Required | The ID of the payout to retrieve the information for. |

## Response Type

[`Task<Models.GetPayoutResponse>`](../../doc/models/get-payout-response.md)

## Example Usage

```csharp
string payoutId = "payout_id6";

try
{
    GetPayoutResponse result = await payoutsApi.GetPayoutAsync(payoutId);
}
catch (ApiException e){};
```


# List Payout Entries

Retrieves a list of all payout entries for a specific payout.
To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.

```csharp
ListPayoutEntriesAsync(
    string payoutId,
    string sortOrder = null,
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `payoutId` | `string` | Template, Required | The ID of the payout to retrieve the information for. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | The order in which payout entries are listed. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination).<br>If request parameters change between requests, subsequent results may contain duplicates or missing records. |
| `limit` | `int?` | Query, Optional | The maximum number of results to be returned in a single page.<br>It is possible to receive fewer results than the specified limit on a given page.<br>The default value of 100 is also the maximum allowed value. If the provided value is<br>greater than 100, it is ignored and the default value is used instead.<br>Default: `100` |

## Response Type

[`Task<Models.ListPayoutEntriesResponse>`](../../doc/models/list-payout-entries-response.md)

## Example Usage

```csharp
string payoutId = "payout_id6";

try
{
    ListPayoutEntriesResponse result = await payoutsApi.ListPayoutEntriesAsync(payoutId, null, null, null);
}
catch (ApiException e){};
```

