# Loyalty

```csharp
ILoyaltyApi loyaltyApi = client.LoyaltyApi;
```

## Class Name

`LoyaltyApi`

## Methods

* [Create Loyalty Account](/doc/loyalty.md#create-loyalty-account)
* [Search Loyalty Accounts](/doc/loyalty.md#search-loyalty-accounts)
* [Retrieve Loyalty Account](/doc/loyalty.md#retrieve-loyalty-account)
* [Accumulate Loyalty Points](/doc/loyalty.md#accumulate-loyalty-points)
* [Adjust Loyalty Points](/doc/loyalty.md#adjust-loyalty-points)
* [Search Loyalty Events](/doc/loyalty.md#search-loyalty-events)
* [List Loyalty Programs](/doc/loyalty.md#list-loyalty-programs)
* [Calculate Loyalty Points](/doc/loyalty.md#calculate-loyalty-points)
* [Create Loyalty Reward](/doc/loyalty.md#create-loyalty-reward)
* [Search Loyalty Rewards](/doc/loyalty.md#search-loyalty-rewards)
* [Delete Loyalty Reward](/doc/loyalty.md#delete-loyalty-reward)
* [Retrieve Loyalty Reward](/doc/loyalty.md#retrieve-loyalty-reward)
* [Redeem Loyalty Reward](/doc/loyalty.md#redeem-loyalty-reward)

## Create Loyalty Account

Creates a loyalty account. For more information, see 
[Create a loyalty account](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-create-account).

```csharp
CreateLoyaltyAccountAsync(Models.CreateLoyaltyAccountRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateLoyaltyAccountRequest`](/doc/models/create-loyalty-account-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateLoyaltyAccountResponse>`](/doc/models/create-loyalty-account-response.md)

### Example Usage

```csharp
var bodyLoyaltyAccountMappings = new List<LoyaltyAccountMapping>();

var bodyLoyaltyAccountMappings0 = new LoyaltyAccountMapping.Builder(
        "PHONE",
        "+14155551234")
    .Id("id0")
    .CreatedAt("created_at8")
    .Build();
bodyLoyaltyAccountMappings.Add(bodyLoyaltyAccountMappings0);

var bodyLoyaltyAccount = new LoyaltyAccount.Builder(
        bodyLoyaltyAccountMappings,
        "d619f755-2d17-41f3-990d-c04ecedd64dd")
    .Id("id2")
    .Balance(14)
    .LifetimePoints(38)
    .CustomerId("customer_id0")
    .EnrolledAt("enrolled_at2")
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

## Search Loyalty Accounts

Searches for loyalty accounts. 
In the current implementation, you can search for a loyalty account using the phone number associated with the account. 
If no phone number is provided, all loyalty accounts are returned.

```csharp
SearchLoyaltyAccountsAsync(Models.SearchLoyaltyAccountsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchLoyaltyAccountsRequest`](/doc/models/search-loyalty-accounts-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchLoyaltyAccountsResponse>`](/doc/models/search-loyalty-accounts-response.md)

### Example Usage

```csharp
var bodyQueryMappings = new List<LoyaltyAccountMapping>();

var bodyQueryMappings0 = new LoyaltyAccountMapping.Builder(
        "PHONE",
        "+14155551234")
    .Id("id4")
    .CreatedAt("created_at8")
    .Build();
bodyQueryMappings.Add(bodyQueryMappings0);

var bodyQuery = new SearchLoyaltyAccountsRequestLoyaltyAccountQuery.Builder()
    .Mappings(bodyQueryMappings)
    .Build();
var body = new SearchLoyaltyAccountsRequest.Builder()
    .Query(bodyQuery)
    .Limit(10)
    .Cursor("cursor0")
    .Build();

try
{
    SearchLoyaltyAccountsResponse result = await loyaltyApi.SearchLoyaltyAccountsAsync(body);
}
catch (ApiException e){};
```

## Retrieve Loyalty Account

Retrieves a loyalty account.

```csharp
RetrieveLoyaltyAccountAsync(string accountId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accountId` | `string` | Template, Required | The ID of the [loyalty account](#type-LoyaltyAccount) to retrieve. |

### Response Type

[`Task<Models.RetrieveLoyaltyAccountResponse>`](/doc/models/retrieve-loyalty-account-response.md)

### Example Usage

```csharp
string accountId = "account_id2";

try
{
    RetrieveLoyaltyAccountResponse result = await loyaltyApi.RetrieveLoyaltyAccountAsync(accountId);
}
catch (ApiException e){};
```

## Accumulate Loyalty Points

Adds points to a loyalty account.

- If you are using the Orders API to manage orders, you only provide the `order_id`. 
The endpoint reads the order to compute points to add to the buyer's account.
- If you are not using the Orders API to manage orders, 
you first perform a client-side computation to compute the points.  
For spend-based and visit-based programs, you can call 
`CalculateLoyaltyPoints` to compute the points. For more information, 
see [Loyalty Program Overview](https://developer.squareup.com/docs/docs/loyalty/overview). 
You then provide the points in a request to this endpoint. 

For more information, see [Accumulate points](https://developer.squareup.com/docs/docs/loyalty-api/overview/#accumulate-points).

```csharp
AccumulateLoyaltyPointsAsync(string accountId, Models.AccumulateLoyaltyPointsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accountId` | `string` | Template, Required | The [loyalty account](#type-LoyaltyAccount) ID to which to add the points. |
| `body` | [`Models.AccumulateLoyaltyPointsRequest`](/doc/models/accumulate-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.AccumulateLoyaltyPointsResponse>`](/doc/models/accumulate-loyalty-points-response.md)

### Example Usage

```csharp
string accountId = "account_id2";
var bodyAccumulatePoints = new LoyaltyEventAccumulatePoints.Builder()
    .LoyaltyProgramId("loyalty_program_id8")
    .Points(90)
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

## Adjust Loyalty Points

Adds points to or subtracts points from a buyer's account. 

Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call 
[AccumulateLoyaltyPoints](https://developer.squareup.com/docs/reference/square/loyalty-api/accumulate-loyalty-points) 
to add points when a buyer pays for the purchase.

```csharp
AdjustLoyaltyPointsAsync(string accountId, Models.AdjustLoyaltyPointsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accountId` | `string` | Template, Required | The ID of the [loyalty account](#type-LoyaltyAccount) in which to adjust the points. |
| `body` | [`Models.AdjustLoyaltyPointsRequest`](/doc/models/adjust-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.AdjustLoyaltyPointsResponse>`](/doc/models/adjust-loyalty-points-response.md)

### Example Usage

```csharp
string accountId = "account_id2";
var bodyAdjustPoints = new LoyaltyEventAdjustPoints.Builder(
        112)
    .LoyaltyProgramId("loyalty_program_id4")
    .Reason("reason0")
    .Build();
var body = new AdjustLoyaltyPointsRequest.Builder(
        "idempotency_key2",
        bodyAdjustPoints)
    .Build();

try
{
    AdjustLoyaltyPointsResponse result = await loyaltyApi.AdjustLoyaltyPointsAsync(accountId, body);
}
catch (ApiException e){};
```

## Search Loyalty Events

Searches for loyalty events.

A Square loyalty program maintains a ledger of events that occur during the lifetime of a 
buyer's loyalty account. Each change in the point balance 
(for example, points earned, points redeemed, and points expired) is 
recorded in the ledger. Using this endpoint, you can search the ledger for events. 
For more information, see 
[Loyalty events](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-events).

```csharp
SearchLoyaltyEventsAsync(Models.SearchLoyaltyEventsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchLoyaltyEventsRequest`](/doc/models/search-loyalty-events-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchLoyaltyEventsResponse>`](/doc/models/search-loyalty-events-response.md)

### Example Usage

```csharp
var bodyQueryFilterLoyaltyAccountFilter = new LoyaltyEventLoyaltyAccountFilter.Builder(
        "loyalty_account_id6")
    .Build();
var bodyQueryFilterTypeFilterTypes = new List<string>();
bodyQueryFilterTypeFilterTypes.Add("DELETE_REWARD");
bodyQueryFilterTypeFilterTypes.Add("ADJUST_POINTS");
bodyQueryFilterTypeFilterTypes.Add("EXPIRE_POINTS");
var bodyQueryFilterTypeFilter = new LoyaltyEventTypeFilter.Builder(
        bodyQueryFilterTypeFilterTypes)
    .Build();
var bodyQueryFilterDateTimeFilterCreatedAt = new TimeRange.Builder()
    .StartAt("start_at8")
    .EndAt("end_at4")
    .Build();
var bodyQueryFilterDateTimeFilter = new LoyaltyEventDateTimeFilter.Builder(
        bodyQueryFilterDateTimeFilterCreatedAt)
    .Build();
var bodyQueryFilterLocationFilterLocationIds = new List<string>();
bodyQueryFilterLocationFilterLocationIds.Add("location_ids2");
bodyQueryFilterLocationFilterLocationIds.Add("location_ids3");
bodyQueryFilterLocationFilterLocationIds.Add("location_ids4");
var bodyQueryFilterLocationFilter = new LoyaltyEventLocationFilter.Builder(
        bodyQueryFilterLocationFilterLocationIds)
    .Build();
var bodyQueryFilterOrderFilter = new LoyaltyEventOrderFilter.Builder(
        "PyATxhYLfsMqpVkcKJITPydgEYfZY")
    .Build();
var bodyQueryFilter = new LoyaltyEventFilter.Builder()
    .LoyaltyAccountFilter(bodyQueryFilterLoyaltyAccountFilter)
    .TypeFilter(bodyQueryFilterTypeFilter)
    .DateTimeFilter(bodyQueryFilterDateTimeFilter)
    .LocationFilter(bodyQueryFilterLocationFilter)
    .OrderFilter(bodyQueryFilterOrderFilter)
    .Build();
var bodyQuery = new LoyaltyEventQuery.Builder()
    .Filter(bodyQueryFilter)
    .Build();
var body = new SearchLoyaltyEventsRequest.Builder()
    .Query(bodyQuery)
    .Limit(30)
    .Cursor("cursor0")
    .Build();

try
{
    SearchLoyaltyEventsResponse result = await loyaltyApi.SearchLoyaltyEventsAsync(body);
}
catch (ApiException e){};
```

## List Loyalty Programs

Returns a list of loyalty programs in the seller's account.
Currently, a seller can only have one loyalty program. For more information, see 
[Loyalty Overview](https://developer.squareup.com/docs/docs/loyalty/overview).
.

```csharp
ListLoyaltyProgramsAsync()
```

### Response Type

[`Task<Models.ListLoyaltyProgramsResponse>`](/doc/models/list-loyalty-programs-response.md)

### Example Usage

```csharp
try
{
    ListLoyaltyProgramsResponse result = await loyaltyApi.ListLoyaltyProgramsAsync();
}
catch (ApiException e){};
```

## Calculate Loyalty Points

Calculates the points a purchase earns.

- If you are using the Orders API to manage orders, you provide `order_id` in the request. The 
endpoint calculates the points by reading the order.
- If you are not using the Orders API to manage orders, you provide the purchase amount in 
the request for the endpoint to calculate the points.

An application might call this endpoint to show the points that a buyer can earn with the 
specific purchase.

```csharp
CalculateLoyaltyPointsAsync(string programId, Models.CalculateLoyaltyPointsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `programId` | `string` | Template, Required | The [loyalty program](#type-LoyaltyProgram) ID, which defines the rules for accruing points. |
| `body` | [`Models.CalculateLoyaltyPointsRequest`](/doc/models/calculate-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CalculateLoyaltyPointsResponse>`](/doc/models/calculate-loyalty-points-response.md)

### Example Usage

```csharp
string programId = "program_id0";
var bodyTransactionAmountMoney = new Money.Builder()
    .Amount(72L)
    .Currency("UZS")
    .Build();
var body = new CalculateLoyaltyPointsRequest.Builder()
    .OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
    .TransactionAmountMoney(bodyTransactionAmountMoney)
    .Build();

try
{
    CalculateLoyaltyPointsResponse result = await loyaltyApi.CalculateLoyaltyPointsAsync(programId, body);
}
catch (ApiException e){};
```

## Create Loyalty Reward

Creates a loyalty reward. In the process, the endpoint does following:

- Uses the `reward_tier_id` in the request to determine the number of points 
to lock for this reward. 
- If the request includes `order_id`, it adds the reward and related discount to the order. 

After a reward is created, the points are locked and 
not available for the buyer to redeem another reward. 
For more information, see 
[Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).

```csharp
CreateLoyaltyRewardAsync(Models.CreateLoyaltyRewardRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateLoyaltyRewardRequest`](/doc/models/create-loyalty-reward-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateLoyaltyRewardResponse>`](/doc/models/create-loyalty-reward-response.md)

### Example Usage

```csharp
var bodyReward = new LoyaltyReward.Builder(
        "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
        "e1b39225-9da5-43d1-a5db-782cdd8ad94f")
    .Id("id4")
    .Status("REDEEMED")
    .Points(230)
    .OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
    .CreatedAt("created_at2")
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

## Search Loyalty Rewards

Searches for loyalty rewards in a loyalty account. 

In the current implementation, the endpoint supports search by the reward `status`.

If you know a reward ID, use the 
[RetrieveLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/retrieve-loyalty-reward) endpoint.

For more information about loyalty rewards, see 
[Loyalty Rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-rewards).

```csharp
SearchLoyaltyRewardsAsync(Models.SearchLoyaltyRewardsRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.SearchLoyaltyRewardsRequest`](/doc/models/search-loyalty-rewards-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.SearchLoyaltyRewardsResponse>`](/doc/models/search-loyalty-rewards-response.md)

### Example Usage

```csharp
var bodyQuery = new SearchLoyaltyRewardsRequestLoyaltyRewardQuery.Builder(
        "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd")
    .Status("REDEEMED")
    .Build();
var body = new SearchLoyaltyRewardsRequest.Builder()
    .Query(bodyQuery)
    .Limit(10)
    .Cursor("cursor0")
    .Build();

try
{
    SearchLoyaltyRewardsResponse result = await loyaltyApi.SearchLoyaltyRewardsAsync(body);
}
catch (ApiException e){};
```

## Delete Loyalty Reward

Deletes a loyalty reward by doing the following:

- Returns the loyalty points back to the loyalty account.
- If an order ID was specified when the reward was created 
(see [CreateLoyaltyReward](https://developer.squareup.com/docs/reference/square/loyalty-api/create-loyalty-reward)), 
it updates the order by removing the reward and related 
discounts.

You cannot delete a reward that has reached the terminal state (REDEEMED). 
For more information, see 
[Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).

```csharp
DeleteLoyaltyRewardAsync(string rewardId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](#type-LoyaltyReward) to delete. |

### Response Type

[`Task<Models.DeleteLoyaltyRewardResponse>`](/doc/models/delete-loyalty-reward-response.md)

### Example Usage

```csharp
string rewardId = "reward_id4";

try
{
    DeleteLoyaltyRewardResponse result = await loyaltyApi.DeleteLoyaltyRewardAsync(rewardId);
}
catch (ApiException e){};
```

## Retrieve Loyalty Reward

Retrieves a loyalty reward.

```csharp
RetrieveLoyaltyRewardAsync(string rewardId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](#type-LoyaltyReward) to retrieve. |

### Response Type

[`Task<Models.RetrieveLoyaltyRewardResponse>`](/doc/models/retrieve-loyalty-reward-response.md)

### Example Usage

```csharp
string rewardId = "reward_id4";

try
{
    RetrieveLoyaltyRewardResponse result = await loyaltyApi.RetrieveLoyaltyRewardAsync(rewardId);
}
catch (ApiException e){};
```

## Redeem Loyalty Reward

Redeems a loyalty reward.

The endpoint sets the reward to the terminal state (`REDEEMED`). 

If you are using your own order processing system (not using the 
Orders API), you call this endpoint after the buyer paid for the 
purchase.

After the reward reaches the terminal state, it cannot be deleted. 
In other words, points used for the reward cannot be returned 
to the account.

For more information, see 
[Loyalty rewards](https://developer.squareup.com/docs/docs/loyalty-api/overview/#loyalty-overview-loyalty-rewards).

```csharp
RedeemLoyaltyRewardAsync(string rewardId, Models.RedeemLoyaltyRewardRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](#type-LoyaltyReward) to redeem. |
| `body` | [`Models.RedeemLoyaltyRewardRequest`](/doc/models/redeem-loyalty-reward-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.RedeemLoyaltyRewardResponse>`](/doc/models/redeem-loyalty-reward-response.md)

### Example Usage

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

