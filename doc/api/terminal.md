# Terminal

```csharp
ITerminalApi terminalApi = client.TerminalApi;
```

## Class Name

`TerminalApi`

## Methods

* [Create Terminal Checkout](../../doc/api/terminal.md#create-terminal-checkout)
* [Search Terminal Checkouts](../../doc/api/terminal.md#search-terminal-checkouts)
* [Get Terminal Checkout](../../doc/api/terminal.md#get-terminal-checkout)
* [Cancel Terminal Checkout](../../doc/api/terminal.md#cancel-terminal-checkout)
* [Create Terminal Refund](../../doc/api/terminal.md#create-terminal-refund)
* [Search Terminal Refunds](../../doc/api/terminal.md#search-terminal-refunds)
* [Get Terminal Refund](../../doc/api/terminal.md#get-terminal-refund)
* [Cancel Terminal Refund](../../doc/api/terminal.md#cancel-terminal-refund)


# Create Terminal Checkout

Creates a Terminal checkout request and sends it to the specified device to take a payment
for the requested amount.

```csharp
CreateTerminalCheckoutAsync(
    Models.CreateTerminalCheckoutRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateTerminalCheckoutRequest`](../../doc/models/create-terminal-checkout-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateTerminalCheckoutResponse>`](../../doc/models/create-terminal-checkout-response.md)

## Example Usage

```csharp
var bodyCheckoutAmountMoney = new Money.Builder()
    .Amount(2610L)
    .Currency("USD")
    .Build();
var bodyCheckoutDeviceOptionsTipSettingsTipPercentages = new IList<int>();
bodyCheckoutDeviceOptionsTipSettingsTipPercentages.Add(148);
bodyCheckoutDeviceOptionsTipSettingsTipPercentages.Add(149);
bodyCheckoutDeviceOptionsTipSettingsTipPercentages.Add(150);
var bodyCheckoutDeviceOptionsTipSettings = new TipSettings.Builder()
    .AllowTipping(false)
    .SeparateTipScreen(false)
    .CustomTipField(false)
    .TipPercentages(bodyCheckoutDeviceOptionsTipSettingsTipPercentages)
    .SmartTipping(false)
    .Build();
var bodyCheckoutDeviceOptions = new DeviceCheckoutOptions.Builder(
        "dbb5d83a-7838-11ea-bc55-0242ac130003")
    .SkipReceiptScreen(false)
    .TipSettings(bodyCheckoutDeviceOptionsTipSettings)
    .Build();
var bodyCheckout = new TerminalCheckout.Builder(
        bodyCheckoutAmountMoney,
        bodyCheckoutDeviceOptions)
    .Id("id8")
    .ReferenceId("id11572")
    .Note("A brief note")
    .DeadlineDuration("deadline_duration0")
    .Status("status0")
    .Build();
var body = new CreateTerminalCheckoutRequest.Builder(
        "28a0c3bc-7839-11ea-bc55-0242ac130003",
        bodyCheckout)
    .Build();

try
{
    CreateTerminalCheckoutResponse result = await terminalApi.CreateTerminalCheckoutAsync(body);
}
catch (ApiException e){};
```


# Search Terminal Checkouts

Retrieves a filtered list of Terminal checkout requests created by the account making the request.

```csharp
SearchTerminalCheckoutsAsync(
    Models.SearchTerminalCheckoutsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchTerminalCheckoutsRequest`](../../doc/models/search-terminal-checkouts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchTerminalCheckoutsResponse>`](../../doc/models/search-terminal-checkouts-response.md)

## Example Usage

```csharp
var bodyQueryFilterCreatedAt = new TimeRange.Builder()
    .StartAt("start_at2")
    .EndAt("end_at0")
    .Build();
var bodyQueryFilter = new TerminalCheckoutQueryFilter.Builder()
    .DeviceId("device_id8")
    .CreatedAt(bodyQueryFilterCreatedAt)
    .Status("COMPLETED")
    .Build();
var bodyQuerySort = new TerminalCheckoutQuerySort.Builder()
    .SortOrder("DESC")
    .Build();
var bodyQuery = new TerminalCheckoutQuery.Builder()
    .Filter(bodyQueryFilter)
    .Sort(bodyQuerySort)
    .Build();
var body = new SearchTerminalCheckoutsRequest.Builder()
    .Query(bodyQuery)
    .Cursor("cursor0")
    .Limit(2)
    .Build();

try
{
    SearchTerminalCheckoutsResponse result = await terminalApi.SearchTerminalCheckoutsAsync(body);
}
catch (ApiException e){};
```


# Get Terminal Checkout

Retrieves a Terminal checkout request by `checkout_id`.

```csharp
GetTerminalCheckoutAsync(
    string checkoutId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `checkoutId` | `string` | Template, Required | The unique ID for the desired `TerminalCheckout`. |

## Response Type

[`Task<Models.GetTerminalCheckoutResponse>`](../../doc/models/get-terminal-checkout-response.md)

## Example Usage

```csharp
string checkoutId = "checkout_id8";

try
{
    GetTerminalCheckoutResponse result = await terminalApi.GetTerminalCheckoutAsync(checkoutId);
}
catch (ApiException e){};
```


# Cancel Terminal Checkout

Cancels a Terminal checkout request if the status of the request permits it.

```csharp
CancelTerminalCheckoutAsync(
    string checkoutId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `checkoutId` | `string` | Template, Required | The unique ID for the desired `TerminalCheckout`. |

## Response Type

[`Task<Models.CancelTerminalCheckoutResponse>`](../../doc/models/cancel-terminal-checkout-response.md)

## Example Usage

```csharp
string checkoutId = "checkout_id8";

try
{
    CancelTerminalCheckoutResponse result = await terminalApi.CancelTerminalCheckoutAsync(checkoutId);
}
catch (ApiException e){};
```


# Create Terminal Refund

Creates a request to refund an Interac payment completed on a Square Terminal.

```csharp
CreateTerminalRefundAsync(
    Models.CreateTerminalRefundRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateTerminalRefundRequest`](../../doc/models/create-terminal-refund-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateTerminalRefundResponse>`](../../doc/models/create-terminal-refund-response.md)

## Example Usage

```csharp
var bodyRefundAmountMoney = new Money.Builder()
    .Amount(111L)
    .Currency("CAD")
    .Build();
var bodyRefund = new TerminalRefund.Builder(
        "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
        bodyRefundAmountMoney)
    .Id("id4")
    .RefundId("refund_id8")
    .OrderId("order_id8")
    .Reason("Returning items")
    .DeviceId("f72dfb8e-4d65-4e56-aade-ec3fb8d33291")
    .Build();
var body = new CreateTerminalRefundRequest.Builder(
        "402a640b-b26f-401f-b406-46f839590c04")
    .Refund(bodyRefund)
    .Build();

try
{
    CreateTerminalRefundResponse result = await terminalApi.CreateTerminalRefundAsync(body);
}
catch (ApiException e){};
```


# Search Terminal Refunds

Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request.

```csharp
SearchTerminalRefundsAsync(
    Models.SearchTerminalRefundsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchTerminalRefundsRequest`](../../doc/models/search-terminal-refunds-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchTerminalRefundsResponse>`](../../doc/models/search-terminal-refunds-response.md)

## Example Usage

```csharp
var bodyQueryFilterCreatedAt = new TimeRange.Builder()
    .StartAt("start_at2")
    .EndAt("end_at0")
    .Build();
var bodyQueryFilter = new TerminalRefundQueryFilter.Builder()
    .DeviceId("device_id8")
    .CreatedAt(bodyQueryFilterCreatedAt)
    .Status("COMPLETED")
    .Build();
var bodyQuerySort = new TerminalRefundQuerySort.Builder()
    .SortOrder("sort_order8")
    .Build();
var bodyQuery = new TerminalRefundQuery.Builder()
    .Filter(bodyQueryFilter)
    .Sort(bodyQuerySort)
    .Build();
var body = new SearchTerminalRefundsRequest.Builder()
    .Query(bodyQuery)
    .Cursor("cursor0")
    .Limit(1)
    .Build();

try
{
    SearchTerminalRefundsResponse result = await terminalApi.SearchTerminalRefundsAsync(body);
}
catch (ApiException e){};
```


# Get Terminal Refund

Retrieves an Interac Terminal refund object by ID.

```csharp
GetTerminalRefundAsync(
    string terminalRefundId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `terminalRefundId` | `string` | Template, Required | The unique ID for the desired `TerminalRefund`. |

## Response Type

[`Task<Models.GetTerminalRefundResponse>`](../../doc/models/get-terminal-refund-response.md)

## Example Usage

```csharp
string terminalRefundId = "terminal_refund_id0";

try
{
    GetTerminalRefundResponse result = await terminalApi.GetTerminalRefundAsync(terminalRefundId);
}
catch (ApiException e){};
```


# Cancel Terminal Refund

Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.

```csharp
CancelTerminalRefundAsync(
    string terminalRefundId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `terminalRefundId` | `string` | Template, Required | The unique ID for the desired `TerminalRefund`. |

## Response Type

[`Task<Models.CancelTerminalRefundResponse>`](../../doc/models/cancel-terminal-refund-response.md)

## Example Usage

```csharp
string terminalRefundId = "terminal_refund_id0";

try
{
    CancelTerminalRefundResponse result = await terminalApi.CancelTerminalRefundAsync(terminalRefundId);
}
catch (ApiException e){};
```

