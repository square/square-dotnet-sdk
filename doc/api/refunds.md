# Refunds

```csharp
IRefundsApi refundsApi = client.RefundsApi;
```

## Class Name

`RefundsApi`

## Methods

* [List Payment Refunds](../../doc/api/refunds.md#list-payment-refunds)
* [Refund Payment](../../doc/api/refunds.md#refund-payment)
* [Get Payment Refund](../../doc/api/refunds.md#get-payment-refund)


# List Payment Refunds

Retrieves a list of refunds for the account making the request.

Results are eventually consistent, and new refunds or changes to refunds might take several
seconds to appear.

The maximum results per page is 100.

```csharp
ListPaymentRefundsAsync(
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null,
    string locationId = null,
    string status = null,
    string sourceType = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `beginTime` | `string` | Query, Optional | The timestamp for the beginning of the requested reporting period, in RFC 3339 format.<br><br>Default: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The timestamp for the end of the requested reporting period, in RFC 3339 format.<br><br>Default: The current time. |
| `sortOrder` | `string` | Query, Optional | The order in which results are listed:<br><br>- `ASC` - Oldest to newest.<br>- `DESC` - Newest to oldest (default). |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br><br>For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination). |
| `locationId` | `string` | Query, Optional | Limit results to the location supplied. By default, results are returned<br>for all locations associated with the seller. |
| `status` | `string` | Query, Optional | If provided, only refunds with the given status are returned.<br>For a list of refund status values, see [PaymentRefund](../../doc/models/payment-refund.md).<br><br>Default: If omitted, refunds are returned regardless of their status. |
| `sourceType` | `string` | Query, Optional | If provided, only returns refunds whose payments have the indicated source type.<br>Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `CASH`, and `EXTERNAL`.<br>For information about these payment source types, see<br>[Take Payments](https://developer.squareup.com/docs/payments-api/take-payments).<br><br>Default: If omitted, refunds are returned regardless of the source type. |
| `limit` | `int?` | Query, Optional | The maximum number of results to be returned in a single page.<br><br>It is possible to receive fewer results than the specified limit on a given page.<br><br>If the supplied value is greater than 100, no more than 100 results are returned.<br><br>Default: 100 |

## Response Type

[`Task<Models.ListPaymentRefundsResponse>`](../../doc/models/list-payment-refunds-response.md)

## Example Usage

```csharp
try
{
    ListPaymentRefundsResponse result = await refundsApi.ListPaymentRefundsAsync(null, null, null, null, null, null, null, null);
}
catch (ApiException e){};
```


# Refund Payment

Refunds a payment. You can refund the entire payment amount or a
portion of it. You can use this endpoint to refund a card payment or record a
refund of a cash or external payment. For more information, see
[Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).

```csharp
RefundPaymentAsync(
    Models.RefundPaymentRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.RefundPaymentRequest`](../../doc/models/refund-payment-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.RefundPaymentResponse>`](../../doc/models/refund-payment-response.md)

## Example Usage

```csharp
var bodyAmountMoney = new Money.Builder()
    .Amount(1000L)
    .Currency("USD")
    .Build();
var bodyAppFeeMoney = new Money.Builder()
    .Amount(10L)
    .Currency("USD")
    .Build();
var body = new RefundPaymentRequest.Builder(
        "9b7f2dcf-49da-4411-b23e-a2d6af21333a",
        bodyAmountMoney)
    .AppFeeMoney(bodyAppFeeMoney)
    .PaymentId("R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY")
    .Reason("Example")
    .Build();

try
{
    RefundPaymentResponse result = await refundsApi.RefundPaymentAsync(body);
}
catch (ApiException e){};
```


# Get Payment Refund

Retrieves a specific refund using the `refund_id`.

```csharp
GetPaymentRefundAsync(
    string refundId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `refundId` | `string` | Template, Required | The unique ID for the desired `PaymentRefund`. |

## Response Type

[`Task<Models.GetPaymentRefundResponse>`](../../doc/models/get-payment-refund-response.md)

## Example Usage

```csharp
string refundId = "refund_id4";

try
{
    GetPaymentRefundResponse result = await refundsApi.GetPaymentRefundAsync(refundId);
}
catch (ApiException e){};
```

