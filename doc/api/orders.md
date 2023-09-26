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
| `body` | [`CreateOrderRequest`](../../doc/models/create-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateOrderResponse>`](../../doc/models/create-order-response.md)

## Example Usage

```csharp
Models.CreateOrderRequest body = new Models.CreateOrderRequest.Builder()
.Order(
    new Models.Order.Builder(
        "057P5VYJ4A5X1"
    )
    .ReferenceId("my-order-001")
    .LineItems(
        new List<Models.OrderLineItem>
        {
            new Models.OrderLineItem.Builder(
                "1"
            )
            .Name("New York Strip Steak")
            .BasePriceMoney(
                new Models.Money.Builder()
                .Amount(1599L)
                .Currency("USD")
                .Build())
            .Build(),
            new Models.OrderLineItem.Builder(
                "2"
            )
            .CatalogObjectId("BEMYCSMIJL46OCDV4KYIKXIB")
            .Modifiers(
                new List<Models.OrderLineItemModifier>
                {
                    new Models.OrderLineItemModifier.Builder()
                    .CatalogObjectId("CHQX7Y4KY6N5KINJKZCFURPZ")
                    .Build(),
                })
            .AppliedDiscounts(
                new List<Models.OrderLineItemAppliedDiscount>
                {
                    new Models.OrderLineItemAppliedDiscount.Builder(
                        "one-dollar-off"
                    )
                    .Build(),
                })
            .Build(),
        })
    .Taxes(
        new List<Models.OrderLineItemTax>
        {
            new Models.OrderLineItemTax.Builder()
            .Uid("state-sales-tax")
            .Name("State Sales Tax")
            .Percentage("9")
            .Scope("ORDER")
            .Build(),
        })
    .Discounts(
        new List<Models.OrderLineItemDiscount>
        {
            new Models.OrderLineItemDiscount.Builder()
            .Uid("labor-day-sale")
            .Name("Labor Day Sale")
            .Percentage("5")
            .Scope("ORDER")
            .Build(),
            new Models.OrderLineItemDiscount.Builder()
            .Uid("membership-discount")
            .CatalogObjectId("DB7L55ZH2BGWI4H23ULIWOQ7")
            .Scope("ORDER")
            .Build(),
            new Models.OrderLineItemDiscount.Builder()
            .Uid("one-dollar-off")
            .Name("Sale - $1.00 off")
            .AmountMoney(
                new Models.Money.Builder()
                .Amount(100L)
                .Currency("USD")
                .Build())
            .Scope("LINE_ITEM")
            .Build(),
        })
    .Build())
.IdempotencyKey("8193148c-9586-11e6-99f9-28cfe92138cf")
.Build();

try
{
    CreateOrderResponse result = await ordersApi.CreateOrderAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`BatchRetrieveOrdersRequest`](../../doc/models/batch-retrieve-orders-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveOrdersResponse>`](../../doc/models/batch-retrieve-orders-response.md)

## Example Usage

```csharp
Models.BatchRetrieveOrdersRequest body = new Models.BatchRetrieveOrdersRequest.Builder(
    new List<string>
    {
        "CAISEM82RcpmcFBM0TfOyiHV3es",
        "CAISENgvlJ6jLWAzERDzjyHVybY",
    }
)
.LocationId("057P5VYJ4A5X1")
.Build();

try
{
    BatchRetrieveOrdersResponse result = await ordersApi.BatchRetrieveOrdersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`CalculateOrderRequest`](../../doc/models/calculate-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CalculateOrderResponse>`](../../doc/models/calculate-order-response.md)

## Example Usage

```csharp
Models.CalculateOrderRequest body = new Models.CalculateOrderRequest.Builder(
    new Models.Order.Builder(
        "D7AVYMEAPJ3A3"
    )
    .LineItems(
        new List<Models.OrderLineItem>
        {
            new Models.OrderLineItem.Builder(
                "1"
            )
            .Name("Item 1")
            .BasePriceMoney(
                new Models.Money.Builder()
                .Amount(500L)
                .Currency("USD")
                .Build())
            .Build(),
            new Models.OrderLineItem.Builder(
                "2"
            )
            .Name("Item 2")
            .BasePriceMoney(
                new Models.Money.Builder()
                .Amount(300L)
                .Currency("USD")
                .Build())
            .Build(),
        })
    .Discounts(
        new List<Models.OrderLineItemDiscount>
        {
            new Models.OrderLineItemDiscount.Builder()
            .Name("50% Off")
            .Percentage("50")
            .Scope("ORDER")
            .Build(),
        })
    .Build()
)
.Build();

try
{
    CalculateOrderResponse result = await ordersApi.CalculateOrderAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`CloneOrderRequest`](../../doc/models/clone-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CloneOrderResponse>`](../../doc/models/clone-order-response.md)

## Example Usage

```csharp
Models.CloneOrderRequest body = new Models.CloneOrderRequest.Builder(
    "ZAISEM52YcpmcWAzERDOyiWS123"
)
.Version(3)
.IdempotencyKey("UNIQUE_STRING")
.Build();

try
{
    CloneOrderResponse result = await ordersApi.CloneOrderAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`SearchOrdersRequest`](../../doc/models/search-orders-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchOrdersResponse>`](../../doc/models/search-orders-response.md)

## Example Usage

```csharp
Models.SearchOrdersRequest body = new Models.SearchOrdersRequest.Builder()
.LocationIds(
    new List<string>
    {
        "057P5VYJ4A5X1",
        "18YC4JDH91E1H",
    })
.Query(
    new Models.SearchOrdersQuery.Builder()
    .Filter(
        new Models.SearchOrdersFilter.Builder()
        .StateFilter(
            new Models.SearchOrdersStateFilter.Builder(
                new List<string>
                {
                    "COMPLETED",
                }
            )
            .Build())
        .DateTimeFilter(
            new Models.SearchOrdersDateTimeFilter.Builder()
            .ClosedAt(
                new Models.TimeRange.Builder()
                .StartAt("2018-03-03T20:00:00+00:00")
                .EndAt("2019-03-04T21:54:45+00:00")
                .Build())
            .Build())
        .Build())
    .Sort(
        new Models.SearchOrdersSort.Builder(
            "CLOSED_AT"
        )
        .SortOrder("DESC")
        .Build())
    .Build())
.Limit(3)
.ReturnEntries(true)
.Build();

try
{
    SearchOrdersResponse result = await ordersApi.SearchOrdersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
- If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete)
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
| `body` | [`UpdateOrderRequest`](../../doc/models/update-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateOrderResponse>`](../../doc/models/update-order-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
Models.UpdateOrderRequest body = new Models.UpdateOrderRequest.Builder()
.Build();

try
{
    UpdateOrderResponse result = await ordersApi.UpdateOrderAsync(
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
| `body` | [`PayOrderRequest`](../../doc/models/pay-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.PayOrderResponse>`](../../doc/models/pay-order-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
Models.PayOrderRequest body = new Models.PayOrderRequest.Builder(
    "c043a359-7ad9-4136-82a9-c3f1d66dcbff"
)
.PaymentIds(
    new List<string>
    {
        "EnZdNAlWCmfh6Mt5FMNST1o7taB",
        "0LRiVlbXVwe8ozu4KbZxd12mvaB",
    })
.Build();

try
{
    PayOrderResponse result = await ordersApi.PayOrderAsync(
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

