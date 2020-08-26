## V1 Fee

V1Fee

### Structure

`V1Fee`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The fee's unique ID. |
| `Name` | `string` | Optional | The fee's name. |
| `Rate` | `string` | Optional | The rate of the fee, as a string representation of a decimal number. A value of 0.07 corresponds to a rate of 7%. |
| `CalculationPhase` | [`string`](/doc/models/v1-fee-calculation-phase.md) | Optional | - |
| `AdjustmentType` | [`string`](/doc/models/v1-fee-adjustment-type.md) | Optional | - |
| `AppliesToCustomAmounts` | `bool?` | Optional | If true, the fee applies to custom amounts entered into Square Point of Sale that are not associated with a particular item. |
| `Enabled` | `bool?` | Optional | If true, the fee is applied to all appropriate items. If false, the fee is not applied at all. |
| `InclusionType` | [`string`](/doc/models/v1-fee-inclusion-type.md) | Optional | - |
| `Type` | [`string`](/doc/models/v1-fee-type.md) | Optional | - |
| `V2Id` | `string` | Optional | The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID. |

### Example (as JSON)

```json
{
  "id": "id0",
  "name": "name0",
  "rate": "rate0",
  "calculation_phase": "FEE_TOTAL_PHASE",
  "adjustment_type": "TAX"
}
```

