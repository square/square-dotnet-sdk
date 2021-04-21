namespace Square
{
    using System;
    using Square.Apis;

    /// <summary>
    /// ISquareClient.
    /// </summary>
    public interface ISquareClient : IConfiguration
    {
        /// <summary>
        /// Gets instance for IMobileAuthorizationApi.
        /// </summary>
        IMobileAuthorizationApi MobileAuthorizationApi { get; }

        /// <summary>
        /// Gets instance for IOAuthApi.
        /// </summary>
        IOAuthApi OAuthApi { get; }

        /// <summary>
        /// Gets instance for IV1EmployeesApi.
        /// </summary>
        IV1EmployeesApi V1EmployeesApi { get; }

        /// <summary>
        /// Gets instance for IV1TransactionsApi.
        /// </summary>
        IV1TransactionsApi V1TransactionsApi { get; }

        /// <summary>
        /// Gets instance for IApplePayApi.
        /// </summary>
        IApplePayApi ApplePayApi { get; }

        /// <summary>
        /// Gets instance for IBankAccountsApi.
        /// </summary>
        IBankAccountsApi BankAccountsApi { get; }

        /// <summary>
        /// Gets instance for IBookingsApi.
        /// </summary>
        IBookingsApi BookingsApi { get; }

        /// <summary>
        /// Gets instance for ICashDrawersApi.
        /// </summary>
        ICashDrawersApi CashDrawersApi { get; }

        /// <summary>
        /// Gets instance for ICatalogApi.
        /// </summary>
        ICatalogApi CatalogApi { get; }

        /// <summary>
        /// Gets instance for ICustomersApi.
        /// </summary>
        ICustomersApi CustomersApi { get; }

        /// <summary>
        /// Gets instance for ICustomerGroupsApi.
        /// </summary>
        ICustomerGroupsApi CustomerGroupsApi { get; }

        /// <summary>
        /// Gets instance for ICustomerSegmentsApi.
        /// </summary>
        ICustomerSegmentsApi CustomerSegmentsApi { get; }

        /// <summary>
        /// Gets instance for IDevicesApi.
        /// </summary>
        IDevicesApi DevicesApi { get; }

        /// <summary>
        /// Gets instance for IDisputesApi.
        /// </summary>
        IDisputesApi DisputesApi { get; }

        /// <summary>
        /// Gets instance for IEmployeesApi.
        /// </summary>
        IEmployeesApi EmployeesApi { get; }

        /// <summary>
        /// Gets instance for IInventoryApi.
        /// </summary>
        IInventoryApi InventoryApi { get; }

        /// <summary>
        /// Gets instance for IInvoicesApi.
        /// </summary>
        IInvoicesApi InvoicesApi { get; }

        /// <summary>
        /// Gets instance for ILaborApi.
        /// </summary>
        ILaborApi LaborApi { get; }

        /// <summary>
        /// Gets instance for ILocationsApi.
        /// </summary>
        ILocationsApi LocationsApi { get; }

        /// <summary>
        /// Gets instance for ICheckoutApi.
        /// </summary>
        ICheckoutApi CheckoutApi { get; }

        /// <summary>
        /// Gets instance for ITransactionsApi.
        /// </summary>
        ITransactionsApi TransactionsApi { get; }

        /// <summary>
        /// Gets instance for ILoyaltyApi.
        /// </summary>
        ILoyaltyApi LoyaltyApi { get; }

        /// <summary>
        /// Gets instance for IMerchantsApi.
        /// </summary>
        IMerchantsApi MerchantsApi { get; }

        /// <summary>
        /// Gets instance for IOrdersApi.
        /// </summary>
        IOrdersApi OrdersApi { get; }

        /// <summary>
        /// Gets instance for IPaymentsApi.
        /// </summary>
        IPaymentsApi PaymentsApi { get; }

        /// <summary>
        /// Gets instance for IRefundsApi.
        /// </summary>
        IRefundsApi RefundsApi { get; }

        /// <summary>
        /// Gets instance for ISubscriptionsApi.
        /// </summary>
        ISubscriptionsApi SubscriptionsApi { get; }

        /// <summary>
        /// Gets instance for ITeamApi.
        /// </summary>
        ITeamApi TeamApi { get; }

        /// <summary>
        /// Gets instance for ITerminalApi.
        /// </summary>
        ITerminalApi TerminalApi { get; }

        /// <summary>
        /// Gets the current version of the SDK.
        /// </summary>
        string SdkVersion { get; }
    }
}