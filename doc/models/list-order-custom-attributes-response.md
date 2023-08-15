
# List Order Custom Attributes Response

Represents a response from listing order custom attributes.

## Structure

`ListOrderCustomAttributesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttributes` | [`IList<CustomAttribute>`](../../doc/models/custom-attribute.md) | Optional | The retrieved custom attributes. If no custom attribute are found, Square returns an empty object (`{}`). |
| `Cursor` | `string` | Optional | The cursor to provide in your next call to this endpoint to retrieve the next page of results for your original request.<br>This field is present only if the request succeeded and additional results are available.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).<br>**Constraints**: *Minimum Length*: `1` |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "custom_attributes": [
    {
      "key": "key2",
      "value": {
        "key1": "val1",
        "key2": "val2"
      },
      "version": 228,
      "visibility": "VISIBILITY_READ_WRITE_VALUES",
      "definition": {
        "key": "key2",
        "schema": {
          "key1": "val1",
          "key2": "val2"
        },
        "name": "name2",
        "description": "description2",
        "visibility": "VISIBILITY_HIDDEN"
      }
    },
    {
      "key": "key3",
      "value": {
        "key1": "val1",
        "key2": "val2"
      },
      "version": 229,
      "visibility": "VISIBILITY_READ_ONLY",
      "definition": {
        "key": "key3",
        "schema": {
          "key1": "val1",
          "key2": "val2"
        },
        "name": "name3",
        "description": "description3",
        "visibility": "VISIBILITY_READ_ONLY"
      }
    },
    {
      "key": "key4",
      "value": {
        "key1": "val1",
        "key2": "val2"
      },
      "version": 230,
      "visibility": "VISIBILITY_HIDDEN",
      "definition": {
        "key": "key4",
        "schema": {
          "key1": "val1",
          "key2": "val2"
        },
        "name": "name4",
        "description": "description4",
        "visibility": "VISIBILITY_READ_WRITE_VALUES"
      }
    }
  ],
  "cursor": "cursor6",
  "errors": [
    {
      "category": "REFUND_ERROR",
      "code": "MERCHANT_SUBSCRIPTION_NOT_FOUND",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "BAD_REQUEST",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "EXTERNAL_VENDOR_ERROR",
      "code": "MISSING_REQUIRED_PARAMETER",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

