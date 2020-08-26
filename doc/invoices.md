# Invoices

```csharp
IInvoicesApi invoicesApi = client.InvoicesApi;
```

## Class Name

`InvoicesApi`

## Methods

* [List Invoices](/doc/invoices.md#list-invoices)
* [Create Invoice](/doc/invoices.md#create-invoice)
* [Search Invoices](/doc/invoices.md#search-invoices)
* [Delete Invoice](/doc/invoices.md#delete-invoice)
* [Get Invoice](/doc/invoices.md#get-invoice)
* [Update Invoice](/doc/invoices.md#update-invoice)
* [Cancel Invoice](/doc/invoices.md#cancel-invoice)
* [Publish Invoice](/doc/invoices.md#publish-invoice)

## List Invoices

Returns a list of invoices for a given location. The response 
is paginated. If truncated, the response includes a `cursor` that you    
use in a subsequent request to fetch the next set of invoices.
For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).

```csharp
ListInvoicesAsync(string locationId, string cursor = null, int? limit = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Required | The ID of the location for which to list invoices. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint. <br>Provide this cursor to retrieve the next set of results for your original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/docs/working-with-apis/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of invoices to return (200 is the maximum `limit`). <br>If not provided, the server <br>uses a default limit of 100 invoices. |

### Response Type

[`Task<Models.ListInvoicesResponse>`](/doc/models/list-invoices-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string cursor = "cursor6";
int? limit = 172;

try
{
    ListInvoicesResponse result = await invoicesApi.ListInvoicesAsync(locationId, cursor, limit);
}
catch (ApiException e){};
```

## Create Invoice

Creates a draft [invoice](#type-invoice) 
for an order created using the Orders API.

A draft invoice remains in your account and no action is taken. 
You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file). 
For more information, see [Manage Invoices Using the Invoices API](https://developer.squareup.com/docs/docs/invoices-api/overview).

```csharp
CreateInvoiceAsync(Models.CreateInvoiceRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateInvoiceRequest`](/doc/models/create-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateInvoiceResponse>`](/doc/models/create-invoice-response.md)

### Example Usage

```csharp
var bodyInvoicePrimaryRecipientAddress = new Address.Builder()
    .AddressLine1("address_line_10")
    .AddressLine2("address_line_20")
    .AddressLine3("address_line_36")
    .Locality("locality0")
    .Sublocality("sublocality0")
    .Build();
var bodyInvoicePrimaryRecipient = new InvoiceRecipient.Builder()
    .CustomerId("JDKYHBWT1D4F8MFH63DBMEN8Y4")
    .GivenName("given_name6")
    .FamilyName("family_name8")
    .EmailAddress("email_address2")
    .Address(bodyInvoicePrimaryRecipientAddress)
    .Build();
var bodyInvoicePaymentRequests = new List<InvoicePaymentRequest>();

var bodyInvoicePaymentRequests0FixedAmountRequestedMoney = new Money.Builder()
    .Amount(52L)
    .Currency("USS")
    .Build();
var bodyInvoicePaymentRequests0Reminders = new List<InvoicePaymentReminder>();

var bodyInvoicePaymentRequests0Reminders0 = new InvoicePaymentReminder.Builder()
    .Uid("uid2")
    .RelativeScheduledDays(-1)
    .Message("Your invoice is due tomorrow")
    .Status("PENDING")
    .SentAt("sent_at2")
    .Build();
bodyInvoicePaymentRequests0Reminders.Add(bodyInvoicePaymentRequests0Reminders0);

var bodyInvoicePaymentRequests0 = new InvoicePaymentRequest.Builder()
    .Uid("uid4")
    .RequestMethod("EMAIL")
    .RequestType("BALANCE")
    .DueDate("2030-01-24")
    .FixedAmountRequestedMoney(bodyInvoicePaymentRequests0FixedAmountRequestedMoney)
    .TippingEnabled(true)
    .Reminders(bodyInvoicePaymentRequests0Reminders)
    .Build();
bodyInvoicePaymentRequests.Add(bodyInvoicePaymentRequests0);

var bodyInvoice = new Invoice.Builder()
    .Id("id0")
    .Version(38)
    .LocationId("ES0RJRZYEC39A")
    .OrderId("CAISENgvlJ6jLWAzERDzjyHVybY")
    .PrimaryRecipient(bodyInvoicePrimaryRecipient)
    .PaymentRequests(bodyInvoicePaymentRequests)
    .InvoiceNumber("inv-100")
    .Title("Event Planning Services")
    .Description("We appreciate your business!")
    .ScheduledAt("2030-01-13T10:00:00Z")
    .Build();
var body = new CreateInvoiceRequest.Builder(
        bodyInvoice)
    .IdempotencyKey("ce3748f9-5fc1-4762-aa12-aae5e843f1f4")
    .Build();

try
{
    CreateInvoiceResponse result = await invoicesApi.CreateInvoiceAsync(body);
}
catch (ApiException e){};
```

## Search Invoices

Searches for invoices from a location specified in 
the filter. You can optionally specify customers in the filter for whom to 
retrieve invoices. In the current implementation, you can only specify one location and 
optionally one customer.

The response is paginated. If truncated, the response includes a `cursor` 
that you use in a subsequent request to fetch the next set of invoices. 
For more information about retrieving invoices, see [Retrieve invoices](https://developer.squareup.com/docs/docs/invoices-api/overview#retrieve-invoices).

```csharp
SearchInvoicesAsync(Models.SearchInvoicesRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchInvoicesRequest`](/doc/models/search-invoices-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchInvoicesResponse>`](/doc/models/search-invoices-response.md)

### Example Usage

```csharp
var bodyQueryFilterLocationIds = new List<string>();
bodyQueryFilterLocationIds.Add("ES0RJRZYEC39A");
var bodyQueryFilterCustomerIds = new List<string>();
bodyQueryFilterCustomerIds.Add("JDKYHBWT1D4F8MFH63DBMEN8Y4");
var bodyQueryFilter = new InvoiceFilter.Builder(
        bodyQueryFilterLocationIds)
    .CustomerIds(bodyQueryFilterCustomerIds)
    .Build();
var bodyQuerySort = new InvoiceSort.Builder(
        "INVOICE_SORT_DATE")
    .Order("DESC")
    .Build();
var bodyQuery = new InvoiceQuery.Builder(
        bodyQueryFilter)
    .Sort(bodyQuerySort)
    .Build();
var body = new SearchInvoicesRequest.Builder(
        bodyQuery)
    .Limit(164)
    .Cursor("cursor0")
    .Build();

try
{
    SearchInvoicesResponse result = await invoicesApi.SearchInvoicesAsync(body);
}
catch (ApiException e){};
```

## Delete Invoice

Deletes the specified invoice. When an invoice is deleted, the 
associated Order status changes to CANCELED. You can only delete a draft 
invoice (you cannot delete an invoice scheduled for publication, or a 
published invoice).

```csharp
DeleteInvoiceAsync(string invoiceId, int? version = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The ID of the invoice to delete. |
| `version` | `int?` | Query, Optional | The version of the [invoice](#type-invoice) to delete.<br>If you do not know the version, you can call [GetInvoice](#endpoint-Invoices-GetInvoice) or <br>[ListInvoices](#endpoint-Invoices-ListInvoices). |

### Response Type

[`Task<Models.DeleteInvoiceResponse>`](/doc/models/delete-invoice-response.md)

### Example Usage

```csharp
string invoiceId = "invoice_id0";
int? version = 172;

try
{
    DeleteInvoiceResponse result = await invoicesApi.DeleteInvoiceAsync(invoiceId, version);
}
catch (ApiException e){};
```

## Get Invoice

Retrieves an invoice by invoice ID.

```csharp
GetInvoiceAsync(string invoiceId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The id of the invoice to retrieve. |

### Response Type

[`Task<Models.GetInvoiceResponse>`](/doc/models/get-invoice-response.md)

### Example Usage

```csharp
string invoiceId = "invoice_id0";

try
{
    GetInvoiceResponse result = await invoicesApi.GetInvoiceAsync(invoiceId);
}
catch (ApiException e){};
```

## Update Invoice

Updates an invoice by modifying field values, clearing field values, or both 
as specified in the request. 
There are no restrictions to updating an invoice in a draft state. 
However, there are guidelines for updating a published invoice. 
For more information, see [Update an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#update-an-invoice).

```csharp
UpdateInvoiceAsync(string invoiceId, Models.UpdateInvoiceRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The id of the invoice to update. |
| `body` | [`Models.UpdateInvoiceRequest`](/doc/models/update-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.UpdateInvoiceResponse>`](/doc/models/update-invoice-response.md)

### Example Usage

```csharp
string invoiceId = "invoice_id0";
var bodyInvoicePrimaryRecipientAddress = new Address.Builder()
    .AddressLine1("address_line_10")
    .AddressLine2("address_line_20")
    .AddressLine3("address_line_36")
    .Locality("locality0")
    .Sublocality("sublocality0")
    .Build();
var bodyInvoicePrimaryRecipient = new InvoiceRecipient.Builder()
    .CustomerId("customer_id2")
    .GivenName("given_name6")
    .FamilyName("family_name8")
    .EmailAddress("email_address2")
    .Address(bodyInvoicePrimaryRecipientAddress)
    .Build();
var bodyInvoicePaymentRequests = new List<InvoicePaymentRequest>();

var bodyInvoicePaymentRequests0FixedAmountRequestedMoney = new Money.Builder()
    .Amount(52L)
    .Currency("USS")
    .Build();
var bodyInvoicePaymentRequests0 = new InvoicePaymentRequest.Builder()
    .Uid("2da7964f-f3d2-4f43-81e8-5aa220bf3355")
    .RequestMethod("EMAIL")
    .RequestType("DEPOSIT")
    .DueDate("due_date2")
    .FixedAmountRequestedMoney(bodyInvoicePaymentRequests0FixedAmountRequestedMoney)
    .TippingEnabled(false)
    .Build();
bodyInvoicePaymentRequests.Add(bodyInvoicePaymentRequests0);

var bodyInvoice = new Invoice.Builder()
    .Id("id0")
    .Version(38)
    .LocationId("location_id4")
    .OrderId("order_id6")
    .PrimaryRecipient(bodyInvoicePrimaryRecipient)
    .PaymentRequests(bodyInvoicePaymentRequests)
    .Build();
var bodyFieldsToClear = new List<string>();
bodyFieldsToClear.Add("payments_requests[2da7964f-f3d2-4f43-81e8-5aa220bf3355].reminders");
var body = new UpdateInvoiceRequest.Builder(
        bodyInvoice)
    .IdempotencyKey("4ee82288-0910-499e-ab4c-5d0071dad1be")
    .FieldsToClear(bodyFieldsToClear)
    .Build();

try
{
    UpdateInvoiceResponse result = await invoicesApi.UpdateInvoiceAsync(invoiceId, body);
}
catch (ApiException e){};
```

## Cancel Invoice

Cancels an invoice. The seller cannot collect payments for 
the canceled invoice.

You cannot cancel an invoice in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.

```csharp
CancelInvoiceAsync(string invoiceId, Models.CancelInvoiceRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The ID of the [invoice](#type-invoice) to cancel. |
| `body` | [`Models.CancelInvoiceRequest`](/doc/models/cancel-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CancelInvoiceResponse>`](/doc/models/cancel-invoice-response.md)

### Example Usage

```csharp
string invoiceId = "invoice_id0";
var body = new CancelInvoiceRequest.Builder(
        0)
    .Build();

try
{
    CancelInvoiceResponse result = await invoicesApi.CancelInvoiceAsync(invoiceId, body);
}
catch (ApiException e){};
```

## Publish Invoice

Publishes the specified draft invoice. 

After an invoice is published, Square 
follows up based on the invoice configuration. For example, Square 
sends the invoice to the customer's email address, charges the customer's card on file, or does 
nothing. Square also makes the invoice available on a Square-hosted invoice page. 

The invoice `status` also changes from `DRAFT` to a status 
based on the invoice configuration. For example, the status changes to `UNPAID` if 
Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the 
invoice amount).

For more information, see 
[Create and publish an invoice](https://developer.squareup.com/docs/docs/invoices-api/overview#create-and-publish-an-invoice).

```csharp
PublishInvoiceAsync(string invoiceId, Models.PublishInvoiceRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The id of the invoice to publish. |
| `body` | [`Models.PublishInvoiceRequest`](/doc/models/publish-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.PublishInvoiceResponse>`](/doc/models/publish-invoice-response.md)

### Example Usage

```csharp
string invoiceId = "invoice_id0";
var body = new PublishInvoiceRequest.Builder(
        1)
    .IdempotencyKey("32da42d0-1997-41b0-826b-f09464fc2c2e")
    .Build();

try
{
    PublishInvoiceResponse result = await invoicesApi.PublishInvoiceAsync(invoiceId, body);
}
catch (ApiException e){};
```

