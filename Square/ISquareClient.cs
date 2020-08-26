using System;
using Square.Apis;

namespace Square
{
    public interface ISquareClient : IConfiguration
    {
        /// <summary>
        /// Instance for IMobileAuthorizationApi
        /// </summary>
        IMobileAuthorizationApi MobileAuthorizationApi { get; }

        /// <summary>
        /// Instance for IOAuthApi
        /// </summary>
        IOAuthApi OAuthApi { get; }

        /// <summary>
        /// Instance for IV1LocationsApi
        /// </summary>
        IV1LocationsApi V1LocationsApi { get; }

        /// <summary>
        /// Instance for IV1EmployeesApi
        /// </summary>
        IV1EmployeesApi V1EmployeesApi { get; }

        /// <summary>
        /// Instance for IV1TransactionsApi
        /// </summary>
        IV1TransactionsApi V1TransactionsApi { get; }

        /// <summary>
        /// Instance for IV1ItemsApi
        /// </summary>
        IV1ItemsApi V1ItemsApi { get; }

        /// <summary>
        /// Instance for IApplePayApi
        /// </summary>
        IApplePayApi ApplePayApi { get; }

        /// <summary>
        /// Instance for IBankAccountsApi
        /// </summary>
        IBankAccountsApi BankAccountsApi { get; }

        /// <summary>
        /// Instance for ICashDrawersApi
        /// </summary>
        ICashDrawersApi CashDrawersApi { get; }

        /// <summary>
        /// Instance for ICatalogApi
        /// </summary>
        ICatalogApi CatalogApi { get; }

        /// <summary>
        /// Instance for ICustomersApi
        /// </summary>
        ICustomersApi CustomersApi { get; }

        /// <summary>
        /// Instance for ICustomerGroupsApi
        /// </summary>
        ICustomerGroupsApi CustomerGroupsApi { get; }

        /// <summary>
        /// Instance for ICustomerSegmentsApi
        /// </summary>
        ICustomerSegmentsApi CustomerSegmentsApi { get; }

        /// <summary>
        /// Instance for IDevicesApi
        /// </summary>
        IDevicesApi DevicesApi { get; }

        /// <summary>
        /// Instance for IDisputesApi
        /// </summary>
        IDisputesApi DisputesApi { get; }

        /// <summary>
        /// Instance for IEmployeesApi
        /// </summary>
        IEmployeesApi EmployeesApi { get; }

        /// <summary>
        /// Instance for IInventoryApi
        /// </summary>
        IInventoryApi InventoryApi { get; }

        /// <summary>
        /// Instance for IInvoicesApi
        /// </summary>
        IInvoicesApi InvoicesApi { get; }

        /// <summary>
        /// Instance for ILaborApi
        /// </summary>
        ILaborApi LaborApi { get; }

        /// <summary>
        /// Instance for ILocationsApi
        /// </summary>
        ILocationsApi LocationsApi { get; }

        /// <summary>
        /// Instance for ICheckoutApi
        /// </summary>
        ICheckoutApi CheckoutApi { get; }

        /// <summary>
        /// Instance for ITransactionsApi
        /// </summary>
        ITransactionsApi TransactionsApi { get; }

        /// <summary>
        /// Instance for ILoyaltyApi
        /// </summary>
        ILoyaltyApi LoyaltyApi { get; }

        /// <summary>
        /// Instance for IMerchantsApi
        /// </summary>
        IMerchantsApi MerchantsApi { get; }

        /// <summary>
        /// Instance for IOrdersApi
        /// </summary>
        IOrdersApi OrdersApi { get; }

        /// <summary>
        /// Instance for IPaymentsApi
        /// </summary>
        IPaymentsApi PaymentsApi { get; }

        /// <summary>
        /// Instance for IRefundsApi
        /// </summary>
        IRefundsApi RefundsApi { get; }

        /// <summary>
        /// Instance for ISubscriptionsApi
        /// </summary>
        ISubscriptionsApi SubscriptionsApi { get; }

        /// <summary>
        /// Instance for ITeamApi
        /// </summary>
        ITeamApi TeamApi { get; }

        /// <summary>
        /// Instance for ITerminalApi
        /// </summary>
        ITerminalApi TerminalApi { get; }

        /// <summary>
        /// Current version of the SDK
        /// </summary>
        string SdkVersion { get; }
    }
}