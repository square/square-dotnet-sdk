# Loyalty

```csharp
ILoyaltyApi loyaltyApi = client.LoyaltyApi;
```

## Class Name

`LoyaltyApi`

## Methods

* [Create Loyalty Account](../../doc/api/loyalty.md#create-loyalty-account)
* [Search Loyalty Accounts](../../doc/api/loyalty.md#search-loyalty-accounts)
* [Retrieve Loyalty Account](../../doc/api/loyalty.md#retrieve-loyalty-account)
* [Accumulate Loyalty Points](../../doc/api/loyalty.md#accumulate-loyalty-points)
* [Adjust Loyalty Points](../../doc/api/loyalty.md#adjust-loyalty-points)
* [Search Loyalty Events](../../doc/api/loyalty.md#search-loyalty-events)
* [List Loyalty Programs](../../doc/api/loyalty.md#list-loyalty-programs)
* [Retrieve Loyalty Program](../../doc/api/loyalty.md#retrieve-loyalty-program)
* [Calculate Loyalty Points](../../doc/api/loyalty.md#calculate-loyalty-points)
* [Create Loyalty Reward](../../doc/api/loyalty.md#create-loyalty-reward)
* [Search Loyalty Rewards](../../doc/api/loyalty.md#search-loyalty-rewards)
* [Delete Loyalty Reward](../../doc/api/loyalty.md#delete-loyalty-reward)
* [Retrieve Loyalty Reward](../../doc/api/loyalty.md#retrieve-loyalty-reward)
* [Redeem Loyalty Reward](../../doc/api/loyalty.md#redeem-loyalty-reward)


# Create Loyalty Account

Creates a loyalty account. To create a loyalty account, you must provide the `program_id` and a `mapping` with the `phone_number` of the buyer.

```csharp
CreateLoyaltyAccountAsync(
    Models.CreateLoyaltyAccountRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateLoyaltyAccountRequest`](../../doc/models/create-loyalty-account-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateLoyaltyAccountResponse>`](../../doc/models/create-loyalty-account-response.md)

## Example Usage

```csharp
var bodyLoyaltyAccountMapping = new LoyaltyAccountMapping.Builder()
    .PhoneNumber("+14155551234")
    .Build();
var bodyLoyaltyAccount = new LoyaltyAccount.Builder(
        "d619f755-2d17-41f3-990d-c04ecedd64dd")
    .Mapping(bodyLoyaltyAccountMapping)
    .Build();
var body = new CreateLoyaltyAccountRequest.Builder(
        bodyLoyaltyAccount,
        "ec78c477-b1c3-4899-a209-a4e71337c996")
    .Build();

try
{
    CreateLoyaltyAccountResponse result = await loyaltyApi.CreateLoyaltyAccountAsync(body);
}
catch (ApiException e){};
```


# Search Loyalty Accounts

Searches for loyalty accounts in a loyalty program.

You can search for a loyalty account using the phone number or customer ID associated with the account. To return all loyalty accounts, specify an empty `query` object or omit it entirely.

Search results are sorted by `created_at` in ascending order.

```csharp
SearchLoyaltyAccountsAsync(
    Models.SearchLoyaltyAccountsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchLoyaltyAccountsRequest`](../../doc/models/search-loyalty-accounts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchLoyaltyAccountsResponse>`](../../doc/models/search-loyalty-accounts-response.md)

## Example Usage

```csharp
var bodyQueryMappings = new List<LoyaltyAccountMapping>();

var bodyQueryMappings0 = new LoyaltyAccountMapping.Builder()
    .PhoneNumber("+14155551234")
    .Build();
bodyQueryMappings.Add(bodyQueryMappings0);

var bodyQuery = new SearchLoyaltyAccountsRequestLoyaltyAccountQuery.Builder()
    .Mappings(bodyQueryMappings)
    .Build();
var body = new SearchLoyaltyAccountsRequest.Builder()
    .Query(bodyQuery)
    .Limit(10)
    .Build();

try
{
    SearchLoyaltyAccountsResponse result = await loyaltyApi.SearchLoyaltyAccountsAsync(body);
}
catch (ApiException e){};
```


# Retrieve Loyalty Account

Retrieves a loyalty account.

```csharp
RetrieveLoyaltyAccountAsync(
    string accountId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accountId` | `string` | Template, Required | The ID of the [loyalty account](../../doc/models/loyalty-account.md) to retrieve. |

## Response Type

[`Task<Models.RetrieveLoyaltyAccountResponse>`](../../doc/models/retrieve-loyalty-account-response.md)

## Example Usage

```csharp
string accountId = "account_id2";

try
{
    RetrieveLoyaltyAccountResponse result = await loyaltyApi.RetrieveLoyaltyAccountAsync(accountId);
}
catch (ApiException e){};
```


# Accumulate Loyalty Points

Adds points earned from the base loyalty program to a loyalty account.

- If you are using the Orders API to manage orders, you only provide the `order_id`.
  The endpoint reads the order to compute points to add to the buyer's account.
- If you are not using the Orders API to manage orders,
  you first perform a client-side computation to compute the points.  
  For spend-based and visit-based programs, you can first call
  [CalculateLoyaltyPoints](../../doc/api/loyalty.md#calculate-loyalty-points) to compute the points  
  that you provide to this endpoint.

This endpoint excludes additional points earned from loyalty promotions.

```csharp
AccumulateLoyaltyPointsAsync(
    string accountId,
    Models.AccumulateLoyaltyPointsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accountId` | `string` | Template, Required | The [loyalty account](../../doc/models/loyalty-account.md) ID to which to add the points. |
| `body` | [`Models.AccumulateLoyaltyPointsRequest`](../../doc/models/accumulate-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.AccumulateLoyaltyPointsResponse>`](../../doc/models/accumulate-loyalty-points-response.md)

## Example Usage

```csharp
string accountId = "account_id2";
var bodyAccumulatePoints = new LoyaltyEventAccumulatePoints.Builder()
    .OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
    .Build();
var body = new AccumulateLoyaltyPointsRequest.Builder(
        bodyAccumulatePoints,
        "58b90739-c3e8-4b11-85f7-e636d48d72cb",
        "P034NEENMD09F")
    .Build();

try
{
    AccumulateLoyaltyPointsResponse result = await loyaltyApi.AccumulateLoyaltyPointsAsync(accountId, body);
}
catch (ApiException e){};
```


# Adjust Loyalty Points

Adds points to or subtracts points from a buyer's account.

Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call
[AccumulateLoyaltyPoints](../../doc/api/loyalty.md#accumulate-loyalty-points)
to add points when a buyer pays for the purchase.

```csharp
AdjustLoyaltyPointsAsync(
    string accountId,
    Models.AdjustLoyaltyPointsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accountId` | `string` | Template, Required | The ID of the [loyalty account](../../doc/models/loyalty-account.md) in which to adjust the points. |
| `body` | [`Models.AdjustLoyaltyPointsRequest`](../../doc/models/adjust-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.AdjustLoyaltyPointsResponse>`](../../doc/models/adjust-loyalty-points-response.md)

## Example Usage

```csharp
string accountId = "account_id2";
var bodyAdjustPoints = new LoyaltyEventAdjustPoints.Builder(
        10)
    .Reason("Complimentary points")
    .Build();
var body = new AdjustLoyaltyPointsRequest.Builder(
        "bc29a517-3dc9-450e-aa76-fae39ee849d1",
        bodyAdjustPoints)
    .Build();

try
{
    AdjustLoyaltyPointsResponse result = await loyaltyApi.AdjustLoyaltyPointsAsync(accountId, body);
}
catch (ApiException e){};
```


# Search Loyalty Events

Searches for loyalty events.

A Square loyalty program maintains a ledger of events that occur during the lifetime of a
buyer's loyalty account. Each change in the point balance
(for example, points earned, points redeemed, and points expired) is
recorded in the ledger. Using this endpoint, you can search the ledger for events.

Search results are sorted by `created_at` in descending order.

```csharp
SearchLoyaltyEventsAsync(
    Models.SearchLoyaltyEventsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchLoyaltyEventsRequest`](../../doc/models/search-loyalty-events-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchLoyaltyEventsResponse>`](../../doc/models/search-loyalty-events-response.md)

## Example Usage

```csharp
var bodyQueryFilterOrderFilter = new LoyaltyEventOrderFilter.Builder(
        "PyATxhYLfsMqpVkcKJITPydgEYfZY")
    .Build();
var bodyQueryFilter = new LoyaltyEventFilter.Builder()
    .OrderFilter(bodyQueryFilterOrderFilter)
    .Build();
var bodyQuery = new LoyaltyEventQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchLoyaltyEventsRequest.Builder()
    .Query(bodyQuery)
    .Limit(30)
    .Build();

try
{
    SearchLoyaltyEventsResponse result = await loyaltyApi.SearchLoyaltyEventsAsync(body);
}
catch (ApiException e){};
```


# List Loyalty Programs

**This endpoint is deprecated.**

Returns a list of loyalty programs in the seller's account.
Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).

Replaced with [RetrieveLoyaltyProgram](../../doc/api/loyalty.md#retrieve-loyalty-program) when used with the keyword `main`.

```csharp
ListLoyaltyProgramsAsync()
```

## Response Type

[`Task<Models.ListLoyaltyProgramsResponse>`](../../doc/models/list-loyalty-programs-response.md)

## Example Usage

```csharp
try
{
    ListLoyaltyProgramsResponse result = await loyaltyApi.ListLoyaltyProgramsAsync();
}
catch (ApiException e){};
```


# Retrieve Loyalty Program

Retrieves the loyalty program in a seller's account, specified by the program ID or the keyword `main`.

Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).

```csharp
RetrieveLoyaltyProgramAsync(
    string programId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `programId` | `string` | Template, Required | The ID of the loyalty program or the keyword `main`. Either value can be used to retrieve the single loyalty program that belongs to the seller. |

## Response Type

[`Task<Models.RetrieveLoyaltyProgramResponse>`](../../doc/models/retrieve-loyalty-program-response.md)

## Example Usage

```csharp
string programId = "program_id0";

try
{
    RetrieveLoyaltyProgramResponse result = await loyaltyApi.RetrieveLoyaltyProgramAsync(programId);
}
catch (ApiException e){};
```


# Calculate Loyalty Points

Calculates the points a purchase earns from the base loyalty program.

- If you are using the Orders API to manage orders, you provide the `order_id` in the request. The
  endpoint calculates the points by reading the order.
- If you are not using the Orders API to manage orders, you provide the purchase amount in
  the request for the endpoint to calculate the points.

An application might call this endpoint to show the points that a buyer can earn with the
specific purchase.

For spend-based and visit-based programs, the `tax_mode` setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.

```csharp
CalculateLoyaltyPointsAsync(
    string programId,
    Models.CalculateLoyaltyPointsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `programId` | `string` | Template, Required | The [loyalty program](../../doc/models/loyalty-program.md) ID, which defines the rules for accruing points. |
| `body` | [`Models.CalculateLoyaltyPointsRequest`](../../doc/models/calculate-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CalculateLoyaltyPointsResponse>`](../../doc/models/calculate-loyalty-points-response.md)

## Example Usage

```csharp
string programId = "program_id0";
var body = new CalculateLoyaltyPointsRequest.Builder()
    .OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
    .Build();

try
{
    CalculateLoyaltyPointsResponse result = await loyaltyApi.CalculateLoyaltyPointsAsync(programId, body);
}
catch (ApiException e){};
```


# Create Loyalty Reward

Creates a loyalty reward. In the process, the endpoint does following:

- Uses the `reward_tier_id` in the request to determine the number of points
  to lock for this reward.
- If the request includes `order_id`, it adds the reward and related discount to the order.

After a reward is created, the points are locked and
not available for the buyer to redeem another reward.

```csharp
CreateLoyaltyRewardAsync(
    Models.CreateLoyaltyRewardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateLoyaltyRewardRequest`](../../doc/models/create-loyalty-reward-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateLoyaltyRewardResponse>`](../../doc/models/create-loyalty-reward-response.md)

## Example Usage

```csharp
var bodyReward = new LoyaltyReward.Builder(
        "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
        "e1b39225-9da5-43d1-a5db-782cdd8ad94f")
    .OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
    .Build();
var body = new CreateLoyaltyRewardRequest.Builder(
        bodyReward,
        "18c2e5ea-a620-4b1f-ad60-7b167285e451")
    .Build();

try
{
    CreateLoyaltyRewardResponse result = await loyaltyApi.CreateLoyaltyRewardAsync(body);
}
catch (ApiException e){};
```


# Search Loyalty Rewards

Searches for loyalty rewards. This endpoint accepts a request with no query filters and returns results for all loyalty accounts.
If you include a `query` object, `loyalty_account_id` is required and `status` is  optional.

If you know a reward ID, use the
[RetrieveLoyaltyReward](../../doc/api/loyalty.md#retrieve-loyalty-reward) endpoint.

Search results are sorted by `updated_at` in descending order.

```csharp
SearchLoyaltyRewardsAsync(
    Models.SearchLoyaltyRewardsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchLoyaltyRewardsRequest`](../../doc/models/search-loyalty-rewards-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchLoyaltyRewardsResponse>`](../../doc/models/search-loyalty-rewards-response.md)

## Example Usage

```csharp
var bodyQuery = new SearchLoyaltyRewardsRequestLoyaltyRewardQuery.Builder(
        "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd")
    .Build();
var body = new SearchLoyaltyRewardsRequest.Builder()
    .Query(bodyQuery)
    .Limit(10)
    .Build();

try
{
    SearchLoyaltyRewardsResponse result = await loyaltyApi.SearchLoyaltyRewardsAsync(body);
}
catch (ApiException e){};
```


# Delete Loyalty Reward

Deletes a loyalty reward by doing the following:

- Returns the loyalty points back to the loyalty account.
- If an order ID was specified when the reward was created
  (see [CreateLoyaltyReward](../../doc/api/loyalty.md#create-loyalty-reward)),
  it updates the order by removing the reward and related
  discounts.

You cannot delete a reward that has reached the terminal state (REDEEMED).

```csharp
DeleteLoyaltyRewardAsync(
    string rewardId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](../../doc/models/loyalty-reward.md) to delete. |

## Response Type

[`Task<Models.DeleteLoyaltyRewardResponse>`](../../doc/models/delete-loyalty-reward-response.md)

## Example Usage

```csharp
string rewardId = "reward_id4";

try
{
    DeleteLoyaltyRewardResponse result = await loyaltyApi.DeleteLoyaltyRewardAsync(rewardId);
}
catch (ApiException e){};
```


# Retrieve Loyalty Reward

Retrieves a loyalty reward.

```csharp
RetrieveLoyaltyRewardAsync(
    string rewardId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](../../doc/models/loyalty-reward.md) to retrieve. |

## Response Type

[`Task<Models.RetrieveLoyaltyRewardResponse>`](../../doc/models/retrieve-loyalty-reward-response.md)

## Example Usage

```csharp
string rewardId = "reward_id4";

try
{
    RetrieveLoyaltyRewardResponse result = await loyaltyApi.RetrieveLoyaltyRewardAsync(rewardId);
}
catch (ApiException e){};
```


# Redeem Loyalty Reward

Redeems a loyalty reward.

The endpoint sets the reward to the `REDEEMED` terminal state.

If you are using your own order processing system (not using the
Orders API), you call this endpoint after the buyer paid for the
purchase.

After the reward reaches the terminal state, it cannot be deleted.
In other words, points used for the reward cannot be returned
to the account.

```csharp
RedeemLoyaltyRewardAsync(
    string rewardId,
    Models.RedeemLoyaltyRewardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](../../doc/models/loyalty-reward.md) to redeem. |
| `body` | [`Models.RedeemLoyaltyRewardRequest`](../../doc/models/redeem-loyalty-reward-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.RedeemLoyaltyRewardResponse>`](../../doc/models/redeem-loyalty-reward-response.md)

## Example Usage

```csharp
string rewardId = "reward_id4";
var body = new RedeemLoyaltyRewardRequest.Builder(
        "98adc7f7-6963-473b-b29c-f3c9cdd7d994",
        "P034NEENMD09F")
    .Build();

try
{
    RedeemLoyaltyRewardResponse result = await loyaltyApi.RedeemLoyaltyRewardAsync(rewardId, body);
}
catch (ApiException e){};
```

