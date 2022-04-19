
# Location

Represents one of a business' [locations](https://developer.squareup.com/docs/locations-api).

## Structure

`Location`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A short generated string of letters and numbers that uniquely identifies this location instance.<br>**Constraints**: *Maximum Length*: `32` |
| `Name` | `string` | Optional | The name of the location.<br>This information appears in the Seller Dashboard as the nickname.<br>A location name must be unique within a seller account.<br>**Constraints**: *Maximum Length*: `255` |
| `Address` | [`Models.Address`](../../doc/models/address.md) | Optional | Represents a postal address in a country.<br>For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `Timezone` | `string` | Optional | The [IANA time zone](https://www.iana.org/time-zones) identifier for<br>the time zone of the location. For example, `America/Los_Angeles`.<br>**Constraints**: *Maximum Length*: `30` |
| `Capabilities` | [`IList<string>`](../../doc/models/location-capability.md) | Optional | The Square features that are enabled for the location.<br>See [LocationCapability](../../doc/models/location-capability.md) for possible values.<br>See [LocationCapability](#type-locationcapability) for possible values |
| `Status` | [`string`](../../doc/models/location-status.md) | Optional | A location's status. |
| `CreatedAt` | `string` | Optional | The time when the location was created, in RFC 3339 format.<br>For more information, see [Working with Dates](https://developer.squareup.com/docs/build-basics/working-with-dates).<br>**Constraints**: *Minimum Length*: `20`, *Maximum Length*: `25` |
| `MerchantId` | `string` | Optional | The ID of the merchant that owns the location.<br>**Constraints**: *Maximum Length*: `32` |
| `Country` | [`string`](../../doc/models/country.md) | Optional | Indicates the country associated with another entity, such as a business.<br>Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm). |
| `LanguageCode` | `string` | Optional | The language associated with the location, in<br>[BCP 47 format](https://tools.ietf.org/html/bcp47#appendix-A).<br>For more information, see [Location language code](https://developer.squareup.com/docs/locations-api#location-language-code).<br>**Constraints**: *Minimum Length*: `5`, *Maximum Length*: `5` |
| `Currency` | [`string`](../../doc/models/currency.md) | Optional | Indicates the associated currency for an amount of money. Values correspond<br>to [ISO 4217](https://wikipedia.org/wiki/ISO_4217). |
| `PhoneNumber` | `string` | Optional | The phone number of the location. For example, `+1 855-700-6000`.<br>**Constraints**: *Maximum Length*: `17` |
| `BusinessName` | `string` | Optional | The name of the location's overall business. This name is present on receipts and other customer-facing branding.<br>**Constraints**: *Maximum Length*: `255` |
| `Type` | [`string`](../../doc/models/location-type.md) | Optional | A location's type. |
| `WebsiteUrl` | `string` | Optional | The website URL of the location.  For example, `https://squareup.com`.<br>**Constraints**: *Maximum Length*: `255` |
| `BusinessHours` | [`Models.BusinessHours`](../../doc/models/business-hours.md) | Optional | The hours of operation for a location. |
| `BusinessEmail` | `string` | Optional | The email address of the location. This can be unique to the location and is not always the email address for the business owner or administrator.<br>**Constraints**: *Maximum Length*: `255` |
| `Description` | `string` | Optional | The description of the location. For example, `Main Street location`.<br>**Constraints**: *Maximum Length*: `1024` |
| `TwitterUsername` | `string` | Optional | The Twitter username of the location without the '@' symbol. For example, `Square`.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `15` |
| `InstagramUsername` | `string` | Optional | The Instagram username of the location without the '@' symbol. For example, `square`.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `30` |
| `FacebookUrl` | `string` | Optional | The Facebook profile URL of the location. The URL should begin with 'facebook.com/'. For example, `https://www.facebook.com/square`.<br>**Constraints**: *Maximum Length*: `255` |
| `Coordinates` | [`Models.Coordinates`](../../doc/models/coordinates.md) | Optional | Latitude and longitude coordinates. |
| `LogoUrl` | `string` | Optional | The URL of the logo image for the location. When configured in the Seller<br>Dashboard (Receipts section), the logo appears on transactions (such as receipts and invoices) that Square generates on behalf of the seller.<br>This image should have a roughly square (1:1) aspect ratio and should be at least 200x200 pixels.<br>**Constraints**: *Maximum Length*: `255` |
| `PosBackgroundUrl` | `string` | Optional | The URL of the Point of Sale background image for the location.<br>**Constraints**: *Maximum Length*: `255` |
| `Mcc` | `string` | Optional | A four-digit number that describes the kind of goods or services sold at the location.<br>The [merchant category code (MCC)](https://developer.squareup.com/docs/locations-api#initialize-a-merchant-category-code) of the location as standardized by ISO 18245.<br>For example, `5045`, for a location that sells computer goods and software.<br>**Constraints**: *Minimum Length*: `4`, *Maximum Length*: `4` |
| `FullFormatLogoUrl` | `string` | Optional | The URL of a full-format logo image for the location. When configured in the Seller<br>Dashboard (Receipts section), the logo appears on transactions (such as receipts and invoices) that Square generates on behalf of the seller.<br>This image can be wider than it is tall and should be at least 1280x648 pixels. |
| `TaxIds` | [`Models.TaxIds`](../../doc/models/tax-ids.md) | Optional | Identifiers for the location used by various governments for tax purposes. |

## Example (as JSON)

```json
{
  "id": "id0",
  "name": "name0",
  "address": {
    "address_line_1": "address_line_16",
    "address_line_2": "address_line_26",
    "address_line_3": "address_line_32",
    "locality": "locality6",
    "sublocality": "sublocality6"
  },
  "timezone": "timezone0",
  "capabilities": [
    "AUTOMATIC_TRANSFERS"
  ]
}
```

