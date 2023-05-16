
# Bank Account

Represents a bank account. For more information about
linking a bank account to a Square account, see
[Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).

## Structure

`BankAccount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | The unique, Square-issued identifier for the bank account.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `30` |
| `AccountNumberSuffix` | `string` | Required | The last few digits of the account number.<br>**Constraints**: *Minimum Length*: `1` |
| `Country` | [`string`](../../doc/models/country.md) | Required | Indicates the country associated with another entity, such as a business.<br>Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm). |
| `Currency` | [`string`](../../doc/models/currency.md) | Required | Indicates the associated currency for an amount of money. Values correspond<br>to [ISO 4217](https://wikipedia.org/wiki/ISO_4217). |
| `AccountType` | [`string`](../../doc/models/bank-account-type.md) | Required | Indicates the financial purpose of the bank account. |
| `HolderName` | `string` | Required | Name of the account holder. This name must match the name<br>on the targeted bank account record.<br>**Constraints**: *Minimum Length*: `1` |
| `PrimaryBankIdentificationNumber` | `string` | Required | Primary identifier for the bank. For more information, see<br>[Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).<br>**Constraints**: *Maximum Length*: `40` |
| `SecondaryBankIdentificationNumber` | `string` | Optional | Secondary identifier for the bank. For more information, see<br>[Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).<br>**Constraints**: *Maximum Length*: `40` |
| `DebitMandateReferenceId` | `string` | Optional | Reference identifier that will be displayed to UK bank account owners<br>when collecting direct debit authorization. Only required for UK bank accounts. |
| `ReferenceId` | `string` | Optional | Client-provided identifier for linking the banking account to an entity<br>in a third-party system (for example, a bank account number or a user identifier). |
| `LocationId` | `string` | Optional | The location to which the bank account belongs. |
| `Status` | [`string`](../../doc/models/bank-account-status.md) | Required | Indicates the current verification status of a `BankAccount` object. |
| `Creditable` | `bool` | Required | Indicates whether it is possible for Square to send money to this bank account. |
| `Debitable` | `bool` | Required | Indicates whether it is possible for Square to take money from this<br>bank account. |
| `Fingerprint` | `string` | Optional | A Square-assigned, unique identifier for the bank account based on the<br>account information. The account fingerprint can be used to compare account<br>entries and determine if the they represent the same real-world bank account. |
| `Version` | `int?` | Optional | The current version of the `BankAccount`. |
| `BankName` | `string` | Optional | Read only. Name of actual financial institution.<br>For example "Bank of America".<br>**Constraints**: *Maximum Length*: `100` |

## Example (as JSON)

```json
{
  "id": "id0",
  "account_number_suffix": "account_number_suffix8",
  "country": "FO",
  "currency": "YER",
  "account_type": "BUSINESS_CHECKING",
  "holder_name": "holder_name4",
  "primary_bank_identification_number": "primary_bank_identification_number8",
  "secondary_bank_identification_number": "secondary_bank_identification_number0",
  "debit_mandate_reference_id": "debit_mandate_reference_id4",
  "reference_id": "reference_id2",
  "location_id": "location_id4",
  "status": "DISABLED",
  "creditable": false,
  "debitable": false,
  "fingerprint": "fingerprint6"
}
```

