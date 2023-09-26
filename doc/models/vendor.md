
# Vendor

Represents a supplier to a seller.

## Structure

`Vendor`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique Square-generated ID for the [Vendor](entity:Vendor).<br>This field is required when attempting to update a [Vendor](entity:Vendor).<br>**Constraints**: *Maximum Length*: `100` |
| `CreatedAt` | `string` | Optional | An RFC 3339-formatted timestamp that indicates when the<br>[Vendor](entity:Vendor) was created.<br>**Constraints**: *Maximum Length*: `34` |
| `UpdatedAt` | `string` | Optional | An RFC 3339-formatted timestamp that indicates when the<br>[Vendor](entity:Vendor) was last updated.<br>**Constraints**: *Maximum Length*: `34` |
| `Name` | `string` | Optional | The name of the [Vendor](entity:Vendor).<br>This field is required when attempting to create or update a [Vendor](entity:Vendor).<br>**Constraints**: *Maximum Length*: `100` |
| `Address` | [`Address`](../../doc/models/address.md) | Optional | Represents a postal address in a country.<br>For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `Contacts` | [`IList<VendorContact>`](../../doc/models/vendor-contact.md) | Optional | The contacts of the [Vendor](entity:Vendor). |
| `AccountNumber` | `string` | Optional | The account number of the [Vendor](entity:Vendor).<br>**Constraints**: *Maximum Length*: `100` |
| `Note` | `string` | Optional | A note detailing information about the [Vendor](entity:Vendor).<br>**Constraints**: *Maximum Length*: `4096` |
| `Version` | `int?` | Optional | The version of the [Vendor](entity:Vendor). |
| `Status` | [`string`](../../doc/models/vendor-status.md) | Optional | The status of the [Vendor](../../doc/models/vendor.md),<br>whether a [Vendor](../../doc/models/vendor.md) is active or inactive. |

## Example (as JSON)

```json
{
  "id": "id8",
  "created_at": "created_at6",
  "updated_at": "updated_at4",
  "name": "name8",
  "address": {
    "address_line_1": "address_line_16",
    "address_line_2": "address_line_26",
    "address_line_3": "address_line_32",
    "locality": "locality6",
    "sublocality": "sublocality6"
  }
}
```

