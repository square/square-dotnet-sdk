
# Catalog Object Reference

A reference to a Catalog object at a specific version. In general this is
used as an entry point into a graph of catalog objects, where the objects exist
at a specific version.

## Structure

`CatalogObjectReference`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ObjectId` | `string` | Optional | The ID of the referenced object. |
| `CatalogVersion` | `long?` | Optional | The version of the object. |

## Example (as JSON)

```json
{
  "object_id": "object_id0",
  "catalog_version": 84
}
```

