# Terminal

```csharp
ITerminalApi terminalApi = client.TerminalApi;
```

## Class Name

`TerminalApi`

## Methods

* [Create Terminal Checkout](/doc/terminal.md#create-terminal-checkout)
* [Search Terminal Checkouts](/doc/terminal.md#search-terminal-checkouts)
* [Get Terminal Checkout](/doc/terminal.md#get-terminal-checkout)
* [Cancel Terminal Checkout](/doc/terminal.md#cancel-terminal-checkout)

## Create Terminal Checkout

Creates a new Terminal checkout request and sends it to the specified device to take a payment for the requested amount.

```csharp
CreateTerminalCheckoutAsync(Models.CreateTerminalCheckoutRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateTerminalCheckoutRequest`](/doc/models/create-terminal-checkout-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateTerminalCheckoutResponse>`](/doc/models/create-terminal-checkout-response.md)

### Example Usage

```csharp
var bodyCheckoutAmountMoney = new Money.Builder()
    .Amount(2610L)
    .Currency("USD")
    .Build();
var bodyCheckoutDeviceOptionsTipSettings = new TipSettings.Builder()
    .AllowTipping(false)
    .SeparateTipScreen(false)
    .CustomTipField(false)
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

## Search Terminal Checkouts

Retrieves a filtered list of Terminal checkout requests created by the account making the request.

```csharp
SearchTerminalCheckoutsAsync(Models.SearchTerminalCheckoutsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchTerminalCheckoutsRequest`](/doc/models/search-terminal-checkouts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchTerminalCheckoutsResponse>`](/doc/models/search-terminal-checkouts-response.md)

### Example Usage

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
    .SortOrder("sort_order8")
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

## Get Terminal Checkout

Retrieves a Terminal checkout request by checkout_id.

```csharp
GetTerminalCheckoutAsync(string checkoutId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `checkoutId` | `string` | Template, Required | Unique ID for the desired `TerminalCheckout` |

### Response Type

[`Task<Models.GetTerminalCheckoutResponse>`](/doc/models/get-terminal-checkout-response.md)

### Example Usage

```csharp
string checkoutId = "checkout_id8";

try
{
    GetTerminalCheckoutResponse result = await terminalApi.GetTerminalCheckoutAsync(checkoutId);
}
catch (ApiException e){};
```

## Cancel Terminal Checkout

Cancels a Terminal checkout request, if the status of the request permits it.

```csharp
CancelTerminalCheckoutAsync(string checkoutId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `checkoutId` | `string` | Template, Required | Unique ID for the desired `TerminalCheckout` |

### Response Type

[`Task<Models.CancelTerminalCheckoutResponse>`](/doc/models/cancel-terminal-checkout-response.md)

### Example Usage

```csharp
string checkoutId = "checkout_id8";

try
{
    CancelTerminalCheckoutResponse result = await terminalApi.CancelTerminalCheckoutAsync(checkoutId);
}
catch (ApiException e){};
```

