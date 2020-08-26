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
* [Remove Group From Customer](/doc/customers.md#remove-group-from-customer)
* [Add Group to Customer](/doc/customers.md#add-group-to-customer)

## List Customers

Lists customer profiles associated with a Square account.

Under normal operating conditions, newly created or updated customer profiles become available 
for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated 
profiles can take closer to one minute or longer, espeically during network incidents and outages.

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
string cursor = "cursor6";
string sortField = "DEFAULT";
string sortOrder = "DESC";

try
{
    ListCustomersResponse result = await customersApi.ListCustomersAsync(cursor, sortField, sortOrder);
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
    .AddressLine3("address_line_38")
    .Locality("New York")
    .Sublocality("sublocality2")
    .AdministrativeDistrictLevel1("NY")
    .PostalCode("10003")
    .Country("US")
    .Build();
var body = new CreateCustomerRequest.Builder()
    .IdempotencyKey("idempotency_key2")
    .GivenName("Amelia")
    .FamilyName("Earhart")
    .CompanyName("company_name2")
    .Nickname("nickname2")
    .EmailAddress("Amelia.Earhart@example.com")
    .Address(bodyAddress)
    .PhoneNumber("1-212-555-4240")
    .ReferenceId("YOUR_REFERENCE_ID")
    .Note("a customer")
    .Build();

try
{
    CreateCustomerResponse result = await customersApi.CreateCustomerAsync(body);
}
catch (ApiException e){};
```

## Search Customers

Searches the customer profiles associated with a Square account using 
one or more supported query filters. 

Calling `SearchCustomers` without any explicit query filter returns all
customer profiles ordered alphabetically based on `given_name` and
`family_name`.

Under normal operating conditions, newly created or updated customer profiles become available 
for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated 
profiles can take closer to one minute or longer, espeically during network incidents and outages.

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
var bodyQueryFilterUpdatedAt = new TimeRange.Builder()
    .StartAt("start_at4")
    .EndAt("end_at8")
    .Build();
var bodyQueryFilterEmailAddress = new CustomerTextFilter.Builder()
    .Exact("exact0")
    .Fuzzy("example.com")
    .Build();
var bodyQueryFilterPhoneNumber = new CustomerTextFilter.Builder()
    .Exact("exact0")
    .Fuzzy("fuzzy6")
    .Build();
var bodyQueryFilterGroupIdsAll = new List<string>();
bodyQueryFilterGroupIdsAll.Add("545AXB44B4XXWMVQ4W8SBT3HHF");
var bodyQueryFilterGroupIdsAny = new List<string>();
bodyQueryFilterGroupIdsAny.Add("any0");
bodyQueryFilterGroupIdsAny.Add("any1");
bodyQueryFilterGroupIdsAny.Add("any2");
var bodyQueryFilterGroupIdsNone = new List<string>();
bodyQueryFilterGroupIdsNone.Add("none5");
bodyQueryFilterGroupIdsNone.Add("none6");
var bodyQueryFilterGroupIds = new FilterValue.Builder()
    .All(bodyQueryFilterGroupIdsAll)
    .Any(bodyQueryFilterGroupIdsAny)
    .None(bodyQueryFilterGroupIdsNone)
    .Build();
var bodyQueryFilter = new CustomerFilter.Builder()
    .CreationSource(bodyQueryFilterCreationSource)
    .CreatedAt(bodyQueryFilterCreatedAt)
    .UpdatedAt(bodyQueryFilterUpdatedAt)
    .EmailAddress(bodyQueryFilterEmailAddress)
    .PhoneNumber(bodyQueryFilterPhoneNumber)
    .GroupIds(bodyQueryFilterGroupIds)
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
    .Cursor("cursor0")
    .Limit(2L)
    .Query(bodyQuery)
    .Build();

try
{
    SearchCustomersResponse result = await customersApi.SearchCustomersAsync(body);
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
    DeleteCustomerResponse result = await customersApi.DeleteCustomerAsync(customerId);
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
    RetrieveCustomerResponse result = await customersApi.RetrieveCustomerAsync(customerId);
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
    .GivenName("given_name8")
    .FamilyName("family_name0")
    .CompanyName("company_name2")
    .Nickname("nickname2")
    .EmailAddress("New.Amelia.Earhart@example.com")
    .PhoneNumber("")
    .Note("updated customer note")
    .Build();

try
{
    UpdateCustomerResponse result = await customersApi.UpdateCustomerAsync(customerId, body);
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
    .AddressLine3("address_line_38")
    .Locality("New York")
    .Sublocality("sublocality2")
    .AdministrativeDistrictLevel1("NY")
    .PostalCode("10003")
    .Country("US")
    .Build();
var body = new CreateCustomerCardRequest.Builder(
        "YOUR_CARD_NONCE")
    .BillingAddress(bodyBillingAddress)
    .CardholderName("Amelia Earhart")
    .VerificationToken("verification_token0")
    .Build();

try
{
    CreateCustomerCardResponse result = await customersApi.CreateCustomerCardAsync(customerId, body);
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
    DeleteCustomerCardResponse result = await customersApi.DeleteCustomerCardAsync(customerId, cardId);
}
catch (ApiException e){};
```

## Remove Group From Customer

Removes a group membership from a customer. 

The customer is identified by the `customer_id` value 
and the customer group is identified by the `group_id` value.

```csharp
RemoveGroupFromCustomerAsync(string customerId, string groupId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to remove from the group. |
| `groupId` | `string` | Template, Required | The ID of the customer group to remove the customer from. |

### Response Type

[`Task<Models.RemoveGroupFromCustomerResponse>`](/doc/models/remove-group-from-customer-response.md)

### Example Usage

```csharp
string customerId = "customer_id8";
string groupId = "group_id0";

try
{
    RemoveGroupFromCustomerResponse result = await customersApi.RemoveGroupFromCustomerAsync(customerId, groupId);
}
catch (ApiException e){};
```

## Add Group to Customer

Adds a group membership to a customer. 

The customer is identified by the `customer_id` value 
and the customer group is identified by the `group_id` value.

```csharp
AddGroupToCustomerAsync(string customerId, string groupId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `customerId` | `string` | Template, Required | The ID of the customer to add to a group. |
| `groupId` | `string` | Template, Required | The ID of the customer group to add the customer to. |

### Response Type

[`Task<Models.AddGroupToCustomerResponse>`](/doc/models/add-group-to-customer-response.md)

### Example Usage

```csharp
string customerId = "customer_id8";
string groupId = "group_id0";

try
{
    AddGroupToCustomerResponse result = await customersApi.AddGroupToCustomerAsync(customerId, groupId);
}
catch (ApiException e){};
```

