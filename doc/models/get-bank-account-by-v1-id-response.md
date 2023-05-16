
# Get Bank Account by V1 Id Response

Response object returned by GetBankAccountByV1Id.

## Structure

`GetBankAccountByV1IdResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Information on errors encountered during the request. |
| `BankAccount` | [`Models.BankAccount`](../../doc/models/bank-account.md) | Optional | Represents a bank account. For more information about<br>linking a bank account to a Square account, see<br>[Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api). |

## Example (as JSON)

```json
{
  "bank_account": {
    "account_number_suffix": "971",
    "account_type": "CHECKING",
    "bank_name": "Bank Name",
    "country": "US",
    "creditable": false,
    "currency": "USD",
    "debitable": false,
    "holder_name": "Jane Doe",
    "id": "w3yRgCGYQnwmdl0R3GB",
    "location_id": "S8GWD5example",
    "primary_bank_identification_number": "112200303",
    "status": "VERIFICATION_IN_PROGRESS",
    "version": 5,
    "secondary_bank_identification_number": "secondary_bank_identification_number4",
    "debit_mandate_reference_id": "debit_mandate_reference_id0",
    "reference_id": "reference_id2",
    "fingerprint": "fingerprint0"
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

