# Customers

```csharp
ICustomersApi customersApi = client.CustomersApi;
```

## Class Name

`CustomersApi`

## Methods

* [List Customers](/doc/customers.md#list-customers)
* [Create Customer](/doc/customers.md#create-customer)
* [Search Customers](/doc/customers.md#search-customers)
* [Delete Customer](/doc/customers.md#delete-customer)
* [Retrieve Customer](/doc/customers.md#retrieve-customer)
* [Update Customer](/doc/customers.md#update-customer)
* [Create Customer Card](/doc/customers.md#create-customer-card)
* [Delete Customer Card](/doc/customers.md#delete-customer-card)

## List Customers

Lists a business's customers.

```csharp
ListCustomersAsync(string cursor = null, string sortField = null, string sortOrder = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See the [Pagination guide](https://developer.squareup.com/docs/working-with-apis/pagination) for more information. |
| `sortField` | [`string`](/doc/models/customer-sort-field.md) | Query, Optional | Indicates how Customers should be sorted.<br><br>Default: `DEFAULT`. |
| `sortOrder` | [`string`](/doc/models/sort-order.md) | Query, Optional | Indicates whether Customers should be sorted in ascending (`ASC`) or<br>descending (`DESC`) order.<br><br>Default: `ASC`. |

### Response Type

[`Task<Models.ListCustomersResponse>`](/doc/models/list-customers-response.md)

### Example Usage

```csharp
try
{
    ListCustomersResponse result = customersApi.ListCustomersAsync(null, null, null).Result;
}
catch (ApiException e){};
```

## Create Customer

Creates a new customer for a business, which can have associated cards on file.

You must provide __at least one__ of the following values in your request to this
endpoint:

- `given_name`
- `family_name`
- `company_name`
- `email_address`
- `phone_number`

```csharp
CreateCustomerAsync(Models.CreateCustomerRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateCustomerRequest`](/doc/models/create-customer-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateCustomerResponse>`](/doc/models/create-customer-response.md)

### Example Usage

```csharp
var bodyAddress = new Address.Builder()
    .AddressLine1("500 Electric Ave")
    .AddressLine2("Suite 600")
    .Locality("New York")
    .AdministrativeDistrictLevel1("NY")
    .PostalCode("10003")
    .Country("US")
    .Build();
var body = new CreateCustomerRequest.Builder()
    .GivenName("Amelia")
    .FamilyName("Earhart")
    .EmailAddress("Amelia.Earhart@example.com")
    .Address(bodyAddress)
    .PhoneNumber("1-212-555-4240")
    .ReferenceId("YOUR_REFERENCE_ID")
    .Note("a customer")
    .Build();

try
{
    CreateCustomerResponse result = customersApi.CreateCustomerAsync(body).Result;
}
catch (ApiException e){};
```

## Search Customers

Searches the customer profiles associated with a Square account.
Calling SearchCustomers without an explicit query parameter returns all
customer profiles ordered alphabetically based on `given_name` and
`family_name`.

```csharp
SearchCustomersAsync(Models.SearchCustomersRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchCustomersRequest`](/doc/models/search-customers-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchCustomersResponse>`](/doc/models/search-customers-response.md)

### Example Usage

```csharp
var bodyQueryFilterCreationSourceValues = new List<string>();
bodyQueryFilterCreationSourceValues.Add("THIRD_PARTY");
var bodyQueryFilterCreationSource = new CustomerCreationSourceFilter.Builder()
    .Values(bodyQueryFilterCreationSourceValues)
    .Rule("INCLUDE")
    .Build();
var bodyQueryFilterCreatedAt = new TimeRange.Builder()
    .StartAt("2018-01-01T00:00:00-00:00")
    .EndAt("2018-02-01T00:00:00-00:00")
    .Build();
var bodyQueryFilter = new CustomerFilter.Builder()
    .CreationSource(bodyQueryFilterCreationSource)
    .CreatedAt(bodyQueryFilterCreatedAt)
    .Build();
var bodyQuerySort = new CustomerSort.Builder()
    .Field("CREATED_AT")
    .Order("ASC")
    .Build();
var bodyQuery = new CustomerQuery.Builder()
    .Filter(bodyQueryFilter)
    .Sort(bodyQuerySort)
    .Build();
var body = new SearchCustomersRequest.Builder()
    .Limit(2L)
    .Query(bodyQuery)
    .Build();

try
{
    SearchCustomersResponse result = customersApi.SearchCustomersAsync(body).Result;
}
catch (ApiException e){};
```

## Delete Customer

Deletes a customer from a business, along with any linked cards on file. When two profiles
are merged into a single profile, that profile is assigned a new `customer_id`. You must use the
new `customer_id` to delete merged profiles.

```csharp
DeleteCustomerAsync(string customerId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to delete. |

### Response Type

[`Task<Models.DeleteCustomerResponse>`](/doc/models/delete-customer-response.md)

### Example Usage

```csharp
string customerId = "customer_id8";

try
{
    DeleteCustomerResponse result = customersApi.DeleteCustomerAsync(customerId).Result;
}
catch (ApiException e){};
```

## Retrieve Customer

Returns details for a single customer.

```csharp
RetrieveCustomerAsync(string customerId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to retrieve. |

### Response Type

[`Task<Models.RetrieveCustomerResponse>`](/doc/models/retrieve-customer-response.md)

### Example Usage

```csharp
string customerId = "customer_id8";

try
{
    RetrieveCustomerResponse result = customersApi.RetrieveCustomerAsync(customerId).Result;
}
catch (ApiException e){};
```

## Update Customer

Updates the details of an existing customer. When two profiles are merged
into a single profile, that profile is assigned a new `customer_id`. You must use
the new `customer_id` to update merged profiles.

You cannot edit a customer's cards on file with this endpoint. To make changes
to a card on file, you must delete the existing card on file with the
[DeleteCustomerCard](#endpoint-deletecustomercard) endpoint, then create a new one with the
[CreateCustomerCard](#endpoint-createcustomercard) endpoint.

```csharp
UpdateCustomerAsync(string customerId, Models.UpdateCustomerRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to update. |
| `body` | [`Models.UpdateCustomerRequest`](/doc/models/update-customer-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateCustomerResponse>`](/doc/models/update-customer-response.md)

### Example Usage

```csharp
string customerId = "customer_id8";
var body = new UpdateCustomerRequest.Builder()
    .EmailAddress("New.Amelia.Earhart@example.com")
    .PhoneNumber("")
    .Note("updated customer note")
    .Build();

try
{
    UpdateCustomerResponse result = customersApi.UpdateCustomerAsync(customerId, body).Result;
}
catch (ApiException e){};
```

## Create Customer Card

Adds a card on file to an existing customer.

As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
calls with the same card nonce return the same card record that was created
with the provided nonce during the _first_ call.

```csharp
CreateCustomerCardAsync(string customerId, Models.CreateCustomerCardRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The Square ID of the customer profile the card is linked to. |
| `body` | [`Models.CreateCustomerCardRequest`](/doc/models/create-customer-card-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateCustomerCardResponse>`](/doc/models/create-customer-card-response.md)

### Example Usage

```csharp
string customerId = "customer_id8";
var bodyBillingAddress = new Address.Builder()
    .AddressLine1("500 Electric Ave")
    .AddressLine2("Suite 600")
    .Locality("New York")
    .AdministrativeDistrictLevel1("NY")
    .PostalCode("10003")
    .Country("US")
    .Build();
var body = new CreateCustomerCardRequest.Builder(
        "YOUR_CARD_NONCE")
    .BillingAddress(bodyBillingAddress)
    .CardholderName("Amelia Earhart")
    .Build();

try
{
    CreateCustomerCardResponse result = customersApi.CreateCustomerCardAsync(customerId, body).Result;
}
catch (ApiException e){};
```

## Delete Customer Card

Removes a card on file from a customer.

```csharp
DeleteCustomerCardAsync(string customerId, string cardId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer that the card on file belongs to. |
| `cardId` | `string` | Template, Required | The ID of the card on file to delete. |

### Response Type

[`Task<Models.DeleteCustomerCardResponse>`](/doc/models/delete-customer-card-response.md)

### Example Usage

```csharp
string customerId = "customer_id8";
string cardId = "card_id4";

try
{
    DeleteCustomerCardResponse result = customersApi.DeleteCustomerCardAsync(customerId, cardId).Result;
}
catch (ApiException e){};
```

