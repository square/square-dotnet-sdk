
# Order Fulfillment Recipient

Information about the fulfillment recipient.

## Structure

`OrderFulfillmentRecipient`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomerId` | `string` | Optional | The ID of the customer associated with the fulfillment.<br>If `customer_id` is provided, the fulfillment recipient's `display_name`,<br>`email_address`, and `phone_number` are automatically populated from the<br>targeted customer profile. If these fields are set in the request, the request<br>values override the information from the customer profile. If the<br>targeted customer profile does not contain the necessary information and<br>these fields are left unset, the request results in an error.<br>**Constraints**: *Maximum Length*: `191` |
| `DisplayName` | `string` | Optional | The display name of the fulfillment recipient. This field is required.<br>If provided, the display name overrides the corresponding customer profile value<br>indicated by `customer_id`.<br>**Constraints**: *Maximum Length*: `255` |
| `EmailAddress` | `string` | Optional | The email address of the fulfillment recipient.<br>If provided, the email address overrides the corresponding customer profile value<br>indicated by `customer_id`.<br>**Constraints**: *Maximum Length*: `255` |
| `PhoneNumber` | `string` | Optional | The phone number of the fulfillment recipient. This field is required.<br>If provided, the phone number overrides the corresponding customer profile value<br>indicated by `customer_id`.<br>**Constraints**: *Maximum Length*: `17` |
| `Address` | [`Models.Address`](../../doc/models/address.md) | Optional | Represents a postal address in a country.<br>For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |

## Example (as JSON)

```json
{
  "customer_id": null,
  "display_name": null,
  "email_address": null,
  "phone_number": null,
  "address": null
}
```

