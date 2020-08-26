# V1 Items

```csharp
IV1ItemsApi v1ItemsApi = client.V1ItemsApi;
```

## Class Name

`V1ItemsApi`

## Methods

* [List Categories](/doc/v1-items.md#list-categories)
* [Create Category](/doc/v1-items.md#create-category)
* [Delete Category](/doc/v1-items.md#delete-category)
* [Update Category](/doc/v1-items.md#update-category)
* [List Discounts](/doc/v1-items.md#list-discounts)
* [Create Discount](/doc/v1-items.md#create-discount)
* [Delete Discount](/doc/v1-items.md#delete-discount)
* [Update Discount](/doc/v1-items.md#update-discount)
* [List Fees](/doc/v1-items.md#list-fees)
* [Create Fee](/doc/v1-items.md#create-fee)
* [Delete Fee](/doc/v1-items.md#delete-fee)
* [Update Fee](/doc/v1-items.md#update-fee)
* [List Inventory](/doc/v1-items.md#list-inventory)
* [Adjust Inventory](/doc/v1-items.md#adjust-inventory)
* [List Items](/doc/v1-items.md#list-items)
* [Create Item](/doc/v1-items.md#create-item)
* [Delete Item](/doc/v1-items.md#delete-item)
* [Retrieve Item](/doc/v1-items.md#retrieve-item)
* [Update Item](/doc/v1-items.md#update-item)
* [Remove Fee](/doc/v1-items.md#remove-fee)
* [Apply Fee](/doc/v1-items.md#apply-fee)
* [Remove Modifier List](/doc/v1-items.md#remove-modifier-list)
* [Apply Modifier List](/doc/v1-items.md#apply-modifier-list)
* [Create Variation](/doc/v1-items.md#create-variation)
* [Delete Variation](/doc/v1-items.md#delete-variation)
* [Update Variation](/doc/v1-items.md#update-variation)
* [List Modifier Lists](/doc/v1-items.md#list-modifier-lists)
* [Create Modifier List](/doc/v1-items.md#create-modifier-list)
* [Delete Modifier List](/doc/v1-items.md#delete-modifier-list)
* [Retrieve Modifier List](/doc/v1-items.md#retrieve-modifier-list)
* [Update Modifier List](/doc/v1-items.md#update-modifier-list)
* [Create Modifier Option](/doc/v1-items.md#create-modifier-option)
* [Delete Modifier Option](/doc/v1-items.md#delete-modifier-option)
* [Update Modifier Option](/doc/v1-items.md#update-modifier-option)
* [List Pages](/doc/v1-items.md#list-pages)
* [Create Page](/doc/v1-items.md#create-page)
* [Delete Page](/doc/v1-items.md#delete-page)
* [Update Page](/doc/v1-items.md#update-page)
* [Delete Page Cell](/doc/v1-items.md#delete-page-cell)
* [Update Page Cell](/doc/v1-items.md#update-page-cell)

## List Categories

Lists all the item categories for a given location.

```csharp
ListCategoriesAsync(string locationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list categories for. |

### Response Type

[`Task<List<Models.V1Category>>`](/doc/models/v1-category.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    List<V1Category> result = await v1ItemsApi.ListCategoriesAsync(locationId);
}
catch (ApiException e){};
```

## Create Category

Creates an item category.

```csharp
CreateCategoryAsync(string locationId, Models.V1Category body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to create an item for. |
| `body` | [`Models.V1Category`](/doc/models/v1-category.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Category>`](/doc/models/v1-category.md)

### Example Usage

```csharp
string locationId = "location_id4";
var body = new V1Category.Builder()
    .Id("id6")
    .Name("name6")
    .V2Id("v2_id6")
    .Build();

try
{
    V1Category result = await v1ItemsApi.CreateCategoryAsync(locationId, body);
}
catch (ApiException e){};
```

## Delete Category

Deletes an existing item category.


__DeleteCategory__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeleteCategoryRequest` object
as documented below.

```csharp
DeleteCategoryAsync(string locationId, string categoryId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `categoryId` | `string` | Template, Required | The ID of the category to delete. |

### Response Type

[`Task<Models.V1Category>`](/doc/models/v1-category.md)

### Example Usage

```csharp
string locationId = "location_id4";
string categoryId = "category_id8";

try
{
    V1Category result = await v1ItemsApi.DeleteCategoryAsync(locationId, categoryId);
}
catch (ApiException e){};
```

## Update Category

Modifies the details of an existing item category.

```csharp
UpdateCategoryAsync(string locationId, string categoryId, Models.V1Category body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the category's associated location. |
| `categoryId` | `string` | Template, Required | The ID of the category to edit. |
| `body` | [`Models.V1Category`](/doc/models/v1-category.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Category>`](/doc/models/v1-category.md)

### Example Usage

```csharp
string locationId = "location_id4";
string categoryId = "category_id8";
var body = new V1Category.Builder()
    .Id("id6")
    .Name("name6")
    .V2Id("v2_id6")
    .Build();

try
{
    V1Category result = await v1ItemsApi.UpdateCategoryAsync(locationId, categoryId, body);
}
catch (ApiException e){};
```

## List Discounts

Lists all the discounts for a given location.

```csharp
ListDiscountsAsync(string locationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list categories for. |

### Response Type

[`Task<List<Models.V1Discount>>`](/doc/models/v1-discount.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    List<V1Discount> result = await v1ItemsApi.ListDiscountsAsync(locationId);
}
catch (ApiException e){};
```

## Create Discount

Creates a discount.

```csharp
CreateDiscountAsync(string locationId, Models.V1Discount body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to create an item for. |
| `body` | [`Models.V1Discount`](/doc/models/v1-discount.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Discount>`](/doc/models/v1-discount.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyAmountMoney = new V1Money.Builder()
    .Amount(194)
    .CurrencyCode("KWD")
    .Build();
var body = new V1Discount.Builder()
    .Id("id6")
    .Name("name6")
    .Rate("rate4")
    .AmountMoney(bodyAmountMoney)
    .DiscountType("VARIABLE_AMOUNT")
    .Build();

try
{
    V1Discount result = await v1ItemsApi.CreateDiscountAsync(locationId, body);
}
catch (ApiException e){};
```

## Delete Discount

Deletes an existing discount.


__DeleteDiscount__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeleteDiscountRequest` object
as documented below.

```csharp
DeleteDiscountAsync(string locationId, string discountId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `discountId` | `string` | Template, Required | The ID of the discount to delete. |

### Response Type

[`Task<Models.V1Discount>`](/doc/models/v1-discount.md)

### Example Usage

```csharp
string locationId = "location_id4";
string discountId = "discount_id8";

try
{
    V1Discount result = await v1ItemsApi.DeleteDiscountAsync(locationId, discountId);
}
catch (ApiException e){};
```

## Update Discount

Modifies the details of an existing discount.

```csharp
UpdateDiscountAsync(string locationId, string discountId, Models.V1Discount body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the category's associated location. |
| `discountId` | `string` | Template, Required | The ID of the discount to edit. |
| `body` | [`Models.V1Discount`](/doc/models/v1-discount.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Discount>`](/doc/models/v1-discount.md)

### Example Usage

```csharp
string locationId = "location_id4";
string discountId = "discount_id8";
var bodyAmountMoney = new V1Money.Builder()
    .Amount(194)
    .CurrencyCode("KWD")
    .Build();
var body = new V1Discount.Builder()
    .Id("id6")
    .Name("name6")
    .Rate("rate4")
    .AmountMoney(bodyAmountMoney)
    .DiscountType("VARIABLE_AMOUNT")
    .Build();

try
{
    V1Discount result = await v1ItemsApi.UpdateDiscountAsync(locationId, discountId, body);
}
catch (ApiException e){};
```

## List Fees

Lists all the fees (taxes) for a given location.

```csharp
ListFeesAsync(string locationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list fees for. |

### Response Type

[`Task<List<Models.V1Fee>>`](/doc/models/v1-fee.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    List<V1Fee> result = await v1ItemsApi.ListFeesAsync(locationId);
}
catch (ApiException e){};
```

## Create Fee

Creates a fee (tax).

```csharp
CreateFeeAsync(string locationId, Models.V1Fee body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to create a fee for. |
| `body` | [`Models.V1Fee`](/doc/models/v1-fee.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Fee>`](/doc/models/v1-fee.md)

### Example Usage

```csharp
string locationId = "location_id4";
var body = new V1Fee.Builder()
    .Id("id6")
    .Name("name6")
    .Rate("rate4")
    .CalculationPhase("FEE_SUBTOTAL_PHASE")
    .AdjustmentType("TAX")
    .Build();

try
{
    V1Fee result = await v1ItemsApi.CreateFeeAsync(locationId, body);
}
catch (ApiException e){};
```

## Delete Fee

Deletes an existing fee (tax).


__DeleteFee__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeleteFeeRequest` object
as documented below.

```csharp
DeleteFeeAsync(string locationId, string feeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the fee's associated location. |
| `feeId` | `string` | Template, Required | The ID of the fee to delete. |

### Response Type

[`Task<Models.V1Fee>`](/doc/models/v1-fee.md)

### Example Usage

```csharp
string locationId = "location_id4";
string feeId = "fee_id8";

try
{
    V1Fee result = await v1ItemsApi.DeleteFeeAsync(locationId, feeId);
}
catch (ApiException e){};
```

## Update Fee

Modifies the details of an existing fee (tax).

```csharp
UpdateFeeAsync(string locationId, string feeId, Models.V1Fee body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the fee's associated location. |
| `feeId` | `string` | Template, Required | The ID of the fee to edit. |
| `body` | [`Models.V1Fee`](/doc/models/v1-fee.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Fee>`](/doc/models/v1-fee.md)

### Example Usage

```csharp
string locationId = "location_id4";
string feeId = "fee_id8";
var body = new V1Fee.Builder()
    .Id("id6")
    .Name("name6")
    .Rate("rate4")
    .CalculationPhase("FEE_SUBTOTAL_PHASE")
    .AdjustmentType("TAX")
    .Build();

try
{
    V1Fee result = await v1ItemsApi.UpdateFeeAsync(locationId, feeId, body);
}
catch (ApiException e){};
```

## List Inventory

Provides inventory information for all inventory-enabled item
variations.

```csharp
ListInventoryAsync(string locationId, int? limit = null, string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `limit` | `int?` | Query, Optional | The maximum number of inventory entries to return in a single response. This value cannot exceed 1000. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1InventoryEntry>>`](/doc/models/v1-inventory-entry.md)

### Example Usage

```csharp
string locationId = "location_id4";
int? limit = 172;
string batchToken = "batch_token2";

try
{
    List<V1InventoryEntry> result = await v1ItemsApi.ListInventoryAsync(locationId, limit, batchToken);
}
catch (ApiException e){};
```

## Adjust Inventory

Adjusts the current available inventory of an item variation.

```csharp
AdjustInventoryAsync(string locationId, string variationId, Models.V1AdjustInventoryRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `variationId` | `string` | Template, Required | The ID of the variation to adjust inventory information for. |
| `body` | [`Models.V1AdjustInventoryRequest`](/doc/models/v1-adjust-inventory-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1InventoryEntry>`](/doc/models/v1-inventory-entry.md)

### Example Usage

```csharp
string locationId = "location_id4";
string variationId = "variation_id2";
var body = new V1AdjustInventoryRequest.Builder()
    .QuantityDelta(87.82)
    .AdjustmentType("SALE")
    .Memo("memo0")
    .Build();

try
{
    V1InventoryEntry result = await v1ItemsApi.AdjustInventoryAsync(locationId, variationId, body);
}
catch (ApiException e){};
```

## List Items

Provides summary information of all items for a given location.

```csharp
ListItemsAsync(string locationId, string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list items for. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1Item>>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string batchToken = "batch_token2";

try
{
    List<V1Item> result = await v1ItemsApi.ListItemsAsync(locationId, batchToken);
}
catch (ApiException e){};
```

## Create Item

Creates an item and at least one variation for it.



Item-related entities include fields you can use to associate them with
entities in a non-Square system.

When you create an item-related entity, you can optionally specify `id`.
This value must be unique among all IDs ever specified for the account,
including those specified by other applications. You can never reuse an
entity ID. If you do not specify an ID, Square generates one for the entity.

Item variations have a `user_data` string that lets you associate arbitrary
metadata with the variation. The string cannot exceed 255 characters.

```csharp
CreateItemAsync(string locationId, Models.V1Item body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to create an item for. |
| `body` | [`Models.V1Item`](/doc/models/v1-item.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
var body = new V1Item.Builder()
    .Id("id6")
    .Name("name6")
    .Description("description4")
    .Type("GIFT_CARD")
    .Color("593c00")
    .Build();

try
{
    V1Item result = await v1ItemsApi.CreateItemAsync(locationId, body);
}
catch (ApiException e){};
```

## Delete Item

Deletes an existing item and all item variations associated with it.


__DeleteItem__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeleteItemRequest` object
as documented below.

```csharp
DeleteItemAsync(string locationId, string itemId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `itemId` | `string` | Template, Required | The ID of the item to modify. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";

try
{
    V1Item result = await v1ItemsApi.DeleteItemAsync(locationId, itemId);
}
catch (ApiException e){};
```

## Retrieve Item

Provides the details for a single item, including associated modifier
lists and fees.

```csharp
RetrieveItemAsync(string locationId, string itemId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `itemId` | `string` | Template, Required | The item's ID. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";

try
{
    V1Item result = await v1ItemsApi.RetrieveItemAsync(locationId, itemId);
}
catch (ApiException e){};
```

## Update Item

Modifies the core details of an existing item.

```csharp
UpdateItemAsync(string locationId, string itemId, Models.V1Item body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `itemId` | `string` | Template, Required | The ID of the item to modify. |
| `body` | [`Models.V1Item`](/doc/models/v1-item.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";
var body = new V1Item.Builder()
    .Id("id6")
    .Name("name6")
    .Description("description4")
    .Type("GIFT_CARD")
    .Color("593c00")
    .Build();

try
{
    V1Item result = await v1ItemsApi.UpdateItemAsync(locationId, itemId, body);
}
catch (ApiException e){};
```

## Remove Fee

Removes a fee assocation from an item so the fee is no longer
automatically applied to the item in Square Point of Sale.

```csharp
RemoveFeeAsync(string locationId, string itemId, string feeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the fee's associated location. |
| `itemId` | `string` | Template, Required | The ID of the item to add the fee to. |
| `feeId` | `string` | Template, Required | The ID of the fee to apply. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";
string feeId = "fee_id8";

try
{
    V1Item result = await v1ItemsApi.RemoveFeeAsync(locationId, itemId, feeId);
}
catch (ApiException e){};
```

## Apply Fee

Associates a fee with an item so the fee is automatically applied to
the item in Square Point of Sale.

```csharp
ApplyFeeAsync(string locationId, string itemId, string feeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the fee's associated location. |
| `itemId` | `string` | Template, Required | The ID of the item to add the fee to. |
| `feeId` | `string` | Template, Required | The ID of the fee to apply. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";
string feeId = "fee_id8";

try
{
    V1Item result = await v1ItemsApi.ApplyFeeAsync(locationId, itemId, feeId);
}
catch (ApiException e){};
```

## Remove Modifier List

Removes a modifier list association from an item so the modifier
options from the list can no longer be applied to the item.

```csharp
RemoveModifierListAsync(string locationId, string modifierListId, string itemId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The ID of the modifier list to remove. |
| `itemId` | `string` | Template, Required | The ID of the item to remove the modifier list from. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";
string itemId = "item_id0";

try
{
    V1Item result = await v1ItemsApi.RemoveModifierListAsync(locationId, modifierListId, itemId);
}
catch (ApiException e){};
```

## Apply Modifier List

Associates a modifier list with an item so the associated modifier
options can be applied to the item.

```csharp
ApplyModifierListAsync(string locationId, string modifierListId, string itemId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The ID of the modifier list to apply. |
| `itemId` | `string` | Template, Required | The ID of the item to add the modifier list to. |

### Response Type

[`Task<Models.V1Item>`](/doc/models/v1-item.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";
string itemId = "item_id0";

try
{
    V1Item result = await v1ItemsApi.ApplyModifierListAsync(locationId, modifierListId, itemId);
}
catch (ApiException e){};
```

## Create Variation

Creates an item variation for an existing item.

```csharp
CreateVariationAsync(string locationId, string itemId, Models.V1Variation body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `itemId` | `string` | Template, Required | The item's ID. |
| `body` | [`Models.V1Variation`](/doc/models/v1-variation.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Variation>`](/doc/models/v1-variation.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";
var body = new V1Variation.Builder()
    .Id("id6")
    .Name("name6")
    .ItemId("item_id4")
    .Ordinal(88)
    .PricingType("FIXED_PRICING")
    .Build();

try
{
    V1Variation result = await v1ItemsApi.CreateVariationAsync(locationId, itemId, body);
}
catch (ApiException e){};
```

## Delete Variation

Deletes an existing item variation from an item.


__DeleteVariation__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeleteVariationRequest` object
as documented below.

```csharp
DeleteVariationAsync(string locationId, string itemId, string variationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `itemId` | `string` | Template, Required | The ID of the item to delete. |
| `variationId` | `string` | Template, Required | The ID of the variation to delete. |

### Response Type

[`Task<Models.V1Variation>`](/doc/models/v1-variation.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";
string variationId = "variation_id2";

try
{
    V1Variation result = await v1ItemsApi.DeleteVariationAsync(locationId, itemId, variationId);
}
catch (ApiException e){};
```

## Update Variation

Modifies the details of an existing item variation.

```csharp
UpdateVariationAsync(
    string locationId,
    string itemId,
    string variationId,
    Models.V1Variation body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `itemId` | `string` | Template, Required | The ID of the item to modify. |
| `variationId` | `string` | Template, Required | The ID of the variation to modify. |
| `body` | [`Models.V1Variation`](/doc/models/v1-variation.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Variation>`](/doc/models/v1-variation.md)

### Example Usage

```csharp
string locationId = "location_id4";
string itemId = "item_id0";
string variationId = "variation_id2";
var body = new V1Variation.Builder()
    .Id("id6")
    .Name("name6")
    .ItemId("item_id4")
    .Ordinal(88)
    .PricingType("FIXED_PRICING")
    .Build();

try
{
    V1Variation result = await v1ItemsApi.UpdateVariationAsync(locationId, itemId, variationId, body);
}
catch (ApiException e){};
```

## List Modifier Lists

Lists all the modifier lists for a given location.

```csharp
ListModifierListsAsync(string locationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list modifier lists for. |

### Response Type

[`Task<List<Models.V1ModifierList>>`](/doc/models/v1-modifier-list.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    List<V1ModifierList> result = await v1ItemsApi.ListModifierListsAsync(locationId);
}
catch (ApiException e){};
```

## Create Modifier List

Creates an item modifier list and at least 1 modifier option for it.

```csharp
CreateModifierListAsync(string locationId, Models.V1ModifierList body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to create a modifier list for. |
| `body` | [`Models.V1ModifierList`](/doc/models/v1-modifier-list.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1ModifierList>`](/doc/models/v1-modifier-list.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyModifierOptions = new List<V1ModifierOption>();

var bodyModifierOptions0PriceMoney = new V1Money.Builder()
    .Amount(104)
    .CurrencyCode("UAH")
    .Build();
var bodyModifierOptions0 = new V1ModifierOption.Builder()
    .Id("id0")
    .Name("name0")
    .PriceMoney(bodyModifierOptions0PriceMoney)
    .OnByDefault(false)
    .Ordinal(178)
    .Build();
bodyModifierOptions.Add(bodyModifierOptions0);

var bodyModifierOptions1PriceMoney = new V1Money.Builder()
    .Amount(103)
    .CurrencyCode("TZS")
    .Build();
var bodyModifierOptions1 = new V1ModifierOption.Builder()
    .Id("id1")
    .Name("name1")
    .PriceMoney(bodyModifierOptions1PriceMoney)
    .OnByDefault(true)
    .Ordinal(179)
    .Build();
bodyModifierOptions.Add(bodyModifierOptions1);

var body = new V1ModifierList.Builder()
    .Id("id6")
    .Name("name6")
    .SelectionType("SINGLE")
    .ModifierOptions(bodyModifierOptions)
    .V2Id("v2_id6")
    .Build();

try
{
    V1ModifierList result = await v1ItemsApi.CreateModifierListAsync(locationId, body);
}
catch (ApiException e){};
```

## Delete Modifier List

Deletes an existing item modifier list and all modifier options
associated with it.


__DeleteModifierList__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeleteModifierListRequest` object
as documented below.

```csharp
DeleteModifierListAsync(string locationId, string modifierListId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The ID of the modifier list to delete. |

### Response Type

[`Task<Models.V1ModifierList>`](/doc/models/v1-modifier-list.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";

try
{
    V1ModifierList result = await v1ItemsApi.DeleteModifierListAsync(locationId, modifierListId);
}
catch (ApiException e){};
```

## Retrieve Modifier List

Provides the details for a single modifier list.

```csharp
RetrieveModifierListAsync(string locationId, string modifierListId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The modifier list's ID. |

### Response Type

[`Task<Models.V1ModifierList>`](/doc/models/v1-modifier-list.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";

try
{
    V1ModifierList result = await v1ItemsApi.RetrieveModifierListAsync(locationId, modifierListId);
}
catch (ApiException e){};
```

## Update Modifier List

Modifies the details of an existing item modifier list.

```csharp
UpdateModifierListAsync(string locationId, string modifierListId, Models.V1UpdateModifierListRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The ID of the modifier list to edit. |
| `body` | [`Models.V1UpdateModifierListRequest`](/doc/models/v1-update-modifier-list-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1ModifierList>`](/doc/models/v1-modifier-list.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";
var body = new V1UpdateModifierListRequest.Builder()
    .Name("name6")
    .SelectionType("SINGLE")
    .Build();

try
{
    V1ModifierList result = await v1ItemsApi.UpdateModifierListAsync(locationId, modifierListId, body);
}
catch (ApiException e){};
```

## Create Modifier Option

Creates an item modifier option and adds it to a modifier list.

```csharp
CreateModifierOptionAsync(string locationId, string modifierListId, Models.V1ModifierOption body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The ID of the modifier list to edit. |
| `body` | [`Models.V1ModifierOption`](/doc/models/v1-modifier-option.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1ModifierOption>`](/doc/models/v1-modifier-option.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";
var bodyPriceMoney = new V1Money.Builder()
    .Amount(194)
    .CurrencyCode("XBA")
    .Build();
var body = new V1ModifierOption.Builder()
    .Id("id6")
    .Name("name6")
    .PriceMoney(bodyPriceMoney)
    .OnByDefault(false)
    .Ordinal(88)
    .Build();

try
{
    V1ModifierOption result = await v1ItemsApi.CreateModifierOptionAsync(locationId, modifierListId, body);
}
catch (ApiException e){};
```

## Delete Modifier Option

Deletes an existing item modifier option from a modifier list.


__DeleteModifierOption__ returns nothing on success but Connect
SDKs map the empty response to an empty `V1DeleteModifierOptionRequest`
object.

```csharp
DeleteModifierOptionAsync(string locationId, string modifierListId, string modifierOptionId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The ID of the modifier list to delete. |
| `modifierOptionId` | `string` | Template, Required | The ID of the modifier list to edit. |

### Response Type

[`Task<Models.V1ModifierOption>`](/doc/models/v1-modifier-option.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";
string modifierOptionId = "modifier_option_id6";

try
{
    V1ModifierOption result = await v1ItemsApi.DeleteModifierOptionAsync(locationId, modifierListId, modifierOptionId);
}
catch (ApiException e){};
```

## Update Modifier Option

Modifies the details of an existing item modifier option.

```csharp
UpdateModifierOptionAsync(
    string locationId,
    string modifierListId,
    string modifierOptionId,
    Models.V1ModifierOption body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the item's associated location. |
| `modifierListId` | `string` | Template, Required | The ID of the modifier list to edit. |
| `modifierOptionId` | `string` | Template, Required | The ID of the modifier list to edit. |
| `body` | [`Models.V1ModifierOption`](/doc/models/v1-modifier-option.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1ModifierOption>`](/doc/models/v1-modifier-option.md)

### Example Usage

```csharp
string locationId = "location_id4";
string modifierListId = "modifier_list_id6";
string modifierOptionId = "modifier_option_id6";
var bodyPriceMoney = new V1Money.Builder()
    .Amount(194)
    .CurrencyCode("XBA")
    .Build();
var body = new V1ModifierOption.Builder()
    .Id("id6")
    .Name("name6")
    .PriceMoney(bodyPriceMoney)
    .OnByDefault(false)
    .Ordinal(88)
    .Build();

try
{
    V1ModifierOption result = await v1ItemsApi.UpdateModifierOptionAsync(locationId, modifierListId, modifierOptionId, body);
}
catch (ApiException e){};
```

## List Pages

Lists all Favorites pages (in Square Point of Sale) for a given
location.

```csharp
ListPagesAsync(string locationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list Favorites pages for. |

### Response Type

[`Task<List<Models.V1Page>>`](/doc/models/v1-page.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    List<V1Page> result = await v1ItemsApi.ListPagesAsync(locationId);
}
catch (ApiException e){};
```

## Create Page

Creates a Favorites page in Square Point of Sale.

```csharp
CreatePageAsync(string locationId, Models.V1Page body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to create an item for. |
| `body` | [`Models.V1Page`](/doc/models/v1-page.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Page>`](/doc/models/v1-page.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyCells = new List<V1PageCell>();

var bodyCells0 = new V1PageCell.Builder()
    .PageId("page_id8")
    .Row(2)
    .Column(80)
    .ObjectType("ITEM")
    .ObjectId("object_id6")
    .Build();
bodyCells.Add(bodyCells0);

var body = new V1Page.Builder()
    .Id("id6")
    .Name("name6")
    .PageIndex(224)
    .Cells(bodyCells)
    .Build();

try
{
    V1Page result = await v1ItemsApi.CreatePageAsync(locationId, body);
}
catch (ApiException e){};
```

## Delete Page

Deletes an existing Favorites page and all of its cells.


__DeletePage__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeletePageRequest` object.

```csharp
DeletePageAsync(string locationId, string pageId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the Favorites page's associated location. |
| `pageId` | `string` | Template, Required | The ID of the page to delete. |

### Response Type

[`Task<Models.V1Page>`](/doc/models/v1-page.md)

### Example Usage

```csharp
string locationId = "location_id4";
string pageId = "page_id0";

try
{
    V1Page result = await v1ItemsApi.DeletePageAsync(locationId, pageId);
}
catch (ApiException e){};
```

## Update Page

Modifies the details of a Favorites page in Square Point of Sale.

```csharp
UpdatePageAsync(string locationId, string pageId, Models.V1Page body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the Favorites page's associated location |
| `pageId` | `string` | Template, Required | The ID of the page to modify. |
| `body` | [`Models.V1Page`](/doc/models/v1-page.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Page>`](/doc/models/v1-page.md)

### Example Usage

```csharp
string locationId = "location_id4";
string pageId = "page_id0";
var bodyCells = new List<V1PageCell>();

var bodyCells0 = new V1PageCell.Builder()
    .PageId("page_id8")
    .Row(2)
    .Column(80)
    .ObjectType("ITEM")
    .ObjectId("object_id6")
    .Build();
bodyCells.Add(bodyCells0);

var body = new V1Page.Builder()
    .Id("id6")
    .Name("name6")
    .PageIndex(224)
    .Cells(bodyCells)
    .Build();

try
{
    V1Page result = await v1ItemsApi.UpdatePageAsync(locationId, pageId, body);
}
catch (ApiException e){};
```

## Delete Page Cell

Deletes a cell from a Favorites page in Square Point of Sale.


__DeletePageCell__ returns nothing on success but Connect SDKs
map the empty response to an empty `V1DeletePageCellRequest` object
as documented below.

```csharp
DeletePageCellAsync(
    string locationId,
    string pageId,
    string row = null,
    string column = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the Favorites page's associated location. |
| `pageId` | `string` | Template, Required | The ID of the page to delete. |
| `row` | `string` | Query, Optional | The row of the cell to clear. Always an integer between 0 and 4, inclusive. Row 0 is the top row. |
| `column` | `string` | Query, Optional | The column of the cell to clear. Always an integer between 0 and 4, inclusive. Column 0 is the leftmost column. |

### Response Type

[`Task<Models.V1Page>`](/doc/models/v1-page.md)

### Example Usage

```csharp
string locationId = "location_id4";
string pageId = "page_id0";
string row = "row0";
string column = "column4";

try
{
    V1Page result = await v1ItemsApi.DeletePageCellAsync(locationId, pageId, row, column);
}
catch (ApiException e){};
```

## Update Page Cell

Modifies a cell of a Favorites page in Square Point of Sale.

```csharp
UpdatePageCellAsync(string locationId, string pageId, Models.V1PageCell body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the Favorites page's associated location. |
| `pageId` | `string` | Template, Required | The ID of the page the cell belongs to. |
| `body` | [`Models.V1PageCell`](/doc/models/v1-page-cell.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Page>`](/doc/models/v1-page.md)

### Example Usage

```csharp
string locationId = "location_id4";
string pageId = "page_id0";
var body = new V1PageCell.Builder()
    .PageId("page_id6")
    .Row(22)
    .Column(60)
    .ObjectType("ITEM")
    .ObjectId("object_id4")
    .Build();

try
{
    V1Page result = await v1ItemsApi.UpdatePageCellAsync(locationId, pageId, body);
}
catch (ApiException e){};
```

