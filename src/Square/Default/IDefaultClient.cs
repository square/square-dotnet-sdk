using Square.Default.ApplePay;
using Square.Default.BankAccounts;
using Square.Default.Bookings;
using Square.Default.CashDrawers;
using Square.Default.Catalog;
using Square.Default.Channels;
using Square.Default.Checkout;
using Square.Default.Customers;
using Square.Default.Devices;
using Square.Default.Disputes;
using Square.Default.Employees;
using Square.Default.Events;
using Square.Default.GiftCards;
using Square.Default.Inventory;
using Square.Default.Invoices;
using Square.Default.Labor;
using Square.Default.Locations;
using Square.Default.Loyalty;
using Square.Default.Merchants;
using Square.Default.Mobile;
using Square.Default.OAuth;
using Square.Default.Orders;
using Square.Default.Payments;
using Square.Default.Payouts;
using Square.Default.Sites;
using Square.Default.Snippets;
using Square.Default.Team;
using Square.Default.TeamMembers;
using Square.Default.Terminal;
using Square.Default.TransferOrders;
using Square.Default.V1Transactions;
using Square.Default.Vendors;
using Square.Default.Webhooks;

namespace Square.Default;

public partial interface IDefaultClient
{
    public MobileClient Mobile { get; }
    public OAuthClient OAuth { get; }
    public V1TransactionsClient V1Transactions { get; }
    public ApplePayClient ApplePay { get; }
    public BankAccountsClient BankAccounts { get; }
    public BookingsClient Bookings { get; }
    public Square.Default.Cards.CardsClient Cards { get; }
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
    public Square.Default.Refunds.RefundsClient Refunds { get; }
    public SitesClient Sites { get; }
    public SnippetsClient Snippets { get; }
    public Square.Default.Subscriptions.SubscriptionsClient Subscriptions { get; }
    public TeamMembersClient TeamMembers { get; }
    public TeamClient Team { get; }
    public TerminalClient Terminal { get; }
    public TransferOrdersClient TransferOrders { get; }
    public VendorsClient Vendors { get; }
    public CashDrawersClient CashDrawers { get; }
    public WebhooksClient Webhooks { get; }
}
