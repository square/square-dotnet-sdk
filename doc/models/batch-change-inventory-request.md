
# Batch Change Inventory Request

## Structure

`BatchChangeInventoryRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` | Required | A client-supplied, universally unique identifier (UUID) for the<br>request.<br><br>See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) in the<br>[API Development 101](https://developer.squareup.com/docs/buildbasics) section for more<br>information.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `Changes` | [`IList<Models.InventoryChange>`](../../doc/models/inventory-change.md) | Optional | The set of physical counts and inventory adjustments to be made.<br>Changes are applied based on the client-supplied timestamp and may be sent<br>out of order. |
| `IgnoreUnchangedCounts` | `bool?` | Optional | Indicates whether the current physical count should be ignored if<br>the quantity is unchanged since the last physical count. Default: `true`. |

## Example (as JSON)

```json
{
  "changes": [
    {
      "physical_count": {
        "catalog_object_id": "W62UWFY35CWMYGVWK6TWJDNI",
        "location_id": "C6W5YS5QM06F5",
        "occurred_at": "2016-11-16T22:25:24.878Z",
        "quantity": "53",
        "reference_id": "1536bfbf-efed-48bf-b17d-a197141b2a92",
        "state": "IN_STOCK",
        "team_member_id": "LRK57NSQ5X7PUD05",
        "id": "id6",
        "catalog_object_type": "catalog_object_type0"
      },
      "type": "PHYSICAL_COUNT",
      "adjustment": {
        "id": "id0",
        "reference_id": "reference_id8",
        "from_state": "SOLD",
        "to_state": "COMPOSED",
        "location_id": "location_id4"
      },
      "transfer": {
        "id": "id4",
        "reference_id": "reference_id8",
        "state": "SUPPORTED_BY_NEWER_VERSION",
        "from_location_id": "from_location_id6",
        "to_location_id": "to_location_id4"
      },
      "measurement_unit": {
        "measurement_unit": {
          "custom_unit": {
            "name": "name6",
            "abbreviation": "abbreviation8"
          },
          "area_unit": "IMPERIAL_SQUARE_FOOT",
          "length_unit": "METRIC_METER",
          "volume_unit": "IMPERIAL_CUBIC_INCH",
          "weight_unit": "IMPERIAL_WEIGHT_OUNCE"
        },
        "precision": 118
      }
    }
  ],
  "idempotency_key": "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
  "ignore_unchanged_counts": true
}
```

