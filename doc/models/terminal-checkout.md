
# Terminal Checkout

Represents a checkout processed by the Square Terminal.

## Structure

`TerminalCheckout`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique ID for this `TerminalCheckout`.<br>**Constraints**: *Minimum Length*: `10`, *Maximum Length*: `255` |
| `AmountMoney` | [`Money`](../../doc/models/money.md) | Required | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ReferenceId` | `string` | Optional | An optional user-defined reference ID that can be used to associate<br>this `TerminalCheckout` to another entity in an external system. For example, an order<br>ID generated by a third-party shopping cart. The ID is also associated with any payments<br>used to complete the checkout.<br>**Constraints**: *Maximum Length*: `40` |
| `Note` | `string` | Optional | An optional note to associate with the checkout, as well as with any payments used to complete the checkout.<br>Note: maximum 500 characters<br>**Constraints**: *Maximum Length*: `500` |
| `OrderId` | `string` | Optional | The reference to the Square order ID for the checkout request. Supported only in the US. |
| `PaymentOptions` | [`PaymentOptions`](../../doc/models/payment-options.md) | Optional | - |
| `DeviceOptions` | [`DeviceCheckoutOptions`](../../doc/models/device-checkout-options.md) | Required | - |
| `DeadlineDuration` | `string` | Optional | An RFC 3339 duration, after which the checkout is automatically canceled.<br>A `TerminalCheckout` that is `PENDING` is automatically `CANCELED` and has a cancellation reason<br>of `TIMED_OUT`.<br><br>Default: 5 minutes from creation<br><br>Maximum: 5 minutes |
| `Status` | `string` | Optional | The status of the `TerminalCheckout`.<br>Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, `COMPLETED` |
| `CancelReason` | [`string`](../../doc/models/action-cancel-reason.md) | Optional | - |
| `PaymentIds` | `IList<string>` | Optional | A list of IDs for payments created by this `TerminalCheckout`. |
| `CreatedAt` | `string` | Optional | The time when the `TerminalCheckout` was created, as an RFC 3339 timestamp. |
| `UpdatedAt` | `string` | Optional | The time when the `TerminalCheckout` was last updated, as an RFC 3339 timestamp. |
| `AppId` | `string` | Optional | The ID of the application that created the checkout. |
| `LocationId` | `string` | Optional | The location of the device where the `TerminalCheckout` was directed.<br>**Constraints**: *Maximum Length*: `64` |
| `PaymentType` | [`string`](../../doc/models/checkout-options-payment-type.md) | Optional | - |
| `TeamMemberId` | `string` | Optional | An optional ID of the team member associated with creating the checkout. |
| `CustomerId` | `string` | Optional | An optional ID of the customer associated with the checkout. |
| `AppFeeMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `StatementDescriptionIdentifier` | `string` | Optional | Optional additional payment information to include on the customer's card statement as<br>part of the statement description. This can be, for example, an invoice number, ticket number,<br>or short description that uniquely identifies the purchase. Supported only in the US.<br>**Constraints**: *Maximum Length*: `20` |
| `TipMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |

## Example (as JSON)

```json
{
  "id": "id6",
  "amount_money": {
    "amount": 186,
    "currency": "AUD"
  },
  "reference_id": "reference_id6",
  "note": "note8",
  "order_id": "order_id0",
  "payment_options": {
    "autocomplete": false,
    "delay_duration": "delay_duration2",
    "accept_partial_authorization": false,
    "delay_action": "CANCEL"
  },
  "device_options": {
    "device_id": "device_id6",
    "skip_receipt_screen": false,
    "collect_signature": false,
    "tip_settings": {
      "allow_tipping": false,
      "separate_tip_screen": false,
      "custom_tip_field": false,
      "tip_percentages": [
        48
      ],
      "smart_tipping": false
    },
    "show_itemized_cart": false
  }
}
```

