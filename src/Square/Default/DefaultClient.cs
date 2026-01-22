using Square.Core;
using Square.Default.CashDrawers;
using Square.Default.Webhooks;

namespace Square.Default;

public partial class DefaultClient : IDefaultClient
{
    private RawClient _client;

    internal DefaultClient(RawClient client)
    {
        _client = client;
        OAuth = new OAuthClient(_client);
        V1Transactions = new V1TransactionsClient(_client);
        ApplePay = new ApplePayClient(_client);
        BankAccounts = new BankAccountsClient(_client);
        Bookings = new BookingsClient(_client);
        Cards = new CardsClient(_client);
        Catalog = new CatalogClient(_client);
        Channels = new ChannelsClient(_client);
        Customers = new CustomersClient(_client);
        Devices = new DevicesClient(_client);
        Disputes = new DisputesClient(_client);
        Employees = new EmployeesClient(_client);
        Events = new EventsClient(_client);
        GiftCards = new GiftCardsClient(_client);
        Inventory = new InventoryClient(_client);
        Invoices = new InvoicesClient(_client);
        Labor = new LaborClient(_client);
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
        TransferOrders = new TransferOrdersClient(_client);
        Vendors = new VendorsClient(_client);
        CashDrawers = new CashDrawersClient(_client);
        Webhooks = new WebhooksClient(_client);
    }

    public OAuthClient OAuth { get; }

    public V1TransactionsClient V1Transactions { get; }

    public ApplePayClient ApplePay { get; }

    public BankAccountsClient BankAccounts { get; }

    public BookingsClient Bookings { get; }

    public CardsClient Cards { get; }

    public CatalogClient Catalog { get; }

    public ChannelsClient Channels { get; }

    public CustomersClient Customers { get; }

    public DevicesClient Devices { get; }

    public DisputesClient Disputes { get; }

    public EmployeesClient Employees { get; }

    public EventsClient Events { get; }

    public GiftCardsClient GiftCards { get; }

    public InventoryClient Inventory { get; }

    public InvoicesClient Invoices { get; }

    public LaborClient Labor { get; }

    public LocationsClient Locations { get; }

    public LoyaltyClient Loyalty { get; }

    public MerchantsClient Merchants { get; }

    public CheckoutClient Checkout { get; }

    public OrdersClient Orders { get; }

    public PaymentsClient Payments { get; }

    public PayoutsClient Payouts { get; }

    public RefundsClient Refunds { get; }

    public SitesClient Sites { get; }

    public SnippetsClient Snippets { get; }

    public SubscriptionsClient Subscriptions { get; }

    public TeamMembersClient TeamMembers { get; }

    public TeamClient Team { get; }

    public TerminalClient Terminal { get; }

    public TransferOrdersClient TransferOrders { get; }

    public VendorsClient Vendors { get; }

    public CashDrawersClient CashDrawers { get; }

    public WebhooksClient Webhooks { get; }
}
