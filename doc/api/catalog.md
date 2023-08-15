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

To ensure consistency, only one delete request is processed at a time per seller account.  
While one (batch or non-batch) delete request is being processed, other (batched and non-batched)
delete requests are rejected with the `429` error code.

```csharp
BatchDeleteCatalogObjectsAsync(
    Models.BatchDeleteCatalogObjectsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchDeleteCatalogObjectsRequest`](../../doc/models/batch-delete-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchDeleteCatalogObjectsResponse>`](../../doc/models/batch-delete-catalog-objects-response.md)

## Example Usage

```csharp
Models.BatchDeleteCatalogObjectsRequest body = new Models.BatchDeleteCatalogObjectsRequest.Builder()
.ObjectIds(
    new List<string>
    {
        "W62UWFY35CWMYGVWK6TWJDNI",
        "AA27W3M2GGTF3H6AVPNB77CK",
    })
.Build();

try
{
    BatchDeleteCatalogObjectsResponse result = await catalogApi.BatchDeleteCatalogObjectsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`BatchRetrieveCatalogObjectsRequest`](../../doc/models/batch-retrieve-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchRetrieveCatalogObjectsResponse>`](../../doc/models/batch-retrieve-catalog-objects-response.md)

## Example Usage

```csharp
Models.BatchRetrieveCatalogObjectsRequest body = new Models.BatchRetrieveCatalogObjectsRequest.Builder(
    new List<string>
    {
        "W62UWFY35CWMYGVWK6TWJDNI",
        "AA27W3M2GGTF3H6AVPNB77CK",
    }
)
.IncludeRelatedObjects(true)
.Build();

try
{
    BatchRetrieveCatalogObjectsResponse result = await catalogApi.BatchRetrieveCatalogObjectsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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

To ensure consistency, only one update request is processed at a time per seller account.  
While one (batch or non-batch) update request is being processed, other (batched and non-batched)
update requests are rejected with the `429` error code.

```csharp
BatchUpsertCatalogObjectsAsync(
    Models.BatchUpsertCatalogObjectsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BatchUpsertCatalogObjectsRequest`](../../doc/models/batch-upsert-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BatchUpsertCatalogObjectsResponse>`](../../doc/models/batch-upsert-catalog-objects-response.md)

## Example Usage

```csharp
Models.BatchUpsertCatalogObjectsRequest body = new Models.BatchUpsertCatalogObjectsRequest.Builder(
    "789ff020-f723-43a9-b4b5-43b5dc1fa3dc",
    new List<Models.CatalogObjectBatch>
    {
        new Models.CatalogObjectBatch.Builder(
            new List<Models.CatalogObject>
            {
                new Models.CatalogObject.Builder(
                    "ITEM",
                    "#Tea"
                )
                .PresentAtAllLocations(true)
                .ItemData(
                    new Models.CatalogItem.Builder()
                    .Name("Tea")
                    .CategoryId("#Beverages")
                    .TaxIds(
                        new List<string>
                        {
                            "#SalesTax",
                        })
                    .Variations(
                        new List<Models.CatalogObject>
                        {
                            new Models.CatalogObject.Builder(
                                "ITEM_VARIATION",
                                "#Tea_Mug"
                            )
                            .PresentAtAllLocations(true)
                            .ItemVariationData(
                                new Models.CatalogItemVariation.Builder()
                                .ItemId("#Tea")
                                .Name("Mug")
                                .PricingType("FIXED_PRICING")
                                .PriceMoney(
                                    new Models.Money.Builder()
                                    .Amount(150L)
                                    .Currency("USD")
                                    .Build())
                                .Build())
                            .Build(),
                        })
                    .DescriptionHtml("<p><strong>Hot</strong> Leaf Juice</p>")
                    .Build())
                .Build(),
                new Models.CatalogObject.Builder(
                    "ITEM",
                    "#Coffee"
                )
                .PresentAtAllLocations(true)
                .ItemData(
                    new Models.CatalogItem.Builder()
                    .Name("Coffee")
                    .CategoryId("#Beverages")
                    .TaxIds(
                        new List<string>
                        {
                            "#SalesTax",
                        })
                    .Variations(
                        new List<Models.CatalogObject>
                        {
                            new Models.CatalogObject.Builder(
                                "ITEM_VARIATION",
                                "#Coffee_Regular"
                            )
                            .PresentAtAllLocations(true)
                            .ItemVariationData(
                                new Models.CatalogItemVariation.Builder()
                                .ItemId("#Coffee")
                                .Name("Regular")
                                .PricingType("FIXED_PRICING")
                                .PriceMoney(
                                    new Models.Money.Builder()
                                    .Amount(250L)
                                    .Currency("USD")
                                    .Build())
                                .Build())
                            .Build(),
                            new Models.CatalogObject.Builder(
                                "ITEM_VARIATION",
                                "#Coffee_Large"
                            )
                            .PresentAtAllLocations(true)
                            .ItemVariationData(
                                new Models.CatalogItemVariation.Builder()
                                .ItemId("#Coffee")
                                .Name("Large")
                                .PricingType("FIXED_PRICING")
                                .PriceMoney(
                                    new Models.Money.Builder()
                                    .Amount(350L)
                                    .Currency("USD")
                                    .Build())
                                .Build())
                            .Build(),
                        })
                    .DescriptionHtml("<p>Hot <em>Bean Juice</em></p>")
                    .Build())
                .Build(),
                new Models.CatalogObject.Builder(
                    "CATEGORY",
                    "#Beverages"
                )
                .PresentAtAllLocations(true)
                .CategoryData(
                    new Models.CatalogCategory.Builder()
                    .Name("Beverages")
                    .Build())
                .Build(),
                new Models.CatalogObject.Builder(
                    "TAX",
                    "#SalesTax"
                )
                .PresentAtAllLocations(true)
                .TaxData(
                    new Models.CatalogTax.Builder()
                    .Name("Sales Tax")
                    .CalculationPhase("TAX_SUBTOTAL_PHASE")
                    .InclusionType("ADDITIVE")
                    .Percentage("5.0")
                    .AppliesToCustomAmounts(true)
                    .Enabled(true)
                    .Build())
                .Build(),
            }
        )
        .Build(),
    }
)
.Build();

try
{
    BatchUpsertCatalogObjectsResponse result = await catalogApi.BatchUpsertCatalogObjectsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `request` | [`CreateCatalogImageRequest`](../../doc/models/create-catalog-image-request.md) | Form (JSON-Encoded), Optional | - |
| `imageFile` | `FileStreamInfo` | Form, Optional | - |

## Response Type

[`Task<Models.CreateCatalogImageResponse>`](../../doc/models/create-catalog-image-response.md)

## Example Usage

```csharp
Models.CreateCatalogImageRequest request = new Models.CreateCatalogImageRequest.Builder(
    "528dea59-7bfb-43c1-bd48-4a6bba7dd61f86",
    new Models.CatalogObject.Builder(
        "IMAGE",
        "#TEMP_ID"
    )
    .ImageData(
        new Models.CatalogImage.Builder()
        .Caption("A picture of a cup of coffee")
        .Build())
    .Build()
)
.ObjectId("ND6EA5AAJEO5WL3JNNIAQA32")
.Build();

try
{
    CreateCatalogImageResponse result = await catalogApi.CreateCatalogImageAsync(request, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `request` | [`UpdateCatalogImageRequest`](../../doc/models/update-catalog-image-request.md) | Form (JSON-Encoded), Optional | - |
| `imageFile` | `FileStreamInfo` | Form, Optional | - |

## Response Type

[`Task<Models.UpdateCatalogImageResponse>`](../../doc/models/update-catalog-image-response.md)

## Example Usage

```csharp
string imageId = "image_id4";
Models.UpdateCatalogImageRequest request = new Models.UpdateCatalogImageRequest.Builder(
    "528dea59-7bfb-43c1-bd48-4a6bba7dd61f86"
)
.Build();

try
{
    UpdateCatalogImageResponse result = await catalogApi.UpdateCatalogImageAsync(imageId, request, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `cursor` | `string` | Query, Optional | The pagination cursor returned in the previous response. Leave unset for an initial request.<br>The page size is currently set to be 100.<br>See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information. |
| `types` | `string` | Query, Optional | An optional case-insensitive, comma-separated list of object types to retrieve.<br><br>The valid values are defined in the [CatalogObjectType](entity:CatalogObjectType) enum, for example,<br>`ITEM`, `ITEM_VARIATION`, `CATEGORY`, `DISCOUNT`, `TAX`,<br>`MODIFIER`, `MODIFIER_LIST`, `IMAGE`, etc.<br><br>If this is unspecified, the operation returns objects of all the top level types at the version<br>of the Square API used to make the request. Object types that are nested onto other object types<br>are not included in the defaults.<br><br>At the current API version the default object types are:<br>ITEM, CATEGORY, TAX, DISCOUNT, MODIFIER_LIST,<br>PRICING_RULE, PRODUCT_SET, TIME_PERIOD, MEASUREMENT_UNIT,<br>SUBSCRIPTION_PLAN, ITEM_OPTION, CUSTOM_ATTRIBUTE_DEFINITION, QUICK_AMOUNT_SETTINGS. |
| `catalogVersion` | `long?` | Query, Optional | The specific version of the catalog objects to be included in the response.<br>This allows you to retrieve historical versions of objects. The specified version value is matched against<br>the [CatalogObject](../../doc/models/catalog-object.md)s' `version` attribute.  If not included, results will be from the<br>current version of the catalog. |

## Response Type

[`Task<Models.ListCatalogResponse>`](../../doc/models/list-catalog-response.md)

## Example Usage

```csharp
try
{
    ListCatalogResponse result = await catalogApi.ListCatalogAsync(null, null, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Upsert Catalog Object

Creates a new or updates the specified [CatalogObject](../../doc/models/catalog-object.md).

To ensure consistency, only one update request is processed at a time per seller account.  
While one (batch or non-batch) update request is being processed, other (batched and non-batched)
update requests are rejected with the `429` error code.

```csharp
UpsertCatalogObjectAsync(
    Models.UpsertCatalogObjectRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`UpsertCatalogObjectRequest`](../../doc/models/upsert-catalog-object-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpsertCatalogObjectResponse>`](../../doc/models/upsert-catalog-object-response.md)

## Example Usage

```csharp
Models.UpsertCatalogObjectRequest body = new Models.UpsertCatalogObjectRequest.Builder(
    "af3d1afc-7212-4300-b463-0bfc5314a5ae",
    new Models.CatalogObject.Builder(
        "ITEM",
        "#Cocoa"
    )
    .ItemData(
        new Models.CatalogItem.Builder()
        .Name("Cocoa")
        .Abbreviation("Ch")
        .Variations(
            new List<Models.CatalogObject>
            {
                new Models.CatalogObject.Builder(
                    "ITEM_VARIATION",
                    "#Small"
                )
                .ItemVariationData(
                    new Models.CatalogItemVariation.Builder()
                    .ItemId("#Cocoa")
                    .Name("Small")
                    .PricingType("VARIABLE_PRICING")
                    .Build())
                .Build(),
                new Models.CatalogObject.Builder(
                    "ITEM_VARIATION",
                    "#Large"
                )
                .ItemVariationData(
                    new Models.CatalogItemVariation.Builder()
                    .ItemId("#Cocoa")
                    .Name("Large")
                    .PricingType("FIXED_PRICING")
                    .PriceMoney(
                        new Models.Money.Builder()
                        .Amount(400L)
                        .Currency("USD")
                        .Build())
                    .Build())
                .Build(),
            })
        .DescriptionHtml("<p><strong>Hot</strong> Chocolate</p>")
        .Build())
    .Build()
)
.Build();

try
{
    UpsertCatalogObjectResponse result = await catalogApi.UpsertCatalogObjectAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete Catalog Object

Deletes a single [CatalogObject](../../doc/models/catalog-object.md) based on the
provided ID and returns the set of successfully deleted IDs in the response.
Deletion is a cascading event such that all children of the targeted object
are also deleted. For example, deleting a [CatalogItem](../../doc/models/catalog-item.md)
will also delete all of its
[CatalogItemVariation](../../doc/models/catalog-item-variation.md) children.

To ensure consistency, only one delete request is processed at a time per seller account.  
While one (batch or non-batch) delete request is being processed, other (batched and non-batched)
delete requests are rejected with the `429` error code.

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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
try
{
    RetrieveCatalogObjectResponse result = await catalogApi.RetrieveCatalogObjectAsync(objectId, includeRelatedObjects, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`SearchCatalogObjectsRequest`](../../doc/models/search-catalog-objects-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchCatalogObjectsResponse>`](../../doc/models/search-catalog-objects-response.md)

## Example Usage

```csharp
Models.SearchCatalogObjectsRequest body = new Models.SearchCatalogObjectsRequest.Builder()
.ObjectTypes(
    new List<string>
    {
        "ITEM",
    })
.Query(
    new Models.CatalogQuery.Builder()
    .PrefixQuery(
        new Models.CatalogQueryPrefix.Builder(
            "name",
            "tea"
        )
        .Build())
    .Build())
.Limit(100)
.Build();

try
{
    SearchCatalogObjectsResponse result = await catalogApi.SearchCatalogObjectsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`SearchCatalogItemsRequest`](../../doc/models/search-catalog-items-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchCatalogItemsResponse>`](../../doc/models/search-catalog-items-response.md)

## Example Usage

```csharp
Models.SearchCatalogItemsRequest body = new Models.SearchCatalogItemsRequest.Builder()
.TextFilter("red")
.CategoryIds(
    new List<string>
    {
        "WINE_CATEGORY_ID",
    })
.StockLevels(
    new List<string>
    {
        "OUT",
        "LOW",
    })
.EnabledLocationIds(
    new List<string>
    {
        "ATL_LOCATION_ID",
    })
.Limit(100)
.SortOrder("ASC")
.ProductTypes(
    new List<string>
    {
        "REGULAR",
    })
.CustomAttributeFilters(
    new List<Models.CustomAttributeFilter>
    {
        new Models.CustomAttributeFilter.Builder()
        .CustomAttributeDefinitionId("VEGAN_DEFINITION_ID")
        .BoolFilter(true)
        .Build(),
        new Models.CustomAttributeFilter.Builder()
        .CustomAttributeDefinitionId("BRAND_DEFINITION_ID")
        .StringFilter("Dark Horse")
        .Build(),
        new Models.CustomAttributeFilter.Builder()
        .Key("VINTAGE")
        .NumberFilter(
            new Models.Range.Builder()
            .Min("2017")
            .Max("2018")
            .Build())
        .Build(),
        new Models.CustomAttributeFilter.Builder()
        .CustomAttributeDefinitionId("VARIETAL_DEFINITION_ID")
        .Build(),
    })
.Build();

try
{
    SearchCatalogItemsResponse result = await catalogApi.SearchCatalogItemsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`UpdateItemModifierListsRequest`](../../doc/models/update-item-modifier-lists-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateItemModifierListsResponse>`](../../doc/models/update-item-modifier-lists-response.md)

## Example Usage

```csharp
Models.UpdateItemModifierListsRequest body = new Models.UpdateItemModifierListsRequest.Builder(
    new List<string>
    {
        "H42BRLUJ5KTZTTMPVSLFAACQ",
        "2JXOBJIHCWBQ4NZ3RIXQGJA6",
    }
)
.ModifierListsToEnable(
    new List<string>
    {
        "H42BRLUJ5KTZTTMPVSLFAACQ",
        "2JXOBJIHCWBQ4NZ3RIXQGJA6",
    })
.ModifierListsToDisable(
    new List<string>
    {
        "7WRC16CJZDVLSNDQ35PP6YAD",
    })
.Build();

try
{
    UpdateItemModifierListsResponse result = await catalogApi.UpdateItemModifierListsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `body` | [`UpdateItemTaxesRequest`](../../doc/models/update-item-taxes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateItemTaxesResponse>`](../../doc/models/update-item-taxes-response.md)

## Example Usage

```csharp
Models.UpdateItemTaxesRequest body = new Models.UpdateItemTaxesRequest.Builder(
    new List<string>
    {
        "H42BRLUJ5KTZTTMPVSLFAACQ",
        "2JXOBJIHCWBQ4NZ3RIXQGJA6",
    }
)
.TaxesToEnable(
    new List<string>
    {
        "4WRCNHCJZDVLSNDQ35PP6YAD",
    })
.TaxesToDisable(
    new List<string>
    {
        "AQCEGCEBBQONINDOHRGZISEX",
    })
.Build();

try
{
    UpdateItemTaxesResponse result = await catalogApi.UpdateItemTaxesAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

