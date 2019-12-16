## V1 Page

V1Page

### Structure

`V1Page`

### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The page's unique identifier. |
| `Name` | `string` | Optional | The page's name, if any. |
| `PageIndex` | `int?` | Optional | The page's position in the merchant's list of pages. Always an integer between 0 and 6, inclusive. |
| `Cells` | [`IList<Models.V1PageCell>`](/doc/models/v1-page-cell.md) | Optional | The cells included on the page. |

### Example (as JSON)

```json
{
  "id": null,
  "name": null,
  "page_index": null,
  "cells": null
}
```

