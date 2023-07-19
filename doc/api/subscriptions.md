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

Enrolls a customer in a subscription.

If you provide a card on file in the request, Square charges the card for
the subscription. Otherwise, Square sends an invoice to the customer's email
address. The subscription starts immediately, unless the request includes
the optional `start_date`. Each individual subscription is associated with a particular location.

For more information, see [Create a subscription](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions#create-a-subscription).

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
Models.CreateSubscriptionRequest body = new Models.CreateSubscriptionRequest.Builder(
    "S8GWD5R9QB376",
    "CHFGVKYY8RSV93M5KCYTG4PN0G"
)
.IdempotencyKey("8193148c-9586-11e6-99f9-28cfe92138cf")
.PlanVariationId("6JHXF3B2CW3YKHDV4XEM674H")
.StartDate("2023-06-20")
.CardId("ccof:qy5x8hHGYsgLrp4Q4GB")
.Timezone("America/Los_Angeles")
.Source(
    new Models.SubscriptionSource.Builder()
    .Name("My Application")
    .Build())
.Phases(
    new List<Models.Phase>
    {
        new Models.Phase.Builder()
        .Ordinal(0)
        .OrderTemplateId("U2NaowWxzXwpsZU697x7ZHOAnCNZY")
        .Build(),
    })
.Build();

try
{
    CreateSubscriptionResponse result = await subscriptionsApi.CreateSubscriptionAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.SearchSubscriptionsRequest body = new Models.SearchSubscriptionsRequest.Builder()
.Query(
    new Models.SearchSubscriptionsQuery.Builder()
    .Filter(
        new Models.SearchSubscriptionsFilter.Builder()
        .CustomerIds(
            new List<string>
            {
                "CHFGVKYY8RSV93M5KCYTG4PN0G",
            })
        .LocationIds(
            new List<string>
            {
                "S8GWD5R9QB376",
            })
        .SourceNames(
            new List<string>
            {
                "My App",
            })
        .Build())
    .Build())
.Build();

try
{
    SearchSubscriptionsResponse result = await subscriptionsApi.SearchSubscriptionsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Subscription

Retrieves a specific subscription.

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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Subscription

Updates a subscription by modifying or clearing `subscription` field values.
To clear a field, set its value to `null`.

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
Models.UpdateSubscriptionRequest body = new Models.UpdateSubscriptionRequest.Builder()
.Subscription(
    new Models.Subscription.Builder()
    .Build())
.Build();

try
{
    UpdateSubscriptionResponse result = await subscriptionsApi.UpdateSubscriptionAsync(subscriptionId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Cancel Subscription

Schedules a `CANCEL` action to cancel an active subscription. This
sets the `canceled_date` field to the end of the active billing period. After this date,
the subscription status changes from ACTIVE to CANCELED.

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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Subscription Events

Lists all [events](https://developer.squareup.com/docs/subscriptions-api/actions-events) for a specific subscription.

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
| `cursor` | `string` | Query, Optional | When the total number of resulting subscription events exceeds the limit of a paged response,<br>specify the cursor returned from a preceding response here to fetch the next set of results.<br>If the cursor is unset, the response contains the last page of the results.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.PauseSubscriptionRequest body = new Models.PauseSubscriptionRequest.Builder()
.Build();

try
{
    PauseSubscriptionResponse result = await subscriptionsApi.PauseSubscriptionAsync(subscriptionId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.ResumeSubscriptionRequest body = new Models.ResumeSubscriptionRequest.Builder()
.Build();

try
{
    ResumeSubscriptionResponse result = await subscriptionsApi.ResumeSubscriptionAsync(subscriptionId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Swap Plan

Schedules a `SWAP_PLAN` action to swap a subscription plan variation in an existing subscription.
For more information, see [Swap Subscription Plan Variations](https://developer.squareup.com/docs/subscriptions-api/swap-plan-variations).

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
Models.SwapPlanRequest body = new Models.SwapPlanRequest.Builder()
.NewPlanVariationId("FQ7CDXXWSLUJRPM3GFJSJGZ7")
.Phases(
    new List<Models.PhaseInput>
    {
        new Models.PhaseInput.Builder(
            0
        )
        .OrderTemplateId("uhhnjH9osVv3shUADwaC0b3hNxQZY")
        .Build(),
    })
.Build();

try
{
    SwapPlanResponse result = await subscriptionsApi.SwapPlanAsync(subscriptionId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

