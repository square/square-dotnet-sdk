
# Destination

Information about the destination against which the payout was made.

## Structure

`Destination`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Type` | [`string`](../../doc/models/destination-type.md) | Optional | List of possible destinations against which a payout can be made. |
| `Id` | `string` | Optional | Square issued unique ID (also known as the instrument ID) associated with this destination. |

## Example (as JSON)

```json
{
  "type": "SQUARE_BALANCE",
  "id": "id0"
}
```

