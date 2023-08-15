
# Bulk Delete Location Custom Attributes Response Location Custom Attribute Delete Response

Represents an individual delete response in a [BulkDeleteLocationCustomAttributes](../../doc/api/location-custom-attributes.md#bulk-delete-location-custom-attributes)
request.

## Structure

`BulkDeleteLocationCustomAttributesResponseLocationCustomAttributeDeleteResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `LocationId` | `string` | Optional | The ID of the location associated with the custom attribute. |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Errors that occurred while processing the individual LocationCustomAttributeDeleteRequest request |

## Example (as JSON)

```json
{
  "errors": [],
  "location_id": "L0TBCBTB7P8RQ"
}
```

