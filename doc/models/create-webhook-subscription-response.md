
# Create Webhook Subscription Response

Defines the fields that are included in the response body of
a request to the [CreateWebhookSubscription](../../doc/api/webhook-subscriptions.md#create-webhook-subscription) endpoint.

Note: if there are errors processing the request, the [Subscription](../../doc/models/webhook-subscription.md) will not be
present.

## Structure

`CreateWebhookSubscriptionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Information on errors encountered during the request. |
| `Subscription` | [`Models.WebhookSubscription`](../../doc/models/webhook-subscription.md) | Optional | Represents the details of a webhook subscription, including notification URL,<br>event types, and signature key. |

## Example (as JSON)

```json
{
  "subscription": {
    "api_version": "2021-12-15",
    "created_at": "2022-01-10 23:29:48 +0000 UTC",
    "enabled": true,
    "event_types": [
      "payment.created",
      "payment.updated"
    ],
    "id": "wbhk_b35f6b3145074cf9ad513610786c19d5",
    "name": "Example Webhook Subscription",
    "notification_url": "https://example-webhook-url.com",
    "signature_key": "1k9bIJKCeTmSQwyagtNRLg",
    "updated_at": "2022-01-10 23:29:48 +0000 UTC"
  }
}
```

