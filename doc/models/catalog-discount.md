
# Catalog Discount

A discount applicable to items.

## Structure

`CatalogDiscount`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | `string` | Optional | The discount name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.<br>**Constraints**: *Maximum Length*: `255` |
| `DiscountType` | [`string`](../../doc/models/catalog-discount-type.md) | Optional | How to apply a CatalogDiscount to a CatalogItem. |
| `Percentage` | `string` | Optional | The percentage of the discount as a string representation of a decimal number, using a `.` as the decimal<br>separator and without a `%` sign. A value of `7.5` corresponds to `7.5%`. Specify a percentage of `0` if `discount_type`<br>is `VARIABLE_PERCENTAGE`.<br><br>Do not use this field for amount-based or variable discounts. |
| `AmountMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `PinRequired` | `bool?` | Optional | Indicates whether a mobile staff member needs to enter their PIN to apply the<br>discount to a payment in the Square Point of Sale app. |
| `LabelColor` | `string` | Optional | The color of the discount display label in the Square Point of Sale app. This must be a valid hex color code. |
| `ModifyTaxBasis` | [`string`](../../doc/models/catalog-discount-modify-tax-basis.md) | Optional | - |
| `MaximumAmountMoney` | [`Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |

## Example (as JSON)

```json
{
  "object": {
    "discount_data": {
      "discount_type": "FIXED_PERCENTAGE",
      "label_color": "red",
      "name": "Welcome to the Dark(Roast) Side!",
      "percentage": "5.4",
      "pin_required": false
    },
    "id": "#Maythe4th",
    "present_at_all_locations": true,
    "type": "DISCOUNT"
  },
  "name": "name8",
  "discount_type": "VARIABLE_PERCENTAGE",
  "percentage": "percentage6",
  "amount_money": {
    "amount": 186,
    "currency": "TZS"
  },
  "pin_required": false
}
```

