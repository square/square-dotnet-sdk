
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `SquareVersion` | `string` | Square Connect API versions<br>*Default*: `"2021-07-21"` |
| `CustomUrl` | `string` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com`<br>*Default*: `"https://connect.squareup.com"` |
| `Environment` | `string` | The API environment. <br> **Default: `production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(60)` |
| `AccessToken` | `string` | The OAuth 2.0 Access Token to use for API requests. |

The API client can be initialized as follows:

```csharp
Square.SquareClient client = new Square.SquareClient.Builder()
    .AccessToken("AccessToken")
    .SquareVersion(GetEnvironmentVariable("2021-07-21"))
    .Environment(Environment.Production)
    .CustomUrl("https://connect.squareup.com")
    .HttpClientConfig(config => config.NumberOfRetries(0))
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
                .SquareVersion(GetEnvironmentVariable("2021-07-21"))
                .HttpClientConfig(config => config.NumberOfRetries(0))
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
| MobileAuthorizationApi | Gets MobileAuthorizationApi. |
| OAuthApi | Gets OAuthApi. |
| V1EmployeesApi | Gets V1EmployeesApi. |
| V1TransactionsApi | Gets V1TransactionsApi. |
| ApplePayApi | Gets ApplePayApi. |
| BankAccountsApi | Gets BankAccountsApi. |
| BookingsApi | Gets BookingsApi. |
| CardsApi | Gets CardsApi. |
| CashDrawersApi | Gets CashDrawersApi. |
| CatalogApi | Gets CatalogApi. |
| CustomersApi | Gets CustomersApi. |
| CustomerGroupsApi | Gets CustomerGroupsApi. |
| CustomerSegmentsApi | Gets CustomerSegmentsApi. |
| DevicesApi | Gets DevicesApi. |
| DisputesApi | Gets DisputesApi. |
| EmployeesApi | Gets EmployeesApi. |
| GiftCardsApi | Gets GiftCardsApi. |
| GiftCardActivitiesApi | Gets GiftCardActivitiesApi. |
| InventoryApi | Gets InventoryApi. |
| InvoicesApi | Gets InvoicesApi. |
| LaborApi | Gets LaborApi. |
| LocationsApi | Gets LocationsApi. |
| CheckoutApi | Gets CheckoutApi. |
| TransactionsApi | Gets TransactionsApi. |
| LoyaltyApi | Gets LoyaltyApi. |
| MerchantsApi | Gets MerchantsApi. |
| OrdersApi | Gets OrdersApi. |
| PaymentsApi | Gets PaymentsApi. |
| RefundsApi | Gets RefundsApi. |
| SitesApi | Gets SitesApi. |
| SnippetsApi | Gets SnippetsApi. |
| SubscriptionsApi | Gets SubscriptionsApi. |
| TeamApi | Gets TeamApi. |
| TerminalApi | Gets TerminalApi. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| AdditionalHeaders | Gets the additional headers. | `IDictionary<string, List<string>>` |
| SdkVersion | Gets the additional headers. | `string` |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Http client timeout. | `TimeSpan` |
| SquareVersion | Square Connect API versions | `string` |
| Environment | Current API environment. | `Environment` |
| CustomUrl | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `string` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the SquareClient using the values provided for the builder. | `Builder` |

## SquareClient Builder Class

Class to build instances of SquareClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)` | Gets the additional headers. | `Builder` |
| `SdkVersion(string sdkVersion)` | Gets the additional headers. | `Builder` |
| `HttpClientConfiguration(Action<HttpClientConfiguration.Builder> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |

