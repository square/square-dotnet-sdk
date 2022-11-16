
# Loyalty Program Accrual Rule Spend Data

Represents additional data for rules with the `SPEND` accrual type.

## Structure

`LoyaltyProgramAccrualRuleSpendData`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AmountMoney` | [`Models.Money`](../../doc/models/money.md) | Required | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `ExcludedCategoryIds` | `IList<string>` | Optional | The IDs of any `CATEGORY` catalog objects that are excluded from points accrual.<br><br>You can use the [BatchRetrieveCatalogObjects](../../doc/api/catalog.md#batch-retrieve-catalog-objects)<br>endpoint to retrieve information about the excluded categories. |
| `ExcludedItemVariationIds` | `IList<string>` | Optional | The IDs of any `ITEM_VARIATION` catalog objects that are excluded from points accrual.<br><br>You can use the [BatchRetrieveCatalogObjects](../../doc/api/catalog.md#batch-retrieve-catalog-objects)<br>endpoint to retrieve information about the excluded item variations. |
| `TaxMode` | [`string`](../../doc/models/loyalty-program-accrual-rule-tax-mode.md) | Required | Indicates how taxes should be treated when calculating the purchase amount used for loyalty points accrual.<br>This setting applies only to `SPEND` accrual rules or `VISIT` accrual rules that have a minimum spend requirement. |

## Example (as JSON)

```json
{
  "amount_money": {
    "amount": null,
    "currency": null
  },
  "excluded_category_ids": null,
  "excluded_item_variation_ids": null,
  "tax_mode": "BEFORE_TAX"
}
```

