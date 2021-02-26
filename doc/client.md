
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `SquareVersion` | `string` | Square Connect API versions<br>*Default*: `"2021-02-26"` |
| `CustomUrl` | `string` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com`<br>*Default*: `"https://connect.squareup.com"` |
| `Environment` | `string` | The API environment. <br> **Default: `production`** |
| `Timeout` | `TimeSpan` | Http client timeout<br>*Default*: `TimeSpan.FromSeconds(60)` |
| `AccessToken` | `string` | The OAuth 2.0 Access Token to use for API requests. |

The API client can be initialized as follows:

```csharp
Square.SquareClient client = new Square.SquareClient.Builder()
    .AccessToken("AccessToken")
    .SquareVersion(GetEnvironmentVariable("2021-02-26"))
    .Environment(Environment.Production)
    .CustomUrl("https://connect.squareup.com")
    .Build();
```

## Make Calls with the API Client

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

using Square;
using Square.Models;
using Square.Apis;
using Square.Utilities;
using Square.Exceptions;

namespace Testing
{
    class Program
    {
        static async void Main(string[] args)
        {
            SquareClient client = new SquareClient.Builder()
                .AccessToken("AccessToken")
                .SquareVersion(GetEnvironmentVariable("2021-02-26"))
                .Build();
            ILocationsApi locationsApi = client.LocationsApi;
            
            try
            {
                ListLocationsResponse result = await locationsApi.ListLocationsAsync();
            }
            catch (ApiException e){};
        }
    }
}
```

## SquareClient Class

The gateway for the SDK. This class acts as a factory for the Apis and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| MobileAuthorizationApi | Provides access to MobileAuthorizationApi. |
| OAuthApi | Provides access to OAuthApi. |
| V1EmployeesApi | Provides access to V1EmployeesApi. |
| V1TransactionsApi | Provides access to V1TransactionsApi. |
| ApplePayApi | Provides access to ApplePayApi. |
| BankAccountsApi | Provides access to BankAccountsApi. |
| BookingsApi | Provides access to BookingsApi. |
| CashDrawersApi | Provides access to CashDrawersApi. |
| CatalogApi | Provides access to CatalogApi. |
| CustomersApi | Provides access to CustomersApi. |
| CustomerGroupsApi | Provides access to CustomerGroupsApi. |
| CustomerSegmentsApi | Provides access to CustomerSegmentsApi. |
| DevicesApi | Provides access to DevicesApi. |
| DisputesApi | Provides access to DisputesApi. |
| EmployeesApi | Provides access to EmployeesApi. |
| InventoryApi | Provides access to InventoryApi. |
| InvoicesApi | Provides access to InvoicesApi. |
| LaborApi | Provides access to LaborApi. |
| LocationsApi | Provides access to LocationsApi. |
| CheckoutApi | Provides access to CheckoutApi. |
| TransactionsApi | Provides access to TransactionsApi. |
| LoyaltyApi | Provides access to LoyaltyApi. |
| MerchantsApi | Provides access to MerchantsApi. |
| OrdersApi | Provides access to OrdersApi. |
| PaymentsApi | Provides access to PaymentsApi. |
| RefundsApi | Provides access to RefundsApi. |
| SubscriptionsApi | Provides access to SubscriptionsApi. |
| TeamApi | Provides access to TeamApi. |
| TerminalApi | Provides access to TerminalApi. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| AdditionalHeaders | Provides access to Additional headers. | `IDictionary<string, List<string>>` |
| SdkVersion | Provides access to Additional headers. | `string` |
| HttpClientConfiguration | The configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout | `TimeSpan` |
| SquareVersion | Square Connect API versions | `string` |
| Environment | Current API environment | `Environment` |
| CustomUrl | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `string` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the SquareClient using the values provided for the builder. | `Builder` |

