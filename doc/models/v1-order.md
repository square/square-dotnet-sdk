
# V1 Order

V1Order

## Structure

`V1Order`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Id` | `string` | Optional | The order's unique identifier. |
| `BuyerEmail` | `string` | Optional | The email address of the order's buyer. |
| `RecipientName` | `string` | Optional | The name of the order's buyer. |
| `RecipientPhoneNumber` | `string` | Optional | The phone number to use for the order's delivery. |
| `State` | [`string`](../../doc/models/v1-order-state.md) | Optional | - |
| `ShippingAddress` | [`Address`](../../doc/models/address.md) | Optional | Represents a postal address in a country.<br>For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `SubtotalMoney` | [`V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `TotalShippingMoney` | [`V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `TotalTaxMoney` | [`V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `TotalPriceMoney` | [`V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `TotalDiscountMoney` | [`V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `CreatedAt` | `string` | Optional | The time when the order was created, in ISO 8601 format. |
| `UpdatedAt` | `string` | Optional | The time when the order was last modified, in ISO 8601 format. |
| `ExpiresAt` | `string` | Optional | The time when the order expires if no action is taken, in ISO 8601 format. |
| `PaymentId` | `string` | Optional | The unique identifier of the payment associated with the order. |
| `BuyerNote` | `string` | Optional | A note provided by the buyer when the order was created, if any. |
| `CompletedNote` | `string` | Optional | A note provided by the merchant when the order's state was set to COMPLETED, if any |
| `RefundedNote` | `string` | Optional | A note provided by the merchant when the order's state was set to REFUNDED, if any. |
| `CanceledNote` | `string` | Optional | A note provided by the merchant when the order's state was set to CANCELED, if any. |
| `Tender` | [`V1Tender`](../../doc/models/v1-tender.md) | Optional | A tender represents a discrete monetary exchange. Square represents this<br>exchange as a money object with a specific currency and amount, where the<br>amount is given in the smallest denomination of the given currency.<br><br>Square POS can accept more than one form of tender for a single payment (such<br>as by splitting a bill between a credit card and a gift card). The `tender`<br>field of the Payment object lists all forms of tender used for the payment.<br><br>Split tender payments behave slightly differently from single tender payments:<br><br>The receipt_url for a split tender corresponds only to the first tender listed<br>in the tender field. To get the receipt URLs for the remaining tenders, use<br>the receipt_url fields of the corresponding Tender objects.<br><br>*A note on gift cards**: when a customer purchases a Square gift card from a<br>merchant, the merchant receives the full amount of the gift card in the<br>associated payment.<br><br>When that gift card is used as a tender, the balance of the gift card is<br>reduced and the merchant receives no funds. A `Tender` object with a type of<br>`SQUARE_GIFT_CARD` indicates a gift card was used for some or all of the<br>associated payment. |
| `OrderHistory` | [`IList<V1OrderHistoryEntry>`](../../doc/models/v1-order-history-entry.md) | Optional | The history of actions associated with the order. |
| `PromoCode` | `string` | Optional | The promo code provided by the buyer, if any. |
| `BtcReceiveAddress` | `string` | Optional | For Bitcoin transactions, the address that the buyer sent Bitcoin to. |
| `BtcPriceSatoshi` | `double?` | Optional | For Bitcoin transactions, the price of the buyer's order in satoshi (100 million satoshi equals 1 BTC). |

## Example (as JSON)

```json
{
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "MAP_KEY_LENGTH_TOO_LONG",
      "detail": "detail6",
      "field": "field4"
    }
  ],
  "id": "id0",
  "buyer_email": "buyer_email8",
  "recipient_name": "recipient_name8",
  "recipient_phone_number": "recipient_phone_number4"
}
```

