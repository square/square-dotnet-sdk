# Payments

```csharp
IPaymentsApi paymentsApi = client.PaymentsApi;
```

## Class Name

`PaymentsApi`

## Methods

* [List Payments](/doc/payments.md#list-payments)
* [Create Payment](/doc/payments.md#create-payment)
* [Cancel Payment by Idempotency Key](/doc/payments.md#cancel-payment-by-idempotency-key)
* [Get Payment](/doc/payments.md#get-payment)
* [Cancel Payment](/doc/payments.md#cancel-payment)
* [Complete Payment](/doc/payments.md#complete-payment)

## List Payments

Retrieves a list of payments taken by the account making the request.

Max results per page: 100

```csharp
ListPaymentsAsync(
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null,
    string locationId = null,
    long? total = null,
    string last4 = null,
    string cardBrand = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `beginTime` | `string` | Query, Optional | Timestamp for the beginning of the reporting period, in RFC 3339 format.<br>Inclusive. Default: The current time minus one year. |
| `endTime` | `string` | Query, Optional | Timestamp for the end of the requested reporting period, in RFC 3339 format.<br><br>Default: The current time. |
| `sortOrder` | `string` | Query, Optional | The order in which results are listed.<br>- `ASC` - oldest to newest<br>- `DESC` - newest to oldest (default). |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for the original query.<br><br>See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information. |
| `locationId` | `string` | Query, Optional | Limit results to the location supplied. By default, results are returned<br>for all locations associated with the merchant. |
| `total` | `long?` | Query, Optional | The exact amount in the total_money for a `Payment`. |
| `last4` | `string` | Query, Optional | The last 4 digits of `Payment` card. |
| `cardBrand` | `string` | Query, Optional | The brand of `Payment` card. For example, `VISA` |

### Response Type

[`Task<Models.ListPaymentsResponse>`](/doc/models/list-payments-response.md)

### Example Usage

```csharp
string beginTime = "begin_time2";
string endTime = "end_time2";
string sortOrder = "sort_order0";
string cursor = "cursor6";
string locationId = "location_id4";
long? total = 10L;
string last4 = "last_42";
string cardBrand = "card_brand6";

try
{
    ListPaymentsResponse result = await paymentsApi.ListPaymentsAsync(beginTime, endTime, sortOrder, cursor, locationId, total, last4, cardBrand);
}
catch (ApiException e){};
```

## Create Payment

Charges a payment source, for example, a card 
represented by customer's card on file or a card nonce. In addition 
to the payment source, the request must also include the 
amount to accept for the payment.

There are several optional parameters that you can include in the request. 
For example, tip money, whether to autocomplete the payment, or a reference ID
to correlate this payment with another system. 
For more information about these 
payment options, see [Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).

The `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission is required
to enable application fees.

```csharp
CreatePaymentAsync(Models.CreatePaymentRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreatePaymentRequest`](/doc/models/create-payment-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreatePaymentResponse>`](/doc/models/create-payment-response.md)

### Example Usage

```csharp
var bodyAmountMoney = new Money.Builder()
    .Amount(200L)
    .Currency("USD")
    .Build();
var bodyTipMoney = new Money.Builder()
    .Amount(198L)
    .Currency("CHF")
    .Build();
var bodyAppFeeMoney = new Money.Builder()
    .Amount(10L)
    .Currency("USD")
    .Build();
var body = new CreatePaymentRequest.Builder(
        "ccof:uIbfJXhXETSP197M3GB",
        "4935a656-a929-4792-b97c-8848be85c27c",
        bodyAmountMoney)
    .TipMoney(bodyTipMoney)
    .AppFeeMoney(bodyAppFeeMoney)
    .DelayDuration("delay_duration6")
    .Autocomplete(true)
    .OrderId("order_id0")
    .CustomerId("VDKXEEKPJN48QDG3BGGFAK05P8")
    .LocationId("XK3DBG77NJBFX")
    .ReferenceId("123456")
    .Note("Brief description")
    .Build();

try
{
    CreatePaymentResponse result = await paymentsApi.CreatePaymentAsync(body);
}
catch (ApiException e){};
```

## Cancel Payment by Idempotency Key

Cancels (voids) a payment identified by the idempotency key that is specified in the
request.

Use this method when status of a CreatePayment request is unknown. For example, after you send a
CreatePayment request a network error occurs and you don't get a response. In this case, you can
direct Square to cancel the payment using this endpoint. In the request, you provide the same
idempotency key that you provided in your CreatePayment request you want  to cancel. After
cancelling the payment, you can submit your CreatePayment request again.

Note that if no payment with the specified idempotency key is found, no action is taken, the end
point returns successfully.

```csharp
CancelPaymentByIdempotencyKeyAsync(Models.CancelPaymentByIdempotencyKeyRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CancelPaymentByIdempotencyKeyRequest`](/doc/models/cancel-payment-by-idempotency-key-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CancelPaymentByIdempotencyKeyResponse>`](/doc/models/cancel-payment-by-idempotency-key-response.md)

### Example Usage

```csharp
var body = new CancelPaymentByIdempotencyKeyRequest.Builder(
        "a7e36d40-d24b-11e8-b568-0800200c9a66")
    .Build();

try
{
    CancelPaymentByIdempotencyKeyResponse result = await paymentsApi.CancelPaymentByIdempotencyKeyAsync(body);
}
catch (ApiException e){};
```

## Get Payment

Retrieves details for a specific Payment.

```csharp
GetPaymentAsync(string paymentId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paymentId` | `string` | Template, Required | Unique ID for the desired `Payment`. |

### Response Type

[`Task<Models.GetPaymentResponse>`](/doc/models/get-payment-response.md)

### Example Usage

```csharp
string paymentId = "payment_id0";

try
{
    GetPaymentResponse result = await paymentsApi.GetPaymentAsync(paymentId);
}
catch (ApiException e){};
```

## Cancel Payment

Cancels (voids) a payment. If you set `autocomplete` to false when creating a payment, 
you can cancel the payment using this endpoint. For more information, see 
[Delayed Payments](https://developer.squareup.com/docs/payments-api/take-payments#delayed-payments).

```csharp
CancelPaymentAsync(string paymentId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paymentId` | `string` | Template, Required | `payment_id` identifying the payment to be canceled. |

### Response Type

[`Task<Models.CancelPaymentResponse>`](/doc/models/cancel-payment-response.md)

### Example Usage

```csharp
string paymentId = "payment_id0";

try
{
    CancelPaymentResponse result = await paymentsApi.CancelPaymentAsync(paymentId);
}
catch (ApiException e){};
```

## Complete Payment

Completes (captures) a payment.

By default, payments are set to complete immediately after they are created. 
If you set autocomplete to false when creating a payment, you can complete (capture) 
the payment using this endpoint. For more information, see
[Delayed Payments](https://developer.squareup.com/docs/payments-api/take-payments#delayed-payments).

```csharp
CompletePaymentAsync(string paymentId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paymentId` | `string` | Template, Required | Unique ID identifying the payment to be completed. |

### Response Type

[`Task<Models.CompletePaymentResponse>`](/doc/models/complete-payment-response.md)

### Example Usage

```csharp
string paymentId = "payment_id0";

try
{
    CompletePaymentResponse result = await paymentsApi.CompletePaymentAsync(paymentId);
}
catch (ApiException e){};
```

