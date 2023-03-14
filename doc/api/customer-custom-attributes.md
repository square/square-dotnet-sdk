# Customer Custom Attributes

```csharp
ICustomerCustomAttributesApi customerCustomAttributesApi = client.CustomerCustomAttributesApi;
```

## Class Name

`CustomerCustomAttributesApi`

## Methods

* [List Customer Custom Attribute Definitions](../../doc/api/customer-custom-attributes.md#list-customer-custom-attribute-definitions)
* [Create Customer Custom Attribute Definition](../../doc/api/customer-custom-attributes.md#create-customer-custom-attribute-definition)
* [Delete Customer Custom Attribute Definition](../../doc/api/customer-custom-attributes.md#delete-customer-custom-attribute-definition)
* [Retrieve Customer Custom Attribute Definition](../../doc/api/customer-custom-attributes.md#retrieve-customer-custom-attribute-definition)
* [Update Customer Custom Attribute Definition](../../doc/api/customer-custom-attributes.md#update-customer-custom-attribute-definition)
* [Bulk Upsert Customer Custom Attributes](../../doc/api/customer-custom-attributes.md#bulk-upsert-customer-custom-attributes)
* [List Customer Custom Attributes](../../doc/api/customer-custom-attributes.md#list-customer-custom-attributes)
* [Delete Customer Custom Attribute](../../doc/api/customer-custom-attributes.md#delete-customer-custom-attribute)
* [Retrieve Customer Custom Attribute](../../doc/api/customer-custom-attributes.md#retrieve-customer-custom-attribute)
* [Upsert Customer Custom Attribute](../../doc/api/customer-custom-attributes.md#upsert-customer-custom-attribute)


# List Customer Custom Attribute Definitions

Lists the customer-related [custom attribute definitions](../../doc/models/custom-attribute-definition.md) that belong to a Square seller account.

When all response pages are retrieved, the results include all custom attribute definitions
that are visible to the requesting application, including those that are created by other
applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
ListCustomerCustomAttributeDefinitionsAsync(
    int? limit = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single paged response. This limit is advisory.<br>The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.<br>The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `cursor` | `string` | Query, Optional | The cursor returned in the paged response from the previous call to this endpoint.<br>Provide this cursor to retrieve the next page of results for your original request.<br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Response Type

[`Task<Models.ListCustomerCustomAttributeDefinitionsResponse>`](../../doc/models/list-customer-custom-attribute-definitions-response.md)

## Example Usage

```csharp
try
{
    ListCustomerCustomAttributeDefinitionsResponse result = await customerCustomAttributesApi.ListCustomerCustomAttributeDefinitionsAsync(null, null);
}
catch (ApiException e){};
```


# Create Customer Custom Attribute Definition

Creates a customer-related [custom attribute definition](../../doc/models/custom-attribute-definition.md) for a Square seller account.
Use this endpoint to define a custom attribute that can be associated with customer profiles.

A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
for a custom attribute. After the definition is created, you can call
[UpsertCustomerCustomAttribute](../../doc/api/customer-custom-attributes.md#upsert-customer-custom-attribute) or
[BulkUpsertCustomerCustomAttributes](../../doc/api/customer-custom-attributes.md#bulk-upsert-customer-custom-attributes)
to set the custom attribute for customer profiles in the seller's Customer Directory.

Sellers can view all custom attributes in exported customer data, including those set to
`VISIBILITY_HIDDEN`.

```csharp
CreateCustomerCustomAttributeDefinitionAsync(
    Models.CreateCustomerCustomAttributeDefinitionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateCustomerCustomAttributeDefinitionRequest`](../../doc/models/create-customer-custom-attribute-definition-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateCustomerCustomAttributeDefinitionResponse>`](../../doc/models/create-customer-custom-attribute-definition-response.md)

## Example Usage

```csharp
var bodyCustomAttributeDefinition = new CustomAttributeDefinition.Builder()
    .Key("favoritemovie")
    .Name("Favorite Movie")
    .Description("The favorite movie of the customer.")
    .Visibility("VISIBILITY_HIDDEN")
    .Build();
var body = new CreateCustomerCustomAttributeDefinitionRequest.Builder(
        bodyCustomAttributeDefinition)
    .Build();

try
{
    CreateCustomerCustomAttributeDefinitionResponse result = await customerCustomAttributesApi.CreateCustomerCustomAttributeDefinitionAsync(body);
}
catch (ApiException e){};
```


# Delete Customer Custom Attribute Definition

Deletes a customer-related [custom attribute definition](../../doc/models/custom-attribute-definition.md) from a Square seller account.

Deleting a custom attribute definition also deletes the corresponding custom attribute from
all customer profiles in the seller's Customer Directory.

Only the definition owner can delete a custom attribute definition.

```csharp
DeleteCustomerCustomAttributeDefinitionAsync(
    string key)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to delete. |

## Response Type

[`Task<Models.DeleteCustomerCustomAttributeDefinitionResponse>`](../../doc/models/delete-customer-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";

try
{
    DeleteCustomerCustomAttributeDefinitionResponse result = await customerCustomAttributesApi.DeleteCustomerCustomAttributeDefinitionAsync(key);
}
catch (ApiException e){};
```


# Retrieve Customer Custom Attribute Definition

Retrieves a customer-related [custom attribute definition](../../doc/models/custom-attribute-definition.md) from a Square seller account.

To retrieve a custom attribute definition created by another application, the `visibility`
setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
RetrieveCustomerCustomAttributeDefinitionAsync(
    string key,
    int? version = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to retrieve. If the requesting application<br>is not the definition owner, you must use the qualified key. |
| `version` | `int?` | Query, Optional | The current version of the custom attribute definition, which is used for strongly consistent<br>reads to guarantee that you receive the most up-to-date data. When included in the request,<br>Square returns the specified version or a higher version if one exists. If the specified version<br>is higher than the current version, Square returns a `BAD_REQUEST` error. |

## Response Type

[`Task<Models.RetrieveCustomerCustomAttributeDefinitionResponse>`](../../doc/models/retrieve-customer-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";

try
{
    RetrieveCustomerCustomAttributeDefinitionResponse result = await customerCustomAttributesApi.RetrieveCustomerCustomAttributeDefinitionAsync(key, null);
}
catch (ApiException e){};
```


# Update Customer Custom Attribute Definition

Updates a customer-related [custom attribute definition](../../doc/models/custom-attribute-definition.md) for a Square seller account.

Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
`schema` for a `Selection` data type.

Only the definition owner can update a custom attribute definition. Note that sellers can view
all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.

```csharp
UpdateCustomerCustomAttributeDefinitionAsync(
    string key,
    Models.UpdateCustomerCustomAttributeDefinitionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `key` | `string` | Template, Required | The key of the custom attribute definition to update. |
| `body` | [`Models.UpdateCustomerCustomAttributeDefinitionRequest`](../../doc/models/update-customer-custom-attribute-definition-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateCustomerCustomAttributeDefinitionResponse>`](../../doc/models/update-customer-custom-attribute-definition-response.md)

## Example Usage

```csharp
string key = "key0";
var bodyCustomAttributeDefinition = new CustomAttributeDefinition.Builder()
    .Description("Update the description as desired.")
    .Visibility("VISIBILITY_READ_ONLY")
    .Build();
var body = new UpdateCustomerCustomAttributeDefinitionRequest.Builder(
        bodyCustomAttributeDefinition)
    .Build();

try
{
    UpdateCustomerCustomAttributeDefinitionResponse result = await customerCustomAttributesApi.UpdateCustomerCustomAttributeDefinitionAsync(key, body);
}
catch (ApiException e){};
```


# Bulk Upsert Customer Custom Attributes

Creates or updates [custom attributes](../../doc/models/custom-attribute.md) for customer profiles as a bulk operation.

Use this endpoint to set the value of one or more custom attributes for one or more customer profiles.
A custom attribute is based on a custom attribute definition in a Square seller account, which is
created using the [CreateCustomerCustomAttributeDefinition](../../doc/api/customer-custom-attributes.md#create-customer-custom-attribute-definition) endpoint.

This `BulkUpsertCustomerCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
requests and returns a map of individual upsert responses. Each upsert request has a unique ID
and provides a customer ID and custom attribute. Each upsert response is returned with the ID
of the corresponding request.

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
BulkUpsertCustomerCustomAttributesAsync(
    Models.BulkUpsertCustomerCustomAttributesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.BulkUpsertCustomerCustomAttributesRequest`](../../doc/models/bulk-upsert-customer-custom-attributes-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpsertCustomerCustomAttributesResponse>`](../../doc/models/bulk-upsert-customer-custom-attributes-response.md)

## Example Usage

```csharp
var bodyValues = new Dictionary<string, BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest>();


var bodyValues0CustomAttribute = new CustomAttribute.Builder()
    .Build();
var bodyValues0 = new BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest.Builder(
        "customer_id2",
        bodyValues0CustomAttribute)
    .Build();
bodyValues.Add("key0",bodyValues0);

var bodyValues1CustomAttribute = new CustomAttribute.Builder()
    .Build();
var bodyValues1 = new BulkUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest.Builder(
        "customer_id3",
        bodyValues1CustomAttribute)
    .Build();
bodyValues.Add("key1",bodyValues1);

var body = new BulkUpsertCustomerCustomAttributesRequest.Builder(
        bodyValues)
    .Build();

try
{
    BulkUpsertCustomerCustomAttributesResponse result = await customerCustomAttributesApi.BulkUpsertCustomerCustomAttributesAsync(body);
}
catch (ApiException e){};
```


# List Customer Custom Attributes

Lists the [custom attributes](../../doc/models/custom-attribute.md) associated with a customer profile.

You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
in the same call.

When all response pages are retrieved, the results include all custom attributes that are
visible to the requesting application, including those that are owned by other applications
and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.

```csharp
ListCustomerCustomAttributesAsync(
    string customerId,
    int? limit = null,
    string cursor = null,
    bool? withDefinitions = false)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the target [customer profile](../../doc/models/customer.md). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single paged response. This limit is advisory.<br>The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.<br>The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `cursor` | `string` | Query, Optional | The cursor returned in the paged response from the previous call to this endpoint.<br>Provide this cursor to retrieve the next page of results for your original request. For more<br>information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `withDefinitions` | `bool?` | Query, Optional | Indicates whether to return the [custom attribute definition](../../doc/models/custom-attribute-definition.md) in the `definition` field of each<br>custom attribute. Set this parameter to `true` to get the name and description of each custom<br>attribute, information about the data type, or other definition details. The default value is `false`.<br>**Default**: `false` |

## Response Type

[`Task<Models.ListCustomerCustomAttributesResponse>`](../../doc/models/list-customer-custom-attributes-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
bool? withDefinitions = false;

try
{
    ListCustomerCustomAttributesResponse result = await customerCustomAttributesApi.ListCustomerCustomAttributesAsync(customerId, null, null, withDefinitions);
}
catch (ApiException e){};
```


# Delete Customer Custom Attribute

Deletes a [custom attribute](../../doc/models/custom-attribute.md) associated with a customer profile.

To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
DeleteCustomerCustomAttributeAsync(
    string customerId,
    string key)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the target [customer profile](../../doc/models/customer.md). |
| `key` | `string` | Template, Required | The key of the custom attribute to delete. This key must match the `key` of a custom<br>attribute definition in the Square seller account. If the requesting application is not the<br>definition owner, you must use the qualified key. |

## Response Type

[`Task<Models.DeleteCustomerCustomAttributeResponse>`](../../doc/models/delete-customer-custom-attribute-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
string key = "key0";

try
{
    DeleteCustomerCustomAttributeResponse result = await customerCustomAttributesApi.DeleteCustomerCustomAttributeAsync(customerId, key);
}
catch (ApiException e){};
```


# Retrieve Customer Custom Attribute

Retrieves a [custom attribute](../../doc/models/custom-attribute.md) associated with a customer profile.

You can use the `with_definition` query parameter to also retrieve the custom attribute definition
in the same call.

To retrieve a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
RetrieveCustomerCustomAttributeAsync(
    string customerId,
    string key,
    bool? withDefinition = false,
    int? version = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the target [customer profile](../../doc/models/customer.md). |
| `key` | `string` | Template, Required | The key of the custom attribute to retrieve. This key must match the `key` of a custom<br>attribute definition in the Square seller account. If the requesting application is not the<br>definition owner, you must use the qualified key. |
| `withDefinition` | `bool?` | Query, Optional | Indicates whether to return the [custom attribute definition](../../doc/models/custom-attribute-definition.md) in the `definition` field of<br>the custom attribute. Set this parameter to `true` to get the name and description of the custom<br>attribute, information about the data type, or other definition details. The default value is `false`.<br>**Default**: `false` |
| `version` | `int?` | Query, Optional | The current version of the custom attribute, which is used for strongly consistent reads to<br>guarantee that you receive the most up-to-date data. When included in the request, Square<br>returns the specified version or a higher version if one exists. If the specified version is<br>higher than the current version, Square returns a `BAD_REQUEST` error. |

## Response Type

[`Task<Models.RetrieveCustomerCustomAttributeResponse>`](../../doc/models/retrieve-customer-custom-attribute-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
string key = "key0";
bool? withDefinition = false;

try
{
    RetrieveCustomerCustomAttributeResponse result = await customerCustomAttributesApi.RetrieveCustomerCustomAttributeAsync(customerId, key, withDefinition, null);
}
catch (ApiException e){};
```


# Upsert Customer Custom Attribute

Creates or updates a [custom attribute](../../doc/models/custom-attribute.md) for a customer profile.

Use this endpoint to set the value of a custom attribute for a specified customer profile.
A custom attribute is based on a custom attribute definition in a Square seller account, which
is created using the [CreateCustomerCustomAttributeDefinition](../../doc/api/customer-custom-attributes.md#create-customer-custom-attribute-definition) endpoint.

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.

```csharp
UpsertCustomerCustomAttributeAsync(
    string customerId,
    string key,
    Models.UpsertCustomerCustomAttributeRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the target [customer profile](../../doc/models/customer.md). |
| `key` | `string` | Template, Required | The key of the custom attribute to create or update. This key must match the `key` of a<br>custom attribute definition in the Square seller account. If the requesting application is not<br>the definition owner, you must use the qualified key. |
| `body` | [`Models.UpsertCustomerCustomAttributeRequest`](../../doc/models/upsert-customer-custom-attribute-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpsertCustomerCustomAttributeResponse>`](../../doc/models/upsert-customer-custom-attribute-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
string key = "key0";
var bodyCustomAttribute = new CustomAttribute.Builder()
    .Build();
var body = new UpsertCustomerCustomAttributeRequest.Builder(
        bodyCustomAttribute)
    .Build();

try
{
    UpsertCustomerCustomAttributeResponse result = await customerCustomAttributesApi.UpsertCustomerCustomAttributeAsync(customerId, key, body);
}
catch (ApiException e){};
```

