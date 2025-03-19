
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `SquareVersion` | `string` | Square Connect API versions<br>*Default*: `"2025-02-20"` |
| `CustomUrl` | `string` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com`<br>*Default*: `"https://connect.squareup.com"` |
| `Environment` | `string` | The API environment. <br> **Default: `production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(60)` |
| `UserAgentDetail` | `string` | User-Agent detail.<br>*Default*: `"null"` |
| `BearerAuthCredentials` | [`BearerAuthCredentials`](auth/oauth-2-bearer-token.md) | The Credentials Setter for OAuth 2 Bearer token |

The API client can be initialized as follows:

```csharp
SquareClient client = new SquareClient.Builder()
    .BearerAuthCredentials(
        new BearerAuthModel.Builder(
            "AccessToken"
        )
        .Build())
    .SquareVersion("2025-02-20")
    .Environment(Square.Legacy.Environment.Production)
    .CustomUrl("https://connect.squareup.com")
    .Build();
```

## Make Calls with the API Client

```csharp
using Square.Legacy;
using Square.Legacy.Apis;
using Square.Legacy.Authentication;
using Square.Legacy.Exceptions;
using Square.Legacy.Models;
using System;
using System.Threading.Tasks;

namespace TestConsoleProject
{
    public class Program
    {
        public static async Task Main()
        {
            SquareClient client = new SquareClient.Builder()
                .BearerAuthCredentials(
                    new BearerAuthModel.Builder(
                        "AccessToken"
                    )
                    .Build())
                .SquareVersion("2025-02-20")
                .Environment(Square.Legacy.Environment.Production)
                .CustomUrl("https://connect.squareup.com")
                .Build();

            ILocationsApi locationsApi = client.LocationsApi;

            try
            {
                ListLocationsResponse result = await locationsApi.ListLocationsAsync();
            }
            catch (ApiException e)
            {
                // TODO: Handle exception here
                Console.WriteLine(e.Message);
            }
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
| V1TransactionsApi | Gets V1TransactionsApi. |
| ApplePayApi | Gets ApplePayApi. |
| BankAccountsApi | Gets BankAccountsApi. |
| BookingsApi | Gets BookingsApi. |
| BookingCustomAttributesApi | Gets BookingCustomAttributesApi. |
| CardsApi | Gets CardsApi. |
| CashDrawersApi | Gets CashDrawersApi. |
| CatalogApi | Gets CatalogApi. |
| CustomersApi | Gets CustomersApi. |
| CustomerCustomAttributesApi | Gets CustomerCustomAttributesApi. |
| CustomerGroupsApi | Gets CustomerGroupsApi. |
| CustomerSegmentsApi | Gets CustomerSegmentsApi. |
| DevicesApi | Gets DevicesApi. |
| DisputesApi | Gets DisputesApi. |
| EmployeesApi | Gets EmployeesApi. |
| EventsApi | Gets EventsApi. |
| GiftCardsApi | Gets GiftCardsApi. |
| GiftCardActivitiesApi | Gets GiftCardActivitiesApi. |
| InventoryApi | Gets InventoryApi. |
| InvoicesApi | Gets InvoicesApi. |
| LaborApi | Gets LaborApi. |
| LocationsApi | Gets LocationsApi. |
| LocationCustomAttributesApi | Gets LocationCustomAttributesApi. |
| CheckoutApi | Gets CheckoutApi. |
| TransactionsApi | Gets TransactionsApi. |
| LoyaltyApi | Gets LoyaltyApi. |
| MerchantsApi | Gets MerchantsApi. |
| MerchantCustomAttributesApi | Gets MerchantCustomAttributesApi. |
| OrdersApi | Gets OrdersApi. |
| OrderCustomAttributesApi | Gets OrderCustomAttributesApi. |
| PaymentsApi | Gets PaymentsApi. |
| PayoutsApi | Gets PayoutsApi. |
| RefundsApi | Gets RefundsApi. |
| SitesApi | Gets SitesApi. |
| SnippetsApi | Gets SnippetsApi. |
| SubscriptionsApi | Gets SubscriptionsApi. |
| TeamApi | Gets TeamApi. |
| TerminalApi | Gets TerminalApi. |
| VendorsApi | Gets VendorsApi. |
| WebhookSubscriptionsApi | Gets WebhookSubscriptionsApi. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| AdditionalHeaders | Gets the additional headers. | `IDictionary<string, List<string>>` |
| SdkVersion | Gets the current version of the SDK. | `string` |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | [`IHttpClientConfiguration`](http-client-configuration.md) |
| Timeout | Http client timeout. | `TimeSpan` |
| SquareVersion | Square Connect API versions | `string` |
| UserAgentDetail | User-Agent detail. | `string` |
| Environment | Current API environment. | `Environment` |
| CustomUrl | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `string` |
| BearerAuthCredentials | Gets the credentials to use with BearerAuth. | [`IBearerAuthCredentials`](auth/oauth-2-bearer-token.md) |

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
| `SdkVersion(string sdkVersion)` | Gets the current version of the SDK. | `Builder` |
| `HttpClientConfiguration(Action<`[`HttpClientConfiguration.Builder`](http-client-configuration-builder.md)`> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `SquareVersion(string squareVersion)` | Square Connect API versions | `Builder` |
| `UserAgentDetail(string userAgentDetail)` | User-Agent detail. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `CustomUrl(string customUrl)` | Sets the base URL requests are made to. Defaults to `https://connect.squareup.com` | `Builder` |
| `BearerAuthCredentials(Action<BearerAuthModel.Builder> action)` | Sets credentials for BearerAuth. | `Builder` |

