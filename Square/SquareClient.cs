namespace Square
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Square.Apis;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Api and holds the
    /// configuration of the SDK.
    /// </summary>
    public sealed class SquareClient : ISquareClient
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "https://connect.squareup.com" },
                }
            },
            {
                Environment.Sandbox, new Dictionary<Server, string>
                {
                    { Server.Default, "https://connect.squareupsandbox.com" },
                }
            },
            {
                Environment.Custom, new Dictionary<Server, string>
                {
                    { Server.Default, "{custom_url}" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IDictionary<string, List<string>> additionalHeaders;
        private readonly IHttpClient httpClient;
        private readonly HttpCallBack httpCallBack;
        private readonly BearerAuthManager bearerAuthManager;

        private readonly Lazy<IMobileAuthorizationApi> mobileAuthorization;
        private readonly Lazy<IOAuthApi> oAuth;
        private readonly Lazy<IV1TransactionsApi> v1Transactions;
        private readonly Lazy<IApplePayApi> applePay;
        private readonly Lazy<IBankAccountsApi> bankAccounts;
        private readonly Lazy<IBookingsApi> bookings;
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
        private readonly Lazy<IGiftCardsApi> giftCards;
        private readonly Lazy<IGiftCardActivitiesApi> giftCardActivities;
        private readonly Lazy<IInventoryApi> inventory;
        private readonly Lazy<IInvoicesApi> invoices;
        private readonly Lazy<ILaborApi> labor;
        private readonly Lazy<ILocationsApi> locations;
        private readonly Lazy<ICheckoutApi> checkout;
        private readonly Lazy<ITransactionsApi> transactions;
        private readonly Lazy<ILoyaltyApi> loyalty;
        private readonly Lazy<IMerchantsApi> merchants;
        private readonly Lazy<IOrdersApi> orders;
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
            string accessToken,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            HttpCallBack httpCallBack,
            IDictionary<string, List<string>> additionalHeaders,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.SquareVersion = squareVersion;
            this.UserAgentDetail = userAgentDetail;
            this.Environment = environment;
            this.CustomUrl = customUrl;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.additionalHeaders = additionalHeaders;
            this.HttpClientConfiguration = httpClientConfiguration;

            this.mobileAuthorization = new Lazy<IMobileAuthorizationApi>(
                () => new MobileAuthorizationApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.oAuth = new Lazy<IOAuthApi>(
                () => new OAuthApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.v1Transactions = new Lazy<IV1TransactionsApi>(
                () => new V1TransactionsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.applePay = new Lazy<IApplePayApi>(
                () => new ApplePayApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.bankAccounts = new Lazy<IBankAccountsApi>(
                () => new BankAccountsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.bookings = new Lazy<IBookingsApi>(
                () => new BookingsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.cards = new Lazy<ICardsApi>(
                () => new CardsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.cashDrawers = new Lazy<ICashDrawersApi>(
                () => new CashDrawersApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.catalog = new Lazy<ICatalogApi>(
                () => new CatalogApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.customers = new Lazy<ICustomersApi>(
                () => new CustomersApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.customerCustomAttributes = new Lazy<ICustomerCustomAttributesApi>(
                () => new CustomerCustomAttributesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.customerGroups = new Lazy<ICustomerGroupsApi>(
                () => new CustomerGroupsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.customerSegments = new Lazy<ICustomerSegmentsApi>(
                () => new CustomerSegmentsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.devices = new Lazy<IDevicesApi>(
                () => new DevicesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.disputes = new Lazy<IDisputesApi>(
                () => new DisputesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.employees = new Lazy<IEmployeesApi>(
                () => new EmployeesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.giftCards = new Lazy<IGiftCardsApi>(
                () => new GiftCardsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.giftCardActivities = new Lazy<IGiftCardActivitiesApi>(
                () => new GiftCardActivitiesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.inventory = new Lazy<IInventoryApi>(
                () => new InventoryApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.invoices = new Lazy<IInvoicesApi>(
                () => new InvoicesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.labor = new Lazy<ILaborApi>(
                () => new LaborApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.locations = new Lazy<ILocationsApi>(
                () => new LocationsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.checkout = new Lazy<ICheckoutApi>(
                () => new CheckoutApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.transactions = new Lazy<ITransactionsApi>(
                () => new TransactionsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.loyalty = new Lazy<ILoyaltyApi>(
                () => new LoyaltyApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.merchants = new Lazy<IMerchantsApi>(
                () => new MerchantsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.orders = new Lazy<IOrdersApi>(
                () => new OrdersApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.payments = new Lazy<IPaymentsApi>(
                () => new PaymentsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.payouts = new Lazy<IPayoutsApi>(
                () => new PayoutsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.refunds = new Lazy<IRefundsApi>(
                () => new RefundsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.sites = new Lazy<ISitesApi>(
                () => new SitesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.snippets = new Lazy<ISnippetsApi>(
                () => new SnippetsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.subscriptions = new Lazy<ISubscriptionsApi>(
                () => new SubscriptionsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.team = new Lazy<ITeamApi>(
                () => new TeamApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.terminal = new Lazy<ITerminalApi>(
                () => new TerminalApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.vendors = new Lazy<IVendorsApi>(
                () => new VendorsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.webhookSubscriptions = new Lazy<IWebhookSubscriptionsApi>(
                () => new WebhookSubscriptionsApi(this, this.httpClient, this.authManagers, this.httpCallBack));

            if (this.authManagers.ContainsKey("global"))
            {
                this.bearerAuthManager = (BearerAuthManager)this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !this.BearerAuthCredentials.Equals(accessToken))
            {
                this.bearerAuthManager = new BearerAuthManager(accessToken);
                this.authManagers["global"] = this.bearerAuthManager;
            }
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
        /// Gets OrdersApi.
        /// </summary>
        public IOrdersApi OrdersApi => this.orders.Value;

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
        public string SdkVersion => "21.0.0";

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
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with BearerAuth.
        /// </summary>
        private IBearerAuthCredentials BearerAuthCredentials => this.bearerAuthManager;

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
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
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
                .AccessToken(this.BearerAuthCredentials.AccessToken)
                .AdditionalHeaders(this.additionalHeaders)
                .HttpCallBack(this.httpCallBack)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers)
                .HttpClientConfig(config => config.Build());

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
                builder.AccessToken(accessToken);
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("custom_url", this.CustomUrl),
            };
            return kvpList;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string squareVersion = "2022-08-17";
            private string userAgentDetail = null;
            private Environment environment = Square.Environment.Production;
            private string customUrl = "https://connect.squareup.com";
            private string accessToken = "";
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private IHttpClient httpClient;
            private HttpCallBack httpCallBack;
            private IDictionary<string, List<string>> additionalHeaders = new Dictionary<string, List<string>>();

            /// <summary>
            /// Sets credentials for BearerAuth.
            /// </summary>
            /// <param name="accessToken">AccessToken.</param>
            /// <returns>Builder.</returns>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
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
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the SquareClient using the values provided for the builder.
            /// </summary>
            /// <returns>SquareClient.</returns>
            public SquareClient Build()
            {
                this.httpClient = new HttpClientWrapper(this.httpClientConfig.Build());

                return new SquareClient(
                    this.squareVersion,
                    this.userAgentDetail,
                    this.environment,
                    this.customUrl,
                    this.accessToken,
                    this.authManagers,
                    this.httpClient,
                    this.httpCallBack,
                    this.additionalHeaders,
                    this.httpClientConfig.Build());
            }
        }
    }
}
