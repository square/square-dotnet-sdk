
# Webhook Subscription

Represents the details of a webhook subscription, including notification URL,
event types, and signature key.

## Structure

`WebhookSubscription`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A Square-generated unique ID for the subscription.<br>**Constraints**: *Maximum Length*: `64` |
| `Name` | `string` | Optional | The name of this subscription.<br>**Constraints**: *Maximum Length*: `64` |
| `Enabled` | `bool?` | Optional | Indicates whether the subscription is enabled (`true`) or not (`false`). |
| `EventTypes` | `IList<string>` | Optional | The event types associated with this subscription. |
| `NotificationUrl` | `string` | Optional | The URL to which webhooks are sent. |
| `ApiVersion` | `string` | Optional | The API version of the subscription.<br>This field is optional for `CreateWebhookSubscription`.<br>The value defaults to the API version used by the application. |
| `SignatureKey` | `string` | Optional | The Square-generated signature key used to validate the origin of the webhook event. |
| `CreatedAt` | `string` | Optional | The timestamp of when the subscription was created, in RFC 3339 format. For example, "2016-09-04T23:59:33.123Z". |
| `UpdatedAt` | `string` | Optional | The timestamp of when the subscription was last updated, in RFC 3339 format.<br>For example, "2016-09-04T23:59:33.123Z". |

## Example (as JSON)

```json
{
  "id": "id0",
  "name": "name0",
  "enabled": false,
  "event_types": [
    "event_types8",
    "event_types9"
  ],
  "notification_url": "notification_url4",
  "api_version": "api_version8",
  "signature_key": "signature_key0",
  "created_at": "created_at2",
  "updated_at": "updated_at4"
}
```

