# Subscriptions

```csharp
ISubscriptionsApi subscriptionsApi = client.SubscriptionsApi;
```

## Class Name

`SubscriptionsApi`

## Methods

* [Create Subscription](/doc/subscriptions.md#create-subscription)
* [Search Subscriptions](/doc/subscriptions.md#search-subscriptions)
* [Retrieve Subscription](/doc/subscriptions.md#retrieve-subscription)
* [Update Subscription](/doc/subscriptions.md#update-subscription)
* [Cancel Subscription](/doc/subscriptions.md#cancel-subscription)
* [List Subscription Events](/doc/subscriptions.md#list-subscription-events)

## Create Subscription

Creates a subscription for a customer to a subscription plan.

If you provide a card on file in the request, Square charges the card for 
the subscription. Otherwise, Square bills an invoice to the customer's email 
address. The subscription starts immediately, unless the request includes 
the optional `start_date`. Each individual subscription is associated with a particular location.

Subscriptions Guide: [https://developer.squareup.com/docs/subscriptions-api/overview#create-subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#create-subscriptions)

```csharp
CreateSubscriptionAsync(Models.CreateSubscriptionRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateSubscriptionRequest`](/doc/models/create-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateSubscriptionResponse>`](/doc/models/create-subscription-response.md)

### Example Usage

```csharp
var bodyPriceOverrideMoney = new Money.Builder()
    .Amount(100L)
    .Currency("USD")
    .Build();
var body = new CreateSubscriptionRequest.Builder(
        "8193148c-9586-11e6-99f9-28cfe92138cf",
        "S8GWD5R9QB376",
        "6JHXF3B2CW3YKHDV4XEM674H",
        "CHFGVKYY8RSV93M5KCYTG4PN0G")
    .StartDate("2020-08-01")
    .CanceledDate("canceled_date0")
    .TaxPercentage("5")
    .PriceOverrideMoney(bodyPriceOverrideMoney)
    .CardId("ccof:qy5x8hHGYsgLrp4Q4GB")
    .Timezone("America/Los_Angeles")
    .Build();

try
{
    CreateSubscriptionResponse result = await subscriptionsApi.CreateSubscriptionAsync(body);
}
catch (ApiException e){};
```

## Search Subscriptions

Searches for subscriptions. 
Results are ordered chronologically by subscription creation date. If
the request specifies more than one location ID, 
the endpoint orders the result 
by location ID, and then by creation date within each location. If no locations are given
in the query, all locations are searched.

You can also optionally specify `customer_ids` to search by customer. 
If left unset, all customers 
associated with the specified locations are returned. 
If the request specifies customer IDs, the endpoint orders results 
first by location, within location by customer ID, and within 
customer by subscription creation date.

For more information, see 
[Retrieve subscriptions](https://developer.squareup.com/docs/docs/subscriptions-api/overview#retrieve-subscriptions).

Subscriptions Guide: [https://developer.squareup.com/docs/subscriptions-api/overview#retrieve-subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#retrieve-subscriptions)

```csharp
SearchSubscriptionsAsync(Models.SearchSubscriptionsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchSubscriptionsRequest`](/doc/models/search-subscriptions-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchSubscriptionsResponse>`](/doc/models/search-subscriptions-response.md)

### Example Usage

```csharp
var bodyQueryFilterCustomerIds = new List<string>();
bodyQueryFilterCustomerIds.Add("CHFGVKYY8RSV93M5KCYTG4PN0G");
var bodyQueryFilterLocationIds = new List<string>();
bodyQueryFilterLocationIds.Add("S8GWD5R9QB376");
var bodyQueryFilter = new SearchSubscriptionsFilter.Builder()
    .CustomerIds(bodyQueryFilterCustomerIds)
    .LocationIds(bodyQueryFilterLocationIds)
    .Build();
var bodyQuery = new SearchSubscriptionsQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchSubscriptionsRequest.Builder()
    .Cursor("cursor0")
    .Limit(164)
    .Query(bodyQuery)
    .Build();

try
{
    SearchSubscriptionsResponse result = await subscriptionsApi.SearchSubscriptionsAsync(body);
}
catch (ApiException e){};
```

## Retrieve Subscription

Retrieves a subscription.

Subscriptions Guide: [https://developer.squareup.com/docs/subscriptions-api/overview#retrieve-subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#retrieve-subscriptions)

```csharp
RetrieveSubscriptionAsync(string subscriptionId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to retrieve. |

### Response Type

[`Task<Models.RetrieveSubscriptionResponse>`](/doc/models/retrieve-subscription-response.md)

### Example Usage

```csharp
string subscriptionId = "subscription_id0";

try
{
    RetrieveSubscriptionResponse result = await subscriptionsApi.RetrieveSubscriptionAsync(subscriptionId);
}
catch (ApiException e){};
```

## Update Subscription

Updates a subscription. You can set, modify, and clear the 
`subscription` field values.

Subscriptions Guide: [https://developer.squareup.com/docs/subscriptions-api/overview#update-subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#update-subscriptions)

```csharp
UpdateSubscriptionAsync(string subscriptionId, Models.UpdateSubscriptionRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID for the subscription to update. |
| `body` | [`Models.UpdateSubscriptionRequest`](/doc/models/update-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateSubscriptionResponse>`](/doc/models/update-subscription-response.md)

### Example Usage

```csharp
string subscriptionId = "subscription_id0";
var bodySubscriptionPriceOverrideMoney = new Money.Builder()
    .Amount(2000L)
    .Currency("USD")
    .Build();
var bodySubscription = new Subscription.Builder()
    .Id("id8")
    .LocationId("location_id2")
    .PlanId("plan_id0")
    .CustomerId("customer_id6")
    .StartDate("start_date2")
    .TaxPercentage("null")
    .PriceOverrideMoney(bodySubscriptionPriceOverrideMoney)
    .Version(1594155459464L)
    .Build();
var body = new UpdateSubscriptionRequest.Builder()
    .Subscription(bodySubscription)
    .Build();

try
{
    UpdateSubscriptionResponse result = await subscriptionsApi.UpdateSubscriptionAsync(subscriptionId, body);
}
catch (ApiException e){};
```

## Cancel Subscription

Sets the `canceled_date` field to the end of the active billing period.
After this date, the status changes from ACTIVE to CANCELED.

Subscriptions Guide: [https://developer.squareup.com/docs/subscriptions-api/overview#cancel-subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#cancel-subscriptions)

```csharp
CancelSubscriptionAsync(string subscriptionId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to cancel. |

### Response Type

[`Task<Models.CancelSubscriptionResponse>`](/doc/models/cancel-subscription-response.md)

### Example Usage

```csharp
string subscriptionId = "subscription_id0";

try
{
    CancelSubscriptionResponse result = await subscriptionsApi.CancelSubscriptionAsync(subscriptionId);
}
catch (ApiException e){};
```

## List Subscription Events

Lists all events for a specific subscription.
In the current implementation, only `START_SUBSCRIPTION` and `STOP_SUBSCRIPTION` (when the subscription was canceled) events are returned.

Subscriptions Guide: [https://developer.squareup.com/docs/subscriptions-api/overview#subscription-events](https://developer.squareup.com/docs/subscriptions-api/overview#subscription-events)

```csharp
ListSubscriptionEventsAsync(string subscriptionId, string cursor = null, int? limit = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to retrieve the events for. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for the original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination). |
| `limit` | `int?` | Query, Optional | The upper limit on the number of subscription events to return <br>in the response. <br><br>Default: `200` |

### Response Type

[`Task<Models.ListSubscriptionEventsResponse>`](/doc/models/list-subscription-events-response.md)

### Example Usage

```csharp
string subscriptionId = "subscription_id0";
string cursor = "cursor6";
int? limit = 172;

try
{
    ListSubscriptionEventsResponse result = await subscriptionsApi.ListSubscriptionEventsAsync(subscriptionId, cursor, limit);
}
catch (ApiException e){};
```

