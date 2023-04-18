
# Search Orders Source Filter

A filter based on order `source` information.

## Structure

`SearchOrdersSourceFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `SourceNames` | `IList<string>` | Optional | Filters by the [Source](entity:OrderSource) `name`. The filter returns any orders<br>with a `source.name` that matches any of the listed source names.<br><br>Max: 10 source names. |

## Example (as JSON)

```json
{
  "source_names": [
    "source_names8"
  ]
}
```

