# Customers

```csharp
ICustomersApi customersApi = client.CustomersApi;
```

## Class Name

`CustomersApi`

## Methods

* [List Customers](../../doc/api/customers.md#list-customers)
* [Create Customer](../../doc/api/customers.md#create-customer)
* [Bulk Create Customers](../../doc/api/customers.md#bulk-create-customers)
* [Bulk Delete Customers](../../doc/api/customers.md#bulk-delete-customers)
* [Bulk Retrieve Customers](../../doc/api/customers.md#bulk-retrieve-customers)
* [Bulk Update Customers](../../doc/api/customers.md#bulk-update-customers)
* [Search Customers](../../doc/api/customers.md#search-customers)
* [Delete Customer](../../doc/api/customers.md#delete-customer)
* [Retrieve Customer](../../doc/api/customers.md#retrieve-customer)
* [Update Customer](../../doc/api/customers.md#update-customer)
* [Create Customer Card](../../doc/api/customers.md#create-customer-card)
* [Delete Customer Card](../../doc/api/customers.md#delete-customer-card)
* [Remove Group From Customer](../../doc/api/customers.md#remove-group-from-customer)
* [Add Group to Customer](../../doc/api/customers.md#add-group-to-customer)


# List Customers

Lists customer profiles associated with a Square account.

Under normal operating conditions, newly created or updated customer profiles become available
for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated
profiles can take closer to one minute or longer, especially during network incidents and outages.

```csharp
ListCustomersAsync(
    string cursor = null,
    int? limit = null,
    string sortField = null,
    string sortOrder = null,
    bool? count = false)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for your original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.<br>If the specified limit is less than 1 or greater than 100, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 100.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `sortField` | [`string`](../../doc/models/customer-sort-field.md) | Query, Optional | Indicates how customers should be sorted.<br><br>The default value is `DEFAULT`. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | Indicates whether customers should be sorted in ascending (`ASC`) or<br>descending (`DESC`) order.<br><br>The default value is `ASC`. |
| `count` | `bool?` | Query, Optional | Indicates whether to return the total count of customers in the `count` field of the response.<br><br>The default value is `false`. |

## Response Type

[`Task<Models.ListCustomersResponse>`](../../doc/models/list-customers-response.md)

## Example Usage

```csharp
bool? count = false;
try
{
    ListCustomersResponse result = await customersApi.ListCustomersAsync(
        null,
        null,
        null,
        null,
        count
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Customer

Creates a new customer for a business.

You must provide at least one of the following values in your request to this
endpoint:

- `given_name`
- `family_name`
- `company_name`
- `email_address`
- `phone_number`

```csharp
CreateCustomerAsync(
    Models.CreateCustomerRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateCustomerRequest`](../../doc/models/create-customer-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateCustomerResponse>`](../../doc/models/create-customer-response.md)

## Example Usage

```csharp
Models.CreateCustomerRequest body = new Models.CreateCustomerRequest.Builder()
.GivenName("Amelia")
.FamilyName("Earhart")
.EmailAddress("Amelia.Earhart@example.com")
.Address(
    new Models.Address.Builder()
    .AddressLine1("500 Electric Ave")
    .AddressLine2("Suite 600")
    .Locality("New York")
    .AdministrativeDistrictLevel1("NY")
    .PostalCode("10003")
    .Country("US")
    .Build())
.PhoneNumber("+1-212-555-4240")
.ReferenceId("YOUR_REFERENCE_ID")
.Note("a customer")
.Build();

try
{
    CreateCustomerResponse result = await customersApi.CreateCustomerAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Create Customers

Creates multiple [customer profiles](../../doc/models/customer.md) for a business.

This endpoint takes a map of individual create requests and returns a map of responses.

You must provide at least one of the following values in each create request:

- `given_name`
- `family_name`
- `company_name`
- `email_address`
- `phone_number`

```csharp
BulkCreateCustomersAsync(
    Models.BulkCreateCustomersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkCreateCustomersRequest`](../../doc/models/bulk-create-customers-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkCreateCustomersResponse>`](../../doc/models/bulk-create-customers-response.md)

## Example Usage

```csharp
Models.BulkCreateCustomersRequest body = new Models.BulkCreateCustomersRequest.Builder(
    new Dictionary<string, Models.BulkCreateCustomerData>
    {
        ["8bb76c4f-e35d-4c5b-90de-1194cd9179f0"] = new Models.BulkCreateCustomerData.Builder()
        .GivenName("Amelia")
        .FamilyName("Earhart")
        .EmailAddress("Amelia.Earhart@example.com")
        .Address(
            new Models.Address.Builder()
            .AddressLine1("500 Electric Ave")
            .AddressLine2("Suite 600")
            .Locality("New York")
            .AdministrativeDistrictLevel1("NY")
            .PostalCode("10003")
            .Country("US")
            .Build())
        .PhoneNumber("+1-212-555-4240")
        .ReferenceId("YOUR_REFERENCE_ID")
        .Note("a customer")
        .Build(),
        ["d1689f23-b25d-4932-b2f0-aed00f5e2029"] = new Models.BulkCreateCustomerData.Builder()
        .GivenName("Marie")
        .FamilyName("Curie")
        .EmailAddress("Marie.Curie@example.com")
        .Address(
            new Models.Address.Builder()
            .AddressLine1("500 Electric Ave")
            .AddressLine2("Suite 601")
            .Locality("New York")
            .AdministrativeDistrictLevel1("NY")
            .PostalCode("10003")
            .Country("US")
            .Build())
        .PhoneNumber("+1-212-444-4240")
        .ReferenceId("YOUR_REFERENCE_ID")
        .Note("another customer")
        .Build(),
    }
)
.Build();

try
{
    BulkCreateCustomersResponse result = await customersApi.BulkCreateCustomersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Delete Customers

Deletes multiple customer profiles.

The endpoint takes a list of customer IDs and returns a map of responses.

```csharp
BulkDeleteCustomersAsync(
    Models.BulkDeleteCustomersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkDeleteCustomersRequest`](../../doc/models/bulk-delete-customers-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkDeleteCustomersResponse>`](../../doc/models/bulk-delete-customers-response.md)

## Example Usage

```csharp
Models.BulkDeleteCustomersRequest body = new Models.BulkDeleteCustomersRequest.Builder(
    new List<string>
    {
        "8DDA5NZVBZFGAX0V3HPF81HHE0",
        "N18CPRVXR5214XPBBA6BZQWF3C",
        "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
    }
)
.Build();

try
{
    BulkDeleteCustomersResponse result = await customersApi.BulkDeleteCustomersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Retrieve Customers

Retrieves multiple customer profiles.

This endpoint takes a list of customer IDs and returns a map of responses.

```csharp
BulkRetrieveCustomersAsync(
    Models.BulkRetrieveCustomersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkRetrieveCustomersRequest`](../../doc/models/bulk-retrieve-customers-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkRetrieveCustomersResponse>`](../../doc/models/bulk-retrieve-customers-response.md)

## Example Usage

```csharp
Models.BulkRetrieveCustomersRequest body = new Models.BulkRetrieveCustomersRequest.Builder(
    new List<string>
    {
        "8DDA5NZVBZFGAX0V3HPF81HHE0",
        "N18CPRVXR5214XPBBA6BZQWF3C",
        "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
    }
)
.Build();

try
{
    BulkRetrieveCustomersResponse result = await customersApi.BulkRetrieveCustomersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Update Customers

Updates multiple customer profiles.

This endpoint takes a map of individual update requests and returns a map of responses.

You cannot use this endpoint to change cards on file. To make changes, use the [Cards API](../../doc/api/cards.md) or [Gift Cards API](../../doc/api/gift-cards.md).

```csharp
BulkUpdateCustomersAsync(
    Models.BulkUpdateCustomersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkUpdateCustomersRequest`](../../doc/models/bulk-update-customers-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpdateCustomersResponse>`](../../doc/models/bulk-update-customers-response.md)

## Example Usage

```csharp
Models.BulkUpdateCustomersRequest body = new Models.BulkUpdateCustomersRequest.Builder(
    new Dictionary<string, Models.BulkUpdateCustomerData>
    {
        ["8DDA5NZVBZFGAX0V3HPF81HHE0"] = new Models.BulkUpdateCustomerData.Builder()
        .EmailAddress("New.Amelia.Earhart@example.com")
        .PhoneNumber("phone_number2")
        .Note("updated customer note")
        .Version(2L)
        .Build(),
        ["N18CPRVXR5214XPBBA6BZQWF3C"] = new Models.BulkUpdateCustomerData.Builder()
        .GivenName("Marie")
        .FamilyName("Curie")
        .Version(0L)
        .Build(),
    }
)
.Build();

try
{
    BulkUpdateCustomersResponse result = await customersApi.BulkUpdateCustomersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Search Customers

Searches the customer profiles associated with a Square account using one or more supported query filters.

Calling `SearchCustomers` without any explicit query filter returns all
customer profiles ordered alphabetically based on `given_name` and
`family_name`.

Under normal operating conditions, newly created or updated customer profiles become available
for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated
profiles can take closer to one minute or longer, especially during network incidents and outages.

```csharp
SearchCustomersAsync(
    Models.SearchCustomersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SearchCustomersRequest`](../../doc/models/search-customers-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchCustomersResponse>`](../../doc/models/search-customers-response.md)

## Example Usage

```csharp
Models.SearchCustomersRequest body = new Models.SearchCustomersRequest.Builder()
.Limit(2L)
.Query(
    new Models.CustomerQuery.Builder()
    .Filter(
        new Models.CustomerFilter.Builder()
        .CreationSource(
            new Models.CustomerCreationSourceFilter.Builder()
            .Values(
                new List<string>
                {
                    "THIRD_PARTY",
                })
            .Rule("INCLUDE")
            .Build())
        .CreatedAt(
            new Models.TimeRange.Builder()
            .StartAt("2018-01-01T00:00:00-00:00")
            .EndAt("2018-02-01T00:00:00-00:00")
            .Build())
        .EmailAddress(
            new Models.CustomerTextFilter.Builder()
            .Fuzzy("example.com")
            .Build())
        .GroupIds(
            new Models.FilterValue.Builder()
            .All(
                new List<string>
                {
                    "545AXB44B4XXWMVQ4W8SBT3HHF",
                })
            .Build())
        .Build())
    .Sort(
        new Models.CustomerSort.Builder()
        .Field("CREATED_AT")
        .Order("ASC")
        .Build())
    .Build())
.Build();

try
{
    SearchCustomersResponse result = await customersApi.SearchCustomersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete Customer

Deletes a customer profile from a business. This operation also unlinks any associated cards on file.

To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.

```csharp
DeleteCustomerAsync(
    string customerId,
    long? version = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to delete. |
| `version` | `long?` | Query, Optional | The current version of the customer profile.<br><br>As a best practice, you should include this parameter to enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control.  For more information, see [Delete a customer profile](https://developer.squareup.com/docs/customers-api/use-the-api/keep-records#delete-customer-profile). |

## Response Type

[`Task<Models.DeleteCustomerResponse>`](../../doc/models/delete-customer-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
try
{
    DeleteCustomerResponse result = await customersApi.DeleteCustomerAsync(customerId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Customer

Returns details for a single customer.

```csharp
RetrieveCustomerAsync(
    string customerId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to retrieve. |

## Response Type

[`Task<Models.RetrieveCustomerResponse>`](../../doc/models/retrieve-customer-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
try
{
    RetrieveCustomerResponse result = await customersApi.RetrieveCustomerAsync(customerId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Customer

Updates a customer profile. This endpoint supports sparse updates, so only new or changed fields are required in the request.
To add or update a field, specify the new value. To remove a field, specify `null`.

To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.

You cannot use this endpoint to change cards on file. To make changes, use the [Cards API](../../doc/api/cards.md) or [Gift Cards API](../../doc/api/gift-cards.md).

```csharp
UpdateCustomerAsync(
    string customerId,
    Models.UpdateCustomerRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to update. |
| `body` | [`UpdateCustomerRequest`](../../doc/models/update-customer-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateCustomerResponse>`](../../doc/models/update-customer-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
Models.UpdateCustomerRequest body = new Models.UpdateCustomerRequest.Builder()
.EmailAddress("New.Amelia.Earhart@example.com")
.PhoneNumber("phone_number2")
.Note("updated customer note")
.Version(2L)
.Build();

try
{
    UpdateCustomerResponse result = await customersApi.UpdateCustomerAsync(
        customerId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Customer Card

**This endpoint is deprecated.**

Adds a card on file to an existing customer.

As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
calls with the same card nonce return the same card record that was created
with the provided nonce during the _first_ call.

```csharp
CreateCustomerCardAsync(
    string customerId,
    Models.CreateCustomerCardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The Square ID of the customer profile the card is linked to. |
| `body` | [`CreateCustomerCardRequest`](../../doc/models/create-customer-card-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateCustomerCardResponse>`](../../doc/models/create-customer-card-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
Models.CreateCustomerCardRequest body = new Models.CreateCustomerCardRequest.Builder(
    "YOUR_CARD_NONCE"
)
.BillingAddress(
    new Models.Address.Builder()
    .AddressLine1("500 Electric Ave")
    .AddressLine2("Suite 600")
    .Locality("New York")
    .AdministrativeDistrictLevel1("NY")
    .PostalCode("10003")
    .Country("US")
    .Build())
.CardholderName("Amelia Earhart")
.Build();

try
{
    CreateCustomerCardResponse result = await customersApi.CreateCustomerCardAsync(
        customerId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete Customer Card

**This endpoint is deprecated.**

Removes a card on file from a customer.

```csharp
DeleteCustomerCardAsync(
    string customerId,
    string cardId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer that the card on file belongs to. |
| `cardId` | `string` | Template, Required | The ID of the card on file to delete. |

## Response Type

[`Task<Models.DeleteCustomerCardResponse>`](../../doc/models/delete-customer-card-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
string cardId = "card_id4";
try
{
    DeleteCustomerCardResponse result = await customersApi.DeleteCustomerCardAsync(
        customerId,
        cardId
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Remove Group From Customer

Removes a group membership from a customer.

The customer is identified by the `customer_id` value
and the customer group is identified by the `group_id` value.

```csharp
RemoveGroupFromCustomerAsync(
    string customerId,
    string groupId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to remove from the group. |
| `groupId` | `string` | Template, Required | The ID of the customer group to remove the customer from. |

## Response Type

[`Task<Models.RemoveGroupFromCustomerResponse>`](../../doc/models/remove-group-from-customer-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
string groupId = "group_id0";
try
{
    RemoveGroupFromCustomerResponse result = await customersApi.RemoveGroupFromCustomerAsync(
        customerId,
        groupId
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Add Group to Customer

Adds a group membership to a customer.

The customer is identified by the `customer_id` value
and the customer group is identified by the `group_id` value.

```csharp
AddGroupToCustomerAsync(
    string customerId,
    string groupId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to add to a group. |
| `groupId` | `string` | Template, Required | The ID of the customer group to add the customer to. |

## Response Type

[`Task<Models.AddGroupToCustomerResponse>`](../../doc/models/add-group-to-customer-response.md)

## Example Usage

```csharp
string customerId = "customer_id8";
string groupId = "group_id0";
try
{
    AddGroupToCustomerResponse result = await customersApi.AddGroupToCustomerAsync(
        customerId,
        groupId
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

