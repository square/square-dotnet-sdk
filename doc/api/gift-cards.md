# Gift Cards

```csharp
IGiftCardsApi giftCardsApi = client.GiftCardsApi;
```

## Class Name

`GiftCardsApi`

## Methods

* [List Gift Cards](../../doc/api/gift-cards.md#list-gift-cards)
* [Create Gift Card](../../doc/api/gift-cards.md#create-gift-card)
* [Retrieve Gift Card From GAN](../../doc/api/gift-cards.md#retrieve-gift-card-from-gan)
* [Retrieve Gift Card From Nonce](../../doc/api/gift-cards.md#retrieve-gift-card-from-nonce)
* [Link Customer to Gift Card](../../doc/api/gift-cards.md#link-customer-to-gift-card)
* [Unlink Customer From Gift Card](../../doc/api/gift-cards.md#unlink-customer-from-gift-card)
* [Retrieve Gift Card](../../doc/api/gift-cards.md#retrieve-gift-card)


# List Gift Cards

Lists all gift cards. You can specify optional filters to retrieve
a subset of the gift cards. Results are sorted by `created_at` in ascending order.

```csharp
ListGiftCardsAsync(
    string type = null,
    string state = null,
    int? limit = null,
    string cursor = null,
    string customerId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `type` | `string` | Query, Optional | If a [type](entity:GiftCardType) is provided, the endpoint returns gift cards of the specified type.<br>Otherwise, the endpoint returns gift cards of all types. |
| `state` | `string` | Query, Optional | If a [state](entity:GiftCardStatus) is provided, the endpoint returns the gift cards in the specified state.<br>Otherwise, the endpoint returns the gift cards of all states. |
| `limit` | `int?` | Query, Optional | If a limit is provided, the endpoint returns only the specified number of results per page.<br>The maximum value is 50. The default value is 30.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>If a cursor is not provided, the endpoint returns the first page of the results.<br>For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination). |
| `customerId` | `string` | Query, Optional | If a customer ID is provided, the endpoint returns only the gift cards linked to the specified customer. |

## Response Type

[`Task<Models.ListGiftCardsResponse>`](../../doc/models/list-gift-cards-response.md)

## Example Usage

```csharp
try
{
    ListGiftCardsResponse result = await giftCardsApi.ListGiftCardsAsync(null, null, null, null, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Gift Card

Creates a digital gift card or registers a physical (plastic) gift card. After the gift card
is created, you must call [CreateGiftCardActivity](../../doc/api/gift-card-activities.md#create-gift-card-activity)
to activate the card with an initial balance before it can be used for payment.

```csharp
CreateGiftCardAsync(
    Models.CreateGiftCardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateGiftCardRequest`](../../doc/models/create-gift-card-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateGiftCardResponse>`](../../doc/models/create-gift-card-response.md)

## Example Usage

```csharp
Models.CreateGiftCardRequest body = new Models.CreateGiftCardRequest.Builder(
    "NC9Tm69EjbjtConu",
    "81FN9BNFZTKS4",
    new Models.GiftCard.Builder(
        "DIGITAL"
    )
    .Build()
)
.Build();

try
{
    CreateGiftCardResponse result = await giftCardsApi.CreateGiftCardAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Gift Card From GAN

Retrieves a gift card using the gift card account number (GAN).

```csharp
RetrieveGiftCardFromGANAsync(
    Models.RetrieveGiftCardFromGANRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.RetrieveGiftCardFromGANRequest`](../../doc/models/retrieve-gift-card-from-gan-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.RetrieveGiftCardFromGANResponse>`](../../doc/models/retrieve-gift-card-from-gan-response.md)

## Example Usage

```csharp
Models.RetrieveGiftCardFromGANRequest body = new Models.RetrieveGiftCardFromGANRequest.Builder(
    "7783320001001635"
)
.Build();

try
{
    RetrieveGiftCardFromGANResponse result = await giftCardsApi.RetrieveGiftCardFromGANAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Gift Card From Nonce

Retrieves a gift card using a secure payment token that represents the gift card.

```csharp
RetrieveGiftCardFromNonceAsync(
    Models.RetrieveGiftCardFromNonceRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.RetrieveGiftCardFromNonceRequest`](../../doc/models/retrieve-gift-card-from-nonce-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.RetrieveGiftCardFromNonceResponse>`](../../doc/models/retrieve-gift-card-from-nonce-response.md)

## Example Usage

```csharp
Models.RetrieveGiftCardFromNonceRequest body = new Models.RetrieveGiftCardFromNonceRequest.Builder(
    "cnon:7783322135245171"
)
.Build();

try
{
    RetrieveGiftCardFromNonceResponse result = await giftCardsApi.RetrieveGiftCardFromNonceAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Link Customer to Gift Card

Links a customer to a gift card, which is also referred to as adding a card on file.

```csharp
LinkCustomerToGiftCardAsync(
    string giftCardId,
    Models.LinkCustomerToGiftCardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `giftCardId` | `string` | Template, Required | The ID of the gift card to be linked. |
| `body` | [`Models.LinkCustomerToGiftCardRequest`](../../doc/models/link-customer-to-gift-card-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.LinkCustomerToGiftCardResponse>`](../../doc/models/link-customer-to-gift-card-response.md)

## Example Usage

```csharp
string giftCardId = "gift_card_id8";
Models.LinkCustomerToGiftCardRequest body = new Models.LinkCustomerToGiftCardRequest.Builder(
    "GKY0FZ3V717AH8Q2D821PNT2ZW"
)
.Build();

try
{
    LinkCustomerToGiftCardResponse result = await giftCardsApi.LinkCustomerToGiftCardAsync(giftCardId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Unlink Customer From Gift Card

Unlinks a customer from a gift card, which is also referred to as removing a card on file.

```csharp
UnlinkCustomerFromGiftCardAsync(
    string giftCardId,
    Models.UnlinkCustomerFromGiftCardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `giftCardId` | `string` | Template, Required | The ID of the gift card to be unlinked. |
| `body` | [`Models.UnlinkCustomerFromGiftCardRequest`](../../doc/models/unlink-customer-from-gift-card-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UnlinkCustomerFromGiftCardResponse>`](../../doc/models/unlink-customer-from-gift-card-response.md)

## Example Usage

```csharp
string giftCardId = "gift_card_id8";
Models.UnlinkCustomerFromGiftCardRequest body = new Models.UnlinkCustomerFromGiftCardRequest.Builder(
    "GKY0FZ3V717AH8Q2D821PNT2ZW"
)
.Build();

try
{
    UnlinkCustomerFromGiftCardResponse result = await giftCardsApi.UnlinkCustomerFromGiftCardAsync(giftCardId, body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Gift Card

Retrieves a gift card using the gift card ID.

```csharp
RetrieveGiftCardAsync(
    string id)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `string` | Template, Required | The ID of the gift card to retrieve. |

## Response Type

[`Task<Models.RetrieveGiftCardResponse>`](../../doc/models/retrieve-gift-card-response.md)

## Example Usage

```csharp
string id = "id0";
try
{
    RetrieveGiftCardResponse result = await giftCardsApi.RetrieveGiftCardAsync(id);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

