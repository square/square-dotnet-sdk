
# Vendor

Represents a supplier to a seller.

## Structure

`Vendor`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique Square-generated ID for the [Vendor](../../doc/models/vendor.md).<br>This field is required when attempting to update a [Vendor](../../doc/models/vendor.md).<br>**Constraints**: *Maximum Length*: `100` |
| `CreatedAt` | `string` | Optional | An RFC 3339-formatted timestamp that indicates when the<br>[Vendor](../../doc/models/vendor.md) was created.<br>**Constraints**: *Maximum Length*: `34` |
| `UpdatedAt` | `string` | Optional | An RFC 3339-formatted timestamp that indicates when the<br>[Vendor](../../doc/models/vendor.md) was last updated.<br>**Constraints**: *Maximum Length*: `34` |
| `Name` | `string` | Optional | The name of the [Vendor](../../doc/models/vendor.md).<br>This field is required when attempting to create or update a [Vendor](../../doc/models/vendor.md).<br>**Constraints**: *Maximum Length*: `100` |
| `Address` | [`Models.Address`](../../doc/models/address.md) | Optional | Represents a postal address in a country.<br>For more information, see [Working with Addresses](https://developer.squareup.com/docs/build-basics/working-with-addresses). |
| `Contacts` | [`IList<Models.VendorContact>`](../../doc/models/vendor-contact.md) | Optional | The contacts of the [Vendor](../../doc/models/vendor.md). |
| `AccountNumber` | `string` | Optional | The account number of the [Vendor](../../doc/models/vendor.md).<br>**Constraints**: *Maximum Length*: `100` |
| `Note` | `string` | Optional | A note detailing information about the [Vendor](../../doc/models/vendor.md).<br>**Constraints**: *Maximum Length*: `4096` |
| `Version` | `int?` | Optional | The version of the [Vendor](../../doc/models/vendor.md). |
| `Status` | [`string`](../../doc/models/vendor-status.md) | Optional | The status of the [Vendor](../../doc/models/vendor.md),<br>whether a [Vendor](../../doc/models/vendor.md) is active or inactive. |

## Example (as JSON)

```json
{
  "id": null,
  "created_at": null,
  "updated_at": null,
  "name": null,
  "address": null,
  "contacts": null,
  "account_number": null,
  "note": null,
  "version": null,
  "status": null
}
```

