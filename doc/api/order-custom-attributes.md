# Order Custom Attributes

```csharp
IOrderCustomAttributesApi orderCustomAttributesApi = client.OrderCustomAttributesApi;
```

## Class Name

`OrderCustomAttributesApi`

## Methods

* [List Order Custom Attribute Definitions](../../doc/api/order-custom-attributes.md#list-order-custom-attribute-definitions)
* [Create Order Custom Attribute Definition](../../doc/api/order-custom-attributes.md#create-order-custom-attribute-definition)
* [Delete Order Custom Attribute Definition](../../doc/api/order-custom-attributes.md#delete-order-custom-attribute-definition)
* [Retrieve Order Custom Attribute Definition](../../doc/api/order-custom-attributes.md#retrieve-order-custom-attribute-definition)
* [Update Order Custom Attribute Definition](../../doc/api/order-custom-attributes.md#update-order-custom-attribute-definition)
* [Bulk Delete Order Custom Attributes](../../doc/api/order-custom-attributes.md#bulk-delete-order-custom-attributes)
* [Bulk Upsert Order Custom Attributes](../../doc/api/order-custom-attributes.md#bulk-upsert-order-custom-attributes)
* [List Order Custom Attributes](../../doc/api/order-custom-attributes.md#list-order-custom-attributes)
* [Delete Order Custom Attribute](../../doc/api/order-custom-attributes.md#delete-order-custom-attribute)
* [Retrieve Order Custom Attribute](../../doc/api/order-custom-attributes.md#retrieve-order-custom-attribute)
* [Upsert Order Custom Attribute](../../doc/api/order-custom-attributes.md#upsert-order-custom-attribute)


# List Order Custom Attribute Definitions

Lists the order-related [custom attribute definitions](../../doc/models/custom-attribute-definition.md) that belong to a Square seller account.

When all response pages are retrieved, the results include all custom attribute definitions
that are visible to the requesting application, including those that are created by other
applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
ListOrderCustomAttributeDefinitionsAsync(
    string visibilityFilter = null,
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `visibilityFilter` | [`string`](../../doc/models/visibility-filter.md) | Query, Optional | Requests that all of the custom attributes be returned, or only those that are read-only or read-write. |
| `cursor` | `string` | Query, Optional | The cursor returned in the paged response from the previous call to this endpoint.<br>Provide this cursor to retrieve the next page of results for your original request.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single paged response. This limit is advisory.<br>The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.<br>The default value is 20.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |

## Response Type

[`Task<Models.ListOrderCustomAttributeDefinitionsResponse>`](../../doc/models/list-order-custom-attribute-definitions-response.md)

## Example Usage

```csharp
try
{
    ListOrderCustomAttributeDefinitionsResponse result = await orderCustomAttributesApi.ListOrderCustomAttributeDefinitionsAsync(null, null, null);
}
catch (ApiException e){};
```


# Create Order Custom Attribute Definition

Creates an order-related custom attribute definition.  Use this endpoint to
define a custom attribute that can be associated with orders.

After creating a custom attribute definition, you can set the custom attribute for orders
in the Square seller account.

```csharp
CreateOrderCustomAttributeDefinitionAsync(
    Models.CreateOrderCustomAttributeDefinitionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateOrderCustomAttributeDefinitionRequest`](../../doc/models/create-order-custom-attribute-definition-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateOrderCustomAttributeDefinitionResponse>`](../../doc/models/create-order-custom-attribute-definition-response.md)

## Example Usage

```csharp
var bodyCustomAttributeDefinition = new CustomAttributeDefinition.Builder()
    .Key("cover-count")
    .Name("Cover count")
    .Description("The number of people seated at a table")
    .Visibility("VISIBILITY_READ_WRITE_VALUES")
    .Build();
var body = new CreateOrderCustomAttributeDefinitionRequest.Builder(
        bodyCustomAttributeDefinition)
    .IdempotencyKey("IDEMPOTENCY_KEY")
    .Build();

try
{
    CreateOrderCustomAttributeDefinitionResponse result = await orderCustomAttributesApi.CreateOrderCustomAttributeDefinitionAsync(body);
}
catch (ApiException e){};
```


# Delete Order Custom Attribute Definition

Deletes an order-related [custom attribute definition](../../doc/models/custom-attribute-definition.md) from a Square seller account.

Only the definition owner can delete a custom attribute definition.

```csharp
DeleteOrderCustomAttributeDefinitionAsync(
    string key)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to delete. |

## Response Type

[`Task<Models.DeleteOrderCustomAttributeDefinitionResponse>`](../../doc/models/delete-order-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";

try
{
    DeleteOrderCustomAttributeDefinitionResponse result = await orderCustomAttributesApi.DeleteOrderCustomAttributeDefinitionAsync(key);
}
catch (ApiException e){};
```


# Retrieve Order Custom Attribute Definition

Retrieves an order-related [custom attribute definition](../../doc/models/custom-attribute-definition.md) from a Square seller account.

To retrieve a custom attribute definition created by another application, the `visibility`
setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
RetrieveOrderCustomAttributeDefinitionAsync(
    string key,
    int? version = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to retrieve. |
| `version` | `int?` | Query, Optional | To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)<br>control, include this optional field and specify the current version of the custom attribute. |

## Response Type

[`Task<Models.RetrieveOrderCustomAttributeDefinitionResponse>`](../../doc/models/retrieve-order-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";

try
{
    RetrieveOrderCustomAttributeDefinitionResponse result = await orderCustomAttributesApi.RetrieveOrderCustomAttributeDefinitionAsync(key, null);
}
catch (ApiException e){};
```


# Update Order Custom Attribute Definition

Updates an order-related custom attribute definition for a Square seller account.

Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.

```csharp
UpdateOrderCustomAttributeDefinitionAsync(
    string key,
    Models.UpdateOrderCustomAttributeDefinitionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to update. |
| `body` | [`Models.UpdateOrderCustomAttributeDefinitionRequest`](../../doc/models/update-order-custom-attribute-definition-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateOrderCustomAttributeDefinitionResponse>`](../../doc/models/update-order-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";
var bodyCustomAttributeDefinition = new CustomAttributeDefinition.Builder()
    .Key("cover-count")
    .Visibility("VISIBILITY_READ_ONLY")
    .Version(1)
    .Build();
var body = new UpdateOrderCustomAttributeDefinitionRequest.Builder(
        bodyCustomAttributeDefinition)
    .IdempotencyKey("IDEMPOTENCY_KEY")
    .Build();

try
{
    UpdateOrderCustomAttributeDefinitionResponse result = await orderCustomAttributesApi.UpdateOrderCustomAttributeDefinitionAsync(key, body);
}
catch (ApiException e){};
```


# Bulk Delete Order Custom Attributes

Deletes order [custom attributes](../../doc/models/custom-attribute.md) as a bulk operation.

Use this endpoint to delete one or more custom attributes from one or more orders.
A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
custom attribute definition, use the [CreateOrderCustomAttributeDefinition](../../doc/api/order-custom-attributes.md#create-order-custom-attribute-definition) endpoint.)

This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete
requests and returns a map of individual delete responses. Each delete request has a unique ID
and provides an order ID and custom attribute. Each delete response is returned with the ID
of the corresponding request.

To delete a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
BulkDeleteOrderCustomAttributesAsync(
    Models.BulkDeleteOrderCustomAttributesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkDeleteOrderCustomAttributesRequest`](../../doc/models/bulk-delete-order-custom-attributes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkDeleteOrderCustomAttributesResponse>`](../../doc/models/bulk-delete-order-custom-attributes-response.md)

## Example Usage

```csharp
var bodyValues = new Dictionary<string, BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute>();


var bodyValues0 = new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute.Builder(
        null)
    .Build();
bodyValues.Add("",bodyValues0);

var bodyValues1 = new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute.Builder(
        null)
    .Build();
bodyValues.Add("",bodyValues1);

var body = new BulkDeleteOrderCustomAttributesRequest.Builder(
        bodyValues)
    .Build();

try
{
    BulkDeleteOrderCustomAttributesResponse result = await orderCustomAttributesApi.BulkDeleteOrderCustomAttributesAsync(body);
}
catch (ApiException e){};
```


# Bulk Upsert Order Custom Attributes

Creates or updates order [custom attributes](../../doc/models/custom-attribute.md) as a bulk operation.

Use this endpoint to delete one or more custom attributes from one or more orders.
A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
custom attribute definition, use the [CreateOrderCustomAttributeDefinition](../../doc/api/order-custom-attributes.md#create-order-custom-attribute-definition) endpoint.)

This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
requests and returns a map of individual upsert responses. Each upsert request has a unique ID
and provides an order ID and custom attribute. Each upsert response is returned with the ID
of the corresponding request.

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
BulkUpsertOrderCustomAttributesAsync(
    Models.BulkUpsertOrderCustomAttributesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkUpsertOrderCustomAttributesRequest`](../../doc/models/bulk-upsert-order-custom-attributes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpsertOrderCustomAttributesResponse>`](../../doc/models/bulk-upsert-order-custom-attributes-response.md)

## Example Usage

```csharp
var bodyValues = new Dictionary<string, BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute>();


var bodyValues0CustomAttribute = new CustomAttribute.Builder()
    .Build();
var bodyValues0 = new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute.Builder(
        bodyValues0CustomAttribute,
        null)
    .Build();
bodyValues.Add("",bodyValues0);

var bodyValues1CustomAttribute = new CustomAttribute.Builder()
    .Build();
var bodyValues1 = new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute.Builder(
        bodyValues1CustomAttribute,
        null)
    .Build();
bodyValues.Add("",bodyValues1);

var body = new BulkUpsertOrderCustomAttributesRequest.Builder(
        bodyValues)
    .Build();

try
{
    BulkUpsertOrderCustomAttributesResponse result = await orderCustomAttributesApi.BulkUpsertOrderCustomAttributesAsync(body);
}
catch (ApiException e){};
```


# List Order Custom Attributes

Lists the [custom attributes](../../doc/models/custom-attribute.md) associated with an order.

You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
in the same call.

When all response pages are retrieved, the results include all custom attributes that are
visible to the requesting application, including those that are owned by other applications
and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.

```csharp
ListOrderCustomAttributesAsync(
    string orderId,
    string visibilityFilter = null,
    string cursor = null,
    int? limit = null,
    bool? withDefinitions = false)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the target [order](../../doc/models/order.md). |
| `visibilityFilter` | [`string`](../../doc/models/visibility-filter.md) | Query, Optional | Requests that all of the custom attributes be returned, or only those that are read-only or read-write. |
| `cursor` | `string` | Query, Optional | The cursor returned in the paged response from the previous call to this endpoint.<br>Provide this cursor to retrieve the next page of results for your original request.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single paged response. This limit is advisory.<br>The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.<br>The default value is 20.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `withDefinitions` | `bool?` | Query, Optional | Indicates whether to return the [custom attribute definition](../../doc/models/custom-attribute-definition.md) in the `definition` field of each<br>custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,<br>information about the data type, or other definition details. The default value is `false`.<br>**Default**: `false` |

## Response Type

[`Task<Models.ListOrderCustomAttributesResponse>`](../../doc/models/list-order-custom-attributes-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
bool? withDefinitions = false;

try
{
    ListOrderCustomAttributesResponse result = await orderCustomAttributesApi.ListOrderCustomAttributesAsync(orderId, null, null, null, withDefinitions);
}
catch (ApiException e){};
```


# Delete Order Custom Attribute

Deletes a [custom attribute](../../doc/models/custom-attribute.md) associated with a customer profile.

To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
DeleteOrderCustomAttributeAsync(
    string orderId,
    string customAttributeKey)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the target [order](../../doc/models/order.md). |
| `customAttributeKey` | `string` | Template, Required | The key of the custom attribute to delete.  This key must match the key of an<br>existing custom attribute definition. |

## Response Type

[`Task<Models.DeleteOrderCustomAttributeResponse>`](../../doc/models/delete-order-custom-attribute-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
string customAttributeKey = "custom_attribute_key2";

try
{
    DeleteOrderCustomAttributeResponse result = await orderCustomAttributesApi.DeleteOrderCustomAttributeAsync(orderId, customAttributeKey);
}
catch (ApiException e){};
```


# Retrieve Order Custom Attribute

Retrieves a [custom attribute](../../doc/models/custom-attribute.md) associated with an order.

You can use the `with_definition` query parameter to also retrieve the custom attribute definition
in the same call.

To retrieve a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
RetrieveOrderCustomAttributeAsync(
    string orderId,
    string customAttributeKey,
    int? version = null,
    bool? withDefinition = false)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the target [order](../../doc/models/order.md). |
| `customAttributeKey` | `string` | Template, Required | The key of the custom attribute to retrieve.  This key must match the key of an<br>existing custom attribute definition. |
| `version` | `int?` | Query, Optional | To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)<br>control, include this optional field and specify the current version of the custom attribute. |
| `withDefinition` | `bool?` | Query, Optional | Indicates whether to return the [custom attribute definition](../../doc/models/custom-attribute-definition.md) in the `definition` field of each<br>custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,<br>information about the data type, or other definition details. The default value is `false`.<br>**Default**: `false` |

## Response Type

[`Task<Models.RetrieveOrderCustomAttributeResponse>`](../../doc/models/retrieve-order-custom-attribute-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
string customAttributeKey = "custom_attribute_key2";
bool? withDefinition = false;

try
{
    RetrieveOrderCustomAttributeResponse result = await orderCustomAttributesApi.RetrieveOrderCustomAttributeAsync(orderId, customAttributeKey, null, withDefinition);
}
catch (ApiException e){};
```


# Upsert Order Custom Attribute

Creates or updates a [custom attribute](../../doc/models/custom-attribute.md) for an order.

Use this endpoint to set the value of a custom attribute for a specific order.
A custom attribute is based on a custom attribute definition in a Square seller account. (To create a
custom attribute definition, use the [CreateOrderCustomAttributeDefinition](../../doc/api/order-custom-attributes.md#create-order-custom-attribute-definition) endpoint.)

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
UpsertOrderCustomAttributeAsync(
    string orderId,
    string customAttributeKey,
    Models.UpsertOrderCustomAttributeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `string` | Template, Required | The ID of the target [order](../../doc/models/order.md). |
| `customAttributeKey` | `string` | Template, Required | The key of the custom attribute to create or update.  This key must match the key<br>of an existing custom attribute definition. |
| `body` | [`Models.UpsertOrderCustomAttributeRequest`](../../doc/models/upsert-order-custom-attribute-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpsertOrderCustomAttributeResponse>`](../../doc/models/upsert-order-custom-attribute-response.md)

## Example Usage

```csharp
string orderId = "order_id6";
string customAttributeKey = "custom_attribute_key2";
var bodyCustomAttribute = new CustomAttribute.Builder()
    .Build();
var body = new UpsertOrderCustomAttributeRequest.Builder(
        bodyCustomAttribute)
    .Build();

try
{
    UpsertOrderCustomAttributeResponse result = await orderCustomAttributesApi.UpsertOrderCustomAttributeAsync(orderId, customAttributeKey, body);
}
catch (ApiException e){};
```

