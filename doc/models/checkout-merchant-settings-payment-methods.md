
# Checkout Merchant Settings Payment Methods

## Structure

`CheckoutMerchantSettingsPaymentMethods`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ApplePay` | [`CheckoutMerchantSettingsPaymentMethodsPaymentMethod`](../../doc/models/checkout-merchant-settings-payment-methods-payment-method.md) | Optional | The settings allowed for a payment method. |
| `GooglePay` | [`CheckoutMerchantSettingsPaymentMethodsPaymentMethod`](../../doc/models/checkout-merchant-settings-payment-methods-payment-method.md) | Optional | The settings allowed for a payment method. |
| `CashApp` | [`CheckoutMerchantSettingsPaymentMethodsPaymentMethod`](../../doc/models/checkout-merchant-settings-payment-methods-payment-method.md) | Optional | The settings allowed for a payment method. |
| `AfterpayClearpay` | [`CheckoutMerchantSettingsPaymentMethodsAfterpayClearpay`](../../doc/models/checkout-merchant-settings-payment-methods-afterpay-clearpay.md) | Optional | The settings allowed for AfterpayClearpay. |

## Example (as JSON)

```json
{
  "apple_pay": {
    "enabled": false
  },
  "google_pay": {
    "enabled": false
  },
  "cash_app": {
    "enabled": false
  },
  "afterpay_clearpay": {
    "order_eligibility_range": {
      "min": {
        "amount": 34,
        "currency": "ISK"
      },
      "max": {
        "amount": 140,
        "currency": "OMR"
      }
    },
    "item_eligibility_range": {
      "min": {
        "amount": 34,
        "currency": "ISK"
      },
      "max": {
        "amount": 140,
        "currency": "OMR"
      }
    },
    "enabled": false
  }
}
```

