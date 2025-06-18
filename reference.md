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
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all event types that you can subscribe to as webhooks or query using the Events API.
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
await client.Events.ListEventTypesAsync(new ListEventTypesRequest());
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

**request:** `ListEventTypesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## GiftCards
<details><summary><code>client.GiftCards.<a href="/src/Square/GiftCards/GiftCardsClient.cs">ListAsync</a>(ListGiftCardsRequest { ... }) -> Pager<GiftCard></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all gift cards. You can specify optional filters to retrieve 
a subset of the gift cards. Results are sorted by `created_at` in ascending order.
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
await client.GiftCards.ListAsync(new ListGiftCardsRequest());
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

**request:** `ListGiftCardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.GiftCards.<a href="/src/Square/GiftCards/GiftCardsClient.cs">CreateAsync</a>(CreateGiftCardRequest { ... }) -> CreateGiftCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a digital gift card or registers a physical (plastic) gift card. The resulting gift card
has a `PENDING` state. To activate a gift card so that it can be redeemed for purchases, call
[CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) and create an `ACTIVATE`
activity with the initial balance. Alternatively, you can use [RefundPayment](api-endpoint:Refunds-RefundPayment)
to refund a payment to the new gift card.
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
await client.GiftCards.CreateAsync(
    new CreateGiftCardRequest
    {
        IdempotencyKey = "NC9Tm69EjbjtConu",
        LocationId = "81FN9BNFZTKS4",
        GiftCard = new GiftCard { Type = GiftCardType.Digital },
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

**request:** `CreateGiftCardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.GiftCards.<a href="/src/Square/GiftCards/GiftCardsClient.cs">GetFromGanAsync</a>(GetGiftCardFromGanRequest { ... }) -> GetGiftCardFromGanResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a gift card using the gift card account number (GAN).
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
await client.GiftCards.GetFromGanAsync(new GetGiftCardFromGanRequest { Gan = "7783320001001635" });
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

**request:** `GetGiftCardFromGanRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.GiftCards.<a href="/src/Square/GiftCards/GiftCardsClient.cs">GetFromNonceAsync</a>(GetGiftCardFromNonceRequest { ... }) -> GetGiftCardFromNonceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a gift card using a secure payment token that represents the gift card.
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
await client.GiftCards.GetFromNonceAsync(
    new GetGiftCardFromNonceRequest { Nonce = "cnon:7783322135245171" }
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

**request:** `GetGiftCardFromNonceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.GiftCards.<a href="/src/Square/GiftCards/GiftCardsClient.cs">LinkCustomerAsync</a>(LinkCustomerToGiftCardRequest { ... }) -> LinkCustomerToGiftCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Links a customer to a gift card, which is also referred to as adding a card on file.
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
await client.GiftCards.LinkCustomerAsync(
    new LinkCustomerToGiftCardRequest
    {
        GiftCardId = "gift_card_id",
        CustomerId = "GKY0FZ3V717AH8Q2D821PNT2ZW",
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

**request:** `LinkCustomerToGiftCardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.GiftCards.<a href="/src/Square/GiftCards/GiftCardsClient.cs">UnlinkCustomerAsync</a>(UnlinkCustomerFromGiftCardRequest { ... }) -> UnlinkCustomerFromGiftCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Unlinks a customer from a gift card, which is also referred to as removing a card on file.
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
await client.GiftCards.UnlinkCustomerAsync(
    new UnlinkCustomerFromGiftCardRequest
    {
        GiftCardId = "gift_card_id",
        CustomerId = "GKY0FZ3V717AH8Q2D821PNT2ZW",
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

**request:** `UnlinkCustomerFromGiftCardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.GiftCards.<a href="/src/Square/GiftCards/GiftCardsClient.cs">GetAsync</a>(GetGiftCardsRequest { ... }) -> GetGiftCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a gift card using the gift card ID.
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
await client.GiftCards.GetAsync(new GetGiftCardsRequest { Id = "id" });
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

**request:** `GetGiftCardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Inventory
<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">DeprecatedGetAdjustmentAsync</a>(DeprecatedGetAdjustmentInventoryRequest { ... }) -> GetInventoryAdjustmentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deprecated version of [RetrieveInventoryAdjustment](api-endpoint:Inventory-RetrieveInventoryAdjustment) after the endpoint URL
is updated to conform to the standard convention.
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
await client.Inventory.DeprecatedGetAdjustmentAsync(
    new DeprecatedGetAdjustmentInventoryRequest { AdjustmentId = "adjustment_id" }
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

**request:** `DeprecatedGetAdjustmentInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">GetAdjustmentAsync</a>(GetAdjustmentInventoryRequest { ... }) -> GetInventoryAdjustmentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the [InventoryAdjustment](entity:InventoryAdjustment) object
with the provided `adjustment_id`.
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
await client.Inventory.GetAdjustmentAsync(
    new GetAdjustmentInventoryRequest { AdjustmentId = "adjustment_id" }
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

**request:** `GetAdjustmentInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">DeprecatedBatchChangeAsync</a>(BatchChangeInventoryRequest { ... }) -> BatchChangeInventoryResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deprecated version of [BatchChangeInventory](api-endpoint:Inventory-BatchChangeInventory) after the endpoint URL
is updated to conform to the standard convention.
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
await client.Inventory.DeprecatedBatchChangeAsync(
    new BatchChangeInventoryRequest
    {
        IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
        Changes = new List<InventoryChange>()
        {
            new InventoryChange
            {
                Type = InventoryChangeType.PhysicalCount,
                PhysicalCount = new InventoryPhysicalCount
                {
                    ReferenceId = "1536bfbf-efed-48bf-b17d-a197141b2a92",
                    CatalogObjectId = "W62UWFY35CWMYGVWK6TWJDNI",
                    State = InventoryState.InStock,
                    LocationId = "C6W5YS5QM06F5",
                    Quantity = "53",
                    TeamMemberId = "LRK57NSQ5X7PUD05",
                    OccurredAt = "2016-11-16T22:25:24.878Z",
                },
            },
        },
        IgnoreUnchangedCounts = true,
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

**request:** `BatchChangeInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">DeprecatedBatchGetChangesAsync</a>(BatchRetrieveInventoryChangesRequest { ... }) -> BatchGetInventoryChangesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deprecated version of [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges) after the endpoint URL
is updated to conform to the standard convention.
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
await client.Inventory.DeprecatedBatchGetChangesAsync(
    new BatchRetrieveInventoryChangesRequest
    {
        CatalogObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI" },
        LocationIds = new List<string>() { "C6W5YS5QM06F5" },
        Types = new List<InventoryChangeType>() { InventoryChangeType.PhysicalCount },
        States = new List<InventoryState>() { InventoryState.InStock },
        UpdatedAfter = "2016-11-01T00:00:00.000Z",
        UpdatedBefore = "2016-12-01T00:00:00.000Z",
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

**request:** `BatchRetrieveInventoryChangesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">DeprecatedBatchGetCountsAsync</a>(BatchGetInventoryCountsRequest { ... }) -> BatchGetInventoryCountsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deprecated version of [BatchRetrieveInventoryCounts](api-endpoint:Inventory-BatchRetrieveInventoryCounts) after the endpoint URL
is updated to conform to the standard convention.
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
await client.Inventory.DeprecatedBatchGetCountsAsync(
    new BatchGetInventoryCountsRequest
    {
        CatalogObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI" },
        LocationIds = new List<string>() { "59TNP9SA8VGDA" },
        UpdatedAfter = "2016-11-16T00:00:00.000Z",
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

**request:** `BatchGetInventoryCountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">BatchCreateChangesAsync</a>(BatchChangeInventoryRequest { ... }) -> BatchChangeInventoryResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Applies adjustments and counts to the provided item quantities.

On success: returns the current calculated counts for all objects
referenced in the request.
On failure: returns a list of related errors.
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
await client.Inventory.BatchCreateChangesAsync(
    new BatchChangeInventoryRequest
    {
        IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
        Changes = new List<InventoryChange>()
        {
            new InventoryChange
            {
                Type = InventoryChangeType.PhysicalCount,
                PhysicalCount = new InventoryPhysicalCount
                {
                    ReferenceId = "1536bfbf-efed-48bf-b17d-a197141b2a92",
                    CatalogObjectId = "W62UWFY35CWMYGVWK6TWJDNI",
                    State = InventoryState.InStock,
                    LocationId = "C6W5YS5QM06F5",
                    Quantity = "53",
                    TeamMemberId = "LRK57NSQ5X7PUD05",
                    OccurredAt = "2016-11-16T22:25:24.878Z",
                },
            },
        },
        IgnoreUnchangedCounts = true,
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

**request:** `BatchChangeInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">BatchGetChangesAsync</a>(BatchRetrieveInventoryChangesRequest { ... }) -> Pager<InventoryChange></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns historical physical counts and adjustments based on the
provided filter criteria.

Results are paginated and sorted in ascending order according their
`occurred_at` timestamp (oldest first).

BatchRetrieveInventoryChanges is a catch-all query endpoint for queries
that cannot be handled by other, simpler endpoints.
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
await client.Inventory.BatchGetChangesAsync(
    new BatchRetrieveInventoryChangesRequest
    {
        CatalogObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI" },
        LocationIds = new List<string>() { "C6W5YS5QM06F5" },
        Types = new List<InventoryChangeType>() { InventoryChangeType.PhysicalCount },
        States = new List<InventoryState>() { InventoryState.InStock },
        UpdatedAfter = "2016-11-01T00:00:00.000Z",
        UpdatedBefore = "2016-12-01T00:00:00.000Z",
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

**request:** `BatchRetrieveInventoryChangesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">BatchGetCountsAsync</a>(BatchGetInventoryCountsRequest { ... }) -> Pager<InventoryCount></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns current counts for the provided
[CatalogObject](entity:CatalogObject)s at the requested
[Location](entity:Location)s.

Results are paginated and sorted in descending order according to their
`calculated_at` timestamp (newest first).

When `updated_after` is specified, only counts that have changed since that
time (based on the server timestamp for the most recent change) are
returned. This allows clients to perform a "sync" operation, for example
in response to receiving a Webhook notification.
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
await client.Inventory.BatchGetCountsAsync(
    new BatchGetInventoryCountsRequest
    {
        CatalogObjectIds = new List<string>() { "W62UWFY35CWMYGVWK6TWJDNI" },
        LocationIds = new List<string>() { "59TNP9SA8VGDA" },
        UpdatedAfter = "2016-11-16T00:00:00.000Z",
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

**request:** `BatchGetInventoryCountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">DeprecatedGetPhysicalCountAsync</a>(DeprecatedGetPhysicalCountInventoryRequest { ... }) -> GetInventoryPhysicalCountResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deprecated version of [RetrieveInventoryPhysicalCount](api-endpoint:Inventory-RetrieveInventoryPhysicalCount) after the endpoint URL
is updated to conform to the standard convention.
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
await client.Inventory.DeprecatedGetPhysicalCountAsync(
    new DeprecatedGetPhysicalCountInventoryRequest { PhysicalCountId = "physical_count_id" }
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

**request:** `DeprecatedGetPhysicalCountInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">GetPhysicalCountAsync</a>(GetPhysicalCountInventoryRequest { ... }) -> GetInventoryPhysicalCountResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the [InventoryPhysicalCount](entity:InventoryPhysicalCount)
object with the provided `physical_count_id`.
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
await client.Inventory.GetPhysicalCountAsync(
    new GetPhysicalCountInventoryRequest { PhysicalCountId = "physical_count_id" }
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

**request:** `GetPhysicalCountInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">GetTransferAsync</a>(GetTransferInventoryRequest { ... }) -> GetInventoryTransferResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the [InventoryTransfer](entity:InventoryTransfer) object
with the provided `transfer_id`.
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
await client.Inventory.GetTransferAsync(
    new GetTransferInventoryRequest { TransferId = "transfer_id" }
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

**request:** `GetTransferInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">GetAsync</a>(GetInventoryRequest { ... }) -> Pager<InventoryCount></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the current calculated stock count for a given
[CatalogObject](entity:CatalogObject) at a given set of
[Location](entity:Location)s. Responses are paginated and unsorted.
For more sophisticated queries, use a batch endpoint.
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
await client.Inventory.GetAsync(new GetInventoryRequest { CatalogObjectId = "catalog_object_id" });
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

**request:** `GetInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Inventory.<a href="/src/Square/Inventory/InventoryClient.cs">ChangesAsync</a>(ChangesInventoryRequest { ... }) -> Pager<InventoryChange></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a set of physical counts and inventory adjustments for the
provided [CatalogObject](entity:CatalogObject) at the requested
[Location](entity:Location)s.

You can achieve the same result by calling [BatchRetrieveInventoryChanges](api-endpoint:Inventory-BatchRetrieveInventoryChanges)
and having the `catalog_object_ids` list contain a single element of the `CatalogObject` ID.

Results are paginated and sorted in descending order according to their
`occurred_at` timestamp (newest first).

There are no limits on how far back the caller can page. This endpoint can be
used to display recent changes for a specific item. For more
sophisticated queries, use a batch endpoint.
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
await client.Inventory.ChangesAsync(
    new ChangesInventoryRequest { CatalogObjectId = "catalog_object_id" }
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

**request:** `ChangesInventoryRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Invoices
<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">ListAsync</a>(ListInvoicesRequest { ... }) -> Pager<Invoice></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of invoices for a given location. The response 
is paginated. If truncated, the response includes a `cursor` that you    
use in a subsequent request to retrieve the next set of invoices.
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
await client.Invoices.ListAsync(new ListInvoicesRequest { LocationId = "location_id" });
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

**request:** `ListInvoicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">CreateAsync</a>(CreateInvoiceRequest { ... }) -> CreateInvoiceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a draft [invoice](entity:Invoice) 
for an order created using the Orders API.

A draft invoice remains in your account and no action is taken. 
You must publish the invoice before Square can process it (send it to the customer's email address or charge the customer’s card on file).
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
await client.Invoices.CreateAsync(
    new CreateInvoiceRequest
    {
        Invoice = new Invoice
        {
            LocationId = "ES0RJRZYEC39A",
            OrderId = "CAISENgvlJ6jLWAzERDzjyHVybY",
            PrimaryRecipient = new InvoiceRecipient { CustomerId = "JDKYHBWT1D4F8MFH63DBMEN8Y4" },
            PaymentRequests = new List<InvoicePaymentRequest>()
            {
                new InvoicePaymentRequest
                {
                    RequestType = InvoiceRequestType.Balance,
                    DueDate = "2030-01-24",
                    TippingEnabled = true,
                    AutomaticPaymentSource = InvoiceAutomaticPaymentSource.None,
                    Reminders = new List<InvoicePaymentReminder>()
                    {
                        new InvoicePaymentReminder
                        {
                            RelativeScheduledDays = -1,
                            Message = "Your invoice is due tomorrow",
                        },
                    },
                },
            },
            DeliveryMethod = InvoiceDeliveryMethod.Email,
            InvoiceNumber = "inv-100",
            Title = "Event Planning Services",
            Description = "We appreciate your business!",
            ScheduledAt = "2030-01-13T10:00:00Z",
            AcceptedPaymentMethods = new InvoiceAcceptedPaymentMethods
            {
                Card = true,
                SquareGiftCard = false,
                BankAccount = false,
                BuyNowPayLater = false,
                CashAppPay = false,
            },
            CustomFields = new List<InvoiceCustomField>()
            {
                new InvoiceCustomField
                {
                    Label = "Event Reference Number",
                    Value = "Ref. #1234",
                    Placement = InvoiceCustomFieldPlacement.AboveLineItems,
                },
                new InvoiceCustomField
                {
                    Label = "Terms of Service",
                    Value = "The terms of service are...",
                    Placement = InvoiceCustomFieldPlacement.BelowLineItems,
                },
            },
            SaleOrServiceDate = "2030-01-24",
            StorePaymentMethodEnabled = false,
        },
        IdempotencyKey = "ce3748f9-5fc1-4762-aa12-aae5e843f1f4",
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

**request:** `CreateInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">SearchAsync</a>(SearchInvoicesRequest { ... }) -> SearchInvoicesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for invoices from a location specified in 
the filter. You can optionally specify customers in the filter for whom to 
retrieve invoices. In the current implementation, you can only specify one location and 
optionally one customer.

The response is paginated. If truncated, the response includes a `cursor` 
that you use in a subsequent request to retrieve the next set of invoices.
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
await client.Invoices.SearchAsync(
    new SearchInvoicesRequest
    {
        Query = new InvoiceQuery
        {
            Filter = new InvoiceFilter
            {
                LocationIds = new List<string>() { "ES0RJRZYEC39A" },
                CustomerIds = new List<string>() { "JDKYHBWT1D4F8MFH63DBMEN8Y4" },
            },
            Sort = new InvoiceSort { Field = "INVOICE_SORT_DATE", Order = SortOrder.Desc },
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

**request:** `SearchInvoicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">GetAsync</a>(GetInvoicesRequest { ... }) -> GetInvoiceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves an invoice by invoice ID.
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
await client.Invoices.GetAsync(new GetInvoicesRequest { InvoiceId = "invoice_id" });
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

**request:** `GetInvoicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">UpdateAsync</a>(UpdateInvoiceRequest { ... }) -> UpdateInvoiceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an invoice. This endpoint supports sparse updates, so you only need
to specify the fields you want to change along with the required `version` field.
Some restrictions apply to updating invoices. For example, you cannot change the
`order_id` or `location_id` field.
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
await client.Invoices.UpdateAsync(
    new UpdateInvoiceRequest
    {
        InvoiceId = "invoice_id",
        Invoice = new Invoice
        {
            Version = 1,
            PaymentRequests = new List<InvoicePaymentRequest>()
            {
                new InvoicePaymentRequest
                {
                    Uid = "2da7964f-f3d2-4f43-81e8-5aa220bf3355",
                    TippingEnabled = false,
                },
            },
        },
        IdempotencyKey = "4ee82288-0910-499e-ab4c-5d0071dad1be",
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

**request:** `UpdateInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">DeleteAsync</a>(DeleteInvoicesRequest { ... }) -> DeleteInvoiceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes the specified invoice. When an invoice is deleted, the 
associated order status changes to CANCELED. You can only delete a draft 
invoice (you cannot delete a published invoice, including one that is scheduled for processing).
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
await client.Invoices.DeleteAsync(new DeleteInvoicesRequest { InvoiceId = "invoice_id" });
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

**request:** `DeleteInvoicesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">DeleteInvoiceAttachmentAsync</a>(DeleteInvoiceAttachmentRequest { ... }) -> DeleteInvoiceAttachmentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes an attachment from an invoice and permanently deletes the file. Attachments can be removed only
from invoices in the `DRAFT`, `SCHEDULED`, `UNPAID`, or `PARTIALLY_PAID` state.
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
await client.Invoices.DeleteInvoiceAttachmentAsync(
    new DeleteInvoiceAttachmentRequest { InvoiceId = "invoice_id", AttachmentId = "attachment_id" }
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

**request:** `DeleteInvoiceAttachmentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">CancelAsync</a>(CancelInvoiceRequest { ... }) -> CancelInvoiceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels an invoice. The seller cannot collect payments for 
the canceled invoice.

You cannot cancel an invoice in the `DRAFT` state or in a terminal state: `PAID`, `REFUNDED`, `CANCELED`, or `FAILED`.
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
await client.Invoices.CancelAsync(
    new CancelInvoiceRequest { InvoiceId = "invoice_id", Version = 0 }
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

**request:** `CancelInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Invoices.<a href="/src/Square/Invoices/InvoicesClient.cs">PublishAsync</a>(PublishInvoiceRequest { ... }) -> PublishInvoiceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Publishes the specified draft invoice. 

After an invoice is published, Square 
follows up based on the invoice configuration. For example, Square 
sends the invoice to the customer's email address, charges the customer's card on file, or does 
nothing. Square also makes the invoice available on a Square-hosted invoice page. 

The invoice `status` also changes from `DRAFT` to a status 
based on the invoice configuration. For example, the status changes to `UNPAID` if 
Square emails the invoice or `PARTIALLY_PAID` if Square charges a card on file for a portion of the 
invoice amount.

In addition to the required `ORDERS_WRITE` and `INVOICES_WRITE` permissions, `CUSTOMERS_READ`
and `PAYMENTS_WRITE` are required when publishing invoices configured for card-on-file payments.
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
await client.Invoices.PublishAsync(
    new PublishInvoiceRequest
    {
        InvoiceId = "invoice_id",
        Version = 1,
        IdempotencyKey = "32da42d0-1997-41b0-826b-f09464fc2c2e",
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

**request:** `PublishInvoiceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Labor
<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">CreateScheduledShiftAsync</a>(CreateScheduledShiftRequest { ... }) -> CreateScheduledShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a scheduled shift by providing draft shift details such as job ID,
team member assignment, and start and end times.

The following `draft_shift_details` fields are required:
- `location_id`
- `job_id`
- `start_at`
- `end_at`
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
await client.Labor.CreateScheduledShiftAsync(
    new CreateScheduledShiftRequest
    {
        IdempotencyKey = "HIDSNG5KS478L",
        ScheduledShift = new ScheduledShift
        {
            DraftShiftDetails = new ScheduledShiftDetails
            {
                TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
                LocationId = "PAA1RJZZKXBFG",
                JobId = "FzbJAtt9qEWncK1BWgVCxQ6M",
                StartAt = "2019-01-25T03:11:00-05:00",
                EndAt = "2019-01-25T13:11:00-05:00",
                Notes = "Dont forget to prep the vegetables",
                IsDeleted = false,
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

**request:** `CreateScheduledShiftRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">BulkPublishScheduledShiftsAsync</a>(BulkPublishScheduledShiftsRequest { ... }) -> BulkPublishScheduledShiftsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Publishes 1 - 100 scheduled shifts. This endpoint takes a map of individual publish
requests and returns a map of responses. When a scheduled shift is published, Square keeps
the `draft_shift_details` field as is and copies it to the `published_shift_details` field.

The minimum `start_at` and maximum `end_at` timestamps of all shifts in a
`BulkPublishScheduledShifts` request must fall within a two-week period.
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
await client.Labor.BulkPublishScheduledShiftsAsync(
    new BulkPublishScheduledShiftsRequest
    {
        ScheduledShifts = new Dictionary<string, BulkPublishScheduledShiftsData>()
        {
            { "key", new BulkPublishScheduledShiftsData() },
        },
        ScheduledShiftNotificationAudience = ScheduledShiftNotificationAudience.Affected,
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

**request:** `BulkPublishScheduledShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">SearchScheduledShiftsAsync</a>(SearchScheduledShiftsRequest { ... }) -> SearchScheduledShiftsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of scheduled shifts, with optional filter and sort settings.
By default, results are sorted by `start_at` in ascending order.
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
await client.Labor.SearchScheduledShiftsAsync(
    new SearchScheduledShiftsRequest
    {
        Query = new ScheduledShiftQuery
        {
            Filter = new ScheduledShiftFilter
            {
                AssignmentStatus = ScheduledShiftFilterAssignmentStatus.Assigned,
            },
            Sort = new ScheduledShiftSort
            {
                Field = ScheduledShiftSortField.CreatedAt,
                Order = SortOrder.Asc,
            },
        },
        Limit = 2,
        Cursor = "xoxp-1234-5678-90123",
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

**request:** `SearchScheduledShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">RetrieveScheduledShiftAsync</a>(RetrieveScheduledShiftRequest { ... }) -> RetrieveScheduledShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a scheduled shift by ID.
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
await client.Labor.RetrieveScheduledShiftAsync(new RetrieveScheduledShiftRequest { Id = "id" });
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

**request:** `RetrieveScheduledShiftRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">UpdateScheduledShiftAsync</a>(UpdateScheduledShiftRequest { ... }) -> UpdateScheduledShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the draft shift details for a scheduled shift. This endpoint supports
sparse updates, so only new, changed, or removed fields are required in the request.
You must publish the shift to make updates public.

You can make the following updates to `draft_shift_details`:
- Change the `location_id`, `job_id`, `start_at`, and `end_at` fields.
- Add, change, or clear the `team_member_id` and `notes` fields. To clear these fields,
set the value to null.
- Change the `is_deleted` field. To delete a scheduled shift, set `is_deleted` to true
and then publish the shift.
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
await client.Labor.UpdateScheduledShiftAsync(
    new UpdateScheduledShiftRequest
    {
        Id = "id",
        ScheduledShift = new ScheduledShift
        {
            DraftShiftDetails = new ScheduledShiftDetails
            {
                TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
                LocationId = "PAA1RJZZKXBFG",
                JobId = "FzbJAtt9qEWncK1BWgVCxQ6M",
                StartAt = "2019-03-25T03:11:00-05:00",
                EndAt = "2019-03-25T13:18:00-05:00",
                Notes = "Dont forget to prep the vegetables",
                IsDeleted = false,
            },
            Version = 1,
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

**request:** `UpdateScheduledShiftRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">PublishScheduledShiftAsync</a>(PublishScheduledShiftRequest { ... }) -> PublishScheduledShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Publishes a scheduled shift. When a scheduled shift is published, Square keeps the
`draft_shift_details` field as is and copies it to the `published_shift_details` field.
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
await client.Labor.PublishScheduledShiftAsync(
    new PublishScheduledShiftRequest
    {
        Id = "id",
        IdempotencyKey = "HIDSNG5KS478L",
        Version = 2,
        ScheduledShiftNotificationAudience = ScheduledShiftNotificationAudience.All,
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

**request:** `PublishScheduledShiftRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">CreateTimecardAsync</a>(CreateTimecardRequest { ... }) -> CreateTimecardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new `Timecard`.

A `Timecard` represents a complete workday for a single team member.
You must provide the following values in your request to this
endpoint:

- `location_id`
- `team_member_id`
- `start_at`

An attempt to create a new `Timecard` can result in a `BAD_REQUEST` error when:
- The `status` of the new `Timecard` is `OPEN` and the team member has another
timecard with an `OPEN` status.
- The `start_at` date is in the future.
- The `start_at` or `end_at` date overlaps another timecard for the same team member.
- The `Break` instances are set in the request and a break `start_at`
is before the `Timecard.start_at`, a break `end_at` is after
the `Timecard.end_at`, or both.
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
await client.Labor.CreateTimecardAsync(
    new CreateTimecardRequest
    {
        IdempotencyKey = "HIDSNG5KS478L",
        Timecard = new Timecard
        {
            LocationId = "PAA1RJZZKXBFG",
            StartAt = "2019-01-25T03:11:00-05:00",
            EndAt = "2019-01-25T13:11:00-05:00",
            Wage = new TimecardWage
            {
                Title = "Barista",
                HourlyRate = new Money { Amount = 1100, Currency = Currency.Usd },
                TipEligible = true,
            },
            Breaks = new List<Break>()
            {
                new Break
                {
                    StartAt = "2019-01-25T06:11:00-05:00",
                    EndAt = "2019-01-25T06:16:00-05:00",
                    BreakTypeId = "REGS1EQR1TPZ5",
                    Name = "Tea Break",
                    ExpectedDuration = "PT5M",
                    IsPaid = true,
                },
            },
            TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
            DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
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

**request:** `CreateTimecardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">SearchTimecardsAsync</a>(SearchTimecardsRequest { ... }) -> SearchTimecardsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of `Timecard` records for a business.
The list to be returned can be filtered by:
- Location IDs
- Team member IDs
- Timecard status (`OPEN` or `CLOSED`)
- Timecard start
- Timecard end
- Workday details

The list can be sorted by:
- `START_AT`
- `END_AT`
- `CREATED_AT`
- `UPDATED_AT`
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
await client.Labor.SearchTimecardsAsync(
    new SearchTimecardsRequest
    {
        Query = new TimecardQuery
        {
            Filter = new TimecardFilter
            {
                Workday = new TimecardWorkday
                {
                    DateRange = new DateRange { StartDate = "2019-01-20", EndDate = "2019-02-03" },
                    MatchTimecardsBy = TimecardWorkdayMatcher.StartAt,
                    DefaultTimezone = "America/Los_Angeles",
                },
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

**request:** `SearchTimecardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">RetrieveTimecardAsync</a>(RetrieveTimecardRequest { ... }) -> RetrieveTimecardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a single `Timecard` specified by `id`.
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
await client.Labor.RetrieveTimecardAsync(new RetrieveTimecardRequest { Id = "id" });
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

**request:** `RetrieveTimecardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">UpdateTimecardAsync</a>(UpdateTimecardRequest { ... }) -> UpdateTimecardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an existing `Timecard`.

When adding a `Break` to a `Timecard`, any earlier `Break` instances in the `Timecard` have
the `end_at` property set to a valid RFC-3339 datetime string.

When closing a `Timecard`, all `Break` instances in the `Timecard` must be complete with `end_at`
set on each `Break`.
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
await client.Labor.UpdateTimecardAsync(
    new UpdateTimecardRequest
    {
        Id = "id",
        Timecard = new Timecard
        {
            LocationId = "PAA1RJZZKXBFG",
            StartAt = "2019-01-25T03:11:00-05:00",
            EndAt = "2019-01-25T13:11:00-05:00",
            Wage = new TimecardWage
            {
                Title = "Bartender",
                HourlyRate = new Money { Amount = 1500, Currency = Currency.Usd },
                TipEligible = true,
            },
            Breaks = new List<Break>()
            {
                new Break
                {
                    Id = "X7GAQYVVRRG6P",
                    StartAt = "2019-01-25T06:11:00-05:00",
                    EndAt = "2019-01-25T06:16:00-05:00",
                    BreakTypeId = "REGS1EQR1TPZ5",
                    Name = "Tea Break",
                    ExpectedDuration = "PT5M",
                    IsPaid = true,
                },
            },
            Status = TimecardStatus.Closed,
            Version = 1,
            TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
            DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
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

**request:** `UpdateTimecardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.<a href="/src/Square/Labor/LaborClient.cs">DeleteTimecardAsync</a>(DeleteTimecardRequest { ... }) -> DeleteTimecardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a `Timecard`.
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
await client.Labor.DeleteTimecardAsync(new DeleteTimecardRequest { Id = "id" });
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

**request:** `DeleteTimecardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Locations
<details><summary><code>client.Locations.<a href="/src/Square/Locations/LocationsClient.cs">ListAsync</a>() -> ListLocationsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),
including those with an inactive status. Locations are listed alphabetically by `name`.
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
await client.Locations.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Square/Locations/LocationsClient.cs">CreateAsync</a>(CreateLocationRequest { ... }) -> CreateLocationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a [location](https://developer.squareup.com/docs/locations-api).
Creating new locations allows for separate configuration of receipt layouts, item prices,
and sales reports. Developers can use locations to separate sales activity through applications
that integrate with Square from sales activity elsewhere in a seller's account.
Locations created programmatically with the Locations API last forever and
are visible to the seller for their own management. Therefore, ensure that
each location has a sensible and unique name.
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
await client.Locations.CreateAsync(
    new CreateLocationRequest
    {
        Location = new Location
        {
            Name = "Midtown",
            Address = new Address
            {
                AddressLine1 = "1234 Peachtree St. NE",
                Locality = "Atlanta",
                AdministrativeDistrictLevel1 = "GA",
                PostalCode = "30309",
            },
            Description = "Midtown Atlanta store",
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

**request:** `CreateLocationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Square/Locations/LocationsClient.cs">GetAsync</a>(GetLocationsRequest { ... }) -> GetLocationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details of a single location. Specify "main"
as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
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
await client.Locations.GetAsync(new GetLocationsRequest { LocationId = "location_id" });
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

**request:** `GetLocationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Square/Locations/LocationsClient.cs">UpdateAsync</a>(UpdateLocationRequest { ... }) -> UpdateLocationResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a [location](https://developer.squareup.com/docs/locations-api).
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
await client.Locations.UpdateAsync(
    new UpdateLocationRequest
    {
        LocationId = "location_id",
        Location = new Location
        {
            BusinessHours = new BusinessHours
            {
                Periods = new List<BusinessHoursPeriod>()
                {
                    new BusinessHoursPeriod
                    {
                        DayOfWeek = DayOfWeek.Fri,
                        StartLocalTime = "07:00",
                        EndLocalTime = "18:00",
                    },
                    new BusinessHoursPeriod
                    {
                        DayOfWeek = DayOfWeek.Sat,
                        StartLocalTime = "07:00",
                        EndLocalTime = "18:00",
                    },
                    new BusinessHoursPeriod
                    {
                        DayOfWeek = DayOfWeek.Sun,
                        StartLocalTime = "09:00",
                        EndLocalTime = "15:00",
                    },
                },
            },
            Description = "Midtown Atlanta store - Open weekends",
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

**request:** `UpdateLocationRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.<a href="/src/Square/Locations/LocationsClient.cs">CheckoutsAsync</a>(CreateCheckoutRequest { ... }) -> CreateCheckoutResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Links a `checkoutId` to a `checkout_page_url` that customers are
directed to in order to provide their payment information using a
payment processing workflow hosted on connect.squareup.com. 


NOTE: The Checkout API has been updated with new features. 
For more information, see [Checkout API highlights](https://developer.squareup.com/docs/checkout-api#checkout-api-highlights).
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
await client.Locations.CheckoutsAsync(
    new CreateCheckoutRequest
    {
        LocationId = "location_id",
        IdempotencyKey = "86ae1696-b1e3-4328-af6d-f1e04d947ad6",
        Order = new CreateOrderRequest
        {
            Order = new Order
            {
                LocationId = "location_id",
                ReferenceId = "reference_id",
                CustomerId = "customer_id",
                LineItems = new List<OrderLineItem>()
                {
                    new OrderLineItem
                    {
                        Name = "Printed T Shirt",
                        Quantity = "2",
                        AppliedTaxes = new List<OrderLineItemAppliedTax>()
                        {
                            new OrderLineItemAppliedTax
                            {
                                TaxUid = "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
                            },
                        },
                        AppliedDiscounts = new List<OrderLineItemAppliedDiscount>()
                        {
                            new OrderLineItemAppliedDiscount
                            {
                                DiscountUid = "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
                            },
                        },
                        BasePriceMoney = new Money { Amount = 1500, Currency = Currency.Usd },
                    },
                    new OrderLineItem
                    {
                        Name = "Slim Jeans",
                        Quantity = "1",
                        BasePriceMoney = new Money { Amount = 2500, Currency = Currency.Usd },
                    },
                    new OrderLineItem
                    {
                        Name = "Woven Sweater",
                        Quantity = "3",
                        BasePriceMoney = new Money { Amount = 3500, Currency = Currency.Usd },
                    },
                },
                Taxes = new List<OrderLineItemTax>()
                {
                    new OrderLineItemTax
                    {
                        Uid = "38ze1696-z1e3-5628-af6d-f1e04d947fg3",
                        Type = OrderLineItemTaxType.Inclusive,
                        Percentage = "7.75",
                        Scope = OrderLineItemTaxScope.LineItem,
                    },
                },
                Discounts = new List<OrderLineItemDiscount>()
                {
                    new OrderLineItemDiscount
                    {
                        Uid = "56ae1696-z1e3-9328-af6d-f1e04d947gd4",
                        Type = OrderLineItemDiscountType.FixedAmount,
                        AmountMoney = new Money { Amount = 100, Currency = Currency.Usd },
                        Scope = OrderLineItemDiscountScope.LineItem,
                    },
                },
            },
            IdempotencyKey = "12ae1696-z1e3-4328-af6d-f1e04d947gd4",
        },
        AskForShippingAddress = true,
        MerchantSupportEmail = "merchant+support@website.com",
        PrePopulateBuyerEmail = "example@email.com",
        PrePopulateShippingAddress = new Address
        {
            AddressLine1 = "1455 Market St.",
            AddressLine2 = "Suite 600",
            Locality = "San Francisco",
            AdministrativeDistrictLevel1 = "CA",
            PostalCode = "94103",
            Country = Country.Us,
            FirstName = "Jane",
            LastName = "Doe",
        },
        RedirectUrl = "https://merchant.website.com/order-confirm",
        AdditionalRecipients = new List<ChargeRequestAdditionalRecipient>()
        {
            new ChargeRequestAdditionalRecipient
            {
                LocationId = "057P5VYJ4A5X1",
                Description = "Application fees",
                AmountMoney = new Money { Amount = 60, Currency = Currency.Usd },
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

**request:** `CreateCheckoutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Loyalty
<details><summary><code>client.Loyalty.<a href="/src/Square/Loyalty/LoyaltyClient.cs">SearchEventsAsync</a>(SearchLoyaltyEventsRequest { ... }) -> SearchLoyaltyEventsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for loyalty events.

A Square loyalty program maintains a ledger of events that occur during the lifetime of a
buyer's loyalty account. Each change in the point balance
(for example, points earned, points redeemed, and points expired) is
recorded in the ledger. Using this endpoint, you can search the ledger for events.

Search results are sorted by `created_at` in descending order.
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
await client.Loyalty.SearchEventsAsync(
    new SearchLoyaltyEventsRequest
    {
        Query = new LoyaltyEventQuery
        {
            Filter = new LoyaltyEventFilter
            {
                OrderFilter = new LoyaltyEventOrderFilter
                {
                    OrderId = "PyATxhYLfsMqpVkcKJITPydgEYfZY",
                },
            },
        },
        Limit = 30,
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

**request:** `SearchLoyaltyEventsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Merchants
<details><summary><code>client.Merchants.<a href="/src/Square/Merchants/MerchantsClient.cs">ListAsync</a>(ListMerchantsRequest { ... }) -> Pager<Merchant></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides details about the merchant associated with a given access token.

The access token used to connect your application to a Square seller is associated
with a single merchant. That means that `ListMerchants` returns a list
with a single `Merchant` object. You can specify your personal access token
to get your own merchant information or specify an OAuth token to get the
information for the merchant that granted your application access.

If you know the merchant ID, you can also use the [RetrieveMerchant](api-endpoint:Merchants-RetrieveMerchant)
endpoint to retrieve the merchant information.
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
await client.Merchants.ListAsync(new ListMerchantsRequest());
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

**request:** `ListMerchantsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.<a href="/src/Square/Merchants/MerchantsClient.cs">GetAsync</a>(GetMerchantsRequest { ... }) -> GetMerchantResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the `Merchant` object for the given `merchant_id`.
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
await client.Merchants.GetAsync(new GetMerchantsRequest { MerchantId = "merchant_id" });
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

**request:** `GetMerchantsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Checkout
<details><summary><code>client.Checkout.<a href="/src/Square/Checkout/CheckoutClient.cs">RetrieveLocationSettingsAsync</a>(RetrieveLocationSettingsRequest { ... }) -> RetrieveLocationSettingsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the location-level settings for a Square-hosted checkout page.
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
await client.Checkout.RetrieveLocationSettingsAsync(
    new RetrieveLocationSettingsRequest { LocationId = "location_id" }
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

**request:** `RetrieveLocationSettingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Checkout.<a href="/src/Square/Checkout/CheckoutClient.cs">UpdateLocationSettingsAsync</a>(UpdateLocationSettingsRequest { ... }) -> UpdateLocationSettingsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the location-level settings for a Square-hosted checkout page.
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
await client.Checkout.UpdateLocationSettingsAsync(
    new UpdateLocationSettingsRequest
    {
        LocationId = "location_id",
        LocationSettings = new CheckoutLocationSettings(),
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

**request:** `UpdateLocationSettingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Checkout.<a href="/src/Square/Checkout/CheckoutClient.cs">RetrieveMerchantSettingsAsync</a>() -> RetrieveMerchantSettingsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the merchant-level settings for a Square-hosted checkout page.
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
await client.Checkout.RetrieveMerchantSettingsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Checkout.<a href="/src/Square/Checkout/CheckoutClient.cs">UpdateMerchantSettingsAsync</a>(UpdateMerchantSettingsRequest { ... }) -> UpdateMerchantSettingsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the merchant-level settings for a Square-hosted checkout page.
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
await client.Checkout.UpdateMerchantSettingsAsync(
    new UpdateMerchantSettingsRequest { MerchantSettings = new CheckoutMerchantSettings() }
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

**request:** `UpdateMerchantSettingsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Orders
<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">CreateAsync</a>(CreateOrderRequest { ... }) -> CreateOrderResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new [order](entity:Order) that can include information about products for
purchase and settings to apply to the purchase.

To pay for a created order, see
[Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).

You can modify open orders using the [UpdateOrder](api-endpoint:Orders-UpdateOrder) endpoint.
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
await client.Orders.CreateAsync(
    new CreateOrderRequest
    {
        Order = new Order
        {
            LocationId = "057P5VYJ4A5X1",
            ReferenceId = "my-order-001",
            LineItems = new List<OrderLineItem>()
            {
                new OrderLineItem
                {
                    Name = "New York Strip Steak",
                    Quantity = "1",
                    BasePriceMoney = new Money { Amount = 1599, Currency = Currency.Usd },
                },
                new OrderLineItem
                {
                    Quantity = "2",
                    CatalogObjectId = "BEMYCSMIJL46OCDV4KYIKXIB",
                    Modifiers = new List<OrderLineItemModifier>()
                    {
                        new OrderLineItemModifier { CatalogObjectId = "CHQX7Y4KY6N5KINJKZCFURPZ" },
                    },
                    AppliedDiscounts = new List<OrderLineItemAppliedDiscount>()
                    {
                        new OrderLineItemAppliedDiscount { DiscountUid = "one-dollar-off" },
                    },
                },
            },
            Taxes = new List<OrderLineItemTax>()
            {
                new OrderLineItemTax
                {
                    Uid = "state-sales-tax",
                    Name = "State Sales Tax",
                    Percentage = "9",
                    Scope = OrderLineItemTaxScope.Order,
                },
            },
            Discounts = new List<OrderLineItemDiscount>()
            {
                new OrderLineItemDiscount
                {
                    Uid = "labor-day-sale",
                    Name = "Labor Day Sale",
                    Percentage = "5",
                    Scope = OrderLineItemDiscountScope.Order,
                },
                new OrderLineItemDiscount
                {
                    Uid = "membership-discount",
                    CatalogObjectId = "DB7L55ZH2BGWI4H23ULIWOQ7",
                    Scope = OrderLineItemDiscountScope.Order,
                },
                new OrderLineItemDiscount
                {
                    Uid = "one-dollar-off",
                    Name = "Sale - $1.00 off",
                    AmountMoney = new Money { Amount = 100, Currency = Currency.Usd },
                    Scope = OrderLineItemDiscountScope.LineItem,
                },
            },
        },
        IdempotencyKey = "8193148c-9586-11e6-99f9-28cfe92138cf",
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

**request:** `CreateOrderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">BatchGetAsync</a>(BatchGetOrdersRequest { ... }) -> BatchGetOrdersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a set of [orders](entity:Order) by their IDs.

If a given order ID does not exist, the ID is ignored instead of generating an error.
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
await client.Orders.BatchGetAsync(
    new BatchGetOrdersRequest
    {
        LocationId = "057P5VYJ4A5X1",
        OrderIds = new List<string>()
        {
            "CAISEM82RcpmcFBM0TfOyiHV3es",
            "CAISENgvlJ6jLWAzERDzjyHVybY",
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

**request:** `BatchGetOrdersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">CalculateAsync</a>(CalculateOrderRequest { ... }) -> CalculateOrderResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Enables applications to preview order pricing without creating an order.
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
await client.Orders.CalculateAsync(
    new CalculateOrderRequest
    {
        Order = new Order
        {
            LocationId = "D7AVYMEAPJ3A3",
            LineItems = new List<OrderLineItem>()
            {
                new OrderLineItem
                {
                    Name = "Item 1",
                    Quantity = "1",
                    BasePriceMoney = new Money { Amount = 500, Currency = Currency.Usd },
                },
                new OrderLineItem
                {
                    Name = "Item 2",
                    Quantity = "2",
                    BasePriceMoney = new Money { Amount = 300, Currency = Currency.Usd },
                },
            },
            Discounts = new List<OrderLineItemDiscount>()
            {
                new OrderLineItemDiscount
                {
                    Name = "50% Off",
                    Percentage = "50",
                    Scope = OrderLineItemDiscountScope.Order,
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

**request:** `CalculateOrderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">CloneAsync</a>(CloneOrderRequest { ... }) -> CloneOrderResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new order, in the `DRAFT` state, by duplicating an existing order. The newly created order has
only the core fields (such as line items, taxes, and discounts) copied from the original order.
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
await client.Orders.CloneAsync(
    new CloneOrderRequest
    {
        OrderId = "ZAISEM52YcpmcWAzERDOyiWS123",
        Version = 3,
        IdempotencyKey = "UNIQUE_STRING",
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

**request:** `CloneOrderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">SearchAsync</a>(SearchOrdersRequest { ... }) -> SearchOrdersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Search all orders for one or more locations. Orders include all sales,
returns, and exchanges regardless of how or when they entered the Square
ecosystem (such as Point of Sale, Invoices, and Connect APIs).

`SearchOrders` requests need to specify which locations to search and define a
[SearchOrdersQuery](entity:SearchOrdersQuery) object that controls
how to sort or filter the results. Your `SearchOrdersQuery` can:

  Set filter criteria.
  Set the sort order.
  Determine whether to return results as complete `Order` objects or as
[OrderEntry](entity:OrderEntry) objects.

Note that details for orders processed with Square Point of Sale while in
offline mode might not be transmitted to Square for up to 72 hours. Offline
orders have a `created_at` value that reflects the time the order was created,
not the time it was subsequently transmitted to Square.
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
await client.Orders.SearchAsync(
    new SearchOrdersRequest
    {
        LocationIds = new List<string>() { "057P5VYJ4A5X1", "18YC4JDH91E1H" },
        Query = new SearchOrdersQuery
        {
            Filter = new SearchOrdersFilter
            {
                StateFilter = new SearchOrdersStateFilter
                {
                    States = new List<OrderState>() { OrderState.Completed },
                },
                DateTimeFilter = new SearchOrdersDateTimeFilter
                {
                    ClosedAt = new TimeRange
                    {
                        StartAt = "2018-03-03T20:00:00+00:00",
                        EndAt = "2019-03-04T21:54:45+00:00",
                    },
                },
            },
            Sort = new SearchOrdersSort
            {
                SortField = SearchOrdersSortField.ClosedAt,
                SortOrder = SortOrder.Desc,
            },
        },
        Limit = 3,
        ReturnEntries = true,
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

**request:** `SearchOrdersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">GetAsync</a>(GetOrdersRequest { ... }) -> GetOrderResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves an [Order](entity:Order) by ID.
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
await client.Orders.GetAsync(new GetOrdersRequest { OrderId = "order_id" });
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

**request:** `GetOrdersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">UpdateAsync</a>(UpdateOrderRequest { ... }) -> UpdateOrderResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an open [order](entity:Order) by adding, replacing, or deleting
fields. Orders with a `COMPLETED` or `CANCELED` state cannot be updated.

An `UpdateOrder` request requires the following:

- The `order_id` in the endpoint path, identifying the order to update.
- The latest `version` of the order to update.
- The [sparse order](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#sparse-order-objects)
containing only the fields to update and the version to which the update is
being applied.
- If deleting fields, the [dot notation paths](https://developer.squareup.com/docs/orders-api/manage-orders/update-orders#identifying-fields-to-delete)
identifying the fields to clear.

To pay for an order, see
[Pay for Orders](https://developer.squareup.com/docs/orders-api/pay-for-orders).
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
await client.Orders.UpdateAsync(
    new UpdateOrderRequest
    {
        OrderId = "order_id",
        Order = new Order
        {
            LocationId = "location_id",
            LineItems = new List<OrderLineItem>()
            {
                new OrderLineItem
                {
                    Uid = "cookie_uid",
                    Name = "COOKIE",
                    Quantity = "2",
                    BasePriceMoney = new Money { Amount = 200, Currency = Currency.Usd },
                },
            },
            Version = 1,
        },
        FieldsToClear = new List<string>() { "discounts" },
        IdempotencyKey = "UNIQUE_STRING",
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

**request:** `UpdateOrderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.<a href="/src/Square/Orders/OrdersClient.cs">PayAsync</a>(PayOrderRequest { ... }) -> PayOrderResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Pay for an [order](entity:Order) using one or more approved [payments](entity:Payment)
or settle an order with a total of `0`.

The total of the `payment_ids` listed in the request must be equal to the order
total. Orders with a total amount of `0` can be marked as paid by specifying an empty
array of `payment_ids` in the request.

To be used with `PayOrder`, a payment must:

- Reference the order by specifying the `order_id` when [creating the payment](api-endpoint:Payments-CreatePayment).
Any approved payments that reference the same `order_id` not specified in the
`payment_ids` is canceled.
- Be approved with [delayed capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture).
Using a delayed capture payment with `PayOrder` completes the approved payment.
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
await client.Orders.PayAsync(
    new PayOrderRequest
    {
        OrderId = "order_id",
        IdempotencyKey = "c043a359-7ad9-4136-82a9-c3f1d66dcbff",
        PaymentIds = new List<string>()
        {
            "EnZdNAlWCmfh6Mt5FMNST1o7taB",
            "0LRiVlbXVwe8ozu4KbZxd12mvaB",
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

**request:** `PayOrderRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Payments
<details><summary><code>client.Payments.<a href="/src/Square/Payments/PaymentsClient.cs">ListAsync</a>(ListPaymentsRequest { ... }) -> Pager<Payment></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of payments taken by the account making the request.

Results are eventually consistent, and new payments or changes to payments might take several
seconds to appear.

The maximum results per page is 100.
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
await client.Payments.ListAsync(new ListPaymentsRequest());
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

**request:** `ListPaymentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payments.<a href="/src/Square/Payments/PaymentsClient.cs">CreateAsync</a>(CreatePaymentRequest { ... }) -> CreatePaymentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a payment using the provided source. You can use this endpoint 
to charge a card (credit/debit card or    
Square gift card) or record a payment that the seller received outside of Square 
(cash payment from a buyer or a payment that an external entity 
processed on behalf of the seller).

The endpoint creates a 
`Payment` object and returns it in the response.
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
await client.Payments.CreateAsync(
    new CreatePaymentRequest
    {
        SourceId = "ccof:GaJGNaZa8x4OgDJn4GB",
        IdempotencyKey = "7b0f3ec5-086a-4871-8f13-3c81b3875218",
        AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
        AppFeeMoney = new Money { Amount = 10, Currency = Currency.Usd },
        Autocomplete = true,
        CustomerId = "W92WH6P11H4Z77CTET0RNTGFW8",
        LocationId = "L88917AVBK2S5",
        ReferenceId = "123456",
        Note = "Brief description",
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

**request:** `CreatePaymentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payments.<a href="/src/Square/Payments/PaymentsClient.cs">CancelByIdempotencyKeyAsync</a>(CancelPaymentByIdempotencyKeyRequest { ... }) -> CancelPaymentByIdempotencyKeyResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels (voids) a payment identified by the idempotency key that is specified in the
request.

Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a
`CreatePayment` request, a network error occurs and you do not get a response). In this case, you can
direct Square to cancel the payment using this endpoint. In the request, you provide the same
idempotency key that you provided in your `CreatePayment` request that you want to cancel. After
canceling the payment, you can submit your `CreatePayment` request again.

Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint
returns successfully.
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
await client.Payments.CancelByIdempotencyKeyAsync(
    new CancelPaymentByIdempotencyKeyRequest
    {
        IdempotencyKey = "a7e36d40-d24b-11e8-b568-0800200c9a66",
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

**request:** `CancelPaymentByIdempotencyKeyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payments.<a href="/src/Square/Payments/PaymentsClient.cs">GetAsync</a>(GetPaymentsRequest { ... }) -> GetPaymentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details for a specific payment.
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
await client.Payments.GetAsync(new GetPaymentsRequest { PaymentId = "payment_id" });
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

**request:** `GetPaymentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payments.<a href="/src/Square/Payments/PaymentsClient.cs">UpdateAsync</a>(UpdatePaymentRequest { ... }) -> UpdatePaymentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a payment with the APPROVED status.
You can update the `amount_money` and `tip_money` using this endpoint.
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
await client.Payments.UpdateAsync(
    new UpdatePaymentRequest
    {
        PaymentId = "payment_id",
        Payment = new Payment
        {
            AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
            TipMoney = new Money { Amount = 100, Currency = Currency.Usd },
            VersionToken = "ODhwVQ35xwlzRuoZEwKXucfu7583sPTzK48c5zoGd0g6o",
        },
        IdempotencyKey = "956f8b13-e4ec-45d6-85e8-d1d95ef0c5de",
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

**request:** `UpdatePaymentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payments.<a href="/src/Square/Payments/PaymentsClient.cs">CancelAsync</a>(CancelPaymentsRequest { ... }) -> CancelPaymentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels (voids) a payment. You can use this endpoint to cancel a payment with 
the APPROVED `status`.
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
await client.Payments.CancelAsync(new CancelPaymentsRequest { PaymentId = "payment_id" });
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

**request:** `CancelPaymentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payments.<a href="/src/Square/Payments/PaymentsClient.cs">CompleteAsync</a>(CompletePaymentRequest { ... }) -> CompletePaymentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Completes (captures) a payment.
By default, payments are set to complete immediately after they are created.

You can use this endpoint to complete a payment with the APPROVED `status`.
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
await client.Payments.CompleteAsync(new CompletePaymentRequest { PaymentId = "payment_id" });
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

**request:** `CompletePaymentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Payouts
<details><summary><code>client.Payouts.<a href="/src/Square/Payouts/PayoutsClient.cs">ListAsync</a>(ListPayoutsRequest { ... }) -> Pager<Payout></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of all payouts for the default location.
You can filter payouts by location ID, status, time range, and order them in ascending or descending order.
To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
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
await client.Payouts.ListAsync(new ListPayoutsRequest());
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

**request:** `ListPayoutsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payouts.<a href="/src/Square/Payouts/PayoutsClient.cs">GetAsync</a>(GetPayoutsRequest { ... }) -> GetPayoutResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details of a specific payout identified by a payout ID.
To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
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
await client.Payouts.GetAsync(new GetPayoutsRequest { PayoutId = "payout_id" });
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

**request:** `GetPayoutsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Payouts.<a href="/src/Square/Payouts/PayoutsClient.cs">ListEntriesAsync</a>(ListEntriesPayoutsRequest { ... }) -> Pager<PayoutEntry></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of all payout entries for a specific payout.
To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
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
await client.Payouts.ListEntriesAsync(new ListEntriesPayoutsRequest { PayoutId = "payout_id" });
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

**request:** `ListEntriesPayoutsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Refunds
<details><summary><code>client.Refunds.<a href="/src/Square/Refunds/RefundsClient.cs">ListAsync</a>(ListRefundsRequest { ... }) -> Pager<PaymentRefund></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a list of refunds for the account making the request.

Results are eventually consistent, and new refunds or changes to refunds might take several
seconds to appear.

The maximum results per page is 100.
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
await client.Refunds.ListAsync(new ListRefundsRequest());
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

**request:** `ListRefundsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Refunds.<a href="/src/Square/Refunds/RefundsClient.cs">RefundPaymentAsync</a>(RefundPaymentRequest { ... }) -> RefundPaymentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Refunds a payment. You can refund the entire payment amount or a
portion of it. You can use this endpoint to refund a card payment or record a 
refund of a cash or external payment. For more information, see
[Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).
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
await client.Refunds.RefundPaymentAsync(
    new RefundPaymentRequest
    {
        IdempotencyKey = "9b7f2dcf-49da-4411-b23e-a2d6af21333a",
        AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
        AppFeeMoney = new Money { Amount = 10, Currency = Currency.Usd },
        PaymentId = "R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY",
        Reason = "Example",
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

**request:** `RefundPaymentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Refunds.<a href="/src/Square/Refunds/RefundsClient.cs">GetAsync</a>(GetRefundsRequest { ... }) -> GetPaymentRefundResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a specific refund using the `refund_id`.
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
await client.Refunds.GetAsync(new GetRefundsRequest { RefundId = "refund_id" });
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

**request:** `GetRefundsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Sites
<details><summary><code>client.Sites.<a href="/src/Square/Sites/SitesClient.cs">ListAsync</a>() -> ListSitesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the Square Online sites that belong to a seller. Sites are listed in descending order by the `created_at` date.


__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
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
await client.Sites.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Snippets
<details><summary><code>client.Snippets.<a href="/src/Square/Snippets/SnippetsClient.cs">GetAsync</a>(GetSnippetsRequest { ... }) -> GetSnippetResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.

You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.


__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
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
await client.Snippets.GetAsync(new GetSnippetsRequest { SiteId = "site_id" });
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

**request:** `GetSnippetsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Snippets.<a href="/src/Square/Snippets/SnippetsClient.cs">UpsertAsync</a>(UpsertSnippetRequest { ... }) -> UpsertSnippetResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds a snippet to a Square Online site or updates the existing snippet on the site. 
The snippet code is appended to the end of the `head` element on every page of the site, except checkout pages. A snippet application can add one snippet to a given site. 

You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.


__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
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
await client.Snippets.UpsertAsync(
    new UpsertSnippetRequest
    {
        SiteId = "site_id",
        Snippet = new Snippet { Content = "<script>var js = 1;</script>" },
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

**request:** `UpsertSnippetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Snippets.<a href="/src/Square/Snippets/SnippetsClient.cs">DeleteAsync</a>(DeleteSnippetsRequest { ... }) -> DeleteSnippetResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes your snippet from a Square Online site.

You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.


__Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
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
await client.Snippets.DeleteAsync(new DeleteSnippetsRequest { SiteId = "site_id" });
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

**request:** `DeleteSnippetsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Subscriptions
<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">CreateAsync</a>(CreateSubscriptionRequest { ... }) -> CreateSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Enrolls a customer in a subscription.

If you provide a card on file in the request, Square charges the card for
the subscription. Otherwise, Square sends an invoice to the customer's email
address. The subscription starts immediately, unless the request includes
the optional `start_date`. Each individual subscription is associated with a particular location.

For more information, see [Create a subscription](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions#create-a-subscription).
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
await client.Subscriptions.CreateAsync(
    new CreateSubscriptionRequest
    {
        IdempotencyKey = "8193148c-9586-11e6-99f9-28cfe92138cf",
        LocationId = "S8GWD5R9QB376",
        PlanVariationId = "6JHXF3B2CW3YKHDV4XEM674H",
        CustomerId = "CHFGVKYY8RSV93M5KCYTG4PN0G",
        StartDate = "2023-06-20",
        CardId = "ccof:qy5x8hHGYsgLrp4Q4GB",
        Timezone = "America/Los_Angeles",
        Source = new SubscriptionSource { Name = "My Application" },
        Phases = new List<Phase>()
        {
            new Phase { Ordinal = 0, OrderTemplateId = "U2NaowWxzXwpsZU697x7ZHOAnCNZY" },
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

**request:** `CreateSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">BulkSwapPlanAsync</a>(BulkSwapPlanRequest { ... }) -> BulkSwapPlanResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Schedules a plan variation change for all active subscriptions under a given plan
variation. For more information, see [Swap Subscription Plan Variations](https://developer.squareup.com/docs/subscriptions-api/swap-plan-variations).
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
await client.Subscriptions.BulkSwapPlanAsync(
    new BulkSwapPlanRequest
    {
        NewPlanVariationId = "FQ7CDXXWSLUJRPM3GFJSJGZ7",
        OldPlanVariationId = "6JHXF3B2CW3YKHDV4XEM674H",
        LocationId = "S8GWD5R9QB376",
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

**request:** `BulkSwapPlanRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">SearchAsync</a>(SearchSubscriptionsRequest { ... }) -> SearchSubscriptionsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for subscriptions.

Results are ordered chronologically by subscription creation date. If
the request specifies more than one location ID,
the endpoint orders the result
by location ID, and then by creation date within each location. If no locations are given
in the query, all locations are searched.

You can also optionally specify `customer_ids` to search by customer.
If left unset, all customers
associated with the specified locations are returned.
If the request specifies customer IDs, the endpoint orders results
first by location, within location by customer ID, and within
customer by subscription creation date.
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
await client.Subscriptions.SearchAsync(
    new SearchSubscriptionsRequest
    {
        Query = new SearchSubscriptionsQuery
        {
            Filter = new SearchSubscriptionsFilter
            {
                CustomerIds = new List<string>() { "CHFGVKYY8RSV93M5KCYTG4PN0G" },
                LocationIds = new List<string>() { "S8GWD5R9QB376" },
                SourceNames = new List<string>() { "My App" },
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

**request:** `SearchSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">GetAsync</a>(GetSubscriptionsRequest { ... }) -> GetSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a specific subscription.
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
await client.Subscriptions.GetAsync(
    new GetSubscriptionsRequest { SubscriptionId = "subscription_id" }
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

**request:** `GetSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">UpdateAsync</a>(UpdateSubscriptionRequest { ... }) -> UpdateSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a subscription by modifying or clearing `subscription` field values.
To clear a field, set its value to `null`.
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
await client.Subscriptions.UpdateAsync(
    new UpdateSubscriptionRequest
    {
        SubscriptionId = "subscription_id",
        Subscription = new Subscription { CardId = "{NEW CARD ID}" },
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

**request:** `UpdateSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">DeleteActionAsync</a>(DeleteActionSubscriptionsRequest { ... }) -> DeleteSubscriptionActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a scheduled action for a subscription.
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
await client.Subscriptions.DeleteActionAsync(
    new DeleteActionSubscriptionsRequest
    {
        SubscriptionId = "subscription_id",
        ActionId = "action_id",
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

**request:** `DeleteActionSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">ChangeBillingAnchorDateAsync</a>(ChangeBillingAnchorDateRequest { ... }) -> ChangeBillingAnchorDateResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes the [billing anchor date](https://developer.squareup.com/docs/subscriptions-api/subscription-billing#billing-dates)
for a subscription.
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
await client.Subscriptions.ChangeBillingAnchorDateAsync(
    new ChangeBillingAnchorDateRequest
    {
        SubscriptionId = "subscription_id",
        MonthlyBillingAnchorDate = 1,
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

**request:** `ChangeBillingAnchorDateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">CancelAsync</a>(CancelSubscriptionsRequest { ... }) -> CancelSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Schedules a `CANCEL` action to cancel an active subscription. This 
sets the `canceled_date` field to the end of the active billing period. After this date, 
the subscription status changes from ACTIVE to CANCELED.
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
await client.Subscriptions.CancelAsync(
    new CancelSubscriptionsRequest { SubscriptionId = "subscription_id" }
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

**request:** `CancelSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">ListEventsAsync</a>(ListEventsSubscriptionsRequest { ... }) -> Pager<SubscriptionEvent></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all [events](https://developer.squareup.com/docs/subscriptions-api/actions-events) for a specific subscription.
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
await client.Subscriptions.ListEventsAsync(
    new ListEventsSubscriptionsRequest { SubscriptionId = "subscription_id" }
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

**request:** `ListEventsSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">PauseAsync</a>(PauseSubscriptionRequest { ... }) -> PauseSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Schedules a `PAUSE` action to pause an active subscription.
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
await client.Subscriptions.PauseAsync(
    new PauseSubscriptionRequest { SubscriptionId = "subscription_id" }
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

**request:** `PauseSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">ResumeAsync</a>(ResumeSubscriptionRequest { ... }) -> ResumeSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Schedules a `RESUME` action to resume a paused or a deactivated subscription.
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
await client.Subscriptions.ResumeAsync(
    new ResumeSubscriptionRequest { SubscriptionId = "subscription_id" }
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

**request:** `ResumeSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Subscriptions.<a href="/src/Square/Subscriptions/SubscriptionsClient.cs">SwapPlanAsync</a>(SwapPlanRequest { ... }) -> SwapPlanResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Schedules a `SWAP_PLAN` action to swap a subscription plan variation in an existing subscription. 
For more information, see [Swap Subscription Plan Variations](https://developer.squareup.com/docs/subscriptions-api/swap-plan-variations).
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
await client.Subscriptions.SwapPlanAsync(
    new SwapPlanRequest
    {
        SubscriptionId = "subscription_id",
        NewPlanVariationId = "FQ7CDXXWSLUJRPM3GFJSJGZ7",
        Phases = new List<PhaseInput>()
        {
            new PhaseInput { Ordinal = 0, OrderTemplateId = "uhhnjH9osVv3shUADwaC0b3hNxQZY" },
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

**request:** `SwapPlanRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## TeamMembers
<details><summary><code>client.TeamMembers.<a href="/src/Square/TeamMembers/TeamMembersClient.cs">CreateAsync</a>(CreateTeamMemberRequest { ... }) -> CreateTeamMemberResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
You must provide the following values in your request to this endpoint:
- `given_name`
- `family_name`

Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#createteammember).
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
await client.TeamMembers.CreateAsync(
    new CreateTeamMemberRequest
    {
        IdempotencyKey = "idempotency-key-0",
        TeamMember = new TeamMember
        {
            ReferenceId = "reference_id_1",
            Status = TeamMemberStatus.Active,
            GivenName = "Joe",
            FamilyName = "Doe",
            EmailAddress = "joe_doe@gmail.com",
            PhoneNumber = "+14159283333",
            AssignedLocations = new TeamMemberAssignedLocations
            {
                AssignmentType = TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
                LocationIds = new List<string>() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
            },
            WageSetting = new Square.WageSetting
            {
                JobAssignments = new List<JobAssignment>()
                {
                    new JobAssignment
                    {
                        PayType = JobAssignmentPayType.Salary,
                        AnnualRate = new Money { Amount = 3000000, Currency = Currency.Usd },
                        WeeklyHours = 40,
                        JobId = "FjS8x95cqHiMenw4f1NAUH4P",
                    },
                    new JobAssignment
                    {
                        PayType = JobAssignmentPayType.Hourly,
                        HourlyRate = new Money { Amount = 2000, Currency = Currency.Usd },
                        JobId = "VDNpRv8da51NU8qZFC5zDWpF",
                    },
                },
                IsOvertimeExempt = true,
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

**request:** `CreateTeamMemberRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TeamMembers.<a href="/src/Square/TeamMembers/TeamMembersClient.cs">BatchCreateAsync</a>(BatchCreateTeamMembersRequest { ... }) -> BatchCreateTeamMembersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
This process is non-transactional and processes as much of the request as possible. If one of the creates in
the request cannot be successfully processed, the request is not marked as failed, but the body of the response
contains explicit error information for the failed create.

Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).
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
await client.TeamMembers.BatchCreateAsync(
    new BatchCreateTeamMembersRequest
    {
        TeamMembers = new Dictionary<string, CreateTeamMemberRequest>()
        {
            {
                "idempotency-key-1",
                new CreateTeamMemberRequest
                {
                    TeamMember = new TeamMember
                    {
                        ReferenceId = "reference_id_1",
                        GivenName = "Joe",
                        FamilyName = "Doe",
                        EmailAddress = "joe_doe@gmail.com",
                        PhoneNumber = "+14159283333",
                        AssignedLocations = new TeamMemberAssignedLocations
                        {
                            AssignmentType =
                                TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
                            LocationIds = new List<string>() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
                        },
                    },
                }
            },
            {
                "idempotency-key-2",
                new CreateTeamMemberRequest
                {
                    TeamMember = new TeamMember
                    {
                        ReferenceId = "reference_id_2",
                        GivenName = "Jane",
                        FamilyName = "Smith",
                        EmailAddress = "jane_smith@gmail.com",
                        PhoneNumber = "+14159223334",
                        AssignedLocations = new TeamMemberAssignedLocations
                        {
                            AssignmentType =
                                TeamMemberAssignedLocationsAssignmentType.AllCurrentAndFutureLocations,
                        },
                    },
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

**request:** `BatchCreateTeamMembersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TeamMembers.<a href="/src/Square/TeamMembers/TeamMembersClient.cs">BatchUpdateAsync</a>(BatchUpdateTeamMembersRequest { ... }) -> BatchUpdateTeamMembersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
This process is non-transactional and processes as much of the request as possible. If one of the updates in
the request cannot be successfully processed, the request is not marked as failed, but the body of the response
contains explicit error information for the failed update.
Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).
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
await client.TeamMembers.BatchUpdateAsync(
    new BatchUpdateTeamMembersRequest
    {
        TeamMembers = new Dictionary<string, UpdateTeamMemberRequest>()
        {
            {
                "AFMwA08kR-MIF-3Vs0OE",
                new UpdateTeamMemberRequest
                {
                    TeamMember = new TeamMember
                    {
                        ReferenceId = "reference_id_2",
                        IsOwner = false,
                        Status = TeamMemberStatus.Active,
                        GivenName = "Jane",
                        FamilyName = "Smith",
                        EmailAddress = "jane_smith@gmail.com",
                        PhoneNumber = "+14159223334",
                        AssignedLocations = new TeamMemberAssignedLocations
                        {
                            AssignmentType =
                                TeamMemberAssignedLocationsAssignmentType.AllCurrentAndFutureLocations,
                        },
                    },
                }
            },
            {
                "fpgteZNMaf0qOK-a4t6P",
                new UpdateTeamMemberRequest
                {
                    TeamMember = new TeamMember
                    {
                        ReferenceId = "reference_id_1",
                        IsOwner = false,
                        Status = TeamMemberStatus.Active,
                        GivenName = "Joe",
                        FamilyName = "Doe",
                        EmailAddress = "joe_doe@gmail.com",
                        PhoneNumber = "+14159283333",
                        AssignedLocations = new TeamMemberAssignedLocations
                        {
                            AssignmentType =
                                TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
                            LocationIds = new List<string>() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
                        },
                    },
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

**request:** `BatchUpdateTeamMembersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TeamMembers.<a href="/src/Square/TeamMembers/TeamMembersClient.cs">SearchAsync</a>(SearchTeamMembersRequest { ... }) -> SearchTeamMembersResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of `TeamMember` objects for a business. 
The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether
the team member is the Square account owner.
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
await client.TeamMembers.SearchAsync(
    new SearchTeamMembersRequest
    {
        Query = new SearchTeamMembersQuery
        {
            Filter = new SearchTeamMembersFilter
            {
                LocationIds = new List<string>() { "0G5P3VGACMMQZ" },
                Status = TeamMemberStatus.Active,
            },
        },
        Limit = 10,
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

**request:** `SearchTeamMembersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TeamMembers.<a href="/src/Square/TeamMembers/TeamMembersClient.cs">GetAsync</a>(GetTeamMembersRequest { ... }) -> GetTeamMemberResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a `TeamMember` object for the given `TeamMember.id`.
Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).
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
await client.TeamMembers.GetAsync(new GetTeamMembersRequest { TeamMemberId = "team_member_id" });
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

**request:** `GetTeamMembersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TeamMembers.<a href="/src/Square/TeamMembers/TeamMembersClient.cs">UpdateAsync</a>(UpdateTeamMembersRequest { ... }) -> UpdateTeamMemberResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).
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
await client.TeamMembers.UpdateAsync(
    new UpdateTeamMembersRequest
    {
        TeamMemberId = "team_member_id",
        Body = new UpdateTeamMemberRequest
        {
            TeamMember = new TeamMember
            {
                ReferenceId = "reference_id_1",
                Status = TeamMemberStatus.Active,
                GivenName = "Joe",
                FamilyName = "Doe",
                EmailAddress = "joe_doe@gmail.com",
                PhoneNumber = "+14159283333",
                AssignedLocations = new TeamMemberAssignedLocations
                {
                    AssignmentType = TeamMemberAssignedLocationsAssignmentType.ExplicitLocations,
                    LocationIds = new List<string>() { "YSGH2WBKG94QZ", "GA2Y9HSJ8KRYT" },
                },
                WageSetting = new Square.WageSetting
                {
                    JobAssignments = new List<JobAssignment>()
                    {
                        new JobAssignment
                        {
                            PayType = JobAssignmentPayType.Salary,
                            AnnualRate = new Money { Amount = 3000000, Currency = Currency.Usd },
                            WeeklyHours = 40,
                            JobId = "FjS8x95cqHiMenw4f1NAUH4P",
                        },
                        new JobAssignment
                        {
                            PayType = JobAssignmentPayType.Hourly,
                            HourlyRate = new Money { Amount = 1200, Currency = Currency.Usd },
                            JobId = "VDNpRv8da51NU8qZFC5zDWpF",
                        },
                    },
                    IsOvertimeExempt = true,
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

**request:** `UpdateTeamMembersRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Team
<details><summary><code>client.Team.<a href="/src/Square/Team/TeamClient.cs">ListJobsAsync</a>(ListJobsRequest { ... }) -> ListJobsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists jobs in a seller account. Results are sorted by title in ascending order.
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
await client.Team.ListJobsAsync(new ListJobsRequest());
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

**request:** `ListJobsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Square/Team/TeamClient.cs">CreateJobAsync</a>(CreateJobRequest { ... }) -> CreateJobResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a job in a seller account. A job defines a title and tip eligibility. Note that
compensation is defined in a [job assignment](entity:JobAssignment) in a team member's wage setting.
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
await client.Team.CreateJobAsync(
    new CreateJobRequest
    {
        Job = new Job { Title = "Cashier", IsTipEligible = true },
        IdempotencyKey = "idempotency-key-0",
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

**request:** `CreateJobRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Square/Team/TeamClient.cs">RetrieveJobAsync</a>(RetrieveJobRequest { ... }) -> RetrieveJobResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a specified job.
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
await client.Team.RetrieveJobAsync(new RetrieveJobRequest { JobId = "job_id" });
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

**request:** `RetrieveJobRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Team.<a href="/src/Square/Team/TeamClient.cs">UpdateJobAsync</a>(UpdateJobRequest { ... }) -> UpdateJobResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the title or tip eligibility of a job. Changes to the title propagate to all
`JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to
tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.
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
await client.Team.UpdateJobAsync(
    new UpdateJobRequest
    {
        JobId = "job_id",
        Job = new Job { Title = "Cashier 1", IsTipEligible = true },
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

**request:** `UpdateJobRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Terminal
<details><summary><code>client.Terminal.<a href="/src/Square/Terminal/TerminalClient.cs">DismissTerminalActionAsync</a>(DismissTerminalActionRequest { ... }) -> DismissTerminalActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Dismisses a Terminal action request if the status and type of the request permits it.

See [Link and Dismiss Actions](https://developer.squareup.com/docs/terminal-api/advanced-features/custom-workflows/link-and-dismiss-actions) for more details.
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
await client.Terminal.DismissTerminalActionAsync(
    new DismissTerminalActionRequest { ActionId = "action_id" }
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

**request:** `DismissTerminalActionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.<a href="/src/Square/Terminal/TerminalClient.cs">DismissTerminalCheckoutAsync</a>(DismissTerminalCheckoutRequest { ... }) -> DismissTerminalCheckoutResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Dismisses a Terminal checkout request if the status and type of the request permits it.
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
await client.Terminal.DismissTerminalCheckoutAsync(
    new DismissTerminalCheckoutRequest { CheckoutId = "checkout_id" }
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

**request:** `DismissTerminalCheckoutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.<a href="/src/Square/Terminal/TerminalClient.cs">DismissTerminalRefundAsync</a>(DismissTerminalRefundRequest { ... }) -> DismissTerminalRefundResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Dismisses a Terminal refund request if the status and type of the request permits it.
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
await client.Terminal.DismissTerminalRefundAsync(
    new DismissTerminalRefundRequest { TerminalRefundId = "terminal_refund_id" }
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

**request:** `DismissTerminalRefundRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Vendors
<details><summary><code>client.Vendors.<a href="/src/Square/Vendors/VendorsClient.cs">BatchCreateAsync</a>(BatchCreateVendorsRequest { ... }) -> BatchCreateVendorsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates one or more [Vendor](entity:Vendor) objects to represent suppliers to a seller.
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
await client.Vendors.BatchCreateAsync(
    new BatchCreateVendorsRequest
    {
        Vendors = new Dictionary<string, Vendor>()
        {
            {
                "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
                new Vendor
                {
                    Name = "Joe's Fresh Seafood",
                    Address = new Address
                    {
                        AddressLine1 = "505 Electric Ave",
                        AddressLine2 = "Suite 600",
                        Locality = "New York",
                        AdministrativeDistrictLevel1 = "NY",
                        PostalCode = "10003",
                        Country = Country.Us,
                    },
                    Contacts = new List<VendorContact>()
                    {
                        new VendorContact
                        {
                            Name = "Joe Burrow",
                            EmailAddress = "joe@joesfreshseafood.com",
                            PhoneNumber = "1-212-555-4250",
                            Ordinal = 1,
                        },
                    },
                    AccountNumber = "4025391",
                    Note = "a vendor",
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

**request:** `BatchCreateVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendors.<a href="/src/Square/Vendors/VendorsClient.cs">BatchGetAsync</a>(BatchGetVendorsRequest { ... }) -> BatchGetVendorsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves one or more vendors of specified [Vendor](entity:Vendor) IDs.
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
await client.Vendors.BatchGetAsync(
    new BatchGetVendorsRequest
    {
        VendorIds = new List<string>() { "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4" },
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

**request:** `BatchGetVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendors.<a href="/src/Square/Vendors/VendorsClient.cs">BatchUpdateAsync</a>(BatchUpdateVendorsRequest { ... }) -> BatchUpdateVendorsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates one or more of existing [Vendor](entity:Vendor) objects as suppliers to a seller.
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
await client.Vendors.BatchUpdateAsync(
    new BatchUpdateVendorsRequest
    {
        Vendors = new Dictionary<string, UpdateVendorRequest>()
        {
            {
                "FMCYHBWT1TPL8MFH52PBMEN92A",
                new UpdateVendorRequest { Vendor = new Vendor() }
            },
            {
                "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                new UpdateVendorRequest { Vendor = new Vendor() }
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

**request:** `BatchUpdateVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendors.<a href="/src/Square/Vendors/VendorsClient.cs">CreateAsync</a>(CreateVendorRequest { ... }) -> CreateVendorResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a single [Vendor](entity:Vendor) object to represent a supplier to a seller.
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
await client.Vendors.CreateAsync(
    new CreateVendorRequest
    {
        IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
        Vendor = new Vendor
        {
            Name = "Joe's Fresh Seafood",
            Address = new Address
            {
                AddressLine1 = "505 Electric Ave",
                AddressLine2 = "Suite 600",
                Locality = "New York",
                AdministrativeDistrictLevel1 = "NY",
                PostalCode = "10003",
                Country = Country.Us,
            },
            Contacts = new List<VendorContact>()
            {
                new VendorContact
                {
                    Name = "Joe Burrow",
                    EmailAddress = "joe@joesfreshseafood.com",
                    PhoneNumber = "1-212-555-4250",
                    Ordinal = 1,
                },
            },
            AccountNumber = "4025391",
            Note = "a vendor",
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

**request:** `CreateVendorRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendors.<a href="/src/Square/Vendors/VendorsClient.cs">SearchAsync</a>(SearchVendorsRequest { ... }) -> SearchVendorsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for vendors using a filter against supported [Vendor](entity:Vendor) properties and a supported sorter.
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
await client.Vendors.SearchAsync(new SearchVendorsRequest());
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

**request:** `SearchVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendors.<a href="/src/Square/Vendors/VendorsClient.cs">GetAsync</a>(GetVendorsRequest { ... }) -> GetVendorResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the vendor of a specified [Vendor](entity:Vendor) ID.
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
await client.Vendors.GetAsync(new GetVendorsRequest { VendorId = "vendor_id" });
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

**request:** `GetVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Vendors.<a href="/src/Square/Vendors/VendorsClient.cs">UpdateAsync</a>(UpdateVendorsRequest { ... }) -> UpdateVendorResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an existing [Vendor](entity:Vendor) object as a supplier to a seller.
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
await client.Vendors.UpdateAsync(
    new UpdateVendorsRequest
    {
        VendorId = "vendor_id",
        Body = new UpdateVendorRequest
        {
            IdempotencyKey = "8fc6a5b0-9fe8-4b46-b46b-2ef95793abbe",
            Vendor = new Vendor
            {
                Id = "INV_V_JDKYHBWT1D4F8MFH63DBMEN8Y4",
                Name = "Jack's Chicken Shack",
                Version = 1,
                Status = VendorStatus.Active,
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

**request:** `UpdateVendorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Bookings CustomAttributeDefinitions
<details><summary><code>client.Bookings.CustomAttributeDefinitions.<a href="/src/Square/Bookings/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">ListAsync</a>(ListCustomAttributeDefinitionsRequest { ... }) -> Pager<CustomAttributeDefinition></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get all bookings custom attribute definitions.

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
await client.Bookings.CustomAttributeDefinitions.ListAsync(
    new ListCustomAttributeDefinitionsRequest()
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

**request:** `ListCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributeDefinitions.<a href="/src/Square/Bookings/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">CreateAsync</a>(CreateBookingCustomAttributeDefinitionRequest { ... }) -> CreateBookingCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a bookings custom attribute definition.

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
await client.Bookings.CustomAttributeDefinitions.CreateAsync(
    new CreateBookingCustomAttributeDefinitionRequest
    {
        CustomAttributeDefinition = new CustomAttributeDefinition(),
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

**request:** `CreateBookingCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributeDefinitions.<a href="/src/Square/Bookings/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">GetAsync</a>(GetCustomAttributeDefinitionsRequest { ... }) -> RetrieveBookingCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a bookings custom attribute definition.

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
await client.Bookings.CustomAttributeDefinitions.GetAsync(
    new GetCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `GetCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributeDefinitions.<a href="/src/Square/Bookings/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">UpdateAsync</a>(UpdateBookingCustomAttributeDefinitionRequest { ... }) -> UpdateBookingCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a bookings custom attribute definition.

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
await client.Bookings.CustomAttributeDefinitions.UpdateAsync(
    new UpdateBookingCustomAttributeDefinitionRequest
    {
        Key = "key",
        CustomAttributeDefinition = new CustomAttributeDefinition(),
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

**request:** `UpdateBookingCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributeDefinitions.<a href="/src/Square/Bookings/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">DeleteAsync</a>(DeleteCustomAttributeDefinitionsRequest { ... }) -> DeleteBookingCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a bookings custom attribute definition.

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
await client.Bookings.CustomAttributeDefinitions.DeleteAsync(
    new DeleteCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `DeleteCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Bookings CustomAttributes
<details><summary><code>client.Bookings.CustomAttributes.<a href="/src/Square/Bookings/CustomAttributes/CustomAttributesClient.cs">BatchDeleteAsync</a>(BulkDeleteBookingCustomAttributesRequest { ... }) -> BulkDeleteBookingCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Bulk deletes bookings custom attributes.

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
await client.Bookings.CustomAttributes.BatchDeleteAsync(
    new BulkDeleteBookingCustomAttributesRequest
    {
        Values = new Dictionary<string, BookingCustomAttributeDeleteRequest>()
        {
            {
                "key",
                new BookingCustomAttributeDeleteRequest { BookingId = "booking_id", Key = "key" }
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

**request:** `BulkDeleteBookingCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributes.<a href="/src/Square/Bookings/CustomAttributes/CustomAttributesClient.cs">BatchUpsertAsync</a>(BulkUpsertBookingCustomAttributesRequest { ... }) -> BulkUpsertBookingCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Bulk upserts bookings custom attributes.

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
await client.Bookings.CustomAttributes.BatchUpsertAsync(
    new BulkUpsertBookingCustomAttributesRequest
    {
        Values = new Dictionary<string, BookingCustomAttributeUpsertRequest>()
        {
            {
                "key",
                new BookingCustomAttributeUpsertRequest
                {
                    BookingId = "booking_id",
                    CustomAttribute = new CustomAttribute(),
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

**request:** `BulkUpsertBookingCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributes.<a href="/src/Square/Bookings/CustomAttributes/CustomAttributesClient.cs">ListAsync</a>(ListCustomAttributesRequest { ... }) -> Pager<CustomAttribute></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists a booking's custom attributes.

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
await client.Bookings.CustomAttributes.ListAsync(
    new ListCustomAttributesRequest { BookingId = "booking_id" }
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

**request:** `ListCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributes.<a href="/src/Square/Bookings/CustomAttributes/CustomAttributesClient.cs">GetAsync</a>(GetCustomAttributesRequest { ... }) -> RetrieveBookingCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a bookings custom attribute.

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
await client.Bookings.CustomAttributes.GetAsync(
    new GetCustomAttributesRequest { BookingId = "booking_id", Key = "key" }
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

**request:** `GetCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributes.<a href="/src/Square/Bookings/CustomAttributes/CustomAttributesClient.cs">UpsertAsync</a>(UpsertBookingCustomAttributeRequest { ... }) -> UpsertBookingCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Upserts a bookings custom attribute.

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
await client.Bookings.CustomAttributes.UpsertAsync(
    new UpsertBookingCustomAttributeRequest
    {
        BookingId = "booking_id",
        Key = "key",
        CustomAttribute = new CustomAttribute(),
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

**request:** `UpsertBookingCustomAttributeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.CustomAttributes.<a href="/src/Square/Bookings/CustomAttributes/CustomAttributesClient.cs">DeleteAsync</a>(DeleteCustomAttributesRequest { ... }) -> DeleteBookingCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a bookings custom attribute.

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
await client.Bookings.CustomAttributes.DeleteAsync(
    new DeleteCustomAttributesRequest { BookingId = "booking_id", Key = "key" }
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

**request:** `DeleteCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Bookings LocationProfiles
<details><summary><code>client.Bookings.LocationProfiles.<a href="/src/Square/Bookings/LocationProfiles/LocationProfilesClient.cs">ListAsync</a>(ListLocationProfilesRequest { ... }) -> Pager<LocationBookingProfile></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists location booking profiles of a seller.
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
await client.Bookings.LocationProfiles.ListAsync(new ListLocationProfilesRequest());
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

**request:** `ListLocationProfilesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Bookings TeamMemberProfiles
<details><summary><code>client.Bookings.TeamMemberProfiles.<a href="/src/Square/Bookings/TeamMemberProfiles/TeamMemberProfilesClient.cs">ListAsync</a>(ListTeamMemberProfilesRequest { ... }) -> Pager<TeamMemberBookingProfile></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists booking profiles for team members.
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
await client.Bookings.TeamMemberProfiles.ListAsync(new ListTeamMemberProfilesRequest());
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

**request:** `ListTeamMemberProfilesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Bookings.TeamMemberProfiles.<a href="/src/Square/Bookings/TeamMemberProfiles/TeamMemberProfilesClient.cs">GetAsync</a>(GetTeamMemberProfilesRequest { ... }) -> GetTeamMemberBookingProfileResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a team member's booking profile.
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
await client.Bookings.TeamMemberProfiles.GetAsync(
    new GetTeamMemberProfilesRequest { TeamMemberId = "team_member_id" }
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

**request:** `GetTeamMemberProfilesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## CashDrawers Shifts
<details><summary><code>client.CashDrawers.Shifts.<a href="/src/Square/CashDrawers/Shifts/ShiftsClient.cs">ListAsync</a>(ListShiftsRequest { ... }) -> Pager<CashDrawerShiftSummary></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides the details for all of the cash drawer shifts for a location
in a date range.
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
await client.CashDrawers.Shifts.ListAsync(new ListShiftsRequest { LocationId = "location_id" });
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

**request:** `ListShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CashDrawers.Shifts.<a href="/src/Square/CashDrawers/Shifts/ShiftsClient.cs">GetAsync</a>(GetShiftsRequest { ... }) -> GetCashDrawerShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides the summary details for a single cash drawer shift. See
[ListCashDrawerShiftEvents](api-endpoint:CashDrawers-ListCashDrawerShiftEvents) for a list of cash drawer shift events.
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
await client.CashDrawers.Shifts.GetAsync(
    new GetShiftsRequest { ShiftId = "shift_id", LocationId = "location_id" }
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

**request:** `GetShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CashDrawers.Shifts.<a href="/src/Square/CashDrawers/Shifts/ShiftsClient.cs">ListEventsAsync</a>(ListEventsShiftsRequest { ... }) -> Pager<CashDrawerShiftEvent></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provides a paginated list of events for a single cash drawer shift.
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
await client.CashDrawers.Shifts.ListEventsAsync(
    new ListEventsShiftsRequest { ShiftId = "shift_id", LocationId = "location_id" }
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

**request:** `ListEventsShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Catalog Images
## Catalog Object
<details><summary><code>client.Catalog.Object.<a href="/src/Square/Catalog/Object/ObjectClient.cs">UpsertAsync</a>(UpsertCatalogObjectRequest { ... }) -> UpsertCatalogObjectResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new or updates the specified [CatalogObject](entity:CatalogObject).

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
await client.Catalog.Object.UpsertAsync(
    new UpsertCatalogObjectRequest
    {
        IdempotencyKey = "af3d1afc-7212-4300-b463-0bfc5314a5ae",
        Object = new CatalogObject(new CatalogObject.Item(new CatalogObjectItem { Id = "id" })),
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

**request:** `UpsertCatalogObjectRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.Object.<a href="/src/Square/Catalog/Object/ObjectClient.cs">GetAsync</a>(GetObjectRequest { ... }) -> GetCatalogObjectResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a single [CatalogItem](entity:CatalogItem) as a
[CatalogObject](entity:CatalogObject) based on the provided ID. The returned
object includes all of the relevant [CatalogItem](entity:CatalogItem)
information including: [CatalogItemVariation](entity:CatalogItemVariation)
children, references to its
[CatalogModifierList](entity:CatalogModifierList) objects, and the ids of
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
await client.Catalog.Object.GetAsync(new GetObjectRequest { ObjectId = "object_id" });
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

**request:** `GetObjectRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Catalog.Object.<a href="/src/Square/Catalog/Object/ObjectClient.cs">DeleteAsync</a>(DeleteObjectRequest { ... }) -> DeleteCatalogObjectResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a single [CatalogObject](entity:CatalogObject) based on the
provided ID and returns the set of successfully deleted IDs in the response.
Deletion is a cascading event such that all children of the targeted object
are also deleted. For example, deleting a [CatalogItem](entity:CatalogItem)
will also delete all of its
[CatalogItemVariation](entity:CatalogItemVariation) children.

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
await client.Catalog.Object.DeleteAsync(new DeleteObjectRequest { ObjectId = "object_id" });
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

**request:** `DeleteObjectRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Checkout PaymentLinks
<details><summary><code>client.Checkout.PaymentLinks.<a href="/src/Square/Checkout/PaymentLinks/PaymentLinksClient.cs">ListAsync</a>(ListPaymentLinksRequest { ... }) -> Pager<PaymentLink></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all payment links.
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
await client.Checkout.PaymentLinks.ListAsync(new ListPaymentLinksRequest());
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

**request:** `ListPaymentLinksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Checkout.PaymentLinks.<a href="/src/Square/Checkout/PaymentLinks/PaymentLinksClient.cs">CreateAsync</a>(CreatePaymentLinkRequest { ... }) -> CreatePaymentLinkResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.
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
await client.Checkout.PaymentLinks.CreateAsync(
    new CreatePaymentLinkRequest
    {
        IdempotencyKey = "cd9e25dc-d9f2-4430-aedb-61605070e95f",
        QuickPay = new QuickPay
        {
            Name = "Auto Detailing",
            PriceMoney = new Money { Amount = 10000, Currency = Currency.Usd },
            LocationId = "A9Y43N9ABXZBP",
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

**request:** `CreatePaymentLinkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Checkout.PaymentLinks.<a href="/src/Square/Checkout/PaymentLinks/PaymentLinksClient.cs">GetAsync</a>(GetPaymentLinksRequest { ... }) -> GetPaymentLinkResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a payment link.
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
await client.Checkout.PaymentLinks.GetAsync(new GetPaymentLinksRequest { Id = "id" });
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

**request:** `GetPaymentLinksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Checkout.PaymentLinks.<a href="/src/Square/Checkout/PaymentLinks/PaymentLinksClient.cs">UpdateAsync</a>(UpdatePaymentLinkRequest { ... }) -> UpdatePaymentLinkResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a payment link. You can update the `payment_link` fields such as
`description`, `checkout_options`, and  `pre_populated_data`.
You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.
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
await client.Checkout.PaymentLinks.UpdateAsync(
    new UpdatePaymentLinkRequest
    {
        Id = "id",
        PaymentLink = new PaymentLink
        {
            Version = 1,
            CheckoutOptions = new CheckoutOptions { AskForShippingAddress = true },
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

**request:** `UpdatePaymentLinkRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Checkout.PaymentLinks.<a href="/src/Square/Checkout/PaymentLinks/PaymentLinksClient.cs">DeleteAsync</a>(DeletePaymentLinksRequest { ... }) -> DeletePaymentLinkResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a payment link.
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
await client.Checkout.PaymentLinks.DeleteAsync(new DeletePaymentLinksRequest { Id = "id" });
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

**request:** `DeletePaymentLinksRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Customers CustomAttributeDefinitions
<details><summary><code>client.Customers.CustomAttributeDefinitions.<a href="/src/Square/Customers/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">ListAsync</a>(ListCustomAttributeDefinitionsRequest { ... }) -> Pager<CustomAttributeDefinition></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the customer-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.

When all response pages are retrieved, the results include all custom attribute definitions
that are visible to the requesting application, including those that are created by other
applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Customers.CustomAttributeDefinitions.ListAsync(
    new ListCustomAttributeDefinitionsRequest()
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

**request:** `ListCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributeDefinitions.<a href="/src/Square/Customers/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">CreateAsync</a>(CreateCustomerCustomAttributeDefinitionRequest { ... }) -> CreateCustomerCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a customer-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
Use this endpoint to define a custom attribute that can be associated with customer profiles.

A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
for a custom attribute. After the definition is created, you can call
[UpsertCustomerCustomAttribute](api-endpoint:CustomerCustomAttributes-UpsertCustomerCustomAttribute) or
[BulkUpsertCustomerCustomAttributes](api-endpoint:CustomerCustomAttributes-BulkUpsertCustomerCustomAttributes)
to set the custom attribute for customer profiles in the seller's Customer Directory.

Sellers can view all custom attributes in exported customer data, including those set to
`VISIBILITY_HIDDEN`.
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
await client.Customers.CustomAttributeDefinitions.CreateAsync(
    new CreateCustomerCustomAttributeDefinitionRequest
    {
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Key = "favoritemovie",
            Schema = new Dictionary<string, object>()
            {
                {
                    "ref",
                    "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
            },
            Name = "Favorite Movie",
            Description = "The favorite movie of the customer.",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityHidden,
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

**request:** `CreateCustomerCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributeDefinitions.<a href="/src/Square/Customers/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">GetAsync</a>(GetCustomAttributeDefinitionsRequest { ... }) -> GetCustomerCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a customer-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.

To retrieve a custom attribute definition created by another application, the `visibility`
setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Customers.CustomAttributeDefinitions.GetAsync(
    new GetCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `GetCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributeDefinitions.<a href="/src/Square/Customers/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">UpdateAsync</a>(UpdateCustomerCustomAttributeDefinitionRequest { ... }) -> UpdateCustomerCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a customer-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.

Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
`schema` for a `Selection` data type.

Only the definition owner can update a custom attribute definition. Note that sellers can view
all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
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
await client.Customers.CustomAttributeDefinitions.UpdateAsync(
    new UpdateCustomerCustomAttributeDefinitionRequest
    {
        Key = "key",
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Description = "Update the description as desired.",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
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

**request:** `UpdateCustomerCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributeDefinitions.<a href="/src/Square/Customers/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">DeleteAsync</a>(DeleteCustomAttributeDefinitionsRequest { ... }) -> DeleteCustomerCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a customer-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.

Deleting a custom attribute definition also deletes the corresponding custom attribute from
all customer profiles in the seller's Customer Directory.

Only the definition owner can delete a custom attribute definition.
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
await client.Customers.CustomAttributeDefinitions.DeleteAsync(
    new DeleteCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `DeleteCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributeDefinitions.<a href="/src/Square/Customers/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">BatchUpsertAsync</a>(BatchUpsertCustomerCustomAttributesRequest { ... }) -> BatchUpsertCustomerCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates [custom attributes](entity:CustomAttribute) for customer profiles as a bulk operation.

Use this endpoint to set the value of one or more custom attributes for one or more customer profiles.
A custom attribute is based on a custom attribute definition in a Square seller account, which is
created using the [CreateCustomerCustomAttributeDefinition](api-endpoint:CustomerCustomAttributes-CreateCustomerCustomAttributeDefinition) endpoint.

This `BulkUpsertCustomerCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
requests and returns a map of individual upsert responses. Each upsert request has a unique ID
and provides a customer ID and custom attribute. Each upsert response is returned with the ID
of the corresponding request.

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Customers.CustomAttributeDefinitions.BatchUpsertAsync(
    new BatchUpsertCustomerCustomAttributesRequest
    {
        Values = new Dictionary<
            string,
            BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
        >()
        {
            {
                "id1",
                new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                {
                    CustomerId = "N3NCVYY3WS27HF0HKANA3R9FP8",
                    CustomAttribute = new CustomAttribute { Key = "favoritemovie", Value = "Dune" },
                }
            },
            {
                "id2",
                new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                {
                    CustomerId = "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                    CustomAttribute = new CustomAttribute { Key = "ownsmovie", Value = false },
                }
            },
            {
                "id3",
                new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                {
                    CustomerId = "SY8EMWRNDN3TQDP2H4KS1QWMMM",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "favoritemovie",
                        Value = "Star Wars",
                    },
                }
            },
            {
                "id4",
                new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                {
                    CustomerId = "N3NCVYY3WS27HF0HKANA3R9FP8",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "square:a0f1505a-2aa1-490d-91a8-8d31ff181808",
                        Value = "10.5",
                    },
                }
            },
            {
                "id5",
                new BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
                {
                    CustomerId = "70548QG1HN43B05G0KCZ4MMC1G",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "sq0ids-0evKIskIGaY45fCyNL66aw:backupemail",
                        Value = "fake-email@squareup.com",
                    },
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

**request:** `BatchUpsertCustomerCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Customers Groups
<details><summary><code>client.Customers.Groups.<a href="/src/Square/Customers/Groups/GroupsClient.cs">ListAsync</a>(ListGroupsRequest { ... }) -> Pager<CustomerGroup></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the list of customer groups of a business.
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
await client.Customers.Groups.ListAsync(new ListGroupsRequest());
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

**request:** `ListGroupsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Groups.<a href="/src/Square/Customers/Groups/GroupsClient.cs">CreateAsync</a>(CreateCustomerGroupRequest { ... }) -> CreateCustomerGroupResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new customer group for a business.

The request must include the `name` value of the group.
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
await client.Customers.Groups.CreateAsync(
    new CreateCustomerGroupRequest { Group = new CustomerGroup { Name = "Loyal Customers" } }
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

**request:** `CreateCustomerGroupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Groups.<a href="/src/Square/Customers/Groups/GroupsClient.cs">GetAsync</a>(GetGroupsRequest { ... }) -> GetCustomerGroupResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a specific customer group as identified by the `group_id` value.
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
await client.Customers.Groups.GetAsync(new GetGroupsRequest { GroupId = "group_id" });
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

**request:** `GetGroupsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Groups.<a href="/src/Square/Customers/Groups/GroupsClient.cs">UpdateAsync</a>(UpdateCustomerGroupRequest { ... }) -> UpdateCustomerGroupResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a customer group as identified by the `group_id` value.
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
await client.Customers.Groups.UpdateAsync(
    new UpdateCustomerGroupRequest
    {
        GroupId = "group_id",
        Group = new CustomerGroup { Name = "Loyal Customers" },
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

**request:** `UpdateCustomerGroupRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Groups.<a href="/src/Square/Customers/Groups/GroupsClient.cs">DeleteAsync</a>(DeleteGroupsRequest { ... }) -> DeleteCustomerGroupResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a customer group as identified by the `group_id` value.
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
await client.Customers.Groups.DeleteAsync(new DeleteGroupsRequest { GroupId = "group_id" });
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

**request:** `DeleteGroupsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Groups.<a href="/src/Square/Customers/Groups/GroupsClient.cs">AddAsync</a>(AddGroupsRequest { ... }) -> AddGroupToCustomerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds a group membership to a customer.

The customer is identified by the `customer_id` value
and the customer group is identified by the `group_id` value.
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
await client.Customers.Groups.AddAsync(
    new AddGroupsRequest { CustomerId = "customer_id", GroupId = "group_id" }
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

**request:** `AddGroupsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Groups.<a href="/src/Square/Customers/Groups/GroupsClient.cs">RemoveAsync</a>(RemoveGroupsRequest { ... }) -> RemoveGroupFromCustomerResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes a group membership from a customer.

The customer is identified by the `customer_id` value
and the customer group is identified by the `group_id` value.
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
await client.Customers.Groups.RemoveAsync(
    new RemoveGroupsRequest { CustomerId = "customer_id", GroupId = "group_id" }
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

**request:** `RemoveGroupsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Customers Segments
<details><summary><code>client.Customers.Segments.<a href="/src/Square/Customers/Segments/SegmentsClient.cs">ListAsync</a>(ListSegmentsRequest { ... }) -> Pager<CustomerSegment></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the list of customer segments of a business.
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
await client.Customers.Segments.ListAsync(new ListSegmentsRequest());
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

**request:** `ListSegmentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Segments.<a href="/src/Square/Customers/Segments/SegmentsClient.cs">GetAsync</a>(GetSegmentsRequest { ... }) -> GetCustomerSegmentResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a specific customer segment as identified by the `segment_id` value.
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
await client.Customers.Segments.GetAsync(new GetSegmentsRequest { SegmentId = "segment_id" });
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

**request:** `GetSegmentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Customers Cards
<details><summary><code>client.Customers.Cards.<a href="/src/Square/Customers/Cards/CardsClient.cs">CreateAsync</a>(CreateCustomerCardRequest { ... }) -> CreateCustomerCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds a card on file to an existing customer.

As with charges, calls to `CreateCustomerCard` are idempotent. Multiple
calls with the same card nonce return the same card record that was created
with the provided nonce during the _first_ call.
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
await client.Customers.Cards.CreateAsync(
    new CreateCustomerCardRequest
    {
        CustomerId = "customer_id",
        CardNonce = "YOUR_CARD_NONCE",
        BillingAddress = new Address
        {
            AddressLine1 = "500 Electric Ave",
            AddressLine2 = "Suite 600",
            Locality = "New York",
            AdministrativeDistrictLevel1 = "NY",
            PostalCode = "10003",
            Country = Country.Us,
        },
        CardholderName = "Amelia Earhart",
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

**request:** `CreateCustomerCardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.Cards.<a href="/src/Square/Customers/Cards/CardsClient.cs">DeleteAsync</a>(DeleteCardsRequest { ... }) -> DeleteCustomerCardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes a card on file from a customer.
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
await client.Customers.Cards.DeleteAsync(
    new DeleteCardsRequest { CustomerId = "customer_id", CardId = "card_id" }
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

**request:** `DeleteCardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Customers CustomAttributes
<details><summary><code>client.Customers.CustomAttributes.<a href="/src/Square/Customers/CustomAttributes/CustomAttributesClient.cs">ListAsync</a>(ListCustomAttributesRequest { ... }) -> Pager<CustomAttribute></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the [custom attributes](entity:CustomAttribute) associated with a customer profile.

You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
in the same call.

When all response pages are retrieved, the results include all custom attributes that are
visible to the requesting application, including those that are owned by other applications
and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Customers.CustomAttributes.ListAsync(
    new ListCustomAttributesRequest { CustomerId = "customer_id" }
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

**request:** `ListCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributes.<a href="/src/Square/Customers/CustomAttributes/CustomAttributesClient.cs">GetAsync</a>(GetCustomAttributesRequest { ... }) -> GetCustomerCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a [custom attribute](entity:CustomAttribute) associated with a customer profile.

You can use the `with_definition` query parameter to also retrieve the custom attribute definition
in the same call.

To retrieve a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Customers.CustomAttributes.GetAsync(
    new GetCustomAttributesRequest { CustomerId = "customer_id", Key = "key" }
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

**request:** `GetCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributes.<a href="/src/Square/Customers/CustomAttributes/CustomAttributesClient.cs">UpsertAsync</a>(UpsertCustomerCustomAttributeRequest { ... }) -> UpsertCustomerCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates a [custom attribute](entity:CustomAttribute) for a customer profile.

Use this endpoint to set the value of a custom attribute for a specified customer profile.
A custom attribute is based on a custom attribute definition in a Square seller account, which
is created using the [CreateCustomerCustomAttributeDefinition](api-endpoint:CustomerCustomAttributes-CreateCustomerCustomAttributeDefinition) endpoint.

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Customers.CustomAttributes.UpsertAsync(
    new UpsertCustomerCustomAttributeRequest
    {
        CustomerId = "customer_id",
        Key = "key",
        CustomAttribute = new CustomAttribute { Value = "Dune" },
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

**request:** `UpsertCustomerCustomAttributeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Customers.CustomAttributes.<a href="/src/Square/Customers/CustomAttributes/CustomAttributesClient.cs">DeleteAsync</a>(DeleteCustomAttributesRequest { ... }) -> DeleteCustomerCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a [custom attribute](entity:CustomAttribute) associated with a customer profile.

To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Customers.CustomAttributes.DeleteAsync(
    new DeleteCustomAttributesRequest { CustomerId = "customer_id", Key = "key" }
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

**request:** `DeleteCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Devices Codes
<details><summary><code>client.Devices.Codes.<a href="/src/Square/Devices/Codes/CodesClient.cs">ListAsync</a>(ListCodesRequest { ... }) -> Pager<DeviceCode></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all DeviceCodes associated with the merchant.
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
await client.Devices.Codes.ListAsync(new ListCodesRequest());
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

**request:** `ListCodesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Devices.Codes.<a href="/src/Square/Devices/Codes/CodesClient.cs">CreateAsync</a>(CreateDeviceCodeRequest { ... }) -> CreateDeviceCodeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a DeviceCode that can be used to login to a Square Terminal device to enter the connected
terminal mode.
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
await client.Devices.Codes.CreateAsync(
    new CreateDeviceCodeRequest
    {
        IdempotencyKey = "01bb00a6-0c86-4770-94ed-f5fca973cd56",
        DeviceCode = new DeviceCode
        {
            Name = "Counter 1",
            ProductType = "TERMINAL_API",
            LocationId = "B5E4484SHHNYH",
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

**request:** `CreateDeviceCodeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Devices.Codes.<a href="/src/Square/Devices/Codes/CodesClient.cs">GetAsync</a>(GetCodesRequest { ... }) -> GetDeviceCodeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves DeviceCode with the associated ID.
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
await client.Devices.Codes.GetAsync(new GetCodesRequest { Id = "id" });
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

**request:** `GetCodesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Disputes Evidence
<details><summary><code>client.Disputes.Evidence.<a href="/src/Square/Disputes/Evidence/EvidenceClient.cs">ListAsync</a>(ListEvidenceRequest { ... }) -> Pager<DisputeEvidence></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of evidence associated with a dispute.
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
await client.Disputes.Evidence.ListAsync(new ListEvidenceRequest { DisputeId = "dispute_id" });
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

**request:** `ListEvidenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Disputes.Evidence.<a href="/src/Square/Disputes/Evidence/EvidenceClient.cs">GetAsync</a>(GetEvidenceRequest { ... }) -> GetDisputeEvidenceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the metadata for the evidence specified in the request URL path.

You must maintain a copy of any evidence uploaded if you want to reference it later. Evidence cannot be downloaded after you upload it.
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
await client.Disputes.Evidence.GetAsync(
    new GetEvidenceRequest { DisputeId = "dispute_id", EvidenceId = "evidence_id" }
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

**request:** `GetEvidenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Disputes.Evidence.<a href="/src/Square/Disputes/Evidence/EvidenceClient.cs">DeleteAsync</a>(DeleteEvidenceRequest { ... }) -> DeleteDisputeEvidenceResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes specified evidence from a dispute.
Square does not send the bank any evidence that is removed.
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
await client.Disputes.Evidence.DeleteAsync(
    new DeleteEvidenceRequest { DisputeId = "dispute_id", EvidenceId = "evidence_id" }
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

**request:** `DeleteEvidenceRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## GiftCards Activities
<details><summary><code>client.GiftCards.Activities.<a href="/src/Square/GiftCards/Activities/ActivitiesClient.cs">ListAsync</a>(ListActivitiesRequest { ... }) -> Pager<GiftCardActivity></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists gift card activities. By default, you get gift card activities for all
gift cards in the seller's account. You can optionally specify query parameters to
filter the list. For example, you can get a list of gift card activities for a gift card,
for all gift cards in a specific region, or for activities within a time window.
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
await client.GiftCards.Activities.ListAsync(new ListActivitiesRequest());
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

**request:** `ListActivitiesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.GiftCards.Activities.<a href="/src/Square/GiftCards/Activities/ActivitiesClient.cs">CreateAsync</a>(CreateGiftCardActivityRequest { ... }) -> CreateGiftCardActivityResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a gift card activity to manage the balance or state of a [gift card](entity:GiftCard).
For example, create an `ACTIVATE` activity to activate a gift card with an initial balance before first use.
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
await client.GiftCards.Activities.CreateAsync(
    new CreateGiftCardActivityRequest
    {
        IdempotencyKey = "U16kfr-kA70er-q4Rsym-7U7NnY",
        GiftCardActivity = new GiftCardActivity
        {
            Type = GiftCardActivityType.Activate,
            LocationId = "81FN9BNFZTKS4",
            GiftCardId = "gftc:6d55a72470d940c6ba09c0ab8ad08d20",
            ActivateActivityDetails = new GiftCardActivityActivate
            {
                OrderId = "jJNGHm4gLI6XkFbwtiSLqK72KkAZY",
                LineItemUid = "eIWl7X0nMuO9Ewbh0ChIx",
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

**request:** `CreateGiftCardActivityRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Labor BreakTypes
<details><summary><code>client.Labor.BreakTypes.<a href="/src/Square/Labor/BreakTypes/BreakTypesClient.cs">ListAsync</a>(ListBreakTypesRequest { ... }) -> Pager<BreakType></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of `BreakType` instances for a business.
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
await client.Labor.BreakTypes.ListAsync(new ListBreakTypesRequest());
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

**request:** `ListBreakTypesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.BreakTypes.<a href="/src/Square/Labor/BreakTypes/BreakTypesClient.cs">CreateAsync</a>(CreateBreakTypeRequest { ... }) -> CreateBreakTypeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new `BreakType`.

A `BreakType` is a template for creating `Break` objects.
You must provide the following values in your request to this
endpoint:

- `location_id`
- `break_name`
- `expected_duration`
- `is_paid`

You can only have three `BreakType` instances per location. If you attempt to add a fourth
`BreakType` for a location, an `INVALID_REQUEST_ERROR` "Exceeded limit of 3 breaks per location."
is returned.
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
await client.Labor.BreakTypes.CreateAsync(
    new CreateBreakTypeRequest
    {
        IdempotencyKey = "PAD3NG5KSN2GL",
        BreakType = new BreakType
        {
            LocationId = "CGJN03P1D08GF",
            BreakName = "Lunch Break",
            ExpectedDuration = "PT30M",
            IsPaid = true,
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

**request:** `CreateBreakTypeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.BreakTypes.<a href="/src/Square/Labor/BreakTypes/BreakTypesClient.cs">GetAsync</a>(GetBreakTypesRequest { ... }) -> GetBreakTypeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a single `BreakType` specified by `id`.
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
await client.Labor.BreakTypes.GetAsync(new GetBreakTypesRequest { Id = "id" });
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

**request:** `GetBreakTypesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.BreakTypes.<a href="/src/Square/Labor/BreakTypes/BreakTypesClient.cs">UpdateAsync</a>(UpdateBreakTypeRequest { ... }) -> UpdateBreakTypeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an existing `BreakType`.
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
await client.Labor.BreakTypes.UpdateAsync(
    new UpdateBreakTypeRequest
    {
        Id = "id",
        BreakType = new BreakType
        {
            LocationId = "26M7H24AZ9N6R",
            BreakName = "Lunch",
            ExpectedDuration = "PT50M",
            IsPaid = true,
            Version = 1,
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

**request:** `UpdateBreakTypeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.BreakTypes.<a href="/src/Square/Labor/BreakTypes/BreakTypesClient.cs">DeleteAsync</a>(DeleteBreakTypesRequest { ... }) -> DeleteBreakTypeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes an existing `BreakType`.

A `BreakType` can be deleted even if it is referenced from a `Shift`.
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
await client.Labor.BreakTypes.DeleteAsync(new DeleteBreakTypesRequest { Id = "id" });
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

**request:** `DeleteBreakTypesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Labor EmployeeWages
<details><summary><code>client.Labor.EmployeeWages.<a href="/src/Square/Labor/EmployeeWages/EmployeeWagesClient.cs">ListAsync</a>(ListEmployeeWagesRequest { ... }) -> Pager<EmployeeWage></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of `EmployeeWage` instances for a business.
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
await client.Labor.EmployeeWages.ListAsync(new ListEmployeeWagesRequest());
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

**request:** `ListEmployeeWagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.EmployeeWages.<a href="/src/Square/Labor/EmployeeWages/EmployeeWagesClient.cs">GetAsync</a>(GetEmployeeWagesRequest { ... }) -> GetEmployeeWageResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a single `EmployeeWage` specified by `id`.
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
await client.Labor.EmployeeWages.GetAsync(new GetEmployeeWagesRequest { Id = "id" });
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

**request:** `GetEmployeeWagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Labor Shifts
<details><summary><code>client.Labor.Shifts.<a href="/src/Square/Labor/Shifts/ShiftsClient.cs">CreateAsync</a>(CreateShiftRequest { ... }) -> CreateShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new `Shift`.

A `Shift` represents a complete workday for a single team member.
You must provide the following values in your request to this
endpoint:

- `location_id`
- `team_member_id`
- `start_at`

An attempt to create a new `Shift` can result in a `BAD_REQUEST` error when:
- The `status` of the new `Shift` is `OPEN` and the team member has another
shift with an `OPEN` status.
- The `start_at` date is in the future.
- The `start_at` or `end_at` date overlaps another shift for the same team member.
- The `Break` instances are set in the request and a break `start_at`
is before the `Shift.start_at`, a break `end_at` is after
the `Shift.end_at`, or both.
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
await client.Labor.Shifts.CreateAsync(
    new CreateShiftRequest
    {
        IdempotencyKey = "HIDSNG5KS478L",
        Shift = new Shift
        {
            LocationId = "PAA1RJZZKXBFG",
            StartAt = "2019-01-25T03:11:00-05:00",
            EndAt = "2019-01-25T13:11:00-05:00",
            Wage = new ShiftWage
            {
                Title = "Barista",
                HourlyRate = new Money { Amount = 1100, Currency = Currency.Usd },
                TipEligible = true,
            },
            Breaks = new List<Break>()
            {
                new Break
                {
                    StartAt = "2019-01-25T06:11:00-05:00",
                    EndAt = "2019-01-25T06:16:00-05:00",
                    BreakTypeId = "REGS1EQR1TPZ5",
                    Name = "Tea Break",
                    ExpectedDuration = "PT5M",
                    IsPaid = true,
                },
            },
            TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
            DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
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

**request:** `CreateShiftRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.Shifts.<a href="/src/Square/Labor/Shifts/ShiftsClient.cs">SearchAsync</a>(SearchShiftsRequest { ... }) -> SearchShiftsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of `Shift` records for a business.
The list to be returned can be filtered by:
- Location IDs
- Team member IDs
- Shift status (`OPEN` or `CLOSED`)
- Shift start
- Shift end
- Workday details

The list can be sorted by:
- `START_AT`
- `END_AT`
- `CREATED_AT`
- `UPDATED_AT`
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
await client.Labor.Shifts.SearchAsync(
    new SearchShiftsRequest
    {
        Query = new ShiftQuery
        {
            Filter = new ShiftFilter
            {
                Workday = new ShiftWorkday
                {
                    DateRange = new DateRange { StartDate = "2019-01-20", EndDate = "2019-02-03" },
                    MatchShiftsBy = ShiftWorkdayMatcher.StartAt,
                    DefaultTimezone = "America/Los_Angeles",
                },
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

**request:** `SearchShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.Shifts.<a href="/src/Square/Labor/Shifts/ShiftsClient.cs">GetAsync</a>(GetShiftsRequest { ... }) -> GetShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a single `Shift` specified by `id`.
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
await client.Labor.Shifts.GetAsync(new GetShiftsRequest { Id = "id" });
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

**request:** `GetShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.Shifts.<a href="/src/Square/Labor/Shifts/ShiftsClient.cs">UpdateAsync</a>(UpdateShiftRequest { ... }) -> UpdateShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an existing `Shift`.

When adding a `Break` to a `Shift`, any earlier `Break` instances in the `Shift` have
the `end_at` property set to a valid RFC-3339 datetime string.

When closing a `Shift`, all `Break` instances in the `Shift` must be complete with `end_at`
set on each `Break`.
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
await client.Labor.Shifts.UpdateAsync(
    new UpdateShiftRequest
    {
        Id = "id",
        Shift = new Shift
        {
            LocationId = "PAA1RJZZKXBFG",
            StartAt = "2019-01-25T03:11:00-05:00",
            EndAt = "2019-01-25T13:11:00-05:00",
            Wage = new ShiftWage
            {
                Title = "Bartender",
                HourlyRate = new Money { Amount = 1500, Currency = Currency.Usd },
                TipEligible = true,
            },
            Breaks = new List<Break>()
            {
                new Break
                {
                    Id = "X7GAQYVVRRG6P",
                    StartAt = "2019-01-25T06:11:00-05:00",
                    EndAt = "2019-01-25T06:16:00-05:00",
                    BreakTypeId = "REGS1EQR1TPZ5",
                    Name = "Tea Break",
                    ExpectedDuration = "PT5M",
                    IsPaid = true,
                },
            },
            Version = 1,
            TeamMemberId = "ormj0jJJZ5OZIzxrZYJI",
            DeclaredCashTipMoney = new Money { Amount = 500, Currency = Currency.Usd },
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

**request:** `UpdateShiftRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.Shifts.<a href="/src/Square/Labor/Shifts/ShiftsClient.cs">DeleteAsync</a>(DeleteShiftsRequest { ... }) -> DeleteShiftResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a `Shift`.
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
await client.Labor.Shifts.DeleteAsync(new DeleteShiftsRequest { Id = "id" });
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

**request:** `DeleteShiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Labor TeamMemberWages
<details><summary><code>client.Labor.TeamMemberWages.<a href="/src/Square/Labor/TeamMemberWages/TeamMemberWagesClient.cs">ListAsync</a>(ListTeamMemberWagesRequest { ... }) -> Pager<TeamMemberWage></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a paginated list of `TeamMemberWage` instances for a business.
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
await client.Labor.TeamMemberWages.ListAsync(new ListTeamMemberWagesRequest());
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

**request:** `ListTeamMemberWagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.TeamMemberWages.<a href="/src/Square/Labor/TeamMemberWages/TeamMemberWagesClient.cs">GetAsync</a>(GetTeamMemberWagesRequest { ... }) -> GetTeamMemberWageResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a single `TeamMemberWage` specified by `id`.
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
await client.Labor.TeamMemberWages.GetAsync(new GetTeamMemberWagesRequest { Id = "id" });
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

**request:** `GetTeamMemberWagesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Labor WorkweekConfigs
<details><summary><code>client.Labor.WorkweekConfigs.<a href="/src/Square/Labor/WorkweekConfigs/WorkweekConfigsClient.cs">ListAsync</a>(ListWorkweekConfigsRequest { ... }) -> Pager<WorkweekConfig></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of `WorkweekConfig` instances for a business.
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
await client.Labor.WorkweekConfigs.ListAsync(new ListWorkweekConfigsRequest());
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

**request:** `ListWorkweekConfigsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Labor.WorkweekConfigs.<a href="/src/Square/Labor/WorkweekConfigs/WorkweekConfigsClient.cs">GetAsync</a>(UpdateWorkweekConfigRequest { ... }) -> UpdateWorkweekConfigResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a `WorkweekConfig`.
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
await client.Labor.WorkweekConfigs.GetAsync(
    new UpdateWorkweekConfigRequest
    {
        Id = "id",
        WorkweekConfig = new WorkweekConfig
        {
            StartOfWeek = Weekday.Mon,
            StartOfDayLocalTime = "10:00",
            Version = 10,
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

**request:** `UpdateWorkweekConfigRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Locations CustomAttributeDefinitions
<details><summary><code>client.Locations.CustomAttributeDefinitions.<a href="/src/Square/Locations/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">ListAsync</a>(ListCustomAttributeDefinitionsRequest { ... }) -> Pager<CustomAttributeDefinition></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the location-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
When all response pages are retrieved, the results include all custom attribute definitions
that are visible to the requesting application, including those that are created by other
applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributeDefinitions.ListAsync(
    new ListCustomAttributeDefinitionsRequest()
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

**request:** `ListCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributeDefinitions.<a href="/src/Square/Locations/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">CreateAsync</a>(CreateLocationCustomAttributeDefinitionRequest { ... }) -> CreateLocationCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a location-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
Use this endpoint to define a custom attribute that can be associated with locations.
A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
for a custom attribute. After the definition is created, you can call
[UpsertLocationCustomAttribute](api-endpoint:LocationCustomAttributes-UpsertLocationCustomAttribute) or
[BulkUpsertLocationCustomAttributes](api-endpoint:LocationCustomAttributes-BulkUpsertLocationCustomAttributes)
to set the custom attribute for locations.
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
await client.Locations.CustomAttributeDefinitions.CreateAsync(
    new CreateLocationCustomAttributeDefinitionRequest
    {
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Key = "bestseller",
            Schema = new Dictionary<string, object>()
            {
                {
                    "ref",
                    "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
            },
            Name = "Bestseller",
            Description = "Bestselling item at location",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityReadWriteValues,
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

**request:** `CreateLocationCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributeDefinitions.<a href="/src/Square/Locations/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">GetAsync</a>(GetCustomAttributeDefinitionsRequest { ... }) -> RetrieveLocationCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a location-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
To retrieve a custom attribute definition created by another application, the `visibility`
setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributeDefinitions.GetAsync(
    new GetCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `GetCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributeDefinitions.<a href="/src/Square/Locations/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">UpdateAsync</a>(UpdateLocationCustomAttributeDefinitionRequest { ... }) -> UpdateLocationCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a location-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
`schema` for a `Selection` data type.
Only the definition owner can update a custom attribute definition.
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
await client.Locations.CustomAttributeDefinitions.UpdateAsync(
    new UpdateLocationCustomAttributeDefinitionRequest
    {
        Key = "key",
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Description = "Update the description as desired.",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
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

**request:** `UpdateLocationCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributeDefinitions.<a href="/src/Square/Locations/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">DeleteAsync</a>(DeleteCustomAttributeDefinitionsRequest { ... }) -> DeleteLocationCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a location-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
Deleting a custom attribute definition also deletes the corresponding custom attribute from
all locations.
Only the definition owner can delete a custom attribute definition.
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
await client.Locations.CustomAttributeDefinitions.DeleteAsync(
    new DeleteCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `DeleteCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Locations CustomAttributes
<details><summary><code>client.Locations.CustomAttributes.<a href="/src/Square/Locations/CustomAttributes/CustomAttributesClient.cs">BatchDeleteAsync</a>(BulkDeleteLocationCustomAttributesRequest { ... }) -> BulkDeleteLocationCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes [custom attributes](entity:CustomAttribute) for locations as a bulk operation.
To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributes.BatchDeleteAsync(
    new BulkDeleteLocationCustomAttributesRequest
    {
        Values = new Dictionary<
            string,
            BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
        >()
        {
            {
                "id1",
                new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
                {
                    Key = "bestseller",
                }
            },
            {
                "id2",
                new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
                {
                    Key = "bestseller",
                }
            },
            {
                "id3",
                new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
                {
                    Key = "phone-number",
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

**request:** `BulkDeleteLocationCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributes.<a href="/src/Square/Locations/CustomAttributes/CustomAttributesClient.cs">BatchUpsertAsync</a>(BulkUpsertLocationCustomAttributesRequest { ... }) -> BulkUpsertLocationCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates [custom attributes](entity:CustomAttribute) for locations as a bulk operation.
Use this endpoint to set the value of one or more custom attributes for one or more locations.
A custom attribute is based on a custom attribute definition in a Square seller account, which is
created using the [CreateLocationCustomAttributeDefinition](api-endpoint:LocationCustomAttributes-CreateLocationCustomAttributeDefinition) endpoint.
This `BulkUpsertLocationCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
requests and returns a map of individual upsert responses. Each upsert request has a unique ID
and provides a location ID and custom attribute. Each upsert response is returned with the ID
of the corresponding request.
To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributes.BatchUpsertAsync(
    new BulkUpsertLocationCustomAttributesRequest
    {
        Values = new Dictionary<
            string,
            BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
        >()
        {
            {
                "id1",
                new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
                {
                    LocationId = "L0TBCBTB7P8RQ",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "bestseller",
                        Value = "hot cocoa",
                    },
                }
            },
            {
                "id2",
                new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
                {
                    LocationId = "L9XMD04V3STJX",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "bestseller",
                        Value = "berry smoothie",
                    },
                }
            },
            {
                "id3",
                new BulkUpsertLocationCustomAttributesRequestLocationCustomAttributeUpsertRequest
                {
                    LocationId = "L0TBCBTB7P8RQ",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "phone-number",
                        Value = "+12223334444",
                    },
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

**request:** `BulkUpsertLocationCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributes.<a href="/src/Square/Locations/CustomAttributes/CustomAttributesClient.cs">ListAsync</a>(ListCustomAttributesRequest { ... }) -> Pager<CustomAttribute></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the [custom attributes](entity:CustomAttribute) associated with a location.
You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
in the same call.
When all response pages are retrieved, the results include all custom attributes that are
visible to the requesting application, including those that are owned by other applications
and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributes.ListAsync(
    new ListCustomAttributesRequest { LocationId = "location_id" }
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

**request:** `ListCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributes.<a href="/src/Square/Locations/CustomAttributes/CustomAttributesClient.cs">GetAsync</a>(GetCustomAttributesRequest { ... }) -> RetrieveLocationCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a [custom attribute](entity:CustomAttribute) associated with a location.
You can use the `with_definition` query parameter to also retrieve the custom attribute definition
in the same call.
To retrieve a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributes.GetAsync(
    new GetCustomAttributesRequest { LocationId = "location_id", Key = "key" }
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

**request:** `GetCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributes.<a href="/src/Square/Locations/CustomAttributes/CustomAttributesClient.cs">UpsertAsync</a>(UpsertLocationCustomAttributeRequest { ... }) -> UpsertLocationCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates a [custom attribute](entity:CustomAttribute) for a location.
Use this endpoint to set the value of a custom attribute for a specified location.
A custom attribute is based on a custom attribute definition in a Square seller account, which
is created using the [CreateLocationCustomAttributeDefinition](api-endpoint:LocationCustomAttributes-CreateLocationCustomAttributeDefinition) endpoint.
To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributes.UpsertAsync(
    new UpsertLocationCustomAttributeRequest
    {
        LocationId = "location_id",
        Key = "key",
        CustomAttribute = new CustomAttribute { Value = "hot cocoa" },
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

**request:** `UpsertLocationCustomAttributeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.CustomAttributes.<a href="/src/Square/Locations/CustomAttributes/CustomAttributesClient.cs">DeleteAsync</a>(DeleteCustomAttributesRequest { ... }) -> DeleteLocationCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a [custom attribute](entity:CustomAttribute) associated with a location.
To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`.
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
await client.Locations.CustomAttributes.DeleteAsync(
    new DeleteCustomAttributesRequest { LocationId = "location_id", Key = "key" }
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

**request:** `DeleteCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Locations Transactions
<details><summary><code>client.Locations.Transactions.<a href="/src/Square/Locations/Transactions/TransactionsClient.cs">ListAsync</a>(ListTransactionsRequest { ... }) -> ListTransactionsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists transactions for a particular location.

Transactions include payment information from sales and exchanges and refund
information from returns and exchanges.

Max results per [page](https://developer.squareup.com/docs/working-with-apis/pagination): 50
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
await client.Locations.Transactions.ListAsync(
    new ListTransactionsRequest { LocationId = "location_id" }
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

**request:** `ListTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.Transactions.<a href="/src/Square/Locations/Transactions/TransactionsClient.cs">GetAsync</a>(GetTransactionsRequest { ... }) -> GetTransactionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves details for a single transaction.
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
await client.Locations.Transactions.GetAsync(
    new GetTransactionsRequest { LocationId = "location_id", TransactionId = "transaction_id" }
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

**request:** `GetTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.Transactions.<a href="/src/Square/Locations/Transactions/TransactionsClient.cs">CaptureAsync</a>(CaptureTransactionsRequest { ... }) -> CaptureTransactionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Captures a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
endpoint with a `delay_capture` value of `true`.


See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
for more information.
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
await client.Locations.Transactions.CaptureAsync(
    new CaptureTransactionsRequest { LocationId = "location_id", TransactionId = "transaction_id" }
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

**request:** `CaptureTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Locations.Transactions.<a href="/src/Square/Locations/Transactions/TransactionsClient.cs">VoidAsync</a>(VoidTransactionsRequest { ... }) -> VoidTransactionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels a transaction that was created with the [Charge](api-endpoint:Transactions-Charge)
endpoint with a `delay_capture` value of `true`.


See [Delayed capture transactions](https://developer.squareup.com/docs/payments/transactions/overview#delayed-capture)
for more information.
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
await client.Locations.Transactions.VoidAsync(
    new VoidTransactionsRequest { LocationId = "location_id", TransactionId = "transaction_id" }
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

**request:** `VoidTransactionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Loyalty Accounts
<details><summary><code>client.Loyalty.Accounts.<a href="/src/Square/Loyalty/Accounts/AccountsClient.cs">CreateAsync</a>(CreateLoyaltyAccountRequest { ... }) -> CreateLoyaltyAccountResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a loyalty account. To create a loyalty account, you must provide the `program_id` and a `mapping` with the `phone_number` of the buyer.
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
await client.Loyalty.Accounts.CreateAsync(
    new CreateLoyaltyAccountRequest
    {
        LoyaltyAccount = new LoyaltyAccount
        {
            ProgramId = "d619f755-2d17-41f3-990d-c04ecedd64dd",
            Mapping = new LoyaltyAccountMapping { PhoneNumber = "+14155551234" },
        },
        IdempotencyKey = "ec78c477-b1c3-4899-a209-a4e71337c996",
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

**request:** `CreateLoyaltyAccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Accounts.<a href="/src/Square/Loyalty/Accounts/AccountsClient.cs">SearchAsync</a>(SearchLoyaltyAccountsRequest { ... }) -> SearchLoyaltyAccountsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for loyalty accounts in a loyalty program.

You can search for a loyalty account using the phone number or customer ID associated with the account. To return all loyalty accounts, specify an empty `query` object or omit it entirely.

Search results are sorted by `created_at` in ascending order.
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
await client.Loyalty.Accounts.SearchAsync(
    new SearchLoyaltyAccountsRequest
    {
        Query = new SearchLoyaltyAccountsRequestLoyaltyAccountQuery
        {
            Mappings = new List<LoyaltyAccountMapping>()
            {
                new LoyaltyAccountMapping { PhoneNumber = "+14155551234" },
            },
        },
        Limit = 10,
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

**request:** `SearchLoyaltyAccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Accounts.<a href="/src/Square/Loyalty/Accounts/AccountsClient.cs">GetAsync</a>(GetAccountsRequest { ... }) -> GetLoyaltyAccountResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a loyalty account.
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
await client.Loyalty.Accounts.GetAsync(new GetAccountsRequest { AccountId = "account_id" });
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

**request:** `GetAccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Accounts.<a href="/src/Square/Loyalty/Accounts/AccountsClient.cs">AccumulatePointsAsync</a>(AccumulateLoyaltyPointsRequest { ... }) -> AccumulateLoyaltyPointsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds points earned from a purchase to a [loyalty account](entity:LoyaltyAccount).

- If you are using the Orders API to manage orders, provide the `order_id`. Square reads the order
to compute the points earned from both the base loyalty program and an associated
[loyalty promotion](entity:LoyaltyPromotion). For purchases that qualify for multiple accrual
rules, Square computes points based on the accrual rule that grants the most points.
For purchases that qualify for multiple promotions, Square computes points based on the most
recently created promotion. A purchase must first qualify for program points to be eligible for promotion points.

- If you are not using the Orders API to manage orders, provide `points` with the number of points to add.
You must first perform a client-side computation of the points earned from the loyalty program and
loyalty promotion. For spend-based and visit-based programs, you can call [CalculateLoyaltyPoints](api-endpoint:Loyalty-CalculateLoyaltyPoints)
to compute the points earned from the base loyalty program. For information about computing points earned from a loyalty promotion, see
[Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
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
await client.Loyalty.Accounts.AccumulatePointsAsync(
    new AccumulateLoyaltyPointsRequest
    {
        AccountId = "account_id",
        AccumulatePoints = new LoyaltyEventAccumulatePoints
        {
            OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
        },
        IdempotencyKey = "58b90739-c3e8-4b11-85f7-e636d48d72cb",
        LocationId = "P034NEENMD09F",
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

**request:** `AccumulateLoyaltyPointsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Accounts.<a href="/src/Square/Loyalty/Accounts/AccountsClient.cs">AdjustAsync</a>(AdjustLoyaltyPointsRequest { ... }) -> AdjustLoyaltyPointsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds points to or subtracts points from a buyer's account.

Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call
[AccumulateLoyaltyPoints](api-endpoint:Loyalty-AccumulateLoyaltyPoints)
to add points when a buyer pays for the purchase.
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
await client.Loyalty.Accounts.AdjustAsync(
    new AdjustLoyaltyPointsRequest
    {
        AccountId = "account_id",
        IdempotencyKey = "bc29a517-3dc9-450e-aa76-fae39ee849d1",
        AdjustPoints = new LoyaltyEventAdjustPoints
        {
            Points = 10,
            Reason = "Complimentary points",
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

**request:** `AdjustLoyaltyPointsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Loyalty Programs
<details><summary><code>client.Loyalty.Programs.<a href="/src/Square/Loyalty/Programs/ProgramsClient.cs">ListAsync</a>() -> ListLoyaltyProgramsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a list of loyalty programs in the seller's account.
Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).


Replaced with [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) when used with the keyword `main`.
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
await client.Loyalty.Programs.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Programs.<a href="/src/Square/Loyalty/Programs/ProgramsClient.cs">GetAsync</a>(GetProgramsRequest { ... }) -> GetLoyaltyProgramResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the loyalty program in a seller's account, specified by the program ID or the keyword `main`.

Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
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
await client.Loyalty.Programs.GetAsync(new GetProgramsRequest { ProgramId = "program_id" });
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

**request:** `GetProgramsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Programs.<a href="/src/Square/Loyalty/Programs/ProgramsClient.cs">CalculateAsync</a>(CalculateLoyaltyPointsRequest { ... }) -> CalculateLoyaltyPointsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Calculates the number of points a buyer can earn from a purchase. Applications might call this endpoint
to display the points to the buyer.

- If you are using the Orders API to manage orders, provide the `order_id` and (optional) `loyalty_account_id`.
Square reads the order to compute the points earned from the base loyalty program and an associated
[loyalty promotion](entity:LoyaltyPromotion).

- If you are not using the Orders API to manage orders, provide `transaction_amount_money` with the
purchase amount. Square uses this amount to calculate the points earned from the base loyalty program,
but not points earned from a loyalty promotion. For spend-based and visit-based programs, the `tax_mode`
setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
If the purchase qualifies for program points, call
[ListLoyaltyPromotions](api-endpoint:Loyalty-ListLoyaltyPromotions) and perform a client-side computation
to calculate whether the purchase also qualifies for promotion points. For more information, see
[Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
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
await client.Loyalty.Programs.CalculateAsync(
    new CalculateLoyaltyPointsRequest
    {
        ProgramId = "program_id",
        OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
        LoyaltyAccountId = "79b807d2-d786-46a9-933b-918028d7a8c5",
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

**request:** `CalculateLoyaltyPointsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Loyalty Rewards
<details><summary><code>client.Loyalty.Rewards.<a href="/src/Square/Loyalty/Rewards/RewardsClient.cs">CreateAsync</a>(CreateLoyaltyRewardRequest { ... }) -> CreateLoyaltyRewardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a loyalty reward. In the process, the endpoint does following:

- Uses the `reward_tier_id` in the request to determine the number of points
to lock for this reward.
- If the request includes `order_id`, it adds the reward and related discount to the order.

After a reward is created, the points are locked and
not available for the buyer to redeem another reward.
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
await client.Loyalty.Rewards.CreateAsync(
    new CreateLoyaltyRewardRequest
    {
        Reward = new LoyaltyReward
        {
            LoyaltyAccountId = "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
            RewardTierId = "e1b39225-9da5-43d1-a5db-782cdd8ad94f",
            OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
        },
        IdempotencyKey = "18c2e5ea-a620-4b1f-ad60-7b167285e451",
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

**request:** `CreateLoyaltyRewardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Rewards.<a href="/src/Square/Loyalty/Rewards/RewardsClient.cs">SearchAsync</a>(SearchLoyaltyRewardsRequest { ... }) -> SearchLoyaltyRewardsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Searches for loyalty rewards. This endpoint accepts a request with no query filters and returns results for all loyalty accounts.
If you include a `query` object, `loyalty_account_id` is required and `status` is  optional.

If you know a reward ID, use the
[RetrieveLoyaltyReward](api-endpoint:Loyalty-RetrieveLoyaltyReward) endpoint.

Search results are sorted by `updated_at` in descending order.
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
await client.Loyalty.Rewards.SearchAsync(
    new SearchLoyaltyRewardsRequest
    {
        Query = new SearchLoyaltyRewardsRequestLoyaltyRewardQuery
        {
            LoyaltyAccountId = "5adcb100-07f1-4ee7-b8c6-6bb9ebc474bd",
        },
        Limit = 10,
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

**request:** `SearchLoyaltyRewardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Rewards.<a href="/src/Square/Loyalty/Rewards/RewardsClient.cs">GetAsync</a>(GetRewardsRequest { ... }) -> GetLoyaltyRewardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a loyalty reward.
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
await client.Loyalty.Rewards.GetAsync(new GetRewardsRequest { RewardId = "reward_id" });
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

**request:** `GetRewardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Rewards.<a href="/src/Square/Loyalty/Rewards/RewardsClient.cs">DeleteAsync</a>(DeleteRewardsRequest { ... }) -> DeleteLoyaltyRewardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a loyalty reward by doing the following:

- Returns the loyalty points back to the loyalty account.
- If an order ID was specified when the reward was created
(see [CreateLoyaltyReward](api-endpoint:Loyalty-CreateLoyaltyReward)),
it updates the order by removing the reward and related
discounts.

You cannot delete a reward that has reached the terminal state (REDEEMED).
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
await client.Loyalty.Rewards.DeleteAsync(new DeleteRewardsRequest { RewardId = "reward_id" });
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

**request:** `DeleteRewardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Rewards.<a href="/src/Square/Loyalty/Rewards/RewardsClient.cs">RedeemAsync</a>(RedeemLoyaltyRewardRequest { ... }) -> RedeemLoyaltyRewardResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Redeems a loyalty reward.

The endpoint sets the reward to the `REDEEMED` terminal state.

If you are using your own order processing system (not using the
Orders API), you call this endpoint after the buyer paid for the
purchase.

After the reward reaches the terminal state, it cannot be deleted.
In other words, points used for the reward cannot be returned
to the account.
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
await client.Loyalty.Rewards.RedeemAsync(
    new RedeemLoyaltyRewardRequest
    {
        RewardId = "reward_id",
        IdempotencyKey = "98adc7f7-6963-473b-b29c-f3c9cdd7d994",
        LocationId = "P034NEENMD09F",
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

**request:** `RedeemLoyaltyRewardRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Loyalty Programs Promotions
<details><summary><code>client.Loyalty.Programs.Promotions.<a href="/src/Square/Loyalty/Programs/Promotions/PromotionsClient.cs">ListAsync</a>(ListPromotionsRequest { ... }) -> Pager<LoyaltyPromotion></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the loyalty promotions associated with a [loyalty program](entity:LoyaltyProgram).
Results are sorted by the `created_at` date in descending order (newest to oldest).
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
await client.Loyalty.Programs.Promotions.ListAsync(
    new ListPromotionsRequest { ProgramId = "program_id" }
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

**request:** `ListPromotionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Programs.Promotions.<a href="/src/Square/Loyalty/Programs/Promotions/PromotionsClient.cs">CreateAsync</a>(CreateLoyaltyPromotionRequest { ... }) -> CreateLoyaltyPromotionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a loyalty promotion for a [loyalty program](entity:LoyaltyProgram). A loyalty promotion
enables buyers to earn points in addition to those earned from the base loyalty program.

This endpoint sets the loyalty promotion to the `ACTIVE` or `SCHEDULED` status, depending on the
`available_time` setting. A loyalty program can have a maximum of 10 loyalty promotions with an
`ACTIVE` or `SCHEDULED` status.
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
await client.Loyalty.Programs.Promotions.CreateAsync(
    new CreateLoyaltyPromotionRequest
    {
        ProgramId = "program_id",
        LoyaltyPromotion = new LoyaltyPromotion
        {
            Name = "Tuesday Happy Hour Promo",
            Incentive = new LoyaltyPromotionIncentive
            {
                Type = LoyaltyPromotionIncentiveType.PointsMultiplier,
                PointsMultiplierData = new LoyaltyPromotionIncentivePointsMultiplierData
                {
                    Multiplier = "3.0",
                },
            },
            AvailableTime = new LoyaltyPromotionAvailableTimeData
            {
                TimePeriods = new List<string>()
                {
                    "BEGIN:VEVENT\nDTSTART:20220816T160000\nDURATION:PT2H\nRRULE:FREQ=WEEKLY;BYDAY=TU\nEND:VEVENT",
                },
            },
            TriggerLimit = new LoyaltyPromotionTriggerLimit
            {
                Times = 1,
                Interval = LoyaltyPromotionTriggerLimitInterval.Day,
            },
            MinimumSpendAmountMoney = new Money { Amount = 2000, Currency = Currency.Usd },
            QualifyingCategoryIds = new List<string>() { "XTQPYLR3IIU9C44VRCB3XD12" },
        },
        IdempotencyKey = "ec78c477-b1c3-4899-a209-a4e71337c996",
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

**request:** `CreateLoyaltyPromotionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Programs.Promotions.<a href="/src/Square/Loyalty/Programs/Promotions/PromotionsClient.cs">GetAsync</a>(GetPromotionsRequest { ... }) -> GetLoyaltyPromotionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a loyalty promotion.
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
await client.Loyalty.Programs.Promotions.GetAsync(
    new GetPromotionsRequest { PromotionId = "promotion_id", ProgramId = "program_id" }
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

**request:** `GetPromotionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loyalty.Programs.Promotions.<a href="/src/Square/Loyalty/Programs/Promotions/PromotionsClient.cs">CancelAsync</a>(CancelPromotionsRequest { ... }) -> CancelLoyaltyPromotionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels a loyalty promotion. Use this endpoint to cancel an `ACTIVE` promotion earlier than the
end date, cancel an `ACTIVE` promotion when an end date is not specified, or cancel a `SCHEDULED` promotion.
Because updating a promotion is not supported, you can also use this endpoint to cancel a promotion before
you create a new one.

This endpoint sets the loyalty promotion to the `CANCELED` state
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
await client.Loyalty.Programs.Promotions.CancelAsync(
    new CancelPromotionsRequest { PromotionId = "promotion_id", ProgramId = "program_id" }
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

**request:** `CancelPromotionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Merchants CustomAttributeDefinitions
<details><summary><code>client.Merchants.CustomAttributeDefinitions.<a href="/src/Square/Merchants/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">ListAsync</a>(ListCustomAttributeDefinitionsRequest { ... }) -> Pager<CustomAttributeDefinition></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the merchant-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.
When all response pages are retrieved, the results include all custom attribute definitions
that are visible to the requesting application, including those that are created by other
applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributeDefinitions.ListAsync(
    new ListCustomAttributeDefinitionsRequest()
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

**request:** `ListCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributeDefinitions.<a href="/src/Square/Merchants/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">CreateAsync</a>(CreateMerchantCustomAttributeDefinitionRequest { ... }) -> CreateMerchantCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
Use this endpoint to define a custom attribute that can be associated with a merchant connecting to your application.
A custom attribute definition specifies the `key`, `visibility`, `schema`, and other properties
for a custom attribute. After the definition is created, you can call
[UpsertMerchantCustomAttribute](api-endpoint:MerchantCustomAttributes-UpsertMerchantCustomAttribute) or
[BulkUpsertMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkUpsertMerchantCustomAttributes)
to set the custom attribute for a merchant.
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
await client.Merchants.CustomAttributeDefinitions.CreateAsync(
    new CreateMerchantCustomAttributeDefinitionRequest
    {
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Key = "alternative_seller_name",
            Schema = new Dictionary<string, object>()
            {
                {
                    "ref",
                    "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                },
            },
            Name = "Alternative Merchant Name",
            Description = "This is the other name this merchant goes by.",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
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

**request:** `CreateMerchantCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributeDefinitions.<a href="/src/Square/Merchants/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">GetAsync</a>(GetCustomAttributeDefinitionsRequest { ... }) -> RetrieveMerchantCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
To retrieve a custom attribute definition created by another application, the `visibility`
setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributeDefinitions.GetAsync(
    new GetCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `GetCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributeDefinitions.<a href="/src/Square/Merchants/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">UpdateAsync</a>(UpdateMerchantCustomAttributeDefinitionRequest { ... }) -> UpdateMerchantCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) for a Square seller account.
Use this endpoint to update the following fields: `name`, `description`, `visibility`, or the
`schema` for a `Selection` data type.
Only the definition owner can update a custom attribute definition.
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
await client.Merchants.CustomAttributeDefinitions.UpdateAsync(
    new UpdateMerchantCustomAttributeDefinitionRequest
    {
        Key = "key",
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Description = "Update the description as desired.",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
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

**request:** `UpdateMerchantCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributeDefinitions.<a href="/src/Square/Merchants/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">DeleteAsync</a>(DeleteCustomAttributeDefinitionsRequest { ... }) -> DeleteMerchantCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a merchant-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.
Deleting a custom attribute definition also deletes the corresponding custom attribute from
the merchant.
Only the definition owner can delete a custom attribute definition.
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
await client.Merchants.CustomAttributeDefinitions.DeleteAsync(
    new DeleteCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `DeleteCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Merchants CustomAttributes
<details><summary><code>client.Merchants.CustomAttributes.<a href="/src/Square/Merchants/CustomAttributes/CustomAttributesClient.cs">BatchDeleteAsync</a>(BulkDeleteMerchantCustomAttributesRequest { ... }) -> BulkDeleteMerchantCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes [custom attributes](entity:CustomAttribute) for a merchant as a bulk operation.
To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributes.BatchDeleteAsync(
    new BulkDeleteMerchantCustomAttributesRequest
    {
        Values = new Dictionary<
            string,
            BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
        >()
        {
            {
                "id1",
                new BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
                {
                    Key = "alternative_seller_name",
                }
            },
            {
                "id2",
                new BulkDeleteMerchantCustomAttributesRequestMerchantCustomAttributeDeleteRequest
                {
                    Key = "has_seen_tutorial",
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

**request:** `BulkDeleteMerchantCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributes.<a href="/src/Square/Merchants/CustomAttributes/CustomAttributesClient.cs">BatchUpsertAsync</a>(BulkUpsertMerchantCustomAttributesRequest { ... }) -> BulkUpsertMerchantCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates [custom attributes](entity:CustomAttribute) for a merchant as a bulk operation.
Use this endpoint to set the value of one or more custom attributes for a merchant.
A custom attribute is based on a custom attribute definition in a Square seller account, which is
created using the [CreateMerchantCustomAttributeDefinition](api-endpoint:MerchantCustomAttributes-CreateMerchantCustomAttributeDefinition) endpoint.
This `BulkUpsertMerchantCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
requests and returns a map of individual upsert responses. Each upsert request has a unique ID
and provides a merchant ID and custom attribute. Each upsert response is returned with the ID
of the corresponding request.
To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributes.BatchUpsertAsync(
    new BulkUpsertMerchantCustomAttributesRequest
    {
        Values = new Dictionary<
            string,
            BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
        >()
        {
            {
                "id1",
                new BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
                {
                    MerchantId = "DM7VKY8Q63GNP",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "alternative_seller_name",
                        Value = "Ultimate Sneaker Store",
                    },
                }
            },
            {
                "id2",
                new BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
                {
                    MerchantId = "DM7VKY8Q63GNP",
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "has_seen_tutorial",
                        Value = true,
                    },
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

**request:** `BulkUpsertMerchantCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributes.<a href="/src/Square/Merchants/CustomAttributes/CustomAttributesClient.cs">ListAsync</a>(ListCustomAttributesRequest { ... }) -> Pager<CustomAttribute></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the [custom attributes](entity:CustomAttribute) associated with a merchant.
You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
in the same call.
When all response pages are retrieved, the results include all custom attributes that are
visible to the requesting application, including those that are owned by other applications
and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributes.ListAsync(
    new ListCustomAttributesRequest { MerchantId = "merchant_id" }
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

**request:** `ListCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributes.<a href="/src/Square/Merchants/CustomAttributes/CustomAttributesClient.cs">GetAsync</a>(GetCustomAttributesRequest { ... }) -> RetrieveMerchantCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a [custom attribute](entity:CustomAttribute) associated with a merchant.
You can use the `with_definition` query parameter to also retrieve the custom attribute definition
in the same call.
To retrieve a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributes.GetAsync(
    new GetCustomAttributesRequest { MerchantId = "merchant_id", Key = "key" }
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

**request:** `GetCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributes.<a href="/src/Square/Merchants/CustomAttributes/CustomAttributesClient.cs">UpsertAsync</a>(UpsertMerchantCustomAttributeRequest { ... }) -> UpsertMerchantCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates a [custom attribute](entity:CustomAttribute) for a merchant.
Use this endpoint to set the value of a custom attribute for a specified merchant.
A custom attribute is based on a custom attribute definition in a Square seller account, which
is created using the [CreateMerchantCustomAttributeDefinition](api-endpoint:MerchantCustomAttributes-CreateMerchantCustomAttributeDefinition) endpoint.
To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributes.UpsertAsync(
    new UpsertMerchantCustomAttributeRequest
    {
        MerchantId = "merchant_id",
        Key = "key",
        CustomAttribute = new CustomAttribute { Value = "Ultimate Sneaker Store" },
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

**request:** `UpsertMerchantCustomAttributeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Merchants.CustomAttributes.<a href="/src/Square/Merchants/CustomAttributes/CustomAttributesClient.cs">DeleteAsync</a>(DeleteCustomAttributesRequest { ... }) -> DeleteMerchantCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a [custom attribute](entity:CustomAttribute) associated with a merchant.
To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`.
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
await client.Merchants.CustomAttributes.DeleteAsync(
    new DeleteCustomAttributesRequest { MerchantId = "merchant_id", Key = "key" }
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

**request:** `DeleteCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Orders CustomAttributeDefinitions
<details><summary><code>client.Orders.CustomAttributeDefinitions.<a href="/src/Square/Orders/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">ListAsync</a>(ListCustomAttributeDefinitionsRequest { ... }) -> Pager<CustomAttributeDefinition></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the order-related [custom attribute definitions](entity:CustomAttributeDefinition) that belong to a Square seller account.

When all response pages are retrieved, the results include all custom attribute definitions
that are visible to the requesting application, including those that are created by other
applications and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that
seller-defined custom attributes (also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributeDefinitions.ListAsync(
    new ListCustomAttributeDefinitionsRequest()
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

**request:** `ListCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributeDefinitions.<a href="/src/Square/Orders/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">CreateAsync</a>(CreateOrderCustomAttributeDefinitionRequest { ... }) -> CreateOrderCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates an order-related custom attribute definition.  Use this endpoint to
define a custom attribute that can be associated with orders.

After creating a custom attribute definition, you can set the custom attribute for orders
in the Square seller account.
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
await client.Orders.CustomAttributeDefinitions.CreateAsync(
    new CreateOrderCustomAttributeDefinitionRequest
    {
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Key = "cover-count",
            Schema = new Dictionary<string, object>()
            {
                {
                    "ref",
                    "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.Number"
                },
            },
            Name = "Cover count",
            Description = "The number of people seated at a table",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityReadWriteValues,
        },
        IdempotencyKey = "IDEMPOTENCY_KEY",
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

**request:** `CreateOrderCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributeDefinitions.<a href="/src/Square/Orders/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">GetAsync</a>(GetCustomAttributeDefinitionsRequest { ... }) -> RetrieveOrderCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves an order-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.

To retrieve a custom attribute definition created by another application, the `visibility`
setting must be `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributeDefinitions.GetAsync(
    new GetCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `GetCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributeDefinitions.<a href="/src/Square/Orders/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">UpdateAsync</a>(UpdateOrderCustomAttributeDefinitionRequest { ... }) -> UpdateOrderCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates an order-related custom attribute definition for a Square seller account.

Only the definition owner can update a custom attribute definition. Note that sellers can view all custom attributes in exported customer data, including those set to `VISIBILITY_HIDDEN`.
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
await client.Orders.CustomAttributeDefinitions.UpdateAsync(
    new UpdateOrderCustomAttributeDefinitionRequest
    {
        Key = "key",
        CustomAttributeDefinition = new CustomAttributeDefinition
        {
            Key = "cover-count",
            Visibility = CustomAttributeDefinitionVisibility.VisibilityReadOnly,
            Version = 1,
        },
        IdempotencyKey = "IDEMPOTENCY_KEY",
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

**request:** `UpdateOrderCustomAttributeDefinitionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributeDefinitions.<a href="/src/Square/Orders/CustomAttributeDefinitions/CustomAttributeDefinitionsClient.cs">DeleteAsync</a>(DeleteCustomAttributeDefinitionsRequest { ... }) -> DeleteOrderCustomAttributeDefinitionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes an order-related [custom attribute definition](entity:CustomAttributeDefinition) from a Square seller account.

Only the definition owner can delete a custom attribute definition.
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
await client.Orders.CustomAttributeDefinitions.DeleteAsync(
    new DeleteCustomAttributeDefinitionsRequest { Key = "key" }
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

**request:** `DeleteCustomAttributeDefinitionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Orders CustomAttributes
<details><summary><code>client.Orders.CustomAttributes.<a href="/src/Square/Orders/CustomAttributes/CustomAttributesClient.cs">BatchDeleteAsync</a>(BulkDeleteOrderCustomAttributesRequest { ... }) -> BulkDeleteOrderCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes order [custom attributes](entity:CustomAttribute) as a bulk operation.

Use this endpoint to delete one or more custom attributes from one or more orders.
A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)

This `BulkDeleteOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual delete
requests and returns a map of individual delete responses. Each delete request has a unique ID
and provides an order ID and custom attribute. Each delete response is returned with the ID
of the corresponding request.

To delete a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributes.BatchDeleteAsync(
    new BulkDeleteOrderCustomAttributesRequest
    {
        Values = new Dictionary<
            string,
            BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
        >()
        {
            {
                "cover-count",
                new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
                {
                    Key = "cover-count",
                    OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
                }
            },
            {
                "table-number",
                new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
                {
                    Key = "table-number",
                    OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
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

**request:** `BulkDeleteOrderCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributes.<a href="/src/Square/Orders/CustomAttributes/CustomAttributesClient.cs">BatchUpsertAsync</a>(BulkUpsertOrderCustomAttributesRequest { ... }) -> BulkUpsertOrderCustomAttributesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates order [custom attributes](entity:CustomAttribute) as a bulk operation.

Use this endpoint to delete one or more custom attributes from one or more orders.
A custom attribute is based on a custom attribute definition in a Square seller account.  (To create a
custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)

This `BulkUpsertOrderCustomAttributes` endpoint accepts a map of 1 to 25 individual upsert
requests and returns a map of individual upsert responses. Each upsert request has a unique ID
and provides an order ID and custom attribute. Each upsert response is returned with the ID
of the corresponding request.

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributes.BatchUpsertAsync(
    new BulkUpsertOrderCustomAttributesRequest
    {
        Values = new Dictionary<
            string,
            BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
        >()
        {
            {
                "cover-count",
                new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
                {
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "cover-count",
                        Value = "6",
                        Version = 2,
                    },
                    OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
                }
            },
            {
                "table-number",
                new BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute
                {
                    CustomAttribute = new CustomAttribute
                    {
                        Key = "table-number",
                        Value = "11",
                        Version = 4,
                    },
                    OrderId = "7BbXGEIWNldxAzrtGf9GPVZTwZ4F",
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

**request:** `BulkUpsertOrderCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributes.<a href="/src/Square/Orders/CustomAttributes/CustomAttributesClient.cs">ListAsync</a>(ListCustomAttributesRequest { ... }) -> Pager<CustomAttribute></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists the [custom attributes](entity:CustomAttribute) associated with an order.

You can use the `with_definitions` query parameter to also retrieve custom attribute definitions
in the same call.

When all response pages are retrieved, the results include all custom attributes that are
visible to the requesting application, including those that are owned by other applications
and set to `VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributes.ListAsync(
    new ListCustomAttributesRequest { OrderId = "order_id" }
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

**request:** `ListCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributes.<a href="/src/Square/Orders/CustomAttributes/CustomAttributesClient.cs">GetAsync</a>(GetCustomAttributesRequest { ... }) -> RetrieveOrderCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a [custom attribute](entity:CustomAttribute) associated with an order.

You can use the `with_definition` query parameter to also retrieve the custom attribute definition
in the same call.

To retrieve a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_ONLY` or `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributes.GetAsync(
    new GetCustomAttributesRequest
    {
        OrderId = "order_id",
        CustomAttributeKey = "custom_attribute_key",
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

**request:** `GetCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributes.<a href="/src/Square/Orders/CustomAttributes/CustomAttributesClient.cs">UpsertAsync</a>(UpsertOrderCustomAttributeRequest { ... }) -> UpsertOrderCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates a [custom attribute](entity:CustomAttribute) for an order.

Use this endpoint to set the value of a custom attribute for a specific order.
A custom attribute is based on a custom attribute definition in a Square seller account. (To create a
custom attribute definition, use the [CreateOrderCustomAttributeDefinition](api-endpoint:OrderCustomAttributes-CreateOrderCustomAttributeDefinition) endpoint.)

To create or update a custom attribute owned by another application, the `visibility` setting
must be `VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributes.UpsertAsync(
    new UpsertOrderCustomAttributeRequest
    {
        OrderId = "order_id",
        CustomAttributeKey = "custom_attribute_key",
        CustomAttribute = new CustomAttribute
        {
            Key = "table-number",
            Value = "42",
            Version = 1,
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

**request:** `UpsertOrderCustomAttributeRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Orders.CustomAttributes.<a href="/src/Square/Orders/CustomAttributes/CustomAttributesClient.cs">DeleteAsync</a>(DeleteCustomAttributesRequest { ... }) -> DeleteOrderCustomAttributeResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a [custom attribute](entity:CustomAttribute) associated with a customer profile.

To delete a custom attribute owned by another application, the `visibility` setting must be
`VISIBILITY_READ_WRITE_VALUES`. Note that seller-defined custom attributes
(also known as custom fields) are always set to `VISIBILITY_READ_WRITE_VALUES`.
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
await client.Orders.CustomAttributes.DeleteAsync(
    new DeleteCustomAttributesRequest
    {
        OrderId = "order_id",
        CustomAttributeKey = "custom_attribute_key",
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

**request:** `DeleteCustomAttributesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## TeamMembers WageSetting
<details><summary><code>client.TeamMembers.WageSetting.<a href="/src/Square/TeamMembers/WageSetting/WageSettingClient.cs">GetAsync</a>(TeamMembers.WageSetting.GetWageSettingRequest { ... }) -> GetWageSettingResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a `WageSetting` object for a team member specified
by `TeamMember.id`. For more information, see
[Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).

Square recommends using [RetrieveTeamMember](api-endpoint:Team-RetrieveTeamMember) or [SearchTeamMembers](api-endpoint:Team-SearchTeamMembers)
to get this information directly from the `TeamMember.wage_setting` field.
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
await client.TeamMembers.WageSetting.GetAsync(
    new Square.TeamMembers.WageSetting.GetWageSettingRequest { TeamMemberId = "team_member_id" }
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

**request:** `TeamMembers.WageSetting.GetWageSettingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TeamMembers.WageSetting.<a href="/src/Square/TeamMembers/WageSetting/WageSettingClient.cs">UpdateAsync</a>(UpdateWageSettingRequest { ... }) -> UpdateWageSettingResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates or updates a `WageSetting` object. The object is created if a
`WageSetting` with the specified `team_member_id` doesn't exist. Otherwise,
it fully replaces the `WageSetting` object for the team member.
The `WageSetting` is returned on a successful update. For more information, see
[Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).

Square recommends using [CreateTeamMember](api-endpoint:Team-CreateTeamMember) or [UpdateTeamMember](api-endpoint:Team-UpdateTeamMember)
to manage the `TeamMember.wage_setting` field directly.
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
await client.TeamMembers.WageSetting.UpdateAsync(
    new UpdateWageSettingRequest
    {
        TeamMemberId = "team_member_id",
        WageSetting = new Square.WageSetting
        {
            JobAssignments = new List<JobAssignment>()
            {
                new JobAssignment
                {
                    JobTitle = "Manager",
                    PayType = JobAssignmentPayType.Salary,
                    AnnualRate = new Money { Amount = 3000000, Currency = Currency.Usd },
                    WeeklyHours = 40,
                },
                new JobAssignment
                {
                    JobTitle = "Cashier",
                    PayType = JobAssignmentPayType.Hourly,
                    HourlyRate = new Money { Amount = 2000, Currency = Currency.Usd },
                },
            },
            IsOvertimeExempt = true,
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

**request:** `UpdateWageSettingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Terminal Actions
<details><summary><code>client.Terminal.Actions.<a href="/src/Square/Terminal/Actions/ActionsClient.cs">CreateAsync</a>(CreateTerminalActionRequest { ... }) -> CreateTerminalActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a Terminal action request and sends it to the specified device.
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
await client.Terminal.Actions.CreateAsync(
    new CreateTerminalActionRequest
    {
        IdempotencyKey = "thahn-70e75c10-47f7-4ab6-88cc-aaa4076d065e",
        Action = new TerminalAction
        {
            DeviceId = "{{DEVICE_ID}}",
            DeadlineDuration = "PT5M",
            Type = TerminalActionActionType.SaveCard,
            SaveCardOptions = new SaveCardOptions
            {
                CustomerId = "{{CUSTOMER_ID}}",
                ReferenceId = "user-id-1",
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

**request:** `CreateTerminalActionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Actions.<a href="/src/Square/Terminal/Actions/ActionsClient.cs">SearchAsync</a>(SearchTerminalActionsRequest { ... }) -> SearchTerminalActionsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.
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
await client.Terminal.Actions.SearchAsync(
    new SearchTerminalActionsRequest
    {
        Query = new TerminalActionQuery
        {
            Filter = new TerminalActionQueryFilter
            {
                CreatedAt = new TimeRange { StartAt = "2022-04-01T00:00:00.000Z" },
            },
            Sort = new TerminalActionQuerySort { SortOrder = SortOrder.Desc },
        },
        Limit = 2,
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

**request:** `SearchTerminalActionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Actions.<a href="/src/Square/Terminal/Actions/ActionsClient.cs">GetAsync</a>(GetActionsRequest { ... }) -> GetTerminalActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.
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
await client.Terminal.Actions.GetAsync(new GetActionsRequest { ActionId = "action_id" });
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

**request:** `GetActionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Actions.<a href="/src/Square/Terminal/Actions/ActionsClient.cs">CancelAsync</a>(CancelActionsRequest { ... }) -> CancelTerminalActionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels a Terminal action request if the status of the request permits it.
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
await client.Terminal.Actions.CancelAsync(new CancelActionsRequest { ActionId = "action_id" });
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

**request:** `CancelActionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Terminal Checkouts
<details><summary><code>client.Terminal.Checkouts.<a href="/src/Square/Terminal/Checkouts/CheckoutsClient.cs">CreateAsync</a>(CreateTerminalCheckoutRequest { ... }) -> CreateTerminalCheckoutResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a Terminal checkout request and sends it to the specified device to take a payment
for the requested amount.
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
await client.Terminal.Checkouts.CreateAsync(
    new CreateTerminalCheckoutRequest
    {
        IdempotencyKey = "28a0c3bc-7839-11ea-bc55-0242ac130003",
        Checkout = new TerminalCheckout
        {
            AmountMoney = new Money { Amount = 2610, Currency = Currency.Usd },
            ReferenceId = "id11572",
            Note = "A brief note",
            DeviceOptions = new DeviceCheckoutOptions
            {
                DeviceId = "dbb5d83a-7838-11ea-bc55-0242ac130003",
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

**request:** `CreateTerminalCheckoutRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Checkouts.<a href="/src/Square/Terminal/Checkouts/CheckoutsClient.cs">SearchAsync</a>(SearchTerminalCheckoutsRequest { ... }) -> SearchTerminalCheckoutsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.
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
await client.Terminal.Checkouts.SearchAsync(
    new SearchTerminalCheckoutsRequest
    {
        Query = new TerminalCheckoutQuery
        {
            Filter = new TerminalCheckoutQueryFilter { Status = "COMPLETED" },
        },
        Limit = 2,
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

**request:** `SearchTerminalCheckoutsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Checkouts.<a href="/src/Square/Terminal/Checkouts/CheckoutsClient.cs">GetAsync</a>(GetCheckoutsRequest { ... }) -> GetTerminalCheckoutResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.
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
await client.Terminal.Checkouts.GetAsync(new GetCheckoutsRequest { CheckoutId = "checkout_id" });
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

**request:** `GetCheckoutsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Checkouts.<a href="/src/Square/Terminal/Checkouts/CheckoutsClient.cs">CancelAsync</a>(CancelCheckoutsRequest { ... }) -> CancelTerminalCheckoutResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels a Terminal checkout request if the status of the request permits it.
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
await client.Terminal.Checkouts.CancelAsync(
    new CancelCheckoutsRequest { CheckoutId = "checkout_id" }
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

**request:** `CancelCheckoutsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Terminal Refunds
<details><summary><code>client.Terminal.Refunds.<a href="/src/Square/Terminal/Refunds/RefundsClient.cs">CreateAsync</a>(CreateTerminalRefundRequest { ... }) -> CreateTerminalRefundResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API](api:Refunds).
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
await client.Terminal.Refunds.CreateAsync(
    new CreateTerminalRefundRequest
    {
        IdempotencyKey = "402a640b-b26f-401f-b406-46f839590c04",
        Refund = new TerminalRefund
        {
            PaymentId = "5O5OvgkcNUhl7JBuINflcjKqUzXZY",
            AmountMoney = new Money { Amount = 111, Currency = Currency.Cad },
            Reason = "Returning items",
            DeviceId = "f72dfb8e-4d65-4e56-aade-ec3fb8d33291",
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

**request:** `CreateTerminalRefundRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Refunds.<a href="/src/Square/Terminal/Refunds/RefundsClient.cs">SearchAsync</a>(SearchTerminalRefundsRequest { ... }) -> SearchTerminalRefundsResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.
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
await client.Terminal.Refunds.SearchAsync(
    new SearchTerminalRefundsRequest
    {
        Query = new TerminalRefundQuery
        {
            Filter = new TerminalRefundQueryFilter { Status = "COMPLETED" },
        },
        Limit = 1,
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

**request:** `SearchTerminalRefundsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Refunds.<a href="/src/Square/Terminal/Refunds/RefundsClient.cs">GetAsync</a>(GetRefundsRequest { ... }) -> GetTerminalRefundResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.
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
await client.Terminal.Refunds.GetAsync(
    new GetRefundsRequest { TerminalRefundId = "terminal_refund_id" }
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

**request:** `GetRefundsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Terminal.Refunds.<a href="/src/Square/Terminal/Refunds/RefundsClient.cs">CancelAsync</a>(CancelRefundsRequest { ... }) -> CancelTerminalRefundResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
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
await client.Terminal.Refunds.CancelAsync(
    new CancelRefundsRequest { TerminalRefundId = "terminal_refund_id" }
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

**request:** `CancelRefundsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Webhooks EventTypes
<details><summary><code>client.Webhooks.EventTypes.<a href="/src/Square/Webhooks/EventTypes/EventTypesClient.cs">ListAsync</a>(ListEventTypesRequest { ... }) -> ListWebhookEventTypesResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all webhook event types that can be subscribed to.
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
await client.Webhooks.EventTypes.ListAsync(new ListEventTypesRequest());
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

**request:** `ListEventTypesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Webhooks Subscriptions
<details><summary><code>client.Webhooks.Subscriptions.<a href="/src/Square/Webhooks/Subscriptions/SubscriptionsClient.cs">ListAsync</a>(ListSubscriptionsRequest { ... }) -> Pager<WebhookSubscription></code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all webhook subscriptions owned by your application.
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
await client.Webhooks.Subscriptions.ListAsync(new ListSubscriptionsRequest());
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

**request:** `ListSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.Subscriptions.<a href="/src/Square/Webhooks/Subscriptions/SubscriptionsClient.cs">CreateAsync</a>(CreateWebhookSubscriptionRequest { ... }) -> CreateWebhookSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a webhook subscription.
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
await client.Webhooks.Subscriptions.CreateAsync(
    new CreateWebhookSubscriptionRequest
    {
        IdempotencyKey = "63f84c6c-2200-4c99-846c-2670a1311fbf",
        Subscription = new WebhookSubscription
        {
            Name = "Example Webhook Subscription",
            EventTypes = new List<string>() { "payment.created", "payment.updated" },
            NotificationUrl = "https://example-webhook-url.com",
            ApiVersion = "2021-12-15",
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

**request:** `CreateWebhookSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.Subscriptions.<a href="/src/Square/Webhooks/Subscriptions/SubscriptionsClient.cs">GetAsync</a>(GetSubscriptionsRequest { ... }) -> GetWebhookSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a webhook subscription identified by its ID.
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
await client.Webhooks.Subscriptions.GetAsync(
    new GetSubscriptionsRequest { SubscriptionId = "subscription_id" }
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

**request:** `GetSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.Subscriptions.<a href="/src/Square/Webhooks/Subscriptions/SubscriptionsClient.cs">UpdateAsync</a>(UpdateWebhookSubscriptionRequest { ... }) -> UpdateWebhookSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a webhook subscription.
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
await client.Webhooks.Subscriptions.UpdateAsync(
    new UpdateWebhookSubscriptionRequest
    {
        SubscriptionId = "subscription_id",
        Subscription = new WebhookSubscription
        {
            Name = "Updated Example Webhook Subscription",
            Enabled = false,
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

**request:** `UpdateWebhookSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.Subscriptions.<a href="/src/Square/Webhooks/Subscriptions/SubscriptionsClient.cs">DeleteAsync</a>(DeleteSubscriptionsRequest { ... }) -> DeleteWebhookSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a webhook subscription.
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
await client.Webhooks.Subscriptions.DeleteAsync(
    new DeleteSubscriptionsRequest { SubscriptionId = "subscription_id" }
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

**request:** `DeleteSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.Subscriptions.<a href="/src/Square/Webhooks/Subscriptions/SubscriptionsClient.cs">UpdateSignatureKeyAsync</a>(UpdateWebhookSubscriptionSignatureKeyRequest { ... }) -> UpdateWebhookSubscriptionSignatureKeyResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a webhook subscription by replacing the existing signature key with a new one.
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
await client.Webhooks.Subscriptions.UpdateSignatureKeyAsync(
    new UpdateWebhookSubscriptionSignatureKeyRequest
    {
        SubscriptionId = "subscription_id",
        IdempotencyKey = "ed80ae6b-0654-473b-bbab-a39aee89a60d",
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

**request:** `UpdateWebhookSubscriptionSignatureKeyRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.Subscriptions.<a href="/src/Square/Webhooks/Subscriptions/SubscriptionsClient.cs">TestAsync</a>(TestWebhookSubscriptionRequest { ... }) -> TestWebhookSubscriptionResponse</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Tests a webhook subscription by sending a test event to the notification URL.
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
await client.Webhooks.Subscriptions.TestAsync(
    new TestWebhookSubscriptionRequest
    {
        SubscriptionId = "subscription_id",
        EventType = "payment.created",
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

**request:** `TestWebhookSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>
