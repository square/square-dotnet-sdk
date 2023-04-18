
# Range

The range of a number value between the specified lower and upper bounds.

## Structure

`Range`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Min` | `string` | Optional | The lower bound of the number range. At least one of `min` or `max` must be specified.<br>If unspecified, the results will have no minimum value. |
| `Max` | `string` | Optional | The upper bound of the number range. At least one of `min` or `max` must be specified.<br>If unspecified, the results will have no maximum value. |

## Example (as JSON)

```json
{
  "min": "min2",
  "max": "max0"
}
```

