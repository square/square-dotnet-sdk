# Orders

```csharp
IOrdersApi ordersApi = client.OrdersApi;
```

## Class Name

`OrdersApi`

## Methods

* [Create Order](/doc/orders.md#create-order)
* [Batch Retrieve Orders](/doc/orders.md#batch-retrieve-orders)
* [Update Order](/doc/orders.md#update-order)
* [Search Orders](/doc/orders.md#search-orders)
* [Pay Order](/doc/orders.md#pay-order)

## Create Order

Creates a new [Order](#type-order) which can include information on products for
purchase and settings to apply to the purchase.

To pay for a created order, please refer to the [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders)
guide.

You can modify open orders using the [UpdateOrder](#endpoint-orders-updateorder) endpoint.

To learn more about the Orders API, see the
[Orders API Overview](https://developer.squareup.com/docs/orders-api/what-it-does).

```csharp
CreateOrderAsync(string locationId, Models.CreateOrderRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the business location to associate the order with. |
| `body` | [`Models.CreateOrderRequest`](/doc/models/create-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateOrderResponse>`](/doc/models/create-order-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
var body = new CreateOrderRequest.Builder()
    .Build();

try
{
    CreateOrderResponse result = ordersApi.CreateOrderAsync(locationId, body).Result;
}
catch (ApiException e){};
```

## Batch Retrieve Orders

Retrieves a set of [Order](#type-order)s by their IDs.

If a given Order ID does not exist, the ID is ignored instead of generating an error.

```csharp
BatchRetrieveOrdersAsync(string locationId, Models.BatchRetrieveOrdersRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the orders' associated location. |
| `body` | [`Models.BatchRetrieveOrdersRequest`](/doc/models/batch-retrieve-orders-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.BatchRetrieveOrdersResponse>`](/doc/models/batch-retrieve-orders-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyOrderIds = new List<string>();
bodyOrderIds.Add("CAISEM82RcpmcFBM0TfOyiHV3es");
bodyOrderIds.Add("CAISENgvlJ6jLWAzERDzjyHVybY");
var body = new BatchRetrieveOrdersRequest.Builder(
        bodyOrderIds)
    .Build();

try
{
    BatchRetrieveOrdersResponse result = ordersApi.BatchRetrieveOrdersAsync(locationId, body).Result;
}
catch (ApiException e){};
```

## Update Order

Updates an open [Order](#type-order) by adding, replacing, or deleting
fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.

An UpdateOrder request requires the following:

- The `order_id` in the endpoint path, identifying the order to update.
- The latest `version` of the order to update.
- The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders#sparse-order-objects)
containing only the fields to update and the version the update is
being applied to.
- If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation)
identifying fields to clear.

To pay for an order, please refer to the [Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders) guide.

To learn more about the Orders API, see the
[Orders API Overview](https://developer.squareup.com/docs/orders-api/what-it-does).

```csharp
UpdateOrderAsync(string locationId, string orderId, Models.UpdateOrderRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the order's associated location. |
| `orderId` | `string` | Template, Required | The ID of the order to update. |
| `body` | [`Models.UpdateOrderRequest`](/doc/models/update-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateOrderResponse>`](/doc/models/update-order-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string orderId = "order_id6";
var body = new UpdateOrderRequest.Builder()
    .Build();

try
{
    UpdateOrderResponse result = ordersApi.UpdateOrderAsync(locationId, orderId, body).Result;
}
catch (ApiException e){};
```

## Search Orders

Search all orders for one or more locations. Orders include all sales,
returns, and exchanges regardless of how or when they entered the Square
Ecosystem (e.g. Point of Sale, Invoices, Connect APIs, etc).

SearchOrders requests need to specify which locations to search and define a
[`SearchOrdersQuery`](#type-searchordersquery) object which controls
how to sort or filter the results. Your SearchOrdersQuery can:

  Set filter criteria.
  Set sort order.
  Determine whether to return results as complete Order objects, or as
[OrderEntry](#type-orderentry) objects.

Note that details for orders processed with Square Point of Sale while in
offline mode may not be transmitted to Square for up to 72 hours. Offline
orders have a `created_at` value that reflects the time the order was created,
not the time it was subsequently transmitted to Square.

```csharp
SearchOrdersAsync(Models.SearchOrdersRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchOrdersRequest`](/doc/models/search-orders-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchOrdersResponse>`](/doc/models/search-orders-response.md)

### Example Usage

```csharp
var bodyLocationIds = new List<string>();
bodyLocationIds.Add("057P5VYJ4A5X1");
bodyLocationIds.Add("18YC4JDH91E1H");
var bodyQueryFilterStateFilterStates = new List<string>();
bodyQueryFilterStateFilterStates.Add("COMPLETED");
var bodyQueryFilterStateFilter = new SearchOrdersStateFilter.Builder(
        bodyQueryFilterStateFilterStates)
    .Build();
var bodyQueryFilterDateTimeFilterClosedAt = new TimeRange.Builder()
    .StartAt("2018-03-03T20:00:00+00:00")
    .EndAt("2019-03-04T21:54:45+00:00")
    .Build();
var bodyQueryFilterDateTimeFilter = new SearchOrdersDateTimeFilter.Builder()
    .ClosedAt(bodyQueryFilterDateTimeFilterClosedAt)
    .Build();
var bodyQueryFilter = new SearchOrdersFilter.Builder()
    .StateFilter(bodyQueryFilterStateFilter)
    .DateTimeFilter(bodyQueryFilterDateTimeFilter)
    .Build();
var bodyQuerySort = new SearchOrdersSort.Builder(
        "CLOSED_AT")
    .SortOrder("DESC")
    .Build();
var bodyQuery = new SearchOrdersQuery.Builder()
    .Filter(bodyQueryFilter)
    .Sort(bodyQuerySort)
    .Build();
var body = new SearchOrdersRequest.Builder()
    .LocationIds(bodyLocationIds)
    .Query(bodyQuery)
    .Limit(3)
    .ReturnEntries(true)
    .Build();

try
{
    SearchOrdersResponse result = ordersApi.SearchOrdersAsync(body).Result;
}
catch (ApiException e){};
```

## Pay Order

Pay for an [order](#type-order) using one or more approved [payments](#type-payment),
or settle an order with a total of `0`.

The total of the `payment_ids` listed in the request must be equal to the order
total. Orders with a total amount of `0` can be marked as paid by specifying an empty
array of `payment_ids` in the request.

To be used with PayOrder, a payment must:

- Reference the order by specifying the `order_id` when [creating the payment](#endpoint-payments-createpayment).
Any approved payments that reference the same `order_id` not specified in the
`payment_ids` will be canceled.
- Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments#delayed-capture).
Using a delayed capture payment with PayOrder will complete the approved payment.

Learn how to [pay for orders with a single payment using the Payments API](https://developer.squareup.com/docs/orders-api/pay-for-orders).

```csharp
PayOrderAsync(string orderId, Models.PayOrderRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the order being paid. |
| `body` | [`Models.PayOrderRequest`](/doc/models/pay-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.PayOrderResponse>`](/doc/models/pay-order-response.md)

### Example Usage

```csharp
string orderId = "order_id6";
var bodyPaymentIds = new List<string>();
bodyPaymentIds.Add("EnZdNAlWCmfh6Mt5FMNST1o7taB");
bodyPaymentIds.Add("0LRiVlbXVwe8ozu4KbZxd12mvaB");
var body = new PayOrderRequest.Builder(
        "c043a359-7ad9-4136-82a9-c3f1d66dcbff")
    .PaymentIds(bodyPaymentIds)
    .Build();

try
{
    PayOrderResponse result = ordersApi.PayOrderAsync(orderId, body).Result;
}
catch (ApiException e){};
```

