
# Address

Represents a postal address in a country.
For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses).

## Structure

`Address`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AddressLine1` | `string` | Optional | The first line of the address.<br><br>Fields that start with `address_line` provide the address's most specific<br>details, like street number, street name, and building name. They do *not*<br>provide less specific details like city, state/province, or country (these<br>details are provided in other fields). |
| `AddressLine2` | `string` | Optional | The second line of the address, if any. |
| `AddressLine3` | `string` | Optional | The third line of the address, if any. |
| `Locality` | `string` | Optional | The city or town of the address. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `Sublocality` | `string` | Optional | A civil region within the address's `locality`, if any. |
| `Sublocality2` | `string` | Optional | A civil region within the address's `sublocality`, if any. |
| `Sublocality3` | `string` | Optional | A civil region within the address's `sublocality_2`, if any. |
| `AdministrativeDistrictLevel1` | `string` | Optional | A civil entity within the address's country. In the US, this<br>is the state. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `AdministrativeDistrictLevel2` | `string` | Optional | A civil entity within the address's `administrative_district_level_1`.<br>In the US, this is the county. |
| `AdministrativeDistrictLevel3` | `string` | Optional | A civil entity within the address's `administrative_district_level_2`,<br>if any. |
| `PostalCode` | `string` | Optional | The address's postal code. For a full list of field meanings by country, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `Country` | [`string`](../../doc/models/country.md) | Optional | Indicates the country associated with another entity, such as a business.<br>Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm). |
| `FirstName` | `string` | Optional | Optional first name when it's representing recipient. |
| `LastName` | `string` | Optional | Optional last name when it's representing recipient. |

## Example (as JSON)

```json
{
  "address_line_1": null,
  "address_line_2": null,
  "address_line_3": null,
  "locality": null,
  "sublocality": null,
  "sublocality_2": null,
  "sublocality_3": null,
  "administrative_district_level_1": null,
  "administrative_district_level_2": null,
  "administrative_district_level_3": null,
  "postal_code": null,
  "country": null,
  "first_name": null,
  "last_name": null
}
```

