using System;
using System.Text;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Square.Authentication;
using Square.Apis;
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
        internal readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IDictionary<string, List<string>> additionalHeaders;
        internal readonly IHttpClient httpClient;
        internal readonly HttpCallBack httpCallBack;
        private readonly AccessTokenManager accessTokenManager;
        private readonly Lazy<IMobileAuthorizationApi> mobileAuthorization;
        private readonly Lazy<IOAuthApi> oAuth;
        private readonly Lazy<IV1EmployeesApi> v1Employees;
        private readonly Lazy<IV1TransactionsApi> v1Transactions;
        private readonly Lazy<IApplePayApi> applePay;
        private readonly Lazy<IBankAccountsApi> bankAccounts;
        private readonly Lazy<IBookingsApi> bookings;
        private readonly Lazy<ICashDrawersApi> cashDrawers;
        private readonly Lazy<ICatalogApi> catalog;
        private readonly Lazy<ICustomersApi> customers;
        private readonly Lazy<ICustomerGroupsApi> customerGroups;
        private readonly Lazy<ICustomerSegmentsApi> customerSegments;
        private readonly Lazy<IDevicesApi> devices;
        private readonly Lazy<IDisputesApi> disputes;
        private readonly Lazy<IEmployeesApi> employees;
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
        private readonly Lazy<IRefundsApi> refunds;
        private readonly Lazy<ISubscriptionsApi> subscriptions;
        private readonly Lazy<ITeamApi> team;
        private readonly Lazy<ITerminalApi> terminal;

        /// <summary>
        /// Provides access to MobileAuthorizationApi.
        /// </summary>
        public IMobileAuthorizationApi MobileAuthorizationApi => mobileAuthorization.Value;

        /// <summary>
        /// Provides access to OAuthApi.
        /// </summary>
        public IOAuthApi OAuthApi => oAuth.Value;

        /// <summary>
        /// Provides access to V1EmployeesApi.
        /// </summary>
        public IV1EmployeesApi V1EmployeesApi => v1Employees.Value;

        /// <summary>
        /// Provides access to V1TransactionsApi.
        /// </summary>
        public IV1TransactionsApi V1TransactionsApi => v1Transactions.Value;

        /// <summary>
        /// Provides access to ApplePayApi.
        /// </summary>
        public IApplePayApi ApplePayApi => applePay.Value;

        /// <summary>
        /// Provides access to BankAccountsApi.
        /// </summary>
        public IBankAccountsApi BankAccountsApi => bankAccounts.Value;

        /// <summary>
        /// Provides access to BookingsApi.
        /// </summary>
        public IBookingsApi BookingsApi => bookings.Value;

        /// <summary>
        /// Provides access to CashDrawersApi.
        /// </summary>
        public ICashDrawersApi CashDrawersApi => cashDrawers.Value;

        /// <summary>
        /// Provides access to CatalogApi.
        /// </summary>
        public ICatalogApi CatalogApi => catalog.Value;

        /// <summary>
        /// Provides access to CustomersApi.
        /// </summary>
        public ICustomersApi CustomersApi => customers.Value;

        /// <summary>
        /// Provides access to CustomerGroupsApi.
        /// </summary>
        public ICustomerGroupsApi CustomerGroupsApi => customerGroups.Value;

        /// <summary>
        /// Provides access to CustomerSegmentsApi.
        /// </summary>
        public ICustomerSegmentsApi CustomerSegmentsApi => customerSegments.Value;

        /// <summary>
        /// Provides access to DevicesApi.
        /// </summary>
        public IDevicesApi DevicesApi => devices.Value;

        /// <summary>
        /// Provides access to DisputesApi.
        /// </summary>
        public IDisputesApi DisputesApi => disputes.Value;

        /// <summary>
        /// Provides access to EmployeesApi.
        /// </summary>
        public IEmployeesApi EmployeesApi => employees.Value;

        /// <summary>
        /// Provides access to InventoryApi.
        /// </summary>
        public IInventoryApi InventoryApi => inventory.Value;

        /// <summary>
        /// Provides access to InvoicesApi.
        /// </summary>
        public IInvoicesApi InvoicesApi => invoices.Value;

        /// <summary>
        /// Provides access to LaborApi.
        /// </summary>
        public ILaborApi LaborApi => labor.Value;

        /// <summary>
        /// Provides access to LocationsApi.
        /// </summary>
        public ILocationsApi LocationsApi => locations.Value;

        /// <summary>
        /// Provides access to CheckoutApi.
        /// </summary>
        public ICheckoutApi CheckoutApi => checkout.Value;

        /// <summary>
        /// Provides access to TransactionsApi.
        /// </summary>
        public ITransactionsApi TransactionsApi => transactions.Value;

        /// <summary>
        /// Provides access to LoyaltyApi.
        /// </summary>
        public ILoyaltyApi LoyaltyApi => loyalty.Value;

        /// <summary>
        /// Provides access to MerchantsApi.
        /// </summary>
        public IMerchantsApi MerchantsApi => merchants.Value;

        /// <summary>
        /// Provides access to OrdersApi.
        /// </summary>
        public IOrdersApi OrdersApi => orders.Value;

        /// <summary>
        /// Provides access to PaymentsApi.
        /// </summary>
        public IPaymentsApi PaymentsApi => payments.Value;

        /// <summary>
        /// Provides access to RefundsApi.
        /// </summary>
        public IRefundsApi RefundsApi => refunds.Value;

        /// <summary>
        /// Provides access to SubscriptionsApi.
        /// </summary>
        public ISubscriptionsApi SubscriptionsApi => subscriptions.Value;

        /// <summary>
        /// Provides access to TeamApi.
        /// </summary>
        public ITeamApi TeamApi => team.Value;

        /// <summary>
        /// Provides access to TerminalApi.
        /// </summary>
        public ITerminalApi TerminalApi => terminal.Value;

        /// <summary>
        /// Provides access to Additional headers.
        /// </summary>
        public IDictionary<string, List<string>> AdditionalHeaders => additionalHeaders.ToDictionary(s => s.Key, s => new List<string>(s.Value));

        /// <summary>
        /// Current version of the SDK.
        /// </summary>
        public string SdkVersion => "9.0.0";

        internal static SquareClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string timeout = System.Environment.GetEnvironmentVariable("SQUARE_TIMEOUT");
            string squareVersion = System.Environment.GetEnvironmentVariable("SQUARE_SQUARE_VERSION");
            string environment = System.Environment.GetEnvironmentVariable("SQUARE_ENVIRONMENT");
            string customUrl = System.Environment.GetEnvironmentVariable("SQUARE_CUSTOM_URL");
            string accessToken = System.Environment.GetEnvironmentVariable("SQUARE_ACCESS_TOKEN");

            if (timeout != null)
            {
                builder.Timeout(TimeSpan.Parse(timeout));
            }

            if (squareVersion != null)
            {
                builder.SquareVersion(squareVersion);
            }

            if (environment != null)
            {
                builder.Environment(EnvironmentHelper.ParseString(environment));
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

        private SquareClient(TimeSpan timeout, string squareVersion, Environment environment,
                string customUrl, string accessToken, IDictionary<string, IAuthManager> authManagers,
                IHttpClient httpClient, HttpCallBack httpCallBack,
                IDictionary<string, List<string>> additionalHeaders,
                IHttpClientConfiguration httpClientConfiguration)
        {
            Timeout = timeout;
            SquareVersion = squareVersion;
            Environment = environment;
            CustomUrl = customUrl;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.additionalHeaders = additionalHeaders;
            HttpClientConfiguration = httpClientConfiguration;

            mobileAuthorization = new Lazy<IMobileAuthorizationApi>(
                () => new MobileAuthorizationApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            oAuth = new Lazy<IOAuthApi>(
                () => new OAuthApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            v1Employees = new Lazy<IV1EmployeesApi>(
                () => new V1EmployeesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            v1Transactions = new Lazy<IV1TransactionsApi>(
                () => new V1TransactionsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            applePay = new Lazy<IApplePayApi>(
                () => new ApplePayApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            bankAccounts = new Lazy<IBankAccountsApi>(
                () => new BankAccountsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            bookings = new Lazy<IBookingsApi>(
                () => new BookingsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            cashDrawers = new Lazy<ICashDrawersApi>(
                () => new CashDrawersApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            catalog = new Lazy<ICatalogApi>(
                () => new CatalogApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            customers = new Lazy<ICustomersApi>(
                () => new CustomersApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            customerGroups = new Lazy<ICustomerGroupsApi>(
                () => new CustomerGroupsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            customerSegments = new Lazy<ICustomerSegmentsApi>(
                () => new CustomerSegmentsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            devices = new Lazy<IDevicesApi>(
                () => new DevicesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            disputes = new Lazy<IDisputesApi>(
                () => new DisputesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            employees = new Lazy<IEmployeesApi>(
                () => new EmployeesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            inventory = new Lazy<IInventoryApi>(
                () => new InventoryApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            invoices = new Lazy<IInvoicesApi>(
                () => new InvoicesApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            labor = new Lazy<ILaborApi>(
                () => new LaborApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            locations = new Lazy<ILocationsApi>(
                () => new LocationsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            checkout = new Lazy<ICheckoutApi>(
                () => new CheckoutApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            transactions = new Lazy<ITransactionsApi>(
                () => new TransactionsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            loyalty = new Lazy<ILoyaltyApi>(
                () => new LoyaltyApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            merchants = new Lazy<IMerchantsApi>(
                () => new MerchantsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            orders = new Lazy<IOrdersApi>(
                () => new OrdersApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            payments = new Lazy<IPaymentsApi>(
                () => new PaymentsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            refunds = new Lazy<IRefundsApi>(
                () => new RefundsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            subscriptions = new Lazy<ISubscriptionsApi>(
                () => new SubscriptionsApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            team = new Lazy<ITeamApi>(
                () => new TeamApi(this, this.httpClient, this.authManagers, this.httpCallBack));
            terminal = new Lazy<ITerminalApi>(
                () => new TerminalApi(this, this.httpClient, this.authManagers, this.httpCallBack));

            if (this.authManagers.ContainsKey("global"))
            {
                accessTokenManager = (AccessTokenManager) this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !AccessTokenCredentials.Equals(accessToken))
            {
                accessTokenManager = new AccessTokenManager(accessToken);
                this.authManagers["global"] = accessTokenManager;
            }
        }

        /// <summary>
        /// The configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// The credentials to use with AccessToken
        /// </summary>
        private IAccessTokenCredentials AccessTokenCredentials { get => accessTokenManager; }

        /// <summary>
        /// Access token to use with OAuth 2 authentication.
        /// </summary>
        public string AccessToken { get => AccessTokenCredentials.AccessToken; }

        /// <summary>
        /// Http client timeout
        /// </summary>
        public TimeSpan Timeout { get; }

        /// <summary>
        /// Square Connect API versions
        /// </summary>
        public string SquareVersion { get; }

        /// <summary>
        /// Current API environment
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Sets the base URL requests are made to. Defaults to `https://connect.squareup.com`
        /// </summary>
        public string CustomUrl { get; }

        //A map of environments and their corresponding servers/baseurls
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

        /// <summary>
        /// Makes a list of the BaseURL parameters 
        /// </summary>
        /// <return>Returns the parameters list</return>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("custom_url", CustomUrl),
            };
            return kvpList;
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends 
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(Url, GetBaseUriParameters());
            return Url.ToString();
        }

        /// <summary>
        /// Creates an object of the SquareClient using the values provided for the builder.
        /// </summary>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Timeout(Timeout)
                .SquareVersion(SquareVersion)
                .Environment(Environment)
                .CustomUrl(CustomUrl)
                .AccessToken(AccessTokenCredentials.AccessToken)
                .AdditionalHeaders(additionalHeaders)
                .HttpCallBack(httpCallBack)
                .HttpClient(httpClient)
                .AuthManagers(authManagers);

            return builder;
        }

        public override string ToString()
        {
            return
                $"SquareVersion = {SquareVersion}, " +
                $"Environment = {Environment}, " +
                $"CustomUrl = {CustomUrl}, " +
                $"additionalHeaders = {ApiHelper.JsonSerialize(additionalHeaders)}, " +
                $"HttpClientConfiguration = {HttpClientConfiguration}, ";
        }

        public class Builder
        {
            private TimeSpan timeout = TimeSpan.FromSeconds(60);
            private string squareVersion = "2021-02-26";
            private Environment environment = Square.Environment.Production;
            private string customUrl = "https://connect.squareup.com";
            private string accessToken = "TODO: Replace";
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private bool createCustomHttpClient = false;
            private HttpClientConfiguration httpClientConfig = new HttpClientConfiguration();
            private IHttpClient httpClient;
            private HttpCallBack httpCallBack;
            private IDictionary<string, List<string>> additionalHeaders = new Dictionary<string, List<string>>();

            /// <summary>
            /// Credentials setter for AccessToken
            /// </summary>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                return this;
            }

            /// <summary>
            /// Setter for SquareVersion.
            /// </summary>
            public Builder SquareVersion(string squareVersion)
            {
                this.squareVersion = squareVersion ?? throw new ArgumentNullException(nameof(squareVersion));
                return this;
            }

            /// <summary>
            /// Setter for Environment.
            /// </summary>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Setter for CustomUrl.
            /// </summary>
            public Builder CustomUrl(string customUrl)
            {
                this.customUrl = customUrl ?? throw new ArgumentNullException(nameof(customUrl));
                return this;
            }

            /// <summary>
            /// Setter for Timeout.
            /// </summary>
            public Builder Timeout(TimeSpan timeout)
            {
                httpClientConfig.Timeout = timeout.TotalSeconds <= 0 ? TimeSpan.FromSeconds(60) : timeout;
                this.createCustomHttpClient = true;
                return this;
            }

            /// <summary>
            /// Sets the AdditionalHeaders for the Builder.
            /// </summary>
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

                if (additionalHeaders.ContainsKey(headerName) && additionalHeaders[headerName] != null)
                {
                    additionalHeaders[headerName].Add(headerValue);
                }
                else
                {
                    additionalHeaders[headerName] = new List<string>() { headerValue };
                }

                return this;
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the SquareClient using the values provided for the builder.
            /// </summary>
            public SquareClient Build()
            {
                if (createCustomHttpClient) 
                {
                    httpClient = new HttpClientWrapper(httpClientConfig);
                } 
                else 
                {
                    httpClient = new HttpClientWrapper();
                }

                return new SquareClient(timeout, squareVersion, environment, customUrl, accessToken, authManagers, httpClient,
                        httpCallBack, additionalHeaders, httpClientConfig);
            }
        }

    }
}
