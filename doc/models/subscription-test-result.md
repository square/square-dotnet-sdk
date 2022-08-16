
# Subscription Test Result

Represents the details of a webhook subscription, including notification URL,
event types, and signature key.

## Structure

`SubscriptionTestResult`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A Square-generated unique ID for the subscription test result.<br>**Constraints**: *Maximum Length*: `64` |
| `StatusCode` | `int?` | Optional | The status code returned by the subscription notification URL. |
| `Payload` | `string` | Optional | An object containing the payload of the test event. For example, a `payment.created` event. |
| `CreatedAt` | `string` | Optional | The timestamp of when the subscription was created, in RFC 3339 format.<br>For example, "2016-09-04T23:59:33.123Z". |
| `UpdatedAt` | `string` | Optional | The timestamp of when the subscription was updated, in RFC 3339 format. For example, "2016-09-04T23:59:33.123Z".<br>Because a subscription test result is unique, this field is the same as the `created_at` field. |

## Example (as JSON)

```json
{
  "status_code": null,
  "payload": null
}
```

