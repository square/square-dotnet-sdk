using Square.Default.CashDrawers;
using Square.Default.Webhooks;

namespace Square.Default;

public partial interface IDefaultClient
{
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
