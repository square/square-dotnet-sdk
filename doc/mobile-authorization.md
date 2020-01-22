# Mobile Authorization

```csharp
IMobileAuthorizationApi mobileAuthorizationApi = client.MobileAuthorizationApi;
```

## Class Name

`MobileAuthorizationApi`

## Create Mobile Authorization Code

Generates code to authorize a mobile application to connect to a Square card reader

Authorization codes are one-time-use and expire __60 minutes__ after being issued.

__Important:__ The `Authorization` header you provide to this endpoint must have the following format:

```
Authorization: Bearer ACCESS_TOKEN
```

Replace `ACCESS_TOKEN` with a
[valid production authorization credential](https://developer.squareup.com/docs/docs/build-basics/access-tokens).

```csharp
CreateMobileAuthorizationCodeAsync(Models.CreateMobileAuthorizationCodeRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.CreateMobileAuthorizationCodeRequest`](/doc/models/create-mobile-authorization-code-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateMobileAuthorizationCodeResponse>`](/doc/models/create-mobile-authorization-code-response.md)

### Example Usage

```csharp
var body = new CreateMobileAuthorizationCodeRequest.Builder()
    .LocationId("YOUR_LOCATION_ID")
    .Build();

try
{
    CreateMobileAuthorizationCodeResponse result = await mobileAuthorizationApi.CreateMobileAuthorizationCodeAsync(body);
}
catch (ApiException e){};
```

