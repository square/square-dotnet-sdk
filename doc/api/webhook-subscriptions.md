# Webhook Subscriptions

```csharp
IWebhookSubscriptionsApi webhookSubscriptionsApi = client.WebhookSubscriptionsApi;
```

## Class Name

`WebhookSubscriptionsApi`

## Methods

* [List Webhook Event Types](../../doc/api/webhook-subscriptions.md#list-webhook-event-types)
* [List Webhook Subscriptions](../../doc/api/webhook-subscriptions.md#list-webhook-subscriptions)
* [Create Webhook Subscription](../../doc/api/webhook-subscriptions.md#create-webhook-subscription)
* [Delete Webhook Subscription](../../doc/api/webhook-subscriptions.md#delete-webhook-subscription)
* [Retrieve Webhook Subscription](../../doc/api/webhook-subscriptions.md#retrieve-webhook-subscription)
* [Update Webhook Subscription](../../doc/api/webhook-subscriptions.md#update-webhook-subscription)
* [Update Webhook Subscription Signature Key](../../doc/api/webhook-subscriptions.md#update-webhook-subscription-signature-key)
* [Test Webhook Subscription](../../doc/api/webhook-subscriptions.md#test-webhook-subscription)


# List Webhook Event Types

Lists all webhook event types that can be subscribed to.

```csharp
ListWebhookEventTypesAsync(
    string apiVersion = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `apiVersion` | `string` | Query, Optional | The API version for which to list event types. Setting this field overrides the default version used by the application. |

## Response Type

[`Task<Models.ListWebhookEventTypesResponse>`](../../doc/models/list-webhook-event-types-response.md)

## Example Usage

```csharp
try
{
    ListWebhookEventTypesResponse result = await webhookSubscriptionsApi.ListWebhookEventTypesAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Webhook Subscriptions

Lists all webhook subscriptions owned by your application.

```csharp
ListWebhookSubscriptionsAsync(
    string cursor = null,
    bool? includeDisabled = false,
    string sortOrder = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `includeDisabled` | `bool?` | Query, Optional | Includes disabled [Subscription](entity:WebhookSubscription)s.<br>By default, all enabled [Subscription](entity:WebhookSubscription)s are returned. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | Sorts the returned list by when the [Subscription](entity:WebhookSubscription) was created with the specified order.<br>This field defaults to ASC. |
| `limit` | `int?` | Query, Optional | The maximum number of results to be returned in a single page.<br>It is possible to receive fewer results than the specified limit on a given page.<br>The default value of 100 is also the maximum allowed value.<br><br>Default: 100 |

## Response Type

[`Task<Models.ListWebhookSubscriptionsResponse>`](../../doc/models/list-webhook-subscriptions-response.md)

## Example Usage

```csharp
bool? includeDisabled = false;
try
{
    ListWebhookSubscriptionsResponse result = await webhookSubscriptionsApi.ListWebhookSubscriptionsAsync(
        null,
        includeDisabled
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Webhook Subscription

Creates a webhook subscription.

```csharp
CreateWebhookSubscriptionAsync(
    Models.CreateWebhookSubscriptionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateWebhookSubscriptionRequest`](../../doc/models/create-webhook-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateWebhookSubscriptionResponse>`](../../doc/models/create-webhook-subscription-response.md)

## Example Usage

```csharp
Models.CreateWebhookSubscriptionRequest body = new Models.CreateWebhookSubscriptionRequest.Builder(
    new Models.WebhookSubscription.Builder()
    .Name("Example Webhook Subscription")
    .EventTypes(
        new List<string>
        {
            "payment.created",
            "payment.updated",
        })
    .NotificationUrl("https://example-webhook-url.com")
    .ApiVersion("2021-12-15")
    .Build()
)
.IdempotencyKey("63f84c6c-2200-4c99-846c-2670a1311fbf")
.Build();

try
{
    CreateWebhookSubscriptionResponse result = await webhookSubscriptionsApi.CreateWebhookSubscriptionAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete Webhook Subscription

Deletes a webhook subscription.

```csharp
DeleteWebhookSubscriptionAsync(
    string subscriptionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to delete. |

## Response Type

[`Task<Models.DeleteWebhookSubscriptionResponse>`](../../doc/models/delete-webhook-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
try
{
    DeleteWebhookSubscriptionResponse result = await webhookSubscriptionsApi.DeleteWebhookSubscriptionAsync(subscriptionId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Webhook Subscription

Retrieves a webhook subscription identified by its ID.

```csharp
RetrieveWebhookSubscriptionAsync(
    string subscriptionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to retrieve. |

## Response Type

[`Task<Models.RetrieveWebhookSubscriptionResponse>`](../../doc/models/retrieve-webhook-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
try
{
    RetrieveWebhookSubscriptionResponse result = await webhookSubscriptionsApi.RetrieveWebhookSubscriptionAsync(subscriptionId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Webhook Subscription

Updates a webhook subscription.

```csharp
UpdateWebhookSubscriptionAsync(
    string subscriptionId,
    Models.UpdateWebhookSubscriptionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update. |
| `body` | [`UpdateWebhookSubscriptionRequest`](../../doc/models/update-webhook-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateWebhookSubscriptionResponse>`](../../doc/models/update-webhook-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
Models.UpdateWebhookSubscriptionRequest body = new Models.UpdateWebhookSubscriptionRequest.Builder()
.Subscription(
    new Models.WebhookSubscription.Builder()
    .Name("Updated Example Webhook Subscription")
    .Enabled(false)
    .Build())
.Build();

try
{
    UpdateWebhookSubscriptionResponse result = await webhookSubscriptionsApi.UpdateWebhookSubscriptionAsync(
        subscriptionId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Webhook Subscription Signature Key

Updates a webhook subscription by replacing the existing signature key with a new one.

```csharp
UpdateWebhookSubscriptionSignatureKeyAsync(
    string subscriptionId,
    Models.UpdateWebhookSubscriptionSignatureKeyRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to update. |
| `body` | [`UpdateWebhookSubscriptionSignatureKeyRequest`](../../doc/models/update-webhook-subscription-signature-key-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateWebhookSubscriptionSignatureKeyResponse>`](../../doc/models/update-webhook-subscription-signature-key-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
Models.UpdateWebhookSubscriptionSignatureKeyRequest body = new Models.UpdateWebhookSubscriptionSignatureKeyRequest.Builder()
.IdempotencyKey("ed80ae6b-0654-473b-bbab-a39aee89a60d")
.Build();

try
{
    UpdateWebhookSubscriptionSignatureKeyResponse result = await webhookSubscriptionsApi.UpdateWebhookSubscriptionSignatureKeyAsync(
        subscriptionId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Test Webhook Subscription

Tests a webhook subscription by sending a test event to the notification URL.

```csharp
TestWebhookSubscriptionAsync(
    string subscriptionId,
    Models.TestWebhookSubscriptionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `subscriptionId` | `string` | Template, Required | [REQUIRED] The ID of the [Subscription](entity:WebhookSubscription) to test. |
| `body` | [`TestWebhookSubscriptionRequest`](../../doc/models/test-webhook-subscription-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.TestWebhookSubscriptionResponse>`](../../doc/models/test-webhook-subscription-response.md)

## Example Usage

```csharp
string subscriptionId = "subscription_id0";
Models.TestWebhookSubscriptionRequest body = new Models.TestWebhookSubscriptionRequest.Builder()
.EventType("payment.created")
.Build();

try
{
    TestWebhookSubscriptionResponse result = await webhookSubscriptionsApi.TestWebhookSubscriptionAsync(
        subscriptionId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

