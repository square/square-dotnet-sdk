# Catalog

```csharp
ICatalogApi catalogApi = client.CatalogApi;
```

## Class Name

`CatalogApi`

## Methods

* [Batch Delete Catalog Objects](/doc/catalog.md#batch-delete-catalog-objects)
* [Batch Retrieve Catalog Objects](/doc/catalog.md#batch-retrieve-catalog-objects)
* [Batch Upsert Catalog Objects](/doc/catalog.md#batch-upsert-catalog-objects)
* [Create Catalog Image](/doc/catalog.md#create-catalog-image)
* [Catalog Info](/doc/catalog.md#catalog-info)
* [List Catalog](/doc/catalog.md#list-catalog)
* [Upsert Catalog Object](/doc/catalog.md#upsert-catalog-object)
* [Delete Catalog Object](/doc/catalog.md#delete-catalog-object)
* [Retrieve Catalog Object](/doc/catalog.md#retrieve-catalog-object)
* [Search Catalog Objects](/doc/catalog.md#search-catalog-objects)
* [Update Item Modifier Lists](/doc/catalog.md#update-item-modifier-lists)
* [Update Item Taxes](/doc/catalog.md#update-item-taxes)

## Batch Delete Catalog Objects

Deletes a set of [CatalogItem](#type-catalogitem)s based on the
provided list of target IDs and returns a set of successfully deleted IDs in
the response. Deletion is a cascading event such that all children of the
targeted object are also deleted. For example, deleting a CatalogItem will
also delete all of its [CatalogItemVariation](#type-catalogitemvariation)
children.

`BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted
IDs can be deleted. The response will only include IDs that were
actually deleted.

```csharp
BatchDeleteCatalogObjectsAsync(Models.BatchDeleteCatalogObjectsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchDeleteCatalogObjectsRequest`](/doc/models/batch-delete-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.BatchDeleteCatalogObjectsResponse>`](/doc/models/batch-delete-catalog-objects-response.md)

### Example Usage

```csharp
var bodyObjectIds = new List<string>();
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

## Batch Retrieve Catalog Objects

Returns a set of objects based on the provided ID.
Each [CatalogItem](#type-catalogitem) returned in the set includes all of its
child information including: all of its
[CatalogItemVariation](#type-catalogitemvariation) objects, references to
its [CatalogModifierList](#type-catalogmodifierlist) objects, and the ids of
any [CatalogTax](#type-catalogtax) objects that apply to it.

```csharp
BatchRetrieveCatalogObjectsAsync(Models.BatchRetrieveCatalogObjectsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchRetrieveCatalogObjectsRequest`](/doc/models/batch-retrieve-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.BatchRetrieveCatalogObjectsResponse>`](/doc/models/batch-retrieve-catalog-objects-response.md)

### Example Usage

```csharp
var bodyObjectIds = new List<string>();
bodyObjectIds.Add("W62UWFY35CWMYGVWK6TWJDNI");
bodyObjectIds.Add("AA27W3M2GGTF3H6AVPNB77CK");
var body = new BatchRetrieveCatalogObjectsRequest.Builder(
        bodyObjectIds)
    .IncludeRelatedObjects(true)
    .Build();

try
{
    BatchRetrieveCatalogObjectsResponse result = await catalogApi.BatchRetrieveCatalogObjectsAsync(body);
}
catch (ApiException e){};
```

## Batch Upsert Catalog Objects

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
BatchUpsertCatalogObjectsAsync(Models.BatchUpsertCatalogObjectsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BatchUpsertCatalogObjectsRequest`](/doc/models/batch-upsert-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.BatchUpsertCatalogObjectsResponse>`](/doc/models/batch-upsert-catalog-objects-response.md)

### Example Usage

```csharp
var bodyBatches = new List<CatalogObjectBatch>();

var bodyBatches0Objects = new List<CatalogObject>();

var bodyBatches0Objects0ItemDataTaxIds = new List<string>();
bodyBatches0Objects0ItemDataTaxIds.Add("#SalesTax");
var bodyBatches0Objects0ItemDataVariations = new List<CatalogObject>();

var bodyBatches0Objects0ItemDataVariations0ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Tea")
    .Name("Mug")
    .PricingType("FIXED_PRICING")
    .Build();
var bodyBatches0Objects0ItemDataVariations0 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Tea_Mug")
    .PresentAtAllLocations(true)
    .ItemVariationData(bodyBatches0Objects0ItemDataVariations0ItemVariationData)
    .Build();
bodyBatches0Objects0ItemDataVariations.Add(bodyBatches0Objects0ItemDataVariations0);

var bodyBatches0Objects0ItemData = new CatalogItem.Builder()
    .Name("Tea")
    .Description("Hot Leaf Juice")
    .CategoryId("#Beverages")
    .TaxIds(bodyBatches0Objects0ItemDataTaxIds)
    .Variations(bodyBatches0Objects0ItemDataVariations)
    .Build();
var bodyBatches0Objects0 = new CatalogObject.Builder(
        "ITEM",
        "#Tea")
    .PresentAtAllLocations(true)
    .ItemData(bodyBatches0Objects0ItemData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects0);

var bodyBatches0Objects1ItemDataTaxIds = new List<string>();
bodyBatches0Objects1ItemDataTaxIds.Add("#SalesTax");
var bodyBatches0Objects1ItemDataVariations = new List<CatalogObject>();

var bodyBatches0Objects1ItemDataVariations0ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Coffee")
    .Name("Regular")
    .PricingType("FIXED_PRICING")
    .Build();
var bodyBatches0Objects1ItemDataVariations0 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Coffee_Regular")
    .PresentAtAllLocations(true)
    .ItemVariationData(bodyBatches0Objects1ItemDataVariations0ItemVariationData)
    .Build();
bodyBatches0Objects1ItemDataVariations.Add(bodyBatches0Objects1ItemDataVariations0);

var bodyBatches0Objects1ItemDataVariations1ItemVariationData = new CatalogItemVariation.Builder()
    .ItemId("#Coffee")
    .Name("Large")
    .PricingType("FIXED_PRICING")
    .Build();
var bodyBatches0Objects1ItemDataVariations1 = new CatalogObject.Builder(
        "ITEM_VARIATION",
        "#Coffee_Large")
    .PresentAtAllLocations(true)
    .ItemVariationData(bodyBatches0Objects1ItemDataVariations1ItemVariationData)
    .Build();
bodyBatches0Objects1ItemDataVariations.Add(bodyBatches0Objects1ItemDataVariations1);

var bodyBatches0Objects1ItemData = new CatalogItem.Builder()
    .Name("Coffee")
    .Description("Hot Bean Juice")
    .CategoryId("#Beverages")
    .TaxIds(bodyBatches0Objects1ItemDataTaxIds)
    .Variations(bodyBatches0Objects1ItemDataVariations)
    .Build();
var bodyBatches0Objects1 = new CatalogObject.Builder(
        "ITEM",
        "#Coffee")
    .PresentAtAllLocations(true)
    .ItemData(bodyBatches0Objects1ItemData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects1);

var bodyBatches0Objects2CategoryData = new CatalogCategory.Builder()
    .Name("Beverages")
    .Build();
var bodyBatches0Objects2 = new CatalogObject.Builder(
        "CATEGORY",
        "#Beverages")
    .PresentAtAllLocations(true)
    .CategoryData(bodyBatches0Objects2CategoryData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects2);

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
    .PresentAtAllLocations(true)
    .TaxData(bodyBatches0Objects3TaxData)
    .Build();
bodyBatches0Objects.Add(bodyBatches0Objects3);

var bodyBatches0 = new CatalogObjectBatch.Builder()
    .Objects(bodyBatches0Objects)
    .Build();
bodyBatches.Add(bodyBatches0);

var body = new BatchUpsertCatalogObjectsRequest.Builder(
        "789ff020-f723-43a9-b4b5-43b5dc1fa3dc")
    .Batches(bodyBatches)
    .Build();

try
{
    BatchUpsertCatalogObjectsResponse result = await catalogApi.BatchUpsertCatalogObjectsAsync(body);
}
catch (ApiException e){};
```

## Create Catalog Image

Upload an image file to create a new [CatalogImage](#type-catalogimage) for an existing
[CatalogObject](#type-catalogobject). Images can be uploaded and linked in this request or created independently
(without an object assignment) and linked to a [CatalogObject](#type-catalogobject) at a later time.

CreateCatalogImage accepts HTTP multipart/form-data requests with a JSON part and an image file part in
JPEG, PJPEG, PNG, or GIF format. The maximum file size is 15MB. The following is an example of such an HTTP request:

```
POST /v2/catalog/images
Accept: application/json
Content-Type: multipart/form-data;boundary="boundary"
Square-Version: XXXX-XX-XX
Authorization: Bearer {ACCESS_TOKEN}

--boundary
Content-Disposition: form-data; name="request"
Content-Type: application/json

{
"idempotency_key":"528dea59-7bfb-43c1-bd48-4a6bba7dd61f86",
"object_id": "ND6EA5AAJEO5WL3JNNIAQA32",
"image":{
"id":"#TEMP_ID",
"type":"IMAGE",
"image_data":{
"caption":"A picture of a cup of coffee"
}
}
}
--boundary
Content-Disposition: form-data; name="image"; filename="Coffee.jpg"
Content-Type: image/jpeg

{ACTUAL_IMAGE_BYTES}
--boundary
```

Additional information and an example cURL request can be found in the [Create a Catalog Image recipe](https://developer.squareup.com/docs/more-apis/catalog/cookbook/create-catalog-images).

```csharp
CreateCatalogImageAsync(Models.CreateCatalogImageRequest request = null, FileStreamInfo imageFile = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `request` | [`Models.CreateCatalogImageRequest`](/doc/models/create-catalog-image-request.md) | Form, Optional | - |
| `imageFile` | `FileStreamInfo` | Form, Optional | - |

### Response Type

[`Task<Models.CreateCatalogImageResponse>`](/doc/models/create-catalog-image-response.md)

### Example Usage

```csharp
var requestImageImageData = new CatalogImage.Builder()
    .Caption("A picture of a cup of coffee")
    .Build();
var requestImage = new CatalogObject.Builder(
        "IMAGE",
        "#TEMP_ID")
    .ImageData(requestImageImageData)
    .Build();
var request = new CreateCatalogImageRequest.Builder(
        "528dea59-7bfb-43c1-bd48-4a6bba7dd61f86")
    .ObjectId("ND6EA5AAJEO5WL3JNNIAQA32")
    .Image(requestImage)
    .Build();

try
{
    CreateCatalogImageResponse result = await catalogApi.CreateCatalogImageAsync(request, null);
}
catch (ApiException e){};
```

## Catalog Info

Returns information about the Square Catalog API, such as batch size
limits for `BatchUpsertCatalogObjects`.

```csharp
CatalogInfoAsync()
```

### Response Type

[`Task<Models.CatalogInfoResponse>`](/doc/models/catalog-info-response.md)

### Example Usage

```csharp
try
{
    CatalogInfoResponse result = await catalogApi.CatalogInfoAsync();
}
catch (ApiException e){};
```

## List Catalog

Returns a list of [CatalogObject](#type-catalogobject)s that includes
all objects of a set of desired types (for example, all [CatalogItem](#type-catalogitem)
and [CatalogTax](#type-catalogtax) objects) in the catalog. The `types` parameter
is specified as a comma-separated list of valid [CatalogObject](#type-catalogobject) types:
`ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`.

__Important:__ ListCatalog does not return deleted catalog items. To retrieve
deleted catalog items, use SearchCatalogObjects and set `include_deleted_objects`
to `true`.

```csharp
ListCatalogAsync(string cursor = null, string types = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | The pagination cursor returned in the previous response. Leave unset for an initial request.<br>See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information. |
| `types` | `string` | Query, Optional | An optional case-insensitive, comma-separated list of object types to retrieve, for example<br>`ITEM,ITEM_VARIATION,CATEGORY,IMAGE`.<br><br>The legal values are taken from the CatalogObjectType enum:<br>`ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`,<br>`MODIFIER`, `MODIFIER_LIST`, or `IMAGE`. |

### Response Type

[`Task<Models.ListCatalogResponse>`](/doc/models/list-catalog-response.md)

### Example Usage

```csharp
try
{
    ListCatalogResponse result = await catalogApi.ListCatalogAsync(null, null);
}
catch (ApiException e){};
```

## Upsert Catalog Object

Creates or updates the target [CatalogObject](#type-catalogobject).

```csharp
UpsertCatalogObjectAsync(Models.UpsertCatalogObjectRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.UpsertCatalogObjectRequest`](/doc/models/upsert-catalog-object-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpsertCatalogObjectResponse>`](/doc/models/upsert-catalog-object-response.md)

### Example Usage

```csharp
var bodyMObjectItemData = new CatalogItem.Builder()
    .Name("Cocoa")
    .Description("Hot chocolate")
    .Abbreviation("Ch")
    .Build();
var bodyMObject = new CatalogObject.Builder(
        "ITEM",
        "#Cocoa")
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

## Delete Catalog Object

Deletes a single [CatalogObject](#type-catalogobject) based on the
provided ID and returns the set of successfully deleted IDs in the response.
Deletion is a cascading event such that all children of the targeted object
are also deleted. For example, deleting a [CatalogItem](#type-catalogitem)
will also delete all of its
[CatalogItemVariation](#type-catalogitemvariation) children.

```csharp
DeleteCatalogObjectAsync(string objectId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `objectId` | `string` | Template, Required | The ID of the catalog object to be deleted. When an object is deleted, other<br>objects in the graph that depend on that object will be deleted as well (for example, deleting a<br>catalog item will delete its catalog item variations). |

### Response Type

[`Task<Models.DeleteCatalogObjectResponse>`](/doc/models/delete-catalog-object-response.md)

### Example Usage

```csharp
string objectId = "object_id8";

try
{
    DeleteCatalogObjectResponse result = await catalogApi.DeleteCatalogObjectAsync(objectId);
}
catch (ApiException e){};
```

## Retrieve Catalog Object

Returns a single [CatalogItem](#type-catalogitem) as a
[CatalogObject](#type-catalogobject) based on the provided ID. The returned
object includes all of the relevant [CatalogItem](#type-catalogitem)
information including: [CatalogItemVariation](#type-catalogitemvariation)
children, references to its
[CatalogModifierList](#type-catalogmodifierlist) objects, and the ids of
any [CatalogTax](#type-catalogtax) objects that apply to it.

```csharp
RetrieveCatalogObjectAsync(string objectId, bool? includeRelatedObjects = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `objectId` | `string` | Template, Required | The object ID of any type of catalog objects to be retrieved. |
| `includeRelatedObjects` | `bool?` | Query, Optional | If `true`, the response will include additional objects that are related to the<br>requested object, as follows:<br><br>If the `object` field of the response contains a CatalogItem,<br>its associated CatalogCategory, CatalogTax objects,<br>CatalogImages and CatalogModifierLists<br>will be returned in the `related_objects` field of the response. If the `object`<br>field of the response contains a CatalogItemVariation,<br>its parent CatalogItem will be returned in the `related_objects` field of<br>the response.<br><br>Default value: `false` |

### Response Type

[`Task<Models.RetrieveCatalogObjectResponse>`](/doc/models/retrieve-catalog-object-response.md)

### Example Usage

```csharp
string objectId = "object_id8";

try
{
    RetrieveCatalogObjectResponse result = await catalogApi.RetrieveCatalogObjectAsync(objectId, null);
}
catch (ApiException e){};
```

## Search Catalog Objects

Queries the targeted catalog using a variety of query types:
[CatalogQuerySortedAttribute](#type-catalogquerysortedattribute),
[CatalogQueryExact](#type-catalogqueryexact),
[CatalogQueryRange](#type-catalogqueryrange),
[CatalogQueryText](#type-catalogquerytext),
[CatalogQueryItemsForTax](#type-catalogqueryitemsfortax), and
[CatalogQueryItemsForModifierList](#type-catalogqueryitemsformodifierlist).
--
--
Future end of the above comment:
[CatalogQueryItemsForTax](#type-catalogqueryitemsfortax),
[CatalogQueryItemsForModifierList](#type-catalogqueryitemsformodifierlist),
[CatalogQueryItemsForItemOptions](#type-catalogqueryitemsforitemoptions), and
[CatalogQueryItemVariationsForItemOptionValues](#type-catalogqueryitemvariationsforitemoptionvalues).

```csharp
SearchCatalogObjectsAsync(Models.SearchCatalogObjectsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchCatalogObjectsRequest`](/doc/models/search-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchCatalogObjectsResponse>`](/doc/models/search-catalog-objects-response.md)

### Example Usage

```csharp
var bodyObjectTypes = new List<string>();
bodyObjectTypes.Add("ITEM");
var bodyQueryPrefixQuery = new CatalogQueryPrefix.Builder(
        "name",
        "tea")
    .Build();
var bodyQuery = new CatalogQuery.Builder()
    .PrefixQuery(bodyQueryPrefixQuery)
    .Build();
var body = new SearchCatalogObjectsRequest.Builder()
    .ObjectTypes(bodyObjectTypes)
    .Query(bodyQuery)
    .Limit(100)
    .Build();

try
{
    SearchCatalogObjectsResponse result = await catalogApi.SearchCatalogObjectsAsync(body);
}
catch (ApiException e){};
```

## Update Item Modifier Lists

Updates the [CatalogModifierList](#type-catalogmodifierlist) objects
that apply to the targeted [CatalogItem](#type-catalogitem) without having
to perform an upsert on the entire item.

```csharp
UpdateItemModifierListsAsync(Models.UpdateItemModifierListsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.UpdateItemModifierListsRequest`](/doc/models/update-item-modifier-lists-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateItemModifierListsResponse>`](/doc/models/update-item-modifier-lists-response.md)

### Example Usage

```csharp
var bodyItemIds = new List<string>();
bodyItemIds.Add("H42BRLUJ5KTZTTMPVSLFAACQ");
bodyItemIds.Add("2JXOBJIHCWBQ4NZ3RIXQGJA6");
var bodyModifierListsToEnable = new List<string>();
bodyModifierListsToEnable.Add("H42BRLUJ5KTZTTMPVSLFAACQ");
bodyModifierListsToEnable.Add("2JXOBJIHCWBQ4NZ3RIXQGJA6");
var bodyModifierListsToDisable = new List<string>();
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

## Update Item Taxes

Updates the [CatalogTax](#type-catalogtax) objects that apply to the
targeted [CatalogItem](#type-catalogitem) without having to perform an
upsert on the entire item.

```csharp
UpdateItemTaxesAsync(Models.UpdateItemTaxesRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.UpdateItemTaxesRequest`](/doc/models/update-item-taxes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateItemTaxesResponse>`](/doc/models/update-item-taxes-response.md)

### Example Usage

```csharp
var bodyItemIds = new List<string>();
bodyItemIds.Add("H42BRLUJ5KTZTTMPVSLFAACQ");
bodyItemIds.Add("2JXOBJIHCWBQ4NZ3RIXQGJA6");
var bodyTaxesToEnable = new List<string>();
bodyTaxesToEnable.Add("4WRCNHCJZDVLSNDQ35PP6YAD");
var bodyTaxesToDisable = new List<string>();
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

