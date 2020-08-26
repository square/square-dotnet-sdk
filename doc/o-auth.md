# O Auth

```csharp
IOAuthApi oAuthApi = client.OAuthApi;
```

## Class Name

`OAuthApi`

## Methods

* [Renew Token](/doc/o-auth.md#renew-token)
* [Revoke Token](/doc/o-auth.md#revoke-token)
* [Obtain Token](/doc/o-auth.md#obtain-token)

## Renew Token

`RenewToken` is deprecated. For information about refreshing OAuth access tokens, see
[Renew OAuth Token](https://developer.squareup.com/docs/oauth-api/cookbook/renew-oauth-tokens).


Renews an OAuth access token before it expires.

OAuth access tokens besides your application's personal access token expire after __30 days__.
You can also renew expired tokens within __15 days__ of their expiration.
You cannot renew an access token that has been expired for more than 15 days.
Instead, the associated user must re-complete the OAuth flow from the beginning.

__Important:__ The `Authorization` header for this endpoint must have the
following format:

```
Authorization: Client APPLICATION_SECRET
```

Replace `APPLICATION_SECRET` with the application secret on the Credentials
page in the [application dashboard](https://connect.squareup.com/apps).

:information_source: **Note** This endpoint does not require authentication.

```csharp
RenewTokenAsync(string clientId, Models.RenewTokenRequest body, string authorization)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `clientId` | `string` | Template, Required | Your application ID, available from the [application dashboard](https://connect.squareup.com/apps). |
| `body` | [`Models.RenewTokenRequest`](/doc/models/renew-token-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |
| `authorization` | `string` | Header, Required | Client APPLICATION_SECRET |

### Response Type

[`Task<Models.RenewTokenResponse>`](/doc/models/renew-token-response.md)

### Example Usage

```csharp
string clientId = "client_id8";
var body = new RenewTokenRequest.Builder()
    .AccessToken("ACCESS_TOKEN")
    .Build();
string authorization = "Client CLIENT_SECRET";

try
{
    RenewTokenResponse result = await oAuthApi.RenewTokenAsync(clientId, body, authorization);
}
catch (ApiException e){};
```

## Revoke Token

Revokes an access token generated with the OAuth flow.

If an account has more than one OAuth access token for your application, this
endpoint revokes all of them, regardless of which token you specify. When an
OAuth access token is revoked, all of the active subscriptions associated
with that OAuth token are canceled immediately.

__Important:__ The `Authorization` header for this endpoint must have the
following format:

```
Authorization: Client APPLICATION_SECRET
```

Replace `APPLICATION_SECRET` with the application secret on the Credentials
page in the [application dashboard](https://connect.squareup.com/apps).

:information_source: **Note** This endpoint does not require authentication.

```csharp
RevokeTokenAsync(Models.RevokeTokenRequest body, string authorization)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.RevokeTokenRequest`](/doc/models/revoke-token-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |
| `authorization` | `string` | Header, Required | Client APPLICATION_SECRET |

### Response Type

[`Task<Models.RevokeTokenResponse>`](/doc/models/revoke-token-response.md)

### Example Usage

```csharp
var body = new RevokeTokenRequest.Builder()
    .ClientId("CLIENT_ID")
    .AccessToken("ACCESS_TOKEN")
    .MerchantId("merchant_id6")
    .RevokeOnlyAccessToken(false)
    .Build();
string authorization = "Client CLIENT_SECRET";

try
{
    RevokeTokenResponse result = await oAuthApi.RevokeTokenAsync(body, authorization);
}
catch (ApiException e){};
```

## Obtain Token

Returns an OAuth access token.

The endpoint supports distinct methods of obtaining OAuth access tokens.
Applications specify a method by adding the `grant_type` parameter
in the request and also provide relevant information.
For more information, see [OAuth access token management](https://developer.squareup.com/docs/authz/oauth/how-it-works#oauth-access-token-management).

__Note:__ Regardless of the method application specified,
the endpoint always returns two items; an OAuth access token and
a refresh token in the response.

__OAuth tokens should only live on secure servers. Application clients
should never interact directly with OAuth tokens__.

:information_source: **Note** This endpoint does not require authentication.

```csharp
ObtainTokenAsync(Models.ObtainTokenRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.ObtainTokenRequest`](/doc/models/obtain-token-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.ObtainTokenResponse>`](/doc/models/obtain-token-response.md)

### Example Usage

```csharp
var body = new ObtainTokenRequest.Builder(
        "APPLICATION_ID",
        "APPLICATION_SECRET",
        "authorization_code")
    .Code("CODE_FROM_AUTHORIZE")
    .RedirectUri("redirect_uri4")
    .RefreshToken("refresh_token6")
    .MigrationToken("migration_token4")
    .Build();

try
{
    ObtainTokenResponse result = await oAuthApi.ObtainTokenAsync(body);
}
catch (ApiException e){};
```

