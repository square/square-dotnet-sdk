## Order Line Item Discount Type

Indicates how the discount is applied to the associated line item or order.

### Enumeration

`OrderLineItemDiscountType`

### Fields

| Name | Description |
|  --- | --- |
| `UNKNOWNDISCOUNT` | Used for reporting only.<br>The original transaction discount type is currently not supported by the API. |
| `FIXEDPERCENTAGE` | Apply the discount as a fixed percentage (e.g., 5%) off the item price. |
| `FIXEDAMOUNT` | Apply the discount as a fixed monetary value (e.g., $1.00) off the item price. |
| `VARIABLEPERCENTAGE` | Apply the discount as a variable percentage based on the item<br>price.<br><br>The specific discount percentage of a `VARIABLE_PERCENTAGE` discount<br>is assigned at the time of the purchase. |
| `VARIABLEAMOUNT` | Apply the discount as a variable amount based on the item price.<br><br>The specific discount amount of a `VARIABLE_AMOUNT` discount<br>is assigned at the time of the purchase. |

