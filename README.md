# Square C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=https%3A%2F%2Fgithub.com%2Ffern-demo%2Fsquare-dotnet-sdk)
[![nuget shield](https://img.shields.io/nuget/v/Square)](https://nuget.org/packages/Square)

The Square .NET library provides convenient access to the Square API from C#, VB.NET, and F#.

## Requirements

The Square .NET SDK is supported with the following target frameworks:
* .NET 8 and above
* .NET Framework 4.6.2 and above
* .NET Standard 2.0 and above

## Installation

```sh
dotnet add package Square
```

## Usage

Instantiate and use the client with the following:

```csharp
using Square.Payments;
using Square;

var client = new SquareClient();
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

## Instantiation

To get started with the Square SDK, instantiate the `SquareClient` class as follows:

```csharp
using Square;

var client = new SquareClient("SQUARE_TOKEN");
```

Alternatively, you can omit the token when constructing the client.
In this case, the SDK will automatically read the token from the
`SQUARE_TOKEN` environment variable:

```csharp
using Square;

var client = new SquareClient(); // Token is read from the SQUARE_TOKEN environment variable.
```

### Environment and Custom URLs

This SDK allows you to configure different environments or custom URLs for API requests.
You can either use the predefined environments or specify your own custom URL.

#### Environments

```csharp
using Square;

var client = new SquareClient(clientOptions: new ClientOptions
{
    BaseUrl = SquareEnvironment.Production // Used by default
});
```

#### Custom URL

```csharp
using Square;

var client = new SquareClient(clientOptions: new ClientOptions
{
    BaseUrl = "https://custom-staging.com"
});
```

## Enums

This SDK uses forward-compatible enums that provide type safety while maintaining forward compatibility with API updates.

```csharp
// Use predefined enum values
var accountType = BankAccountType.Checking;

// Use unknown/future enum values
var customType = BankAccountType.FromCustom("FUTURE_VALUE");

// String conversions and equality
string typeString = accountType.ToString();  // Returns "CHECKING"
var isChecking = accountType == "CHECKING"; // Returns true

// When writing switch statements, always include a default case
switch (accountType.Value) {
    case BankAccountType.Values.Checking:
        // Handle checking accounts
        break;
    case BankAccountType.Values.BusinessChecking:
        // Handle business checking accounts
        break;
    default:
        // Handle unknown values for forward compatibility
        break;
}
```

## Pagination

List endpoints are paginated. The SDK provides an async enumerable so that you can simply loop over the items:

```csharp
using Square.BankAccounts;
using Square;

var client = new SquareClient();
var pager = await client.BankAccounts.ListAsync(new ListBankAccountsRequest());

await foreach (var item in pager)
{
    // do something with item
}
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a `SquareApiException` will be thrown.

```csharp
using Square;

try {
    var response = await client.Payments.CreateAsync(...);
} catch (SquareApiException e) {
    Console.WriteLine(e.Body);
    Console.WriteLine(e.StatusCode);

    // Access the parsed error objects
    foreach (var error in e.Errors) {
        Console.WriteLine($"Category: {error.Category}");
        Console.WriteLine($"Code: {error.Code}");
        Console.WriteLine($"Detail: {error.Detail}");
        Console.WriteLine($"Field: {error.Field}");
    }
}
```

## Webhook Signature Verification

The SDK provides utility methods that allow you to verify webhook signatures and ensure
that all webhook events originate from Square. The `WebhooksHelper.verifySignature` method
can be used to verify the signature like so:

```csharp
using Microsoft.AspNetCore.Http;
using Square;

public static async Task CheckWebhooksEvent(
    HttpRequest request,
    string signatureKey,
    string notificationUrl
)
{
    var signature = request.Headers["x-square-hmacsha256-signature"].ToString();
    using var reader = new StreamReader(request.Body, System.Text.Encoding.UTF8);
    var requestBody = await reader.ReadToEndAsync();
    if (!WebhooksHelper.VerifySignature(requestBody, signature, signatureKey, notificationUrl))
    {
        throw new Exception("A webhook event was received that was not from Square.");
    }
}
```

In .NET 6 and above, there are also overloads using spans for allocation free webhook verification.

## Legacy SDK

While the new SDK has a lot of improvements, we at Square understand that it takes time to upgrade when there are breaking changes.
To make the migration easier, the legacy SDK is available as a separate NuGet package `Square.Legacy` with all functionality under the `Square.Legacy` namespace. Here's an example of how you can use the legacy SDK alongside the new SDK inside a single file:

```csharp
using Square;
using Square.Legacy.Authentication;

var accessToken = "YOUR_SQUARE_TOKEN";
// NEW
var client = new SquareClient(accessToken);
// LEGACY
var legacyClient = new Square.Legacy.SquareClient.Builder()
    .BearerAuthCredentials(
        new BearerAuthModel.Builder(accessToken)
            .Build())
    .Environment(Square.Legacy.Environment.Production)
    .Build();
```

We recommend migrating to the new SDK using the following steps:

1. Install the `Square.Legacy` NuGet package alongside your existing Square SDK
2. Search and replace all using statements from `Square` to `Square.Legacy`
3. Gradually move over to use the new SDK by importing it from the `Square` namespace.

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

A request is deemed retryable when any of the following HTTP status codes is returned:

- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500) (Internal Server Errors)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.Payments.CreateAsync(
    ...,
    new RequestOptions {
        MaxRetries: 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.Payments.CreateAsync(
    ...,
    new RequestOptions {
        Timeout: TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

### Receive Additional Properties

Every response type includes the `AdditionalProperties` property, which returns an `IDictionary<string, JsonElement>` that contains any properties in the JSON response that were not specified in the returned class. Similar to the use case for sending additional parameters, this can be useful for API features not present in the SDK yet.

You can access the additional properties like so:

```csharp
var payments = client.Payments.Create(...);
IDictionary<string, JsonElement> additionalProperties = payments.AdditionalProperties;
```

The `AdditionalProperties` dictionary is populated automatically during deserialization using the `[JsonExtensionData]` attribute. This provides you with access to any fields that may be added to the API response in the future before they're formally added to the SDK models.

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!
