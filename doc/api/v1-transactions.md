# V1 Transactions

```csharp
IV1TransactionsApi v1TransactionsApi = client.V1TransactionsApi;
```

## Class Name

`V1TransactionsApi`

## Methods

* [V1 List Orders](../../doc/api/v1-transactions.md#v1-list-orders)
* [V1 Retrieve Order](../../doc/api/v1-transactions.md#v1-retrieve-order)
* [V1 Update Order](../../doc/api/v1-transactions.md#v1-update-order)


# V1 List Orders

**This endpoint is deprecated.**

Provides summary information for a merchant's online store orders.

```csharp
V1ListOrdersAsync(
    string locationId,
    string order = null,
    int? limit = null,
    string batchToken = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list online store orders for. |
| `order` | [`string`](../../doc/models/sort-order.md) | Query, Optional | The order in which payments are listed in the response. |
| `limit` | `int?` | Query, Optional | The maximum number of payments to return in a single response. This value cannot exceed 200. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

## Response Type

[`Task<List<Models.V1Order>>`](../../doc/models/v1-order.md)

## Example Usage

```csharp
string locationId = "location_id4";
try
{
    List<V1Order> result = await v1TransactionsApi.V1ListOrdersAsync(locationId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# V1 Retrieve Order

**This endpoint is deprecated.**

Provides comprehensive information for a single online store order, including the order's history.

```csharp
V1RetrieveOrderAsync(
    string locationId,
    string orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the order's associated location. |
| `orderId` | `string` | Template, Required | The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint |

## Response Type

[`Task<Models.V1Order>`](../../doc/models/v1-order.md)

## Example Usage

```csharp
string locationId = "location_id4";
string orderId = "order_id6";
try
{
    V1Order result = await v1TransactionsApi.V1RetrieveOrderAsync(
        locationId,
        orderId
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# V1 Update Order

**This endpoint is deprecated.**

Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:

```csharp
V1UpdateOrderAsync(
    string locationId,
    string orderId,
    Models.V1UpdateOrderRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the order's associated location. |
| `orderId` | `string` | Template, Required | The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint |
| `body` | [`V1UpdateOrderRequest`](../../doc/models/v1-update-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.V1Order>`](../../doc/models/v1-order.md)

## Example Usage

```csharp
string locationId = "location_id4";
string orderId = "order_id6";
Models.V1UpdateOrderRequest body = new Models.V1UpdateOrderRequest.Builder(
    "REFUND"
)
.Build();

try
{
    V1Order result = await v1TransactionsApi.V1UpdateOrderAsync(
        locationId,
        orderId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

