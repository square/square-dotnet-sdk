# Inventory

```csharp
IInventoryApi inventoryApi = client.InventoryApi;
```

## Class Name

`InventoryApi`

## Methods

* [Deprecated Retrieve Inventory Adjustment](../../doc/api/inventory.md#deprecated-retrieve-inventory-adjustment)
* [Retrieve Inventory Adjustment](../../doc/api/inventory.md#retrieve-inventory-adjustment)
* [Deprecated Batch Change Inventory](../../doc/api/inventory.md#deprecated-batch-change-inventory)
* [Deprecated Batch Retrieve Inventory Changes](../../doc/api/inventory.md#deprecated-batch-retrieve-inventory-changes)
* [Deprecated Batch Retrieve Inventory Counts](../../doc/api/inventory.md#deprecated-batch-retrieve-inventory-counts)
* [Batch Change Inventory](../../doc/api/inventory.md#batch-change-inventory)
* [Batch Retrieve Inventory Changes](../../doc/api/inventory.md#batch-retrieve-inventory-changes)
* [Batch Retrieve Inventory Counts](../../doc/api/inventory.md#batch-retrieve-inventory-counts)
* [Deprecated Retrieve Inventory Physical Count](../../doc/api/inventory.md#deprecated-retrieve-inventory-physical-count)
* [Retrieve Inventory Physical Count](../../doc/api/inventory.md#retrieve-inventory-physical-count)
* [Retrieve Inventory Transfer](../../doc/api/inventory.md#retrieve-inventory-transfer)
* [Retrieve Inventory Count](../../doc/api/inventory.md#retrieve-inventory-count)
* [Retrieve Inventory Changes](../../doc/api/inventory.md#retrieve-inventory-changes)


# Deprecated Retrieve Inventory Adjustment

**This endpoint is deprecated.**

Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL
is updated to conform to the standard convention.

```csharp
DeprecatedRetrieveInventoryAdjustmentAsync(
    string adjustmentId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `adjustmentId` | `string` | Template, Required | ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve. |

## Response Type

[`Task<Models.RetrieveInventoryAdjustmentResponse>`](../../doc/models/retrieve-inventory-adjustment-response.md)

## Example Usage

```csharp
string adjustmentId = "adjustment_id0";
try
{
    RetrieveInventoryAdjustmentResponse result = await inventoryApi.DeprecatedRetrieveInventoryAdjustmentAsync(adjustmentId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Inventory Adjustment

Returns the [InventoryAdjustment](../../doc/models/inventory-adjustment.md) object
with the provided `adjustment_id`.

```csharp
RetrieveInventoryAdjustmentAsync(
    string adjustmentId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `adjustmentId` | `string` | Template, Required | ID of the [InventoryAdjustment](entity:InventoryAdjustment) to retrieve. |

## Response Type

[`Task<Models.RetrieveInventoryAdjustmentResponse>`](../../doc/models/retrieve-inventory-adjustment-response.md)

## Example Usage

```csharp
string adjustmentId = "adjustment_id0";
try
{
    RetrieveInventoryAdjustmentResponse result = await inventoryApi.RetrieveInventoryAdjustmentAsync(adjustmentId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Deprecated Batch Change Inventory

**This endpoint is deprecated.**

Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL
is updated to conform to the standard convention.

```csharp
DeprecatedBatchChangeInventoryAsync(
    Models.BatchChangeInventoryRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchChangeInventoryRequest`](../../doc/models/batch-change-inventory-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchChangeInventoryResponse>`](../../doc/models/batch-change-inventory-response.md)

## Example Usage

```csharp
Models.BatchChangeInventoryRequest body = new Models.BatchChangeInventoryRequest.Builder(
    "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe"
)
.Changes(
    new List<Models.InventoryChange>
    {
        new Models.InventoryChange.Builder()
        .Type("PHYSICAL_COUNT")
        .PhysicalCount(
            new Models.InventoryPhysicalCount.Builder()
            .ReferenceId("1536bfbf-efed-48bf-b17d-a197141b2a92")
            .CatalogObjectId("W62UWFY35CWMYGVWK6TWJDNI")
            .State("IN_STOCK")
            .LocationId("C6W5YS5QM06F5")
            .Quantity("53")
            .TeamMemberId("LRK57NSQ5X7PUD05")
            .OccurredAt("2016-11-16T22:25:24.878Z")
            .Build())
        .Build(),
    })
.IgnoreUnchangedCounts(true)
.Build();

try
{
    BatchChangeInventoryResponse result = await inventoryApi.DeprecatedBatchChangeInventoryAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Deprecated Batch Retrieve Inventory Changes

**This endpoint is deprecated.**

Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL
is updated to conform to the standard convention.

```csharp
DeprecatedBatchRetrieveInventoryChangesAsync(
    Models.BatchRetrieveInventoryChangesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchRetrieveInventoryChangesRequest`](../../doc/models/batch-retrieve-inventory-changes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveInventoryChangesResponse>`](../../doc/models/batch-retrieve-inventory-changes-response.md)

## Example Usage

```csharp
Models.BatchRetrieveInventoryChangesRequest body = new Models.BatchRetrieveInventoryChangesRequest.Builder()
.CatalogObjectIds(
    new List<string>
    {
        "W62UWFY35CWMYGVWK6TWJDNI",
    })
.LocationIds(
    new List<string>
    {
        "C6W5YS5QM06F5",
    })
.Types(
    new List<string>
    {
        "PHYSICAL_COUNT",
    })
.States(
    new List<string>
    {
        "IN_STOCK",
    })
.UpdatedAfter("2016-11-01T00:00:00.000Z")
.UpdatedBefore("2016-12-01T00:00:00.000Z")
.Build();

try
{
    BatchRetrieveInventoryChangesResponse result = await inventoryApi.DeprecatedBatchRetrieveInventoryChangesAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Deprecated Batch Retrieve Inventory Counts

**This endpoint is deprecated.**

Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL
is updated to conform to the standard convention.

```csharp
DeprecatedBatchRetrieveInventoryCountsAsync(
    Models.BatchRetrieveInventoryCountsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchRetrieveInventoryCountsRequest`](../../doc/models/batch-retrieve-inventory-counts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveInventoryCountsResponse>`](../../doc/models/batch-retrieve-inventory-counts-response.md)

## Example Usage

```csharp
Models.BatchRetrieveInventoryCountsRequest body = new Models.BatchRetrieveInventoryCountsRequest.Builder()
.CatalogObjectIds(
    new List<string>
    {
        "W62UWFY35CWMYGVWK6TWJDNI",
    })
.LocationIds(
    new List<string>
    {
        "59TNP9SA8VGDA",
    })
.UpdatedAfter("2016-11-16T00:00:00.000Z")
.Build();

try
{
    BatchRetrieveInventoryCountsResponse result = await inventoryApi.DeprecatedBatchRetrieveInventoryCountsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Batch Change Inventory

Applies adjustments and counts to the provided item quantities.

On success: returns the current calculated counts for all objects
referenced in the request.
On failure: returns a list of related errors.

```csharp
BatchChangeInventoryAsync(
    Models.BatchChangeInventoryRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchChangeInventoryRequest`](../../doc/models/batch-change-inventory-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchChangeInventoryResponse>`](../../doc/models/batch-change-inventory-response.md)

## Example Usage

```csharp
Models.BatchChangeInventoryRequest body = new Models.BatchChangeInventoryRequest.Builder(
    "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe"
)
.Changes(
    new List<Models.InventoryChange>
    {
        new Models.InventoryChange.Builder()
        .Type("PHYSICAL_COUNT")
        .PhysicalCount(
            new Models.InventoryPhysicalCount.Builder()
            .ReferenceId("1536bfbf-efed-48bf-b17d-a197141b2a92")
            .CatalogObjectId("W62UWFY35CWMYGVWK6TWJDNI")
            .State("IN_STOCK")
            .LocationId("C6W5YS5QM06F5")
            .Quantity("53")
            .TeamMemberId("LRK57NSQ5X7PUD05")
            .OccurredAt("2016-11-16T22:25:24.878Z")
            .Build())
        .Build(),
    })
.IgnoreUnchangedCounts(true)
.Build();

try
{
    BatchChangeInventoryResponse result = await inventoryApi.BatchChangeInventoryAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Batch Retrieve Inventory Changes

Returns historical physical counts and adjustments based on the
provided filter criteria.

Results are paginated and sorted in ascending order according their
`occurred_at` timestamp (oldest first).

BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
that cannot be handled by other, simpler endpoints.

```csharp
BatchRetrieveInventoryChangesAsync(
    Models.BatchRetrieveInventoryChangesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchRetrieveInventoryChangesRequest`](../../doc/models/batch-retrieve-inventory-changes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveInventoryChangesResponse>`](../../doc/models/batch-retrieve-inventory-changes-response.md)

## Example Usage

```csharp
Models.BatchRetrieveInventoryChangesRequest body = new Models.BatchRetrieveInventoryChangesRequest.Builder()
.CatalogObjectIds(
    new List<string>
    {
        "W62UWFY35CWMYGVWK6TWJDNI",
    })
.LocationIds(
    new List<string>
    {
        "C6W5YS5QM06F5",
    })
.Types(
    new List<string>
    {
        "PHYSICAL_COUNT",
    })
.States(
    new List<string>
    {
        "IN_STOCK",
    })
.UpdatedAfter("2016-11-01T00:00:00.000Z")
.UpdatedBefore("2016-12-01T00:00:00.000Z")
.Build();

try
{
    BatchRetrieveInventoryChangesResponse result = await inventoryApi.BatchRetrieveInventoryChangesAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Batch Retrieve Inventory Counts

Returns current counts for the provided
[CatalogObject](../../doc/models/catalog-object.md)s at the requested
[Location](../../doc/models/location.md)s.

Results are paginated and sorted in descending order according to their
`calculated_at` timestamp (newest first).

When `updated_after` is specified, only counts that have changed since that
time (based on the server timestamp for the most recent change) are
returned. This allows clients to perform a "sync" operation, for example
in response to receiving a Webhook notification.

```csharp
BatchRetrieveInventoryCountsAsync(
    Models.BatchRetrieveInventoryCountsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchRetrieveInventoryCountsRequest`](../../doc/models/batch-retrieve-inventory-counts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveInventoryCountsResponse>`](../../doc/models/batch-retrieve-inventory-counts-response.md)

## Example Usage

```csharp
Models.BatchRetrieveInventoryCountsRequest body = new Models.BatchRetrieveInventoryCountsRequest.Builder()
.CatalogObjectIds(
    new List<string>
    {
        "W62UWFY35CWMYGVWK6TWJDNI",
    })
.LocationIds(
    new List<string>
    {
        "59TNP9SA8VGDA",
    })
.UpdatedAfter("2016-11-16T00:00:00.000Z")
.Build();

try
{
    BatchRetrieveInventoryCountsResponse result = await inventoryApi.BatchRetrieveInventoryCountsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Deprecated Retrieve Inventory Physical Count

**This endpoint is deprecated.**

Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL
is updated to conform to the standard convention.

```csharp
DeprecatedRetrieveInventoryPhysicalCountAsync(
    string physicalCountId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `physicalCountId` | `string` | Template, Required | ID of the<br>[InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve. |

## Response Type

[`Task<Models.RetrieveInventoryPhysicalCountResponse>`](../../doc/models/retrieve-inventory-physical-count-response.md)

## Example Usage

```csharp
string physicalCountId = "physical_count_id2";
try
{
    RetrieveInventoryPhysicalCountResponse result = await inventoryApi.DeprecatedRetrieveInventoryPhysicalCountAsync(physicalCountId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Inventory Physical Count

Returns the [InventoryPhysicalCount](../../doc/models/inventory-physical-count.md)
object with the provided `physical_count_id`.

```csharp
RetrieveInventoryPhysicalCountAsync(
    string physicalCountId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `physicalCountId` | `string` | Template, Required | ID of the<br>[InventoryPhysicalCount](entity:InventoryPhysicalCount) to retrieve. |

## Response Type

[`Task<Models.RetrieveInventoryPhysicalCountResponse>`](../../doc/models/retrieve-inventory-physical-count-response.md)

## Example Usage

```csharp
string physicalCountId = "physical_count_id2";
try
{
    RetrieveInventoryPhysicalCountResponse result = await inventoryApi.RetrieveInventoryPhysicalCountAsync(physicalCountId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Inventory Transfer

Returns the [InventoryTransfer](../../doc/models/inventory-transfer.md) object
with the provided `transfer_id`.

```csharp
RetrieveInventoryTransferAsync(
    string transferId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `transferId` | `string` | Template, Required | ID of the [InventoryTransfer](entity:InventoryTransfer) to retrieve. |

## Response Type

[`Task<Models.RetrieveInventoryTransferResponse>`](../../doc/models/retrieve-inventory-transfer-response.md)

## Example Usage

```csharp
string transferId = "transfer_id6";
try
{
    RetrieveInventoryTransferResponse result = await inventoryApi.RetrieveInventoryTransferAsync(transferId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Inventory Count

Retrieves the current calculated stock count for a given
[CatalogObject](../../doc/models/catalog-object.md) at a given set of
[Location](../../doc/models/location.md)s. Responses are paginated and unsorted.
For more sophisticated queries, use a batch endpoint.

```csharp
RetrieveInventoryCountAsync(
    string catalogObjectId,
    string locationIds = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `catalogObjectId` | `string` | Template, Required | ID of the [CatalogObject](entity:CatalogObject) to retrieve. |
| `locationIds` | `string` | Query, Optional | The [Location](entity:Location) IDs to look up as a comma-separated<br>list. An empty list queries all locations. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for the original query.<br><br>See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information. |

## Response Type

[`Task<Models.RetrieveInventoryCountResponse>`](../../doc/models/retrieve-inventory-count-response.md)

## Example Usage

```csharp
string catalogObjectId = "catalog_object_id6";
try
{
    RetrieveInventoryCountResponse result = await inventoryApi.RetrieveInventoryCountAsync(catalogObjectId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Inventory Changes

**This endpoint is deprecated.**

Returns a set of physical counts and inventory adjustments for the
provided [CatalogObject](entity:CatalogObject) at the requested
[Location](entity:Location)s.

You can achieve the same result by calling [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges)
and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.

Results are paginated and sorted in descending order according to their
`occurred_at` timestamp (newest first).

There are no limits on how far back the caller can page. This endpoint can be
used to display recent changes for a specific item. For more
sophisticated queries, use a batch endpoint.

```csharp
RetrieveInventoryChangesAsync(
    string catalogObjectId,
    string locationIds = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `catalogObjectId` | `string` | Template, Required | ID of the [CatalogObject](entity:CatalogObject) to retrieve. |
| `locationIds` | `string` | Query, Optional | The [Location](entity:Location) IDs to look up as a comma-separated<br>list. An empty list queries all locations. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for the original query.<br><br>See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information. |

## Response Type

[`Task<Models.RetrieveInventoryChangesResponse>`](../../doc/models/retrieve-inventory-changes-response.md)

## Example Usage

```csharp
string catalogObjectId = "catalog_object_id6";
try
{
    RetrieveInventoryChangesResponse result = await inventoryApi.RetrieveInventoryChangesAsync(catalogObjectId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

