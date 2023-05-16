
# Standard Unit Description Group

Group of standard measurement units.

## Structure

`StandardUnitDescriptionGroup`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `StandardUnitDescriptions` | [`IList<Models.StandardUnitDescription>`](../../doc/models/standard-unit-description.md) | Optional | List of standard (non-custom) measurement units in this description group. |
| `LanguageCode` | `string` | Optional | IETF language tag. |

## Example (as JSON)

```json
{
  "standard_unit_descriptions": [
    {
      "unit": {
        "custom_unit": {
          "name": "name1",
          "abbreviation": "abbreviation3"
        },
        "area_unit": "IMPERIAL_SQUARE_INCH",
        "length_unit": "IMPERIAL_FOOT",
        "volume_unit": "GENERIC_QUART",
        "weight_unit": "IMPERIAL_POUND"
      },
      "name": "name1",
      "abbreviation": "abbreviation3"
    },
    {
      "unit": {
        "custom_unit": {
          "name": "name2",
          "abbreviation": "abbreviation4"
        },
        "area_unit": "IMPERIAL_SQUARE_FOOT",
        "length_unit": "IMPERIAL_YARD",
        "volume_unit": "GENERIC_GALLON",
        "weight_unit": "IMPERIAL_STONE"
      },
      "name": "name2",
      "abbreviation": "abbreviation4"
    },
    {
      "unit": {
        "custom_unit": {
          "name": "name3",
          "abbreviation": "abbreviation5"
        },
        "area_unit": "IMPERIAL_SQUARE_YARD",
        "length_unit": "IMPERIAL_MILE",
        "volume_unit": "IMPERIAL_CUBIC_INCH",
        "weight_unit": "METRIC_MILLIGRAM"
      },
      "name": "name3",
      "abbreviation": "abbreviation5"
    }
  ],
  "language_code": "language_code8"
}
```

