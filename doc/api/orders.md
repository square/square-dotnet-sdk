# Orders

```csharp
IOrdersApi ordersApi = client.OrdersApi;
```

## Class Name

`OrdersApi`

## Methods

* [Create Order](../../doc/api/orders.md#create-order)
* [Batch Retrieve Orders](../../doc/api/orders.md#batch-retrieve-orders)
* [Calculate Order](../../doc/api/orders.md#calculate-order)
* [Clone Order](../../doc/api/orders.md#clone-order)
* [Search Orders](../../doc/api/orders.md#search-orders)
* [Retrieve Order](../../doc/api/orders.md#retrieve-order)
* [Update Order](../../doc/api/orders.md#update-order)
* [Pay Order](../../doc/api/orders.md#pay-order)


# Create Order

Creates a new [order](../../doc/models/order.md) that can include information about products for
purchase and settings to apply to the purchase.

To pay for a created order, see
[Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).

You can modify open orders using the [UpdateOrder](../../doc/api/orders.md#update-order) endpoint.

```csharp
CreateOrderAsync(
    Models.CreateOrderRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateOrderRequest`](../../doc/models/create-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateOrderResponse>`](../../doc/models/create-order-response.md)

## Example Usage

```csharp
var bodyOrderLineItems = new List<OrderLineItem>();

var bodyOrderLineItems0BasePriceMoney = new Money.Builder()
    .Amount(1599L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems0 = new OrderLineItem.Builder(
        "1")
    .Name("New York Strip Steak")
    .BasePriceMoney(bodyOrderLineItems0BasePriceMoney)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems0);

var bodyOrderLineItems1Modifiers = new List<OrderLineItemModifier>();

var bodyOrderLineItems1Modifiers0 = new OrderLineItemModifier.Builder()
    .CatalogObjectId("CHQX7Y4KY6N5KINJKZCFURPZ")
    .Build();
bodyOrderLineItems1Modifiers.Add(bodyOrderLineItems1Modifiers0);

var bodyOrderLineItems1AppliedDiscounts = new List<OrderLineItemAppliedDiscount>();

var bodyOrderLineItems1AppliedDiscounts0 = new OrderLineItemAppliedDiscount.Builder(
        "one-dollar-off")
    .Build();
bodyOrderLineItems1AppliedDiscounts.Add(bodyOrderLineItems1AppliedDiscounts0);

var bodyOrderLineItems1 = new OrderLineItem.Builder(
        "2")
    .CatalogObjectId("BEMYCSMIJL46OCDV4KYIKXIB")
    .Modifiers(bodyOrderLineItems1Modifiers)
    .AppliedDiscounts(bodyOrderLineItems1AppliedDiscounts)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems1);

var bodyOrderTaxes = new List<OrderLineItemTax>();

var bodyOrderTaxes0 = new OrderLineItemTax.Builder()
    .Uid("state-sales-tax")
    .Name("State Sales Tax")
    .Percentage("9")
    .Scope("ORDER")
    .Build();
bodyOrderTaxes.Add(bodyOrderTaxes0);

var bodyOrderDiscounts = new List<OrderLineItemDiscount>();

var bodyOrderDiscounts0 = new OrderLineItemDiscount.Builder()
    .Uid("labor-day-sale")
    .Name("Labor Day Sale")
    .Percentage("5")
    .Scope("ORDER")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts0);

var bodyOrderDiscounts1 = new OrderLineItemDiscount.Builder()
    .Uid("membership-discount")
    .CatalogObjectId("DB7L55ZH2BGWI4H23ULIWOQ7")
    .Scope("ORDER")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts1);

var bodyOrderDiscounts2AmountMoney = new Money.Builder()
    .Amount(100L)
    .Currency("USD")
    .Build();
var bodyOrderDiscounts2 = new OrderLineItemDiscount.Builder()
    .Uid("one-dollar-off")
    .Name("Sale - $1.00 off")
    .AmountMoney(bodyOrderDiscounts2AmountMoney)
    .Scope("LINE_ITEM")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts2);

var bodyOrder = new Order.Builder(
        "057P5VYJ4A5X1")
    .ReferenceId("my-order-001")
    .LineItems(bodyOrderLineItems)
    .Taxes(bodyOrderTaxes)
    .Discounts(bodyOrderDiscounts)
    .Build();
var body = new CreateOrderRequest.Builder()
    .Order(bodyOrder)
    .IdempotencyKey("8193148c-9586-11e6-99f9-28cfe92138cf")
    .Build();

try
{
    CreateOrderResponse result = await ordersApi.CreateOrderAsync(body);
}
catch (ApiException e){};
```


# Batch Retrieve Orders

Retrieves a set of [orders](../../doc/models/order.md) by their IDs.

If a given order ID does not exist, the ID is ignored instead of generating an error.

```csharp
BatchRetrieveOrdersAsync(
    Models.BatchRetrieveOrdersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchRetrieveOrdersRequest`](../../doc/models/batch-retrieve-orders-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveOrdersResponse>`](../../doc/models/batch-retrieve-orders-response.md)

## Example Usage

```csharp
var bodyOrderIds = new IList<string>();
bodyOrderIds.Add("CAISEM82RcpmcFBM0TfOyiHV3es");
bodyOrderIds.Add("CAISENgvlJ6jLWAzERDzjyHVybY");
var body = new BatchRetrieveOrdersRequest.Builder(
        bodyOrderIds)
    .LocationId("057P5VYJ4A5X1")
    .Build();

try
{
    BatchRetrieveOrdersResponse result = await ordersApi.BatchRetrieveOrdersAsync(body);
}
catch (ApiException e){};
```


# Calculate Order

Enables applications to preview order pricing without creating an order.

```csharp
CalculateOrderAsync(
    Models.CalculateOrderRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CalculateOrderRequest`](../../doc/models/calculate-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CalculateOrderResponse>`](../../doc/models/calculate-order-response.md)

## Example Usage

```csharp
var bodyOrderLineItems = new List<OrderLineItem>();

var bodyOrderLineItems0BasePriceMoney = new Money.Builder()
    .Amount(500L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems0 = new OrderLineItem.Builder(
        "1")
    .Name("Item 1")
    .BasePriceMoney(bodyOrderLineItems0BasePriceMoney)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems0);

var bodyOrderLineItems1BasePriceMoney = new Money.Builder()
    .Amount(300L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems1 = new OrderLineItem.Builder(
        "2")
    .Name("Item 2")
    .BasePriceMoney(bodyOrderLineItems1BasePriceMoney)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems1);

var bodyOrderDiscounts = new List<OrderLineItemDiscount>();

var bodyOrderDiscounts0 = new OrderLineItemDiscount.Builder()
    .Name("50% Off")
    .Percentage("50")
    .Scope("ORDER")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts0);

var bodyOrder = new Order.Builder(
        "D7AVYMEAPJ3A3")
    .LineItems(bodyOrderLineItems)
    .Discounts(bodyOrderDiscounts)
    .Build();
var body = new CalculateOrderRequest.Builder(
        bodyOrder)
    .Build();

try
{
    CalculateOrderResponse result = await ordersApi.CalculateOrderAsync(body);
}
catch (ApiException e){};
```


# Clone Order

Creates a new order, in the `DRAFT` state, by duplicating an existing order. The newly created order has
only the core fields (such as line items, taxes, and discounts) copied from the original order.

```csharp
CloneOrderAsync(
    Models.CloneOrderRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CloneOrderRequest`](../../doc/models/clone-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CloneOrderResponse>`](../../doc/models/clone-order-response.md)

## Example Usage

```csharp
var body = new CloneOrderRequest.Builder(
        "ZAISEM52YcpmcWAzERDOyiWS123")
    .Version(3)
    .IdempotencyKey("UNIQUE_STRING")
    .Build();

try
{
    CloneOrderResponse result = await ordersApi.CloneOrderAsync(body);
}
catch (ApiException e){};
```


# Search Orders

Search all orders for one or more locations. Orders include all sales,
returns, and exchanges regardless of how or when they entered the Square
ecosystem (such as Point of Sale, Invoices, and Connect APIs).

`SearchOrders` requests need to specify which locations to search and define a
[SearchOrdersQuery](../../doc/models/search-orders-query.md) object that controls
how to sort or filter the results. Your `SearchOrdersQuery` can:

Set filter criteria.
Set the sort order.
Determine whether to return results as complete `Order` objects or as
[OrderEntry](../../doc/models/order-entry.md) objects.

Note that details for orders processed with Square Point of Sale while in
offline mode might not be transmitted to Square for up to 72 hours. Offline
orders have a `created_at` value that reflects the time the order was created,
not the time it was subsequently transmitted to Square.

```csharp
SearchOrdersAsync(
    Models.SearchOrdersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchOrdersRequest`](../../doc/models/search-orders-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchOrdersResponse>`](../../doc/models/search-orders-response.md)

## Example Usage

```csharp
var bodyLocationIds = new IList<string>();
bodyLocationIds.Add("057P5VYJ4A5X1");
bodyLocationIds.Add("18YC4JDH91E1H");
var bodyQueryFilterStateFilterStates = new IList<string>();
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
    SearchOrdersResponse result = await ordersApi.SearchOrdersAsync(body);
}
catch (ApiException e){};
```


# Retrieve Order

Retrieves an [Order](../../doc/models/order.md) by ID.

```csharp
RetrieveOrderAsync(
    string orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the order to retrieve. |

## Response Type

[`Task<Models.RetrieveOrderResponse>`](../../doc/models/retrieve-order-response.md)

## Example Usage

```csharp
string orderId = "order_id6";

try
{
    RetrieveOrderResponse result = await ordersApi.RetrieveOrderAsync(orderId);
}
catch (ApiException e){};
```


# Update Order

Updates an open [order](../../doc/models/order.md) by adding, replacing, or deleting
fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.

An `UpdateOrder` request requires the following:

- The `order_id` in the endpoint path, identifying the order to update.
- The latest `version` of the order to update.
- The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects)
  containing only the fields to update and the version to which the update is
  being applied.
- If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders#on-dot-notation)
  identifying the fields to clear.

To pay for an order, see
[Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).

```csharp
UpdateOrderAsync(
    string orderId,
    Models.UpdateOrderRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the order to update. |
| `body` | [`Models.UpdateOrderRequest`](../../doc/models/update-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateOrderResponse>`](../../doc/models/update-order-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
var body = new UpdateOrderRequest.Builder()
    .Build();

try
{
    UpdateOrderResponse result = await ordersApi.UpdateOrderAsync(orderId, body);
}
catch (ApiException e){};
```


# Pay Order

Pay for an [order](../../doc/models/order.md) using one or more approved [payments](../../doc/models/payment.md)
or settle an order with a total of `0`.

The total of the `payment_ids` listed in the request must be equal to the order
total. Orders with a total amount of `0` can be marked as paid by specifying an empty
array of `payment_ids` in the request.

To be used with `PayOrder`, a payment must:

- Reference the order by specifying the `order_id` when [creating the payment](../../doc/api/payments.md#create-payment).
  Any approved payments that reference the same `order_id` not specified in the
  `payment_ids` is canceled.
- Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture).
  Using a delayed capture payment with `PayOrder` completes the approved payment.

```csharp
PayOrderAsync(
    string orderId,
    Models.PayOrderRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the order being paid. |
| `body` | [`Models.PayOrderRequest`](../../doc/models/pay-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.PayOrderResponse>`](../../doc/models/pay-order-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
var bodyPaymentIds = new IList<string>();
bodyPaymentIds.Add("EnZdNAlWCmfh6Mt5FMNST1o7taB");
bodyPaymentIds.Add("0LRiVlbXVwe8ozu4KbZxd12mvaB");
var body = new PayOrderRequest.Builder(
        "c043a359-7ad9-4136-82a9-c3f1d66dcbff")
    .PaymentIds(bodyPaymentIds)
    .Build();

try
{
    PayOrderResponse result = await ordersApi.PayOrderAsync(orderId, body);
}
catch (ApiException e){};
```

