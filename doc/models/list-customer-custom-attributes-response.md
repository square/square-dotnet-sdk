
# List Customer Custom Attributes Response

Represents a [ListCustomerCustomAttributes](../../doc/api/customer-custom-attributes.md#list-customer-custom-attributes) response.
Either `custom_attributes`, an empty object, or `errors` is present in the response. If additional
results are available, the `cursor` field is also present along with `custom_attributes`.

## Structure

`ListCustomerCustomAttributesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttributes` | [`IList<Models.CustomAttribute>`](../../doc/models/custom-attribute.md) | Optional | The retrieved custom attributes. If `with_definitions` was set to `true` in the request,<br>the custom attribute definition is returned in the `definition` field of each custom attribute.<br><br>If no custom attributes are found, Square returns an empty object (`{}`). |
| `Cursor` | `string` | Optional | The cursor to use in your next call to this endpoint to retrieve the next page of results<br>for your original request. This field is present only if the request succeeded and additional<br>results are available. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

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
  ]
}
```

