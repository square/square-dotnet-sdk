# Customer Segments

```csharp
ICustomerSegmentsApi customerSegmentsApi = client.CustomerSegmentsApi;
```

## Class Name

`CustomerSegmentsApi`

## Methods

* [List Customer Segments](/doc/customer-segments.md#list-customer-segments)
* [Retrieve Customer Segment](/doc/customer-segments.md#retrieve-customer-segment)

## List Customer Segments

Retrieves the list of customer segments of a business.

```csharp
ListCustomerSegmentsAsync(string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by previous calls to __ListCustomerSegments__.<br>Used to retrieve the next set of query results.<br><br>See the [Pagination guide](https://developer.squareup.com/docs/docs/working-with-apis/pagination) for more information. |

### Response Type

[`Task<Models.ListCustomerSegmentsResponse>`](/doc/models/list-customer-segments-response.md)

### Example Usage

```csharp
string cursor = "cursor6";

try
{
    ListCustomerSegmentsResponse result = await customerSegmentsApi.ListCustomerSegmentsAsync(cursor);
}
catch (ApiException e){};
```

## Retrieve Customer Segment

Retrieves a specific customer segment as identified by the `segment_id` value.

```csharp
RetrieveCustomerSegmentAsync(string segmentId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `segmentId` | `string` | Template, Required | The Square-issued ID of the customer segment. |

### Response Type

[`Task<Models.RetrieveCustomerSegmentResponse>`](/doc/models/retrieve-customer-segment-response.md)

### Example Usage

```csharp
string segmentId = "segment_id4";

try
{
    RetrieveCustomerSegmentResponse result = await customerSegmentsApi.RetrieveCustomerSegmentAsync(segmentId);
}
catch (ApiException e){};
```

