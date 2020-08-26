# V1 Transactions

```csharp
IV1TransactionsApi v1TransactionsApi = client.V1TransactionsApi;
```

## Class Name

`V1TransactionsApi`

## Methods

* [List Bank Accounts](/doc/v1-transactions.md#list-bank-accounts)
* [Retrieve Bank Account](/doc/v1-transactions.md#retrieve-bank-account)
* [List Orders](/doc/v1-transactions.md#list-orders)
* [Retrieve Order](/doc/v1-transactions.md#retrieve-order)
* [Update Order](/doc/v1-transactions.md#update-order)
* [List Payments](/doc/v1-transactions.md#list-payments)
* [Retrieve Payment](/doc/v1-transactions.md#retrieve-payment)
* [List Refunds](/doc/v1-transactions.md#list-refunds)
* [Create Refund](/doc/v1-transactions.md#create-refund)
* [List Settlements](/doc/v1-transactions.md#list-settlements)
* [Retrieve Settlement](/doc/v1-transactions.md#retrieve-settlement)

## List Bank Accounts

Provides non-confidential details for all of a location's associated bank accounts. This endpoint does not provide full bank account numbers, and there is no way to obtain a full bank account number with the Connect API.

```csharp
ListBankAccountsAsync(string locationId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list bank accounts for. |

### Response Type

[`Task<List<Models.V1BankAccount>>`](/doc/models/v1-bank-account.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    List<V1BankAccount> result = await v1TransactionsApi.ListBankAccountsAsync(locationId);
}
catch (ApiException e){};
```

## Retrieve Bank Account

Provides non-confidential details for a merchant's associated bank account. This endpoint does not provide full bank account numbers, and there is no way to obtain a full bank account number with the Connect API.

```csharp
RetrieveBankAccountAsync(string locationId, string bankAccountId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the bank account's associated location. |
| `bankAccountId` | `string` | Template, Required | The bank account's Square-issued ID. You obtain this value from Settlement objects returned. |

### Response Type

[`Task<Models.V1BankAccount>`](/doc/models/v1-bank-account.md)

### Example Usage

```csharp
string locationId = "location_id4";
string bankAccountId = "bank_account_id0";

try
{
    V1BankAccount result = await v1TransactionsApi.RetrieveBankAccountAsync(locationId, bankAccountId);
}
catch (ApiException e){};
```

## List Orders

Provides summary information for a merchant's online store orders.

```csharp
ListOrdersAsync(
    string locationId,
    string order = null,
    int? limit = null,
    string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list online store orders for. |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | TThe order in which payments are listed in the response. |
| `limit` | `int?` | Query, Optional | The maximum number of payments to return in a single response. This value cannot exceed 200. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1Order>>`](/doc/models/v1-order.md)

### Example Usage

```csharp
string locationId = "location_id4";
string order = "DESC";
int? limit = 172;
string batchToken = "batch_token2";

try
{
    List<V1Order> result = await v1TransactionsApi.ListOrdersAsync(locationId, order, limit, batchToken);
}
catch (ApiException e){};
```

## Retrieve Order

Provides comprehensive information for a single online store order, including the order's history.

```csharp
RetrieveOrderAsync(string locationId, string orderId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the order's associated location. |
| `orderId` | `string` | Template, Required | The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint |

### Response Type

[`Task<Models.V1Order>`](/doc/models/v1-order.md)

### Example Usage

```csharp
string locationId = "location_id4";
string orderId = "order_id6";

try
{
    V1Order result = await v1TransactionsApi.RetrieveOrderAsync(locationId, orderId);
}
catch (ApiException e){};
```

## Update Order

Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:

```csharp
UpdateOrderAsync(string locationId, string orderId, Models.V1UpdateOrderRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the order's associated location. |
| `orderId` | `string` | Template, Required | The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint |
| `body` | [`Models.V1UpdateOrderRequest`](/doc/models/v1-update-order-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Order>`](/doc/models/v1-order.md)

### Example Usage

```csharp
string locationId = "location_id4";
string orderId = "order_id6";
var body = new V1UpdateOrderRequest.Builder(
        "REFUND")
    .ShippedTrackingNumber("shipped_tracking_number6")
    .CompletedNote("completed_note6")
    .RefundedNote("refunded_note0")
    .CanceledNote("canceled_note4")
    .Build();

try
{
    V1Order result = await v1TransactionsApi.UpdateOrderAsync(locationId, orderId, body);
}
catch (ApiException e){};
```

## List Payments

Provides summary information for all payments taken for a given
Square account during a date range. Date ranges cannot exceed 1 year in
length. See Date ranges for details of inclusive and exclusive dates.

*Note**: Details for payments processed with Square Point of Sale while
in offline mode may not be transmitted to Square for up to 72 hours.
Offline payments have a `created_at` value that reflects the time the
payment was originally processed, not the time it was subsequently
transmitted to Square. Consequently, the ListPayments endpoint might
list an offline payment chronologically between online payments that
were seen in a previous request.

```csharp
ListPaymentsAsync(
    string locationId,
    string order = null,
    string beginTime = null,
    string endTime = null,
    int? limit = null,
    string batchToken = null,
    bool? includePartial = false)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list payments for. If you specify me, this endpoint returns payments aggregated from all of the business's locations. |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which payments are listed in the response. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time. |
| `limit` | `int?` | Query, Optional | The maximum number of payments to return in a single response. This value cannot exceed 200. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |
| `includePartial` | `bool?` | Query, Optional | Indicates whether or not to include partial payments in the response. Partial payments will have the tenders collected so far, but the itemizations will be empty until the payment is completed. |

### Response Type

[`Task<List<Models.V1Payment>>`](/doc/models/v1-payment.md)

### Example Usage

```csharp
string locationId = "location_id4";
string order = "DESC";
string beginTime = "begin_time2";
string endTime = "end_time2";
int? limit = 172;
string batchToken = "batch_token2";
bool? includePartial = false;

try
{
    List<V1Payment> result = await v1TransactionsApi.ListPaymentsAsync(locationId, order, beginTime, endTime, limit, batchToken, includePartial);
}
catch (ApiException e){};
```

## Retrieve Payment

Provides comprehensive information for a single payment.

```csharp
RetrievePaymentAsync(string locationId, string paymentId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the payment's associated location. |
| `paymentId` | `string` | Template, Required | The Square-issued payment ID. payment_id comes from Payment objects returned by the List Payments endpoint, Settlement objects returned by the List Settlements endpoint, or Refund objects returned by the List Refunds endpoint. |

### Response Type

[`Task<Models.V1Payment>`](/doc/models/v1-payment.md)

### Example Usage

```csharp
string locationId = "location_id4";
string paymentId = "payment_id0";

try
{
    V1Payment result = await v1TransactionsApi.RetrievePaymentAsync(locationId, paymentId);
}
catch (ApiException e){};
```

## List Refunds

Provides the details for all refunds initiated by a merchant or any of the merchant's mobile staff during a date range. Date ranges cannot exceed one year in length.

```csharp
ListRefundsAsync(
    string locationId,
    string order = null,
    string beginTime = null,
    string endTime = null,
    int? limit = null,
    string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list refunds for. |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | TThe order in which payments are listed in the response. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time. |
| `limit` | `int?` | Query, Optional | The approximate number of refunds to return in a single response. Default: 100. Max: 200. Response may contain more results than the prescribed limit when refunds are made simultaneously to multiple tenders in a payment or when refunds are generated in an exchange to account for the value of returned goods. |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1Refund>>`](/doc/models/v1-refund.md)

### Example Usage

```csharp
string locationId = "location_id4";
string order = "DESC";
string beginTime = "begin_time2";
string endTime = "end_time2";
int? limit = 172;
string batchToken = "batch_token2";

try
{
    List<V1Refund> result = await v1TransactionsApi.ListRefundsAsync(locationId, order, beginTime, endTime, limit, batchToken);
}
catch (ApiException e){};
```

## Create Refund

Issues a refund for a previously processed payment. You must issue
a refund within 60 days of the associated payment.

You cannot issue a partial refund for a split tender payment. You must
instead issue a full or partial refund for a particular tender, by
providing the applicable tender id to the V1CreateRefund endpoint.
Issuing a full refund for a split tender payment refunds all tenders
associated with the payment.

Issuing a refund for a card payment is not reversible. For development
purposes, you can create fake cash payments in Square Point of Sale and
refund them.

```csharp
CreateRefundAsync(string locationId, Models.V1CreateRefundRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the original payment's associated location. |
| `body` | [`Models.V1CreateRefundRequest`](/doc/models/v1-create-refund-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.V1Refund>`](/doc/models/v1-refund.md)

### Example Usage

```csharp
string locationId = "location_id4";
var bodyRefundedMoney = new V1Money.Builder()
    .Amount(222)
    .CurrencyCode("CLF")
    .Build();
var body = new V1CreateRefundRequest.Builder(
        "payment_id6",
        "FULL",
        "reason8")
    .RefundedMoney(bodyRefundedMoney)
    .RequestIdempotenceKey("request_idempotence_key2")
    .Build();

try
{
    V1Refund result = await v1TransactionsApi.CreateRefundAsync(locationId, body);
}
catch (ApiException e){};
```

## List Settlements

Provides summary information for all deposits and withdrawals
initiated by Square to a linked bank account during a date range. Date
ranges cannot exceed one year in length.

*Note**: the ListSettlements endpoint does not provide entry
information.

```csharp
ListSettlementsAsync(
    string locationId,
    string order = null,
    string beginTime = null,
    string endTime = null,
    int? limit = null,
    string status = null,
    string batchToken = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list settlements for. If you specify me, this endpoint returns settlements aggregated from all of the business's locations. |
| `order` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which settlements are listed in the response. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time. |
| `limit` | `int?` | Query, Optional | The maximum number of settlements to return in a single response. This value cannot exceed 200. |
| `status` | [`string`](/doc/models/v1-list-settlements-request-status.md) | Query, Optional | Provide this parameter to retrieve only settlements with a particular status (SENT or FAILED). |
| `batchToken` | `string` | Query, Optional | A pagination cursor to retrieve the next set of results for your<br>original query to the endpoint. |

### Response Type

[`Task<List<Models.V1Settlement>>`](/doc/models/v1-settlement.md)

### Example Usage

```csharp
string locationId = "location_id4";
string order = "DESC";
string beginTime = "begin_time2";
string endTime = "end_time2";
int? limit = 172;
string status = "SENT";
string batchToken = "batch_token2";

try
{
    List<V1Settlement> result = await v1TransactionsApi.ListSettlementsAsync(locationId, order, beginTime, endTime, limit, status, batchToken);
}
catch (ApiException e){};
```

## Retrieve Settlement

Provides comprehensive information for a single settlement.

The returned `Settlement` objects include an `entries` field that lists
the transactions that contribute to the settlement total. Most
settlement entries correspond to a payment payout, but settlement
entries are also generated for less common events, like refunds, manual
adjustments, or chargeback holds.

Square initiates its regular deposits as indicated in the
[Deposit Options with Square](https://squareup.com/help/us/en/article/3807)
help article. Details for a regular deposit are usually not available
from Connect API endpoints before 10 p.m. PST the same day.

Square does not know when an initiated settlement **completes**, only
whether it has failed. A completed settlement is typically reflected in
a bank account within 3 business days, but in exceptional cases it may
take longer.

```csharp
RetrieveSettlementAsync(string locationId, string settlementId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the settlements's associated location. |
| `settlementId` | `string` | Template, Required | The settlement's Square-issued ID. You obtain this value from Settlement objects returned by the List Settlements endpoint. |

### Response Type

[`Task<Models.V1Settlement>`](/doc/models/v1-settlement.md)

### Example Usage

```csharp
string locationId = "location_id4";
string settlementId = "settlement_id0";

try
{
    V1Settlement result = await v1TransactionsApi.RetrieveSettlementAsync(locationId, settlementId);
}
catch (ApiException e){};
```

