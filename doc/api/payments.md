# Payments

```csharp
IPaymentsApi paymentsApi = client.PaymentsApi;
```

## Class Name

`PaymentsApi`

## Methods

* [List Payments](../../doc/api/payments.md#list-payments)
* [Create Payment](../../doc/api/payments.md#create-payment)
* [Cancel Payment by Idempotency Key](../../doc/api/payments.md#cancel-payment-by-idempotency-key)
* [Get Payment](../../doc/api/payments.md#get-payment)
* [Update Payment](../../doc/api/payments.md#update-payment)
* [Cancel Payment](../../doc/api/payments.md#cancel-payment)
* [Complete Payment](../../doc/api/payments.md#complete-payment)


# List Payments

Retrieves a list of payments taken by the account making the request.

Results are eventually consistent, and new payments or changes to payments might take several
seconds to appear.

The maximum results per page is 100.

```csharp
ListPaymentsAsync(
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null,
    string locationId = null,
    long? total = null,
    string last4 = null,
    string cardBrand = null,
    int? limit = null,
    bool? isOfflinePayment = false,
    string offlineBeginTime = null,
    string offlineEndTime = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `beginTime` | `string` | Query, Optional | Indicates the start of the time range to retrieve payments for, in RFC 3339 format.  <br>The range is determined using the `created_at` field for each Payment.<br>Inclusive. Default: The current time minus one year. |
| `endTime` | `string` | Query, Optional | Indicates the end of the time range to retrieve payments for, in RFC 3339 format.  The<br>range is determined using the `created_at` field for each Payment.<br><br>Default: The current time. |
| `sortOrder` | `string` | Query, Optional | The order in which results are listed by `Payment.created_at`:<br><br>- `ASC` - Oldest to newest.<br>- `DESC` - Newest to oldest (default). |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `locationId` | `string` | Query, Optional | Limit results to the location supplied. By default, results are returned<br>for the default (main) location associated with the seller. |
| `total` | `long?` | Query, Optional | The exact amount in the `total_money` for a payment. |
| `last4` | `string` | Query, Optional | The last four digits of a payment card. |
| `cardBrand` | `string` | Query, Optional | The brand of the payment card (for example, VISA). |
| `limit` | `int?` | Query, Optional | The maximum number of results to be returned in a single page.<br>It is possible to receive fewer results than the specified limit on a given page.<br><br>The default value of 100 is also the maximum allowed value. If the provided value is<br>greater than 100, it is ignored and the default value is used instead.<br><br>Default: `100` |
| `isOfflinePayment` | `bool?` | Query, Optional | Whether the payment was taken offline or not. |
| `offlineBeginTime` | `string` | Query, Optional | Indicates the start of the time range for which to retrieve offline payments, in RFC 3339<br>format for timestamps. The range is determined using the<br>`offline_payment_details.client_created_at` field for each Payment. If set, payments without a<br>value set in `offline_payment_details.client_created_at` will not be returned.<br><br>Default: The current time. |
| `offlineEndTime` | `string` | Query, Optional | Indicates the end of the time range for which to retrieve offline payments, in RFC 3339<br>format for timestamps. The range is determined using the<br>`offline_payment_details.client_created_at` field for each Payment. If set, payments without a<br>value set in `offline_payment_details.client_created_at` will not be returned.<br><br>Default: The current time. |

## Response Type

[`Task<Models.ListPaymentsResponse>`](../../doc/models/list-payments-response.md)

## Example Usage

```csharp
bool? isOfflinePayment = false;
try
{
    ListPaymentsResponse result = await paymentsApi.ListPaymentsAsync(
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        isOfflinePayment
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Payment

Creates a payment using the provided source. You can use this endpoint
to charge a card (credit/debit card or  
Square gift card) or record a payment that the seller received outside of Square
(cash payment from a buyer or a payment that an external entity
processed on behalf of the seller).

The endpoint creates a
`Payment` object and returns it in the response.

```csharp
CreatePaymentAsync(
    Models.CreatePaymentRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreatePaymentRequest`](../../doc/models/create-payment-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreatePaymentResponse>`](../../doc/models/create-payment-response.md)

## Example Usage

```csharp
Models.CreatePaymentRequest body = new Models.CreatePaymentRequest.Builder(
    "ccof:GaJGNaZa8x4OgDJn4GB",
    "7b0f3ec5-086a-4871-8f13-3c81b3875218"
)
.AmountMoney(
    new Models.Money.Builder()
    .Amount(1000L)
    .Currency("USD")
    .Build())
.AppFeeMoney(
    new Models.Money.Builder()
    .Amount(10L)
    .Currency("USD")
    .Build())
.Autocomplete(true)
.CustomerId("W92WH6P11H4Z77CTET0RNTGFW8")
.LocationId("L88917AVBK2S5")
.ReferenceId("123456")
.Note("Brief description")
.Build();

try
{
    CreatePaymentResponse result = await paymentsApi.CreatePaymentAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Cancel Payment by Idempotency Key

Cancels (voids) a payment identified by the idempotency key that is specified in the
request.

Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a
`CreatePayment` request, a network error occurs and you do not get a response). In this case, you can
direct Square to cancel the payment using this endpoint. In the request, you provide the same
idempotency key that you provided in your `CreatePayment` request that you want to cancel. After
canceling the payment, you can submit your `CreatePayment` request again.

Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint
returns successfully.

```csharp
CancelPaymentByIdempotencyKeyAsync(
    Models.CancelPaymentByIdempotencyKeyRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CancelPaymentByIdempotencyKeyRequest`](../../doc/models/cancel-payment-by-idempotency-key-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CancelPaymentByIdempotencyKeyResponse>`](../../doc/models/cancel-payment-by-idempotency-key-response.md)

## Example Usage

```csharp
Models.CancelPaymentByIdempotencyKeyRequest body = new Models.CancelPaymentByIdempotencyKeyRequest.Builder(
    "a7e36d40-d24b-11e8-b568-0800200c9a66"
)
.Build();

try
{
    CancelPaymentByIdempotencyKeyResponse result = await paymentsApi.CancelPaymentByIdempotencyKeyAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Payment

Retrieves details for a specific payment.

```csharp
GetPaymentAsync(
    string paymentId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paymentId` | `string` | Template, Required | A unique ID for the desired payment. |

## Response Type

[`Task<Models.GetPaymentResponse>`](../../doc/models/get-payment-response.md)

## Example Usage

```csharp
string paymentId = "payment_id0";
try
{
    GetPaymentResponse result = await paymentsApi.GetPaymentAsync(paymentId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Payment

Updates a payment with the APPROVED status.
You can update the `amount_money` and `tip_money` using this endpoint.

```csharp
UpdatePaymentAsync(
    string paymentId,
    Models.UpdatePaymentRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paymentId` | `string` | Template, Required | The ID of the payment to update. |
| `body` | [`UpdatePaymentRequest`](../../doc/models/update-payment-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdatePaymentResponse>`](../../doc/models/update-payment-response.md)

## Example Usage

```csharp
string paymentId = "payment_id0";
Models.UpdatePaymentRequest body = new Models.UpdatePaymentRequest.Builder(
    "956f8b13-e4ec-45d6-85e8-d1d95ef0c5de"
)
.Payment(
    new Models.Payment.Builder()
    .AmountMoney(
        new Models.Money.Builder()
        .Amount(1000L)
        .Currency("USD")
        .Build())
    .TipMoney(
        new Models.Money.Builder()
        .Amount(100L)
        .Currency("USD")
        .Build())
    .VersionToken("ODhwVQ35xwlzRuoZEwKXucfu7583sPTzK48c5zoGd0g6o")
    .Build())
.Build();

try
{
    UpdatePaymentResponse result = await paymentsApi.UpdatePaymentAsync(
        paymentId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Cancel Payment

Cancels (voids) a payment. You can use this endpoint to cancel a payment with
the APPROVED `status`.

```csharp
CancelPaymentAsync(
    string paymentId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paymentId` | `string` | Template, Required | The ID of the payment to cancel. |

## Response Type

[`Task<Models.CancelPaymentResponse>`](../../doc/models/cancel-payment-response.md)

## Example Usage

```csharp
string paymentId = "payment_id0";
try
{
    CancelPaymentResponse result = await paymentsApi.CancelPaymentAsync(paymentId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Complete Payment

Completes (captures) a payment.
By default, payments are set to complete immediately after they are created.

You can use this endpoint to complete a payment with the APPROVED `status`.

```csharp
CompletePaymentAsync(
    string paymentId,
    Models.CompletePaymentRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `paymentId` | `string` | Template, Required | The unique ID identifying the payment to be completed. |
| `body` | [`CompletePaymentRequest`](../../doc/models/complete-payment-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CompletePaymentResponse>`](../../doc/models/complete-payment-response.md)

## Example Usage

```csharp
string paymentId = "payment_id0";
Models.CompletePaymentRequest body = new Models.CompletePaymentRequest.Builder()
.Build();

try
{
    CompletePaymentResponse result = await paymentsApi.CompletePaymentAsync(
        paymentId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

