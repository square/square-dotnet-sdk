# Apple Pay

```csharp
IApplePayApi applePayApi = client.ApplePayApi;
```

## Class Name

`ApplePayApi`

## Register Domain

Activates a domain for use with Web Apple Pay and Square. A validation
will be performed on this domain by Apple to ensure is it properly set up as
an Apple Pay enabled domain.

This endpoint provides an easy way for platform developers to bulk activate
Web Apple Pay with Square for merchants using their platform.

To learn more about Apple Pay on Web see the Apple Pay section in the
[Square Payment Form Walkthrough](https://developer.squareup.com/docs/docs/payment-form/payment-form-walkthrough).

```csharp
RegisterDomainAsync(Models.RegisterDomainRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.RegisterDomainRequest`](/doc/models/register-domain-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.RegisterDomainResponse>`](/doc/models/register-domain-response.md)

### Example Usage

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

