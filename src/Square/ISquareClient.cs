using Square.ApplePay;
using Square.BankAccounts;
using Square.Bookings;
using Square.CashDrawers;
using Square.Catalog;
using Square.Channels;
using Square.Checkout;
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
using Square.OAuth;
using Square.Orders;
using Square.Payments;
using Square.Payouts;
using Square.Sites;
using Square.Snippets;
using Square.Team;
using Square.TeamMembers;
using Square.Terminal;
using Square.TransferOrders;
using Square.V1Transactions;
using Square.Vendors;
using Square.Webhooks;

namespace Square;

public partial interface ISquareClient
{
    public OAuthClient OAuth { get; }
    public V1TransactionsClient V1Transactions { get; }
    public ApplePayClient ApplePay { get; }
    public BankAccountsClient BankAccounts { get; }
    public BookingsClient Bookings { get; }
    public Square.Cards.CardsClient Cards { get; }
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
    public Square.Refunds.RefundsClient Refunds { get; }
    public SitesClient Sites { get; }
    public SnippetsClient Snippets { get; }
    public Square.Subscriptions.SubscriptionsClient Subscriptions { get; }
    public TeamMembersClient TeamMembers { get; }
    public TeamClient Team { get; }
    public TerminalClient Terminal { get; }
    public TransferOrdersClient TransferOrders { get; }
    public VendorsClient Vendors { get; }
    public CashDrawersClient CashDrawers { get; }
    public WebhooksClient Webhooks { get; }
}
