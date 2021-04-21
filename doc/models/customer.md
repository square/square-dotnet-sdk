
# Customer

Represents a Square customer profile, which can have one or more
cards on file associated with it.

## Structure

`Customer`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | A unique Square-assigned ID for the customer profile. |
| `CreatedAt` | `string` | Optional | The timestamp when the customer profile was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp when the customer profile was last updated, in RFC 3339 format. |
| `Cards` | [`IList<Models.Card>`](/doc/models/card.md) | Optional | Payment details of the credit, debit, and gift cards stored on file for the customer profile. |
| `GivenName` | `string` | Optional | The given (i.e., first) name associated with the customer profile. |
| `FamilyName` | `string` | Optional | The family (i.e., last) name associated with the customer profile. |
| `Nickname` | `string` | Optional | A nickname for the customer profile. |
| `CompanyName` | `string` | Optional | A business name associated with the customer profile. |
| `EmailAddress` | `string` | Optional | The email address associated with the customer profile. |
| `Address` | [`Models.Address`](/doc/models/address.md) | Optional | Represents a physical address. |
| `PhoneNumber` | `string` | Optional | The 11-digit phone number associated with the customer profile. |
| `Birthday` | `string` | Optional | The birthday associated with the customer profile, in RFC 3339 format. The year is optional. The timezone and time are not allowed.<br>For example, `0000-09-21T00:00:00-00:00` represents a birthday on September 21 and `1998-09-21T00:00:00-00:00` represents a birthday on September 21, 1998. |
| `ReferenceId` | `string` | Optional | An optional second ID used to associate the customer profile with an<br>entity in another system. |
| `Note` | `string` | Optional | A custom note associated with the customer profile. |
| `Preferences` | [`Models.CustomerPreferences`](/doc/models/customer-preferences.md) | Optional | Represents communication preferences for the customer profile. |
| `CreationSource` | [`string`](/doc/models/customer-creation-source.md) | Optional | Indicates the method used to create the customer profile. |
| `GroupIds` | `IList<string>` | Optional | The IDs of customer groups the customer belongs to. |
| `SegmentIds` | `IList<string>` | Optional | The IDs of segments the customer belongs to. |
| `Version` | `long?` | Optional | The Square-assigned version number of the customer profile. The version number is incremented each time an update is committed to the customer profile, except for changes to customer segment membership and cards on file. |

## Example (as JSON)

```json
{
  "id": "id0",
  "created_at": "created_at2",
  "updated_at": "updated_at4",
  "cards": [
    {
      "id": "id7",
      "card_brand": "AMERICAN_EXPRESS",
      "last_4": "last_49",
      "exp_month": 79,
      "exp_year": 217
    },
    {
      "id": "id8",
      "card_brand": "MASTERCARD",
      "last_4": "last_40",
      "exp_month": 78,
      "exp_year": 218
    }
  ],
  "given_name": "given_name2"
}
```

