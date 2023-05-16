
# Retrieve Transaction Response

Defines the fields that are included in the response body of
a request to the [RetrieveTransaction](api-endpoint:Transactions-RetrieveTransaction) endpoint.

One of `errors` or `transaction` is present in a given response (never both).

## Structure

`RetrieveTransactionResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Transaction` | [`Models.Transaction`](../../doc/models/transaction.md) | Optional | Represents a transaction processed with Square, either with the<br>Connect API or with Square Point of Sale.<br><br>The `tenders` field of this object lists all methods of payment used to pay in<br>the transaction. |

## Example (as JSON)

```json
{
  "transaction": {
    "created_at": "2016-03-10T22:57:56Z",
    "id": "KnL67ZIwXCPtzOrqj0HrkxMF",
    "location_id": "18YC4JDH91E1H",
    "product": "EXTERNAL_API",
    "reference_id": "some optional reference id",
    "tenders": [
      {
        "additional_recipients": [
          {
            "amount_money": {
              "amount": 20,
              "currency": "USD"
            },
            "description": "Application fees",
            "location_id": "057P5VYJ4A5X1"
          }
        ],
        "amount_money": {
          "amount": 5000,
          "currency": "USD"
        },
        "card_details": {
          "card": {
            "card_brand": "VISA",
            "last_4": "1111"
          },
          "entry_method": "KEYED",
          "status": "CAPTURED"
        },
        "created_at": "2016-03-10T22:57:56Z",
        "id": "MtZRYYdDrYNQbOvV7nbuBvMF",
        "location_id": "18YC4JDH91E1H",
        "note": "some optional note",
        "processing_fee_money": {
          "amount": 138,
          "currency": "USD"
        },
        "transaction_id": "KnL67ZIwXCPtzOrqj0HrkxMF",
        "type": "CARD"
      }
    ],
    "refunds": [
      {
        "id": "id6",
        "location_id": "location_id0",
        "transaction_id": "transaction_id4",
        "tender_id": "tender_id4",
        "created_at": "created_at6",
        "reason": "reason8",
        "amount_money": {
          "amount": 162,
          "currency": "AOA"
        },
        "status": "PENDING",
        "processing_fee_money": {
          "amount": 88,
          "currency": "HUF"
        },
        "additional_recipients": [
          {
            "location_id": "location_id9",
            "description": "description5",
            "amount_money": {
              "amount": 59,
              "currency": "LAK"
            },
            "receivable_id": "receivable_id5"
          }
        ]
      },
      {
        "id": "id7",
        "location_id": "location_id1",
        "transaction_id": "transaction_id5",
        "tender_id": "tender_id5",
        "created_at": "created_at5",
        "reason": "reason7",
        "amount_money": {
          "amount": 163,
          "currency": "ARS"
        },
        "status": "FAILED",
        "processing_fee_money": {
          "amount": 89,
          "currency": "IDR"
        },
        "additional_recipients": [
          {
            "location_id": "location_id0",
            "description": "description6",
            "amount_money": {
              "amount": 60,
              "currency": "LBP"
            },
            "receivable_id": "receivable_id6"
          },
          {
            "location_id": "location_id1",
            "description": "description7",
            "amount_money": {
              "amount": 61,
              "currency": "LKR"
            },
            "receivable_id": "receivable_id7"
          }
        ]
      },
      {
        "id": "id8",
        "location_id": "location_id2",
        "transaction_id": "transaction_id6",
        "tender_id": "tender_id6",
        "created_at": "created_at4",
        "reason": "reason6",
        "amount_money": {
          "amount": 164,
          "currency": "AUD"
        },
        "status": "REJECTED",
        "processing_fee_money": {
          "amount": 90,
          "currency": "ILS"
        },
        "additional_recipients": [
          {
            "location_id": "location_id1",
            "description": "description7",
            "amount_money": {
              "amount": 61,
              "currency": "LKR"
            },
            "receivable_id": "receivable_id7"
          },
          {
            "location_id": "location_id2",
            "description": "description8",
            "amount_money": {
              "amount": 62,
              "currency": "LRD"
            },
            "receivable_id": "receivable_id8"
          },
          {
            "location_id": "location_id3",
            "description": "description9",
            "amount_money": {
              "amount": 63,
              "currency": "LSL"
            },
            "receivable_id": "receivable_id9"
          }
        ]
      }
    ]
  },
  "errors": [
    {
      "category": "AUTHENTICATION_ERROR",
      "code": "REFUND_ALREADY_PENDING",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "INVALID_REQUEST_ERROR",
      "code": "PAYMENT_NOT_REFUNDABLE",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "RATE_LIMIT_ERROR",
      "code": "REFUND_DECLINED",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

