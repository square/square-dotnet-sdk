# Apple Pay

```csharp
IApplePayApi applePayApi = client.ApplePayApi;
```

## Class Name

`ApplePayApi`


# Register Domain

Activates a domain for use with Apple Pay on the Web and Square. A validation
is performed on this domain by Apple to ensure that it is properly set up as
an Apple Pay enabled domain.

This endpoint provides an easy way for platform developers to bulk activate
Apple Pay on the Web with Square for merchants using their platform.

To learn more about Web Apple Pay, see
[Add the Apple Pay on the Web Button](https://developer.squareup.com/docs/payment-form/add-digital-wallets/apple-pay).

```csharp
RegisterDomainAsync(Models.RegisterDomainRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.RegisterDomainRequest`](/doc/models/register-domain-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.RegisterDomainResponse>`](/doc/models/register-domain-response.md)

## Example Usage

```csharp
var body = new RegisterDomainRequest.Builder(
        "example.com")
    .Build();

try
{
    RegisterDomainResponse result = await applePayApi.RegisterDomainAsync(body);
}
catch (ApiException e){};
```

