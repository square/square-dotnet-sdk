## V1 Payment

A payment represents a paid transaction between a Square merchant and a
customer. Payment details are usually available from Connect API endpoints
within a few minutes after the transaction completes.

Each Payment object includes several fields that end in `_money`. These fields
describe the various amounts of money that contribute to the payment total:

<ul>
<li>
Monetary values are <b>positive</b> if they represent an
<em>increase</em> in the amount of money the merchant receives (e.g.,
<code>tax_money</code>, <code>tip_money</code>).
</li>
<li>
Monetary values are <b>negative</b> if they represent an
<em>decrease</em> in the amount of money the merchant receives (e.g.,
<code>discount_money</code>, <code>refunded_money</code>).
</li>
</ul>

### Structure

`V1Payment`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The payment's unique identifier. |
| `MerchantId` | `string` | Optional | The unique identifier of the merchant that took the payment. |
| `CreatedAt` | `string` | Optional | The time when the payment was created, in ISO 8601 format. Reflects the time of the first payment if the object represents an incomplete partial payment, and the time of the last or complete payment otherwise. |
| `CreatorId` | `string` | Optional | The unique identifier of the Square account that took the payment. |
| `Device` | [`Models.Device`](/doc/models/device.md) | Optional | - |
| `PaymentUrl` | `string` | Optional | The URL of the payment's detail page in the merchant dashboard. The merchant must be signed in to the merchant dashboard to view this page. |
| `ReceiptUrl` | `string` | Optional | The URL of the receipt for the payment. Note that for split tender<br>payments, this URL corresponds to the receipt for the first tender<br>listed in the payment's tender field. Each Tender object has its own<br>receipt_url field you can use to get the other receipts associated with<br>a split tender payment. |
| `InclusiveTaxMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `AdditiveTaxMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `TaxMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `TipMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `DiscountMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `TotalCollectedMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `ProcessingFeeMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `NetTotalMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `RefundedMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `SwedishRoundingMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `GrossSalesMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `NetSalesMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `InclusiveTax` | [`IList<Models.V1PaymentTax>`](/doc/models/v1-payment-tax.md) | Optional | All of the inclusive taxes associated with the payment. |
| `AdditiveTax` | [`IList<Models.V1PaymentTax>`](/doc/models/v1-payment-tax.md) | Optional | All of the additive taxes associated with the payment. |
| `Tender` | [`IList<Models.V1Tender>`](/doc/models/v1-tender.md) | Optional | All of the tenders associated with the payment. |
| `Refunds` | [`IList<Models.V1Refund>`](/doc/models/v1-refund.md) | Optional | All of the refunds applied to the payment. Note that the value of all refunds on a payment can exceed the value of all tenders if a merchant chooses to refund money to a tender after previously accepting returned goods as part of an exchange. |
| `Itemizations` | [`IList<Models.V1PaymentItemization>`](/doc/models/v1-payment-itemization.md) | Optional | The items purchased in the payment. |
| `SurchargeMoney` | [`Models.V1Money`](/doc/models/v1-money.md) | Optional | - |
| `Surcharges` | [`IList<Models.V1PaymentSurcharge>`](/doc/models/v1-payment-surcharge.md) | Optional | A list of all surcharges associated with the payment. |
| `IsPartial` | `bool?` | Optional | Indicates whether or not the payment is only partially paid for.<br>If true, this payment will have the tenders collected so far, but the<br>itemizations will be empty until the payment is completed. |

### Example (as JSON)

```json
{
  "id": "id0",
  "merchant_id": "merchant_id0",
  "created_at": "created_at2",
  "creator_id": "creator_id0",
  "device": {
    "id": "id6",
    "name": "name6"
  }
}
```

