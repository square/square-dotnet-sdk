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
* [List Loyalty Promotions](../../doc/api/loyalty.md#list-loyalty-promotions)
* [Create Loyalty Promotion](../../doc/api/loyalty.md#create-loyalty-promotion)
* [Retrieve Loyalty Promotion](../../doc/api/loyalty.md#retrieve-loyalty-promotion)
* [Cancel Loyalty Promotion](../../doc/api/loyalty.md#cancel-loyalty-promotion)
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
Models.CreateLoyaltyAccountRequest body = new Models.CreateLoyaltyAccountRequest.Builder(
    new Models.LoyaltyAccount.Builder(
        "d619f755-2d17-41f3-990d-c04ecedd64dd"
    )
    .Mapping(
        new Models.LoyaltyAccountMapping.Builder()
        .PhoneNumber("+14155551234")
        .Build())
    .Build(),
    "ec78c477-b1c3-4899-a209-a4e71337c996"
)
.Build();

try
{
    CreateLoyaltyAccountResponse result = await loyaltyApi.CreateLoyaltyAccountAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.SearchLoyaltyAccountsRequest body = new Models.SearchLoyaltyAccountsRequest.Builder()
.Query(
    new Models.SearchLoyaltyAccountsRequestLoyaltyAccountQuery.Builder()
    .Mappings(
        new List<Models.LoyaltyAccountMapping>
        {
            new Models.LoyaltyAccountMapping.Builder()
            .PhoneNumber("+14155551234")
            .Build(),
        })
    .Build())
.Limit(10)
.Build();

try
{
    SearchLoyaltyAccountsResponse result = await loyaltyApi.SearchLoyaltyAccountsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `accountId` | `string` | Template, Required | The ID of the [loyalty account](entity:LoyaltyAccount) to retrieve. |

## Response Type

[`Task<Models.RetrieveLoyaltyAccountResponse>`](../../doc/models/retrieve-loyalty-account-response.md)

## Example Usage

```csharp
string accountId = "account_id2";
try
{
    RetrieveLoyaltyAccountResponse result = await loyaltyApi.RetrieveLoyaltyAccountAsync(accountId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Accumulate Loyalty Points

Adds points earned from a purchase to a [loyalty account](../../doc/models/loyalty-account.md).

- If you are using the Orders API to manage orders, provide the `order_id`. Square reads the order
  to compute the points earned from both the base loyalty program and an associated
  [loyalty promotion](../../doc/models/loyalty-promotion.md). For purchases that qualify for multiple accrual
  rules, Square computes points based on the accrual rule that grants the most points.
  For purchases that qualify for multiple promotions, Square computes points based on the most
  recently created promotion. A purchase must first qualify for program points to be eligible for promotion points.

- If you are not using the Orders API to manage orders, provide `points` with the number of points to add.
  You must first perform a client-side computation of the points earned from the loyalty program and
  loyalty promotion. For spend-based and visit-based programs, you can call [CalculateLoyaltyPoints](../../doc/api/loyalty.md#calculate-loyalty-points)
  to compute the points earned from the base loyalty program. For information about computing points earned from a loyalty promotion, see
  [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).

```csharp
AccumulateLoyaltyPointsAsync(
    string accountId,
    Models.AccumulateLoyaltyPointsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `accountId` | `string` | Template, Required | The ID of the target [loyalty account](entity:LoyaltyAccount). |
| `body` | [`Models.AccumulateLoyaltyPointsRequest`](../../doc/models/accumulate-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.AccumulateLoyaltyPointsResponse>`](../../doc/models/accumulate-loyalty-points-response.md)

## Example Usage

```csharp
string accountId = "account_id2";
Models.AccumulateLoyaltyPointsRequest body = new Models.AccumulateLoyaltyPointsRequest.Builder(
    new Models.LoyaltyEventAccumulatePoints.Builder()
    .OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
    .Build(),
    "58b90739-c3e8-4b11-85f7-e636d48d72cb",
    "P034NEENMD09F"
)
.Build();

try
{
    AccumulateLoyaltyPointsResponse result = await loyaltyApi.AccumulateLoyaltyPointsAsync(accountId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `accountId` | `string` | Template, Required | The ID of the target [loyalty account](entity:LoyaltyAccount). |
| `body` | [`Models.AdjustLoyaltyPointsRequest`](../../doc/models/adjust-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.AdjustLoyaltyPointsResponse>`](../../doc/models/adjust-loyalty-points-response.md)

## Example Usage

```csharp
string accountId = "account_id2";
Models.AdjustLoyaltyPointsRequest body = new Models.AdjustLoyaltyPointsRequest.Builder(
    "bc29a517-3dc9-450e-aa76-fae39ee849d1",
    new Models.LoyaltyEventAdjustPoints.Builder(
        10
    )
    .Reason("Complimentary points")
    .Build()
)
.Build();

try
{
    AdjustLoyaltyPointsResponse result = await loyaltyApi.AdjustLoyaltyPointsAsync(accountId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.SearchLoyaltyEventsRequest body = new Models.SearchLoyaltyEventsRequest.Builder()
.Query(
    new Models.LoyaltyEventQuery.Builder()
    .Filter(
        new Models.LoyaltyEventFilter.Builder()
        .OrderFilter(
            new Models.LoyaltyEventOrderFilter.Builder(
                "PyATxhYLfsMqpVkcKJITPydgEYfZY"
            )
            .Build())
        .Build())
    .Build())
.Limit(30)
.Build();

try
{
    SearchLoyaltyEventsResponse result = await loyaltyApi.SearchLoyaltyEventsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Loyalty Programs

**This endpoint is deprecated.**

Returns a list of loyalty programs in the seller's account.
Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).

Replaced with [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) when used with the keyword `main`.

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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Calculate Loyalty Points

Calculates the number of points a buyer can earn from a purchase. Applications might call this endpoint
to display the points to the buyer.

- If you are using the Orders API to manage orders, provide the `order_id` and (optional) `loyalty_account_id`.
  Square reads the order to compute the points earned from the base loyalty program and an associated
  [loyalty promotion](../../doc/models/loyalty-promotion.md).

- If you are not using the Orders API to manage orders, provide `transaction_amount_money` with the
  purchase amount. Square uses this amount to calculate the points earned from the base loyalty program,
  but not points earned from a loyalty promotion. For spend-based and visit-based programs, the `tax_mode`
  setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
  If the purchase qualifies for program points, call
  [ListLoyaltyPromotions](../../doc/api/loyalty.md#list-loyalty-promotions) and perform a client-side computation
  to calculate whether the purchase also qualifies for promotion points. For more information, see
  [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).

```csharp
CalculateLoyaltyPointsAsync(
    string programId,
    Models.CalculateLoyaltyPointsRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `programId` | `string` | Template, Required | The ID of the [loyalty program](entity:LoyaltyProgram), which defines the rules for accruing points. |
| `body` | [`Models.CalculateLoyaltyPointsRequest`](../../doc/models/calculate-loyalty-points-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CalculateLoyaltyPointsResponse>`](../../doc/models/calculate-loyalty-points-response.md)

## Example Usage

```csharp
string programId = "program_id0";
Models.CalculateLoyaltyPointsRequest body = new Models.CalculateLoyaltyPointsRequest.Builder()
.OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
.LoyaltyAccountId("79b807d2-d786-46a9-933b-918028d7a8c5")
.Build();

try
{
    CalculateLoyaltyPointsResponse result = await loyaltyApi.CalculateLoyaltyPointsAsync(programId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Loyalty Promotions

Lists the loyalty promotions associated with a [loyalty program](../../doc/models/loyalty-program.md).
Results are sorted by the `created_at` date in descending order (newest to oldest).

```csharp
ListLoyaltyPromotionsAsync(
    string programId,
    string status = null,
    string cursor = null,
    int? limit = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `programId` | `string` | Template, Required | The ID of the base [loyalty program](entity:LoyaltyProgram). To get the program ID,<br>call [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) using the `main` keyword. |
| `status` | [`string`](../../doc/models/loyalty-promotion-status.md) | Query, Optional | The status to filter the results by. If a status is provided, only loyalty promotions<br>with the specified status are returned. Otherwise, all loyalty promotions associated with<br>the loyalty program are returned. |
| `cursor` | `string` | Query, Optional | The cursor returned in the paged response from the previous call to this endpoint.<br>Provide this cursor to retrieve the next page of results for your original request.<br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |
| `limit` | `int?` | Query, Optional | The maximum number of results to return in a single paged response.<br>The minimum value is 1 and the maximum value is 30. The default value is 30.<br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Response Type

[`Task<Models.ListLoyaltyPromotionsResponse>`](../../doc/models/list-loyalty-promotions-response.md)

## Example Usage

```csharp
string programId = "program_id0";
try
{
    ListLoyaltyPromotionsResponse result = await loyaltyApi.ListLoyaltyPromotionsAsync(programId, null, null, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Loyalty Promotion

Creates a loyalty promotion for a [loyalty program](../../doc/models/loyalty-program.md). A loyalty promotion
enables buyers to earn points in addition to those earned from the base loyalty program.

This endpoint sets the loyalty promotion to the `ACTIVE` or `SCHEDULED` status, depending on the
`available_time` setting. A loyalty program can have a maximum of 10 loyalty promotions with an
`ACTIVE` or `SCHEDULED` status.

```csharp
CreateLoyaltyPromotionAsync(
    string programId,
    Models.CreateLoyaltyPromotionRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `programId` | `string` | Template, Required | The ID of the [loyalty program](entity:LoyaltyProgram) to associate with the promotion.<br>To get the program ID, call [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram)<br>using the `main` keyword. |
| `body` | [`Models.CreateLoyaltyPromotionRequest`](../../doc/models/create-loyalty-promotion-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateLoyaltyPromotionResponse>`](../../doc/models/create-loyalty-promotion-response.md)

## Example Usage

```csharp
string programId = "program_id0";
Models.CreateLoyaltyPromotionRequest body = new Models.CreateLoyaltyPromotionRequest.Builder(
    new Models.LoyaltyPromotion.Builder(
        "Tuesday Happy Hour Promo",
        new Models.LoyaltyPromotionIncentive.Builder(
            "POINTS_MULTIPLIER"
        )
        .PointsMultiplierData(
            new Models.LoyaltyPromotionIncentivePointsMultiplierData.Builder(
                3
            )
            .Build())
        .Build(),
        new Models.LoyaltyPromotionAvailableTimeData.Builder(
            new List<string>
            {
                "BEGIN:VEVENT\\nDTSTART:20220816T160000\\nDURATION:PT2H\\nRRULE:FREQ=WEEKLY;BYDAY=TU\\nEND:VEVENT",
            }
        )
        .Build()
    )
    .TriggerLimit(
        new Models.LoyaltyPromotionTriggerLimit.Builder(
            1
        )
        .Interval("DAY")
        .Build())
    .MinimumSpendAmountMoney(
        new Models.Money.Builder()
        .Amount(2000L)
        .Currency("USD")
        .Build())
    .QualifyingCategoryIds(
        new List<string>
        {
            "XTQPYLR3IIU9C44VRCB3XD12",
        })
    .Build(),
    "ec78c477-b1c3-4899-a209-a4e71337c996"
)
.Build();

try
{
    CreateLoyaltyPromotionResponse result = await loyaltyApi.CreateLoyaltyPromotionAsync(programId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Loyalty Promotion

Retrieves a loyalty promotion.

```csharp
RetrieveLoyaltyPromotionAsync(
    string promotionId,
    string programId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `promotionId` | `string` | Template, Required | The ID of the [loyalty promotion](entity:LoyaltyPromotion) to retrieve. |
| `programId` | `string` | Template, Required | The ID of the base [loyalty program](entity:LoyaltyProgram). To get the program ID,<br>call [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) using the `main` keyword. |

## Response Type

[`Task<Models.RetrieveLoyaltyPromotionResponse>`](../../doc/models/retrieve-loyalty-promotion-response.md)

## Example Usage

```csharp
string promotionId = "promotion_id0";
string programId = "program_id0";
try
{
    RetrieveLoyaltyPromotionResponse result = await loyaltyApi.RetrieveLoyaltyPromotionAsync(promotionId, programId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Cancel Loyalty Promotion

Cancels a loyalty promotion. Use this endpoint to cancel an `ACTIVE` promotion earlier than the
end date, cancel an `ACTIVE` promotion when an end date is not specified, or cancel a `SCHEDULED` promotion.
Because updating a promotion is not supported, you can also use this endpoint to cancel a promotion before
you create a new one.

This endpoint sets the loyalty promotion to the `CANCELED` state

```csharp
CancelLoyaltyPromotionAsync(
    string promotionId,
    string programId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `promotionId` | `string` | Template, Required | The ID of the [loyalty promotion](entity:LoyaltyPromotion) to cancel. You can cancel a<br>promotion that has an `ACTIVE` or `SCHEDULED` status. |
| `programId` | `string` | Template, Required | The ID of the base [loyalty program](entity:LoyaltyProgram). |

## Response Type

[`Task<Models.CancelLoyaltyPromotionResponse>`](../../doc/models/cancel-loyalty-promotion-response.md)

## Example Usage

```csharp
string promotionId = "promotion_id0";
string programId = "program_id0";
try
{
    CancelLoyaltyPromotionResponse result = await loyaltyApi.CancelLoyaltyPromotionAsync(promotionId, programId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.CreateLoyaltyRewardRequest body = new Models.CreateLoyaltyRewardRequest.Builder(
    new Models.LoyaltyReward.Builder(
        "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
        "e1b39225-9da5-43d1-a5db-782cdd8ad94f"
    )
    .OrderId("RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY")
    .Build(),
    "18c2e5ea-a620-4b1f-ad60-7b167285e451"
)
.Build();

try
{
    CreateLoyaltyRewardResponse result = await loyaltyApi.CreateLoyaltyRewardAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
Models.SearchLoyaltyRewardsRequest body = new Models.SearchLoyaltyRewardsRequest.Builder()
.Query(
    new Models.SearchLoyaltyRewardsRequestLoyaltyRewardQuery.Builder(
        "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd"
    )
    .Build())
.Limit(10)
.Build();

try
{
    SearchLoyaltyRewardsResponse result = await loyaltyApi.SearchLoyaltyRewardsAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](entity:LoyaltyReward) to delete. |

## Response Type

[`Task<Models.DeleteLoyaltyRewardResponse>`](../../doc/models/delete-loyalty-reward-response.md)

## Example Usage

```csharp
string rewardId = "reward_id4";
try
{
    DeleteLoyaltyRewardResponse result = await loyaltyApi.DeleteLoyaltyRewardAsync(rewardId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](entity:LoyaltyReward) to retrieve. |

## Response Type

[`Task<Models.RetrieveLoyaltyRewardResponse>`](../../doc/models/retrieve-loyalty-reward-response.md)

## Example Usage

```csharp
string rewardId = "reward_id4";
try
{
    RetrieveLoyaltyRewardResponse result = await loyaltyApi.RetrieveLoyaltyRewardAsync(rewardId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
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
| `rewardId` | `string` | Template, Required | The ID of the [loyalty reward](entity:LoyaltyReward) to redeem. |
| `body` | [`Models.RedeemLoyaltyRewardRequest`](../../doc/models/redeem-loyalty-reward-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.RedeemLoyaltyRewardResponse>`](../../doc/models/redeem-loyalty-reward-response.md)

## Example Usage

```csharp
string rewardId = "reward_id4";
Models.RedeemLoyaltyRewardRequest body = new Models.RedeemLoyaltyRewardRequest.Builder(
    "98adc7f7-6963-473b-b29c-f3c9cdd7d994",
    "P034NEENMD09F"
)
.Build();

try
{
    RedeemLoyaltyRewardResponse result = await loyaltyApi.RedeemLoyaltyRewardAsync(rewardId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

