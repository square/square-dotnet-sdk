# Customer Segments

```csharp
ICustomerSegmentsApi customerSegmentsApi = client.CustomerSegmentsApi;
```

## Class Name

`CustomerSegmentsApi`

## Methods

* [List Customer Segments](../../doc/api/customer-segments.md#list-customer-segments)
* [Retrieve Customer Segment](../../doc/api/customer-segments.md#retrieve-customer-segment)


# List Customer Segments

Retrieves the list of customer segments of a business.

```csharp
ListCustomerSegmentsAsync(
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by previous calls to `ListCustomerSegments`.<br>This cursor is used to retrieve the next set of query results.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.<br>If the specified limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Response Type

[`Task<Models.ListCustomerSegmentsResponse>`](../../doc/models/list-customer-segments-response.md)

## Example Usage

```csharp
try
{
    ListCustomerSegmentsResponse result = await customerSegmentsApi.ListCustomerSegmentsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Customer Segment

Retrieves a specific customer segment as identified by the `segment_id` value.

```csharp
RetrieveCustomerSegmentAsync(
    string segmentId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `segmentId` | `string` | Template, Required | The Square-issued ID of the customer segment. |

## Response Type

[`Task<Models.RetrieveCustomerSegmentResponse>`](../../doc/models/retrieve-customer-segment-response.md)

## Example Usage

```csharp
string segmentId = "segment_id4";
try
{
    RetrieveCustomerSegmentResponse result = await customerSegmentsApi.RetrieveCustomerSegmentAsync(segmentId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

