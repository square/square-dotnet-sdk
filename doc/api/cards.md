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
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Pagination](../../https://developer.squareup.com/docs/basics/api101/pagination) for more information. |
| `customerId` | `string` | Query, Optional | Limit results to cards associated with the customer supplied.<br>By default, all cards owned by the merchant are returned. |
| `includeDisabled` | `bool?` | Query, Optional | Includes disabled cards.<br>By default, all enabled cards owned by the merchant are returned.<br>**Default**: `false` |
| `referenceId` | `string` | Query, Optional | Limit results to cards associated with the reference_id supplied. |
| `sortOrder` | [`string`](../../doc/models/sort-order.md) | Query, Optional | Sorts the returned list by when the card was created with the specified order.<br>This field defaults to ASC. |

## Response Type

[`Task<Models.ListCardsResponse>`](../../doc/models/list-cards-response.md)

## Example Usage

```csharp
string cursor = "cursor6";
string customerId = "customer_id8";
bool? includeDisabled = false;
string referenceId = "reference_id2";
string sortOrder = "DESC";

try
{
    ListCardsResponse result = await cardsApi.ListCardsAsync(cursor, customerId, includeDisabled, referenceId, sortOrder);
}
catch (ApiException e){};
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
| `body` | [`Models.CreateCardRequest`](../../doc/models/create-card-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateCardResponse>`](../../doc/models/create-card-response.md)

## Example Usage

```csharp
var bodyCardBillingAddress = new Address.Builder()
    .AddressLine1("500 Electric Ave")
    .AddressLine2("Suite 600")
    .AddressLine3("address_line_34")
    .Locality("New York")
    .Sublocality("sublocality8")
    .AdministrativeDistrictLevel1("NY")
    .PostalCode("10003")
    .Country("US")
    .Build();
var bodyCard = new Card.Builder()
    .Id("id0")
    .CardBrand("INTERAC")
    .Last4("last_42")
    .ExpMonth(236L)
    .ExpYear(60L)
    .CardholderName("Amelia Earhart")
    .BillingAddress(bodyCardBillingAddress)
    .CustomerId("VDKXEEKPJN48QDG3BGGFAK05P8")
    .ReferenceId("user-id-1")
    .Build();
var body = new CreateCardRequest.Builder(
        "4935a656-a929-4792-b97c-8848be85c27c",
        "cnon:uIbfJXhXETSP197M3GB",
        bodyCard)
    .VerificationToken("verification_token0")
    .Build();

try
{
    CreateCardResponse result = await cardsApi.CreateCardAsync(body);
}
catch (ApiException e){};
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
catch (ApiException e){};
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
catch (ApiException e){};
```

