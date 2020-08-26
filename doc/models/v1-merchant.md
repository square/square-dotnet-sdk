## V1 Merchant

Defines the fields that are included in the response body of
a request to the **RetrieveBusiness** endpoint.

### Structure

`V1Merchant`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The merchant account's unique identifier. |
| `Name` | `string` | Optional | The name associated with the merchant account. |
| `Email` | `string` | Optional | The email address associated with the merchant account. |
| `AccountType` | [`string`](/doc/models/v1-merchant-account-type.md) | Optional | - |
| `AccountCapabilities` | `IList<string>` | Optional | Capabilities that are enabled for the merchant's Square account. Capabilities that are not listed in this array are not enabled for the account. |
| `CountryCode` | `string` | Optional | The country associated with the merchant account, in ISO 3166-1-alpha-2 format. |
| `LanguageCode` | `string` | Optional | The language associated with the merchant account, in BCP 47 format. |
| `CurrencyCode` | `string` | Optional | The currency associated with the merchant account, in ISO 4217 format. For example, the currency code for US dollars is USD. |
| `BusinessName` | `string` | Optional | The name of the merchant's business. |
| `BusinessAddress` | [`Models.Address`](/doc/models/address.md) | Optional | Represents a physical address. |
| `BusinessPhone` | [`Models.V1PhoneNumber`](/doc/models/v1-phone-number.md) | Optional | Represents a phone number. |
| `BusinessType` | [`string`](/doc/models/v1-merchant-business-type.md) | Optional | - |
| `ShippingAddress` | [`Models.Address`](/doc/models/address.md) | Optional | Represents a physical address. |
| `LocationDetails` | [`Models.V1MerchantLocationDetails`](/doc/models/v1-merchant-location-details.md) | Optional | Additional information for a single-location account specified by its associated business account, if it has one. |
| `MarketUrl` | `string` | Optional | The URL of the merchant's online store. |

### Example (as JSON)

```json
{
  "id": "id0",
  "name": "name0",
  "email": "email6",
  "account_type": "LOCATION",
  "account_capabilities": [
    "account_capabilities8"
  ]
}
```

