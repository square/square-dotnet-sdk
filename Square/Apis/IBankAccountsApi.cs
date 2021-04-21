namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Square;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// IBankAccountsApi.
    /// </summary>
    public interface IBankAccountsApi
    {
        /// <summary>
        /// Returns a list of [BankAccount]($m/BankAccount) objects linked to a Square account..
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by a previous call to this endpoint. Use it in the next `ListBankAccounts` request to retrieve the next set  of results.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="limit">Optional parameter: Upper limit on the number of bank accounts to return in the response.  Currently, 1000 is the largest supported limit. You can specify a limit  of up to 1000 bank accounts. This is also the default limit..</param>
        /// <param name="locationId">Optional parameter: Location ID. You can specify this optional filter  to retrieve only the linked bank accounts belonging to a specific location..</param>
        /// <returns>Returns the Models.ListBankAccountsResponse response from the API call.</returns>
        Models.ListBankAccountsResponse ListBankAccounts(
                string cursor = null,
                int? limit = null,
                string locationId = null);

        /// <summary>
        /// Returns a list of [BankAccount]($m/BankAccount) objects linked to a Square account..
        /// </summary>
        /// <param name="cursor">Optional parameter: The pagination cursor returned by a previous call to this endpoint. Use it in the next `ListBankAccounts` request to retrieve the next set  of results.  See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information..</param>
        /// <param name="limit">Optional parameter: Upper limit on the number of bank accounts to return in the response.  Currently, 1000 is the largest supported limit. You can specify a limit  of up to 1000 bank accounts. This is also the default limit..</param>
        /// <param name="locationId">Optional parameter: Location ID. You can specify this optional filter  to retrieve only the linked bank accounts belonging to a specific location..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBankAccountsResponse response from the API call.</returns>
        Task<Models.ListBankAccountsResponse> ListBankAccountsAsync(
                string cursor = null,
                int? limit = null,
                string locationId = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount) identified by V1 bank account ID..
        /// </summary>
        /// <param name="v1BankAccountId">Required parameter: Connect V1 ID of the desired `BankAccount`. For more information, see  [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api)..</param>
        /// <returns>Returns the Models.GetBankAccountByV1IdResponse response from the API call.</returns>
        Models.GetBankAccountByV1IdResponse GetBankAccountByV1Id(
                string v1BankAccountId);

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount) identified by V1 bank account ID..
        /// </summary>
        /// <param name="v1BankAccountId">Required parameter: Connect V1 ID of the desired `BankAccount`. For more information, see  [Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetBankAccountByV1IdResponse response from the API call.</returns>
        Task<Models.GetBankAccountByV1IdResponse> GetBankAccountByV1IdAsync(
                string v1BankAccountId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount).
        /// linked to a Square account..
        /// </summary>
        /// <param name="bankAccountId">Required parameter: Square-issued ID of the desired `BankAccount`..</param>
        /// <returns>Returns the Models.GetBankAccountResponse response from the API call.</returns>
        Models.GetBankAccountResponse GetBankAccount(
                string bankAccountId);

        /// <summary>
        /// Returns details of a [BankAccount]($m/BankAccount).
        /// linked to a Square account..
        /// </summary>
        /// <param name="bankAccountId">Required parameter: Square-issued ID of the desired `BankAccount`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetBankAccountResponse response from the API call.</returns>
        Task<Models.GetBankAccountResponse> GetBankAccountAsync(
                string bankAccountId,
                CancellationToken cancellationToken = default);
    }
}