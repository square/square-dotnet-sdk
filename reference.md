# Reference
## Mobile
<details><summary><code>client.Mobile.<a href="/src/Square/Mobile/MobileClient.cs">AuthorizationCodeAsync</a>(CreateMobileAuthorizationCodeRequest { ... }) -> CreateMobileAuthorizationCodeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

__Note:__ This endpoint is used by the deprecated Reader SDK. 
Developers should update their integration to use the [Mobile Payments SDK](https://developer.squareup.com/docs/mobile-payments-sdk), which includes its own authorization methods. 

Generates code to authorize a mobile application to connect to a Square card reader.

Authorization codes are one-time-use codes and expire 60 minutes after being issued.

The `Authorization` header you provide to this endpoint must have the following format:

```
Authorization: Bearer ACCESS_TOKEN
```

Replace `ACCESS_TOKEN` with a
[valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Mobile.AuthorizationCodeAsync(
    new CreateMobileAuthorizationCodeRequest { LocationId = "YOUR_LOCATION_ID" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateMobileAuthorizationCodeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## OAuth
<details><summary><code>client.OAuth.<a href="/src/Square/OAuth/OAuthClient.cs">RevokeTokenAsync</a>(RevokeTokenRequest { ... }) -> RevokeTokenResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Revokes an access token generated with the OAuth flow.

If an account has more than one OAuth access token for your application, this
endpoint revokes all of them, regardless of which token you specify. 

__Important:__ The `Authorization` header for this endpoint must have the
following format:

```
Authorization: Client APPLICATION_SECRET
```

Replace `APPLICATION_SECRET` with the application secret on the **OAuth**
page for your application in the Developer Dashboard.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OAuth.RevokeTokenAsync(
    new RevokeTokenRequest { ClientId = "CLIENT_ID", AccessToken = "ACCESS_TOKEN" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RevokeTokenRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OAuth.<a href="/src/Square/OAuth/OAuthClient.cs">ObtainTokenAsync</a>(ObtainTokenRequest { ... }) -> ObtainTokenResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns an OAuth access token and refresh token using the `authorization_code`
or `refresh_token` grant type.

When `grant_type` is `authorization_code`:
- With the [code flow](https://developer.squareup.com/docs/oauth-api/overview#code-flow),
provide `code`, `client_id`, and `client_secret`.
- With the [PKCE flow](https://developer.squareup.com/docs/oauth-api/overview#pkce-flow),
provide `code`, `client_id`, and `code_verifier`. 

When `grant_type` is `refresh_token`:
- With the code flow, provide `refresh_token`, `client_id`, and `client_secret`.
The response returns the same refresh token provided in the request.
- With the PKCE flow, provide `refresh_token` and `client_id`. The response returns
a new refresh token.

You can use the `scopes` parameter to limit the set of permissions authorized by the
access token. You can use the `short_lived` parameter to create an access token that
expires in 24 hours.

__Important:__ OAuth tokens should be encrypted and stored on a secure server.
Application clients should never interact directly with OAuth tokens.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OAuth.ObtainTokenAsync(
    new ObtainTokenRequest
    {
        ClientId = "sq0idp-uaPHILoPzWZk3tlJqlML0g",
        ClientSecret = "sq0csp-30a-4C_tVOnTh14Piza2BfTPBXyLafLPWSzY1qAjeBfM",
        Code = "sq0cgb-l0SBqxs4uwxErTVyYOdemg",
        GrantType = "authorization_code",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ObtainTokenRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OAuth.<a href="/src/Square/OAuth/OAuthClient.cs">RetrieveTokenStatusAsync</a>() -> RetrieveTokenStatusResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns information about an [OAuth access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-an-oauth-access-token) or an application’s [personal access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-a-personal-access-token).

Add the access token to the Authorization header of the request.

__Important:__ The `Authorization` header you provide to this endpoint must have the following format:

```
Authorization: Bearer ACCESS_TOKEN
```

where `ACCESS_TOKEN` is a
[valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).

If the access token is expired or not a valid access token, the endpoint returns an `UNAUTHORIZED` error.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OAuth.RetrieveTokenStatusAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.OAuth.<a href="/src/Square/OAuth/OAuthClient.cs">AuthorizeAsync</a>()</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.OAuth.AuthorizeAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## V1Transactions
<details><summary><code>client.V1Transactions.<a href="/src/Square/V1Transactions/V1TransactionsClient.cs">V1ListOrdersAsync</a>(V1ListOrdersRequest { ... }) -> IEnumerable<V1Order></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides summary information for a merchant's online store orders.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.V1Transactions.V1ListOrdersAsync(
    new V1ListOrdersRequest { LocationId = "location_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `V1ListOrdersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.V1Transactions.<a href="/src/Square/V1Transactions/V1TransactionsClient.cs">V1RetrieveOrderAsync</a>(V1RetrieveOrderRequest { ... }) -> V1Order</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides comprehensive information for a single online store order, including the order's history.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.V1Transactions.V1RetrieveOrderAsync(
    new V1RetrieveOrderRequest { LocationId = "location_id", OrderId = "order_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `V1RetrieveOrderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.V1Transactions.<a href="/src/Square/V1Transactions/V1TransactionsClient.cs">V1UpdateOrderAsync</a>(V1UpdateOrderRequest { ... }) -> V1Order</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the details of an online store order. Every update you perform on an order corresponds to one of three actions:
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.V1Transactions.V1UpdateOrderAsync(
    new V1UpdateOrderRequest
    {
        LocationId = "location_id",
        OrderId = "order_id",
        Action = V1UpdateOrderRequestAction.Complete,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `V1UpdateOrderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ApplePay
<details><summary><code>client.ApplePay.<a href="/src/Square/ApplePay/ApplePayClient.cs">RegisterDomainAsync</a>(RegisterDomainRequest { ... }) -> RegisterDomainResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Activates a domain for use with Apple Pay on the Web and Square. A validation
is performed on this domain by Apple to ensure that it is properly set up as
an Apple Pay enabled domain.

This endpoint provides an easy way for platform developers to bulk activate
Apple Pay on the Web with Square for merchants using their platform.

Note: You will need to host a valid domain verification file on your domain to support Apple Pay.  The
current version of this file is always available at https://app.squareup.com/digital-wallets/apple-pay/apple-developer-merchantid-domain-association,
and should be hosted at `.well_known/apple-developer-merchantid-domain-association` on your
domain.  This file is subject to change; we strongly recommend checking for updates regularly and avoiding
long-lived caches that might not keep in sync with the correct file version.

To learn more about the Web Payments SDK and how to add Apple Pay, see [Take an Apple Pay Payment](https://developer.squareup.com/docs/web-payments/apple-pay).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ApplePay.RegisterDomainAsync(new RegisterDomainRequest { DomainName = "example.com" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RegisterDomainRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## BankAccounts
<details><summary><code>client.BankAccounts.<a href="/src/Square/BankAccounts/BankAccountsClient.cs">ListAsync</a>(ListBankAccountsRequest { ... }) -> Pager<BankAccount></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of [BankAccount](entity:BankAccount) objects linked to a Square account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BankAccounts.ListAsync(new ListBankAccountsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBankAccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.BankAccounts.<a href="/src/Square/BankAccounts/BankAccountsClient.cs">GetByV1IdAsync</a>(GetByV1IdBankAccountsRequest { ... }) -> GetBankAccountByV1IdResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns details of a [BankAccount](entity:BankAccount) identified by V1 bank account ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BankAccounts.GetByV1IdAsync(
    new GetByV1IdBankAccountsRequest { V1BankAccountId = "v1_bank_account_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetByV1IdBankAccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.BankAccounts.<a href="/src/Square/BankAccounts/BankAccountsClient.cs">GetAsync</a>(GetBankAccountsRequest { ... }) -> GetBankAccountResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns details of a [BankAccount](entity:BankAccount)
linked to a Square account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.BankAccounts.GetAsync(
    new GetBankAccountsRequest { BankAccountId = "bank_account_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBankAccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Bookings
<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">ListAsync</a>(ListBookingsRequest { ... }) -> Pager<Booking></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a collection of bookings.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.ListAsync(new ListBookingsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBookingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">CreateAsync</a>(CreateBookingRequest { ... }) -> CreateBookingResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a booking.

The required input must include the following:
- `Booking.location_id`
- `Booking.start_at`
- `Booking.AppointmentSegment.team_member_id`
- `Booking.AppointmentSegment.service_variation_id`
- `Booking.AppointmentSegment.service_variation_version`

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.CreateAsync(new CreateBookingRequest { Booking = new Booking() });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateBookingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">SearchAvailabilityAsync</a>(SearchAvailabilityRequest { ... }) -> SearchAvailabilityResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for availabilities for booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.SearchAvailabilityAsync(
    new SearchAvailabilityRequest
    {
        Query = new SearchAvailabilityQuery
        {
            Filter = new SearchAvailabilityFilter { StartAtRange = new TimeRange() },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchAvailabilityRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">BulkRetrieveBookingsAsync</a>(BulkRetrieveBookingsRequest { ... }) -> BulkRetrieveBookingsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Bulk-Retrieves a list of bookings by booking IDs.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.BulkRetrieveBookingsAsync(
    new BulkRetrieveBookingsRequest { BookingIds = new List<string>() { "booking_ids" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkRetrieveBookingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">GetBusinessProfileAsync</a>() -> GetBusinessBookingProfileResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a seller's booking profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.GetBusinessProfileAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">RetrieveLocationBookingProfileAsync</a>(RetrieveLocationBookingProfileRequest { ... }) -> RetrieveLocationBookingProfileResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a seller's location booking profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.RetrieveLocationBookingProfileAsync(
    new RetrieveLocationBookingProfileRequest { LocationId = "location_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RetrieveLocationBookingProfileRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">BulkRetrieveTeamMemberBookingProfilesAsync</a>(BulkRetrieveTeamMemberBookingProfilesRequest { ... }) -> BulkRetrieveTeamMemberBookingProfilesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves one or more team members' booking profiles.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.BulkRetrieveTeamMemberBookingProfilesAsync(
    new BulkRetrieveTeamMemberBookingProfilesRequest
    {
        TeamMemberIds = new List<string>() { "team_member_ids" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkRetrieveTeamMemberBookingProfilesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">GetAsync</a>(GetBookingsRequest { ... }) -> GetBookingResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.GetAsync(new GetBookingsRequest { BookingId = "booking_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBookingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">UpdateAsync</a>(UpdateBookingRequest { ... }) -> UpdateBookingResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.UpdateAsync(
    new UpdateBookingRequest { BookingId = "booking_id", Booking = new Booking() }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateBookingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.<a href="/src/Square/Bookings/BookingsClient.cs">CancelAsync</a>(CancelBookingRequest { ... }) -> CancelBookingResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels an existing booking.

To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.

For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
or *Appointments Premium*.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Bookings.CancelAsync(new CancelBookingRequest { BookingId = "booking_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CancelBookingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Cards
<details><summary><code>client.Cards.<a href="/src/Square/Cards/CardsClient.cs">ListAsync</a>(ListCardsRequest { ... }) -> Pager<Card></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of cards owned by the account making the request.
A max of 25 cards will be returned.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cards.ListAsync(new ListCardsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cards.<a href="/src/Square/Cards/CardsClient.cs">CreateAsync</a>(CreateCardRequest { ... }) -> CreateCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds a card on file to an existing merchant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cards.CreateAsync(
    new CreateCardRequest
    {
        IdempotencyKey = "4935a656-a929-4792-b97c-8848be85c27c",
        SourceId = "cnon:uIbfJXhXETSP197M3GB",
        Card = new Card
        {
            CardholderName = "Amelia Earhart",
            BillingAddress = new Address
            {
                AddressLine1 = "500 Electric Ave",
                AddressLine2 = "Suite 600",
                Locality = "New York",
                AdministrativeDistrictLevel1 = "NY",
                PostalCode = "10003",
                Country = Country.Us,
            },
            CustomerId = "VDKXEEKPJN48QDG3BGGFAK05P8",
            ReferenceId = "user-id-1",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateCardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cards.<a href="/src/Square/Cards/CardsClient.cs">GetAsync</a>(GetCardsRequest { ... }) -> GetCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details for a specific Card.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cards.GetAsync(new GetCardsRequest { CardId = "card_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Cards.<a href="/src/Square/Cards/CardsClient.cs">DisableAsync</a>(DisableCardsRequest { ... }) -> DisableCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Disables the card, preventing any further updates or charges.
Disabling an already disabled card is allowed but has no effect.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Cards.DisableAsync(new DisableCardsRequest { CardId = "card_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DisableCardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Catalog
<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">BatchDeleteAsync</a>(BatchDeleteCatalogObjectsRequest { ... }) -> BatchDeleteCatalogObjectsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a set of [CatalogItem](entity:CatalogItem)s based on the
provided list of target IDs and returns a set of successfully deleted IDs in
the response. Deletion is a cascading event such that all children of the
targeted object are also deleted. For example, deleting a CatalogItem will
also delete all of its [CatalogItemVariation](entity:CatalogItemVariation)
children.

`BatchDeleteCatalogObjects` succeeds even if only a portion of the targeted
IDs can be deleted. The response will only include IDs that were
actually deleted.

To ensure consistency, only one delete request is processed at a time per seller account.
While one (batch or non-batch) delete request is being processed, other (batched and non-batched)
delete requests are rejected with the `429` error code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.BatchDeleteAsync(
    new BatchDeleteCatalogObjectsRequest
    {
        ObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI", "AA27W3M2GGTF3H6AVPNB77CK" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BatchDeleteCatalogObjectsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">BatchGetAsync</a>(BatchGetCatalogObjectsRequest { ... }) -> BatchGetCatalogObjectsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a set of objects based on the provided ID.
Each [CatalogItem](entity:CatalogItem) returned in the set includes all of its
child information including: all of its
[CatalogItemVariation](entity:CatalogItemVariation) objects, references to
its [CatalogModifierList](entity:CatalogModifierList) objects, and the ids of
any [CatalogTax](entity:CatalogTax) objects that apply to it.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.BatchGetAsync(
    new BatchGetCatalogObjectsRequest
    {
        ObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI", "AA27W3M2GGTF3H6AVPNB77CK" },
        IncludeRelatedObjects = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BatchGetCatalogObjectsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">BatchUpsertAsync</a>(BatchUpsertCatalogObjectsRequest { ... }) -> BatchUpsertCatalogObjectsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates up to 10,000 target objects based on the provided
list of objects. The target objects are grouped into batches and each batch is
inserted/updated in an all-or-nothing manner. If an object within a batch is
malformed in some way, or violates a database constraint, the entire batch
containing that item will be disregarded. However, other batches in the same
request may still succeed. Each batch may contain up to 1,000 objects, and
batches will be processed in order as long as the total object count for the
request (items, variations, modifier lists, discounts, and taxes) is no more
than 10,000.

To ensure consistency, only one update request is processed at a time per seller account.
While one (batch or non-batch) update request is being processed, other (batched and non-batched)
update requests are rejected with the `429` error code.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.BatchUpsertAsync(
    new BatchUpsertCatalogObjectsRequest
    {
        IdempotencyKey = "789ff020-f723-43a9-b4b5-43b5dc1fa3dc",
        Batches = new List<CatalogObjectBatch>()
        {
            new CatalogObjectBatch
            {
                Objects = new List<CatalogObject>()
                {
                    new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
                    new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
                    new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
                    new CatalogObject(new CatalogObject.Tax(new CatalogObjectTax { Id = "id" })),
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BatchUpsertCatalogObjectsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">InfoAsync</a>() -> CatalogInfoResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves information about the Square Catalog API, such as batch size
limits that can be used by the `BatchUpsertCatalogObjects` endpoint.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.InfoAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">ListAsync</a>(ListCatalogRequest { ... }) -> Pager<CatalogObject></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of all [CatalogObject](entity:CatalogObject)s of the specified types in the catalog.

The `types` parameter is specified as a comma-separated list of the [CatalogObjectType](entity:CatalogObjectType) values,
for example, "`ITEM`, `ITEM_VARIATION`, `MODIFIER`, `MODIFIER_LIST`, `CATEGORY`, `DISCOUNT`, `TAX`, `IMAGE`".

__Important:__ ListCatalog does not return deleted catalog items. To retrieve
deleted catalog items, use [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects)
and set the `include_deleted_objects` attribute value to `true`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.ListAsync(new ListCatalogRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCatalogRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">SearchAsync</a>(SearchCatalogObjectsRequest { ... }) -> SearchCatalogObjectsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for [CatalogObject](entity:CatalogObject) of any type by matching supported search attribute values,
excluding custom attribute values on items or item variations, against one or more of the specified query filters.

This (`SearchCatalogObjects`) endpoint differs from the [SearchCatalogItems](api-endpoint:Catalog-SearchCatalogItems)
endpoint in the following aspects:

- `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
- `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
- `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
- The both endpoints have different call conventions, including the query filter formats.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.SearchAsync(
    new SearchCatalogObjectsRequest
    {
        ObjectTypes = new List<CatalogObjectType>() { CatalogObjectType.Item },
        Query = new CatalogQuery
        {
            PrefixQuery = new CatalogQueryPrefix
            {
                AttributeName = "name",
                AttributePrefix = "tea",
            },
        },
        Limit = 100,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchCatalogObjectsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">SearchItemsAsync</a>(SearchCatalogItemsRequest { ... }) -> SearchCatalogItemsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for catalog items or item variations by matching supported search attribute values, including
custom attribute values, against one or more of the specified query filters.

This (`SearchCatalogItems`) endpoint differs from the [SearchCatalogObjects](api-endpoint:Catalog-SearchCatalogObjects)
endpoint in the following aspects:

- `SearchCatalogItems` can only search for items or item variations, whereas `SearchCatalogObjects` can search for any type of catalog objects.
- `SearchCatalogItems` supports the custom attribute query filters to return items or item variations that contain custom attribute values, where `SearchCatalogObjects` does not.
- `SearchCatalogItems` does not support the `include_deleted_objects` filter to search for deleted items or item variations, whereas `SearchCatalogObjects` does.
- The both endpoints use different call conventions, including the query filter formats.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.SearchItemsAsync(
    new SearchCatalogItemsRequest
    {
        TextFilter = "red",
        CategoryIds = new List<string>() { "WINE_CATEGORY_ID" },
        StockLevels = new List<SearchCatalogItemsRequestStockLevel>()
        {
            SearchCatalogItemsRequestStockLevel.Out,
            SearchCatalogItemsRequestStockLevel.Low,
        },
        EnabledLocationIds = new List<string>() { "ATL_LOCATION_ID" },
        Limit = 100,
        SortOrder = SortOrder.Asc,
        ProductTypes = new List<CatalogItemProductType>() { CatalogItemProductType.Regular },
        CustomAttributeFilters = new List<CustomAttributeFilter>()
        {
            new CustomAttributeFilter
            {
                CustomAttributeDefinitionId = "VEGAN_DEFINITION_ID",
                BoolFilter = true,
            },
            new CustomAttributeFilter
            {
                CustomAttributeDefinitionId = "BRAND_DEFINITION_ID",
                StringFilter = "Dark Horse",
            },
            new CustomAttributeFilter
            {
                Key = "VINTAGE",
                NumberFilter = new Range { Min = "min", Max = "max" },
            },
            new CustomAttributeFilter { CustomAttributeDefinitionId = "VARIETAL_DEFINITION_ID" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchCatalogItemsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">UpdateItemModifierListsAsync</a>(UpdateItemModifierListsRequest { ... }) -> UpdateItemModifierListsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the [CatalogModifierList](entity:CatalogModifierList) objects
that apply to the targeted [CatalogItem](entity:CatalogItem) without having
to perform an upsert on the entire item.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.UpdateItemModifierListsAsync(
    new UpdateItemModifierListsRequest
    {
        ItemIds = new List<string>() { "H42BRLUJ5KTZTTMPVSLFAACQ", "2JXOBJIHCWBQ4NZ3RIXQGJA6" },
        ModifierListsToEnable = new List<string>()
        {
            "H42BRLUJ5KTZTTMPVSLFAACQ",
            "2JXOBJIHCWBQ4NZ3RIXQGJA6",
        },
        ModifierListsToDisable = new List<string>() { "7WRC16CJZDVLSNDQ35PP6YAD" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateItemModifierListsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.<a href="/src/Square/Catalog/CatalogClient.cs">UpdateItemTaxesAsync</a>(UpdateItemTaxesRequest { ... }) -> UpdateItemTaxesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the [CatalogTax](entity:CatalogTax) objects that apply to the
targeted [CatalogItem](entity:CatalogItem) without having to perform an
upsert on the entire item.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Catalog.UpdateItemTaxesAsync(
    new UpdateItemTaxesRequest
    {
        ItemIds = new List<string>() { "H42BRLUJ5KTZTTMPVSLFAACQ", "2JXOBJIHCWBQ4NZ3RIXQGJA6" },
        TaxesToEnable = new List<string>() { "4WRCNHCJZDVLSNDQ35PP6YAD" },
        TaxesToDisable = new List<string>() { "AQCEGCEBBQONINDOHRGZISEX" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateItemTaxesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Customers
<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">ListAsync</a>(ListCustomersRequest { ... }) -> Pager<Customer></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists customer profiles associated with a Square account.

Under normal operating conditions, newly created or updated customer profiles become available
for the listing operation in well under 30 seconds. Occasionally, propagation of the new or updated
profiles can take closer to one minute or longer, especially during network incidents and outages.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.ListAsync(new ListCustomersRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">CreateAsync</a>(CreateCustomerRequest { ... }) -> CreateCustomerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new customer for a business.

You must provide at least one of the following values in your request to this
endpoint:

- `given_name`
- `family_name`
- `company_name`
- `email_address`
- `phone_number`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.CreateAsync(
    new CreateCustomerRequest
    {
        GivenName = "Amelia",
        FamilyName = "Earhart",
        EmailAddress = "Amelia.Earhart@example.com",
        Address = new Address
        {
            AddressLine1 = "500 Electric Ave",
            AddressLine2 = "Suite 600",
            Locality = "New York",
            AdministrativeDistrictLevel1 = "NY",
            PostalCode = "10003",
            Country = Country.Us,
        },
        PhoneNumber = "+1-212-555-4240",
        ReferenceId = "YOUR_REFERENCE_ID",
        Note = "a customer",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateCustomerRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">BatchCreateAsync</a>(BulkCreateCustomersRequest { ... }) -> BulkCreateCustomersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates multiple [customer profiles](entity:Customer) for a business.

This endpoint takes a map of individual create requests and returns a map of responses.

You must provide at least one of the following values in each create request:

- `given_name`
- `family_name`
- `company_name`
- `email_address`
- `phone_number`
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.BatchCreateAsync(
    new BulkCreateCustomersRequest
    {
        Customers = new Dictionary<string, BulkCreateCustomerData>()
        {
            {
                "8bb76c4f-e35d-4c5b-90de-1194cd9179f0",
                new BulkCreateCustomerData
                {
                    GivenName = "Amelia",
                    FamilyName = "Earhart",
                    EmailAddress = "Amelia.Earhart@example.com",
                    Address = new Address
                    {
                        AddressLine1 = "500 Electric Ave",
                        AddressLine2 = "Suite 600",
                        Locality = "New York",
                        AdministrativeDistrictLevel1 = "NY",
                        PostalCode = "10003",
                        Country = Country.Us,
                    },
                    PhoneNumber = "+1-212-555-4240",
                    ReferenceId = "YOUR_REFERENCE_ID",
                    Note = "a customer",
                }
            },
            {
                "d1689f23-b25d-4932-b2f0-aed00f5e2029",
                new BulkCreateCustomerData
                {
                    GivenName = "Marie",
                    FamilyName = "Curie",
                    EmailAddress = "Marie.Curie@example.com",
                    Address = new Address
                    {
                        AddressLine1 = "500 Electric Ave",
                        AddressLine2 = "Suite 601",
                        Locality = "New York",
                        AdministrativeDistrictLevel1 = "NY",
                        PostalCode = "10003",
                        Country = Country.Us,
                    },
                    PhoneNumber = "+1-212-444-4240",
                    ReferenceId = "YOUR_REFERENCE_ID",
                    Note = "another customer",
                }
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkCreateCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">BulkDeleteCustomersAsync</a>(BulkDeleteCustomersRequest { ... }) -> BulkDeleteCustomersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes multiple customer profiles.

The endpoint takes a list of customer IDs and returns a map of responses.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.BulkDeleteCustomersAsync(
    new BulkDeleteCustomersRequest
    {
        CustomerIds = new List<string>()
        {
            "8DDA5NZVBZFGAX0V3HPF81HHE0",
            "N18CPRVXR5214XPBBA6BZQWF3C",
            "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkDeleteCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">BulkRetrieveCustomersAsync</a>(BulkRetrieveCustomersRequest { ... }) -> BulkRetrieveCustomersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves multiple customer profiles.

This endpoint takes a list of customer IDs and returns a map of responses.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.BulkRetrieveCustomersAsync(
    new BulkRetrieveCustomersRequest
    {
        CustomerIds = new List<string>()
        {
            "8DDA5NZVBZFGAX0V3HPF81HHE0",
            "N18CPRVXR5214XPBBA6BZQWF3C",
            "2GYD7WNXF7BJZW1PMGNXZ3Y8M8",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkRetrieveCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">BulkUpdateCustomersAsync</a>(BulkUpdateCustomersRequest { ... }) -> BulkUpdateCustomersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates multiple customer profiles.

This endpoint takes a map of individual update requests and returns a map of responses.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.BulkUpdateCustomersAsync(
    new BulkUpdateCustomersRequest
    {
        Customers = new Dictionary<string, BulkUpdateCustomerData>()
        {
            {
                "8DDA5NZVBZFGAX0V3HPF81HHE0",
                new BulkUpdateCustomerData
                {
                    EmailAddress = "New.Amelia.Earhart@example.com",
                    Note = "updated customer note",
                    Version = 2,
                }
            },
            {
                "N18CPRVXR5214XPBBA6BZQWF3C",
                new BulkUpdateCustomerData
                {
                    GivenName = "Marie",
                    FamilyName = "Curie",
                    Version = 0,
                }
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkUpdateCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">SearchAsync</a>(SearchCustomersRequest { ... }) -> SearchCustomersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches the customer profiles associated with a Square account using one or more supported query filters.

Calling `SearchCustomers` without any explicit query filter returns all
customer profiles ordered alphabetically based on `given_name` and
`family_name`.

Under normal operating conditions, newly created or updated customer profiles become available
for the search operation in well under 30 seconds. Occasionally, propagation of the new or updated
profiles can take closer to one minute or longer, especially during network incidents and outages.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.SearchAsync(
    new SearchCustomersRequest
    {
        Limit = 2,
        Query = new CustomerQuery
        {
            Filter = new CustomerFilter
            {
                CreationSource = new CustomerCreationSourceFilter
                {
                    Values = new List<CustomerCreationSource>()
                    {
                        CustomerCreationSource.ThirdParty,
                    },
                    Rule = CustomerInclusionExclusion.Include,
                },
                CreatedAt = new TimeRange
                {
                    StartAt = "2018-01-01T00:00:00-00:00",
                    EndAt = "2018-02-01T00:00:00-00:00",
                },
                EmailAddress = new CustomerTextFilter { Fuzzy = "example.com" },
                GroupIds = new FilterValue
                {
                    All = new List<string>() { "545AXB44B4XXWMVQ4W8SBT3HHF" },
                },
            },
            Sort = new CustomerSort { Field = CustomerSortField.CreatedAt, Order = SortOrder.Asc },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">GetAsync</a>(GetCustomersRequest { ... }) -> GetCustomerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns details for a single customer.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.GetAsync(new GetCustomersRequest { CustomerId = "customer_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">UpdateAsync</a>(UpdateCustomerRequest { ... }) -> UpdateCustomerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a customer profile. This endpoint supports sparse updates, so only new or changed fields are required in the request.
To add or update a field, specify the new value. To remove a field, specify `null`.

To update a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.UpdateAsync(
    new UpdateCustomerRequest
    {
        CustomerId = "customer_id",
        EmailAddress = "New.Amelia.Earhart@example.com",
        Note = "updated customer note",
        Version = 2,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateCustomerRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.<a href="/src/Square/Customers/CustomersClient.cs">DeleteAsync</a>(DeleteCustomersRequest { ... }) -> DeleteCustomerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a customer profile from a business.

To delete a customer profile that was created by merging existing profiles, you must use the ID of the newly created profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Customers.DeleteAsync(new DeleteCustomersRequest { CustomerId = "customer_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteCustomersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Devices
<details><summary><code>client.Devices.<a href="/src/Square/Devices/DevicesClient.cs">ListAsync</a>(ListDevicesRequest { ... }) -> Pager<Device></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List devices associated with the merchant. Currently, only Terminal API
devices are supported.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Devices.ListAsync(new ListDevicesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDevicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Devices.<a href="/src/Square/Devices/DevicesClient.cs">GetAsync</a>(GetDevicesRequest { ... }) -> GetDeviceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves Device with the associated `device_id`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Devices.GetAsync(new GetDevicesRequest { DeviceId = "device_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDevicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Disputes
<details><summary><code>client.Disputes.<a href="/src/Square/Disputes/DisputesClient.cs">ListAsync</a>(ListDisputesRequest { ... }) -> Pager<Dispute></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of disputes associated with a particular account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Disputes.ListAsync(new ListDisputesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDisputesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Disputes.<a href="/src/Square/Disputes/DisputesClient.cs">GetAsync</a>(GetDisputesRequest { ... }) -> GetDisputeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns details about a specific dispute.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Disputes.GetAsync(new GetDisputesRequest { DisputeId = "dispute_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDisputesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Disputes.<a href="/src/Square/Disputes/DisputesClient.cs">AcceptAsync</a>(AcceptDisputesRequest { ... }) -> AcceptDisputeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and
updates the dispute state to ACCEPTED.

Square debits the disputed amount from the seller’s Square account. If the Square account
does not have sufficient funds, Square debits the associated bank account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Disputes.AcceptAsync(new AcceptDisputesRequest { DisputeId = "dispute_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `AcceptDisputesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Disputes.<a href="/src/Square/Disputes/DisputesClient.cs">CreateEvidenceTextAsync</a>(CreateDisputeEvidenceTextRequest { ... }) -> CreateDisputeEvidenceTextResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Uploads text to use as evidence for a dispute challenge.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Disputes.CreateEvidenceTextAsync(
    new CreateDisputeEvidenceTextRequest
    {
        DisputeId = "dispute_id",
        IdempotencyKey = "ed3ee3933d946f1514d505d173c82648",
        EvidenceType = DisputeEvidenceType.TrackingNumber,
        EvidenceText = "1Z8888888888888888",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateDisputeEvidenceTextRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Disputes.<a href="/src/Square/Disputes/DisputesClient.cs">SubmitEvidenceAsync</a>(SubmitEvidenceDisputesRequest { ... }) -> SubmitEvidenceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Submits evidence to the cardholder's bank.

The evidence submitted by this endpoint includes evidence uploaded
using the [CreateDisputeEvidenceFile](api-endpoint:Disputes-CreateDisputeEvidenceFile) and
[CreateDisputeEvidenceText](api-endpoint:Disputes-CreateDisputeEvidenceText) endpoints and
evidence automatically provided by Square, when available. Evidence cannot be removed from
a dispute after submission.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Disputes.SubmitEvidenceAsync(
    new SubmitEvidenceDisputesRequest { DisputeId = "dispute_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SubmitEvidenceDisputesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Employees
<details><summary><code>client.Employees.<a href="/src/Square/Employees/EmployeesClient.cs">ListAsync</a>(ListEmployeesRequest { ... }) -> Pager<Employee></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>


</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Employees.ListAsync(new ListEmployeesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListEmployeesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Employees.<a href="/src/Square/Employees/EmployeesClient.cs">GetAsync</a>(GetEmployeesRequest { ... }) -> GetEmployeeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>


</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Employees.GetAsync(new GetEmployeesRequest { Id = "id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetEmployeesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Events
<details><summary><code>client.Events.<a href="/src/Square/Events/EventsClient.cs">SearchEventsAsync</a>(SearchEventsRequest { ... }) -> SearchEventsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search for Square API events that occur within a 28-day timeframe.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.SearchEventsAsync(new SearchEventsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SearchEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Events.<a href="/src/Square/Events/EventsClient.cs">DisableEventsAsync</a>() -> DisableEventsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Disables events to prevent them from being searchable.
All events are disabled by default. You must enable events to make them searchable.
Disabling events for a specific time period prevents them from being searchable, even if you re-enable them later.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.DisableEventsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Events.<a href="/src/Square/Events/EventsClient.cs">EnableEventsAsync</a>() -> EnableEventsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Enables events to make them searchable. Only events that occur while in the enabled state are searchable.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Events.EnableEventsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Events.<a href="/src/Square/Events/EventsClient.cs">ListEventTypesAsync</a>(ListEventTypesRequest { ... }) -> ListEventTypesResponse</code></summary>