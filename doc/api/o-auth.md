# O Auth

```csharp
IOAuthApi oAuthApi = client.OAuthApi;
```

## Class Name

`OAuthApi`

## Methods

* [Revoke Token](../../doc/api/o-auth.md#revoke-token)
* [Obtain Token](../../doc/api/o-auth.md#obtain-token)
* [Retrieve Token Status](../../doc/api/o-auth.md#retrieve-token-status)


# Revoke Token

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

:information_source: **Note** This endpoint does not require authentication.

```csharp
RevokeTokenAsync(
    Models.RevokeTokenRequest body,
    string authorization)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`RevokeTokenRequest`](../../doc/models/revoke-token-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |
| `authorization` | `string` | Header, Required | Client APPLICATION_SECRET |

## Response Type

[`Task<Models.RevokeTokenResponse>`](../../doc/models/revoke-token-response.md)

## Example Usage

```csharp
Models.RevokeTokenRequest body = new Models.RevokeTokenRequest.Builder()
.ClientId("CLIENT_ID")
.AccessToken("ACCESS_TOKEN")
.Build();

string authorization = "Client CLIENT_SECRET";
try
{
    RevokeTokenResponse result = await oAuthApi.RevokeTokenAsync(
        body,
        authorization
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Obtain Token

Returns an OAuth access token and a refresh token unless the
`short_lived` parameter is set to `true`, in which case the endpoint
returns only an access token.

The `grant_type` parameter specifies the type of OAuth request. If
`grant_type` is `authorization_code`, you must include the authorization
code you received when a seller granted you authorization. If `grant_type`
is `refresh_token`, you must provide a valid refresh token. If you're using
an old version of the Square APIs (prior to March 13, 2019), `grant_type`
can be `migration_token` and you must provide a valid migration token.

You can use the `scopes` parameter to limit the set of permissions granted
to the access token and refresh token. You can use the `short_lived` parameter
to create an access token that expires in 24 hours.

__Note:__ OAuth tokens should be encrypted and stored on a secure server.
Application clients should never interact directly with OAuth tokens.

:information_source: **Note** This endpoint does not require authentication.

```csharp
ObtainTokenAsync(
    Models.ObtainTokenRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`ObtainTokenRequest`](../../doc/models/obtain-token-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.ObtainTokenResponse>`](../../doc/models/obtain-token-response.md)

## Example Usage

```csharp
Models.ObtainTokenRequest body = new Models.ObtainTokenRequest.Builder(
    "APPLICATION_ID",
    "authorization_code"
)
.ClientSecret("APPLICATION_SECRET")
.Code("CODE_FROM_AUTHORIZE")
.Build();

try
{
    ObtainTokenResponse result = await oAuthApi.ObtainTokenAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Token Status

Returns information about an [OAuth access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-an-oauth-access-token) or an application’s [personal access token](https://developer.squareup.com/docs/build-basics/access-tokens#get-a-personal-access-token).

Add the access token to the Authorization header of the request.

__Important:__ The `Authorization` header you provide to this endpoint must have the following format:

```
Authorization: Bearer ACCESS_TOKEN
```

where `ACCESS_TOKEN` is a
[valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).

If the access token is expired or not a valid access token, the endpoint returns an `UNAUTHORIZED` error.

```csharp
RetrieveTokenStatusAsync()
```

## Response Type

[`Task<Models.RetrieveTokenStatusResponse>`](../../doc/models/retrieve-token-status-response.md)

## Example Usage

```csharp
try
{
    RetrieveTokenStatusResponse result = await oAuthApi.RetrieveTokenStatusAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

