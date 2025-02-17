using System;
using System.Collections.Generic;
using System.Linq;
using APIMatic.Core;
using APIMatic.Core.Authentication;
using APIMatic.Core.Request.Parameters;
using Square.Apis;
using Square.Authentication;
using Square.Http.Client;
using Square.Utilities;

namespace Square
{
    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Api and holds the
    /// configuration of the SDK.
    /// </summary>
    public sealed class SquareClient : ISquareClient
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://connect.squareup.com" },
                }
            },
            {
                Environment.Sandbox, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://connect.squareupsandbox.com" },
                }
            },
            {
                Environment.Custom, new Dictionary<Enum, string>
                {
                    { Server.Default, "{custom_url}" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "Square-DotNet-SDK/40.1.0 ({api-version}) {engine}/{engine-version} ({os-info}) {detail}";
        private readonly HttpCallback httpCallback;
        private readonly IDictionary<string, List<string>> additionalHeaders;
        private readonly Lazy<IMobileAuthorizationApi> mobileAuthorization;
        private readonly Lazy<IOAuthApi> oAuth;
        private readonly Lazy<IV1TransactionsApi> v1Transactions;
        private readonly Lazy<IApplePayApi> applePay;
        private readonly Lazy<IBankAccountsApi> bankAccounts;
        private readonly Lazy<IBookingsApi> bookings;
        private readonly Lazy<IBookingCustomAttributesApi> bookingCustomAttributes;
        private readonly Lazy<ICardsApi> cards;
        private readonly Lazy<ICashDrawersApi> cashDrawers;
        private readonly Lazy<ICatalogApi> catalog;
        private readonly Lazy<ICustomersApi> customers;
        private readonly Lazy<ICustomerCustomAttributesApi> customerCustomAttributes;
        private readonly Lazy<ICustomerGroupsApi> customerGroups;
        private readonly Lazy<ICustomerSegmentsApi> customerSegments;
        private readonly Lazy<IDevicesApi> devices;
        private readonly Lazy<IDisputesApi> disputes;
        private readonly Lazy<IEmployeesApi> employees;
        private readonly Lazy<IEventsApi> events;
        private readonly Lazy<IGiftCardsApi> giftCards;
        private readonly Lazy<IGiftCardActivitiesApi> giftCardActivities;
        private readonly Lazy<IInventoryApi> inventory;
        private readonly Lazy<IInvoicesApi> invoices;
        private readonly Lazy<ILaborApi> labor;
        private readonly Lazy<ILocationsApi> locations;
        private readonly Lazy<ILocationCustomAttributesApi> locationCustomAttributes;
        private readonly Lazy<ICheckoutApi> checkout;
        private readonly Lazy<ITransactionsApi> transactions;
        private readonly Lazy<ILoyaltyApi> loyalty;
        private readonly Lazy<IMerchantsApi> merchants;
        private readonly Lazy<IMerchantCustomAttributesApi> merchantCustomAttributes;
        private readonly Lazy<IOrdersApi> orders;
        private readonly Lazy<IOrderCustomAttributesApi> orderCustomAttributes;
        private readonly Lazy<IPaymentsApi> payments;
        private readonly Lazy<IPayoutsApi> payouts;
        private readonly Lazy<IRefundsApi> refunds;
        private readonly Lazy<ISitesApi> sites;
        private readonly Lazy<ISnippetsApi> snippets;
        private readonly Lazy<ISubscriptionsApi> subscriptions;
        private readonly Lazy<ITeamApi> team;
        private readonly Lazy<ITerminalApi> terminal;
        private readonly Lazy<IVendorsApi> vendors;
        private readonly Lazy<IWebhookSubscriptionsApi> webhookSubscriptions;

        private SquareClient(
            string squareVersion,
            string userAgentDetail,
            Environment environment,
            string customUrl,
            BearerAuthModel bearerAuthModel,
            HttpCallback httpCallback,
            IDictionary<string, List<string>> additionalHeaders,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.SquareVersion = squareVersion;
            this.UserAgentDetail = userAgentDetail;
            this.Environment = environment;
            this.CustomUrl = customUrl;
            this.httpCallback = httpCallback;
            this.additionalHeaders = additionalHeaders;
            this.HttpClientConfiguration = httpClientConfiguration;
            BearerAuthModel = bearerAuthModel;
            var bearerAuthManager = new BearerAuthManager(bearerAuthModel);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                    {"global", bearerAuthManager},
                })
                .ApiCallback(httpCallback)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .Parameters(globalParameter => globalParameter
                    .Header(headerParameter => headerParameter.Setup("Square-Version", this.SquareVersion))
                    .Template(templateParameter => templateParameter.Setup("custom_url", this.CustomUrl)))
                .RuntimeParameters(runtimeParameter => runtimeParameter.AdditionalHeaders(SetupAdditionalHeaders))
                .UserAgent(userAgent, GetUserAgentConfig())
                .Build();

            BearerAuthCredentials = bearerAuthManager;

            this.mobileAuthorization = new Lazy<IMobileAuthorizationApi>(
                () => new MobileAuthorizationApi(globalConfiguration));
            this.oAuth = new Lazy<IOAuthApi>(
                () => new OAuthApi(globalConfiguration));
            this.v1Transactions = new Lazy<IV1TransactionsApi>(
                () => new V1TransactionsApi(globalConfiguration));
            this.applePay = new Lazy<IApplePayApi>(
                () => new ApplePayApi(globalConfiguration));
            this.bankAccounts = new Lazy<IBankAccountsApi>(
                () => new BankAccountsApi(globalConfiguration));
            this.bookings = new Lazy<IBookingsApi>(
                () => new BookingsApi(globalConfiguration));
            this.bookingCustomAttributes = new Lazy<IBookingCustomAttributesApi>(
                () => new BookingCustomAttributesApi(globalConfiguration));
            this.cards = new Lazy<ICardsApi>(
                () => new CardsApi(globalConfiguration));
            this.cashDrawers = new Lazy<ICashDrawersApi>(
                () => new CashDrawersApi(globalConfiguration));
            this.catalog = new Lazy<ICatalogApi>(
                () => new CatalogApi(globalConfiguration));
            this.customers = new Lazy<ICustomersApi>(
                () => new CustomersApi(globalConfiguration));
            this.customerCustomAttributes = new Lazy<ICustomerCustomAttributesApi>(
                () => new CustomerCustomAttributesApi(globalConfiguration));
            this.customerGroups = new Lazy<ICustomerGroupsApi>(
                () => new CustomerGroupsApi(globalConfiguration));
            this.customerSegments = new Lazy<ICustomerSegmentsApi>(
                () => new CustomerSegmentsApi(globalConfiguration));
            this.devices = new Lazy<IDevicesApi>(
                () => new DevicesApi(globalConfiguration));
            this.disputes = new Lazy<IDisputesApi>(
                () => new DisputesApi(globalConfiguration));
            this.employees = new Lazy<IEmployeesApi>(
                () => new EmployeesApi(globalConfiguration));
            this.events = new Lazy<IEventsApi>(
                () => new EventsApi(globalConfiguration));
            this.giftCards = new Lazy<IGiftCardsApi>(
                () => new GiftCardsApi(globalConfiguration));
            this.giftCardActivities = new Lazy<IGiftCardActivitiesApi>(
                () => new GiftCardActivitiesApi(globalConfiguration));
            this.inventory = new Lazy<IInventoryApi>(
                () => new InventoryApi(globalConfiguration));
            this.invoices = new Lazy<IInvoicesApi>(
                () => new InvoicesApi(globalConfiguration));
            this.labor = new Lazy<ILaborApi>(
                () => new LaborApi(globalConfiguration));
            this.locations = new Lazy<ILocationsApi>(
                () => new LocationsApi(globalConfiguration));
            this.locationCustomAttributes = new Lazy<ILocationCustomAttributesApi>(
                () => new LocationCustomAttributesApi(globalConfiguration));
            this.checkout = new Lazy<ICheckoutApi>(
                () => new CheckoutApi(globalConfiguration));
            this.transactions = new Lazy<ITransactionsApi>(
                () => new TransactionsApi(globalConfiguration));
            this.loyalty = new Lazy<ILoyaltyApi>(
                () => new LoyaltyApi(globalConfiguration));
            this.merchants = new Lazy<IMerchantsApi>(
                () => new MerchantsApi(globalConfiguration));
            this.merchantCustomAttributes = new Lazy<IMerchantCustomAttributesApi>(
                () => new MerchantCustomAttributesApi(globalConfiguration));
            this.orders = new Lazy<IOrdersApi>(
                () => new OrdersApi(globalConfiguration));
            this.orderCustomAttributes = new Lazy<IOrderCustomAttributesApi>(
                () => new OrderCustomAttributesApi(globalConfiguration));
            this.payments = new Lazy<IPaymentsApi>(
                () => new PaymentsApi(globalConfiguration));
            this.payouts = new Lazy<IPayoutsApi>(
                () => new PayoutsApi(globalConfiguration));
            this.refunds = new Lazy<IRefundsApi>(
                () => new RefundsApi(globalConfiguration));
            this.sites = new Lazy<ISitesApi>(
                () => new SitesApi(globalConfiguration));
            this.snippets = new Lazy<ISnippetsApi>(
                () => new SnippetsApi(globalConfiguration));
            this.subscriptions = new Lazy<ISubscriptionsApi>(
                () => new SubscriptionsApi(globalConfiguration));
            this.team = new Lazy<ITeamApi>(
                () => new TeamApi(globalConfiguration));
            this.terminal = new Lazy<ITerminalApi>(
                () => new TerminalApi(globalConfiguration));
            this.vendors = new Lazy<IVendorsApi>(
                () => new VendorsApi(globalConfiguration));
            this.webhookSubscriptions = new Lazy<IWebhookSubscriptionsApi>(
                () => new WebhookSubscriptionsApi(globalConfiguration));
        }

        /// <summary>
        /// Gets MobileAuthorizationApi.
        /// </summary>
        public IMobileAuthorizationApi MobileAuthorizationApi => this.mobileAuthorization.Value;

        /// <summary>
        /// Gets OAuthApi.
        /// </summary>
        public IOAuthApi OAuthApi => this.oAuth.Value;

        /// <summary>
        /// Gets V1TransactionsApi.
        /// </summary>
        public IV1TransactionsApi V1TransactionsApi => this.v1Transactions.Value;

        /// <summary>
        /// Gets ApplePayApi.
        /// </summary>
        public IApplePayApi ApplePayApi => this.applePay.Value;

        /// <summary>
        /// Gets BankAccountsApi.
        /// </summary>
        public IBankAccountsApi BankAccountsApi => this.bankAccounts.Value;

        /// <summary>
        /// Gets BookingsApi.
        /// </summary>
        public IBookingsApi BookingsApi => this.bookings.Value;

        /// <summary>
        /// Gets BookingCustomAttributesApi.
        /// </summary>
        public IBookingCustomAttributesApi BookingCustomAttributesApi => this.bookingCustomAttributes.Value;

        /// <summary>
        /// Gets CardsApi.
        /// </summary>
        public ICardsApi CardsApi => this.cards.Value;

        /// <summary>
        /// Gets CashDrawersApi.
        /// </summary>
        public ICashDrawersApi CashDrawersApi => this.cashDrawers.Value;

        /// <summary>
        /// Gets CatalogApi.
        /// </summary>
        public ICatalogApi CatalogApi => this.catalog.Value;

        /// <summary>
        /// Gets CustomersApi.
        /// </summary>
        public ICustomersApi CustomersApi => this.customers.Value;

        /// <summary>
        /// Gets CustomerCustomAttributesApi.
        /// </summary>
        public ICustomerCustomAttributesApi CustomerCustomAttributesApi => this.customerCustomAttributes.Value;

        /// <summary>
        /// Gets CustomerGroupsApi.
        /// </summary>
        public ICustomerGroupsApi CustomerGroupsApi => this.customerGroups.Value;

        /// <summary>
        /// Gets CustomerSegmentsApi.
        /// </summary>
        public ICustomerSegmentsApi CustomerSegmentsApi => this.customerSegments.Value;

        /// <summary>
        /// Gets DevicesApi.
        /// </summary>
        public IDevicesApi DevicesApi => this.devices.Value;

        /// <summary>
        /// Gets DisputesApi.
        /// </summary>
        public IDisputesApi DisputesApi => this.disputes.Value;

        /// <summary>
        /// Gets EmployeesApi.
        /// </summary>
        public IEmployeesApi EmployeesApi => this.employees.Value;

        /// <summary>
        /// Gets EventsApi.
        /// </summary>
        public IEventsApi EventsApi => this.events.Value;

        /// <summary>
        /// Gets GiftCardsApi.
        /// </summary>
        public IGiftCardsApi GiftCardsApi => this.giftCards.Value;

        /// <summary>
        /// Gets GiftCardActivitiesApi.
        /// </summary>
        public IGiftCardActivitiesApi GiftCardActivitiesApi => this.giftCardActivities.Value;

        /// <summary>
        /// Gets InventoryApi.
        /// </summary>
        public IInventoryApi InventoryApi => this.inventory.Value;

        /// <summary>
        /// Gets InvoicesApi.
        /// </summary>
        public IInvoicesApi InvoicesApi => this.invoices.Value;

        /// <summary>
        /// Gets LaborApi.
        /// </summary>
        public ILaborApi LaborApi => this.labor.Value;

        /// <summary>
        /// Gets LocationsApi.
        /// </summary>
        public ILocationsApi LocationsApi => this.locations.Value;

        /// <summary>
        /// Gets LocationCustomAttributesApi.
        /// </summary>
        public ILocationCustomAttributesApi LocationCustomAttributesApi => this.locationCustomAttributes.Value;

        /// <summary>
        /// Gets CheckoutApi.
        /// </summary>
        public ICheckoutApi CheckoutApi => this.checkout.Value;

        /// <summary>
        /// Gets TransactionsApi.
        /// </summary>
        public ITransactionsApi TransactionsApi => this.transactions.Value;

        /// <summary>
        /// Gets LoyaltyApi.
        /// </summary>
        public ILoyaltyApi LoyaltyApi => this.loyalty.Value;

        /// <summary>
        /// Gets MerchantsApi.
        /// </summary>
        public IMerchantsApi MerchantsApi => this.merchants.Value;

        /// <summary>
        /// Gets MerchantCustomAttributesApi.
        /// </summary>
        public IMerchantCustomAttributesApi MerchantCustomAttributesApi => this.merchantCustomAttributes.Value;

        /// <summary>
        /// Gets OrdersApi.
        /// </summary>
        public IOrdersApi OrdersApi => this.orders.Value;

        /// <summary>
        /// Gets OrderCustomAttributesApi.
        /// </summary>
        public IOrderCustomAttributesApi OrderCustomAttributesApi => this.orderCustomAttributes.Value;

        /// <summary>
        /// Gets PaymentsApi.
        /// </summary>
        public IPaymentsApi PaymentsApi => this.payments.Value;

        /// <summary>
        /// Gets PayoutsApi.
        /// </summary>
        public IPayoutsApi PayoutsApi => this.payouts.Value;

        /// <summary>
        /// Gets RefundsApi.
        /// </summary>
        public IRefundsApi RefundsApi => this.refunds.Value;

        /// <summary>
        /// Gets SitesApi.
        /// </summary>
        public ISitesApi SitesApi => this.sites.Value;

        /// <summary>
        /// Gets SnippetsApi.
        /// </summary>
        public ISnippetsApi SnippetsApi => this.snippets.Value;

        /// <summary>
        /// Gets SubscriptionsApi.
        /// </summary>
        public ISubscriptionsApi SubscriptionsApi => this.subscriptions.Value;

        /// <summary>
        /// Gets TeamApi.
        /// </summary>
        public ITeamApi TeamApi => this.team.Value;

        /// <summary>
        /// Gets TerminalApi.
        /// </summary>
        public ITerminalApi TerminalApi => this.terminal.Value;

        /// <summary>
        /// Gets VendorsApi.
        /// </summary>
        public IVendorsApi VendorsApi => this.vendors.Value;

        /// <summary>
        /// Gets WebhookSubscriptionsApi.
        /// </summary>
        public IWebhookSubscriptionsApi WebhookSubscriptionsApi => this.webhookSubscriptions.Value;

        /// <summary>
        /// Gets the additional headers.
        /// </summary>
        public IDictionary<string, List<string>> AdditionalHeaders => this.additionalHeaders.ToDictionary(s => s.Key, s => new List<string>(s.Value));

        /// <summary>
        /// Gets the current version of the SDK.
        /// </summary>
        public string SdkVersion => "40.1.0";

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets SquareVersion.
        /// Square Connect API versions.
        /// </summary>
        public string SquareVersion { get; }

        /// <summary>
        /// Gets UserAgentDetail.
        /// User-Agent detail.
        /// </summary>
        public string UserAgentDetail { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets CustomUrl.
        /// Sets the base URL requests are made to. Defaults to `https://connect.squareup.com`.
        /// </summary>
        public string CustomUrl { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        public HttpCallback HttpCallback => this.httpCallback;

        /// <summary>
        /// Gets the credentials to use with BearerAuth.
        /// </summary>
        public IBearerAuthCredentials BearerAuthCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with BearerAuth.
        /// </summary>
        public BearerAuthModel BearerAuthModel { get; private set; }

        /// <summary>
        /// Gets the access token to use with OAuth 2 authentication.
        /// </summary>
        public string AccessToken => this.BearerAuthCredentials.AccessToken;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the SquareClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .SquareVersion(this.SquareVersion)
                .UserAgentDetail(this.UserAgentDetail)
                .Environment(this.Environment)
                .CustomUrl(this.CustomUrl)
                .AdditionalHeaders(additionalHeaders)
                .HttpCallback(httpCallback)
                .HttpClientConfig(config => config.Build());

            if (BearerAuthModel != null)
            {
                builder.BearerAuthCredentials(BearerAuthModel.ToBuilder().Build());
            }

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"SquareVersion = {this.SquareVersion}, " +
                $"UserAgentDetail = {this.UserAgentDetail}, " +
                $"Environment = {this.Environment}, " +
                $"CustomUrl = {this.CustomUrl}, " +
                $"additionalHeaders = {ApiHelper.JsonSerialize(this.additionalHeaders)}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> SquareClient.</returns>
        internal static SquareClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string squareVersion = System.Environment.GetEnvironmentVariable("SQUARE_SQUARE_VERSION");
            string environment = System.Environment.GetEnvironmentVariable("SQUARE_ENVIRONMENT");
            string customUrl = System.Environment.GetEnvironmentVariable("SQUARE_CUSTOM_URL");
            string accessToken = System.Environment.GetEnvironmentVariable("SQUARE_ACCESS_TOKEN");

            if (squareVersion != null)
            {
                builder.SquareVersion(squareVersion);
            }

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (customUrl != null)
            {
                builder.CustomUrl(customUrl);
            }

            if (accessToken != null)
            {
                builder.BearerAuthCredentials(new BearerAuthModel
                .Builder(accessToken)
                .Build());
            }

            return builder.Build();
        }

        private void SetupAdditionalHeaders(AdditionalHeaderParams additionalHeaderParams)
        {
            if (additionalHeaders == null)
            {
                return;
            }
            foreach (var entry in additionalHeaders)
            {
                additionalHeaderParams.Setup(entry.Key, string.Join(", ", entry.Value));
            }
        }

        private List<(string, string)> GetUserAgentConfig()
            => new List<(string, string)>
            {
                ("{api-version}", SquareVersion ?? ""),
                ("{detail}", UserAgentDetail != null ? Uri.EscapeDataString(UserAgentDetail) : "")
            };
        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string squareVersion = "2025-01-23";
            private string userAgentDetail = null;
            private Environment environment = Square.Environment.Production;
            private string customUrl = "https://connect.squareup.com";
            private BearerAuthModel bearerAuthModel = new BearerAuthModel();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallback httpCallback;
            private IDictionary<string, List<string>> additionalHeaders = new Dictionary<string, List<string>>();

            /// <summary>
            /// Sets credentials for BearerAuth.
            /// </summary>
            /// <param name="accessToken">AccessToken.</param>
            /// <returns>Builder.</returns>
            [Obsolete("This method is deprecated. Use BearerAuthCredentials(bearerAuthModel) instead.")]
            public Builder AccessToken(string accessToken)
            {
                bearerAuthModel = bearerAuthModel.ToBuilder()
                    .AccessToken(accessToken)
                    .Build();
                return this;
            }

            /// <summary>
            /// Sets credentials for BearerAuth.
            /// </summary>
            /// <param name="bearerAuthModel">BearerAuthModel.</param>
            /// <returns>Builder.</returns>
            public Builder BearerAuthCredentials(BearerAuthModel bearerAuthModel)
            {
                if (bearerAuthModel is null)
                {
                    throw new ArgumentNullException(nameof(bearerAuthModel));
                }

                this.bearerAuthModel = bearerAuthModel;
                return this;
            }

            /// <summary>
            /// Sets SquareVersion.
            /// </summary>
            /// <param name="squareVersion"> SquareVersion. </param>
            /// <returns> Builder. </returns>
            public Builder SquareVersion(string squareVersion)
            {
                this.squareVersion = squareVersion ?? throw new ArgumentNullException(nameof(squareVersion));
                return this;
            }

            /// <summary>
            /// Sets UserAgentDetail.
            /// </summary>
            /// <param name="userAgentDetail"> UserAgentDetail. </param>
            /// <returns> Builder. </returns>
            public Builder UserAgentDetail(string userAgentDetail)
            {
                if(userAgentDetail != null && userAgentDetail.Count() > 128) throw new ArgumentException("The length of user-agent detail should not exceed 128 characters.");
                this.userAgentDetail = userAgentDetail;
                return this;
            }
            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets CustomUrl.
            /// </summary>
            /// <param name="customUrl"> CustomUrl. </param>
            /// <returns> Builder. </returns>
            public Builder CustomUrl(string customUrl)
            {
                this.customUrl = customUrl ?? throw new ArgumentNullException(nameof(customUrl));
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }


            /// <summary>
            /// Sets the AdditionalHeaders for the Builder.
            /// </summary>
            /// <param name="additionalHeaders"> additional headers. </param>
            /// <returns>Builder.</returns>
            public Builder AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)
            {
                if (additionalHeaders is null)
                {
                    throw new ArgumentNullException(nameof(additionalHeaders));
                }

                this.additionalHeaders = additionalHeaders.ToDictionary(s => s.Key, s => new List<string>(s.Value));
                return this;
            }

            /// <summary>
            /// Adds AdditionalHeader.
            /// </summary>
            /// <param name="headerName"> header name. </param>
            /// <param name="headerValue"> header value. </param>
            /// <returns>Builder.</returns>
            public Builder AddAdditionalHeader(string headerName, string headerValue)
            {
                if (string.IsNullOrWhiteSpace(headerName))
                {
                    throw new ArgumentException("Header name can not be null, empty or whitespace.", nameof(headerName));
                }

                if (headerValue is null)
                {
                    throw new ArgumentNullException(nameof(headerValue));
                }

                if (this.additionalHeaders.ContainsKey(headerName) && this.additionalHeaders[headerName] != null)
                {
                    this.additionalHeaders[headerName].Add(headerValue);
                }
                else
                {
                    this.additionalHeaders[headerName] = new List<string>() { headerValue };
                }

                return this;
            }

            /// <summary>
            /// Sets the HttpCallback for the Builder.
            /// </summary>
            /// <param name="httpCallback"> http callback. </param>
            /// <returns>Builder.</returns>
            public Builder HttpCallback(HttpCallback httpCallback)
            {
                this.httpCallback = httpCallback;
                return this;
            }

            /// <summary>
            /// Creates an object of the SquareClient using the values provided for the builder.
            /// </summary>
            /// <returns>SquareClient.</returns>
            public SquareClient Build()
            {
                if (bearerAuthModel.AccessToken == null)
                {
                    bearerAuthModel = null;
                }
                return new SquareClient(
                    squareVersion,
                    userAgentDetail,
                    environment,
                    customUrl,
                    bearerAuthModel,
                    httpCallback,
                    additionalHeaders,
                    httpClientConfig.Build());
            }
        }
    }
}
