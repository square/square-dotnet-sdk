# Gift Card Activities

```csharp
IGiftCardActivitiesApi giftCardActivitiesApi = client.GiftCardActivitiesApi;
```

## Class Name

`GiftCardActivitiesApi`

## Methods

* [List Gift Card Activities](../../doc/api/gift-card-activities.md#list-gift-card-activities)
* [Create Gift Card Activity](../../doc/api/gift-card-activities.md#create-gift-card-activity)


# List Gift Card Activities

Lists gift card activities. By default, you get gift card activities for all
gift cards in the seller's account. You can optionally specify query parameters to
filter the list. For example, you can get a list of gift card activities for a gift card,
for all gift cards in a specific region, or for activities within a time window.

```csharp
ListGiftCardActivitiesAsync(
    string giftCardId = null,
    string type = null,
    string locationId = null,
    string beginTime = null,
    string endTime = null,
    int? limit = null,
    string cursor = null,
    string sortOrder = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `giftCardId` | `string` | Query, Optional | If a gift card ID is provided, the endpoint returns activities related<br>to the specified gift card. Otherwise, the endpoint returns all gift card activities for<br>the seller. |
| `type` | `string` | Query, Optional | If a [type](../../doc/models/gift-card-activity-type.md) is provided, the endpoint returns gift card activities of the specified type.<br>Otherwise, the endpoint returns all types of gift card activities. |
| `locationId` | `string` | Query, Optional | If a location ID is provided, the endpoint returns gift card activities for the specified location.<br>Otherwise, the endpoint returns gift card activities for all locations. |
| `beginTime` | `string` | Query, Optional | The timestamp for the beginning of the reporting period, in RFC 3339 format.<br>This start time is inclusive. The default value is the current time minus one year. |
| `endTime` | `string` | Query, Optional | The timestamp for the end of the reporting period, in RFC 3339 format.<br>This end time is inclusive. The default value is the current time. |
| `limit` | `int?` | Query, Optional | If a limit is provided, the endpoint returns the specified number<br>of results (or fewer) per page. The maximum value is 100. The default value is 50.<br>For more information, see [Pagination](../../https://developer.squareup.com/docs/working-with-apis/pagination). |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>If a cursor is not provided, the endpoint returns the first page of the results.<br>For more information, see [Pagination](../../https://developer.squareup.com/docs/working-with-apis/pagination). |
| `sortOrder` | `string` | Query, Optional | The order in which the endpoint returns the activities, based on `created_at`.<br><br>- `ASC` - Oldest to newest.<br>- `DESC` - Newest to oldest (default). |

## Response Type

[`Task<Models.ListGiftCardActivitiesResponse>`](../../doc/models/list-gift-card-activities-response.md)

## Example Usage

```csharp
string giftCardId = "gift_card_id8";
string type = "type0";
string locationId = "location_id4";
string beginTime = "begin_time2";
string endTime = "end_time2";
int? limit = 172;
string cursor = "cursor6";
string sortOrder = "sort_order0";

try
{
    ListGiftCardActivitiesResponse result = await giftCardActivitiesApi.ListGiftCardActivitiesAsync(giftCardId, type, locationId, beginTime, endTime, limit, cursor, sortOrder);
}
catch (ApiException e){};
```


# Create Gift Card Activity

Creates a gift card activity. For more information, see
[GiftCardActivity](../../https://developer.squareup.com/docs/gift-cards/using-gift-cards-api#giftcardactivity) and
[Using activated gift cards](../../https://developer.squareup.com/docs/gift-cards/using-gift-cards-api#using-activated-gift-cards).

```csharp
CreateGiftCardActivityAsync(
    Models.CreateGiftCardActivityRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateGiftCardActivityRequest`](../../doc/models/create-gift-card-activity-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateGiftCardActivityResponse>`](../../doc/models/create-gift-card-activity-response.md)

## Example Usage

```csharp
var bodyGiftCardActivityGiftCardBalanceMoney = new Money.Builder()
    .Amount(88L)
    .Currency("ANG")
    .Build();
var bodyGiftCardActivityActivateActivityDetailsAmountMoney = new Money.Builder()
    .Amount(10L)
    .Currency("MXV")
    .Build();
var bodyGiftCardActivityActivateActivityDetailsBuyerPaymentInstrumentIds = new IList<string>();
bodyGiftCardActivityActivateActivityDetailsBuyerPaymentInstrumentIds.Add("buyer_payment_instrument_ids4");
bodyGiftCardActivityActivateActivityDetailsBuyerPaymentInstrumentIds.Add("buyer_payment_instrument_ids5");
bodyGiftCardActivityActivateActivityDetailsBuyerPaymentInstrumentIds.Add("buyer_payment_instrument_ids6");
var bodyGiftCardActivityActivateActivityDetails = new GiftCardActivityActivate.Builder()
    .AmountMoney(bodyGiftCardActivityActivateActivityDetailsAmountMoney)
    .OrderId("jJNGHm4gLI6XkFbwtiSLqK72KkAZY")
    .LineItemUid("eIWl7X0nMuO9Ewbh0ChIx")
    .ReferenceId("reference_id4")
    .BuyerPaymentInstrumentIds(bodyGiftCardActivityActivateActivityDetailsBuyerPaymentInstrumentIds)
    .Build();
var bodyGiftCardActivity = new GiftCardActivity.Builder(
        "ACTIVATE",
        "81FN9BNFZTKS4")
    .Id("id2")
    .CreatedAt("created_at0")
    .GiftCardId("gftc:6d55a72470d940c6ba09c0ab8ad08d20")
    .GiftCardGan("gift_card_gan8")
    .GiftCardBalanceMoney(bodyGiftCardActivityGiftCardBalanceMoney)
    .ActivateActivityDetails(bodyGiftCardActivityActivateActivityDetails)
    .Build();
var body = new CreateGiftCardActivityRequest.Builder(
        "U16kfr-kA70er-q4Rsym-7U7NnY",
        bodyGiftCardActivity)
    .Build();

try
{
    CreateGiftCardActivityResponse result = await giftCardActivitiesApi.CreateGiftCardActivityAsync(body);
}
catch (ApiException e){};
```

