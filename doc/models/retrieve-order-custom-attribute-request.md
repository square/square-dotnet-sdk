
# Retrieve Order Custom Attribute Request

Represents a get request for an order custom attribute.

## Structure

`RetrieveOrderCustomAttributeRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Version` | `int?` | Optional | To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)<br>control, include this optional field and specify the current version of the custom attribute. |
| `WithDefinition` | `bool?` | Optional | Indicates whether to return the [custom attribute definition](../../doc/models/custom-attribute-definition.md) in the `definition` field of each<br>custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,<br>information about the data type, or other definition details. The default value is `false`. |

## Example (as JSON)

```json
{
  "version": null,
  "with_definition": null
}
```

