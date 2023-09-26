# Transactions

```csharp
ITransactionsApi transactionsApi = client.TransactionsApi;
```

## Class Name

`TransactionsApi`

## Methods

* [List Transactions](../../doc/api/transactions.md#list-transactions)
* [Retrieve Transaction](../../doc/api/transactions.md#retrieve-transaction)
* [Capture Transaction](../../doc/api/transactions.md#capture-transaction)
* [Void Transaction](../../doc/api/transactions.md#void-transaction)


# List Transactions

**This endpoint is deprecated.**

Lists transactions for a particular location.

Transactions include payment information from sales and exchanges and refund
information from returns and exchanges.

Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50

```csharp
ListTransactionsAsync(
    string locationId,
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list transactions for. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.<br><br>Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](https://developer.squareup.com/docs/build-basics/working-with-dates) for details on date inclusivity/exclusivity.<br><br>Default value: The current time. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | The order in which results are listed in the response (`ASC` for<br>oldest first, `DESC` for newest first).<br><br>Default value: `DESC` |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information. |

## Response Type

[`Task<Models.ListTransactionsResponse>`](../../doc/models/list-transactions-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
try
{
    ListTransactionsResponse result = await transactionsApi.ListTransactionsAsync(locationId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Transaction

**This endpoint is deprecated.**

Retrieves details for a single transaction.

```csharp
RetrieveTransactionAsync(
    string locationId,
    string transactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the transaction's associated location. |
| `transactionId` | `string` | Template, Required | The ID of the transaction to retrieve. |

## Response Type

[`Task<Models.RetrieveTransactionResponse>`](../../doc/models/retrieve-transaction-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
string transactionId = "transaction_id8";
try
{
    RetrieveTransactionResponse result = await transactionsApi.RetrieveTransactionAsync(
        locationId,
        transactionId
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Capture Transaction

**This endpoint is deprecated.**

Captures a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
endpoint with a `delay_capture` value of `true`.

See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
for more information.

```csharp
CaptureTransactionAsync(
    string locationId,
    string transactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | - |
| `transactionId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.CaptureTransactionResponse>`](../../doc/models/capture-transaction-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
string transactionId = "transaction_id8";
try
{
    CaptureTransactionResponse result = await transactionsApi.CaptureTransactionAsync(
        locationId,
        transactionId
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Void Transaction

**This endpoint is deprecated.**

Cancels a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
endpoint with a `delay_capture` value of `true`.

See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
for more information.

```csharp
VoidTransactionAsync(
    string locationId,
    string transactionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | - |
| `transactionId` | `string` | Template, Required | - |

## Response Type

[`Task<Models.VoidTransactionResponse>`](../../doc/models/void-transaction-response.md)

## Example Usage

```csharp
string locationId = "location_id4";
string transactionId = "transaction_id8";
try
{
    VoidTransactionResponse result = await transactionsApi.VoidTransactionAsync(
        locationId,
        transactionId
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

