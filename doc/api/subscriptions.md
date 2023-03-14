# Subscriptions

```csharp
ISubscriptionsApi subscriptionsApi = client.SubscriptionsApi;
```

## Class Name

`SubscriptionsApi`

## Methods

* [Create Subscription](../../doc/api/subscriptions.md#create-subscription)
* [Search Subscriptions](../../doc/api/subscriptions.md#search-subscriptions)
* [Retrieve Subscription](../../doc/api/subscriptions.md#retrieve-subscription)
* [Update Subscription](../../doc/api/subscriptions.md#update-subscription)
* [Delete Subscription Action](../../doc/api/subscriptions.md#delete-subscription-action)
* [Cancel Subscription](../../doc/api/subscriptions.md#cancel-subscription)
* [List Subscription Events](../../doc/api/subscriptions.md#list-subscription-events)
* [Pause Subscription](../../doc/api/subscriptions.md#pause-subscription)
* [Resume Subscription](../../doc/api/subscriptions.md#resume-subscription)
* [Swap Plan](../../doc/api/subscriptions.md#swap-plan)


# Create Subscription

Creates a subscription to a subscription plan by a customer.

If you provide a card on file in the request, Square charges the card for
the subscription. Otherwise, Square bills an invoice to the customer's email
address. The subscription starts immediately, unless the request includes
the optional `start_date`. Each individual subscription is associated with a particular location.

```csharp
CreateSubscriptionAsync(
    Models.CreateSubscriptionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateSubscriptionRequest`](../../doc/models/create-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateSubscriptionResponse>`](../../doc/models/create-subscription-response.md)

## Example Usage

```csharp
var bodyPriceOverrideMoney = new Money.Builder()
    .Amount(100L)
    .Currency("USD")
    .Build();
var body = new CreateSubscriptionRequest.Builder(
        "S8GWD5R9QB376",
        "6JHXF3B2CW3YKHDV4XEM674H",
        "CHFGVKYY8RSV93M5KCYTG4PN0G")
    .IdempotencyKey("8193148c-9586-11e6-99f9-28cfe92138cf")
    .StartDate("2021-10-20")
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


# Search Subscriptions

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
[Retrieve subscriptions](https://developer.squareup.com/docs/subscriptions-api/overview#retrieve-subscriptions).

```csharp
SearchSubscriptionsAsync(
    Models.SearchSubscriptionsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchSubscriptionsRequest`](../../doc/models/search-subscriptions-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchSubscriptionsResponse>`](../../doc/models/search-subscriptions-response.md)

## Example Usage

```csharp
var bodyQueryFilterCustomerIds = new IList<string>();
bodyQueryFilterCustomerIds.Add("CHFGVKYY8RSV93M5KCYTG4PN0G");
var bodyQueryFilterLocationIds = new IList<string>();
bodyQueryFilterLocationIds.Add("S8GWD5R9QB376");
var bodyQueryFilterSourceNames = new IList<string>();
bodyQueryFilterSourceNames.Add("My App");
var bodyQueryFilter = new SearchSubscriptionsFilter.Builder()
    .CustomerIds(bodyQueryFilterCustomerIds)
    .LocationIds(bodyQueryFilterLocationIds)
    .SourceNames(bodyQueryFilterSourceNames)
    .Build();
var bodyQuery = new SearchSubscriptionsQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchSubscriptionsRequest.Builder()
    .Query(bodyQuery)
    .Build();

try
{
    SearchSubscriptionsResponse result = await subscriptionsApi.SearchSubscriptionsAsync(body);
}
catch (ApiException e){};
```


# Retrieve Subscription

Retrieves a subscription.

```csharp
RetrieveSubscriptionAsync(
    string subscriptionId,
    string include = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to retrieve. |
| `include` | `string` | Query, Optional | A query parameter to specify related information to be included in the response.<br><br>The supported query parameter values are:<br><br>- `actions`: to include scheduled actions on the targeted subscription. |

## Response Type

[`Task<Models.RetrieveSubscriptionResponse>`](../../doc/models/retrieve-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";

try
{
    RetrieveSubscriptionResponse result = await subscriptionsApi.RetrieveSubscriptionAsync(subscriptionId, null);
}
catch (ApiException e){};
```


# Update Subscription

Updates a subscription. You can set, modify, and clear the
`subscription` field values.

```csharp
UpdateSubscriptionAsync(
    string subscriptionId,
    Models.UpdateSubscriptionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to update. |
| `body` | [`Models.UpdateSubscriptionRequest`](../../doc/models/update-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateSubscriptionResponse>`](../../doc/models/update-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
var bodySubscriptionPriceOverrideMoney = new Money.Builder()
    .Amount(2000L)
    .Currency("USD")
    .Build();
var bodySubscription = new Subscription.Builder()
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


# Delete Subscription Action

Deletes a scheduled action for a subscription.

```csharp
DeleteSubscriptionActionAsync(
    string subscriptionId,
    string actionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription the targeted action is to act upon. |
| `actionId` | `string` | Template, Required | The ID of the targeted action to be deleted. |

## Response Type

[`Task<Models.DeleteSubscriptionActionResponse>`](../../doc/models/delete-subscription-action-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
string actionId = "action_id6";

try
{
    DeleteSubscriptionActionResponse result = await subscriptionsApi.DeleteSubscriptionActionAsync(subscriptionId, actionId);
}
catch (ApiException e){};
```


# Cancel Subscription

Schedules a `CANCEL` action to cancel an active subscription
by setting the `canceled_date` field to the end of the active billing period
and changing the subscription status from ACTIVE to CANCELED after this date.

```csharp
CancelSubscriptionAsync(
    string subscriptionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to cancel. |

## Response Type

[`Task<Models.CancelSubscriptionResponse>`](../../doc/models/cancel-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";

try
{
    CancelSubscriptionResponse result = await subscriptionsApi.CancelSubscriptionAsync(subscriptionId);
}
catch (ApiException e){};
```


# List Subscription Events

Lists all events for a specific subscription.

```csharp
ListSubscriptionEventsAsync(
    string subscriptionId,
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to retrieve the events for. |
| `cursor` | `string` | Query, Optional | When the total number of resulting subscription events exceeds the limit of a paged response,<br>specify the cursor returned from a preceding response here to fetch the next set of results.<br>If the cursor is unset, the response contains the last page of the results.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `limit` | `int?` | Query, Optional | The upper limit on the number of subscription events to return<br>in a paged response. |

## Response Type

[`Task<Models.ListSubscriptionEventsResponse>`](../../doc/models/list-subscription-events-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";

try
{
    ListSubscriptionEventsResponse result = await subscriptionsApi.ListSubscriptionEventsAsync(subscriptionId, null, null);
}
catch (ApiException e){};
```


# Pause Subscription

Schedules a `PAUSE` action to pause an active subscription.

```csharp
PauseSubscriptionAsync(
    string subscriptionId,
    Models.PauseSubscriptionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to pause. |
| `body` | [`Models.PauseSubscriptionRequest`](../../doc/models/pause-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.PauseSubscriptionResponse>`](../../doc/models/pause-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
var body = new PauseSubscriptionRequest.Builder()
    .Build();

try
{
    PauseSubscriptionResponse result = await subscriptionsApi.PauseSubscriptionAsync(subscriptionId, body);
}
catch (ApiException e){};
```


# Resume Subscription

Schedules a `RESUME` action to resume a paused or a deactivated subscription.

```csharp
ResumeSubscriptionAsync(
    string subscriptionId,
    Models.ResumeSubscriptionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to resume. |
| `body` | [`Models.ResumeSubscriptionRequest`](../../doc/models/resume-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.ResumeSubscriptionResponse>`](../../doc/models/resume-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
var body = new ResumeSubscriptionRequest.Builder()
    .Build();

try
{
    ResumeSubscriptionResponse result = await subscriptionsApi.ResumeSubscriptionAsync(subscriptionId, body);
}
catch (ApiException e){};
```


# Swap Plan

Schedules a `SWAP_PLAN` action to swap a subscription plan in an existing subscription.

```csharp
SwapPlanAsync(
    string subscriptionId,
    Models.SwapPlanRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | The ID of the subscription to swap the subscription plan for. |
| `body` | [`Models.SwapPlanRequest`](../../doc/models/swap-plan-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SwapPlanResponse>`](../../doc/models/swap-plan-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
var body = new SwapPlanRequest.Builder(
        null)
    .Build();

try
{
    SwapPlanResponse result = await subscriptionsApi.SwapPlanAsync(subscriptionId, body);
}
catch (ApiException e){};
```

