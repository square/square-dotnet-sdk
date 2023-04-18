
# Customer Creation Source Filter

The creation source filter.

If one or more creation sources are set, customer profiles are included in,
or excluded from, the result if they match at least one of the filter criteria.

## Structure

`CustomerCreationSourceFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Values` | [`IList<string>`](../../doc/models/customer-creation-source.md) | Optional | The list of creation sources used as filtering criteria.<br>See [CustomerCreationSource](#type-customercreationsource) for possible values |
| `Rule` | [`string`](../../doc/models/customer-inclusion-exclusion.md) | Optional | Indicates whether customers should be included in, or excluded from,<br>the result set when they match the filtering criteria. |

## Example (as JSON)

```json
{
  "values": [
    "INSTANT_PROFILE",
    "TERMINAL",
    "THIRD_PARTY"
  ],
  "rule": "INCLUDE"
}
```

