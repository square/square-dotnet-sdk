
# Customer Custom Attribute Filter

The custom attribute filter. Use this filter in a set of [custom attribute filters](../../doc/models/customer-custom-attribute-filters.md) to search
based on the value or last updated date of a customer-related [custom attribute](../../doc/models/custom-attribute.md).

## Structure

`CustomerCustomAttributeFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Key` | `string` | Required | The `key` of the [custom attribute](../../doc/models/custom-attribute.md) to filter by. The key is the identifier of the custom attribute<br>(and the corresponding custom attribute definition) and can be retrieved using the [Customer Custom Attributes API](../../doc/api/customer-custom-attributes.md). |
| `Filter` | [`Models.CustomerCustomAttributeFilterValue`](../../doc/models/customer-custom-attribute-filter-value.md) | Optional | A type-specific filter used in a [custom attribute filter](../../doc/models/customer-custom-attribute-filter.md) to search based on the value<br>of a customer-related [custom attribute](../../doc/models/custom-attribute.md). |
| `UpdatedAt` | [`Models.TimeRange`](../../doc/models/time-range.md) | Optional | Represents a generic time range. The start and end values are<br>represented in RFC 3339 format. Time ranges are customized to be<br>inclusive or exclusive based on the needs of a particular endpoint.<br>Refer to the relevant endpoint-specific documentation to determine<br>how time ranges are handled. |

## Example (as JSON)

```json
{
  "key": "key0",
  "filter": null,
  "updated_at": null
}
```

