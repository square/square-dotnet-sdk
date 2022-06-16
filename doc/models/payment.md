
# Payment

Represents a payment processed by the Square API.

## Structure

`Payment`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique ID for the payment.<br>**Constraints**: *Maximum Length*: `192` |
| `CreatedAt` | `string` | Optional | The timestamp of when the payment was created, in RFC 3339 format.<br>**Constraints**: *Maximum Length*: `32` |
| `UpdatedAt` | `string` | Optional | The timestamp of when the payment was last updated, in RFC 3339 format.<br>**Constraints**: *Maximum Length*: `32` |
| `AmountMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TipMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `TotalMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `AppFeeMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ApprovedMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ProcessingFee` | [`IList<Models.ProcessingFee>`](../../doc/models/processing-fee.md) | Optional | The processing fees and fee adjustments assessed by Square for this payment. |
| `RefundedMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `Status` | `string` | Optional | Indicates whether the payment is APPROVED, PENDING, COMPLETED, CANCELED, or FAILED.<br>**Constraints**: *Maximum Length*: `50` |
| `DelayDuration` | `string` | Optional | The duration of time after the payment's creation when Square automatically applies the<br>`delay_action` to the payment. This automatic `delay_action` applies only to payments that<br>do not reach a terminal state (COMPLETED, CANCELED, or FAILED) before the `delay_duration`<br>time period.<br><br>This field is specified as a time duration, in RFC 3339 format.<br><br>Notes:<br>This feature is only supported for card payments.<br><br>Default:<br><br>- Card-present payments: "PT36H" (36 hours) from the creation time.<br>- Card-not-present payments: "P7D" (7 days) from the creation time. |
| `DelayAction` | `string` | Optional | The action to be applied to the payment when the `delay_duration` has elapsed.<br><br>Current values include `CANCEL` and `COMPLETE`. |
| `DelayedUntil` | `string` | Optional | The read-only timestamp of when the `delay_action` is automatically applied,<br>in RFC 3339 format.<br><br>Note that this field is calculated by summing the payment's `delay_duration` and `created_at`<br>fields. The `created_at` field is generated by Square and might not exactly match the<br>time on your local machine. |
| `SourceType` | `string` | Optional | The source type for this payment.<br><br>Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `BUY_NOW_PAY_LATER`, `CASH`, or<br>`EXTERNAL`. For information about these payment source types,<br>see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).<br>**Constraints**: *Maximum Length*: `50` |
| `CardDetails` | [`Models.CardPaymentDetails`](../../doc/models/card-payment-details.md) | Optional | Reflects the current status of a card payment. Contains only non-confidential information. |
| `CashDetails` | [`Models.CashPaymentDetails`](../../doc/models/cash-payment-details.md) | Optional | Stores details about a cash payment. Contains only non-confidential information. For more information, see<br>[Take Cash Payments](https://developer.squareup.com/docs/payments-api/take-payments/cash-payments). |
| `BankAccountDetails` | [`Models.BankAccountPaymentDetails`](../../doc/models/bank-account-payment-details.md) | Optional | Additional details about BANK_ACCOUNT type payments. |
| `ExternalDetails` | [`Models.ExternalPaymentDetails`](../../doc/models/external-payment-details.md) | Optional | Stores details about an external payment. Contains only non-confidential information.<br>For more information, see<br>[Take External Payments](https://developer.squareup.com/docs/payments-api/take-payments/external-payments). |
| `WalletDetails` | [`Models.DigitalWalletDetails`](../../doc/models/digital-wallet-details.md) | Optional | Additional details about `WALLET` type payments. Contains only non-confidential information. |
| `BuyNowPayLaterDetails` | [`Models.BuyNowPayLaterDetails`](../../doc/models/buy-now-pay-later-details.md) | Optional | Additional details about a Buy Now Pay Later payment type. |
| `LocationId` | `string` | Optional | The ID of the location associated with the payment.<br>**Constraints**: *Maximum Length*: `50` |
| `OrderId` | `string` | Optional | The ID of the order associated with the payment.<br>**Constraints**: *Maximum Length*: `192` |
| `ReferenceId` | `string` | Optional | An optional ID that associates the payment with an entity in<br>another system.<br>**Constraints**: *Maximum Length*: `40` |
| `CustomerId` | `string` | Optional | The [Customer](../../doc/models/customer.md) ID of the customer associated with the payment.<br>**Constraints**: *Maximum Length*: `191` |
| `EmployeeId` | `string` | Optional | __Deprecated__: Use `Payment.team_member_id` instead.<br><br>An optional ID of the employee associated with taking the payment.<br>**Constraints**: *Maximum Length*: `192` |
| `TeamMemberId` | `string` | Optional | An optional ID of the [TeamMember](../../doc/models/team-member.md) associated with taking the payment.<br>**Constraints**: *Maximum Length*: `192` |
| `RefundIds` | `IList<string>` | Optional | A list of `refund_id`s identifying refunds for the payment. |
| `RiskEvaluation` | [`Models.RiskEvaluation`](../../doc/models/risk-evaluation.md) | Optional | Represents fraud risk information for the associated payment.<br><br>When you take a payment through Square's Payments API (using the `CreatePayment`<br>endpoint), Square evaluates it and assigns a risk level to the payment. Sellers<br>can use this information to determine the course of action (for example,<br>provide the goods/services or refund the payment). |
| `BuyerEmailAddress` | `string` | Optional | The buyer's email address.<br>**Constraints**: *Maximum Length*: `255` |
| `BillingAddress` | [`Models.Address`](../../doc/models/address.md) | Optional | Represents a postal address in a country.<br>For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `ShippingAddress` | [`Models.Address`](../../doc/models/address.md) | Optional | Represents a postal address in a country.<br>For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `Note` | `string` | Optional | An optional note to include when creating a payment.<br>**Constraints**: *Maximum Length*: `500` |
| `StatementDescriptionIdentifier` | `string` | Optional | Additional payment information that gets added to the customer's card statement<br>as part of the statement description.<br><br>Note that the `statement_description_identifier` might get truncated on the statement description<br>to fit the required information including the Square identifier (SQ *) and the name of the<br>seller taking the payment. |
| `Capabilities` | `IList<string>` | Optional | Actions that can be performed on this payment:<br><br>- `EDIT_AMOUNT_UP` - The payment amount can be edited up.<br>- `EDIT_AMOUNT_DOWN` - The payment amount can be edited down.<br>- `EDIT_TIP_AMOUNT_UP` - The tip amount can be edited up.<br>- `EDIT_TIP_AMOUNT_DOWN` - The tip amount can be edited down.<br>- `EDIT_DELAY_ACTION` - The delay_action can be edited. |
| `ReceiptNumber` | `string` | Optional | The payment's receipt number.<br>The field is missing if a payment is canceled.<br>**Constraints**: *Maximum Length*: `4` |
| `ReceiptUrl` | `string` | Optional | The URL for the payment's receipt.<br>The field is only populated for COMPLETED payments.<br>**Constraints**: *Maximum Length*: `255` |
| `DeviceDetails` | [`Models.DeviceDetails`](../../doc/models/device-details.md) | Optional | Details about the device that took the payment. |
| `ApplicationDetails` | [`Models.ApplicationDetails`](../../doc/models/application-details.md) | Optional | Details about the application that took the payment. |
| `VersionToken` | `string` | Optional | Used for optimistic concurrency. This opaque token identifies a specific version of the<br>`Payment` object. |

## Example (as JSON)

```json
{
  "id": null,
  "created_at": null,
  "updated_at": null,
  "amount_money": null,
  "tip_money": null,
  "total_money": null,
  "app_fee_money": null,
  "approved_money": null,
  "processing_fee": null,
  "refunded_money": null,
  "status": null,
  "delay_duration": null,
  "delay_action": null,
  "delayed_until": null,
  "source_type": null,
  "card_details": null,
  "cash_details": null,
  "bank_account_details": null,
  "external_details": null,
  "wallet_details": null,
  "buy_now_pay_later_details": null,
  "location_id": null,
  "order_id": null,
  "reference_id": null,
  "customer_id": null,
  "employee_id": null,
  "team_member_id": null,
  "refund_ids": null,
  "risk_evaluation": null,
  "buyer_email_address": null,
  "billing_address": null,
  "shipping_address": null,
  "note": null,
  "statement_description_identifier": null,
  "capabilities": null,
  "receipt_number": null,
  "receipt_url": null,
  "device_details": null,
  "application_details": null,
  "version_token": null
}
```

