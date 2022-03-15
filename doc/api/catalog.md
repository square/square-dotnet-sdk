# Catalog

```csharp
ICatalogApi catalogApi = client.CatalogApi;
```

## Class Name

`CatalogApi`

## Methods

* [Batch Delete Catalog Objects](../../doc/api/catalog.md#batch-delete-catalog-objects)
* [Batch Retrieve Catalog Objects](../../doc/api/catalog.md#batch-retrieve-catalog-objects)
* [Batch Upsert Catalog Objects](../../doc/api/catalog.md#batch-upsert-catalog-objects)
* [Create Catalog Image](../../doc/api/catalog.md#create-catalog-image)
* [Update Catalog Image](../../doc/api/catalog.md#update-catalog-image)
* [Catalog Info](../../doc/api/catalog.md#catalog-info)
* [List Catalog](../../doc/api/catalog.md#list-catalog)
* [Upsert Catalog Object](../../doc/api/catalog.md#upsert-catalog-object)
* [Delete Catalog Object](../../doc/api/catalog.md#delete-catalog-object)
* [Retrieve Catalog Object](../../doc/api/catalog.md#retrieve-catalog-object)
* [Search Catalog Objects](../../doc/api/catalog.md#search-catalog-objects)
* [Search Catalog Items](../../doc/api/catalog.md#search-catalog-items)
* [Update Item Modifier Lists](../../doc/api/catalog.md#update-item-modifier-lists)
* [Update Item Taxes](../../doc/api/catalog.md#update-item-taxes)


# Batch Delete Catalog Objects

Deletes a set of [CatalogItem](../../doc/models/catalog-item.md)s based on the
provided list of target IDs and returns a set of successfully deleted IDs in
the response. Deletion is a cascading event such that all children of the
targeted object are also deleted. For example, deleting a CatalogItem will
also delete all of its [CatalogItemVariation](../../doc/models/catalog-item-variation.md)
children.

`BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted
IDs can be deleted. The response will only include IDs that were
actually deleted.

```csharp
BatchDeleteCatalogObjectsAsync(
    Models.BatchDeleteCatalogObjectsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchDeleteCatalogObjectsRequest`](../../doc/models/batch-delete-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchDeleteCatalogObjectsResponse>`](../../doc/models/batch-delete-catalog-objects-response.md)

## Example Usage

```csharp
var bodyObjectIds = new IList<string>();
bodyObjectIds.Add("W62UWFY35CWMYGVWK6TWJDNI");
bodyObjectIds.Add("AA27W3M2GGTF3H6AVPNB77CK");
var body = new BatchDeleteCatalogObjectsRequest.Builder()
    .ObjectIds(bodyObjectIds)
    .Build();

try
{
    BatchDeleteCatalogObjectsResponse result = await catalogApi.BatchDeleteCatalogObjectsAsync(body);
}
catch (ApiException e){};
```


# Batch Retrieve Catalog Objects

Returns a set of objects based on the provided ID.
Each [CatalogItem](../../doc/models/catalog-item.md) returned in the set includes all of its
child information including: all of its
[CatalogItemVariation](../../doc/models/catalog-item-variation.md) objects, references to
its [CatalogModifierList](../../doc/models/catalog-modifier-list.md) objects, and the ids of
any [CatalogTax](../../doc/models/catalog-tax.md) objects that apply to it.

```csharp
BatchRetrieveCatalogObjectsAsync(
    Models.BatchRetrieveCatalogObjectsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchRetrieveCatalogObjectsRequest`](../../doc/models/batch-retrieve-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveCatalogObjectsResponse>`](../../doc/models/batch-retrieve-catalog-objects-response.md)

## Example Usage

```csharp
var bodyObjectIds = new IList<string>();
bodyObjectIds.Add("W62UWFY35CWMYGVWK6TWJDNI");
bodyObjectIds.Add("AA27W3M2GGTF3H6AVPNB77CK");
var body = new BatchRetrieveCatalogObjectsRequest.Builder(
        bodyObjectIds)
    .IncludeRelatedObjects(true)
    .CatalogVersion(118L)
    .Build();

try
{
    BatchRetrieveCatalogObjectsResponse result = await catalogApi.BatchRetrieveCatalogObjectsAsync(body);
}
catch (ApiException e){};
```


# Batch Upsert Catalog Objects

Creates or updates up to 10,000 target objects based on the provided
list of objects. The target objects are grouped into batches and each batch is
inserted/updated in an all-or-nothing manner. If an object within a batch is
malformed in some way, or violates a database constraint, the entire batch
containing that item will be disregarded. However, other batches in the same
request may still succeed. Each batch may contain up to 1,000 objects, and
batches will be processed in order as long as the total object count for the
request (items, variations, modifier lists, discounts, and taxes) is no more
than 10,000.

```csharp
BatchUpsertCatalogObjectsAsync(
    Models.BatchUpsertCatalogObjectsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchUpsertCatalogObjectsRequest`](../../doc/models/batch-upsert-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchUpsertCatalogObjectsResponse>`](../../doc/models/batch-upsert-catalog-objects-response.md)

## Example Usage

```csharp
var bodyBatches = new List<CatalogObjectBatch>();

var bodyBatches0Objects = new List<CatalogObject>();

var bodyBatches0Objects0CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyBatches0Objects0CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name1")
    .StringValue("string_value5")
    .CustomAttributeDefinitionId("custom_attribute_definition_id1")
    .Type("SELECTION")
    .NumberValue("number_value1")
    .Build();
bodyBatches0Objects0CustomAttributeValues.Add("key0",bodyBatches0Objects0CustomAttributeValues0);

var bodyBatches0Objects0CustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Name("name0")
    .StringValue("string_value4")
    .CustomAttributeDefinitionId("custom_attribute_definition_id2")
    .Type("STRING")
    .NumberValue("number_value0")
    .Build();
bodyBatches0Objects0CustomAttributeValues.Add("key1",bodyBatches0Objects0CustomAttributeValues1);

var bodyBatches0Objects0CatalogV1Ids = new List<CatalogV1Id>();

var bodyBatches0Objects0CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id4")
    .LocationId("location_id4")
    .Build();
bodyBatches0Objects0CatalogV1Ids.Add(bodyBatches0Objects0CatalogV1Ids0);

var bodyBatches0Objects0ItemDataTaxIds = new IList<string>();
bodyBatches0Objects0ItemDataTaxIds.Add("#SalesTax");
var bodyBatches0Objects0ItemDataVariations = new List<CatalogObject>();

var bodyBatches0Objects0ItemDataVariations0CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyBatches0Objects0ItemDataVariations0CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name0")
    .StringValue("string_value4")
    .CustomAttributeDefinitionId("custom_attribute_definition_id2")
    .Type("STRING")
    .NumberValue("number_value0")
    .Build();
bodyBatches0Objects0ItemDataVariations0CustomAttributeValues.Add("key0",bodyBatches0Objects0ItemDataVariations0CustomAttributeValues0);

var bodyBatches0Objects0ItemDataVariations0CustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Name("name1")
    .StringValue("string_value5")
    .CustomAttributeDefinitionId("custom_attribute_definition_id1")
    .Type("SELECTION")
    .NumberValue("number_value1")
    .Build();
bodyBatches0Objects0ItemDataVariations0CustomAttributeValues.Add("key1",bodyBatches0Objects0ItemDataVariations0CustomAttributeValues1);

var bodyBatches0Objects0ItemDataVariations0CatalogV1Ids = new List<CatalogV1Id>();

var bodyBatches0Objects0ItemDataVariations0CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id3")
    .LocationId("location_id3")
    .Build();
bodyBatches0Objects0ItemDataVariations0CatalogV1Ids.Add(bodyBatches0Objects0ItemDataVariations0CatalogV1Ids0);

var bodyBatches0Objects0ItemDataVariations0ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Tea")
    .Name("Mug")
    .Sku("sku9")
    .Upc("upc7")
    .Ordinal(149)
    .PricingType("FIXED_PRICING")
    .Build();
var bodyBatches0Objects0ItemDataVariations0 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Tea_Mug")
    .UpdatedAt("updated_at5")
    .Version(99L)
    .IsDeleted(true)
    .CustomAttributeValues(bodyBatches0Objects0ItemDataVariations0CustomAttributeValues)
    .CatalogV1Ids(bodyBatches0Objects0ItemDataVariations0CatalogV1Ids)
    .PresentAtAllLocations(true)
    .ItemVariationData(bodyBatches0Objects0ItemDataVariations0ItemVariationData)
    .Build();
bodyBatches0Objects0ItemDataVariations.Add(bodyBatches0Objects0ItemDataVariations0);

var bodyBatches0Objects0ItemData = new CatalogItem.Builder()
    .Name("Tea")
    .Description("Hot Leaf Juice")
    .Abbreviation("abbreviation0")
    .LabelColor("label_color0")
    .AvailableOnline(false)
    .CategoryId("#Beverages")
    .TaxIds(bodyBatches0Objects0ItemDataTaxIds)
    .Variations(bodyBatches0Objects0ItemDataVariations)
    .Build();
var bodyBatches0Objects0 = new CatalogObject.Builder(
        "ITEM",
        "#Tea")
    .UpdatedAt("updated_at6")
    .Version(252L)
    .IsDeleted(false)
    .CustomAttributeValues(bodyBatches0Objects0CustomAttributeValues)
    .CatalogV1Ids(bodyBatches0Objects0CatalogV1Ids)
    .PresentAtAllLocations(true)
    .ItemData(bodyBatches0Objects0ItemData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects0);

var bodyBatches0Objects1CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyBatches0Objects1CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name2")
    .StringValue("string_value6")
    .CustomAttributeDefinitionId("custom_attribute_definition_id0")
    .Type("NUMBER")
    .NumberValue("number_value2")
    .Build();
bodyBatches0Objects1CustomAttributeValues.Add("key0",bodyBatches0Objects1CustomAttributeValues0);

var bodyBatches0Objects1CatalogV1Ids = new List<CatalogV1Id>();

var bodyBatches0Objects1CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id5")
    .LocationId("location_id5")
    .Build();
bodyBatches0Objects1CatalogV1Ids.Add(bodyBatches0Objects1CatalogV1Ids0);

var bodyBatches0Objects1CatalogV1Ids1 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id6")
    .LocationId("location_id6")
    .Build();
bodyBatches0Objects1CatalogV1Ids.Add(bodyBatches0Objects1CatalogV1Ids1);

var bodyBatches0Objects1ItemDataTaxIds = new IList<string>();
bodyBatches0Objects1ItemDataTaxIds.Add("#SalesTax");
var bodyBatches0Objects1ItemDataVariations = new List<CatalogObject>();

var bodyBatches0Objects1ItemDataVariations0CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyBatches0Objects1ItemDataVariations0CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name9")
    .StringValue("string_value3")
    .CustomAttributeDefinitionId("custom_attribute_definition_id3")
    .Type("BOOLEAN")
    .NumberValue("number_value9")
    .Build();
bodyBatches0Objects1ItemDataVariations0CustomAttributeValues.Add("key0",bodyBatches0Objects1ItemDataVariations0CustomAttributeValues0);

var bodyBatches0Objects1ItemDataVariations0CatalogV1Ids = new List<CatalogV1Id>();

var bodyBatches0Objects1ItemDataVariations0CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id4")
    .LocationId("location_id4")
    .Build();
bodyBatches0Objects1ItemDataVariations0CatalogV1Ids.Add(bodyBatches0Objects1ItemDataVariations0CatalogV1Ids0);

var bodyBatches0Objects1ItemDataVariations0CatalogV1Ids1 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id5")
    .LocationId("location_id5")
    .Build();
bodyBatches0Objects1ItemDataVariations0CatalogV1Ids.Add(bodyBatches0Objects1ItemDataVariations0CatalogV1Ids1);

var bodyBatches0Objects1ItemDataVariations0ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Coffee")
    .Name("Regular")
    .Sku("sku8")
    .Upc("upc6")
    .Ordinal(150)
    .PricingType("FIXED_PRICING")
    .Build();
var bodyBatches0Objects1ItemDataVariations0 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Coffee_Regular")
    .UpdatedAt("updated_at4")
    .Version(100L)
    .IsDeleted(false)
    .CustomAttributeValues(bodyBatches0Objects1ItemDataVariations0CustomAttributeValues)
    .CatalogV1Ids(bodyBatches0Objects1ItemDataVariations0CatalogV1Ids)
    .PresentAtAllLocations(true)
    .ItemVariationData(bodyBatches0Objects1ItemDataVariations0ItemVariationData)
    .Build();
bodyBatches0Objects1ItemDataVariations.Add(bodyBatches0Objects1ItemDataVariations0);

var bodyBatches0Objects1ItemDataVariations1CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyBatches0Objects1ItemDataVariations1CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name8")
    .StringValue("string_value2")
    .CustomAttributeDefinitionId("custom_attribute_definition_id4")
    .Type("NUMBER")
    .NumberValue("number_value8")
    .Build();
bodyBatches0Objects1ItemDataVariations1CustomAttributeValues.Add("key0",bodyBatches0Objects1ItemDataVariations1CustomAttributeValues0);

var bodyBatches0Objects1ItemDataVariations1CustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Name("name9")
    .StringValue("string_value3")
    .CustomAttributeDefinitionId("custom_attribute_definition_id3")
    .Type("BOOLEAN")
    .NumberValue("number_value9")
    .Build();
bodyBatches0Objects1ItemDataVariations1CustomAttributeValues.Add("key1",bodyBatches0Objects1ItemDataVariations1CustomAttributeValues1);

var bodyBatches0Objects1ItemDataVariations1CustomAttributeValues2 = new CatalogCustomAttributeValue.Builder()
    .Name("name0")
    .StringValue("string_value4")
    .CustomAttributeDefinitionId("custom_attribute_definition_id2")
    .Type("STRING")
    .NumberValue("number_value0")
    .Build();
bodyBatches0Objects1ItemDataVariations1CustomAttributeValues.Add("key2",bodyBatches0Objects1ItemDataVariations1CustomAttributeValues2);

var bodyBatches0Objects1ItemDataVariations1CatalogV1Ids = new List<CatalogV1Id>();

var bodyBatches0Objects1ItemDataVariations1CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id5")
    .LocationId("location_id5")
    .Build();
bodyBatches0Objects1ItemDataVariations1CatalogV1Ids.Add(bodyBatches0Objects1ItemDataVariations1CatalogV1Ids0);

var bodyBatches0Objects1ItemDataVariations1CatalogV1Ids1 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id6")
    .LocationId("location_id6")
    .Build();
bodyBatches0Objects1ItemDataVariations1CatalogV1Ids.Add(bodyBatches0Objects1ItemDataVariations1CatalogV1Ids1);

var bodyBatches0Objects1ItemDataVariations1CatalogV1Ids2 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id7")
    .LocationId("location_id7")
    .Build();
bodyBatches0Objects1ItemDataVariations1CatalogV1Ids.Add(bodyBatches0Objects1ItemDataVariations1CatalogV1Ids2);

var bodyBatches0Objects1ItemDataVariations1ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Coffee")
    .Name("Large")
    .Sku("sku7")
    .Upc("upc5")
    .Ordinal(151)
    .PricingType("FIXED_PRICING")
    .Build();
var bodyBatches0Objects1ItemDataVariations1 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Coffee_Large")
    .UpdatedAt("updated_at3")
    .Version(101L)
    .IsDeleted(true)
    .CustomAttributeValues(bodyBatches0Objects1ItemDataVariations1CustomAttributeValues)
    .CatalogV1Ids(bodyBatches0Objects1ItemDataVariations1CatalogV1Ids)
    .PresentAtAllLocations(true)
    .ItemVariationData(bodyBatches0Objects1ItemDataVariations1ItemVariationData)
    .Build();
bodyBatches0Objects1ItemDataVariations.Add(bodyBatches0Objects1ItemDataVariations1);

var bodyBatches0Objects1ItemData = new CatalogItem.Builder()
    .Name("Coffee")
    .Description("Hot Bean Juice")
    .Abbreviation("abbreviation9")
    .LabelColor("label_color9")
    .AvailableOnline(true)
    .CategoryId("#Beverages")
    .TaxIds(bodyBatches0Objects1ItemDataTaxIds)
    .Variations(bodyBatches0Objects1ItemDataVariations)
    .Build();
var bodyBatches0Objects1 = new CatalogObject.Builder(
        "ITEM",
        "#Coffee")
    .UpdatedAt("updated_at7")
    .Version(253L)
    .IsDeleted(true)
    .CustomAttributeValues(bodyBatches0Objects1CustomAttributeValues)
    .CatalogV1Ids(bodyBatches0Objects1CatalogV1Ids)
    .PresentAtAllLocations(true)
    .ItemData(bodyBatches0Objects1ItemData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects1);

var bodyBatches0Objects2CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyBatches0Objects2CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name3")
    .StringValue("string_value7")
    .CustomAttributeDefinitionId("custom_attribute_definition_id9")
    .Type("BOOLEAN")
    .NumberValue("number_value3")
    .Build();
bodyBatches0Objects2CustomAttributeValues.Add("key0",bodyBatches0Objects2CustomAttributeValues0);

var bodyBatches0Objects2CustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Name("name2")
    .StringValue("string_value6")
    .CustomAttributeDefinitionId("custom_attribute_definition_id0")
    .Type("NUMBER")
    .NumberValue("number_value2")
    .Build();
bodyBatches0Objects2CustomAttributeValues.Add("key1",bodyBatches0Objects2CustomAttributeValues1);

var bodyBatches0Objects2CustomAttributeValues2 = new CatalogCustomAttributeValue.Builder()
    .Name("name1")
    .StringValue("string_value5")
    .CustomAttributeDefinitionId("custom_attribute_definition_id1")
    .Type("SELECTION")
    .NumberValue("number_value1")
    .Build();
bodyBatches0Objects2CustomAttributeValues.Add("key2",bodyBatches0Objects2CustomAttributeValues2);

var bodyBatches0Objects2CatalogV1Ids = new List<CatalogV1Id>();

var bodyBatches0Objects2CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id6")
    .LocationId("location_id6")
    .Build();
bodyBatches0Objects2CatalogV1Ids.Add(bodyBatches0Objects2CatalogV1Ids0);

var bodyBatches0Objects2CatalogV1Ids1 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id7")
    .LocationId("location_id7")
    .Build();
bodyBatches0Objects2CatalogV1Ids.Add(bodyBatches0Objects2CatalogV1Ids1);

var bodyBatches0Objects2CatalogV1Ids2 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id8")
    .LocationId("location_id8")
    .Build();
bodyBatches0Objects2CatalogV1Ids.Add(bodyBatches0Objects2CatalogV1Ids2);

var bodyBatches0Objects2CategoryDataImageIds = new IList<string>();
bodyBatches0Objects2CategoryDataImageIds.Add("image_ids1");
bodyBatches0Objects2CategoryDataImageIds.Add("image_ids2");
var bodyBatches0Objects2CategoryData = new CatalogCategory.Builder()
    .Name("Beverages")
    .ImageIds(bodyBatches0Objects2CategoryDataImageIds)
    .Build();
var bodyBatches0Objects2 = new CatalogObject.Builder(
        "CATEGORY",
        "#Beverages")
    .UpdatedAt("updated_at8")
    .Version(254L)
    .IsDeleted(false)
    .CustomAttributeValues(bodyBatches0Objects2CustomAttributeValues)
    .CatalogV1Ids(bodyBatches0Objects2CatalogV1Ids)
    .PresentAtAllLocations(true)
    .CategoryData(bodyBatches0Objects2CategoryData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects2);

var bodyBatches0Objects3CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyBatches0Objects3CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name4")
    .StringValue("string_value8")
    .CustomAttributeDefinitionId("custom_attribute_definition_id8")
    .Type("STRING")
    .NumberValue("number_value4")
    .Build();
bodyBatches0Objects3CustomAttributeValues.Add("key0",bodyBatches0Objects3CustomAttributeValues0);

var bodyBatches0Objects3CustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Name("name3")
    .StringValue("string_value7")
    .CustomAttributeDefinitionId("custom_attribute_definition_id9")
    .Type("BOOLEAN")
    .NumberValue("number_value3")
    .Build();
bodyBatches0Objects3CustomAttributeValues.Add("key1",bodyBatches0Objects3CustomAttributeValues1);

var bodyBatches0Objects3CatalogV1Ids = new List<CatalogV1Id>();

var bodyBatches0Objects3CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id7")
    .LocationId("location_id7")
    .Build();
bodyBatches0Objects3CatalogV1Ids.Add(bodyBatches0Objects3CatalogV1Ids0);

var bodyBatches0Objects3TaxData = new CatalogTax.Builder()
    .Name("Sales Tax")
    .CalculationPhase("TAX_SUBTOTAL_PHASE")
    .InclusionType("ADDITIVE")
    .Percentage("5.0")
    .AppliesToCustomAmounts(true)
    .Enabled(true)
    .Build();
var bodyBatches0Objects3 = new CatalogObject.Builder(
        "TAX",
        "#SalesTax")
    .UpdatedAt("updated_at9")
    .Version(255L)
    .IsDeleted(true)
    .CustomAttributeValues(bodyBatches0Objects3CustomAttributeValues)
    .CatalogV1Ids(bodyBatches0Objects3CatalogV1Ids)
    .PresentAtAllLocations(true)
    .TaxData(bodyBatches0Objects3TaxData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects3);

var bodyBatches0 = new CatalogObjectBatch.Builder(
        bodyBatches0Objects)
    .Build();
bodyBatches.Add(bodyBatches0);

var body = new BatchUpsertCatalogObjectsRequest.Builder(
        "789ff020-f723-43a9-b4b5-43b5dc1fa3dc",
        bodyBatches)
    .Build();

try
{
    BatchUpsertCatalogObjectsResponse result = await catalogApi.BatchUpsertCatalogObjectsAsync(body);
}
catch (ApiException e){};
```


# Create Catalog Image

Uploads an image file to be represented by a [CatalogImage](../../doc/models/catalog-image.md) object that can be linked to an existing
[CatalogObject](../../doc/models/catalog-object.md) instance. The resulting `CatalogImage` is unattached to any `CatalogObject` if the `object_id`
is not specified.

This `CreateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.

```csharp
CreateCatalogImageAsync(
    Models.CreateCatalogImageRequest request = null,
    FileStreamInfo imageFile = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `request` | [`Models.CreateCatalogImageRequest`](../../doc/models/create-catalog-image-request.md) | Form, Optional | - |
| `imageFile` | `FileStreamInfo` | Form, Optional | - |

## Response Type

[`Task<Models.CreateCatalogImageResponse>`](../../doc/models/create-catalog-image-response.md)

## Example Usage

```csharp
var requestImageCustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var requestImageCustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Build();
requestImageCustomAttributeValues.Add("",requestImageCustomAttributeValues0);

var requestImageCustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Build();
requestImageCustomAttributeValues.Add("",requestImageCustomAttributeValues1);

var requestImageCatalogV1Ids = new List<CatalogV1Id>();

var requestImageCatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id4")
    .LocationId("location_id4")
    .Build();
requestImageCatalogV1Ids.Add(requestImageCatalogV1Ids0);

var requestImageImageData = new CatalogImage.Builder()
    .Name("name0")
    .Url("url4")
    .Caption("A picture of a cup of coffee")
    .PhotoStudioOrderId("photo_studio_order_id2")
    .Build();
var requestImage = new CatalogObject.Builder(
        "IMAGE",
        "#TEMP_ID")
    .UpdatedAt("updated_at4")
    .Version(68L)
    .IsDeleted(false)
    .CustomAttributeValues(requestImageCustomAttributeValues)
    .CatalogV1Ids(requestImageCatalogV1Ids)
    .ImageData(requestImageImageData)
    .Build();
var request = new CreateCatalogImageRequest.Builder(
        "528dea59-7bfb-43c1-bd48-4a6bba7dd61f86",
        requestImage)
    .ObjectId("ND6EA5AAJEO5WL3JNNIAQA32")
    .IsPrimary(false)
    .Build();
FileStreamInfo imageFile = new FileStreamInfo(new FileStream("dummy_file",FileMode.Open));

try
{
    CreateCatalogImageResponse result = await catalogApi.CreateCatalogImageAsync(request, imageFile);
}
catch (ApiException e){};
```


# Update Catalog Image

Uploads a new image file to replace the existing one in the specified [CatalogImage](../../doc/models/catalog-image.md) object.

This `UpdateCatalogImage` endpoint accepts HTTP multipart/form-data requests with a JSON part and an image file part in
JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB.

```csharp
UpdateCatalogImageAsync(
    string imageId,
    Models.UpdateCatalogImageRequest request = null,
    FileStreamInfo imageFile = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `imageId` | `string` | Template, Required | The ID of the `CatalogImage` object to update the encapsulated image file. |
| `request` | [`Models.UpdateCatalogImageRequest`](../../doc/models/update-catalog-image-request.md) | Form, Optional | - |
| `imageFile` | `FileStreamInfo` | Form, Optional | - |

## Response Type

[`Task<Models.UpdateCatalogImageResponse>`](../../doc/models/update-catalog-image-response.md)

## Example Usage

```csharp
string imageId = "image_id4";
var request = new UpdateCatalogImageRequest.Builder(
        "528dea59-7bfb-43c1-bd48-4a6bba7dd61f86")
    .Build();
FileStreamInfo imageFile = new FileStreamInfo(new FileStream("dummy_file",FileMode.Open));

try
{
    UpdateCatalogImageResponse result = await catalogApi.UpdateCatalogImageAsync(imageId, request, imageFile);
}
catch (ApiException e){};
```


# Catalog Info

Retrieves information about the Square Catalog API, such as batch size
limits that can be used by the `BatchUpsertCatalogObjects` endpoint.

```csharp
CatalogInfoAsync()
```

## Response Type

[`Task<Models.CatalogInfoResponse>`](../../doc/models/catalog-info-response.md)

## Example Usage

```csharp
try
{
    CatalogInfoResponse result = await catalogApi.CatalogInfoAsync();
}
catch (ApiException e){};
```


# List Catalog

Returns a list of all [CatalogObject](../../doc/models/catalog-object.md)s of the specified types in the catalog.

The `types` parameter is specified as a comma-separated list of the [CatalogObjectType](../../doc/models/catalog-object-type.md) values,
for example, "`ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`".

__Important:__ ListCatalog does not return deleted catalog items. To retrieve
deleted catalog items, use [SearchCatalogObjects](../../doc/api/catalog.md#search-catalog-objects)
and set the `include_deleted_objects` attribute value to `true`.

```csharp
ListCatalogAsync(
    string cursor = null,
    string types = null,
    long? catalogVersion = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | The pagination cursor returned in the previous response. Leave unset for an initial request.<br>The page size is currently set to be 100.<br>See [Pagination](../../https://developer.squareup.com/docs/basics/api101/pagination) for more information. |
| `types` | `string` | Query, Optional | An optional case-insensitive, comma-separated list of object types to retrieve.<br><br>The valid values are defined in the [CatalogObjectType](../../doc/models/catalog-object-type.md) enum, for example,<br>`ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`,<br>`MODIFIER`, `MODIFIER_LIST`, `IMAGE`, etc.<br><br>If this is unspecified, the operation returns objects of all the top level types at the version<br>of the Square API used to make the request. Object types that are nested onto other object types<br>are not included in the defaults.<br><br>At the current API version the default object types are:<br>ITEM, CATEGORY, TAX, DISCOUNT, MODIFIER_LIST, DINING_OPTION, TAX_EXEMPTION,<br>SERVICE_CHARGE, PRICING_RULE, PRODUCT_SET, TIME_PERIOD, MEASUREMENT_UNIT,<br>SUBSCRIPTION_PLAN, ITEM_OPTION, CUSTOM_ATTRIBUTE_DEFINITION, QUICK_AMOUNT_SETTINGS. |
| `catalogVersion` | `long?` | Query, Optional | The specific version of the catalog objects to be included in the response.<br>This allows you to retrieve historical<br>versions of objects. The specified version value is matched against<br>the [CatalogObject](../../doc/models/catalog-object.md)s' `version` attribute.  If not included, results will<br>be from the current version of the catalog. |

## Response Type

[`Task<Models.ListCatalogResponse>`](../../doc/models/list-catalog-response.md)

## Example Usage

```csharp
string cursor = "cursor6";
string types = "types6";
long? catalogVersion = 126L;

try
{
    ListCatalogResponse result = await catalogApi.ListCatalogAsync(cursor, types, catalogVersion);
}
catch (ApiException e){};
```


# Upsert Catalog Object

Creates or updates the target [CatalogObject](../../doc/models/catalog-object.md).

```csharp
UpsertCatalogObjectAsync(
    Models.UpsertCatalogObjectRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.UpsertCatalogObjectRequest`](../../doc/models/upsert-catalog-object-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpsertCatalogObjectResponse>`](../../doc/models/upsert-catalog-object-response.md)

## Example Usage

```csharp
var bodyMObjectCustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyMObjectCustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Build();
bodyMObjectCustomAttributeValues.Add("",bodyMObjectCustomAttributeValues0);

var bodyMObjectCustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Build();
bodyMObjectCustomAttributeValues.Add("",bodyMObjectCustomAttributeValues1);

var bodyMObjectCustomAttributeValues2 = new CatalogCustomAttributeValue.Builder()
    .Build();
bodyMObjectCustomAttributeValues.Add("",bodyMObjectCustomAttributeValues2);

var bodyMObjectCatalogV1Ids = new List<CatalogV1Id>();

var bodyMObjectCatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id0")
    .LocationId("location_id0")
    .Build();
bodyMObjectCatalogV1Ids.Add(bodyMObjectCatalogV1Ids0);

var bodyMObjectCatalogV1Ids1 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id1")
    .LocationId("location_id1")
    .Build();
bodyMObjectCatalogV1Ids.Add(bodyMObjectCatalogV1Ids1);

var bodyMObjectCatalogV1Ids2 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id2")
    .LocationId("location_id2")
    .Build();
bodyMObjectCatalogV1Ids.Add(bodyMObjectCatalogV1Ids2);

var bodyMObjectItemDataVariations = new List<CatalogObject>();

var bodyMObjectItemDataVariations0CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyMObjectItemDataVariations0CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name4")
    .StringValue("string_value8")
    .CustomAttributeDefinitionId("custom_attribute_definition_id8")
    .Type("NUMBER")
    .NumberValue("number_value4")
    .Build();
bodyMObjectItemDataVariations0CustomAttributeValues.Add("key0",bodyMObjectItemDataVariations0CustomAttributeValues0);

var bodyMObjectItemDataVariations0CustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Name("name5")
    .StringValue("string_value9")
    .CustomAttributeDefinitionId("custom_attribute_definition_id7")
    .Type("BOOLEAN")
    .NumberValue("number_value5")
    .Build();
bodyMObjectItemDataVariations0CustomAttributeValues.Add("key1",bodyMObjectItemDataVariations0CustomAttributeValues1);

var bodyMObjectItemDataVariations0CatalogV1Ids = new List<CatalogV1Id>();

var bodyMObjectItemDataVariations0CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id9")
    .LocationId("location_id9")
    .Build();
bodyMObjectItemDataVariations0CatalogV1Ids.Add(bodyMObjectItemDataVariations0CatalogV1Ids0);

var bodyMObjectItemDataVariations0ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Cocoa")
    .Name("Small")
    .Sku("sku3")
    .Upc("upc1")
    .Ordinal(119)
    .PricingType("VARIABLE_PRICING")
    .Build();
var bodyMObjectItemDataVariations0 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Small")
    .UpdatedAt("updated_at9")
    .Version(69L)
    .IsDeleted(true)
    .CustomAttributeValues(bodyMObjectItemDataVariations0CustomAttributeValues)
    .CatalogV1Ids(bodyMObjectItemDataVariations0CatalogV1Ids)
    .ItemVariationData(bodyMObjectItemDataVariations0ItemVariationData)
    .Build();
bodyMObjectItemDataVariations.Add(bodyMObjectItemDataVariations0);

var bodyMObjectItemDataVariations1CustomAttributeValues = new Dictionary<string, CatalogCustomAttributeValue>();


var bodyMObjectItemDataVariations1CustomAttributeValues0 = new CatalogCustomAttributeValue.Builder()
    .Name("name5")
    .StringValue("string_value9")
    .CustomAttributeDefinitionId("custom_attribute_definition_id7")
    .Type("BOOLEAN")
    .NumberValue("number_value5")
    .Build();
bodyMObjectItemDataVariations1CustomAttributeValues.Add("key0",bodyMObjectItemDataVariations1CustomAttributeValues0);

var bodyMObjectItemDataVariations1CustomAttributeValues1 = new CatalogCustomAttributeValue.Builder()
    .Name("name6")
    .StringValue("string_value0")
    .CustomAttributeDefinitionId("custom_attribute_definition_id6")
    .Type("STRING")
    .NumberValue("number_value6")
    .Build();
bodyMObjectItemDataVariations1CustomAttributeValues.Add("key1",bodyMObjectItemDataVariations1CustomAttributeValues1);

var bodyMObjectItemDataVariations1CustomAttributeValues2 = new CatalogCustomAttributeValue.Builder()
    .Name("name7")
    .StringValue("string_value1")
    .CustomAttributeDefinitionId("custom_attribute_definition_id5")
    .Type("SELECTION")
    .NumberValue("number_value7")
    .Build();
bodyMObjectItemDataVariations1CustomAttributeValues.Add("key2",bodyMObjectItemDataVariations1CustomAttributeValues2);

var bodyMObjectItemDataVariations1CatalogV1Ids = new List<CatalogV1Id>();

var bodyMObjectItemDataVariations1CatalogV1Ids0 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id8")
    .LocationId("location_id8")
    .Build();
bodyMObjectItemDataVariations1CatalogV1Ids.Add(bodyMObjectItemDataVariations1CatalogV1Ids0);

var bodyMObjectItemDataVariations1CatalogV1Ids1 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id9")
    .LocationId("location_id9")
    .Build();
bodyMObjectItemDataVariations1CatalogV1Ids.Add(bodyMObjectItemDataVariations1CatalogV1Ids1);

var bodyMObjectItemDataVariations1CatalogV1Ids2 = new CatalogV1Id.Builder()
    .CatalogV1Id("catalog_v1_id0")
    .LocationId("location_id0")
    .Build();
bodyMObjectItemDataVariations1CatalogV1Ids.Add(bodyMObjectItemDataVariations1CatalogV1Ids2);

var bodyMObjectItemDataVariations1ItemVariationDataPriceMoney = new Money.Builder()
    .Amount(400L)
    .Currency("USD")
    .Build();
var bodyMObjectItemDataVariations1ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Cocoa")
    .Name("Large")
    .Sku("sku4")
    .Upc("upc2")
    .Ordinal(118)
    .PricingType("FIXED_PRICING")
    .PriceMoney(bodyMObjectItemDataVariations1ItemVariationDataPriceMoney)
    .Build();
var bodyMObjectItemDataVariations1 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Large")
    .UpdatedAt("updated_at0")
    .Version(68L)
    .IsDeleted(false)
    .CustomAttributeValues(bodyMObjectItemDataVariations1CustomAttributeValues)
    .CatalogV1Ids(bodyMObjectItemDataVariations1CatalogV1Ids)
    .ItemVariationData(bodyMObjectItemDataVariations1ItemVariationData)
    .Build();
bodyMObjectItemDataVariations.Add(bodyMObjectItemDataVariations1);

var bodyMObjectItemData = new CatalogItem.Builder()
    .Name("Cocoa")
    .Description("Hot Chocolate")
    .Abbreviation("Ch")
    .LabelColor("label_color4")
    .AvailableOnline(false)
    .Variations(bodyMObjectItemDataVariations)
    .Build();
var bodyMObject = new CatalogObject.Builder(
        "ITEM",
        "#Cocoa")
    .UpdatedAt("updated_at8")
    .Version(252L)
    .IsDeleted(false)
    .CustomAttributeValues(bodyMObjectCustomAttributeValues)
    .CatalogV1Ids(bodyMObjectCatalogV1Ids)
    .ItemData(bodyMObjectItemData)
    .Build();
var body = new UpsertCatalogObjectRequest.Builder(
        "af3d1afc-7212-4300-b463-0bfc5314a5ae",
        bodyMObject)
    .Build();

try
{
    UpsertCatalogObjectResponse result = await catalogApi.UpsertCatalogObjectAsync(body);
}
catch (ApiException e){};
```


# Delete Catalog Object

Deletes a single [CatalogObject](../../doc/models/catalog-object.md) based on the
provided ID and returns the set of successfully deleted IDs in the response.
Deletion is a cascading event such that all children of the targeted object
are also deleted. For example, deleting a [CatalogItem](../../doc/models/catalog-item.md)
will also delete all of its
[CatalogItemVariation](../../doc/models/catalog-item-variation.md) children.

```csharp
DeleteCatalogObjectAsync(
    string objectId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `objectId` | `string` | Template, Required | The ID of the catalog object to be deleted. When an object is deleted, other<br>objects in the graph that depend on that object will be deleted as well (for example, deleting a<br>catalog item will delete its catalog item variations). |

## Response Type

[`Task<Models.DeleteCatalogObjectResponse>`](../../doc/models/delete-catalog-object-response.md)

## Example Usage

```csharp
string objectId = "object_id8";

try
{
    DeleteCatalogObjectResponse result = await catalogApi.DeleteCatalogObjectAsync(objectId);
}
catch (ApiException e){};
```


# Retrieve Catalog Object

Returns a single [CatalogItem](../../doc/models/catalog-item.md) as a
[CatalogObject](../../doc/models/catalog-object.md) based on the provided ID. The returned
object includes all of the relevant [CatalogItem](../../doc/models/catalog-item.md)
information including: [CatalogItemVariation](../../doc/models/catalog-item-variation.md)
children, references to its
[CatalogModifierList](../../doc/models/catalog-modifier-list.md) objects, and the ids of
any [CatalogTax](../../doc/models/catalog-tax.md) objects that apply to it.

```csharp
RetrieveCatalogObjectAsync(
    string objectId,
    bool? includeRelatedObjects = false,
    long? catalogVersion = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `objectId` | `string` | Template, Required | The object ID of any type of catalog objects to be retrieved. |
| `includeRelatedObjects` | `bool?` | Query, Optional | If `true`, the response will include additional objects that are related to the<br>requested objects. Related objects are defined as any objects referenced by ID by the results in the `objects` field<br>of the response. These objects are put in the `related_objects` field. Setting this to `true` is<br>helpful when the objects are needed for immediate display to a user.<br>This process only goes one level deep. Objects referenced by the related objects will not be included. For example,<br><br>if the `objects` field of the response contains a CatalogItem, its associated<br>CatalogCategory objects, CatalogTax objects, CatalogImage objects and<br>CatalogModifierLists will be returned in the `related_objects` field of the<br>response. If the `objects` field of the response contains a CatalogItemVariation,<br>its parent CatalogItem will be returned in the `related_objects` field of<br>the response.<br><br>Default value: `false`<br>**Default**: `false` |
| `catalogVersion` | `long?` | Query, Optional | Requests objects as of a specific version of the catalog. This allows you to retrieve historical<br>versions of objects. The value to retrieve a specific version of an object can be found<br>in the version field of [CatalogObject](../../doc/models/catalog-object.md)s. If not included, results will<br>be from the current version of the catalog. |

## Response Type

[`Task<Models.RetrieveCatalogObjectResponse>`](../../doc/models/retrieve-catalog-object-response.md)

## Example Usage

```csharp
string objectId = "object_id8";
bool? includeRelatedObjects = false;
long? catalogVersion = 126L;

try
{
    RetrieveCatalogObjectResponse result = await catalogApi.RetrieveCatalogObjectAsync(objectId, includeRelatedObjects, catalogVersion);
}
catch (ApiException e){};
```


# Search Catalog Objects

Searches for [CatalogObject](../../doc/models/catalog-object.md) of any type by matching supported search attribute values,
excluding custom attribute values on items or item variations, against one or more of the specified query filters.

This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems](../../doc/api/catalog.md#search-catalog-items)
endpoint in the following aspects:

- `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
- `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
- `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
- The both endpoints have different call conventions, including the query filter formats.

```csharp
SearchCatalogObjectsAsync(
    Models.SearchCatalogObjectsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchCatalogObjectsRequest`](../../doc/models/search-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchCatalogObjectsResponse>`](../../doc/models/search-catalog-objects-response.md)

## Example Usage

```csharp
var bodyObjectTypes = new IList<string>();
bodyObjectTypes.Add("ITEM");
var bodyQuerySortedAttributeQuery = new CatalogQuerySortedAttribute.Builder(
        "attribute_name6")
    .InitialAttributeValue("initial_attribute_value4")
    .SortOrder("DESC")
    .Build();
var bodyQueryExactQuery = new CatalogQueryExact.Builder(
        "attribute_name2",
        "attribute_value2")
    .Build();
var bodyQuerySetQueryAttributeValues = new IList<string>();
bodyQuerySetQueryAttributeValues.Add("attribute_values0");
var bodyQuerySetQuery = new CatalogQuerySet.Builder(
        "attribute_name8",
        bodyQuerySetQueryAttributeValues)
    .Build();
var bodyQueryPrefixQuery = new CatalogQueryPrefix.Builder(
        "name",
        "tea")
    .Build();
var bodyQueryRangeQuery = new CatalogQueryRange.Builder(
        "attribute_name6")
    .AttributeMinValue(14L)
    .AttributeMaxValue(180L)
    .Build();
var bodyQuery = new CatalogQuery.Builder()
    .SortedAttributeQuery(bodyQuerySortedAttributeQuery)
    .ExactQuery(bodyQueryExactQuery)
    .SetQuery(bodyQuerySetQuery)
    .PrefixQuery(bodyQueryPrefixQuery)
    .RangeQuery(bodyQueryRangeQuery)
    .Build();
var body = new SearchCatalogObjectsRequest.Builder()
    .Cursor("cursor0")
    .ObjectTypes(bodyObjectTypes)
    .IncludeDeletedObjects(false)
    .IncludeRelatedObjects(false)
    .BeginTime("begin_time4")
    .Query(bodyQuery)
    .Limit(100)
    .Build();

try
{
    SearchCatalogObjectsResponse result = await catalogApi.SearchCatalogObjectsAsync(body);
}
catch (ApiException e){};
```


# Search Catalog Items

Searches for catalog items or item variations by matching supported search attribute values, including
custom attribute values, against one or more of the specified query filters.

This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects](../../doc/api/catalog.md#search-catalog-objects)
endpoint in the following aspects:

- `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
- `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
- `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
- The both endpoints use different call conventions, including the query filter formats.

```csharp
SearchCatalogItemsAsync(
    Models.SearchCatalogItemsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchCatalogItemsRequest`](../../doc/models/search-catalog-items-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchCatalogItemsResponse>`](../../doc/models/search-catalog-items-response.md)

## Example Usage

```csharp
var bodyCategoryIds = new IList<string>();
bodyCategoryIds.Add("WINE_CATEGORY_ID");
var bodyStockLevels = new IList<string>();
bodyStockLevels.Add("OUT");
bodyStockLevels.Add("LOW");
var bodyEnabledLocationIds = new IList<string>();
bodyEnabledLocationIds.Add("ATL_LOCATION_ID");
var bodyProductTypes = new IList<string>();
bodyProductTypes.Add("REGULAR");
var bodyCustomAttributeFilters = new List<CustomAttributeFilter>();

var bodyCustomAttributeFilters0NumberFilter = new Range.Builder()
    .Min("min0")
    .Max("max2")
    .Build();
var bodyCustomAttributeFilters0SelectionUidsFilter = new IList<string>();
bodyCustomAttributeFilters0SelectionUidsFilter.Add("selection_uids_filter2");
bodyCustomAttributeFilters0SelectionUidsFilter.Add("selection_uids_filter3");
var bodyCustomAttributeFilters0 = new CustomAttributeFilter.Builder()
    .CustomAttributeDefinitionId("VEGAN_DEFINITION_ID")
    .Key("key2")
    .StringFilter("string_filter4")
    .NumberFilter(bodyCustomAttributeFilters0NumberFilter)
    .SelectionUidsFilter(bodyCustomAttributeFilters0SelectionUidsFilter)
    .BoolFilter(true)
    .Build();
bodyCustomAttributeFilters.Add(bodyCustomAttributeFilters0);

var bodyCustomAttributeFilters1NumberFilter = new Range.Builder()
    .Min("min1")
    .Max("max1")
    .Build();
var bodyCustomAttributeFilters1SelectionUidsFilter = new IList<string>();
bodyCustomAttributeFilters1SelectionUidsFilter.Add("selection_uids_filter1");
var bodyCustomAttributeFilters1 = new CustomAttributeFilter.Builder()
    .CustomAttributeDefinitionId("BRAND_DEFINITION_ID")
    .Key("key3")
    .StringFilter("Dark Horse")
    .NumberFilter(bodyCustomAttributeFilters1NumberFilter)
    .SelectionUidsFilter(bodyCustomAttributeFilters1SelectionUidsFilter)
    .Build();
bodyCustomAttributeFilters.Add(bodyCustomAttributeFilters1);

var bodyCustomAttributeFilters2NumberFilter = new Range.Builder()
    .Min("2017")
    .Max("2018")
    .Build();
var bodyCustomAttributeFilters2SelectionUidsFilter = new IList<string>();
bodyCustomAttributeFilters2SelectionUidsFilter.Add("selection_uids_filter0");
bodyCustomAttributeFilters2SelectionUidsFilter.Add("selection_uids_filter1");
bodyCustomAttributeFilters2SelectionUidsFilter.Add("selection_uids_filter2");
var bodyCustomAttributeFilters2 = new CustomAttributeFilter.Builder()
    .CustomAttributeDefinitionId("custom_attribute_definition_id8")
    .Key("VINTAGE")
    .StringFilter("string_filter6")
    .NumberFilter(bodyCustomAttributeFilters2NumberFilter)
    .SelectionUidsFilter(bodyCustomAttributeFilters2SelectionUidsFilter)
    .Build();
bodyCustomAttributeFilters.Add(bodyCustomAttributeFilters2);

var bodyCustomAttributeFilters3NumberFilter = new Range.Builder()
    .Min("min3")
    .Max("max9")
    .Build();
var bodyCustomAttributeFilters3SelectionUidsFilter = new IList<string>();
bodyCustomAttributeFilters3SelectionUidsFilter.Add("selection_uids_filter9");
bodyCustomAttributeFilters3SelectionUidsFilter.Add("selection_uids_filter0");
var bodyCustomAttributeFilters3 = new CustomAttributeFilter.Builder()
    .CustomAttributeDefinitionId("VARIETAL_DEFINITION_ID")
    .Key("key5")
    .StringFilter("string_filter7")
    .NumberFilter(bodyCustomAttributeFilters3NumberFilter)
    .SelectionUidsFilter(bodyCustomAttributeFilters3SelectionUidsFilter)
    .Build();
bodyCustomAttributeFilters.Add(bodyCustomAttributeFilters3);

var body = new SearchCatalogItemsRequest.Builder()
    .TextFilter("red")
    .CategoryIds(bodyCategoryIds)
    .StockLevels(bodyStockLevels)
    .EnabledLocationIds(bodyEnabledLocationIds)
    .Cursor("cursor0")
    .Limit(100)
    .SortOrder("ASC")
    .ProductTypes(bodyProductTypes)
    .CustomAttributeFilters(bodyCustomAttributeFilters)
    .Build();

try
{
    SearchCatalogItemsResponse result = await catalogApi.SearchCatalogItemsAsync(body);
}
catch (ApiException e){};
```


# Update Item Modifier Lists

Updates the [CatalogModifierList](../../doc/models/catalog-modifier-list.md) objects
that apply to the targeted [CatalogItem](../../doc/models/catalog-item.md) without having
to perform an upsert on the entire item.

```csharp
UpdateItemModifierListsAsync(
    Models.UpdateItemModifierListsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.UpdateItemModifierListsRequest`](../../doc/models/update-item-modifier-lists-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateItemModifierListsResponse>`](../../doc/models/update-item-modifier-lists-response.md)

## Example Usage

```csharp
var bodyItemIds = new IList<string>();
bodyItemIds.Add("H42BRLUJ5KTZTTMPVSLFAACQ");
bodyItemIds.Add("2JXOBJIHCWBQ4NZ3RIXQGJA6");
var bodyModifierListsToEnable = new IList<string>();
bodyModifierListsToEnable.Add("H42BRLUJ5KTZTTMPVSLFAACQ");
bodyModifierListsToEnable.Add("2JXOBJIHCWBQ4NZ3RIXQGJA6");
var bodyModifierListsToDisable = new IList<string>();
bodyModifierListsToDisable.Add("7WRC16CJZDVLSNDQ35PP6YAD");
var body = new UpdateItemModifierListsRequest.Builder(
        bodyItemIds)
    .ModifierListsToEnable(bodyModifierListsToEnable)
    .ModifierListsToDisable(bodyModifierListsToDisable)
    .Build();

try
{
    UpdateItemModifierListsResponse result = await catalogApi.UpdateItemModifierListsAsync(body);
}
catch (ApiException e){};
```


# Update Item Taxes

Updates the [CatalogTax](../../doc/models/catalog-tax.md) objects that apply to the
targeted [CatalogItem](../../doc/models/catalog-item.md) without having to perform an
upsert on the entire item.

```csharp
UpdateItemTaxesAsync(
    Models.UpdateItemTaxesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.UpdateItemTaxesRequest`](../../doc/models/update-item-taxes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateItemTaxesResponse>`](../../doc/models/update-item-taxes-response.md)

## Example Usage

```csharp
var bodyItemIds = new IList<string>();
bodyItemIds.Add("H42BRLUJ5KTZTTMPVSLFAACQ");
bodyItemIds.Add("2JXOBJIHCWBQ4NZ3RIXQGJA6");
var bodyTaxesToEnable = new IList<string>();
bodyTaxesToEnable.Add("4WRCNHCJZDVLSNDQ35PP6YAD");
var bodyTaxesToDisable = new IList<string>();
bodyTaxesToDisable.Add("AQCEGCEBBQONINDOHRGZISEX");
var body = new UpdateItemTaxesRequest.Builder(
        bodyItemIds)
    .TaxesToEnable(bodyTaxesToEnable)
    .TaxesToDisable(bodyTaxesToDisable)
    .Build();

try
{
    UpdateItemTaxesResponse result = await catalogApi.UpdateItemTaxesAsync(body);
}
catch (ApiException e){};
```

