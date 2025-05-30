
# List Booking Custom Attributes Response

Represents a [ListBookingCustomAttributes](../../doc/api/booking-custom-attributes.md#list-booking-custom-attributes) response.
Either `custom_attributes`, an empty object, or `errors` is present in the response. If additional
results are available, the `cursor` field is also present along with `custom_attributes`.

## Structure

`ListBookingCustomAttributesResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomAttributes` | [`IList<CustomAttribute>`](../../doc/models/custom-attribute.md) | Optional | The retrieved custom attributes. If `with_definitions` was set to `true` in the request,<br>the custom attribute definition is returned in the `definition` field of each custom attribute.<br><br>If no custom attributes are found, Square returns an empty object (`{}`). |
| `Cursor` | `string` | Optional | The cursor to use in your next call to this endpoint to retrieve the next page of results<br>for your original request. This field is present only if the request succeeded and additional<br>results are available. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |

## Example (as JSON)

```json
{
  "custom_attributes": [
    {
      "key": "key8",
      "value": {
        "key1": "val1",
        "key2": "val2"
      },
      "version": 180,
      "visibility": "VISIBILITY_HIDDEN",
      "definition": {
        "key": "key0",
        "schema": {
          "key1": "val1",
          "key2": "val2"
        },
        "name": "name0",
        "description": "description0",
        "visibility": "VISIBILITY_HIDDEN"
      }
    },
    {
      "key": "key8",
      "value": {
        "key1": "val1",
        "key2": "val2"
      },
      "version": 180,
      "visibility": "VISIBILITY_HIDDEN",
      "definition": {
        "key": "key0",
        "schema": {
          "key1": "val1",
          "key2": "val2"
        },
        "name": "name0",
        "description": "description0",
        "visibility": "VISIBILITY_HIDDEN"
      }
    }
  ],
  "cursor": "cursor0",
  "errors": [
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "INVALID_EXPIRATION",
      "detail": "detail6",
      "field": "field4"
    }
  ]
}
```

