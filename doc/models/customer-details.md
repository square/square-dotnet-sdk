
# Customer Details

Details about the customer making the payment.

## Structure

`CustomerDetails`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `CustomerInitiated` | `bool?` | Optional | Indicates whether the customer initiated the payment. |
| `SellerKeyedIn` | `bool?` | Optional | Indicates that the seller keyed in payment details on behalf of the customer.<br>This is used to flag a payment as Mail Order / Telephone Order (MOTO). |

## Example (as JSON)

```json
{
  "customer_initiated": false,
  "seller_keyed_in": false
}
```

