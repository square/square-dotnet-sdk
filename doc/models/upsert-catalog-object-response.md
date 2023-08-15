
# Upsert Catalog Object Response

## Structure

`UpsertCatalogObjectResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `CatalogObject` | [`CatalogObject`](../../doc/models/catalog-object.md) | Optional | The wrapper object for the catalog entries of a given object type.<br><br>Depending on the `type` attribute value, a `CatalogObject` instance assumes a type-specific data to yield the corresponding type of catalog object.<br><br>For example, if `type=ITEM`, the `CatalogObject` instance must have the ITEM-specific data set on the `item_data` attribute. The resulting `CatalogObject` instance is also a `CatalogItem` instance.<br><br>In general, if `type=<OBJECT_TYPE>`, the `CatalogObject` instance must have the `<OBJECT_TYPE>`-specific data set on the `<object_type>_data` attribute. The resulting `CatalogObject` instance is also a `Catalog<ObjectType>` instance.<br><br>For a more detailed discussion of the Catalog data model, please see the<br>[Design a Catalog](https://developer.squareup.com/docs/catalog-api/design-a-catalog) guide. |
| `IdMappings` | [`IList<CatalogIdMapping>`](../../doc/models/catalog-id-mapping.md) | Optional | The mapping between client and server IDs for this upsert. |

## Example (as JSON)

```json
{
  "catalog_object": {
    "id": "R2TA2FOBUGCJZNIWJSOSNAI4",
    "is_deleted": false,
    "item_data": {
      "abbreviation": "Ch",
      "description": "Hot Chocolate",
      "description_html": "<p><strong>Hot</strong> Chocolate</p>",
      "description_plaintext": "Hot Chocolate",
      "name": "Cocoa",
      "product_type": "REGULAR",
      "variations": [
        {
          "id": "QRT53UP4LITLWGOGBZCUWP63",
          "is_deleted": false,
          "item_variation_data": {
            "item_id": "R2TA2FOBUGCJZNIWJSOSNAI4",
            "name": "Small",
            "ordinal": 0,
            "pricing_type": "VARIABLE_PRICING",
            "stockable": true
          },
          "present_at_all_locations": true,
          "type": "ITEM_VARIATION",
          "updated_at": "2021-06-14T15:51:39.021Z",
          "version": 1623685899021
        },
        {
          "id": "NS77DKEIQ3AEQTCP727DSA7U",
          "is_deleted": false,
          "item_variation_data": {
            "item_id": "R2TA2FOBUGCJZNIWJSOSNAI4",
            "name": "Large",
            "ordinal": 1,
            "price_money": {
              "amount": 400,
              "currency": "USD"
            },
            "pricing_type": "FIXED_PRICING",
            "stockable": true
          },
          "present_at_all_locations": true,
          "type": "ITEM_VARIATION",
          "updated_at": "2021-06-14T15:51:39.021Z",
          "version": 1623685899021
        }
      ]
    },
    "present_at_all_locations": true,
    "type": "ITEM",
    "updated_at": "2021-06-14T15:51:39.021Z",
    "version": 1623685899021,
    "custom_attribute_values": {
      "key0": {
        "name": "name9",
        "string_value": "string_value3",
        "custom_attribute_definition_id": "custom_attribute_definition_id3",
        "type": "BOOLEAN",
        "number_value": "number_value9"
      },
      "key1": {
        "name": "name0",
        "string_value": "string_value4",
        "custom_attribute_definition_id": "custom_attribute_definition_id2",
        "type": "STRING",
        "number_value": "number_value0"
      },
      "key2": {
        "name": "name1",
        "string_value": "string_value5",
        "custom_attribute_definition_id": "custom_attribute_definition_id1",
        "type": "SELECTION",
        "number_value": "number_value1"
      }
    },
    "catalog_v1_ids": [
      {
        "catalog_v1_id": "catalog_v1_id4",
        "location_id": "location_id4"
      },
      {
        "catalog_v1_id": "catalog_v1_id5",
        "location_id": "location_id5"
      },
      {
        "catalog_v1_id": "catalog_v1_id6",
        "location_id": "location_id6"
      }
    ]
  },
  "id_mappings": [
    {
      "client_object_id": "#Cocoa",
      "object_id": "R2TA2FOBUGCJZNIWJSOSNAI4"
    },
    {
      "client_object_id": "#Small",
      "object_id": "QRT53UP4LITLWGOGBZCUWP63"
    },
    {
      "client_object_id": "#Large",
      "object_id": "NS77DKEIQ3AEQTCP727DSA7U"
    }
  ],
  "errors": [
    {
      "category": "REFUND_ERROR",
      "code": "MERCHANT_SUBSCRIPTION_NOT_FOUND",
      "detail": "detail1",
      "field": "field9"
    },
    {
      "category": "MERCHANT_SUBSCRIPTION_ERROR",
      "code": "BAD_REQUEST",
      "detail": "detail2",
      "field": "field0"
    },
    {
      "category": "EXTERNAL_VENDOR_ERROR",
      "code": "MISSING_REQUIRED_PARAMETER",
      "detail": "detail3",
      "field": "field1"
    }
  ]
}
```

