# Transactions

```csharp
ITransactionsApi transactionsApi = client.TransactionsApi;
```

## Class Name

`TransactionsApi`

## Methods

* [List Refunds](/doc/transactions.md#list-refunds)
* [List Transactions](/doc/transactions.md#list-transactions)
* [Charge](/doc/transactions.md#charge)
* [Retrieve Transaction](/doc/transactions.md#retrieve-transaction)
* [Capture Transaction](/doc/transactions.md#capture-transaction)
* [Create Refund](/doc/transactions.md#create-refund)
* [Void Transaction](/doc/transactions.md#void-transaction)

## List Refunds

Lists refunds for one of a business's locations.

In addition to full or partial tender refunds processed through Square APIs,
refunds may result from itemized returns or exchanges through Square's
Point of Sale applications.

Refunds with a `status` of `PENDING` are not currently included in this
endpoint's response.

Max results per [page](#paginatingresults): 50

```csharp
ListRefundsAsync(
    string locationId,
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list refunds for. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time. |
| `sortOrder` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which results are listed in the response (`ASC` for<br>oldest first, `DESC` for newest first).<br><br>Default value: `DESC` |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Paginating results](#paginatingresults) for more information. |

### Response Type

[`Task<Models.ListRefundsResponse>`](/doc/models/list-refunds-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string beginTime = "begin_time2";
string endTime = "end_time2";
string sortOrder = "DESC";
string cursor = "cursor6";

try
{
    ListRefundsResponse result = await transactionsApi.ListRefundsAsync(locationId, beginTime, endTime, sortOrder, cursor);
}
catch (ApiException e){};
```

## List Transactions

Lists transactions for a particular location.

Transactions include payment information from sales and exchanges and refund
information from returns and exchanges.

Max results per [page](#paginatingresults): 50

```csharp
ListTransactionsAsync(
    string locationId,
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list transactions for. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time. |
| `sortOrder` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which results are listed in the response (`ASC` for<br>oldest first, `DESC` for newest first).<br><br>Default value: `DESC` |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Paginating results](#paginatingresults) for more information. |

### Response Type

[`Task<Models.ListTransactionsResponse>`](/doc/models/list-transactions-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string beginTime = "begin_time2";
string endTime = "end_time2";
string sortOrder = "DESC";
string cursor = "cursor6";

try
{
    ListTransactionsResponse result = await transactionsApi.ListTransactionsAsync(locationId, beginTime, endTime, sortOrder, cursor);
}
catch (ApiException e){};
```

## Charge

Charges a card represented by a card nonce or a customer's card on file.

Your request to this endpoint must include _either_:

- A value for the `card_nonce` parameter (to charge a card nonce generated
with the `SqPaymentForm`)
- Values for the `customer_card_id` and `customer_id` parameters (to charge
a customer's card on file)

In order for an eCommerce payment to potentially qualify for
[Square chargeback protection](https://squareup.com/help/article/5394), you
_must_ provide values for the following parameters in your request:

- `buyer_email_address`
- At least one of `billing_address` or `shipping_address`

When this response is returned, the amount of Square's processing fee might not yet be
calculated. To obtain the processing fee, wait about ten seconds and call
[RetrieveTransaction](#endpoint-retrievetransaction). See the `processing_fee_money`
field of each [Tender included](#type-tender) in the transaction.

```csharp
ChargeAsync(string locationId, Models.ChargeRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to associate the created transaction with. |
| `body` | [`Models.ChargeRequest`](/doc/models/charge-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.ChargeResponse>`](/doc/models/charge-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyAmountMoney = new Money.Builder()
    .Amount(200L)
    .Currency("USD")
    .Build();
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
var bodyShippingAddress = new Address.Builder()
    .AddressLine1("123 Main St")
    .AddressLine2("address_line_24")
    .AddressLine3("address_line_30")
    .Locality("San Francisco")
    .Sublocality("sublocality4")
    .AdministrativeDistrictLevel1("CA")
    .PostalCode("94114")
    .Country("US")
    .Build();
var bodyAdditionalRecipients = new List<AdditionalRecipient>();

var bodyAdditionalRecipients0AmountMoney = new Money.Builder()
    .Amount(20L)
    .Currency("USD")
    .Build();
var bodyAdditionalRecipients0 = new AdditionalRecipient.Builder(
        "057P5VYJ4A5X1",
        "Application fees",
        bodyAdditionalRecipients0AmountMoney)
    .ReceivableId("receivable_id5")
    .Build();
bodyAdditionalRecipients.Add(bodyAdditionalRecipients0);

var body = new ChargeRequest.Builder(
        "74ae1696-b1e3-4328-af6d-f1e04d947a13",
        bodyAmountMoney)
    .CardNonce("card_nonce_from_square_123")
    .CustomerCardId("customer_card_id6")
    .DelayCapture(false)
    .ReferenceId("some optional reference id")
    .Note("some optional note")
    .BillingAddress(bodyBillingAddress)
    .ShippingAddress(bodyShippingAddress)
    .AdditionalRecipients(bodyAdditionalRecipients)
    .Build();

try
{
    ChargeResponse result = await transactionsApi.ChargeAsync(locationId, body);
}
catch (ApiException e){};
```

## Retrieve Transaction

Retrieves details for a single transaction.

```csharp
RetrieveTransactionAsync(string locationId, string transactionId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the transaction's associated location. |
| `transactionId` | `string` | Template, Required | The ID of the transaction to retrieve. |

### Response Type

[`Task<Models.RetrieveTransactionResponse>`](/doc/models/retrieve-transaction-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string transactionId = "transaction_id8";

try
{
    RetrieveTransactionResponse result = await transactionsApi.RetrieveTransactionAsync(locationId, transactionId);
}
catch (ApiException e){};
```

## Capture Transaction

Captures a transaction that was created with the [Charge](#endpoint-charge)
endpoint with a `delay_capture` value of `true`.


See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
for more information.

```csharp
CaptureTransactionAsync(string locationId, string transactionId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | - |
| `transactionId` | `string` | Template, Required | - |

### Response Type

[`Task<Models.CaptureTransactionResponse>`](/doc/models/capture-transaction-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string transactionId = "transaction_id8";

try
{
    CaptureTransactionResponse result = await transactionsApi.CaptureTransactionAsync(locationId, transactionId);
}
catch (ApiException e){};
```

## Create Refund

Initiates a refund for a previously charged tender.

You must issue a refund within 120 days of the associated payment. See
[this article](https://squareup.com/help/us/en/article/5060) for more information
on refund behavior.

NOTE: Card-present transactions with Interac credit cards **cannot be
refunded using the Connect API**. Interac transactions must refunded
in-person (e.g., dipping the card using POS app).

```csharp
CreateRefundAsync(string locationId, string transactionId, Models.CreateRefundRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the original transaction's associated location. |
| `transactionId` | `string` | Template, Required | The ID of the original transaction that includes the tender to refund. |
| `body` | [`Models.CreateRefundRequest`](/doc/models/create-refund-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateRefundResponse>`](/doc/models/create-refund-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string transactionId = "transaction_id8";
var bodyAmountMoney = new Money.Builder()
    .Amount(100L)
    .Currency("USD")
    .Build();
var body = new CreateRefundRequest.Builder(
        "86ae1696-b1e3-4328-af6d-f1e04d947ad2",
        "MtZRYYdDrYNQbOvV7nbuBvMF",
        bodyAmountMoney)
    .Reason("a reason")
    .Build();

try
{
    CreateRefundResponse result = await transactionsApi.CreateRefundAsync(locationId, transactionId, body);
}
catch (ApiException e){};
```

## Void Transaction

Cancels a transaction that was created with the [Charge](#endpoint-charge)
endpoint with a `delay_capture` value of `true`.


See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
for more information.

```csharp
VoidTransactionAsync(string locationId, string transactionId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | - |
| `transactionId` | `string` | Template, Required | - |

### Response Type

[`Task<Models.VoidTransactionResponse>`](/doc/models/void-transaction-response.md)

### Example Usage

```csharp
string locationId = "location_id4";
string transactionId = "transaction_id8";

try
{
    VoidTransactionResponse result = await transactionsApi.VoidTransactionAsync(locationId, transactionId);
}
catch (ApiException e){};
```

