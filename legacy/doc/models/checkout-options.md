
# Checkout Options

## Structure

`CheckoutOptions`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AllowTipping` | `bool?` | Optional | Indicates whether the payment allows tipping. |
| `CustomFields` | [`IList<CustomField>`](../../doc/models/custom-field.md) | Optional | The custom fields requesting information from the buyer. |
| `SubscriptionPlanId` | `string` | Optional | The ID of the subscription plan for the buyer to pay and subscribe.<br>For more information, see [Subscription Plan Checkout](https://developer.squareup.com/docs/checkout-api/subscription-plan-checkout).<br>**Constraints**: *Maximum Length*: `255` |
| `RedirectUrl` | `string` | Optional | The confirmation page URL to redirect the buyer to after Square processes the payment.<br>**Constraints**: *Maximum Length*: `2048` |
| `MerchantSupportEmail` | `string` | Optional | The email address that buyers can use to contact the seller.<br>**Constraints**: *Maximum Length*: `256` |
| `AskForShippingAddress` | `bool?` | Optional | Indicates whether to include the address fields in the payment form. |
| `AcceptedPaymentMethods` | [`AcceptedPaymentMethods`](../../doc/models/accepted-payment-methods.md) | Optional | - |
| `AppFeeMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ShippingFee` | [`ShippingFee`](../../doc/models/shipping-fee.md) | Optional | - |
| `EnableCoupon` | `bool?` | Optional | Indicates whether to include the `Add coupon` section for the buyer to provide a Square marketing coupon in the payment form. |
| `EnableLoyalty` | `bool?` | Optional | Indicates whether to include the `REWARDS` section for the buyer to opt in to loyalty, redeem rewards in the payment form, or both. |

## Example (as JSON)

```json
{
  "allow_tipping": false,
  "custom_fields": [
    {
      "title": "title8"
    },
    {
      "title": "title8"
    },
    {
      "title": "title8"
    }
  ],
  "subscription_plan_id": "subscription_plan_id0",
  "redirect_url": "redirect_url4",
  "merchant_support_email": "merchant_support_email0"
}
```

