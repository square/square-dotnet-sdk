
# Quantity Ratio

A whole number or unreduced fractional ratio.

## Structure

`QuantityRatio`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Quantity` | `int?` | Optional | The whole or fractional quantity as the numerator. |
| `QuantityDenominator` | `int?` | Optional | The whole or fractional quantity as the denominator.<br>In the case of fractional quantity this field is the denominator and quantity is the numerator.<br>When unspecified, the value is `1`. For example, when `quantity=3` and `quantity_donominator` is unspecified,<br>the quantity ratio is `3` or `3/1`. |

## Example (as JSON)

```json
{
  "quantity": 68,
  "quantity_denominator": 0
}
```

