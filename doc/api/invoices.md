# Invoices

```csharp
IInvoicesApi invoicesApi = client.InvoicesApi;
```

## Class Name

`InvoicesApi`

## Methods

* [List Invoices](../../doc/api/invoices.md#list-invoices)
* [Create Invoice](../../doc/api/invoices.md#create-invoice)
* [Search Invoices](../../doc/api/invoices.md#search-invoices)
* [Delete Invoice](../../doc/api/invoices.md#delete-invoice)
* [Get Invoice](../../doc/api/invoices.md#get-invoice)
* [Update Invoice](../../doc/api/invoices.md#update-invoice)
* [Cancel Invoice](../../doc/api/invoices.md#cancel-invoice)
* [Publish Invoice](../../doc/api/invoices.md#publish-invoice)


# List Invoices

Returns a list of invoices for a given location. The response
is paginated. If truncated, the response includes a `cursor` that you  
use in a subsequent request to retrieve the next set of invoices.

```csharp
ListInvoicesAsync(
    string locationId,
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Query, Required | The ID of the location for which to list invoices. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for your original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of invoices to return (200 is the maximum `limit`).<br>If not provided, the server uses a default limit of 100 invoices. |

## Response Type

[`Task<Models.ListInvoicesResponse>`](../../doc/models/list-invoices-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
try
{
    ListInvoicesResponse result = await invoicesApi.ListInvoicesAsync(locationId, null, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Invoice

Creates a draft [invoice](../../doc/models/invoice.md)
for an order created using the Orders API.

A draft invoice remains in your account and no action is taken.
You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).

```csharp
CreateInvoiceAsync(
    Models.CreateInvoiceRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateInvoiceRequest`](../../doc/models/create-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateInvoiceResponse>`](../../doc/models/create-invoice-response.md)

## Example Usage

```csharp
Models.CreateInvoiceRequest body = new Models.CreateInvoiceRequest.Builder(
    new Models.Invoice.Builder()
    .LocationId("ES0RJRZYEC39A")
    .OrderId("CAISENgvlJ6jLWAzERDzjyHVybY")
    .PrimaryRecipient(
        new Models.InvoiceRecipient.Builder()
        .CustomerId("JDKYHBWT1D4F8MFH63DBMEN8Y4")
        .Build())
    .PaymentRequests(
        new List<Models.InvoicePaymentRequest>
        {
            new Models.InvoicePaymentRequest.Builder()
            .RequestType("BALANCE")
            .DueDate("2030-01-24")
            .TippingEnabled(true)
            .AutomaticPaymentSource("NONE")
            .Reminders(
                new List<Models.InvoicePaymentReminder>
                {
                    new Models.InvoicePaymentReminder.Builder()
                    .RelativeScheduledDays(-1)
                    .Message("Your invoice is due tomorrow")
                    .Build(),
                })
            .Build(),
        })
    .DeliveryMethod("EMAIL")
    .InvoiceNumber("inv-100")
    .Title("Event Planning Services")
    .Description("We appreciate your business!")
    .ScheduledAt("2030-01-13T10:00:00Z")
    .AcceptedPaymentMethods(
        new Models.InvoiceAcceptedPaymentMethods.Builder()
        .Card(true)
        .SquareGiftCard(false)
        .BankAccount(false)
        .BuyNowPayLater(false)
        .CashAppPay(false)
        .Build())
    .CustomFields(
        new List<Models.InvoiceCustomField>
        {
            new Models.InvoiceCustomField.Builder()
            .Label("Event Reference Number")
            .MValue("Ref. #1234")
            .Placement("ABOVE_LINE_ITEMS")
            .Build(),
            new Models.InvoiceCustomField.Builder()
            .Label("Terms of Service")
            .MValue("The terms of service are...")
            .Placement("BELOW_LINE_ITEMS")
            .Build(),
        })
    .SaleOrServiceDate("2030-01-24")
    .StorePaymentMethodEnabled(false)
    .Build()
)
.IdempotencyKey("ce3748f9-5fc1-4762-aa12-aae5e843f1f4")
.Build();

try
{
    CreateInvoiceResponse result = await invoicesApi.CreateInvoiceAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Search Invoices

Searches for invoices from a location specified in
the filter. You can optionally specify customers in the filter for whom to
retrieve invoices. In the current implementation, you can only specify one location and
optionally one customer.

The response is paginated. If truncated, the response includes a `cursor`
that you use in a subsequent request to retrieve the next set of invoices.

```csharp
SearchInvoicesAsync(
    Models.SearchInvoicesRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SearchInvoicesRequest`](../../doc/models/search-invoices-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchInvoicesResponse>`](../../doc/models/search-invoices-response.md)

## Example Usage

```csharp
Models.SearchInvoicesRequest body = new Models.SearchInvoicesRequest.Builder(
    new Models.InvoiceQuery.Builder(
        new Models.InvoiceFilter.Builder(
            new List<string>
            {
                "ES0RJRZYEC39A",
            }
        )
        .CustomerIds(
            new List<string>
            {
                "JDKYHBWT1D4F8MFH63DBMEN8Y4",
            })
        .Build()
    )
    .Sort(
        new Models.InvoiceSort.Builder(
            "INVOICE_SORT_DATE"
        )
        .Order("DESC")
        .Build())
    .Build()
)
.Build();

try
{
    SearchInvoicesResponse result = await invoicesApi.SearchInvoicesAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete Invoice

Deletes the specified invoice. When an invoice is deleted, the
associated order status changes to CANCELED. You can only delete a draft
invoice (you cannot delete a published invoice, including one that is scheduled for processing).

```csharp
DeleteInvoiceAsync(
    string invoiceId,
    int? version = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The ID of the invoice to delete. |
| `version` | `int?` | Query, Optional | The version of the [invoice](entity:Invoice) to delete.<br>If you do not know the version, you can call [GetInvoice](api-endpoint:Invoices-GetInvoice) or<br>[ListInvoices](api-endpoint:Invoices-ListInvoices). |

## Response Type

[`Task<Models.DeleteInvoiceResponse>`](../../doc/models/delete-invoice-response.md)

## Example Usage

```csharp
string invoiceId = "invoice_id0";
try
{
    DeleteInvoiceResponse result = await invoicesApi.DeleteInvoiceAsync(invoiceId, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Invoice

Retrieves an invoice by invoice ID.

```csharp
GetInvoiceAsync(
    string invoiceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The ID of the invoice to retrieve. |

## Response Type

[`Task<Models.GetInvoiceResponse>`](../../doc/models/get-invoice-response.md)

## Example Usage

```csharp
string invoiceId = "invoice_id0";
try
{
    GetInvoiceResponse result = await invoicesApi.GetInvoiceAsync(invoiceId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Invoice

Updates an invoice by modifying fields, clearing fields, or both. For most updates, you can use a sparse
`Invoice` object to add fields or change values and use the `fields_to_clear` field to specify fields to clear.
However, some restrictions apply. For example, you cannot change the `order_id` or `location_id` field and you
must provide the complete `custom_fields` list to update a custom field. Published invoices have additional restrictions.

```csharp
UpdateInvoiceAsync(
    string invoiceId,
    Models.UpdateInvoiceRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The ID of the invoice to update. |
| `body` | [`UpdateInvoiceRequest`](../../doc/models/update-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateInvoiceResponse>`](../../doc/models/update-invoice-response.md)

## Example Usage

```csharp
string invoiceId = "invoice_id0";
Models.UpdateInvoiceRequest body = new Models.UpdateInvoiceRequest.Builder(
    new Models.Invoice.Builder()
    .Version(1)
    .PaymentRequests(
        new List<Models.InvoicePaymentRequest>
        {
            new Models.InvoicePaymentRequest.Builder()
            .Uid("2da7964f-f3d2-4f43-81e8-5aa220bf3355")
            .TippingEnabled(false)
            .Build(),
        })
    .Build()
)
.IdempotencyKey("4ee82288-0910-499e-ab4c-5d0071dad1be")
.FieldsToClear(
    new List<string>
    {
        "payments_requests[2da7964f-f3d2-4f43-81e8-5aa220bf3355].reminders",
    })
.Build();

try
{
    UpdateInvoiceResponse result = await invoicesApi.UpdateInvoiceAsync(invoiceId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Cancel Invoice

Cancels an invoice. The seller cannot collect payments for
the canceled invoice.

You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.

```csharp
CancelInvoiceAsync(
    string invoiceId,
    Models.CancelInvoiceRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The ID of the [invoice](entity:Invoice) to cancel. |
| `body` | [`CancelInvoiceRequest`](../../doc/models/cancel-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CancelInvoiceResponse>`](../../doc/models/cancel-invoice-response.md)

## Example Usage

```csharp
string invoiceId = "invoice_id0";
Models.CancelInvoiceRequest body = new Models.CancelInvoiceRequest.Builder(
    0
)
.Build();

try
{
    CancelInvoiceResponse result = await invoicesApi.CancelInvoiceAsync(invoiceId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Publish Invoice

Publishes the specified draft invoice.

After an invoice is published, Square
follows up based on the invoice configuration. For example, Square
sends the invoice to the customer's email address, charges the customer's card on file, or does
nothing. Square also makes the invoice available on a Square-hosted invoice page.

The invoice `status` also changes from `DRAFT` to a status
based on the invoice configuration. For example, the status changes to `UNPAID` if
Square emails the invoice or `PARTIALLY_PAID` if Square charge a card on file for a portion of the
invoice amount.

```csharp
PublishInvoiceAsync(
    string invoiceId,
    Models.PublishInvoiceRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `invoiceId` | `string` | Template, Required | The ID of the invoice to publish. |
| `body` | [`PublishInvoiceRequest`](../../doc/models/publish-invoice-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.PublishInvoiceResponse>`](../../doc/models/publish-invoice-response.md)

## Example Usage

```csharp
string invoiceId = "invoice_id0";
Models.PublishInvoiceRequest body = new Models.PublishInvoiceRequest.Builder(
    1
)
.IdempotencyKey("32da42d0-1997-41b0-826b-f09464fc2c2e")
.Build();

try
{
    PublishInvoiceResponse result = await invoicesApi.PublishInvoiceAsync(invoiceId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

