# Terminal

```csharp
ITerminalApi terminalApi = client.TerminalApi;
```

## Class Name

`TerminalApi`

## Methods

* [Create Terminal Action](../../doc/api/terminal.md#create-terminal-action)
* [Search Terminal Actions](../../doc/api/terminal.md#search-terminal-actions)
* [Get Terminal Action](../../doc/api/terminal.md#get-terminal-action)
* [Cancel Terminal Action](../../doc/api/terminal.md#cancel-terminal-action)
* [Create Terminal Checkout](../../doc/api/terminal.md#create-terminal-checkout)
* [Search Terminal Checkouts](../../doc/api/terminal.md#search-terminal-checkouts)
* [Get Terminal Checkout](../../doc/api/terminal.md#get-terminal-checkout)
* [Cancel Terminal Checkout](../../doc/api/terminal.md#cancel-terminal-checkout)
* [Create Terminal Refund](../../doc/api/terminal.md#create-terminal-refund)
* [Search Terminal Refunds](../../doc/api/terminal.md#search-terminal-refunds)
* [Get Terminal Refund](../../doc/api/terminal.md#get-terminal-refund)
* [Cancel Terminal Refund](../../doc/api/terminal.md#cancel-terminal-refund)


# Create Terminal Action

Creates a Terminal action request and sends it to the specified device to take a payment
for the requested amount.

```csharp
CreateTerminalActionAsync(
    Models.CreateTerminalActionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateTerminalActionRequest`](../../doc/models/create-terminal-action-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateTerminalActionResponse>`](../../doc/models/create-terminal-action-response.md)

## Example Usage

```csharp
var bodyActionSaveCardOptions = new SaveCardOptions.Builder(
        "{{CUSTOMER_ID}}")
    .ReferenceId("user-id-1")
    .Build();
var bodyAction = new TerminalAction.Builder()
    .DeviceId("{{DEVICE_ID}}")
    .DeadlineDuration("PT5M")
    .Type("SAVE_CARD")
    .SaveCardOptions(bodyActionSaveCardOptions)
    .Build();
var body = new CreateTerminalActionRequest.Builder(
        "thahn-70e75c10-47f7-4ab6-88cc-aaa4076d065e",
        bodyAction)
    .Build();

try
{
    CreateTerminalActionResponse result = await terminalApi.CreateTerminalActionAsync(body);
}
catch (ApiException e){};
```


# Search Terminal Actions

Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.

```csharp
SearchTerminalActionsAsync(
    Models.SearchTerminalActionsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchTerminalActionsRequest`](../../doc/models/search-terminal-actions-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchTerminalActionsResponse>`](../../doc/models/search-terminal-actions-response.md)

## Example Usage

```csharp
var bodyQueryFilterCreatedAt = new TimeRange.Builder()
    .StartAt("2022-04-01T00:00:00.000Z")
    .Build();
var bodyQueryFilter = new TerminalActionQueryFilter.Builder()
    .CreatedAt(bodyQueryFilterCreatedAt)
    .Build();
var bodyQuerySort = new TerminalActionQuerySort.Builder()
    .SortOrder("DESC")
    .Build();
var bodyQuery = new TerminalActionQuery.Builder()
    .Filter(bodyQueryFilter)
    .Sort(bodyQuerySort)
    .Build();
var body = new SearchTerminalActionsRequest.Builder()
    .Query(bodyQuery)
    .Limit(2)
    .Build();

try
{
    SearchTerminalActionsResponse result = await terminalApi.SearchTerminalActionsAsync(body);
}
catch (ApiException e){};
```


# Get Terminal Action

Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.

```csharp
GetTerminalActionAsync(
    string actionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `actionId` | `string` | Template, Required | Unique ID for the desired `TerminalAction` |

## Response Type

[`Task<Models.GetTerminalActionResponse>`](../../doc/models/get-terminal-action-response.md)

## Example Usage

```csharp
string actionId = "action_id6";

try
{
    GetTerminalActionResponse result = await terminalApi.GetTerminalActionAsync(actionId);
}
catch (ApiException e){};
```


# Cancel Terminal Action

Cancels a Terminal action request if the status of the request permits it.

```csharp
CancelTerminalActionAsync(
    string actionId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `actionId` | `string` | Template, Required | Unique ID for the desired `TerminalAction` |

## Response Type

[`Task<Models.CancelTerminalActionResponse>`](../../doc/models/cancel-terminal-action-response.md)

## Example Usage

```csharp
string actionId = "action_id6";

try
{
    CancelTerminalActionResponse result = await terminalApi.CancelTerminalActionAsync(actionId);
}
catch (ApiException e){};
```


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
var bodyCheckoutDeviceOptions = new DeviceCheckoutOptions.Builder(
        "dbb5d83a-7838-11ea-bc55-0242ac130003")
    .Build();
var bodyCheckout = new TerminalCheckout.Builder(
        bodyCheckoutAmountMoney,
        bodyCheckoutDeviceOptions)
    .ReferenceId("id11572")
    .Note("A brief note")
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

Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.

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
var bodyQueryFilter = new TerminalCheckoutQueryFilter.Builder()
    .Status("COMPLETED")
    .Build();
var bodyQuery = new TerminalCheckoutQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchTerminalCheckoutsRequest.Builder()
    .Query(bodyQuery)
    .Limit(2)
    .Build();

try
{
    SearchTerminalCheckoutsResponse result = await terminalApi.SearchTerminalCheckoutsAsync(body);
}
catch (ApiException e){};
```


# Get Terminal Checkout

Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.

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

Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API](../../doc/api/refunds.md).

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
        bodyRefundAmountMoney,
        "Returning items",
        "f72dfb8e-4d65-4e56-aade-ec3fb8d33291")
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

Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.

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
var bodyQueryFilter = new TerminalRefundQueryFilter.Builder()
    .Status("COMPLETED")
    .Build();
var bodyQuery = new TerminalRefundQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchTerminalRefundsRequest.Builder()
    .Query(bodyQuery)
    .Limit(1)
    .Build();

try
{
    SearchTerminalRefundsResponse result = await terminalApi.SearchTerminalRefundsAsync(body);
}
catch (ApiException e){};
```


# Get Terminal Refund

Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.

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

