# Cards

```csharp
ICardsApi cardsApi = client.CardsApi;
```

## Class Name

`CardsApi`

## Methods

* [List Cards](../../doc/api/cards.md#list-cards)
* [Create Card](../../doc/api/cards.md#create-card)
* [Retrieve Card](../../doc/api/cards.md#retrieve-card)
* [Disable Card](../../doc/api/cards.md#disable-card)


# List Cards

Retrieves a list of cards owned by the account making the request.
A max of 25 cards will be returned.

```csharp
ListCardsAsync(
    string cursor = null,
    string customerId = null,
    bool? includeDisabled = false,
    string referenceId = null,
    string sortOrder = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination) for more information. |
| `customerId` | `string` | Query, Optional | Limit results to cards associated with the customer supplied.<br>By default, all cards owned by the merchant are returned. |
| `includeDisabled` | `bool?` | Query, Optional | Includes disabled cards.<br>By default, all enabled cards owned by the merchant are returned. |
| `referenceId` | `string` | Query, Optional | Limit results to cards associated with the reference_id supplied. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | Sorts the returned list by when the card was created with the specified order.<br>This field defaults to ASC. |

## Response Type

[`Task<Models.ListCardsResponse>`](../../doc/models/list-cards-response.md)

## Example Usage

```csharp
bool? includeDisabled = false;
try
{
    ListCardsResponse result = await cardsApi.ListCardsAsync(
        null,
        null,
        includeDisabled
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Card

Adds a card on file to an existing merchant.

```csharp
CreateCardAsync(
    Models.CreateCardRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateCardRequest`](../../doc/models/create-card-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateCardResponse>`](../../doc/models/create-card-response.md)

## Example Usage

```csharp
Models.CreateCardRequest body = new Models.CreateCardRequest.Builder(
    "4935a656-a929-4792-b97c-8848be85c27c",
    "cnon:uIbfJXhXETSP197M3GB",
    new Models.Card.Builder()
    .CardholderName("Amelia Earhart")
    .BillingAddress(
        new Models.Address.Builder()
        .AddressLine1("500 Electric Ave")
        .AddressLine2("Suite 600")
        .Locality("New York")
        .AdministrativeDistrictLevel1("NY")
        .PostalCode("10003")
        .Country("US")
        .Build())
    .CustomerId("VDKXEEKPJN48QDG3BGGFAK05P8")
    .ReferenceId("user-id-1")
    .Build()
)
.Build();

try
{
    CreateCardResponse result = await cardsApi.CreateCardAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Card

Retrieves details for a specific Card.

```csharp
RetrieveCardAsync(
    string cardId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cardId` | `string` | Template, Required | Unique ID for the desired Card. |

## Response Type

[`Task<Models.RetrieveCardResponse>`](../../doc/models/retrieve-card-response.md)

## Example Usage

```csharp
string cardId = "card_id4";
try
{
    RetrieveCardResponse result = await cardsApi.RetrieveCardAsync(cardId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Disable Card

Disables the card, preventing any further updates or charges.
Disabling an already disabled card is allowed but has no effect.

```csharp
DisableCardAsync(
    string cardId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cardId` | `string` | Template, Required | Unique ID for the desired Card. |

## Response Type

[`Task<Models.DisableCardResponse>`](../../doc/models/disable-card-response.md)

## Example Usage

```csharp
string cardId = "card_id4";
try
{
    DisableCardResponse result = await cardsApi.DisableCardAsync(cardId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

