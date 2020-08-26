# Orders

```csharp
IOrdersApi ordersApi = client.OrdersApi;
```

## Class Name

`OrdersApi`

## Methods

* [Create Order](/doc/orders.md#create-order)
* [Batch Retrieve Orders](/doc/orders.md#batch-retrieve-orders)
* [Calculate Order](/doc/orders.md#calculate-order)
* [Search Orders](/doc/orders.md#search-orders)
* [Update Order](/doc/orders.md#update-order)
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
CreateOrderAsync(Models.CreateOrderRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateOrderRequest`](/doc/models/create-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateOrderResponse>`](/doc/models/create-order-response.md)

### Example Usage

```csharp
var bodyOrderSource = new OrderSource.Builder()
    .Name("name6")
    .Build();
var bodyOrderLineItems = new List<OrderLineItem>();

var bodyOrderLineItems0QuantityUnitMeasurementUnitCustomUnit = new MeasurementUnitCustom.Builder(
        "name9",
        "abbreviation1")
    .Build();
var bodyOrderLineItems0QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .CustomUnit(bodyOrderLineItems0QuantityUnitMeasurementUnitCustomUnit)
    .AreaUnit("IMPERIAL_SQUARE_INCH")
    .LengthUnit("METRIC_KILOMETER")
    .VolumeUnit("GENERIC_QUART")
    .WeightUnit("METRIC_MILLIGRAM")
    .Build();
var bodyOrderLineItems0QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderLineItems0QuantityUnitMeasurementUnit)
    .Precision(189)
    .Build();
var bodyOrderLineItems0BasePriceMoney = new Money.Builder()
    .Amount(1599L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems0 = new OrderLineItem.Builder(
        "1")
    .Uid("uid1")
    .Name("New York Strip Steak")
    .QuantityUnit(bodyOrderLineItems0QuantityUnit)
    .Note("note3")
    .CatalogObjectId("catalog_object_id5")
    .BasePriceMoney(bodyOrderLineItems0BasePriceMoney)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems0);

var bodyOrderLineItems1QuantityUnitMeasurementUnitCustomUnit = new MeasurementUnitCustom.Builder(
        "name8",
        "abbreviation0")
    .Build();
var bodyOrderLineItems1QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .CustomUnit(bodyOrderLineItems1QuantityUnitMeasurementUnitCustomUnit)
    .AreaUnit("IMPERIAL_ACRE")
    .LengthUnit("IMPERIAL_INCH")
    .VolumeUnit("GENERIC_PINT")
    .WeightUnit("METRIC_GRAM")
    .Build();
var bodyOrderLineItems1QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderLineItems1QuantityUnitMeasurementUnit)
    .Precision(188)
    .Build();
var bodyOrderLineItems1Modifiers = new List<OrderLineItemModifier>();

var bodyOrderLineItems1Modifiers0BasePriceMoney = new Money.Builder()
    .Amount(53L)
    .Currency("TTD")
    .Build();
var bodyOrderLineItems1Modifiers0TotalPriceMoney = new Money.Builder()
    .Amount(51L)
    .Currency("EUR")
    .Build();
var bodyOrderLineItems1Modifiers0 = new OrderLineItemModifier.Builder()
    .Uid("uid1")
    .CatalogObjectId("CHQX7Y4KY6N5KINJKZCFURPZ")
    .Name("name1")
    .BasePriceMoney(bodyOrderLineItems1Modifiers0BasePriceMoney)
    .TotalPriceMoney(bodyOrderLineItems1Modifiers0TotalPriceMoney)
    .Build();
bodyOrderLineItems1Modifiers.Add(bodyOrderLineItems1Modifiers0);

var bodyOrderLineItems1AppliedDiscounts = new List<OrderLineItemAppliedDiscount>();

var bodyOrderLineItems1AppliedDiscounts0AppliedMoney = new Money.Builder()
    .Amount(164L)
    .Currency("CUC")
    .Build();
var bodyOrderLineItems1AppliedDiscounts0 = new OrderLineItemAppliedDiscount.Builder(
        "one-dollar-off")
    .Uid("uid4")
    .AppliedMoney(bodyOrderLineItems1AppliedDiscounts0AppliedMoney)
    .Build();
bodyOrderLineItems1AppliedDiscounts.Add(bodyOrderLineItems1AppliedDiscounts0);

var bodyOrderLineItems1 = new OrderLineItem.Builder(
        "2")
    .Uid("uid0")
    .Name("name0")
    .QuantityUnit(bodyOrderLineItems1QuantityUnit)
    .Note("note4")
    .CatalogObjectId("BEMYCSMIJL46OCDV4KYIKXIB")
    .Modifiers(bodyOrderLineItems1Modifiers)
    .AppliedDiscounts(bodyOrderLineItems1AppliedDiscounts)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems1);

var bodyOrderTaxes = new List<OrderLineItemTax>();

var bodyOrderTaxes0 = new OrderLineItemTax.Builder()
    .Uid("state-sales-tax")
    .CatalogObjectId("catalog_object_id1")
    .Name("State Sales Tax")
    .Type("UNKNOWN_TAX")
    .Percentage("9")
    .Scope("ORDER")
    .Build();
bodyOrderTaxes.Add(bodyOrderTaxes0);

var bodyOrderDiscounts = new List<OrderLineItemDiscount>();

var bodyOrderDiscounts0 = new OrderLineItemDiscount.Builder()
    .Uid("labor-day-sale")
    .CatalogObjectId("catalog_object_id5")
    .Name("Labor Day Sale")
    .Type("FIXED_PERCENTAGE")
    .Percentage("5")
    .Scope("ORDER")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts0);

var bodyOrderDiscounts1 = new OrderLineItemDiscount.Builder()
    .Uid("membership-discount")
    .CatalogObjectId("DB7L55ZH2BGWI4H23ULIWOQ7")
    .Name("name2")
    .Type("FIXED_AMOUNT")
    .Percentage("percentage0")
    .Scope("ORDER")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts1);

var bodyOrderDiscounts2AmountMoney = new Money.Builder()
    .Amount(100L)
    .Currency("USD")
    .Build();
var bodyOrderDiscounts2 = new OrderLineItemDiscount.Builder()
    .Uid("one-dollar-off")
    .CatalogObjectId("catalog_object_id7")
    .Name("Sale - $1.00 off")
    .Type("VARIABLE_PERCENTAGE")
    .Percentage("percentage1")
    .AmountMoney(bodyOrderDiscounts2AmountMoney)
    .Scope("LINE_ITEM")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts2);

var bodyOrder = new Order.Builder(
        "057P5VYJ4A5X1")
    .Id("id0")
    .ReferenceId("my-order-001")
    .Source(bodyOrderSource)
    .CustomerId("customer_id8")
    .LineItems(bodyOrderLineItems)
    .Taxes(bodyOrderTaxes)
    .Discounts(bodyOrderDiscounts)
    .Build();
var body = new CreateOrderRequest.Builder()
    .Order(bodyOrder)
    .LocationId("location_id0")
    .IdempotencyKey("8193148c-9586-11e6-99f9-28cfe92138cf")
    .Build();

try
{
    CreateOrderResponse result = await ordersApi.CreateOrderAsync(body);
}
catch (ApiException e){};
```

## Batch Retrieve Orders

Retrieves a set of [Order](#type-order)s by their IDs.

If a given Order ID does not exist, the ID is ignored instead of generating an error.

```csharp
BatchRetrieveOrdersAsync(Models.BatchRetrieveOrdersRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchRetrieveOrdersRequest`](/doc/models/batch-retrieve-orders-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.BatchRetrieveOrdersResponse>`](/doc/models/batch-retrieve-orders-response.md)

### Example Usage

```csharp
var bodyOrderIds = new List<string>();
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

## Calculate Order

Calculates an [Order](#type-order).

```csharp
CalculateOrderAsync(Models.CalculateOrderRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CalculateOrderRequest`](/doc/models/calculate-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CalculateOrderResponse>`](/doc/models/calculate-order-response.md)

### Example Usage

```csharp
var bodyOrderSource = new OrderSource.Builder()
    .Name("name6")
    .Build();
var bodyOrderLineItems = new List<OrderLineItem>();

var bodyOrderLineItems0QuantityUnitMeasurementUnitCustomUnit = new MeasurementUnitCustom.Builder(
        "name9",
        "abbreviation1")
    .Build();
var bodyOrderLineItems0QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .CustomUnit(bodyOrderLineItems0QuantityUnitMeasurementUnitCustomUnit)
    .AreaUnit("IMPERIAL_SQUARE_INCH")
    .LengthUnit("METRIC_KILOMETER")
    .VolumeUnit("GENERIC_QUART")
    .WeightUnit("METRIC_MILLIGRAM")
    .Build();
var bodyOrderLineItems0QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderLineItems0QuantityUnitMeasurementUnit)
    .Precision(189)
    .Build();
var bodyOrderLineItems0BasePriceMoney = new Money.Builder()
    .Amount(500L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems0 = new OrderLineItem.Builder(
        "1")
    .Uid("uid1")
    .Name("Item 1")
    .QuantityUnit(bodyOrderLineItems0QuantityUnit)
    .Note("note3")
    .CatalogObjectId("catalog_object_id5")
    .BasePriceMoney(bodyOrderLineItems0BasePriceMoney)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems0);

var bodyOrderLineItems1QuantityUnitMeasurementUnitCustomUnit = new MeasurementUnitCustom.Builder(
        "name8",
        "abbreviation0")
    .Build();
var bodyOrderLineItems1QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .CustomUnit(bodyOrderLineItems1QuantityUnitMeasurementUnitCustomUnit)
    .AreaUnit("IMPERIAL_ACRE")
    .LengthUnit("IMPERIAL_INCH")
    .VolumeUnit("GENERIC_PINT")
    .WeightUnit("METRIC_GRAM")
    .Build();
var bodyOrderLineItems1QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderLineItems1QuantityUnitMeasurementUnit)
    .Precision(188)
    .Build();
var bodyOrderLineItems1BasePriceMoney = new Money.Builder()
    .Amount(300L)
    .Currency("USD")
    .Build();
var bodyOrderLineItems1 = new OrderLineItem.Builder(
        "2")
    .Uid("uid0")
    .Name("Item 2")
    .QuantityUnit(bodyOrderLineItems1QuantityUnit)
    .Note("note4")
    .CatalogObjectId("catalog_object_id6")
    .BasePriceMoney(bodyOrderLineItems1BasePriceMoney)
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems1);

var bodyOrderDiscounts = new List<OrderLineItemDiscount>();

var bodyOrderDiscounts0 = new OrderLineItemDiscount.Builder()
    .Uid("uid1")
    .CatalogObjectId("catalog_object_id5")
    .Name("50% Off")
    .Type("FIXED_PERCENTAGE")
    .Percentage("50")
    .Scope("ORDER")
    .Build();
bodyOrderDiscounts.Add(bodyOrderDiscounts0);

var bodyOrder = new Order.Builder(
        "D7AVYMEAPJ3A3")
    .Id("id0")
    .ReferenceId("reference_id8")
    .Source(bodyOrderSource)
    .CustomerId("customer_id8")
    .LineItems(bodyOrderLineItems)
    .Discounts(bodyOrderDiscounts)
    .Build();
var bodyProposedRewards = new List<OrderReward>();

var bodyProposedRewards0 = new OrderReward.Builder(
        "id6",
        "reward_tier_id2")
    .Build();
bodyProposedRewards.Add(bodyProposedRewards0);

var bodyProposedRewards1 = new OrderReward.Builder(
        "id7",
        "reward_tier_id3")
    .Build();
bodyProposedRewards.Add(bodyProposedRewards1);

var bodyProposedRewards2 = new OrderReward.Builder(
        "id8",
        "reward_tier_id4")
    .Build();
bodyProposedRewards.Add(bodyProposedRewards2);

var body = new CalculateOrderRequest.Builder(
        bodyOrder)
    .ProposedRewards(bodyProposedRewards)
    .Build();

try
{
    CalculateOrderResponse result = await ordersApi.CalculateOrderAsync(body);
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
var bodyQueryFilterDateTimeFilterCreatedAt = new TimeRange.Builder()
    .StartAt("start_at8")
    .EndAt("end_at4")
    .Build();
var bodyQueryFilterDateTimeFilterUpdatedAt = new TimeRange.Builder()
    .StartAt("start_at6")
    .EndAt("end_at6")
    .Build();
var bodyQueryFilterDateTimeFilterClosedAt = new TimeRange.Builder()
    .StartAt("2018-03-03T20:00:00+00:00")
    .EndAt("2019-03-04T21:54:45+00:00")
    .Build();
var bodyQueryFilterDateTimeFilter = new SearchOrdersDateTimeFilter.Builder()
    .CreatedAt(bodyQueryFilterDateTimeFilterCreatedAt)
    .UpdatedAt(bodyQueryFilterDateTimeFilterUpdatedAt)
    .ClosedAt(bodyQueryFilterDateTimeFilterClosedAt)
    .Build();
var bodyQueryFilterFulfillmentFilterFulfillmentTypes = new List<string>();
bodyQueryFilterFulfillmentFilterFulfillmentTypes.Add("SHIPMENT");
var bodyQueryFilterFulfillmentFilterFulfillmentStates = new List<string>();
bodyQueryFilterFulfillmentFilterFulfillmentStates.Add("CANCELED");
bodyQueryFilterFulfillmentFilterFulfillmentStates.Add("FAILED");
var bodyQueryFilterFulfillmentFilter = new SearchOrdersFulfillmentFilter.Builder()
    .FulfillmentTypes(bodyQueryFilterFulfillmentFilterFulfillmentTypes)
    .FulfillmentStates(bodyQueryFilterFulfillmentFilterFulfillmentStates)
    .Build();
var bodyQueryFilterSourceFilterSourceNames = new List<string>();
bodyQueryFilterSourceFilterSourceNames.Add("source_names8");
var bodyQueryFilterSourceFilter = new SearchOrdersSourceFilter.Builder()
    .SourceNames(bodyQueryFilterSourceFilterSourceNames)
    .Build();
var bodyQueryFilterCustomerFilterCustomerIds = new List<string>();
bodyQueryFilterCustomerFilterCustomerIds.Add("customer_ids5");
bodyQueryFilterCustomerFilterCustomerIds.Add("customer_ids6");
var bodyQueryFilterCustomerFilter = new SearchOrdersCustomerFilter.Builder()
    .CustomerIds(bodyQueryFilterCustomerFilterCustomerIds)
    .Build();
var bodyQueryFilter = new SearchOrdersFilter.Builder()
    .StateFilter(bodyQueryFilterStateFilter)
    .DateTimeFilter(bodyQueryFilterDateTimeFilter)
    .FulfillmentFilter(bodyQueryFilterFulfillmentFilter)
    .SourceFilter(bodyQueryFilterSourceFilter)
    .CustomerFilter(bodyQueryFilterCustomerFilter)
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
    .Cursor("cursor0")
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
UpdateOrderAsync(string orderId, Models.UpdateOrderRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the order to update. |
| `body` | [`Models.UpdateOrderRequest`](/doc/models/update-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateOrderResponse>`](/doc/models/update-order-response.md)

### Example Usage

```csharp
string orderId = "order_id6";
var bodyOrderSource = new OrderSource.Builder()
    .Name("name6")
    .Build();
var bodyOrderLineItems = new List<OrderLineItem>();

var bodyOrderLineItems0QuantityUnitMeasurementUnitCustomUnit = new MeasurementUnitCustom.Builder(
        "name9",
        "abbreviation1")
    .Build();
var bodyOrderLineItems0QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .CustomUnit(bodyOrderLineItems0QuantityUnitMeasurementUnitCustomUnit)
    .AreaUnit("IMPERIAL_SQUARE_INCH")
    .LengthUnit("METRIC_KILOMETER")
    .VolumeUnit("GENERIC_QUART")
    .WeightUnit("METRIC_MILLIGRAM")
    .Build();
var bodyOrderLineItems0QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderLineItems0QuantityUnitMeasurementUnit)
    .Precision(189)
    .Build();
var bodyOrderLineItems0 = new OrderLineItem.Builder(
        "quantity7")
    .Uid("uid1")
    .Name("name1")
    .QuantityUnit(bodyOrderLineItems0QuantityUnit)
    .Note("note3")
    .CatalogObjectId("catalog_object_id5")
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems0);

var bodyOrderLineItems1QuantityUnitMeasurementUnitCustomUnit = new MeasurementUnitCustom.Builder(
        "name8",
        "abbreviation0")
    .Build();
var bodyOrderLineItems1QuantityUnitMeasurementUnit = new MeasurementUnit.Builder()
    .CustomUnit(bodyOrderLineItems1QuantityUnitMeasurementUnitCustomUnit)
    .AreaUnit("IMPERIAL_ACRE")
    .LengthUnit("IMPERIAL_INCH")
    .VolumeUnit("GENERIC_PINT")
    .WeightUnit("METRIC_GRAM")
    .Build();
var bodyOrderLineItems1QuantityUnit = new OrderQuantityUnit.Builder()
    .MeasurementUnit(bodyOrderLineItems1QuantityUnitMeasurementUnit)
    .Precision(188)
    .Build();
var bodyOrderLineItems1 = new OrderLineItem.Builder(
        "quantity6")
    .Uid("uid0")
    .Name("name0")
    .QuantityUnit(bodyOrderLineItems1QuantityUnit)
    .Note("note4")
    .CatalogObjectId("catalog_object_id6")
    .Build();
bodyOrderLineItems.Add(bodyOrderLineItems1);

var bodyOrder = new Order.Builder(
        "location_id4")
    .Id("id0")
    .ReferenceId("reference_id8")
    .Source(bodyOrderSource)
    .CustomerId("customer_id8")
    .LineItems(bodyOrderLineItems)
    .Build();
var bodyFieldsToClear = new List<string>();
bodyFieldsToClear.Add("fields_to_clear7");
bodyFieldsToClear.Add("fields_to_clear8");
var body = new UpdateOrderRequest.Builder()
    .Order(bodyOrder)
    .FieldsToClear(bodyFieldsToClear)
    .IdempotencyKey("idempotency_key2")
    .Build();

try
{
    UpdateOrderResponse result = await ordersApi.UpdateOrderAsync(orderId, body);
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
    .OrderVersion(82)
    .PaymentIds(bodyPaymentIds)
    .Build();

try
{
    PayOrderResponse result = await ordersApi.PayOrderAsync(orderId, body);
}
catch (ApiException e){};
```

