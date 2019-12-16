## Inventory State

Indicates the state of a tracked item quantity in the lifecycle of goods.

### Enumeration

`InventoryState`

### Fields

| Name | Description |
|  --- | --- |
| `CUSTOM` | The related quantity of items are in a custom state. **READ-ONLY**:<br>the Inventory API cannot move quantities to or from this state. |
| `INSTOCK` | The related quantity of items are on hand and available for sale. |
| `SOLD` | The related quantity of items were sold as part of an itemized<br>transaction. Quantities in the `SOLD` state are no longer tracked. |
| `RETURNEDBYCUSTOMER` | The related quantity of items were returned through the Square Point<br>of Sale application, but are not yet available for sale. **READ-ONLY**:<br>the Inventory API cannot move quantities to or from this state. |
| `RESERVEDFORSALE` | The related quantity of items are on hand, but not currently<br>available for sale. **READ-ONLY**: the Inventory API cannot move<br>quantities to or from this state. |
| `SOLDONLINE` | The related quantity of items were sold online. **READ-ONLY**: the<br>Inventory API cannot move quantities to or from this state. |
| `ORDEREDFROMVENDOR` | The related quantity of items were ordered from a vendor but not yet<br>received. **READ-ONLY**: the Inventory API cannot move quantities to or<br>from this state. |
| `RECEIVEDFROMVENDOR` | The related quantity of items were received from a vendor but are<br>not yet available for sale. **READ-ONLY**: the Inventory API cannot move<br>quantities to or from this state. |
| `INTRANSITTO` | The related quantity of items are in transit between locations.<br>*READ-ONLY**: the Inventory API cannot move quantities to or from this<br>state. |
| `NONE` | A placeholder indicating that the related quantity of items are not<br>currently tracked in Square. Transferring quantities from the `NONE` state<br>to a tracked state (e.g., `IN_STOCK`) introduces stock into the system. |
| `WASTE` | The related quantity of items are lost or damaged and cannot be<br>sold. |
| `UNLINKEDRETURN` | The related quantity of items were returned but not linked to a<br>previous transaction. Unlinked returns are not tracked in Square.<br>Transferring a quantity from `UNLINKED_RETURN` to a tracked state (e.g.,<br>`IN_STOCK`) introduces new stock into the system. |

