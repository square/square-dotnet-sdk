# Refunds

```csharp
IRefundsApi refundsApi = client.RefundsApi;
```

## Class Name

`RefundsApi`

## Methods

* [List Payment Refunds](/doc/refunds.md#list-payment-refunds)
* [Refund Payment](/doc/refunds.md#refund-payment)
* [Get Payment Refund](/doc/refunds.md#get-payment-refund)

## List Payment Refunds

Retrieves a list of refunds for the account making the request.

Max results per page: 100

```csharp
ListPaymentRefundsAsync(
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null,
    string locationId = null,
    string status = null,
    string sourceType = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `beginTime` | `string` | Query, Optional | Timestamp for the beginning of the requested reporting period, in RFC 3339 format.<br><br>Default: The current time minus one year. |
| `endTime` | `string` | Query, Optional | Timestamp for the end of the requested reporting period, in RFC 3339 format.<br><br>Default: The current time. |
| `sortOrder` | `string` | Query, Optional | The order in which results are listed.<br>- `ASC` - oldest to newest<br>- `DESC` - newest to oldest (default). |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for the original query.<br><br>See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information. |
| `locationId` | `string` | Query, Optional | ID of location associated with payment. |
| `status` | `string` | Query, Optional | If provided, only refunds with the given status are returned.<br>For a list of refund status values, see [PaymentRefund](#type-paymentrefund).<br><br>Default: If omitted refunds are returned regardless of status. |
| `sourceType` | `string` | Query, Optional | If provided, only refunds with the given source type are returned.<br>- `CARD` - List refunds only for payments where card was specified as payment<br>source.<br><br>Default: If omitted refunds are returned regardless of source type. |

### Response Type

[`Task<Models.ListPaymentRefundsResponse>`](/doc/models/list-payment-refunds-response.md)

### Example Usage

```csharp
try
{
    ListPaymentRefundsResponse result = await refundsApi.ListPaymentRefundsAsync(null, null, null, null, null, null, null);
}
catch (ApiException e){};
```

## Refund Payment

Refunds a payment. You can refund the entire payment amount or a 
portion of it. For more information, see 
[Payments and Refunds Overview](https://developer.squareup.com/docs/payments-api/overview).

```csharp
RefundPaymentAsync(Models.RefundPaymentRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.RefundPaymentRequest`](/doc/models/refund-payment-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.RefundPaymentResponse>`](/doc/models/refund-payment-response.md)

### Example Usage

```csharp
var bodyAmountMoney = new Money.Builder()
    .Amount(100L)
    .Currency("USD")
    .Build();
var body = new RefundPaymentRequest.Builder(
        "a7e36d40-d24b-11e8-b568-0800200c9a66",
        bodyAmountMoney,
        "UNOE3kv2BZwqHlJ830RCt5YCuaB")
    .Build();

try
{
    RefundPaymentResponse result = await refundsApi.RefundPaymentAsync(body);
}
catch (ApiException e){};
```

## Get Payment Refund

Retrieves a specific `Refund` using the `refund_id`.

```csharp
GetPaymentRefundAsync(string refundId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `refundId` | `string` | Template, Required | Unique ID for the desired `PaymentRefund`. |

### Response Type

[`Task<Models.GetPaymentRefundResponse>`](/doc/models/get-payment-refund-response.md)

### Example Usage

```csharp
string refundId = "refund_id4";

try
{
    GetPaymentRefundResponse result = await refundsApi.GetPaymentRefundAsync(refundId);
}
catch (ApiException e){};
```

