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
    public sealed class SquareClient : ISquareClient
    {
        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IDictionary<string, List<string>> additionalHeaders;
        private readonly AccessTokenManager accessTokenManager;
        private readonly IHttpClient httpClient;
        private readonly HttpCallBack httpCallBack;
        private readonly Lazy<IMobileAuthorizationApi> mobileAuthorization;
        private readonly Lazy<IOAuthApi> oAuth;
        private readonly Lazy<IV1LocationsApi> v1Locations;
        private readonly Lazy<IV1EmployeesApi> v1Employees;
        private readonly Lazy<IV1TransactionsApi> v1Transactions;
        private readonly Lazy<IV1ItemsApi> v1Items;
        private readonly Lazy<IApplePayApi> applePay;
        private readonly Lazy<IBankAccountsApi> bankAccounts;
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
        /// Provides access to MobileAuthorizationApi controller
        /// </summary>
        public IMobileAuthorizationApi MobileAuthorizationApi => mobileAuthorization.Value;

        /// <summary>
        /// Provides access to OAuthApi controller
        /// </summary>
        public IOAuthApi OAuthApi => oAuth.Value;

        /// <summary>
        /// Provides access to V1LocationsApi controller
        /// </summary>
        public IV1LocationsApi V1LocationsApi => v1Locations.Value;

        /// <summary>
        /// Provides access to V1EmployeesApi controller
        /// </summary>
        public IV1EmployeesApi V1EmployeesApi => v1Employees.Value;

        /// <summary>
        /// Provides access to V1TransactionsApi controller
        /// </summary>
        public IV1TransactionsApi V1TransactionsApi => v1Transactions.Value;

        /// <summary>
        /// Provides access to V1ItemsApi controller
        /// </summary>
        public IV1ItemsApi V1ItemsApi => v1Items.Value;

        /// <summary>
        /// Provides access to ApplePayApi controller
        /// </summary>
        public IApplePayApi ApplePayApi => applePay.Value;

        /// <summary>
        /// Provides access to BankAccountsApi controller
        /// </summary>
        public IBankAccountsApi BankAccountsApi => bankAccounts.Value;

        /// <summary>
        /// Provides access to CashDrawersApi controller
        /// </summary>
        public ICashDrawersApi CashDrawersApi => cashDrawers.Value;

        /// <summary>
        /// Provides access to CatalogApi controller
        /// </summary>
        public ICatalogApi CatalogApi => catalog.Value;

        /// <summary>
        /// Provides access to CustomersApi controller
        /// </summary>
        public ICustomersApi CustomersApi => customers.Value;

        /// <summary>
        /// Provides access to CustomerGroupsApi controller
        /// </summary>
        public ICustomerGroupsApi CustomerGroupsApi => customerGroups.Value;

        /// <summary>
        /// Provides access to CustomerSegmentsApi controller
        /// </summary>
        public ICustomerSegmentsApi CustomerSegmentsApi => customerSegments.Value;

        /// <summary>
        /// Provides access to DevicesApi controller
        /// </summary>
        public IDevicesApi DevicesApi => devices.Value;

        /// <summary>
        /// Provides access to DisputesApi controller
        /// </summary>
        public IDisputesApi DisputesApi => disputes.Value;

        /// <summary>
        /// Provides access to EmployeesApi controller
        /// </summary>
        public IEmployeesApi EmployeesApi => employees.Value;

        /// <summary>
        /// Provides access to InventoryApi controller
        /// </summary>
        public IInventoryApi InventoryApi => inventory.Value;

        /// <summary>
        /// Provides access to InvoicesApi controller
        /// </summary>
        public IInvoicesApi InvoicesApi => invoices.Value;

        /// <summary>
        /// Provides access to LaborApi controller
        /// </summary>
        public ILaborApi LaborApi => labor.Value;

        /// <summary>
        /// Provides access to LocationsApi controller
        /// </summary>
        public ILocationsApi LocationsApi => locations.Value;

        /// <summary>
        /// Provides access to CheckoutApi controller
        /// </summary>
        public ICheckoutApi CheckoutApi => checkout.Value;

        /// <summary>
        /// Provides access to TransactionsApi controller
        /// </summary>
        public ITransactionsApi TransactionsApi => transactions.Value;

        /// <summary>
        /// Provides access to LoyaltyApi controller
        /// </summary>
        public ILoyaltyApi LoyaltyApi => loyalty.Value;

        /// <summary>
        /// Provides access to MerchantsApi controller
        /// </summary>
        public IMerchantsApi MerchantsApi => merchants.Value;

        /// <summary>
        /// Provides access to OrdersApi controller
        /// </summary>
        public IOrdersApi OrdersApi => orders.Value;

        /// <summary>
        /// Provides access to PaymentsApi controller
        /// </summary>
        public IPaymentsApi PaymentsApi => payments.Value;

        /// <summary>
        /// Provides access to RefundsApi controller
        /// </summary>
        public IRefundsApi RefundsApi => refunds.Value;

        /// <summary>
        /// Provides access to SubscriptionsApi controller
        /// </summary>
        public ISubscriptionsApi SubscriptionsApi => subscriptions.Value;

        /// <summary>
        /// Provides access to TeamApi controller
        /// </summary>
        public ITeamApi TeamApi => team.Value;

        /// <summary>
        /// Provides access to TerminalApi controller
        /// </summary>
        public ITerminalApi TerminalApi => terminal.Value;

        /// <summary>
        /// Provides access to Additional headers
        /// </summary>
        public IDictionary<string, List<string>> AdditionalHeaders => additionalHeaders.ToDictionary(s => s.Key, s => new List<string>(s.Value));

        /// <summary>
        /// Current version of the SDK
        /// </summary>
        public string SdkVersion => "6.3.0";

        internal static SquareClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string timeout = System.Environment.GetEnvironmentVariable("SQUARE_TIMEOUT");
            string squareVersion = System.Environment.GetEnvironmentVariable("SQUARE_SQUARE_VERSION");
            string accessToken = System.Environment.GetEnvironmentVariable("SQUARE_ACCESS_TOKEN");
            string environment = System.Environment.GetEnvironmentVariable("SQUARE_ENVIRONMENT");

            if (timeout != null)
            {
                builder.Timeout(TimeSpan.Parse(timeout));
            }

            if (squareVersion != null)
            {
                builder.SquareVersion(squareVersion);
            }

            if (accessToken != null)
            {
                builder.AccessToken(accessToken);
            }

            if (environment != null)
            {
                builder.Environment(EnvironmentHelper.ParseString(environment));
            }

            return builder.Build();
        }

        private SquareClient(TimeSpan timeout, string squareVersion, string accessToken,
                Environment environment, IDictionary<string, IAuthManager> authManagers,
                IHttpClient httpClient, HttpCallBack httpCallBack,
                IDictionary<string, List<string>> additionalHeaders,
                IHttpClientConfiguration httpClientConfiguration)
        {
            Timeout = timeout;
            SquareVersion = squareVersion;
            AccessToken = accessToken;
            Environment = environment;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = new Dictionary<string, IAuthManager>(authManagers);
            accessTokenManager = new AccessTokenManager(accessToken);
            this.additionalHeaders = additionalHeaders;                HttpClientConfiguration = httpClientConfiguration;

            mobileAuthorization = new Lazy<IMobileAuthorizationApi>(
                () => new MobileAuthorizationApi(this, this.httpClient, authManagers, this.httpCallBack));
            oAuth = new Lazy<IOAuthApi>(
                () => new OAuthApi(this, this.httpClient, authManagers, this.httpCallBack));
            v1Locations = new Lazy<IV1LocationsApi>(
                () => new V1LocationsApi(this, this.httpClient, authManagers, this.httpCallBack));
            v1Employees = new Lazy<IV1EmployeesApi>(
                () => new V1EmployeesApi(this, this.httpClient, authManagers, this.httpCallBack));
            v1Transactions = new Lazy<IV1TransactionsApi>(
                () => new V1TransactionsApi(this, this.httpClient, authManagers, this.httpCallBack));
            v1Items = new Lazy<IV1ItemsApi>(
                () => new V1ItemsApi(this, this.httpClient, authManagers, this.httpCallBack));
            applePay = new Lazy<IApplePayApi>(
                () => new ApplePayApi(this, this.httpClient, authManagers, this.httpCallBack));
            bankAccounts = new Lazy<IBankAccountsApi>(
                () => new BankAccountsApi(this, this.httpClient, authManagers, this.httpCallBack));
            cashDrawers = new Lazy<ICashDrawersApi>(
                () => new CashDrawersApi(this, this.httpClient, authManagers, this.httpCallBack));
            catalog = new Lazy<ICatalogApi>(
                () => new CatalogApi(this, this.httpClient, authManagers, this.httpCallBack));
            customers = new Lazy<ICustomersApi>(
                () => new CustomersApi(this, this.httpClient, authManagers, this.httpCallBack));
            customerGroups = new Lazy<ICustomerGroupsApi>(
                () => new CustomerGroupsApi(this, this.httpClient, authManagers, this.httpCallBack));
            customerSegments = new Lazy<ICustomerSegmentsApi>(
                () => new CustomerSegmentsApi(this, this.httpClient, authManagers, this.httpCallBack));
            devices = new Lazy<IDevicesApi>(
                () => new DevicesApi(this, this.httpClient, authManagers, this.httpCallBack));
            disputes = new Lazy<IDisputesApi>(
                () => new DisputesApi(this, this.httpClient, authManagers, this.httpCallBack));
            employees = new Lazy<IEmployeesApi>(
                () => new EmployeesApi(this, this.httpClient, authManagers, this.httpCallBack));
            inventory = new Lazy<IInventoryApi>(
                () => new InventoryApi(this, this.httpClient, authManagers, this.httpCallBack));
            invoices = new Lazy<IInvoicesApi>(
                () => new InvoicesApi(this, this.httpClient, authManagers, this.httpCallBack));
            labor = new Lazy<ILaborApi>(
                () => new LaborApi(this, this.httpClient, authManagers, this.httpCallBack));
            locations = new Lazy<ILocationsApi>(
                () => new LocationsApi(this, this.httpClient, authManagers, this.httpCallBack));
            checkout = new Lazy<ICheckoutApi>(
                () => new CheckoutApi(this, this.httpClient, authManagers, this.httpCallBack));
            transactions = new Lazy<ITransactionsApi>(
                () => new TransactionsApi(this, this.httpClient, authManagers, this.httpCallBack));
            loyalty = new Lazy<ILoyaltyApi>(
                () => new LoyaltyApi(this, this.httpClient, authManagers, this.httpCallBack));
            merchants = new Lazy<IMerchantsApi>(
                () => new MerchantsApi(this, this.httpClient, authManagers, this.httpCallBack));
            orders = new Lazy<IOrdersApi>(
                () => new OrdersApi(this, this.httpClient, authManagers, this.httpCallBack));
            payments = new Lazy<IPaymentsApi>(
                () => new PaymentsApi(this, this.httpClient, authManagers, this.httpCallBack));
            refunds = new Lazy<IRefundsApi>(
                () => new RefundsApi(this, this.httpClient, authManagers, this.httpCallBack));
            subscriptions = new Lazy<ISubscriptionsApi>(
                () => new SubscriptionsApi(this, this.httpClient, authManagers, this.httpCallBack));
            team = new Lazy<ITeamApi>(
                () => new TeamApi(this, this.httpClient, authManagers, this.httpCallBack));
            terminal = new Lazy<ITerminalApi>(
                () => new TerminalApi(this, this.httpClient, authManagers, this.httpCallBack));

            if (!authManagers.ContainsKey("default") ||
                ((AccessTokenManager)authManagers["default"]).AccessToken != accessToken)
            {
                authManagers["default"] = accessTokenManager;
            }
        }

        /// <summary>
        /// The configuration of the Http Client associated with this SquareClient.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Http client timeout
        /// </summary>
        public TimeSpan Timeout { get; }

        /// <summary>
        /// Square Connect API versions
        /// </summary>
        public string SquareVersion { get; }

        /// <summary>
        /// OAuth 2.0 Access Token
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Current API environment
        /// </summary>
        public Environment Environment { get; }

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
        };

        /// <summary>
        /// Makes a list of the BaseURL parameters 
        /// </summary>
        /// <return>Returns the parameters list</return>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(Url, GetBaseUriParameters());
            return Url.ToString();
        }

        public Builder ToBuilder()
        {
            Builder builder = new Builder();
            builder.Timeout(Timeout);
            builder.SquareVersion(SquareVersion);
            builder.AccessToken(AccessToken);
            builder.Environment(Environment);
            builder.AdditionalHeaders(additionalHeaders);
            builder.HttpCallBack(httpCallBack);
            builder.HttpClient(httpClient);
            builder.AuthManagers(authManagers);

            return builder;
        }

        public class Builder
        {
            private TimeSpan timeout = TimeSpan.FromSeconds(60);
            private string squareVersion = "2020-08-26";
            private string accessToken = String.Empty;
            private Environment environment = Square.Environment.Production;
            private IHttpClient httpClient;
            private IDictionary<string, List<string>> additionalHeaders = new Dictionary<string, List<string>>();
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration httpClientConfig = new HttpClientConfiguration();
            private HttpCallBack httpCallBack;
            private bool createCustomHttpClient = false;

            // Setter for SquareVersion
            public Builder SquareVersion(string squareVersion)
            {
                this.squareVersion = squareVersion ?? throw new ArgumentNullException(nameof(squareVersion));
                return this;
            }

            // Setter for AccessToken
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                return this;
            }

            // Setter for Environment
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            // Setter for Timeout
            public Builder Timeout(TimeSpan timeout)
            {
                httpClientConfig.Timeout = timeout.TotalSeconds <= 0 ? TimeSpan.FromSeconds(60) : timeout;
                this.createCustomHttpClient = true;
                return this;
            }

            public Builder AdditionalHeaders(IDictionary<string, List<string>> additionalHeaders)
            {
                if (additionalHeaders is null)
                {
                    throw new ArgumentNullException(nameof(additionalHeaders));
                }

                this.additionalHeaders = additionalHeaders.ToDictionary(s => s.Key, s => new List<string>(s.Value));
                return this;
            }

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

            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

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

                return new SquareClient(timeout, squareVersion, accessToken, environment, authManagers, httpClient, httpCallBack,
                        additionalHeaders, httpClientConfig);
            }
        }

    }
}
