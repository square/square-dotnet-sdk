## Merchant

Represents a Square seller.

### Structure

`Merchant`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The Square-issued ID of the merchant. |
| `BusinessName` | `string` | Optional | The business name of the merchant. |
| `Country` | [`string`](/doc/models/country.md) |  | Indicates the country associated with another entity, such as a business.<br>Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm). |
| `LanguageCode` | `string` | Optional | The language code associated with the merchant account, in BCP 47 format. |
| `Currency` | [`string`](/doc/models/currency.md) | Optional | Indicates the associated currency for an amount of money. Values correspond<br>to [ISO 4217](https://wikipedia.org/wiki/ISO_4217). |
| `Status` | [`string`](/doc/models/merchant-status.md) | Optional | - |
| `MainLocationId` | `string` | Optional | The ID of the main `Location` for this merchant. |

### Example (as JSON)

```json
{
  "id": "id0",
  "business_name": "business_name4",
  "country": "FO",
  "language_code": "language_code8",
  "currency": "YER",
  "status": "ACTIVE"
}
```

