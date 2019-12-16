## Order Line Item Tax Scope

Indicates whether this is a line item or order level tax.

### Enumeration

`OrderLineItemTaxScope`

### Fields

| Name | Description |
|  --- | --- |
| `OTHERTAXSCOPE` | Used for reporting only.<br>The original transaction tax scope is currently not supported by the API. |
| `LINEITEM` | The tax should be applied only to line items specified by<br>the `OrderLineItemAppliedTax` reference records. |
| `ORDER` | The tax should be applied to the entire order. |

