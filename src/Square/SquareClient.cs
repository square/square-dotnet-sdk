using Square.ApplePay;
using Square.BankAccounts;
using Square.Bookings;
using Square.Cards;
using Square.CashDrawers;
using Square.Catalog;
using Square.Checkout;
using Square.Core;
using Square.Customers;
using Square.Devices;
using Square.Disputes;
using Square.Employees;
using Square.Events;
using Square.GiftCards;
using Square.Inventory;
using Square.Invoices;
using Square.Labor;
using Square.Locations;
using Square.Loyalty;
using Square.Merchants;
using Square.Mobile;
using Square.OAuth;
using Square.Orders;
using Square.Payments;
using Square.Payouts;
using Square.Refunds;
using Square.Sites;
using Square.Snippets;
using Square.Subscriptions;
using Square.Team;
using Square.TeamMembers;
using Square.Terminal;
using Square.V1Transactions;
using Square.Vendors;
using Square.Webhooks;

namespace Square;

public partial class SquareClient
{
    private readonly RawClient _client;

    public SquareClient(string? token = null, ClientOptions? clientOptions = null)
    {
        token ??= GetFromEnvironmentOrThrow(
            "SQUARE_TOKEN",
            "Please pass in token or set the environment variable SQUARE_TOKEN."
        );
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "Authorization", $"Bearer {token}" },
                { "Square-Version", "2025-03-19" },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Square" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "Square/41.0.0" },
            }
        );
        clientOptions ??= new ClientOptions();
        if (clientOptions.Version != null)
        {
            defaultHeaders["Square-Version"] = clientOptions.Version;
        }
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
        Mobile = new MobileClient(_client);
        OAuth = new OAuthClient(_client);
        V1Transactions = new V1TransactionsClient(_client);
        ApplePay = new ApplePayClient(_client);
        BankAccounts = new BankAccountsClient(_client);
        Bookings = new BookingsClient(_client);
        Cards = new CardsClient(_client);
        Catalog = new CatalogClient(_client);
        Customers = new CustomersClient(_client);
        Devices = new DevicesClient(_client);
        Disputes = new DisputesClient(_client);
        Employees = new EmployeesClient(_client);
        Events = new EventsClient(_client);
        GiftCards = new GiftCardsClient(_client);
        Inventory = new InventoryClient(_client);
        Invoices = new InvoicesClient(_client);
        Locations = new LocationsClient(_client);
        Loyalty = new LoyaltyClient(_client);
        Merchants = new MerchantsClient(_client);
        Checkout = new CheckoutClient(_client);
        Orders = new OrdersClient(_client);
        Payments = new PaymentsClient(_client);
        Payouts = new PayoutsClient(_client);
        Refunds = new RefundsClient(_client);
        Sites = new SitesClient(_client);
        Snippets = new SnippetsClient(_client);
        Subscriptions = new SubscriptionsClient(_client);
        TeamMembers = new TeamMembersClient(_client);
        Team = new TeamClient(_client);
        Terminal = new TerminalClient(_client);
        Vendors = new VendorsClient(_client);
        CashDrawers = new CashDrawersClient(_client);
        Labor = new LaborClient(_client);
        Webhooks = new WebhooksClient(_client);
    }

    public MobileClient Mobile { get; init; }

    public OAuthClient OAuth { get; init; }

    public V1TransactionsClient V1Transactions { get; init; }

    public ApplePayClient ApplePay { get; init; }

    public BankAccountsClient BankAccounts { get; init; }

    public BookingsClient Bookings { get; init; }

    public CardsClient Cards { get; init; }

    public CatalogClient Catalog { get; init; }

    public CustomersClient Customers { get; init; }

    public DevicesClient Devices { get; init; }

    public DisputesClient Disputes { get; init; }

    public EmployeesClient Employees { get; init; }

    public EventsClient Events { get; init; }

    public GiftCardsClient GiftCards { get; init; }

    public InventoryClient Inventory { get; init; }

    public InvoicesClient Invoices { get; init; }

    public LocationsClient Locations { get; init; }

    public LoyaltyClient Loyalty { get; init; }

    public MerchantsClient Merchants { get; init; }

    public CheckoutClient Checkout { get; init; }

    public OrdersClient Orders { get; init; }

    public PaymentsClient Payments { get; init; }

    public PayoutsClient Payouts { get; init; }

    public RefundsClient Refunds { get; init; }

    public SitesClient Sites { get; init; }

    public SnippetsClient Snippets { get; init; }

    public SubscriptionsClient Subscriptions { get; init; }

    public TeamMembersClient TeamMembers { get; init; }

    public TeamClient Team { get; init; }

    public TerminalClient Terminal { get; init; }

    public VendorsClient Vendors { get; init; }

    public CashDrawersClient CashDrawers { get; init; }

    public LaborClient Labor { get; init; }

    public WebhooksClient Webhooks { get; init; }

    private static string GetFromEnvironmentOrThrow(string env, string message)
    {
        return Environment.GetEnvironmentVariable(env) ?? throw new Exception(message);
    }
}
