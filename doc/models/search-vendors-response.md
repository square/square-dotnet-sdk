
# Search Vendors Response

Represents an output from a call to [SearchVendors](../../doc/api/vendors.md#search-vendors).

## Structure

`SearchVendorsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Errors encountered when the request fails. |
| `Vendors` | [`IList<Models.Vendor>`](../../doc/models/vendor.md) | Optional | The [Vendor](entity:Vendor) objects matching the specified search filter. |
| `Cursor` | `string` | Optional | The pagination cursor to be used in a subsequent request. If unset,<br>this is the final response.<br><br>See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information. |

## Example (as JSON)

```json
{
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
  ],
  "vendors": [
    {
      "id": "id9",
      "created_at": "created_at7",
      "updated_at": "updated_at5",
      "name": "name9",
      "address": {
        "address_line_1": "address_line_15",
        "address_line_2": "address_line_25",
        "address_line_3": "address_line_31",
        "locality": "locality5",
        "sublocality": "sublocality5",
        "sublocality_2": "sublocality_23",
        "sublocality_3": "sublocality_35",
        "administrative_district_level_1": "administrative_district_level_19",
        "administrative_district_level_2": "administrative_district_level_21",
        "administrative_district_level_3": "administrative_district_level_33",
        "postal_code": "postal_code7",
        "country": "HT",
        "first_name": "first_name5",
        "last_name": "last_name3"
      },
      "contacts": [
        {
          "id": "id6",
          "name": "name6",
          "email_address": "email_address4",
          "phone_number": "phone_number4",
          "removed": false,
          "ordinal": 232
        },
        {
          "id": "id7",
          "name": "name7",
          "email_address": "email_address5",
          "phone_number": "phone_number5",
          "removed": true,
          "ordinal": 233
        },
        {
          "id": "id8",
          "name": "name8",
          "email_address": "email_address6",
          "phone_number": "phone_number6",
          "removed": false,
          "ordinal": 234
        }
      ],
      "account_number": "account_number1",
      "note": "note5",
      "version": 41,
      "status": "INACTIVE"
    },
    {
      "id": "id0",
      "created_at": "created_at8",
      "updated_at": "updated_at4",
      "name": "name0",
      "address": {
        "address_line_1": "address_line_16",
        "address_line_2": "address_line_26",
        "address_line_3": "address_line_32",
        "locality": "locality6",
        "sublocality": "sublocality6",
        "sublocality_2": "sublocality_24",
        "sublocality_3": "sublocality_36",
        "administrative_district_level_1": "administrative_district_level_10",
        "administrative_district_level_2": "administrative_district_level_22",
        "administrative_district_level_3": "administrative_district_level_34",
        "postal_code": "postal_code8",
        "country": "HU",
        "first_name": "first_name6",
        "last_name": "last_name4"
      },
      "contacts": [
        {
          "id": "id7",
          "name": "name7",
          "email_address": "email_address5",
          "phone_number": "phone_number5",
          "removed": true,
          "ordinal": 233
        }
      ],
      "account_number": "account_number0",
      "note": "note4",
      "version": 42,
      "status": "ACTIVE"
    },
    {
      "id": "id1",
      "created_at": "created_at9",
      "updated_at": "updated_at3",
      "name": "name1",
      "address": {
        "address_line_1": "address_line_17",
        "address_line_2": "address_line_27",
        "address_line_3": "address_line_33",
        "locality": "locality7",
        "sublocality": "sublocality7",
        "sublocality_2": "sublocality_25",
        "sublocality_3": "sublocality_37",
        "administrative_district_level_1": "administrative_district_level_11",
        "administrative_district_level_2": "administrative_district_level_23",
        "administrative_district_level_3": "administrative_district_level_35",
        "postal_code": "postal_code9",
        "country": "ID",
        "first_name": "first_name7",
        "last_name": "last_name5"
      },
      "contacts": [
        {
          "id": "id8",
          "name": "name8",
          "email_address": "email_address6",
          "phone_number": "phone_number6",
          "removed": false,
          "ordinal": 234
        },
        {
          "id": "id9",
          "name": "name9",
          "email_address": "email_address7",
          "phone_number": "phone_number7",
          "removed": true,
          "ordinal": 235
        }
      ],
      "account_number": "account_number9",
      "note": "note3",
      "version": 43,
      "status": "INACTIVE"
    }
  ],
  "cursor": "cursor6"
}
```

